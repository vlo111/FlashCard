namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public static class SaveDB
    {
        private static SqlCommand comm;

        public static void Answer(List<LogAnswer> answers)
        {
            try
            {
                using (var connection = new SqlConnection(Connection.ConnectionString))
                {
                    connection.Open();
                    foreach (var answer in answers)
                    {
                        var checkAnswer_query = $@"SELECT *
  FROM [Megamind].[dbo].[T_LogAnswer]
  WHERE ([AID] = {answer.AID})";
                        var updateAnswer_query = $@"UPDATE [dbo].[T_LogAnswer]
   SET [Rnk] = {answer.Rnk}
 WHERE AID = {answer.AID}";
                        var insertAnswer_query = $@"INSERT INTO [dbo].[T_LogAnswer]
           ([QUID]
           ,[AID]
           ,[Rnk])
     VALUES
           ({answer.QUID}
           ,{answer.AID}
           ,{answer.Rnk})";

                        using (comm = new SqlCommand(checkAnswer_query, connection))
                        {
                            int? UserExist = (int?)comm.ExecuteScalar();

                            if (UserExist != null && UserExist > 0)
                            {
                                comm = new SqlCommand(updateAnswer_query, connection);
                                comm.ExecuteNonQuery();
                            }
                            else
                            {
                                comm = new SqlCommand(insertAnswer_query, connection);
                                comm.ExecuteNonQuery();
                            }
                        }
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
