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
    public static class PluginSocialIconRepository
    {
        public static ResultList<PluginSocialIconEntity> SelectAllNotAsync()
        {
            ResultList<PluginSocialIconEntity> result = new ResultList<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSocialIconEntity> list = new List<PluginSocialIconEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginSocialIconEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<PluginSocialIconEntity>> Plugin_SocialIcons_SelectByID(int ID)
        {

            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginSocialIconRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<PluginSocialIconEntity>> SelectSocialIconByCategory()
        {
            ResultList<PluginSocialIconEntity> result = new ResultList<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSocialIconEntity> list = new List<PluginSocialIconEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginSocialIconEntity entity = EntityHelper(reader, false);
                    if ( entity.IsDeleted == false)
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
        public async static Task<ResultList<PluginSocialIconEntity>> SelectAll()
        {
            ResultList<PluginSocialIconEntity> result = new ResultList<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSocialIconEntity> list = new List<PluginSocialIconEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginSocialIconEntity entity = EntityHelper(reader, false); 

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
        public async static Task<ResultEntity<PluginSocialIconEntity>> Plugin_SocialIcons_Update(PluginSocialIconEntity entity)
        {

            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Imageover, entity.Imageover);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.IconOrder, entity.IconOrder);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.AddUser, entity.AddUser); 
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<PluginSocialIconEntity>> Plugin_SocialIcons_Insert(PluginSocialIconEntity entity)
        {

            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Imageover, entity.Imageover);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.IconOrder, entity.IconOrder);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Link, entity.Link); 
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.Target, entity.Target); 
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginSocialIconRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(PluginSocialIconRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginSocialIconRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginSocialIconEntity>> Plugin_SocialIcons_Delete(int ID)
        {
            ResultEntity<PluginSocialIconEntity> result = new ResultEntity<PluginSocialIconEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSocialIconRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginSocialIconRepositoryConstants.ID,ID));
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
        static PluginSocialIconEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginSocialIconEntity entity = new PluginSocialIconEntity();

            entity.ID = Convert.ToInt32(reader[PluginSocialIconEntityConstants.ID].ToString());
            entity.IconOrder = Convert.ToInt32(reader[PluginSocialIconEntityConstants.IconOrder].ToString());
            entity.Title = reader[PluginSocialIconEntityConstants.Title].ToString();
            entity.Image = reader[PluginSocialIconEntityConstants.Image].ToString();
            entity.Link = reader[PluginSocialIconEntityConstants.Link].ToString();
            entity.Target = reader[PluginSocialIconEntityConstants.Target].ToString();
            entity.Imageover = reader[PluginSocialIconEntityConstants.Imageover].ToString();
            entity.LanguageID = Convert.ToInt32(reader[PluginSocialIconEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginSocialIconEntityConstants.IsDeleted].ToString());
            entity.ImageTitle = reader[PluginSocialIconEntityConstants.ImageTitle].ToString();
            entity.AltIamge = reader[PluginSocialIconEntityConstants.AltIamge].ToString();
            entity.AddDate = Convert.ToDateTime(reader[PluginSocialIconEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginSocialIconEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginSocialIconEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginSocialIconEntityConstants.EditUser].ToString();

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
                entity.LanguageName = reader[PluginSocialIconEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
