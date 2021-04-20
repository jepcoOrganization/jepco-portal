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
    public static class Plugin_Video_Repository
    {
        public async static Task<ResultEntity<Plugin_VideoEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Video_RepositoryConstants.ID, ID));
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
        public static ResultEntity<Plugin_VideoEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Video_RepositoryConstants.ID, ID));
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
        public async static Task<ResultList<Plugin_VideoEntity>> SelectAll()
        {
            ResultList<Plugin_VideoEntity> result = new ResultList<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_VideoEntity> list = new List<Plugin_VideoEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_VideoEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_VideoEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_VideoEntity> result = new ResultList<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_VideoEntity> list = new List<Plugin_VideoEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_VideoEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_VideoEntity>> Update(Plugin_VideoEntity entity)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.CoverImage, entity.CoverImage);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_VideoEntity> UpdateNotAsync(Plugin_VideoEntity entity)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.CoverImage, entity.CoverImage);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditUser, entity.EditUser);
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
        public async static Task<ResultEntity<Plugin_VideoEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.ID, ID);

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
        public async static Task<ResultEntity<Plugin_VideoEntity>> Insert(Plugin_VideoEntity entity)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.CoverImage, entity.CoverImage);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(Plugin_Video_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Video_RepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_VideoEntity> InsertNotAsync(Plugin_VideoEntity entity)
        {

            ResultEntity<Plugin_VideoEntity> result = new ResultEntity<Plugin_VideoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Video_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.CoverImage, entity.CoverImage);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Video_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Video_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Video_RepositoryConstants.ID].Value);

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

        static Plugin_VideoEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_VideoEntity entity = new Plugin_VideoEntity();


            entity.ID = Convert.ToInt64(reader[Plugin_Video_EntityConstants.ID].ToString());
            entity.Title = reader[Plugin_Video_EntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.Title].ToString();
            entity.CoverImage = reader[Plugin_Video_EntityConstants.CoverImage] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.CoverImage].ToString();
            entity.Link = reader[Plugin_Video_EntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.Link].ToString();
            entity.Target = reader[Plugin_Video_EntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.Target].ToString();
            entity.Order = reader[Plugin_Video_EntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_Video_EntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_Video_EntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_Video_EntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_Video_EntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Video_EntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_Video_EntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_Video_EntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_Video_EntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_Video_EntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_Video_EntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Video_EntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_Video_EntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_Video_EntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Video_EntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_Video_EntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_Video_EntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_Video_EntityConstants.LanguageName].ToString();
            }

            return entity;
        }

    }
}
