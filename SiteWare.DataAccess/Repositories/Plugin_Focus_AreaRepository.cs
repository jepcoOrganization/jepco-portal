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
    public static class Plugin_Focus_AreaRepository
    {
        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Focus_AreaRepositoryConstants.FocusID, ID));
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
        public static ResultEntity<Plugin_Focus_AreaEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Focus_AreaRepositoryConstants.FocusID, ID));
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
        public async static Task<ResultList<Plugin_Focus_AreaEntity>> SelectAll()
        {
            ResultList<Plugin_Focus_AreaEntity> result = new ResultList<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Focus_AreaEntity> list = new List<Plugin_Focus_AreaEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_Focus_AreaEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_Focus_AreaEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_Focus_AreaEntity> result = new ResultList<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Focus_AreaEntity> list = new List<Plugin_Focus_AreaEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_Focus_AreaEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> Update(Plugin_Focus_AreaEntity entity)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Color, entity.Color);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusOrder, entity.FocusOrder);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_Focus_AreaEntity> UpdateNotAsync(Plugin_Focus_AreaEntity entity)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Color, entity.Color);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusOrder, entity.FocusOrder);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusID, ID);

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
        public async static Task<ResultEntity<Plugin_Focus_AreaEntity>> Insert(Plugin_Focus_AreaEntity entity)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Focus_AreaRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Color, entity.Color);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusOrder, entity.FocusOrder);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Focus_AreaRepositoryConstants.FocusID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.FocusID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Focus_AreaRepositoryConstants.FocusID].Value);

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
        public static ResultEntity<Plugin_Focus_AreaEntity> InsertNotAsync(Plugin_Focus_AreaEntity entity)
        {

            ResultEntity<Plugin_Focus_AreaEntity> result = new ResultEntity<Plugin_Focus_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Color, entity.Color);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.FocusOrder, entity.FocusOrder);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Focus_AreaRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Focus_AreaRepositoryConstants.FocusID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.FocusID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Focus_AreaRepositoryConstants.FocusID].Value);

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
        static Plugin_Focus_AreaEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_Focus_AreaEntity entity = new Plugin_Focus_AreaEntity();

            try
            {
                entity.FocusID = Convert.ToInt64(reader[Plugin_Focus_AreaEntityConstants.FocusID].ToString());
                entity.Title = reader[Plugin_Focus_AreaEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Title].ToString();
                entity.Summary = reader[Plugin_Focus_AreaEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Summary].ToString();
                entity.Icon = reader[Plugin_Focus_AreaEntityConstants.Icon] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Icon].ToString();
                entity.Color = reader[Plugin_Focus_AreaEntityConstants.Color] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Color].ToString();
                entity.Link = reader[Plugin_Focus_AreaEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Link].ToString();
                entity.Target = reader[Plugin_Focus_AreaEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Target].ToString();
                entity.LanguageID = reader[Plugin_Focus_AreaEntityConstants.LanguageID] == DBNull.Value ? 1 : Convert.ToInt32(reader[Plugin_Focus_AreaEntityConstants.LanguageID].ToString());
                entity.FocusOrder = reader[Plugin_Focus_AreaEntityConstants.FocusOrder] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_Focus_AreaEntityConstants.FocusOrder].ToString());

                entity.IsPublished = reader[Plugin_Focus_AreaEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_Focus_AreaEntityConstants.IsPublished].ToString());
                entity.PublishedDate = reader[Plugin_Focus_AreaEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Focus_AreaEntityConstants.PublishedDate].ToString());

                entity.IsDelete = reader[Plugin_Focus_AreaEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_Focus_AreaEntityConstants.IsDelete].ToString());
                entity.AddDate = reader[Plugin_Focus_AreaEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Focus_AreaEntityConstants.AddDate].ToString());
                entity.EditDate = reader[Plugin_Focus_AreaEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_Focus_AreaEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_Focus_AreaEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_Focus_AreaEntityConstants.EditUser].ToString();
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
                    entity.LanguageName = reader[Plugin_Focus_AreaEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.LanguageName].ToString();
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("Image");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Image = reader[Plugin_Focus_AreaEntityConstants.Image] == DBNull.Value ? string.Empty : reader[Plugin_Focus_AreaEntityConstants.Image].ToString();
                }
            }
            catch(Exception ex)
            {

            }            
            
            return entity;
        }
    }
}
