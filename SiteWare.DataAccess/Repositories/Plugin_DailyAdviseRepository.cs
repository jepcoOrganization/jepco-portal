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
   public static class Plugin_DailyAdviseRepository
    {
        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> SelectByID(long AdviseID)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_DailyAdviseRepositoryConstants.AdviseID, AdviseID));
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
        public static ResultEntity<Plugin_DailyAdviseEntity> SelectByIDNotAsync(long AdviseID)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_DailyAdviseRepositoryConstants.AdviseID, AdviseID));
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
        public async static Task<ResultList<Plugin_DailyAdviseEntity>> SelectAll()
        {
            ResultList<Plugin_DailyAdviseEntity> result = new ResultList<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_DailyAdviseEntity> list = new List<Plugin_DailyAdviseEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_DailyAdviseEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_DailyAdviseEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_DailyAdviseEntity> result = new ResultList<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_DailyAdviseEntity> list = new List<Plugin_DailyAdviseEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_DailyAdviseEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> Update(Plugin_DailyAdviseEntity entity)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AdviseID, entity.AdviseID);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Link, entity.Link);

                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_DailyAdviseEntity> UpdateNotAsync(Plugin_DailyAdviseEntity entity)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AdviseID, entity.AdviseID);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditUser, entity.EditUser);
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
        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> Delete(long AdviseID)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AdviseID, AdviseID);

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
        public async static Task<ResultEntity<Plugin_DailyAdviseEntity>> Insert(Plugin_DailyAdviseEntity entity)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(Plugin_DailyAdviseRepositoryConstants.AdviseID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.AdviseID = Convert.ToInt64(sqlCommand.Parameters[Plugin_DailyAdviseRepositoryConstants.AdviseID].Value);

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
        public static ResultEntity<Plugin_DailyAdviseEntity> InsertNotAsync(Plugin_DailyAdviseEntity entity)
        {

            ResultEntity<Plugin_DailyAdviseEntity> result = new ResultEntity<Plugin_DailyAdviseEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_DailyAdviseRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateTo, entity.DateTo);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.DateFrom, entity.DateFrom);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_DailyAdviseRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_DailyAdviseRepositoryConstants.AdviseID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.AdviseID = Convert.ToInt64(sqlCommand.Parameters[Plugin_DailyAdviseRepositoryConstants.AdviseID].Value);

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

        static Plugin_DailyAdviseEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_DailyAdviseEntity entity = new Plugin_DailyAdviseEntity();


            entity.AdviseID = Convert.ToInt64(reader[Plugin_DailyAdviseEntityConstants.AdviseID].ToString());
            entity.Title = reader[Plugin_DailyAdviseEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.Title].ToString();
            entity.Summary = reader[Plugin_DailyAdviseEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.Summary].ToString();
            entity.Image = reader[Plugin_DailyAdviseEntityConstants.Image] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.Image].ToString();
            entity.DateTo = reader[Plugin_DailyAdviseEntityConstants.DateTo] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_DailyAdviseEntityConstants.DateTo].ToString());
            entity.DateFrom = reader[Plugin_DailyAdviseEntityConstants.DateFrom] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_DailyAdviseEntityConstants.DateFrom].ToString());
            entity.Link = reader[Plugin_DailyAdviseEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.Link].ToString();
            entity.Target = reader[Plugin_DailyAdviseEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.Target].ToString();
            entity.Order = reader[Plugin_DailyAdviseEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_DailyAdviseEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_DailyAdviseEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_DailyAdviseEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_DailyAdviseEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_DailyAdviseEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_DailyAdviseEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_DailyAdviseEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_DailyAdviseEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_DailyAdviseEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_DailyAdviseEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_DailyAdviseEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_DailyAdviseEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_DailyAdviseEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_DailyAdviseEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_DailyAdviseEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_DailyAdviseEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_DailyAdviseEntityConstants.LanguageName].ToString();
            }

            return entity;
        }

    }
}
