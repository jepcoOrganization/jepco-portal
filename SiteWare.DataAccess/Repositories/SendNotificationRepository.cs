using SiteWare.DataAccess.Common.Constants;
using SiteWare.DataAccess.RepositorieConstants;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Constants.Entity;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.Repositories
{
    public class SendNotificationRepository
    {
        public async static Task<ResultEntity<SendNotificationEntity>> InsertNotification(SendNotificationEntity entity)
        {

            ResultEntity<SendNotificationEntity> result = new ResultEntity<SendNotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SendNotificationRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.SendNotificationID, entity.SendNotificationID);
                //sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.DeviceID, entity.DeviceID);
                sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.NotificationType, entity.NotificationType);
                sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.NotificationID, entity.NotificationID);
                sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.Notification, entity.Notification);
                sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.IoSnotificationResult, entity.IoSnotificationResult);
                sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.AndroidnotificationResult, entity.AndroidnotificationResult);
                sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.DateGenerated, DateTime.Now);
                sqlCommand.Parameters.Add(SendNotificationRepositoryConstants.SendNotificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                // sqlCommand.Parameters.AddWithValue(SendNotificationRepositoryConstants.DateGenerated, DateTime.Now);

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }

        public async static Task<ResultList<SendNotificationEntity>> SelectAll()
        {
            ResultList<SendNotificationEntity> result = new ResultList<SendNotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SendNotificationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SendNotificationEntity> list = new List<SendNotificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    SendNotificationEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    reader.Close();

                    result.List = list;

                }
                else
                {
                    result.Status = ErrorEnums.Information;
                    result.Details = MessageConstants.CannotFindAllMessage;
                    result.Message = MessageConstants.CannotFindAllDetails;
                }
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Message = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }

        static SendNotificationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            SendNotificationEntity entity = new SendNotificationEntity();

            entity.SendNotificationID = Convert.ToInt64(reader[SendNotificationEntityConstants.SendNotificationID].ToString());
            entity.DeviceID = reader[SendNotificationEntityConstants.DeviceID].ToString();
            entity.NotificationType = reader[SendNotificationEntityConstants.NotificationType].ToString();
            entity.NotificationID = Convert.ToInt32(reader[SendNotificationEntityConstants.NotificationID].ToString());
            entity.Notification = reader[SendNotificationEntityConstants.Notification].ToString();
            entity.IoSnotificationResult = reader[SendNotificationEntityConstants.IoSnotificationResult].ToString();
            entity.AndroidnotificationResult = reader[SendNotificationEntityConstants.AndroidnotificationResult].ToString();
            entity.DateGenerated = Convert.ToDateTime(reader[SendNotificationEntityConstants.DateGenerated].ToString());
            entity.DateGeneratedDate = reader[SendNotificationEntityConstants.DateGenerated].ToString();
            return entity;
        }
    }
}
