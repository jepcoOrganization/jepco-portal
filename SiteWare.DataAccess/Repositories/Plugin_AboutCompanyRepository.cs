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
    public static class Plugin_AboutCompanyRepository
    {
        public async static Task<ResultList<Plugin_AboutCompanyEntity>> SelectAll()
        {
            ResultList<Plugin_AboutCompanyEntity> result = new ResultList<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_AboutCompanyEntity> list = new List<Plugin_AboutCompanyEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_AboutCompanyEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_AboutCompanyEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_AboutCompanyEntity> result = new ResultList<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_AboutCompanyEntity> list = new List<Plugin_AboutCompanyEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_AboutCompanyEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> Insert(Plugin_AboutCompanyEntity entity)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title3, entity.Title3);
                
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Summery, entity.Summery);
               
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Order, entity.Order);
               
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_AboutCompanyRepositoryConstants.CompanyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.CompanyID = Convert.ToInt64(sqlCommand.Parameters[Plugin_AboutCompanyRepositoryConstants.CompanyID].Value);

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
        public static ResultEntity<Plugin_AboutCompanyEntity> InsertNotAsync(Plugin_AboutCompanyEntity entity)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title3, entity.Title3);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Summery, entity.Summery);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Order, entity.Order);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_AboutCompanyRepositoryConstants.CompanyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.CompanyID = Convert.ToInt64(sqlCommand.Parameters[Plugin_AboutCompanyRepositoryConstants.CompanyID].Value);

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

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_AboutCompanyRepositoryConstants.CompanyID, ID));
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
        public static ResultEntity<Plugin_AboutCompanyEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_AboutCompanyRepositoryConstants.CompanyID, ID));
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

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> Update(Plugin_AboutCompanyEntity entity)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title3, entity.Title3);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Summery, entity.Summery);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Order, entity.Order);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.CompanyID, entity.CompanyID);

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
        public static ResultEntity<Plugin_AboutCompanyEntity> UpdateNotAsync(Plugin_AboutCompanyEntity entity)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Title3, entity.Title3);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Summery, entity.Summery);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.Order, entity.Order);

                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.CompanyID, entity.CompanyID);

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

        public async static Task<ResultEntity<Plugin_AboutCompanyEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_AboutCompanyEntity> result = new ResultEntity<Plugin_AboutCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_AboutCompanyRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_AboutCompanyRepositoryConstants.CompanyID, ID);

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

        static Plugin_AboutCompanyEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_AboutCompanyEntity entity = new Plugin_AboutCompanyEntity();

            try
            {
                entity.CompanyID = Convert.ToInt64(reader[Plugin_AboutCompanyEntityConstants.CompanyID].ToString());
                entity.Title = reader[Plugin_AboutCompanyEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Title].ToString();
                entity.Title2 = reader[Plugin_AboutCompanyEntityConstants.Title2] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Title2].ToString();
                entity.Title3 = reader[Plugin_AboutCompanyEntityConstants.Title3] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Title3].ToString();
               
                entity.Icon = reader[Plugin_AboutCompanyEntityConstants.Icon] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Icon].ToString();
                entity.Link = reader[Plugin_AboutCompanyEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Link].ToString();
                entity.Target = reader[Plugin_AboutCompanyEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Target].ToString();
                entity.Summery = reader[Plugin_AboutCompanyEntityConstants.Summery] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.Summery].ToString();
               
                entity.Order = reader[Plugin_AboutCompanyEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_AboutCompanyEntityConstants.Order].ToString());
               
                entity.PublishedDate = reader[Plugin_AboutCompanyEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_AboutCompanyEntityConstants.PublishedDate].ToString());
                entity.IsPublished = reader[Plugin_AboutCompanyEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_AboutCompanyEntityConstants.IsPublished].ToString());
                entity.IsDelete = reader[Plugin_AboutCompanyEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_AboutCompanyEntityConstants.IsDelete].ToString());
                entity.LanguageID = reader[Plugin_AboutCompanyEntityConstants.LanguageID] == DBNull.Value ? 1 : Convert.ToInt32(reader[Plugin_AboutCompanyEntityConstants.LanguageID].ToString());
                entity.AddDate = reader[Plugin_AboutCompanyEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_AboutCompanyEntityConstants.AddDate].ToString());
                entity.EditDate = reader[Plugin_AboutCompanyEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_AboutCompanyEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_AboutCompanyEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_AboutCompanyEntityConstants.EditUser].ToString();
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
                    entity.LanguageName = reader[Plugin_AboutCompanyEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_AboutCompanyEntityConstants.LanguageName].ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
