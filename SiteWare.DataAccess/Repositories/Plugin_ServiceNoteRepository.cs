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
    public static class Plugin_ServiceNoteRepository
    {
        public static ResultList<Plugin_ServiceNoteEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_ServiceNoteEntity> result = new ResultList<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ServiceNoteEntity> list = new List<Plugin_ServiceNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ServiceNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Plugin_ServiceNoteEntity>> SelectAll()
        {
            ResultList<Plugin_ServiceNoteEntity> result = new ResultList<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ServiceNoteEntity> list = new List<Plugin_ServiceNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ServiceNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> ServiceNote_SelectByID(int ID)
        {

            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceNoteRepositoryConstants.ServiceNoteID, ID));
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
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> Plugin_ServiceNote_UpdateByIsDelete(Plugin_ServiceNoteEntity entity)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_UpdateByIsDelete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceNoteRepositoryConstants.ServiceNoteID, entity.ServiceNoteID));
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceNoteRepositoryConstants.IsDelete, entity.IsDelete));
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
        public static ResultEntity<Plugin_ServiceNoteEntity> Plugin_ServiceNote_UpdateByIsDeleteNotAsync(Plugin_ServiceNoteEntity entity)
        {
            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_UpdateByIsDelete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceNoteRepositoryConstants.ServiceNoteID, entity.ServiceNoteID));
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceNoteRepositoryConstants.IsDelete, entity.IsDelete));
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
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> Update(Plugin_ServiceNoteEntity entity)
        {

            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.ServiceNoteID, entity.ServiceNoteID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.ContactDetail, entity.ContactDetail);                
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.LanguageID, entity.LanguageID);
                //sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.AddDate, entity.AddDate);
                //sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.AddUser, entity.AddUser);                
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.EditUser, entity.EditUser);                                
                


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
        public async static Task<ResultEntity<Plugin_ServiceNoteEntity>> Insert(Plugin_ServiceNoteEntity entity)
        {

            ResultEntity<Plugin_ServiceNoteEntity> result = new ResultEntity<Plugin_ServiceNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceNoteRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.ContactDetail, entity.ContactDetail);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceNoteRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_ServiceNoteRepositoryConstants.ServiceNoteID, SqlDbType.Int).Direction = ParameterDirection.Output;

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
        static Plugin_ServiceNoteEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ServiceNoteEntity entity = new Plugin_ServiceNoteEntity();
            try
            {
                entity.ServiceNoteID = Convert.ToInt32(reader[Plugin_ServiceNoteEntityConstants.ServiceNoteID].ToString());
                entity.Title = reader[Plugin_ServiceNoteEntityConstants.Title].ToString();
                entity.Title2 = reader[Plugin_ServiceNoteEntityConstants.Title2].ToString();
                entity.Summary = reader[Plugin_ServiceNoteEntityConstants.Summary] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_ServiceNoteEntityConstants.Summary]);
                entity.ContactDetail = reader[Plugin_ServiceNoteEntityConstants.ContactDetail] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_ServiceNoteEntityConstants.ContactDetail]);
                entity.LanguageID = Convert.ToInt32(reader[Plugin_ServiceNoteEntityConstants.LanguageID].ToString());
                entity.IsDelete = Convert.ToBoolean(reader[Plugin_ServiceNoteEntityConstants.IsDelete].ToString());
                entity.AddDate = Convert.ToDateTime(reader[Plugin_ServiceNoteEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[Plugin_ServiceNoteEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_ServiceNoteEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_ServiceNoteEntityConstants.EditUser].ToString();                
                entity.IsPublished = reader[Plugin_ServiceNoteEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_ServiceNoteEntityConstants.IsPublished]);
                entity.PublishedDate = reader[Plugin_ServiceNoteEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_ServiceNoteEntityConstants.PublishedDate]);
                entity.Order = reader[Plugin_ServiceNoteEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceNoteEntityConstants.Order]);
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
                    entity.Link = reader[Plugin_ServiceNoteEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_ServiceNoteEntityConstants.Link].ToString();
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
                    entity.Target = reader[Plugin_ServiceNoteEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_ServiceNoteEntityConstants.Target].ToString();
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
                    entity.LanguageName = reader[Plugin_ServiceNoteEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_ServiceNoteEntityConstants.LanguageName].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            return entity;
        }
    }
}
