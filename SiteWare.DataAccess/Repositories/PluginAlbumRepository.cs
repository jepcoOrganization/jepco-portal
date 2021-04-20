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
    public static class PluginAlbumRepository
    {
        public static ResultList<PluginAlbumEntity> SelectAllNotAsync()
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumEntity> list = new List<PluginAlbumEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAlbumEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<PluginAlbumEntity>> Plugin_Albums_SelectByID(int ID)
        {

            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumRepositoryConstants.ID, ID));
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
        public static ResultList<PluginAlbumEntity> Plugin_Albums_SelectByIDNotAsync(int ID)
        {

            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_SelectByID, sqlConnection);
            List<PluginAlbumEntity> list = new List<PluginAlbumEntity>();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumRepositoryConstants.ID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAlbumEntity entity = EntityHelper(reader, false);
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
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public async static Task<ResultList<PluginAlbumEntity>> SelectAlbumByType(int TypeID)
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_SelectByTypeID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumEntity> list = new List<PluginAlbumEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumRepositoryConstants.TypeID, TypeID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginAlbumEntity entity = EntityHelper(reader, false);
                    //if(entity.TypeID== TypeID)
                    //{
                        list.Add(entity); 
                    //}
                   
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

        public  static ResultList<PluginAlbumEntity> SelectAlbumByTypeNotAsync(int TypeID)
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumEntity> list = new List<PluginAlbumEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginAlbumEntity entity = EntityHelper(reader, false);
                    if (entity.TypeID == TypeID)
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
        public async static Task<ResultList<PluginAlbumEntity>> SelectAll()
        {
            ResultList<PluginAlbumEntity> result = new ResultList<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginAlbumEntity> list = new List<PluginAlbumEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginAlbumEntity entity = EntityHelper(reader, false); 

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
        public async static Task<ResultEntity<PluginAlbumEntity>> Plugin_Albums_Update(PluginAlbumEntity entity)
        {

            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.TypeID, entity.TypeID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AlbumOrder, entity.AlbumOrder);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<PluginAlbumEntity>> Plugin_Albums_Insert(PluginAlbumEntity entity)
        {

            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.TypeID, entity.TypeID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.ViewCount, 0);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AlbumOrder, entity.AlbumOrder);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.PublishDate, entity.PublishDate); 
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginAlbumRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(PluginAlbumRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginAlbumRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginAlbumEntity>> Plugin_Albums_Delete(int ID)
        {
            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumRepositoryConstants.ID,ID));
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
        static PluginAlbumEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginAlbumEntity entity = new PluginAlbumEntity();

            entity.ID = Convert.ToInt32(reader[PluginAlbumEntityConstants.ID].ToString());
            entity.Title = reader[PluginAlbumEntityConstants.Title].ToString();
            entity.Image = reader[PluginAlbumEntityConstants.Image].ToString();
            entity.AlbumOrder = Convert.ToInt32(reader[PluginAlbumEntityConstants.AlbumOrder].ToString());
            entity.IsPublish = Convert.ToBoolean(reader[PluginAlbumEntityConstants.IsPublish].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[PluginAlbumEntityConstants.PublishDate].ToString());
            entity.TypeID = Convert.ToInt32(reader[PluginAlbumEntityConstants.TypeID].ToString());
            entity.LanguageID = Convert.ToInt32(reader[PluginAlbumEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginAlbumEntityConstants.IsDeleted].ToString());
            entity.ImageTitle = reader[PluginAlbumEntityConstants.ImageTitle].ToString();
            entity.AltIamge = reader[PluginAlbumEntityConstants.AltIamge].ToString();
            entity.AddDate = Convert.ToDateTime(reader[PluginAlbumEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginAlbumEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginAlbumEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginAlbumEntityConstants.EditUser].ToString();
            entity.ViewCount = Convert.ToInt32(reader[PluginAlbumEntityConstants.ViewCount].ToString());
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
                entity.LanguageName = reader[PluginAlbumEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[PluginAlbumEntityConstants.LanguageName].ToString();
            }


            return entity;
        }


        public async static Task<ResultEntity<PluginAlbumEntity>> UpdateViewCount(int id)
        {

            ResultEntity<PluginAlbumEntity> result = new ResultEntity<PluginAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginAlbumRepositoryConstants.SP_UpdateViewCount, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginAlbumRepositoryConstants.ID, id));
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


    }
}
