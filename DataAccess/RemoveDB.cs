namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public static class RemoveDB
    {
        private static SqlCommand comm;

        public static void TryDeleteAnswers(ICollection<AnswerDto> answers)
        {
            try
            {
                using (var connection = new SqlConnection(Connection.ConnectionString))
                {
                    connection.Open();

                    var answerIds = string.Join(", ", answers.Select(p => p.Id));

                    var checkAnswer_query = $@"DELETE FROM [dbo].[T_LogAnswer] 
WHERE [AID] IN ({answerIds})";

                    using (comm = new SqlCommand(checkAnswer_query, connection))
                    {
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}