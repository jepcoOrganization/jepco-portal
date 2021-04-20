using Siteware.DataAccess.RepositorieConstants;
using Siteware.Entity.Constants.Entity;
using Siteware.Entity.Entities;
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
    public class Plugin_Project_Repository
    {
        public async static Task<ResultEntity<Plugin_ProjectEntities>> SelectByID(long ID)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Project_RepositoryConstants.ID, ID));
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
        public static ResultEntity<Plugin_ProjectEntities> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Project_RepositoryConstants.ID, ID));
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
        public async static Task<ResultList<Plugin_ProjectEntities>> SelectAll()
        {
            ResultList<Plugin_ProjectEntities> result = new ResultList<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProjectEntities> list = new List<Plugin_ProjectEntities>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ProjectEntities entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_ProjectEntities> SelectAllNotAsync()
        {
            ResultList<Plugin_ProjectEntities> result = new ResultList<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProjectEntities> list = new List<Plugin_ProjectEntities>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ProjectEntities entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_ProjectEntities>> Update(Plugin_ProjectEntities entity)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ID, entity.ID);

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
        public static ResultEntity<Plugin_ProjectEntities> UpdateNotAsync(Plugin_ProjectEntities entity)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<Plugin_ProjectEntities>> Delete(long ID)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ID, ID);

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
        public async static Task<ResultEntity<Plugin_ProjectEntities>> Insert(Plugin_ProjectEntities entity)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Project_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Project_RepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_ProjectEntities> InsertNotAsync(Plugin_ProjectEntities entity)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Project_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Project_RepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<Plugin_ProjectEntities>> Delete(Plugin_ProjectEntities entity)
        {

            ResultEntity<Plugin_ProjectEntities> result = new ResultEntity<Plugin_ProjectEntities>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Project_RepositoryConstants.ID, entity.ID);

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
        static Plugin_ProjectEntities EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ProjectEntities entity = new Plugin_ProjectEntities();

            entity.ID = Convert.ToInt64(reader[Plugin_Project_EntityConstants.ID].ToString());
            entity.Title = reader[Plugin_Project_EntityConstants.Title].ToString();
            entity.Summary = reader[Plugin_Project_EntityConstants.Summary].ToString();
            entity.URL = reader[Plugin_Project_EntityConstants.URL].ToString();
            entity.ImageUrl = reader[Plugin_Project_EntityConstants.ImageUrl].ToString();
            entity.TargetID = Convert.ToByte(reader[Plugin_Project_EntityConstants.TargetID].ToString());
            entity.Order = Convert.ToByte(reader[Plugin_Project_EntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[Plugin_Project_EntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[Plugin_Project_EntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_Project_EntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_Project_EntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_Project_EntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_Project_EntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_Project_EntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_Project_EntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_Project_EntityConstants.LanguageName].ToString();
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("ParentID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ParentID = reader[Plugin_Project_EntityConstants.ParentID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_Project_EntityConstants.ParentID].ToString());
            }
            return entity;
        }
    }
}
