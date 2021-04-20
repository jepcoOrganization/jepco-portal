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
    public static class MessagesAndNotificationsRepository
    {
        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> SelectByID(long NotificationID)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(MessagesAndNotificationsRepositoryConstants.NotificationID, NotificationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    reader.Read();
                    result.Entity = EntityHelper(reader, true);
                }
                else
                {
                    result.Status = ErrorEnums.Warning;
                    result.Message = MessageConstants.NotFoundMessage;
                    result.Details = MessageConstants.NotFoundDetails;
                }
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
        public static ResultEntity<MessagesAndNotificationsEntity> SelectByIDNotAsync(long NotificationID)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(MessagesAndNotificationsRepositoryConstants.NotificationID, NotificationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result.Entity = EntityHelper(reader, true);
                }
                else
                {
                    result.Status = ErrorEnums.Warning;
                    result.Message = MessageConstants.NotFoundMessage;
                    result.Details = MessageConstants.NotFoundDetails;
                }
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
        public async static Task<ResultList<MessagesAndNotificationsEntity>> SelectAll()
        {
            ResultList<MessagesAndNotificationsEntity> result = new ResultList<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MessagesAndNotificationsEntity> list = new List<MessagesAndNotificationsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    MessagesAndNotificationsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<MessagesAndNotificationsEntity> SelectAllNotAsync()
        {
            ResultList<MessagesAndNotificationsEntity> result = new ResultList<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MessagesAndNotificationsEntity> list = new List<MessagesAndNotificationsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    MessagesAndNotificationsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> Insert(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                //sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.MsgFromUserID, entity.MsgFromUserID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.FromUserType, entity.FromUserType);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.MsgToUserID, entity.MsgToUserID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.ToUserType, entity.ToUserType);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Subject, entity.Subject);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment1, entity.Attachment1);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment4, entity.Attachment4);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.IsRead, entity.IsRead);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.RequestType, entity.RequestType);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.EditUser, entity.EditUser);






                sqlCommand.Parameters.Add(MessagesAndNotificationsRepositoryConstants.NotificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.NotificationID = Convert.ToInt64(sqlCommand.Parameters[MessagesAndNotificationsRepositoryConstants.NotificationID].Value);

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
        public static ResultEntity<MessagesAndNotificationsEntity> InsertNotAsync(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.MsgFromUserID, entity.MsgFromUserID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.FromUserType, entity.FromUserType);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.MsgToUserID, entity.MsgToUserID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.ToUserType, entity.ToUserType);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Subject, entity.Subject);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment1, entity.Attachment1);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Attachment4, entity.Attachment4);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.IsRead, entity.IsRead);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.RequestType, entity.RequestType);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(MessagesAndNotificationsRepositoryConstants.NotificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.NotificationID = Convert.ToInt64(sqlCommand.Parameters[MessagesAndNotificationsRepositoryConstants.NotificationID].Value);

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
        static MessagesAndNotificationsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            MessagesAndNotificationsEntity entity = new MessagesAndNotificationsEntity();

            try
            {

                entity.NotificationID = Convert.ToInt64(reader[MessagesAndNotificationsEntityConstants.NotificationID].ToString());
                entity.MsgFromUserID = reader[MessagesAndNotificationsEntityConstants.MsgFromUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[MessagesAndNotificationsEntityConstants.MsgFromUserID].ToString());
                entity.FromUserType = reader[MessagesAndNotificationsEntityConstants.FromUserType] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.FromUserType].ToString();
                entity.MsgToUserID = reader[MessagesAndNotificationsEntityConstants.MsgToUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[MessagesAndNotificationsEntityConstants.MsgToUserID].ToString());
                entity.ToUserType = reader[MessagesAndNotificationsEntityConstants.ToUserType] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.ToUserType].ToString();

                entity.Subject = reader[MessagesAndNotificationsEntityConstants.Subject] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.Subject].ToString();
                entity.Description = reader[MessagesAndNotificationsEntityConstants.Description] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.Description].ToString();
                entity.Attachment1 = reader[MessagesAndNotificationsEntityConstants.Attachment1] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.Attachment1].ToString();
                entity.Attachment2 = reader[MessagesAndNotificationsEntityConstants.Attachment2] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.Attachment2].ToString();
                entity.Attachment3 = reader[MessagesAndNotificationsEntityConstants.Attachment3] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.Attachment3].ToString();
                entity.Attachment4 = reader[MessagesAndNotificationsEntityConstants.Attachment4] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.Attachment4].ToString();

                entity.IsRead = reader[MessagesAndNotificationsEntityConstants.IsRead] == DBNull.Value ? false : Convert.ToBoolean(reader[MessagesAndNotificationsEntityConstants.IsRead].ToString());
                entity.RequestID = reader[MessagesAndNotificationsEntityConstants.RequestID] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.RequestID].ToString();
                entity.RequestType = reader[MessagesAndNotificationsEntityConstants.RequestType] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.RequestType].ToString();

                entity.Order = reader[MessagesAndNotificationsEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[MessagesAndNotificationsEntityConstants.Order].ToString());
                entity.LanguageID = reader[MessagesAndNotificationsEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[MessagesAndNotificationsEntityConstants.LanguageID].ToString());
                entity.PublishDate = reader[MessagesAndNotificationsEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[MessagesAndNotificationsEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[MessagesAndNotificationsEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[MessagesAndNotificationsEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[MessagesAndNotificationsEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[MessagesAndNotificationsEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[MessagesAndNotificationsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[MessagesAndNotificationsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[MessagesAndNotificationsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[MessagesAndNotificationsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[MessagesAndNotificationsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[MessagesAndNotificationsEntityConstants.EditUser].ToString();

                bool ColumnExists = false;
                try
                {
                    int columnOrdinal = reader.GetOrdinal("LanguageName");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.LanguageName = reader[MessagesAndNotificationsEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[MessagesAndNotificationsEntityConstants.LanguageName].ToString();
                }

            }
            catch (Exception ex)
            {

            }

            return entity;
        }


        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> Delete(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);

                await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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

        public static ResultEntity<MessagesAndNotificationsEntity> DeleteNotAsync(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);

                sqlCommand.ExecuteReader();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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



        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> UnRead(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_UnRead, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);

                await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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

        public static ResultEntity<MessagesAndNotificationsEntity> UnReadNotAsync(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_UnRead, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);

                sqlCommand.ExecuteReader();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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


        public async static Task<ResultEntity<MessagesAndNotificationsEntity>> Read(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_Read, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);

                await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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

        public static ResultEntity<MessagesAndNotificationsEntity> ReadNotAsync(MessagesAndNotificationsEntity entity)
        {

            ResultEntity<MessagesAndNotificationsEntity> result = new ResultEntity<MessagesAndNotificationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MessagesAndNotificationsRepositoryConstants.SP_Read, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MessagesAndNotificationsRepositoryConstants.NotificationID, entity.NotificationID);

                sqlCommand.ExecuteReader();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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


    }
}


