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
    public static class PluginAlbumDetailRepository
    {
        public static ResultList<PluginAlbumDetailEntity> SelectAllNotAsync()
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumDetailEntity> list = new List<PluginAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAlbumDetailEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginAlbumDetailEntity>> Plugin_Albums_SelectByID(int ID)
        {

            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumDetailRepositoryConstants.ID, ID));
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

        public async static Task<ResultList<PluginAlbumDetailEntity>> SelectAlbumByAlbumID(int AlbumID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumDetailEntity> list = new List<PluginAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginAlbumDetailEntity entity = EntityHelper(reader, false);
                    if (entity.AlbumID == AlbumID)
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

        public static ResultList<PluginAlbumDetailEntity> SelectAlbumByAlbumIDNotAsync(int AlbumID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumDetailEntity> list = new List<PluginAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAlbumDetailEntity entity = EntityHelper(reader, false);
                    if (entity.AlbumID == AlbumID)
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

        public async static Task<ResultList<PluginAlbumDetailEntity>> SelectAll()
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumDetailEntity> list = new List<PluginAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginAlbumDetailEntity entity = EntityHelper(reader, false); 

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

        public async static Task<ResultEntity<PluginAlbumDetailEntity>> Plugin_Albums_Update(PluginAlbumDetailEntity entity)
        {

            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.CoverImage, entity.CoverImage);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.AlbumID, entity.AlbumID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.ItemOredr, entity.ItemOredr);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.ItemLink, entity.ItemLink); 
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.OpenIn, entity.OpenIn);

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

        public async static Task<ResultEntity<PluginAlbumDetailEntity>> Plugin_Albums_Insert(PluginAlbumDetailEntity entity)
        {

            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //try
            //{
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.CoverImage, entity.CoverImage);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.AlbumID, entity.AlbumID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.ItemOredr, entity.ItemOredr);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.ItemLink, entity.ItemLink);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginAlbumDetailRepositoryConstants.OpenIn, entity.OpenIn);


            sqlCommand.Parameters.Add(PluginAlbumDetailRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginAlbumDetailRepositoryConstants.ID].Value);

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
            //}
            //catch (Exception ex)
            //{
            //    result.Status = ErrorEnums.Exception;
            //    result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //    sqlCommand.Dispose();
            //}

            return result;
        }
        public async static Task<ResultList<PluginAlbumDetailEntity>> SelectAlbumByTypeID(int TypeID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectAllByType, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumDetailEntity> list = new List<PluginAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumDetailRepositoryConstants.TypeID, TypeID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PluginAlbumDetailEntity entity = EntityHelper(reader, false);
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
        public  static ResultList<PluginAlbumDetailEntity> SelectAlbumByTypeIDNotAsync(int TypeID)
        {
            ResultList<PluginAlbumDetailEntity> result = new ResultList<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_SelectAllByType, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumDetailEntity> list = new List<PluginAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumDetailRepositoryConstants.TypeID, TypeID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    PluginAlbumDetailEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginAlbumDetailEntity>> Plugin_Albums_Delete(int ID)
        {
            ResultEntity<PluginAlbumDetailEntity> result = new ResultEntity<PluginAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumDetailRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumDetailRepositoryConstants.ID,ID));
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

        static PluginAlbumDetailEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginAlbumDetailEntity entity = new PluginAlbumDetailEntity();

            entity.ID = Convert.ToInt32(reader[PluginAlbumDetailEntityConstants.ID].ToString());
            entity.Title = reader[PluginAlbumDetailEntityConstants.Title].ToString();
            entity.CoverImage = reader[PluginAlbumDetailEntityConstants.CoverImage].ToString();
            entity.ItemOredr = Convert.ToInt32(reader[PluginAlbumDetailEntityConstants.ItemOredr].ToString());
            entity.IsPublish = Convert.ToBoolean(reader[PluginAlbumDetailEntityConstants.IsPublish].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[PluginAlbumDetailEntityConstants.PublishDate].ToString());
            entity.AlbumID = Convert.ToInt32(reader[PluginAlbumDetailEntityConstants.AlbumID].ToString());
            entity.LanguageID = Convert.ToInt32(reader[PluginAlbumDetailEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginAlbumDetailEntityConstants.IsDeleted].ToString());
            entity.ItemLink = reader[PluginAlbumDetailEntityConstants.ItemLink].ToString(); 
            entity.AddDate = Convert.ToDateTime(reader[PluginAlbumDetailEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginAlbumDetailEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginAlbumDetailEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginAlbumDetailEntityConstants.EditUser].ToString();
            entity.OpenIn = reader[PluginAlbumDetailEntityConstants.OpenIn].ToString();
            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("TypeID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.TypeID = reader[PluginAlbumDetailEntityConstants.TypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[PluginAlbumDetailEntityConstants.TypeID].ToString());
            }
            return entity;
        }
    }
}
