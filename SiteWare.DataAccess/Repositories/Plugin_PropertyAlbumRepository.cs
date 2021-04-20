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
    public static class Plugin_PropertyAlbumRepository
    {
        public static ResultList<Plugin_PropertyAlbumEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_PropertyAlbumEntity> result = new ResultList<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyAlbumEntity> list = new List<Plugin_PropertyAlbumEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PropertyAlbumEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> PropertyAlbums_SelectByID(int ID)
        {

            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_SelectbyID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyAlbumRepositoryConstants.AlbumID, ID));
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

        public async static Task<ResultList<Plugin_PropertyAlbumEntity>> SelectPropertyAlbumByProperty(int PropertyID)
        {
            ResultList<Plugin_PropertyAlbumEntity> result = new ResultList<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_SelectbyPropertyID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyAlbumEntity> list = new List<Plugin_PropertyAlbumEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyAlbumRepositoryConstants.PropertyID, PropertyID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PropertyAlbumEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Plugin_PropertyAlbumEntity>> SelectAll()
        {
            ResultList<Plugin_PropertyAlbumEntity> result = new ResultList<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyAlbumEntity> list = new List<Plugin_PropertyAlbumEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PropertyAlbumEntity entity = EntityHelper(reader, false);

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

        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> Plugin_PropertyAlbums_Update(Plugin_PropertyAlbumEntity entity)
        {

            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.PropertyID, entity.PropertyID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.AlbumOrder, entity.AlbumOrder);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.AlbumID, entity.AlbumID);
                
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

        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> Plugin_PropertyAlbums_Insert(Plugin_PropertyAlbumEntity entity)
        {

            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.PropertyID, entity.PropertyID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.AlbumOrder, entity.AlbumOrder);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumRepositoryConstants.AddUser, entity.AddUser);

                sqlCommand.Parameters.Add(Plugin_PropertyAlbumRepositoryConstants.AlbumID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.AlbumID = Convert.ToInt32(sqlCommand.Parameters[Plugin_PropertyAlbumRepositoryConstants.AlbumID].Value);

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

        public async static Task<ResultEntity<Plugin_PropertyAlbumEntity>> Plugin_PropertyAlbums_Delete(int AlbumID)
        {
            ResultEntity<Plugin_PropertyAlbumEntity> result = new ResultEntity<Plugin_PropertyAlbumEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyAlbumRepositoryConstants.AlbumID, AlbumID));
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

        static Plugin_PropertyAlbumEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_PropertyAlbumEntity entity = new Plugin_PropertyAlbumEntity();

            entity.AlbumID = Convert.ToInt32(reader[Plugin_PropertyAlbumEntityConstants.AlbumID].ToString());
            entity.PropertyID = Convert.ToInt64(reader[Plugin_PropertyAlbumEntityConstants.PropertyID].ToString());
            entity.Title = reader[Plugin_PropertyAlbumEntityConstants.Title].ToString();
            entity.Image = reader[Plugin_PropertyAlbumEntityConstants.Image].ToString();
            entity.ImageTitle = reader[Plugin_PropertyAlbumEntityConstants.ImageTitle].ToString();
            entity.LanguageID = Convert.ToInt32(reader[Plugin_PropertyAlbumEntityConstants.LanguageID].ToString());
            entity.IsPublish = Convert.ToBoolean(reader[Plugin_PropertyAlbumEntityConstants.IsPublish].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[Plugin_PropertyAlbumEntityConstants.PublishDate].ToString());
            entity.AlbumOrder = Convert.ToInt32(reader[Plugin_PropertyAlbumEntityConstants.AlbumOrder].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_PropertyAlbumEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_PropertyAlbumEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_PropertyAlbumEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_PropertyAlbumEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_PropertyAlbumEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
