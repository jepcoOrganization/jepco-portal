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
    public static class PluginBannerRepository
    {
        public static ResultList<PluginBannerEntity> SelectAllNotAsync()
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginBannerEntity> list = new List<PluginBannerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginBannerEntity entity = EntityHelper(reader, false);
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
        public static ResultList<PluginBannerEntity> SelectBannerByCategoryNotAsync(int ID)
        {

            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginBannerEntity> list = new List<PluginBannerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginBannerEntity entity = EntityHelper(reader, false);
                    if (entity.CategoryID == ID && entity.IsDeleted == false)
                    {
                        list.Add(entity);
                    }
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
        public async static Task<ResultEntity<PluginBannerEntity>> Plugin_Banners_SelectByID(int ID)
        {

            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginBannerRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<PluginBannerEntity>> SelectBannerByCategory(int CatID)
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginBannerEntity> list = new List<PluginBannerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginBannerEntity entity = EntityHelper(reader, false);
                    if (entity.CategoryID == CatID && entity.IsDeleted == false)
                    {
                        list.Add(entity);
                    }
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
        public async static Task<ResultList<PluginBannerEntity>> SelectAll()
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginBannerEntity> list = new List<PluginBannerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginBannerEntity entity = EntityHelper(reader, false);

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
        public async static Task<ResultList<PluginBannerEntity>> SelectAllByBodyBannar()
        {
            ResultList<PluginBannerEntity> result = new ResultList<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_SelectByBodyBannar, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginBannerEntity> list = new List<PluginBannerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginBannerEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginBannerEntity>> Plugin_Banners_Update(PluginBannerEntity entity)
        {

            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Sammery, entity.Sammery);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.BannerImage, entity.BannerImage);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IconImage, entity.IconImage);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.CategoryID, entity.CategoryID);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LinkTitle, entity.LinkTitle);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Target, entity.Target);
                //sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.AddDate, entity.AddDate);
                //sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.BannerOrder, entity.BannerOrder);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.PublishDate, entity.PublishDate);

                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Link1, entity.Link1);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Target1, entity.Target1);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Link2, entity.Link2);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Target2, entity.Target2);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LinkImage1, entity.LinkImage1);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LinkImage2, entity.LinkImage2);

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
        public async static Task<ResultEntity<PluginBannerEntity>> Plugin_Banners_Insert(PluginBannerEntity entity)
        {

            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Sammery, entity.Sammery);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.BannerImage, entity.BannerImage);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IconImage, entity.IconImage);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.CategoryID, entity.CategoryID);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LinkTitle, entity.LinkTitle);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.BannerOrder, entity.BannerOrder);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.PublishDate, entity.PublishDate);

                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Link1, entity.Link1);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Target1, entity.Target1);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Link2, entity.Link2);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.Target2, entity.Target2);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LinkImage1, entity.LinkImage1);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.LinkImage2, entity.LinkImage2);

                sqlCommand.Parameters.Add(PluginBannerRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginBannerRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginBannerEntity>> Plugin_Banners_Delete(int ID)
        {
            ResultEntity<PluginBannerEntity> result = new ResultEntity<PluginBannerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginBannerRepositoryConstants.Plugin_Banners_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginBannerRepositoryConstants.ID, ID));
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
        static PluginBannerEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginBannerEntity entity = new PluginBannerEntity();

            entity.ID = Convert.ToInt32(reader[PluginBannerEntityConstants.ID].ToString());
            entity.Title = reader[PluginBannerEntityConstants.Title].ToString();
            entity.Sammery = reader[PluginBannerEntityConstants.Sammery].ToString();
            entity.BannerImage = reader[PluginBannerEntityConstants.BannerImage] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.BannerImage].ToString();
            entity.IconImage = reader[PluginBannerEntityConstants.IconImage] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.IconImage].ToString();
            entity.LinkTitle = reader[PluginBannerEntityConstants.LinkTitle] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.LinkTitle].ToString();
            entity.Link = reader[PluginBannerEntityConstants.Link].ToString();
            entity.Target = reader[PluginBannerEntityConstants.Target].ToString();
            entity.CategoryID = Convert.ToInt32(reader[PluginBannerEntityConstants.CategoryID].ToString());
            entity.LanguageID = Convert.ToInt32(reader[PluginBannerEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginBannerEntityConstants.IsDeleted].ToString());
            entity.ImageTitle = reader[PluginBannerEntityConstants.ImageTitle].ToString();
            entity.AltIamge = reader[PluginBannerEntityConstants.AltIamge].ToString();
            entity.AddDate = Convert.ToDateTime(reader[PluginBannerEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginBannerEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginBannerEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginBannerEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[PluginBannerEntityConstants.LanguageName].ToString();
            }
            //----------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("BannerOrder");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.BannerOrder = reader[PluginBannerEntityConstants.BannerOrder] == DBNull.Value ? 0 : Convert.ToInt32(reader[PluginBannerEntityConstants.BannerOrder].ToString());
            }
            else
            {
                entity.BannerOrder = 0;
            }
            //----------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("PublishDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.PublishDate = reader[PluginBannerEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[PluginBannerEntityConstants.PublishDate].ToString());
            }
            else
            {
                entity.PublishDate = DateTime.Now;
            }
            //----------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("IsPublished");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IsPublished = reader[PluginBannerEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[PluginBannerEntityConstants.IsPublished].ToString());
            }
            else
            {
                entity.IsPublished = true;
            }


            //27052020
            try
            {
                int columnOrdinal = reader.GetOrdinal("Link1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Link1 = reader[PluginBannerEntityConstants.Link1] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.Link1].ToString();
            }
            else
            {
                entity.Link1 = string.Empty;
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("Link2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Link2 = reader[PluginBannerEntityConstants.Link2] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.Link2].ToString();
            }
            else
            {
                entity.Link2 = string.Empty;
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("Target1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Target1 = reader[PluginBannerEntityConstants.Target1] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.Target1].ToString();
            }
            else
            {
                entity.Target1 = string.Empty;
            }



            try
            {
                int columnOrdinal = reader.GetOrdinal("Target2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Target2 = reader[PluginBannerEntityConstants.Target2] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.Target2].ToString();
            }
            else
            {
                entity.Target2 = string.Empty;
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("LinkImage1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.LinkImage1 = reader[PluginBannerEntityConstants.LinkImage1] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.LinkImage1].ToString();
            }
            else
            {
                entity.LinkImage1 = string.Empty;
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("LinkImage2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.LinkImage2 = reader[PluginBannerEntityConstants.LinkImage2] == DBNull.Value ? string.Empty : reader[PluginBannerEntityConstants.LinkImage2].ToString();
            }
            else
            {
                entity.LinkImage2 = string.Empty;
            }
            // 27052020




            return entity;
        }
    }
}
