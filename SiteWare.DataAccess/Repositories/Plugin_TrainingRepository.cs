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
    public class Plugin_TrainingRepository
    {
        public static ResultList<Plugin_TrainingEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_TrainingEntity> result = new ResultList<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_TrainingEntity> list = new List<Plugin_TrainingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_TrainingEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_TrainingEntity>> Plugin_Tarining_SelectByID(long ID)
        {

            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_TrainingRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<Plugin_TrainingEntity>> SelectAll()
        {
            ResultList<Plugin_TrainingEntity> result = new ResultList<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_TrainingEntity> list = new List<Plugin_TrainingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_TrainingEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_TrainingEntity>> Plugin_Training_Update(Plugin_TrainingEntity entity)
        {

            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Details, entity.Details);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.TrainingDate, entity.TrainingDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.EditUser, entity.EditUser);
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
        public async static Task<ResultEntity<Plugin_TrainingEntity>> Plugin_Training_Insert(Plugin_TrainingEntity entity)
        {

            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Details, entity.Details);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.TrainingDate, entity.TrainingDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_TrainingRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(Plugin_TrainingRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[Plugin_TrainingRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<Plugin_TrainingEntity>> Plugin_Training_Delete(long ID)
        {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_TrainingRepositoryConstants.ID, ID));
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

        public async static Task<ResultEntity<Plugin_TrainingEntity>> Plugin_Training_ViewCount(long ID)
        {
            ResultEntity<Plugin_TrainingEntity> result = new ResultEntity<Plugin_TrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_TrainingRepositoryConstants.Plugin_Training_ViewCount, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_TrainingRepositoryConstants.ID, ID));
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

        static Plugin_TrainingEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_TrainingEntity entity = new Plugin_TrainingEntity();
            entity.ID = Convert.ToInt32(reader[Plugin_TrainingEntityConstants.ID].ToString());
            entity.LanguageID = Convert.ToInt32(reader[Plugin_TrainingEntityConstants.LanguageID].ToString());
            entity.Title = reader[Plugin_TrainingEntityConstants.Title].ToString();
            entity.Image = reader[Plugin_TrainingEntityConstants.Image].ToString();
            entity.Summary = reader[Plugin_TrainingEntityConstants.Summary].ToString();
            entity.Details = reader[Plugin_TrainingEntityConstants.Details].ToString();
            entity.PublishedDate = Convert.ToDateTime(reader[Plugin_TrainingEntityConstants.PublishedDate].ToString());
            entity.TrainingDate = Convert.ToDateTime(reader[Plugin_TrainingEntityConstants.TrainingDate].ToString());
            entity.Order = Convert.ToInt32(reader[Plugin_TrainingEntityConstants.Order].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_TrainingEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Plugin_TrainingEntityConstants.IsDelete].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_TrainingEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_TrainingEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_TrainingEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_TrainingEntityConstants.EditUser].ToString();
            entity.ViewCount = Convert.ToInt64(reader[Plugin_TrainingEntityConstants.ViewCount].ToString());

            return entity;
        }
    }
}
