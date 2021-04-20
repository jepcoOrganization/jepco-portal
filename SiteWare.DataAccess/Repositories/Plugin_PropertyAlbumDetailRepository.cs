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
    public static class Plugin_PropertyAlbumDetailRepository
    {
        public static ResultList<Plugin_PropertyAlbumDetailEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_PropertyAlbumDetailEntity> result = new ResultList<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyAlbumDetailEntity> list = new List<Plugin_PropertyAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PropertyAlbumDetailEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> PropertyAlbumsDetail_SelectByID(int ID)
        {

            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_SelectbyID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumDetailID, ID));
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

        public async static Task<ResultList<Plugin_PropertyAlbumDetailEntity>> SelectPropertyAlbumDetailByAlbumID(int AlbumID)
        {
            ResultList<Plugin_PropertyAlbumDetailEntity> result = new ResultList<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_SelectbyAlbumID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyAlbumDetailEntity> list = new List<Plugin_PropertyAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumID, AlbumID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PropertyAlbumDetailEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Plugin_PropertyAlbumDetailEntity>> SelectAll()
        {
            ResultList<Plugin_PropertyAlbumDetailEntity> result = new ResultList<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyAlbumDetailEntity> list = new List<Plugin_PropertyAlbumDetailEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PropertyAlbumDetailEntity entity = EntityHelper(reader, false);

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

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> Plugin_PropertyAlbumsDetail_Update(Plugin_PropertyAlbumDetailEntity entity)
        {

            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumDetailID, entity.AlbumDetailID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumID, entity.AlbumID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.PropertyID, entity.PropertyID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.ItemLink, entity.ItemLink);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.ItemOredr, entity.ItemOredr);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> Plugin_PropertyAlbumsDetail_Insert(Plugin_PropertyAlbumDetailEntity entity)
        {

            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //try
            //{
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumID, entity.AlbumID);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.PropertyID, entity.PropertyID);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.Title, entity.Title);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.ItemLink, entity.ItemLink);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.ItemOredr, entity.ItemOredr);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.LanguageID, entity.LanguageID);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.Image, entity.Image);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.IsPublish, entity.IsPublish);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.PublishDate, entity.PublishDate);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.IsDeleted, entity.IsDeleted);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.AddDate, entity.AddDate);
            sqlCommand.Parameters.AddWithValue(Plugin_PropertyAlbumDetailRepositoryConstants.AddUser, entity.AddUser);

            sqlCommand.Parameters.Add(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumDetailID, SqlDbType.Int).Direction = ParameterDirection.Output;

            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            result.Entity = entity;
            entity.AlbumDetailID = Convert.ToInt32(sqlCommand.Parameters[Plugin_PropertyAlbumDetailRepositoryConstants.AlbumDetailID].Value);

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

        public async static Task<ResultEntity<Plugin_PropertyAlbumDetailEntity>> Plugin_PropertyAlbumsDetail_Delete(int AlbumDetailID)
        {
            ResultEntity<Plugin_PropertyAlbumDetailEntity> result = new ResultEntity<Plugin_PropertyAlbumDetailEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyAlbumDetailRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyAlbumDetailRepositoryConstants.AlbumDetailID, AlbumDetailID));
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

        static Plugin_PropertyAlbumDetailEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_PropertyAlbumDetailEntity entity = new Plugin_PropertyAlbumDetailEntity();

            entity.AlbumDetailID = Convert.ToInt32(reader[Plugin_PropertyAlbumDetailEntityConstants.AlbumDetailID].ToString());
            entity.AlbumID = Convert.ToInt32(reader[Plugin_PropertyAlbumDetailEntityConstants.AlbumID].ToString());
            entity.PropertyID = Convert.ToInt64(reader[Plugin_PropertyAlbumDetailEntityConstants.PropertyID].ToString());
            entity.Title = reader[Plugin_PropertyAlbumDetailEntityConstants.Title].ToString();
            entity.ItemLink = reader[Plugin_PropertyAlbumDetailEntityConstants.ItemLink].ToString();
            entity.ItemOredr = Convert.ToInt32(reader[Plugin_PropertyAlbumDetailEntityConstants.ItemOredr].ToString());
            entity.LanguageID = Convert.ToInt32(reader[Plugin_PropertyAlbumDetailEntityConstants.LanguageID].ToString());
            entity.Image = reader[Plugin_PropertyAlbumDetailEntityConstants.Image].ToString();
            entity.IsPublish = Convert.ToBoolean(reader[Plugin_PropertyAlbumDetailEntityConstants.IsPublish].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[Plugin_PropertyAlbumDetailEntityConstants.PublishDate].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_PropertyAlbumDetailEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_PropertyAlbumDetailEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_PropertyAlbumDetailEntityConstants.AddUser].ToString();
            entity.EditDate = Convert.ToDateTime(reader[Plugin_PropertyAlbumDetailEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_PropertyAlbumDetailEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
