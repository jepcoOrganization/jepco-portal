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
    public class Plugin_TimelineRepository
    {

        public async static Task<ResultList<Plugin_TimelineEntity>> SelectAll()
        {
            ResultList<Plugin_TimelineEntity> result = new ResultList<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_TimelineEntity> list = new List<Plugin_TimelineEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_TimelineEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_TimelineEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_TimelineEntity> result = new ResultList<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_TimelineEntity> list = new List<Plugin_TimelineEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_TimelineEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_TimelineEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_TimelineRepositoryConstants.TimelineID, ID));
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
        public static ResultEntity<Plugin_TimelineEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_TimelineRepositoryConstants.TimelineID, ID));
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

        public async static Task<ResultEntity<Plugin_TimelineEntity>> Insert(Plugin_TimelineEntity entity)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Summary, entity.Summary);              
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditUser, entity.EditUser);
              
                sqlCommand.Parameters.Add(Plugin_TimelineRepositoryConstants.TimelineID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.TimelineID = Convert.ToInt32(sqlCommand.Parameters[Plugin_TimelineRepositoryConstants.TimelineID].Value);

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
        public static ResultEntity<Plugin_TimelineEntity> InsertNotAsync(Plugin_TimelineEntity entity)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditUser, entity.EditUser);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.TimelineID = Convert.ToInt32(sqlCommand.Parameters[Plugin_TimelineRepositoryConstants.TimelineID].Value);

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

        public async static Task<ResultEntity<Plugin_TimelineEntity>> Update(Plugin_TimelineEntity entity)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Summary, entity.Summary);                
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.TimelineID, entity.TimelineID);


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
        public static ResultEntity<Plugin_TimelineEntity> UpdateNotAsync(Plugin_TimelineEntity entity)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.TimelineID, entity.TimelineID);

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

        public async static Task<ResultEntity<Plugin_TimelineEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_TimelineEntity> result = new ResultEntity<Plugin_TimelineEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TimelineRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_TimelineRepositoryConstants.TimelineID, ID);

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

        static Plugin_TimelineEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_TimelineEntity entity = new Plugin_TimelineEntity();

            try
            {
                entity.TimelineID = Convert.ToInt64(reader[Plugin_TimelineEntityConstants.TimelineID].ToString());
                entity.Title = reader[Plugin_TimelineEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.Title].ToString();
                entity.Summary = reader[Plugin_TimelineEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.Summary].ToString();
                
                entity.FocusID = Convert.ToInt64(reader[Plugin_TimelineEntityConstants.FocusID].ToString());
                entity.Description = reader[Plugin_TimelineEntityConstants.Description] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.Description].ToString();
                entity.Year = reader[Plugin_TimelineEntityConstants.Year] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.Year].ToString();
                entity.Order = reader[Plugin_TimelineEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_TimelineEntityConstants.Order].ToString());
                entity.PublishedDate = reader[Plugin_TimelineEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_TimelineEntityConstants.PublishedDate].ToString());
                entity.IsPublished = reader[Plugin_TimelineEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_TimelineEntityConstants.IsPublished].ToString());
                entity.IsDelete = reader[Plugin_TimelineEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_TimelineEntityConstants.IsDelete].ToString());
                entity.LanguageID = reader[Plugin_TimelineEntityConstants.LanguageID] == DBNull.Value ? 1 : Convert.ToInt32(reader[Plugin_TimelineEntityConstants.LanguageID].ToString());

                entity.AddDate = reader[Plugin_TimelineEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_TimelineEntityConstants.AddDate].ToString());
                entity.EditDate = reader[Plugin_TimelineEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_TimelineEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_TimelineEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_TimelineEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.EditUser].ToString();
                
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
                    entity.LanguageName = reader[Plugin_TimelineEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.LanguageName].ToString();
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("PluginAreaTitle");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.PluginAreaTitle = reader[Plugin_TimelineEntityConstants.PluginAreaTitle] == DBNull.Value ? string.Empty : reader[Plugin_TimelineEntityConstants.PluginAreaTitle].ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
