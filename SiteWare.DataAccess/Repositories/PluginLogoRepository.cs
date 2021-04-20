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
    public static class PluginLogoRepository
    {
        public static ResultList<PluginLogoEntity> SelectAllNotAsync()
        {
            ResultList<PluginLogoEntity> result = new ResultList<PluginLogoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginLogoRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginLogoEntity> list = new List<PluginLogoEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginLogoEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<PluginLogoEntity>> SelectAll()
        {
            ResultList<PluginLogoEntity> result = new ResultList<PluginLogoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginLogoRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginLogoEntity> list = new List<PluginLogoEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginLogoEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginLogoEntity>> Plugin_Logo_SelectByID(int ID)
        {

            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginLogoRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginLogoRepositoryConstants.ID, ID));
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
        public async static Task<ResultEntity<PluginLogoEntity>> Plugin_Logo_Update(PluginLogoEntity entity)
        {

            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginLogoRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Order, entity.Order);

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
        public async static Task<ResultEntity<PluginLogoEntity>> InsertLogo(PluginLogoEntity entity)
        {

            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginLogoRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.Order, entity.Order);

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
        public async static Task<ResultEntity<PluginLogoEntity>> DeleteLogo(int ID)
        {

            ResultEntity<PluginLogoEntity> result = new ResultEntity<PluginLogoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginLogoRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginLogoRepositoryConstants.ID, ID);

                await sqlCommand.ExecuteReaderAsync();
                result.Entity.ID = ID;


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
        static PluginLogoEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginLogoEntity entity = new PluginLogoEntity();
            try
            {
                entity.ID = Convert.ToInt32(reader[PluginLogoEntityConstants.ID].ToString());
                entity.Title = reader[PluginLogoEntityConstants.Title].ToString();
                entity.Image = reader[PluginLogoEntityConstants.Image].ToString();
                entity.Target = reader[PluginLogoEntityConstants.Target] == DBNull.Value ? string.Empty : reader[PluginLogoEntityConstants.Target].ToString();
                entity.URL = reader[PluginLogoEntityConstants.URL].ToString();
                entity.LanguageID = Convert.ToInt32(reader[PluginLogoEntityConstants.LanguageID].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[PluginLogoEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[PluginLogoEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[PluginLogoEntityConstants.EditDate].ToString());
                entity.AddUser = reader[PluginLogoEntityConstants.AddUser].ToString();
                entity.EditUser = reader[PluginLogoEntityConstants.EditUser].ToString();
                entity.IsPublished = reader[PluginLogoEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[PluginLogoEntityConstants.IsPublished].ToString());
                entity.PublishedDate = reader[PluginLogoEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[PluginLogoEntityConstants.PublishedDate].ToString());
                entity.Order = reader[PluginLogoEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[PluginLogoEntityConstants.Order].ToString());
            }
            catch (Exception ex)
            {
            }



            return entity;
        }


    }
}
