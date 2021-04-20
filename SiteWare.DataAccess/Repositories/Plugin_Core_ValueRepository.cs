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
    public static class Plugin_Core_ValueRepository
    {

        public async static Task<ResultList<Plugin_Core_ValueEntity>> SelectAll()
        {
            ResultList<Plugin_Core_ValueEntity> result = new ResultList<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Core_ValueEntity> list = new List<Plugin_Core_ValueEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_Core_ValueEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_Core_ValueEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_Core_ValueEntity> result = new ResultList<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Core_ValueEntity> list = new List<Plugin_Core_ValueEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_Core_ValueEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> Insert(Plugin_Core_ValueEntity entity)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Icon, entity.Icon);              
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.MappedCoreID1, entity.MappedCoreID1);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsPublished, entity.IsPublished);                
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Core_ValueRepositoryConstants.CoreID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.CoreID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Core_ValueRepositoryConstants.CoreID].Value);

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
        public static ResultEntity<Plugin_Core_ValueEntity> InsertNotAsync(Plugin_Core_ValueEntity entity)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.MappedCoreID1, entity.MappedCoreID1);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Core_ValueRepositoryConstants.CoreID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.CoreID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Core_ValueRepositoryConstants.CoreID].Value);

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

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Core_ValueRepositoryConstants.CoreID, ID));
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
        public static ResultEntity<Plugin_Core_ValueEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Core_ValueRepositoryConstants.CoreID, ID));
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

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> Update(Plugin_Core_ValueEntity entity)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();              
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Icon, entity.Icon);              
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.MappedCoreID1, entity.MappedCoreID1);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.CoreID, entity.CoreID);

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
        public static ResultEntity<Plugin_Core_ValueEntity> UpdateNotAsync(Plugin_Core_ValueEntity entity)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();               
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.MappedCoreID1, entity.MappedCoreID1);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.CoreID, entity.CoreID);

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

        public async static Task<ResultEntity<Plugin_Core_ValueEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_Core_ValueEntity> result = new ResultEntity<Plugin_Core_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Core_ValueRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Core_ValueRepositoryConstants.CoreID, ID);

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

        static Plugin_Core_ValueEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_Core_ValueEntity entity = new Plugin_Core_ValueEntity();

            try
            {
                entity.CoreID = Convert.ToInt64(reader[Plugin_Core_ValueEntityConstants.CoreID].ToString());
                entity.Title = reader[Plugin_Core_ValueEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.Title].ToString();
                entity.Summary = reader[Plugin_Core_ValueEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.Summary].ToString();
                entity.Icon = reader[Plugin_Core_ValueEntityConstants.Icon] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.Icon].ToString();               
                entity.Link = reader[Plugin_Core_ValueEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.Link].ToString();
                entity.Target = reader[Plugin_Core_ValueEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.Target].ToString();
                entity.Description = reader[Plugin_Core_ValueEntityConstants.Description] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.Description].ToString();
                entity.Order = reader[Plugin_Core_ValueEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_Core_ValueEntityConstants.Order].ToString());
                entity.MappedCoreID1 = reader[Plugin_Core_ValueEntityConstants.MappedCoreID1] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.MappedCoreID1].ToString();
                entity.PublishedDate = reader[Plugin_Core_ValueEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Core_ValueEntityConstants.PublishedDate].ToString());
                entity.IsPublished = reader[Plugin_Core_ValueEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_Core_ValueEntityConstants.IsPublished].ToString());                
                entity.IsDelete = reader[Plugin_Core_ValueEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_Core_ValueEntityConstants.IsDelete].ToString());
                entity.LanguageID = reader[Plugin_Core_ValueEntityConstants.LanguageID] == DBNull.Value ? 1 : Convert.ToInt32(reader[Plugin_Core_ValueEntityConstants.LanguageID].ToString());
                entity.AddDate = reader[Plugin_Core_ValueEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Core_ValueEntityConstants.AddDate].ToString());
                entity.EditDate = reader[Plugin_Core_ValueEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Core_ValueEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_Core_ValueEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_Core_ValueEntityConstants.EditUser].ToString();
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
                    entity.LanguageName = reader[Plugin_Core_ValueEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_Core_ValueEntityConstants.LanguageName].ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
