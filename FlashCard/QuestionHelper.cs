namespace FlashCard
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;

    using DataAccess;

    using Telerik.WinControls.UI;

    public class QuestionHelper
    {
        public List<QuestionDto> questions = new List<QuestionDto>();

        public QuestionDto currentQuestion = new QuestionDto();

        public List<QuestionDto> wrongQuestions = new List<QuestionDto>();

        public QuestionDto currentWrongQuestion = new QuestionDto();

        public int CurrentIndex { get; set; }

        public int CurrentSuinceIndex { get; set; }

        public int WrongAnweredCount { get; set; }

        public QuestionHelper()
        {
            this.CurrentIndex = 0;

            this.CurrentSuinceIndex = 0;

            this.WrongAnweredCount = 0;
        }

        public List<RadListDataItem> NextNormal()
        {
            if (this.questions != null && this.CurrentIndex < this.questions.Count)
            {
                this.currentQuestion = this.questions.ElementAt(this.CurrentIndex++);

                var listDataItemAnswers = new List<RadListDataItem>();

                foreach (var currentQuestionAnswer in this.currentQuestion.Answers)
                {
                    listDataItemAnswers.Add(
                        new RadListDataItem
                            {
                                TextWrap = true,
                                Height = 60,
                                Text =
                                    $"({(char)(currentQuestionAnswer.Rnk + 64)})\r\n {currentQuestionAnswer.Message}",
                                Value = currentQuestionAnswer.Id,
                                Image = Image.FromFile(
                                    System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)
                                        ?.Replace("\\bin\\Debug", string.Empty) + "\\Icons\\menu.png"),
                                ImageAlignment = ContentAlignment.TopLeft
                            });
                }

                return listDataItemAnswers;
            }

            return null;
        }

        public List<RadListDataItem> NextSuinceMode()
        {
            if (this.wrongQuestions != null && this.CurrentSuinceIndex < this.wrongQuestions.Count)
            {
                var listDataItemAnswers = new List<RadListDataItem>();

                this.currentWrongQuestion = this.wrongQuestions.ElementAt(this.CurrentSuinceIndex++);

                var index = 64;

                foreach (var wrongQuestionAnswer in this.currentWrongQuestion.Answers)
                {
                    if (wrongQuestionAnswer.Rnk != wrongQuestionAnswer.WrongRnk)
                    {
                        listDataItemAnswers.Add(
                            new RadListDataItem
                                {
                                    TextWrap = true,
                                    Height = 60,
                                    Text = $"({(char)++index})\r\n {wrongQuestionAnswer.Message}",
                                    Value = wrongQuestionAnswer.Id,
                                    Image = Image.FromFile(
                                        System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)
                                            ?.Replace("\\bin\\Debug", string.Empty) + "\\Icons\\sad.png"),
                                    ImageAlignment = ContentAlignment.TopLeft
                                });
                    }
                    else
                    {
                        listDataItemAnswers.Add(
                            new RadListDataItem
                                {
                                    TextWrap = true,
                                    Height = 60,
                                    Text = $"({(char)++index})\r\n {wrongQuestionAnswer.Message}",
                                    Value = wrongQuestionAnswer.Id,
                                    Image = Image.FromFile(
                                        System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)
                                            ?.Replace("\\bin\\Debug", string.Empty) + "\\Icons\\smile.png"),
                                    ImageAlignment = ContentAlignment.TopLeft
                                });
                    }
                }

                return listDataItemAnswers;
            }

            return null;
        }

        public void LogAnswers(ICollection<AnswerDto> currentAnswers, RadListControl answerCorrectList, string mode)
        {
            bool wrongAnswer = false;

            var logAnswer = new List<LogAnswer>();

            foreach (var currentAnswer in currentAnswers)
            {
                foreach (var item in answerCorrectList.Items)
                {
                    if (currentAnswer.Id == (int)item.Value)
                    {
                        logAnswer.Add(
                            new LogAnswer
                                {
                                    AID = currentAnswer.Id, QUID = currentAnswer.QuestionId, Rnk = item.Index + 1
                                });

                        if (currentAnswer.Rnk != item.Index + 1)
                        {
                            wrongAnswer = true;
                        }
                    }
                }
            }

            if (wrongAnswer)
            {
                if (mode == "Normal")
                {
                    this.WrongAnweredCount++;
                }

                // Log answers, if answered incorrectly
                SaveDB.Answer(logAnswer);
            }
            else
            {
                // delete if answered correctly(if it exist) 
                RemoveDB.TryDeleteAnswers(currentAnswers);
            }
        }
    }
}