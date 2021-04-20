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
    public static class PluginAnnouncementRepository
    {
        public async static Task<ResultList<PluginAnnouncementEntity>> Search_Announcement_SelectByKeyword(string kyeword, byte LanguageId, int year, int pageno, int pagesize)
        {

            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_Search_Announcement_SelectByKeyword, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAnnouncementEntity> list = new List<PluginAnnouncementEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@kyeword", kyeword));
                sqlCommand.Parameters.Add(new SqlParameter("@LanguageId", LanguageId));
                sqlCommand.Parameters.Add(new SqlParameter("@Year", year));
                sqlCommand.Parameters.Add(new SqlParameter("@PageNumber", pageno));
                sqlCommand.Parameters.Add(new SqlParameter("@PageSize", pagesize));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PluginAnnouncementEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginAnnouncementEntity>> SelectByAnnouncementID(int AnnouncementID)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_SelectByAnnouncementID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAnnouncementRepositoryConstants.AnnouncementID, AnnouncementID));
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

        public async static Task<ResultList<PluginAnnouncementEntity>> Search_AllAnnouncement_SelectByKeyword(string keyword, byte languageId, int year)
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_Search_AllAnnouncement_SelectByKeyword, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAnnouncementEntity> list = new List<PluginAnnouncementEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@kyeword", keyword));
                sqlCommand.Parameters.Add(new SqlParameter("@LanguageId", languageId));
                sqlCommand.Parameters.Add(new SqlParameter("@Year", year));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PluginAnnouncementEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginAnnouncementEntity>> SelectByAnnouncementID(int ID, byte langID)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_SelectByAnnouncementIDWithLanguage, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAnnouncementRepositoryConstants.AnnouncementID, ID));
                sqlCommand.Parameters.Add(new SqlParameter(PluginAnnouncementRepositoryConstants.LanguageID, langID));
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

        public async static Task<ResultList<PluginAnnouncementEntity>> SelectAll()
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAnnouncementEntity> list = new List<PluginAnnouncementEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginAnnouncementEntity entity = EntityHelper(reader, false);
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
        public static ResultList<PluginAnnouncementEntity> SelectAllNotAsync()
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAnnouncementEntity> list = new List<PluginAnnouncementEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAnnouncementEntity entity = EntityHelper(reader, false);
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

        public static ResultList<PluginAnnouncementEntity> SelectWithPaginationAllNotAsync(byte LanguageID, int pageno, int pagesize)
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_SelectAll_With_Pagination, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAnnouncementEntity> list = new List<PluginAnnouncementEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAnnouncementRepositoryConstants.LanguageID, LanguageID));
                sqlCommand.Parameters.Add(new SqlParameter(PluginAnnouncementRepositoryConstants.PageNumber, pageno));
                sqlCommand.Parameters.Add(new SqlParameter(PluginAnnouncementRepositoryConstants.PageSize, pagesize));

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAnnouncementEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginAnnouncementEntity>> Update(PluginAnnouncementEntity entity)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.MediaType, entity.MediaType);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.VideoType, entity.VideoType);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AnnouncementDate, entity.AnnouncementDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AnnouncementID, entity.AnnouncementID);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.MapAnnouncementId1, entity.MapAnnouncementId1);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.MapAnnouncementId2, entity.MapAnnouncementId2);

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
        public async static Task<ResultEntity<PluginAnnouncementEntity>> UpdateByIsDeleted(PluginAnnouncementEntity entity)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AnnouncementID, entity.AnnouncementID);

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
        public async static Task<ResultEntity<PluginAnnouncementEntity>> InsertAnnouncement(PluginAnnouncementEntity entity)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.MediaType, entity.MediaType);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.VideoType, entity.VideoType);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AnnouncementDate, entity.AnnouncementDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.MapAnnouncementId1, entity.MapAnnouncementId1);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.MapAnnouncementId2, entity.MapAnnouncementId2);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.IsNotication, entity.IsNotication);
                sqlCommand.Parameters.Add(PluginAnnouncementRepositoryConstants.AnnouncementID, SqlDbType.Int).Direction = ParameterDirection.Output;

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
        public async static Task<ResultEntity<PluginAnnouncementEntity>> DeleteAnnouncement(PluginAnnouncementEntity entity)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AnnouncementID, entity.AnnouncementID);

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
        public async static Task<ResultList<PluginAnnouncementEntity>> SelectTopThree()
        {
            ResultList<PluginAnnouncementEntity> result = new ResultList<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_SelectTopThree, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAnnouncementEntity> list = new List<PluginAnnouncementEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginAnnouncementEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginAnnouncementEntity>> UpdateViewCount(PluginAnnouncementEntity entity)
        {

            ResultEntity<PluginAnnouncementEntity> result = new ResultEntity<PluginAnnouncementEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAnnouncementRepositoryConstants.SP_UpdateByViewCount, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(PluginAnnouncementRepositoryConstants.AnnouncementID, entity.AnnouncementID);

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
        static PluginAnnouncementEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginAnnouncementEntity entity = new PluginAnnouncementEntity();

            entity.AnnouncementID = Convert.ToInt32(reader[PluginAnnouncementEntityConstants.AnnouncementID].ToString());
            entity.Image = reader[PluginAnnouncementEntityConstants.Image].ToString();
            entity.Title = reader[PluginAnnouncementEntityConstants.Title].ToString();
            entity.Summary = reader[PluginAnnouncementEntityConstants.Summary].ToString();
            entity.Description = reader[PluginAnnouncementEntityConstants.Description].ToString();
            entity.AnnouncementDate = Convert.ToDateTime(reader[PluginAnnouncementEntityConstants.AnnouncementDate].ToString());
            entity.ViewCount = Convert.ToInt64(reader[PluginAnnouncementEntityConstants.ViewCount].ToString());
            entity.Order = float.Parse(reader[PluginAnnouncementEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[PluginAnnouncementEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[PluginAnnouncementEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[PluginAnnouncementEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginAnnouncementEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginAnnouncementEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginAnnouncementEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginAnnouncementEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginAnnouncementEntityConstants.EditUser].ToString();
            entity.MapAnnouncementId1 = reader[PluginAnnouncementEntityConstants.MapAnnouncementId1].ToString();
            entity.MapAnnouncementId2 = reader[PluginAnnouncementEntityConstants.MapAnnouncementId2].ToString();
            entity.IsNotication = Convert.ToBoolean(reader[PluginAnnouncementEntityConstants.IsNotication].ToString());

            entity.AnnouncementDateStr = reader[PluginAnnouncementEntityConstants.AnnouncementDate].ToString();

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
                entity.LanguageName = reader[PluginAnnouncementEntityConstants.LanguageName].ToString();
            }
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
                entity.Link = reader[PluginAnnouncementEntityConstants.Link] == DBNull.Value ? string.Empty : reader[PluginAnnouncementEntityConstants.Link].ToString();
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
                entity.Target = reader[PluginAnnouncementEntityConstants.Target] == DBNull.Value ? string.Empty : reader[PluginAnnouncementEntityConstants.Target].ToString();
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("MediaType");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.MediaType = reader[PluginAnnouncementEntityConstants.MediaType] == DBNull.Value ? 0 : Convert.ToInt32(reader[PluginAnnouncementEntityConstants.MediaType].ToString());
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("VideoType");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.VideoType = reader[PluginAnnouncementEntityConstants.VideoType] == DBNull.Value ? 0 : Convert.ToInt32(reader[PluginAnnouncementEntityConstants.VideoType].ToString());
            }
            return entity;
        }
    }
}
