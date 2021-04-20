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
    public class Plugin_FA_EntitiesRepository
    {
        public async static Task<ResultList<Plugin_FA_EntitiesEntity>> SelectAll()
        {
            ResultList<Plugin_FA_EntitiesEntity> result = new ResultList<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_FA_EntitiesEntity> list = new List<Plugin_FA_EntitiesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_FA_EntitiesEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_FA_EntitiesEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_FA_EntitiesEntity> result = new ResultList<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_FA_EntitiesEntity> list = new List<Plugin_FA_EntitiesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_FA_EntitiesEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, ID));
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
        public static ResultEntity<Plugin_FA_EntitiesEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, ID));
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

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> Insert(Plugin_FA_EntitiesEntity entity)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.MapEntity, entity.MapEntity);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Telephone, entity.Telephone);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Fax, entity.Fax);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title1, entity.Title1);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsShowPage, entity.IsShowPage);
                sqlCommand.Parameters.Add(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.FocusID = Convert.ToInt64(sqlCommand.Parameters[Plugin_FA_EntitiesRepositoryConstants.FocusEntityId].Value);

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
        public static ResultEntity<Plugin_FA_EntitiesEntity> InsertNotAsync(Plugin_FA_EntitiesEntity entity)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.MapEntity, entity.MapEntity);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Telephone, entity.Telephone);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Fax, entity.Fax);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title1, entity.Title1);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsShowPage, entity.IsShowPage);
                sqlCommand.Parameters.Add(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.FocusID = Convert.ToInt64(sqlCommand.Parameters[Plugin_FA_EntitiesRepositoryConstants.FocusEntityId].Value);

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

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> Update(Plugin_FA_EntitiesEntity entity)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.MapEntity, entity.MapEntity);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Telephone, entity.Telephone);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Fax, entity.Fax);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title1, entity.Title1);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsShowPage, entity.IsShowPage);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, entity.FocusEntityId);


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
        public static ResultEntity<Plugin_FA_EntitiesEntity> UpdateNotAsync(Plugin_FA_EntitiesEntity entity)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.MapEntity, entity.MapEntity);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Telephone, entity.Telephone);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Fax, entity.Fax);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.Title1, entity.Title1);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.IsShowPage, entity.IsShowPage);
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, entity.FocusEntityId);

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

        public async static Task<ResultEntity<Plugin_FA_EntitiesEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_FA_EntitiesEntity> result = new ResultEntity<Plugin_FA_EntitiesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FA_EntitiesRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FA_EntitiesRepositoryConstants.FocusEntityId, ID);

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


        static Plugin_FA_EntitiesEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_FA_EntitiesEntity entity = new Plugin_FA_EntitiesEntity();

            try
            {
                entity.FocusEntityId = Convert.ToInt64(reader[Plugin_FA_EntitiesEntityConstants.FocusEntityId].ToString());
                entity.Title = reader[Plugin_FA_EntitiesEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Title].ToString();
                entity.Summary = reader[Plugin_FA_EntitiesEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Summary].ToString();
                entity.Image = reader[Plugin_FA_EntitiesEntityConstants.Image] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Image].ToString();
                entity.FocusID = Convert.ToInt64(reader[Plugin_FA_EntitiesEntityConstants.FocusID].ToString());
                entity.Description = reader[Plugin_FA_EntitiesEntityConstants.Description] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Description].ToString();
                entity.Order = reader[Plugin_FA_EntitiesEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_FA_EntitiesEntityConstants.Order].ToString());
                entity.PublishedDate = reader[Plugin_FA_EntitiesEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_FA_EntitiesEntityConstants.PublishedDate].ToString());
                entity.IsPublished = reader[Plugin_FA_EntitiesEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_FA_EntitiesEntityConstants.IsPublished].ToString());
                entity.IsDelete = reader[Plugin_FA_EntitiesEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_FA_EntitiesEntityConstants.IsDelete].ToString());
                entity.LanguageID = reader[Plugin_FA_EntitiesEntityConstants.LanguageID] == DBNull.Value ? 1 : Convert.ToInt32(reader[Plugin_FA_EntitiesEntityConstants.LanguageID].ToString());

                entity.AddDate = reader[Plugin_FA_EntitiesEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_FA_EntitiesEntityConstants.AddDate].ToString());
                entity.EditDate = reader[Plugin_FA_EntitiesEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_FA_EntitiesEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_FA_EntitiesEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_FA_EntitiesEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.EditUser].ToString();
                entity.MapEntity = reader[Plugin_FA_EntitiesEntityConstants.MapEntity] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.MapEntity].ToString();
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
                    entity.LanguageName = reader[Plugin_FA_EntitiesEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.LanguageName].ToString();
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
                    entity.PluginAreaTitle = reader[Plugin_FA_EntitiesEntityConstants.PluginAreaTitle] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.PluginAreaTitle].ToString();
                }
                //------------------------------------ Get Address Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Address");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Address = reader[Plugin_FA_EntitiesEntityConstants.Address] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Address].ToString();
                }

                //------------------------------------ Get Telephone Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Telephone");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Telephone = reader[Plugin_FA_EntitiesEntityConstants.Telephone] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Telephone].ToString();
                }

                //------------------------------------ Get Fax Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Fax");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Fax = reader[Plugin_FA_EntitiesEntityConstants.Fax] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Fax].ToString();
                }

                //------------------------------------ Get Fax Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Email");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Email = reader[Plugin_FA_EntitiesEntityConstants.Email] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Email].ToString();
                }

                //------------------------------------ Get Fax Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Website");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Website = reader[Plugin_FA_EntitiesEntityConstants.Website] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Website].ToString();
                }

                //------------------------------------ Get Title1 Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Title1");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Title1 = reader[Plugin_FA_EntitiesEntityConstants.Title1] == DBNull.Value ? string.Empty : reader[Plugin_FA_EntitiesEntityConstants.Title1].ToString();
                }

                //------------------------------------ Get IsShowPage Column ------------------------------------------------------------
                try
                {
                    int columnOrdinal = reader.GetOrdinal("IsShowPage");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.IsShowPage = reader[Plugin_FA_EntitiesEntityConstants.IsShowPage] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_FA_EntitiesEntityConstants.IsShowPage].ToString());
                }
                else
                {
                    entity.IsShowPage = true;
                }

            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
