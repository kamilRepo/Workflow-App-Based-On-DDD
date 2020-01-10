using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Base.Infrastructure.Loggers
{
    public static class DBLogger
    {
        public static void OwnApp(ApplicationLayerException ex)
        {
            var message = ex.Message.Replace("'", "");
            var errorNumber = ex.ErrorNumber;
            var messageContent = ex.MessageContent;
            var userId = ex.UserId;

            string query = @"
                INSERT INTO dbo.B_ApplicationError
                       (C_User_id
                       ,C_Date
                       ,ErrorNumber
                       ,Message
                       ,MessageContent
                       ,Status
                       ,IsUserError)
                 VALUES
                       (#UserId#
                       ,CAST(N'#Date#' AS DateTime)
                       ,#ErrorNumber#
                       ,'#Message#'
                       ,'#MessageContent#'                        
                       ,0
                       ,0);
            ";

            query = query.Replace("#UserId#", userId == null ? "null" : userId.ToString());
            query = query.Replace("#Date#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            query = query.Replace("#ErrorNumber#", ((long)errorNumber).ToString());
            query = query.Replace("#Message#", message);
            query = query.Replace("#MessageContent#", messageContent);

            DatabaseSave(query);

            throw ex;
        }

        public static void OwnUser(UserException ex)
        {
            var message = ex.Message.Replace("'", "");
            var errorNumber = ex.ErrorNumber;
            var messageContent = ex.MessageContent;
            var userId = ex.UserId;

            string query = @"
                INSERT INTO dbo.B_ApplicationError
                       (C_User_id
                       ,C_Date
                       ,ErrorNumber
                       ,Message
                       ,MessageContent
                       ,Status
                       ,IsUserError)
                 VALUES
                       (#UserId#
                       ,CAST(N'#Date#' AS DateTime)
                       ,#ErrorNumber#
                       ,'#Message#'
                       ,'#MessageContent#'                        
                       ,0
                       ,1);
            ";

            query = query.Replace("#UserId#", userId == null ? "null" : userId.ToString());
            query = query.Replace("#Date#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            query = query.Replace("#ErrorNumber#", ((long)errorNumber).ToString());
            query = query.Replace("#Message#", message);
            query = query.Replace("#MessageContent#", messageContent);

            DatabaseSave(query);

            throw ex;
        }

        public static void UnhandledException(Exception ex, ErrorNumbers errorNumber, string messageContent, int? userId)
        {
            var message = ex.Message.Replace("'", "");

            string query = @"
                INSERT INTO dbo.B_ApplicationError
                       (C_User_id
                       ,C_Date
                       ,ErrorNumber
                       ,Message
                       ,MessageContent
                       ,Status
                       ,IsUserError)
                 VALUES
                       (#UserId#
                       ,CAST(N'#Date#' AS DateTime)
                       ,#ErrorNumber#
                       ,'#Message#'
                       ,'#MessageContent#'                        
                       ,0
                       ,0);
            ";

            query = query.Replace("#UserId#", userId == null ? "null" : userId.ToString());
            query = query.Replace("#Date#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            query = query.Replace("#ErrorNumber#", ((long)errorNumber).ToString());
            query = query.Replace("#Message#", message);
            query = query.Replace("#MessageContent#", messageContent);

            DatabaseSave(query);

            throw new ApplicationLayerException(message, messageContent, errorNumber, userId);
        }

        private static void DatabaseSave(string query)
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                var conection = new SqlConnection(conStr);
                using (var con = conection)
                {
                    con.Open();

                    using (var command = con.CreateCommand())
                    {
                        try
                        {
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }
                        finally { con.Close(); }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("#START# Exception: ");
                    sb.Append(Environment.NewLine);
                    sb.Append(ex.Message);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Query: ");
                    sb.Append(Environment.NewLine);
                    sb.Append(query);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("#END#");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                
                    Logger.Instance.LogError(sb.ToString(), ex);
                }
                catch { }
            }
        }
    }
}
