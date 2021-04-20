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
    public static class VideoSliderRepository
    {
        public async static Task<ResultEntity<VideoSliderEntity>> SelectByID(int ID)
        {

            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(VideoSliderRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(VideoSliderRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<VideoSliderEntity>> SelectAll()
        {
            ResultList<VideoSliderEntity> result = new ResultList<VideoSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(VideoSliderRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<VideoSliderEntity> list = new List<VideoSliderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    VideoSliderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<VideoSliderEntity>> Insert(VideoSliderEntity entity)
        {

            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(VideoSliderRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.VideoID, entity.VideoID);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<VideoSliderEntity>> Update(VideoSliderEntity entity)
        {

            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(VideoSliderRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.VideoID, entity.VideoID);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<VideoSliderEntity>> UpdateByIsDeleted(VideoSliderEntity entity)
        {

            ResultEntity<VideoSliderEntity> result = new ResultEntity<VideoSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(VideoSliderRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(VideoSliderRepositoryConstants.ID, entity.ID);

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
        static VideoSliderEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            VideoSliderEntity entity = new VideoSliderEntity();

            entity.ID = Convert.ToInt32(reader[VideoSliderEntityConstants.ID].ToString());
            entity.Title = reader[VideoSliderEntityConstants.Title].ToString();
            entity.VideoID = reader[VideoSliderEntityConstants.VideoID].ToString();
            entity.LanguageID = Convert.ToByte(reader[VideoSliderEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[VideoSliderEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[VideoSliderEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[VideoSliderEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[VideoSliderEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[VideoSliderEntityConstants.EditDate].ToString());
            entity.AddUser = reader[VideoSliderEntityConstants.AddUser].ToString();
            entity.EditUser = reader[VideoSliderEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
