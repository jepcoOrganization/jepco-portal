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
    public static class NewsTickerRepository
    {
        public async static Task<ResultEntity<NewsTickerEntity>> SelectByNewsTickerID(int NewsTickerID)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_SelectByNewsTickerID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NewsTickerRepositoryConstants.NewsTickerID, NewsTickerID));
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
        public static ResultEntity<NewsTickerEntity> SelectByNewsTickerIDNotAsync(int NewsTickerID)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_SelectByNewsTickerID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NewsTickerRepositoryConstants.NewsTickerID, NewsTickerID));
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
        public async static Task<ResultList<NewsTickerEntity>> SelectAll()
        {
            ResultList<NewsTickerEntity> result = new ResultList<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewsTickerEntity> list = new List<NewsTickerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    NewsTickerEntity entity = EntityHelper(reader, false);
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
        public static ResultList<NewsTickerEntity> SelectAllNotAsync()
        {
            ResultList<NewsTickerEntity> result = new ResultList<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewsTickerEntity> list = new List<NewsTickerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NewsTickerEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<NewsTickerEntity>> Update(NewsTickerEntity entity)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsURL, entity.NewsURL);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsOrder, entity.NewsOrder);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsTickerID, entity.NewsTickerID);

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
        public  static ResultEntity<NewsTickerEntity> UpdateNotAsync(NewsTickerEntity entity)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsURL, entity.NewsURL);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsOrder, entity.NewsOrder);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsTickerID, entity.NewsTickerID);

                sqlCommand.ExecuteNonQuery();
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
        public async static Task<ResultEntity<NewsTickerEntity>> UpdateByIsDeleted(NewsTickerEntity entity)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsTickerID, entity.NewsTickerID);

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
        public async static Task<ResultEntity<NewsTickerEntity>> InsertNewsTicker(NewsTickerEntity entity)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsURL, entity.NewsURL);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsOrder, entity.NewsOrder);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditUser, entity.EditUser);

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
        public  static ResultEntity<NewsTickerEntity> InsertNewsTickerNotAsync(NewsTickerEntity entity)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsURL, entity.NewsURL);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsOrder, entity.NewsOrder);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.EditUser, entity.EditUser);

                SqlDataReader reader = sqlCommand.ExecuteReader();
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
        public async static Task<ResultEntity<NewsTickerEntity>> DeleteNewsTicker(NewsTickerEntity entity)
        {

            ResultEntity<NewsTickerEntity> result = new ResultEntity<NewsTickerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsTickerRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsTickerRepositoryConstants.NewsTickerID, entity.NewsTickerID);

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
        static NewsTickerEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            NewsTickerEntity entity = new NewsTickerEntity();

            entity.NewsTickerID = Convert.ToInt32(reader[NewsTickerEntityConstants.NewsTickerID].ToString());
            entity.Name = reader[NewsTickerEntityConstants.Name].ToString();
            entity.NewsURL = reader[NewsTickerEntityConstants.NewsURL].ToString();
            entity.TargetID = Convert.ToByte(reader[NewsTickerEntityConstants.TargetID].ToString());
            entity.NewsOrder = Convert.ToByte(reader[NewsTickerEntityConstants.NewsOrder].ToString());
            entity.LanguageID = Convert.ToByte(reader[NewsTickerEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[NewsTickerEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[NewsTickerEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[NewsTickerEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[NewsTickerEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[NewsTickerEntityConstants.EditDate].ToString());
            entity.AddUser = reader[NewsTickerEntityConstants.AddUser].ToString();
            entity.EditUser = reader[NewsTickerEntityConstants.EditUser].ToString();
            return entity;
        }
    }
}
