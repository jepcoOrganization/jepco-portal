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
    public class PluginProvider_Partner_Repository
    {
        public async static Task<ResultList<PluginProvider_Partner_Entity>> SelectAll()
        {
            ResultList<PluginProvider_Partner_Entity> result = new ResultList<PluginProvider_Partner_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_Partner_RepositoryConstants.Partner_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginProvider_Partner_Entity> list = new List<PluginProvider_Partner_Entity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginProvider_Partner_Entity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginProvider_Partner_Entity>> Partner_Update(PluginProvider_Partner_Entity entity)
        {

            ResultEntity<PluginProvider_Partner_Entity> result = new ResultEntity<PluginProvider_Partner_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_Partner_RepositoryConstants.Partner_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.PartnerName, entity.PartnerName);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.PartnerPhoneNo, entity.PartnerPhoneNo);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultList<PluginProvider_Partner_Entity>> SelectByProviderID(long ProviderID)
        {

            ResultList<PluginProvider_Partner_Entity> result = new ResultList<PluginProvider_Partner_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_Partner_RepositoryConstants.SP_SelectByProviderID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginProvider_Partner_Entity> list = new List<PluginProvider_Partner_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginProvider_Partner_RepositoryConstants.ProviderID, ProviderID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    PluginProvider_Partner_Entity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginProvider_Partner_Entity>> Partner_Insert(PluginProvider_Partner_Entity entity)
        {

            ResultEntity<PluginProvider_Partner_Entity> result = new ResultEntity<PluginProvider_Partner_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_Partner_RepositoryConstants.Partner_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.PartnerName, entity.PartnerName);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.PartnerPhoneNo, entity.PartnerPhoneNo);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(PluginProvider_Partner_RepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[PluginProvider_Partner_RepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginProvider_Partner_Entity>> PartnerUpdateByIsDelete(PluginProvider_Partner_Entity entity)
        {

            ResultEntity<PluginProvider_Partner_Entity> result = new ResultEntity<PluginProvider_Partner_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginProvider_Partner_RepositoryConstants.SP_DeleteActingManager, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginProvider_Partner_RepositoryConstants.ProviderID, entity.ProviderID);

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
        static PluginProvider_Partner_Entity EntityHelper(SqlDataReader reader, bool v)
        {
            PluginProvider_Partner_Entity entity = new PluginProvider_Partner_Entity();

            entity.ID = Convert.ToInt64(reader[PluginProvider_Partner_EntityConstants.ID].ToString());
            entity.ProviderID = Convert.ToInt64(reader[PluginProvider_Partner_EntityConstants.ProviderID].ToString());
            entity.PartnerName = reader[PluginProvider_Partner_EntityConstants.PartnerName].ToString();
            entity.PartnerPhoneNo = reader[PluginProvider_Partner_EntityConstants.PartnerPhoneNo].ToString();
            entity.IsDelete = Convert.ToBoolean(reader[PluginProvider_Partner_EntityConstants.IsDelete].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[PluginProvider_Partner_EntityConstants.IsPublished].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginProvider_Partner_EntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginProvider_Partner_EntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginProvider_Partner_EntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginProvider_Partner_EntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
