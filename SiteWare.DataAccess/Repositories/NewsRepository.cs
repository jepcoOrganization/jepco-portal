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
    public static class NewsRepository
    {
        public async static Task<ResultEntity<NewsEntity>> SelectByNewsID(int NewsID)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_SelectByNewsID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NewsRepositoryConstants.NewsID, NewsID));
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

        public async static Task<ResultEntity<NewsEntity>> SelectByNewsID(int NewsID, byte Lang)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_SelectByNewsIDWithLanguage, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NewsRepositoryConstants.NewsID, NewsID));
                sqlCommand.Parameters.Add(new SqlParameter(NewsRepositoryConstants.LanguageID, Lang));
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

        public static ResultList<NewsEntity> SelectNewsByLanguage(byte Lang)
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();
            List<NewsEntity> list = new List<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_SelectNewsByLanguage, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NewsRepositoryConstants.LanguageID, Lang));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NewsEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    reader.Close();
                    result.List = list;
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

        public async static Task<ResultList<NewsEntity>> SelectAll()
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewsEntity> list = new List<NewsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    NewsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<NewsEntity> SelectAllNotAsync()
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewsEntity> list = new List<NewsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NewsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<NewsEntity>> Update(NewsEntity entity)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsImage, entity.NewsImage);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.Headline, entity.Headline);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsDate, entity.NewsDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsOrder, entity.NewsOrder);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.ShowInMarquee, entity.ShowInMarquee);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsID, entity.NewsID);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.MappedNewsID1, entity.MappedNewsID1);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.MappedNewsID2, entity.MappedNewsID2);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsNotification, entity.IsNotification);

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
        public async static Task<ResultEntity<NewsEntity>> UpdateByIsDeleted(NewsEntity entity)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsID, entity.NewsID);

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
        public async static Task<ResultEntity<NewsEntity>> InsertNews(NewsEntity entity)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsImage, entity.NewsImage);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.Headline, entity.Headline);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsDate, entity.NewsDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsOrder, entity.NewsOrder);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.ShowInMarquee, entity.ShowInMarquee);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.MappedNewsID1, entity.MappedNewsID1);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.MappedNewsID2, entity.MappedNewsID2);
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.IsNotification, entity.IsNotification);
                sqlCommand.Parameters.Add(NewsRepositoryConstants.NewsID, SqlDbType.BigInt).Direction=ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.NewsID = Convert.ToInt32(sqlCommand.Parameters[NewsRepositoryConstants.NewsID].Value);
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
        public async static Task<ResultEntity<NewsEntity>> DeleteNews(NewsEntity entity)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsID, entity.NewsID);

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
        public async static Task<ResultList<NewsEntity>> SelectTopThree()
        {
            ResultList<NewsEntity> result = new ResultList<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_SelectTopThree, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewsEntity> list = new List<NewsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    NewsEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<NewsEntity>> UpdateViewCount(int NewsID)
        {

            ResultEntity<NewsEntity> result = new ResultEntity<NewsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_UpdateViewCount, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();               
                sqlCommand.Parameters.AddWithValue(NewsRepositoryConstants.NewsID, NewsID);

                await sqlCommand.ExecuteNonQueryAsync();                

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
        static NewsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            NewsEntity entity = new NewsEntity();
            entity.NewsID = Convert.ToInt32(reader[NewsEntityConstants.NewsID].ToString());
            entity.NewsImage = reader[NewsEntityConstants.NewsImage].ToString();
            entity.Headline = reader[NewsEntityConstants.Headline].ToString();
            entity.Summary = reader[NewsEntityConstants.Summary].ToString();
            entity.Description = reader[NewsEntityConstants.Description].ToString();
            entity.NewsDate = Convert.ToDateTime(reader[NewsEntityConstants.NewsDate].ToString());
            entity.ViewCount = Convert.ToInt64(reader[NewsEntityConstants.ViewCount].ToString());
            entity.NewsOrder = float.Parse(reader[NewsEntityConstants.NewsOrder].ToString());
            entity.LanguageID = Convert.ToByte(reader[NewsEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[NewsEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[NewsEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[NewsEntityConstants.IsDeleted].ToString());
            entity.ShowInMarquee = Convert.ToBoolean(reader[NewsEntityConstants.ShowInMarquee].ToString());
            entity.AddDate = Convert.ToDateTime(reader[NewsEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[NewsEntityConstants.EditDate].ToString());
            entity.AddUser = reader[NewsEntityConstants.AddUser].ToString();
            entity.EditUser = reader[NewsEntityConstants.EditUser].ToString();
            entity.MappedNewsID1 = reader[NewsEntityConstants.MappedNewsID1].ToString();
            entity.MappedNewsID2 = reader[NewsEntityConstants.MappedNewsID2].ToString();
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
                entity.LanguageName = reader[NewsEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("IsNotification");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IsNotification = reader[NewsEntityConstants.IsNotification] == DBNull.Value ? false : Convert.ToBoolean(reader[NewsEntityConstants.IsNotification].ToString());
            }

            return entity;
        }

        #region--> EntityHelper1 & SelectMonthYearByLanguage | Add | Jigar Patel | 27062018

        public static ResultList<Plugin_NewsYearMonthEntity> SelectMonthYearByLanguage(byte Lang)
        {
            ResultList<Plugin_NewsYearMonthEntity> result = new ResultList<Plugin_NewsYearMonthEntity>();
            List<Plugin_NewsYearMonthEntity> list = new List<Plugin_NewsYearMonthEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewsRepositoryConstants.SP_GetMonthYearList, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NewsRepositoryConstants.LanguageID, Lang));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_NewsYearMonthEntity entity = EntityHelper1(reader, false);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    reader.Close();
                    result.List = list;
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


        static Plugin_NewsYearMonthEntity EntityHelper1(SqlDataReader reader, bool isFull)
        {
            Plugin_NewsYearMonthEntity entity = new Plugin_NewsYearMonthEntity();

            entity.Months = Convert.ToInt64(reader[Plugin_NewsYearMonthEntityConstant.Months].ToString());
            entity.Years = Convert.ToInt64(reader[Plugin_NewsYearMonthEntityConstant.Years].ToString());

            return entity;
        }
        #endregion
    }
}
