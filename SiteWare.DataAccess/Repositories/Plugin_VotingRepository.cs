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
   public static class Plugin_VotingRepository
    {
        public async static Task<ResultEntity<Plugin_VotingEntity>> SelectByID(long VotingID)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_VotingRepositoryConstants.VotingID, VotingID));
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
        public static ResultEntity<Plugin_VotingEntity> SelectByIDNotAsync(long VotingID)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_VotingRepositoryConstants.VotingID, VotingID));
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
        public async static Task<ResultList<Plugin_VotingEntity>> SelectAll()
        {
            ResultList<Plugin_VotingEntity> result = new ResultList<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_VotingEntity> list = new List<Plugin_VotingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_VotingEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_VotingEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_VotingEntity> result = new ResultList<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_VotingEntity> list = new List<Plugin_VotingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_VotingEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_VotingEntity>> Update(Plugin_VotingEntity entity)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingID, entity.VotingID);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingResult, entity.VotingResult);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_VotingEntity> UpdateNotAsync(Plugin_VotingEntity entity)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingID, entity.VotingID);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingResult, entity.VotingResult);


                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditUser, entity.EditUser);
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
        public async static Task<ResultEntity<Plugin_VotingEntity>> Delete(long VotingID)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingID, VotingID);

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
        public async static Task<ResultEntity<Plugin_VotingEntity>> Insert(Plugin_VotingEntity entity)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingResult, entity.VotingResult);

                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(Plugin_VotingRepositoryConstants.VotingID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.VotingID = Convert.ToInt64(sqlCommand.Parameters[Plugin_VotingRepositoryConstants.VotingID].Value);

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
        public static ResultEntity<Plugin_VotingEntity> InsertNotAsync(Plugin_VotingEntity entity)
        {

            ResultEntity<Plugin_VotingEntity> result = new ResultEntity<Plugin_VotingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_VotingRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.VotingResult, entity.VotingResult);

                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_VotingRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_VotingRepositoryConstants.VotingID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.VotingID = Convert.ToInt64(sqlCommand.Parameters[Plugin_VotingRepositoryConstants.VotingID].Value);

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

        static Plugin_VotingEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_VotingEntity entity = new Plugin_VotingEntity();


            entity.VotingID = Convert.ToInt64(reader[Plugin_VotingEntityConstants.VotingID].ToString());
            entity.VotingResult = reader[Plugin_VotingEntityConstants.VotingResult] == DBNull.Value ? string.Empty : reader[Plugin_VotingEntityConstants.VotingResult].ToString();
            entity.Order = reader[Plugin_VotingEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_VotingEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_VotingEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_VotingEntityConstants.LanguageID].ToString());
            entity.PublishedDate = reader[Plugin_VotingEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_VotingEntityConstants.PublishedDate].ToString());
            entity.IsPublished = reader[Plugin_VotingEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_VotingEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_VotingEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_VotingEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_VotingEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_VotingEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_VotingEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_VotingEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_VotingEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_VotingEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_VotingEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_VotingEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_VotingEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_VotingEntityConstants.LanguageName].ToString();
            }

            return entity;
        }

    }
}
