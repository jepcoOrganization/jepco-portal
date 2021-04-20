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
    public static class Plugin_SubmitCVRepository
    {
        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> SelectByID(int SubmitCVID)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.SelectById, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_SubmitCVRepositoryConstants.SubmitCVID, SubmitCVID));
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
        public static ResultEntity<Plugin_SubmitCVEntity> SelectByIDNotAsync(int SubmitCVID)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.SelectById, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_SubmitCVRepositoryConstants.SubmitCVID, SubmitCVID));
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
        public async static Task<ResultList<Plugin_SubmitCVEntity>> SelectAll()
        {
            ResultList<Plugin_SubmitCVEntity> result = new ResultList<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_SubmitCVEntity> list = new List<Plugin_SubmitCVEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_SubmitCVEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_SubmitCVEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_SubmitCVEntity> result = new ResultList<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_SubmitCVEntity> list = new List<Plugin_SubmitCVEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_SubmitCVEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> Update(Plugin_SubmitCVEntity entity)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PhoneNo, entity.PhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Interest, entity.Interest);


                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsDeleted, entity.IsDeleted);
               
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.SubmitCVID, entity.SubmitCVID);


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
        public static ResultEntity<Plugin_SubmitCVEntity> UpdateNotAsync(Plugin_SubmitCVEntity entity)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PhoneNo, entity.PhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Interest, entity.Interest);


                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsDeleted, entity.IsDeleted);

                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.SubmitCVID, entity.SubmitCVID);

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
        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> Delete(int SubmitCVID)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.SubmitCVID, SubmitCVID);

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
        public async static Task<ResultEntity<Plugin_SubmitCVEntity>> Insert(Plugin_SubmitCVEntity entity)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PhoneNo, entity.PhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Interest, entity.Interest);


                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(Plugin_SubmitCVRepositoryConstants.SubmitCVID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.SubmitCVID = Convert.ToInt32(sqlCommand.Parameters[Plugin_SubmitCVRepositoryConstants.SubmitCVID].Value);

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
        public static ResultEntity<Plugin_SubmitCVEntity> InsertNotAsync(Plugin_SubmitCVEntity entity)
        {

            ResultEntity<Plugin_SubmitCVEntity> result = new ResultEntity<Plugin_SubmitCVEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SubmitCVRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PhoneNo, entity.PhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Interest, entity.Interest);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.AttachCV, entity.AttachCV);



                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.PublishedDate, entity.PublishedDate);
               
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SubmitCVRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_SubmitCVRepositoryConstants.SubmitCVID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.SubmitCVID = Convert.ToInt32(sqlCommand.Parameters[Plugin_SubmitCVRepositoryConstants.SubmitCVID].Value);

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

        static Plugin_SubmitCVEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_SubmitCVEntity entity = new Plugin_SubmitCVEntity();


            entity.SubmitCVID = Convert.ToInt32(reader[Plugin_SubmitCVEntityConstants.SubmitCVID].ToString());
            entity.Name = reader[Plugin_SubmitCVEntityConstants.Name] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.Name].ToString();
            entity.Email = reader[Plugin_SubmitCVEntityConstants.Email] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.Email].ToString();

            entity.PhoneNo = reader[Plugin_SubmitCVEntityConstants.PhoneNo] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.PhoneNo].ToString();

            entity.Interest = reader[Plugin_SubmitCVEntityConstants.Interest] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.Interest].ToString();
            entity.AttachCV = reader[Plugin_SubmitCVEntityConstants.AttachCV] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.AttachCV].ToString();
            entity.LanguageID = reader[Plugin_SubmitCVEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_SubmitCVEntityConstants.LanguageID].ToString());

            entity.Order = reader[Plugin_SubmitCVEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_SubmitCVEntityConstants.Order].ToString());
            
            entity.PublishedDate = reader[Plugin_SubmitCVEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_SubmitCVEntityConstants.PublishedDate].ToString());
            entity.IsPublished = reader[Plugin_SubmitCVEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_SubmitCVEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_SubmitCVEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_SubmitCVEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_SubmitCVEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_SubmitCVEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_SubmitCVEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_SubmitCVEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_SubmitCVEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_SubmitCVEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_SubmitCVEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_SubmitCVEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
