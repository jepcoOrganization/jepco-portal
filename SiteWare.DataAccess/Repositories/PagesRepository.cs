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
    public static class PagesRepository
    {
        public async static Task<ResultList<PagesEntity>> Search_Page_SelectByKeyword(string kyeword,byte LanguageId)
        {

            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_Search_Page_SelectByKeyword, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@kyeword", kyeword));
                sqlCommand.Parameters.Add(new SqlParameter("@LanguageId", LanguageId));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PagesEntity>> SelectByPageID(int PageID)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectByPageID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.PageID, PageID));
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

        //Created By Simran 02/07/2018
        public static ResultEntity<PagesEntity> SelectByPageIDNotAsync(int PageID)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectByPageID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.PageID, PageID));
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

        public async static Task<ResultEntity<PagesEntity>> UpdateViewCountByPageAliasPath(string Alias)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_UpdateViewCountByAliasPath, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.AliasPath, Alias));
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
        public async static Task<ResultEntity<PagesEntity>> SelectByPageAliasPath(string Alias, byte langId)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectByAliasPath, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.AliasPath, Alias));
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.LanguageID, langId));
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
        public static ResultEntity<PagesEntity> SelectByPageAliasPathNotAsync(string Alias, byte langId)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectByAliasPath, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.AliasPath, Alias));
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.LanguageID, langId));
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
        public async static Task<ResultList<PagesEntity>> SelectByPageID2(int PageID)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectByPageID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesRepositoryConstants.PageID, PageID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<PagesEntity>> SelectAll(int UserID)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@UserID", UserID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<PagesEntity>> SelectAllSuperAdmin()
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectAllSuperAdmin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.Add(new SqlParameter("@UserID", UserID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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

        public static ResultList<PagesEntity> SelectAllSuperAdminNotAsync()
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectAllSuperAdmin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.Add(new SqlParameter("@UserID", UserID));

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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

        public static ResultList<PagesEntity> SelectAllNotAsync(int UserID)
        {
            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@UserID", UserID));

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PagesEntity>> Update(PagesEntity entity)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.PageID, entity.PageID);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.AliasPath, entity.AliasPath);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.NamePath, entity.NamePath);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.LivePath, entity.LivePath);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.LanguageID, entity.LanguageID);

                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsList, entity.IsList);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ListLink, entity.ListLink);

                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ContentHTML, entity.ContentHTML);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ContentHTML1, entity.ContentHTML1);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.SEOAttribute, entity.SEOAttribute);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MetaTitle, entity.MetaTitle);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MetaDescription, entity.MetaDescription);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MappedPage1, entity.MappedPage1);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MappedPage2, entity.MappedPage2);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MobileBanner, entity.MobileBanner);

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
        public async static Task<ResultEntity<PagesEntity>> UpdateByIsDeleted(PagesEntity entity)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.PageID, entity.PageID);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsDeleted, entity.IsDeleted);

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
        public async static Task<ResultEntity<PagesEntity>> InsertPage(PagesEntity entity)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.AliasPath, entity.AliasPath);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.NamePath, entity.NamePath);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.LivePath, entity.LivePath);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.LanguageID, entity.LanguageID);

                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsList, entity.IsList);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ListLink, entity.ListLink);

                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ContentHTML, entity.ContentHTML);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ContentHTML1, entity.ContentHTML1);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.SEOAttribute, entity.SEOAttribute);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MetaTitle, entity.MetaTitle);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MetaDescription, entity.MetaDescription);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MappedPage1, entity.MappedPage1);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MappedPage2, entity.MappedPage2);
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.MobileBanner, entity.MobileBanner);
                sqlCommand.Parameters.Add(PagesRepositoryConstants.PageID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.PageID = Convert.ToInt32(sqlCommand.Parameters[PagesRepositoryConstants.PageID].Value);

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
        public async static Task<ResultEntity<PagesEntity>> DeletePage(PagesEntity entity)
        {

            ResultEntity<PagesEntity> result = new ResultEntity<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PagesRepositoryConstants.PageID,entity.PageID);

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
        public async static Task<ResultList<PagesEntity>> Search_Page_SelectByKeywordPageNo(string kyeword, byte LanguageId, int pageno, int pagesize)
        {

            ResultList<PagesEntity> result = new ResultList<PagesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesRepositoryConstants.SP_Search_Page_SelectByKeywordPageNo, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesEntity> list = new List<PagesEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter("@kyeword", kyeword));
                sqlCommand.Parameters.Add(new SqlParameter("@LanguageId", LanguageId));
                sqlCommand.Parameters.Add(new SqlParameter("@PageNumber", pageno));
                sqlCommand.Parameters.Add(new SqlParameter("@PageSize", pagesize));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PagesEntity entity = EntityHelper(reader, false);
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
        static PagesEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PagesEntity entity = new PagesEntity();

            entity.PageID = Convert.ToInt32(reader[PagesEntityConstants.PageID].ToString());
            entity.AliasPath = reader[PagesEntityConstants.AliasPath].ToString();
            entity.NamePath = reader[PagesEntityConstants.NamePath].ToString();
            entity.LivePath = reader[PagesEntityConstants.LivePath].ToString();
            entity.Image = reader[PagesEntityConstants.Image].ToString();
            entity.ParentID = Convert.ToInt32(reader[PagesEntityConstants.ParentID].ToString());
            entity.LanguageID = Convert.ToByte(reader[PagesEntityConstants.LanguageID].ToString());

            entity.IsList = Convert.ToBoolean(reader[PagesEntityConstants.IsList].ToString());
            entity.ListLink = reader[PagesEntityConstants.ListLink].ToString();

            entity.Name = reader[PagesEntityConstants.Name].ToString();
            entity.Description = reader[PagesEntityConstants.Description].ToString();
            entity.ContentHTML = reader[PagesEntityConstants.ContentHTML].ToString();
            entity.ContentHTML1 = reader[PagesEntityConstants.ContentHTML1]==DBNull.Value ? string.Empty : Convert.ToString(reader[PagesEntityConstants.ContentHTML1]);
            entity.PublishDate = Convert.ToDateTime(reader[PagesEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[PagesEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PagesEntityConstants.IsDeleted].ToString());
            entity.ViewCount = Convert.ToInt64(reader[PagesEntityConstants.ViewCount].ToString());
            entity.SEOAttribute = reader[PagesEntityConstants.SEOAttribute].ToString();
            entity.MetaTitle = reader[PagesEntityConstants.MetaTitle].ToString();
            entity.MetaDescription = reader[PagesEntityConstants.MetaDescription].ToString();
            entity.AddDate = Convert.ToDateTime(reader[PagesEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PagesEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PagesEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PagesEntityConstants.EditUser].ToString();
            entity.MappedPage1 = reader[PagesEntityConstants.MappedPage1].ToString();
            entity.MappedPage2 = reader[PagesEntityConstants.MappedPage2].ToString();
            entity.MobileBanner = reader[PagesEntityConstants.MobileBanner]==DBNull.Value ? string.Empty :  reader[PagesEntityConstants.MobileBanner].ToString();

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
                entity.LanguageName = reader[PagesEntityConstants.LanguageName].ToString();
            }
           
            try
            {
                int columnOrdinal = reader.GetOrdinal("MappedPage1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.MappedPage1 = reader[PagesEntityConstants.MappedPage1] == DBNull.Value ? string.Empty : reader[PagesEntityConstants.MappedPage1].ToString();
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("MappedPage2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.MappedPage2 = reader[PagesEntityConstants.MappedPage2] == DBNull.Value ? string.Empty : reader[PagesEntityConstants.MappedPage2].ToString();
            }
            return entity;
        }
    }
}
