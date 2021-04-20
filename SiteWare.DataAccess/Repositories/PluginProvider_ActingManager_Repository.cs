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
    public class PluginProvider_ActingManager_Repository
    {
        public async static Task<ResultList<PluginProvider_ActingManagerEntity>> SelectAll()
        {
            ResultList<PluginProvider_ActingManagerEntity> result = new ResultList<PluginProvider_ActingManagerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_ActingManager_RepositoryConstants.ActingManager_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginProvider_ActingManagerEntity> list = new List<PluginProvider_ActingManagerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginProvider_ActingManagerEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<PluginProvider_ActingManagerEntity>> SelectByProviderID(long ProviderID)
        {

            ResultList<PluginProvider_ActingManagerEntity> result = new ResultList<PluginProvider_ActingManagerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_ActingManager_RepositoryConstants.SP_SelectByProviderID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginProvider_ActingManagerEntity> list = new List<PluginProvider_ActingManagerEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginProvider_ActingManager_RepositoryConstants.ProviderID, ProviderID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PluginProvider_ActingManagerEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginProvider_ActingManagerEntity>> ActingManager_Update(PluginProvider_ActingManagerEntity entity)
        {

            ResultEntity<PluginProvider_ActingManagerEntity> result = new ResultEntity<PluginProvider_ActingManagerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_ActingManager_RepositoryConstants.ActingManager_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ActingManagerName, entity.ActingManagerName);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ActingManagerPhoneNo, entity.ActingManagerPhoneNo);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<PluginProvider_ActingManagerEntity>> ActingManager_Insert(PluginProvider_ActingManagerEntity entity)
        {

            ResultEntity<PluginProvider_ActingManagerEntity> result = new ResultEntity<PluginProvider_ActingManagerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_ActingManager_RepositoryConstants.ActingManager_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ActingManagerName, entity.ActingManagerName);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ActingManagerPhoneNo, entity.ActingManagerPhoneNo);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(PluginProvider_ActingManager_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                //entity.ID = Convert.ToInt64(sqlCommand.Parameters[PluginProvider_ActingManager_RepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginProvider_ActingManagerEntity>> ActingManagerUpdateByIsDelete(PluginProvider_ActingManagerEntity entity)
        {

            ResultEntity<PluginProvider_ActingManagerEntity> result = new ResultEntity<PluginProvider_ActingManagerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_ActingManager_RepositoryConstants.SP_DeleteActingManager, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginProvider_ActingManager_RepositoryConstants.ProviderID, entity.ProviderID);

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

        static PluginProvider_ActingManagerEntity EntityHelper(SqlDataReader reader, bool v)
        {
            PluginProvider_ActingManagerEntity entity = new PluginProvider_ActingManagerEntity();

            entity.ID = Convert.ToInt64(reader[PluginProvider_ActingManager_EntityConstants.ID].ToString());
            entity.ProviderID = Convert.ToInt64(reader[PluginProvider_ActingManager_EntityConstants.ProviderID].ToString());
            entity.ActingManagerName = reader[PluginProvider_ActingManager_EntityConstants.ActingManagerName].ToString();
            entity.ActingManagerPhoneNo = reader[PluginProvider_ActingManager_EntityConstants.ActingManagerPhoneNo].ToString();
            entity.IsDelete = Convert.ToBoolean(reader[PluginProvider_ActingManager_EntityConstants.IsDelete].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[PluginProvider_ActingManager_EntityConstants.IsPublished].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginProvider_ActingManager_EntityConstants.AddDate].ToString());
            entity.AddUser = reader[PluginProvider_ActingManager_EntityConstants.AddUser].ToString();
            entity.EditDate = Convert.ToDateTime(reader[PluginProvider_ActingManager_EntityConstants.EditDate].ToString());
            entity.EditUser = reader[PluginProvider_ActingManager_EntityConstants.EditUser].ToString();
            return entity;
        }
    }
}
    