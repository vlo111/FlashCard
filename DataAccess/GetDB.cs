namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public static class GetDB
    {
        private static List<DomainDto> domains = new List<DomainDto>();

        private static List<QuestionDto> questions = new List<QuestionDto>();

        private static List<AnswerDto> answers = new List<AnswerDto>();

        private static List<LogAnswer> wrongAnswers = new List<LogAnswer>();

        private static List<QuestionDto> wrongQuestions = new List<QuestionDto>();

        private static SqlCommand command;

        public static List<QuestionDto> GetQuestion(List<DomainDto> domains)
        {
            try
            {
                questions.Clear();
                answers.Clear();

                using (var connection = new SqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    var domainIds = string.Join(", ", domains.Select(p => p.ID));

                    var get_question_query = $@"SELECT q.[QUID]
      ,q.[DomainID]
      ,q.[Question]
      ,q.[QType]
      ,q.[stscd]
	  ,a.AID
	  ,a.Rnk
	  ,a.Message
  FROM [Megamind].[dbo].[T_QuestionBank] q
  LEFT JOIN T_AnswerBank a WITH(NOLOCK) on q.QUID = a.QUID
  WHERE q.DomainID IN ({domainIds})";

                    using (command = new SqlCommand(get_question_query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    questions.Add(
                                        new QuestionDto
                                            {
                                                Id = (int)reader.GetValue(0),
                                                DomainId = (int)reader.GetValue(1),
                                                Question = (string)reader.GetValue(2),
                                                QType = (int)reader.GetValue(3)
                                            });

                                    answers.Add(
                                        new AnswerDto
                                            {
                                                Id = (int)reader.GetValue(5),
                                                QuestionId = (int)reader.GetValue(0),
                                                QuestionType = (int)reader.GetValue(3),
                                                Rnk = (int)reader.GetValue(6),
                                                Message = (string)reader.GetValue(7)
                                            });
                                }

                                questions = questions.GroupBy(x => x.Id).Select(g => g.First()).ToList();

                                questions.ForEach(
                                    question =>
                                        {
                                            answers.ForEach(
                                                answer =>
                                                    {
                                                        if (question.Id != answer.QuestionId)
                                                        {
                                                            return;
                                                        }

                                                        question.Answers = question.Answers ?? new List<AnswerDto>();

                                                        question.Answers.Add(answer);
                                                    });
                                        });
                            }
                        }
                    }

                    return questions;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<DomainDto> GetAllDomains()
        {
            try
            {
                domains.Clear();
                using (var connection = new SqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    var get_domain_query = $@"SELECT d.[ID]
      ,d.[Domain]
      ,d.[Info]
  FROM [Megamind].[dbo].[T_DomainBank] d";
                    using (command = new SqlCommand(get_domain_query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    domains.Add(
                                        new DomainDto
                                            {
                                                ID = (int)reader.GetValue(0),
                                                Name = (string)reader.GetValue(1),
                                                Info = !reader.IsDBNull(2) ? (string)reader.GetValue(2) : string.Empty
                                            });
                                }
                            }
                        }
                    }
                }

                return domains;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<QuestionDto> GetAllWrongQuestions()
        {
            try
            {
                wrongAnswers.Clear();
                wrongQuestions.Clear();
                using (var connection = new SqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    var wrongAllAnswers_query = $@"SELECT LA.[ID]
      ,LA.[QUID]
      ,LA.[AID]
      ,LA.[Rnk]
  FROM [Megamind].[dbo].[T_LogAnswer] LA";

                    using (command = new SqlCommand(wrongAllAnswers_query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    wrongAnswers.Add(
                                        new LogAnswer
                                            {
                                                Id = (int)reader.GetValue(0),
                                                QUID = (int)reader.GetValue(1),
                                                AID = (int)reader.GetValue(2),
                                                Rnk = (int)reader.GetValue(3)
                                            });
                                }
                            }
                        }
                    }

                    var wrongQuetionIds = wrongAnswers.GroupBy(p => p.QUID).Select(p => p.First().QUID).ToList();

                    questions.ForEach(
                        question =>
                            {
                                if (wrongQuetionIds.Contains(question.Id))
                                {
                                    wrongQuestions.Add(question);
                                }
                            });

                    foreach (var wrongQuestion in wrongQuestions)
                    {
                        foreach (var wrongQuestionAnswer in wrongQuestion.Answers)
                        {
                            wrongAnswers.ForEach(
                                p =>
                                    {
                                        if (p.AID == wrongQuestionAnswer.Id)
                                        {
                                            wrongQuestionAnswer.WrongRnk = p.Rnk;
                                        }
                                    });
                        }
                    }

                    return wrongQuestions;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}