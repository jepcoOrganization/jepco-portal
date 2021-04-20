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
    public static class PluginContactUsRepository
    {
        public static ResultList<PluginContactUsEntity> SelectAllNotAsync()
        {
            ResultList<PluginContactUsEntity> result = new ResultList<PluginContactUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginContactUsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginContactUsEntity> list = new List<PluginContactUsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginContactUsEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<PluginContactUsEntity>> Plugin_ContactUs_SelectByID(int ID)
        {

            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginContactUsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginContactUsRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<PluginContactUsEntity>> SelectAll()
        {
            ResultList<PluginContactUsEntity> result = new ResultList<PluginContactUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginContactUsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginContactUsEntity> list = new List<PluginContactUsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginContactUsEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginContactUsEntity>> Plugin_ContactUs_Update(PluginContactUsEntity entity)
        {

            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginContactUsRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Image, entity.Image); 
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.AddUser, entity.AddUser); 
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.IsDeleted, entity.IsDeleted); 
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Longitude, entity.Longitude);


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
        public async static Task<ResultEntity<PluginContactUsEntity>> Plugin_ContactUs_Insert(PluginContactUsEntity entity)
        {

            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginContactUsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Image, entity.Image); 
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.URL, entity.URL); 
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.IsDeleted, entity.IsDeleted); 
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(PluginContactUsRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.Add(PluginContactUsRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginContactUsRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginContactUsEntity>> Plugin_ContactUs_Delete(int ID)
        {
            ResultEntity<PluginContactUsEntity> result = new ResultEntity<PluginContactUsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginContactUsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginContactUsRepositoryConstants.ID,ID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.CannotUpdateDetails;
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
        static PluginContactUsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginContactUsEntity entity = new PluginContactUsEntity();

            entity.ID = Convert.ToInt32(reader[PluginContactUsEntityConstants.ID].ToString());
            entity.Title = reader[PluginContactUsEntityConstants.Title].ToString();
            entity.Image = reader[PluginContactUsEntityConstants.Image].ToString(); 
            entity.URL = reader[PluginContactUsEntityConstants.URL].ToString(); 
            entity.LanguageID = Convert.ToInt32(reader[PluginContactUsEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginContactUsEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginContactUsEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginContactUsEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginContactUsEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginContactUsEntityConstants.EditUser].ToString();
            entity.Target = reader[PluginContactUsEntityConstants.Target]==DBNull.Value ? "_parent" : reader[PluginContactUsEntityConstants.Target].ToString();
            entity.Order = reader[PluginContactUsEntityConstants.Order]==DBNull.Value ? 0 : Convert.ToInt32(reader[PluginContactUsEntityConstants.Order].ToString());
            entity.IsPublished = reader[PluginContactUsEntityConstants.IsPublished]==DBNull.Value ? false : Convert.ToBoolean(reader[PluginContactUsEntityConstants.IsPublished].ToString());
            entity.PublishedDate = reader[PluginContactUsEntityConstants.PublishedDate]==DBNull.Value ? DateTime.Now: Convert.ToDateTime(reader[PluginContactUsEntityConstants.PublishedDate].ToString());
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
                entity.LanguageName = reader[PluginContactUsEntityConstants.LanguageName].ToString();
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("Description");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Description = reader[PluginContactUsEntityConstants.Description].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("Latitude");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Latitude = reader[PluginContactUsEntityConstants.Latitude].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("Longitude");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Longitude = reader[PluginContactUsEntityConstants.Longitude].ToString();
            }
            return entity;
        }
    }
}
