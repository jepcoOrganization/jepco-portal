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
   public static class Plugin_NotificationRepository
    {
        public async static Task<ResultEntity<Plugin_NotificationEntity>> SelectByID(long NotificationID)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Notification_RepositoryConstants.NotificationID, NotificationID));
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
        public static ResultEntity<Plugin_NotificationEntity> SelectByIDNotAsync(long NotificationID)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Notification_RepositoryConstants.NotificationID, NotificationID));
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
        public async static Task<ResultList<Plugin_NotificationEntity>> SelectAll()
        {
            ResultList<Plugin_NotificationEntity> result = new ResultList<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_NotificationEntity> list = new List<Plugin_NotificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_NotificationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_NotificationEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_NotificationEntity> result = new ResultList<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_NotificationEntity> list = new List<Plugin_NotificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_NotificationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_NotificationEntity>> Update(Plugin_NotificationEntity entity)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.NotificationID, entity.NotificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Link, entity.Link);
                
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditUser, entity.EditUser);


                await sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
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
        public static ResultEntity<Plugin_NotificationEntity> UpdateNotAsync(Plugin_NotificationEntity entity)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.NotificationID, entity.NotificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
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
        public async static Task<ResultEntity<Plugin_NotificationEntity>> Delete(long NotificationID)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.NotificationID, NotificationID);

                await sqlCommand.ExecuteReaderAsync();

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
        public async static Task<ResultEntity<Plugin_NotificationEntity>> Insert(Plugin_NotificationEntity entity)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(Plugin_Notification_RepositoryConstants.NotificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.NotificationID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Notification_RepositoryConstants.NotificationID].Value);

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
        public static ResultEntity<Plugin_NotificationEntity> InsertNotAsync(Plugin_NotificationEntity entity)
        {

            ResultEntity<Plugin_NotificationEntity> result = new ResultEntity<Plugin_NotificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Notification_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Notification_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Notification_RepositoryConstants.NotificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.NotificationID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Notification_RepositoryConstants.NotificationID].Value);

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

        static Plugin_NotificationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_NotificationEntity entity = new Plugin_NotificationEntity();


            entity.NotificationID = Convert.ToInt64(reader[Plugin_NotificationEntityConstants.NotificationID].ToString());
            entity.Title = reader[Plugin_NotificationEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.Title].ToString();
            entity.Summary = reader[Plugin_NotificationEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.Summary].ToString();
            entity.Image = reader[Plugin_NotificationEntityConstants.Image] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.Image].ToString();
            entity.DateTo = reader[Plugin_NotificationEntityConstants.DateTo] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_NotificationEntityConstants.DateTo].ToString());
            entity.DateFrom = reader[Plugin_NotificationEntityConstants.DateFrom] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_NotificationEntityConstants.DateFrom].ToString());
            entity.Link = reader[Plugin_NotificationEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.Link].ToString();
            entity.Target = reader[Plugin_NotificationEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.Target].ToString();
            entity.Order = reader[Plugin_NotificationEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_NotificationEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_NotificationEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_NotificationEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_NotificationEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_NotificationEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_NotificationEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_NotificationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_NotificationEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_NotificationEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_NotificationEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_NotificationEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_NotificationEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_NotificationEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_NotificationEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_NotificationEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_NotificationEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_NotificationEntityConstants.LanguageName].ToString();
            }

            return entity;
        }

    }
}
