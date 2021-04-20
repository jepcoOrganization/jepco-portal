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
    public static class Plugin_AboutUsRepository
    {
        public static ResultList<Plugin_AboutUsEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_AboutUsEntity> result = new ResultList<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_AboutUsEntity> list = new List<Plugin_AboutUsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_AboutUsEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Plugin_AboutUsEntity>> SelectAll()
        {
            ResultList<Plugin_AboutUsEntity> result = new ResultList<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_AboutUsEntity> list = new List<Plugin_AboutUsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_AboutUsEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> AboutUs_SelectByID(int ID)
        {

            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_AboutUsRepositoryConstants.ID, ID));
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
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> Plugin_AboutUs_UpdateByIsDelete(Plugin_AboutUsEntity entity)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_UpdateByIsDelete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginContactUsRepositoryConstants.ID, entity.ID));
                sqlCommand.Parameters.Add(new SqlParameter(PluginContactUsRepositoryConstants.IsDeleted, entity.IsDeleted));
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
        public static ResultEntity<Plugin_AboutUsEntity> Plugin_AboutUs_UpdateByIsDeleteNotAsync(Plugin_AboutUsEntity entity)
        {
            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_UpdateByIsDelete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginContactUsRepositoryConstants.ID, entity.ID));
                sqlCommand.Parameters.Add(new SqlParameter(PluginContactUsRepositoryConstants.IsDeleted, entity.IsDeleted));
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
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> Update(Plugin_AboutUsEntity entity)
        {

            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Target, entity.Target);                
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Order, entity.Order);


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
        public async static Task<ResultEntity<Plugin_AboutUsEntity>> Insert(Plugin_AboutUsEntity entity)
        {

            ResultEntity<Plugin_AboutUsEntity> result = new ResultEntity<Plugin_AboutUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutUsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Target, entity.Target);                
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutUsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.Add(Plugin_AboutUsRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

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
        static Plugin_AboutUsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_AboutUsEntity entity = new Plugin_AboutUsEntity();
            try
            {
                entity.ID = Convert.ToInt32(reader[Plugin_AboutUsEntityConstants.ID].ToString());
                entity.Title = reader[Plugin_AboutUsEntityConstants.Title].ToString();
                entity.Image = reader[Plugin_AboutUsEntityConstants.Image].ToString();
                entity.LanguageID = Convert.ToInt32(reader[Plugin_AboutUsEntityConstants.LanguageID].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[Plugin_AboutUsEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[Plugin_AboutUsEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[Plugin_AboutUsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_AboutUsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_AboutUsEntityConstants.EditUser].ToString();
                entity.Summary = reader[Plugin_AboutUsEntityConstants.Summary]==DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_AboutUsEntityConstants.Summary]);
                entity.IsPublished = reader[Plugin_AboutUsEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_AboutUsEntityConstants.IsPublished]);
                entity.PublishedDate = reader[Plugin_AboutUsEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_AboutUsEntityConstants.PublishedDate]);
                entity.Order = reader[Plugin_AboutUsEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_AboutUsEntityConstants.Order]);

                bool ColumnExists = false;

                try
                {
                    int columnOrdinal = reader.GetOrdinal("Link");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }
                if (ColumnExists)
                {
                    entity.Link = reader[Plugin_AboutUsEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_AboutUsEntityConstants.Link].ToString();
                }
                
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Target");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }
                if (ColumnExists)
                {
                    entity.Target = reader[Plugin_AboutUsEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_AboutUsEntityConstants.Target].ToString();
                }
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
                    entity.LanguageName = reader[Plugin_AboutUsEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_AboutUsEntityConstants.LanguageName].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            return entity;
        }
    }
}
