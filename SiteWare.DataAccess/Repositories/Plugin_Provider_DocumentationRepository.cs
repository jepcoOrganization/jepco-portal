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
    public class Plugin_Provider_DocumentationRepository
    {
        public async static Task<ResultList<Plugin_ProviderDocumentationEntity>> SelectAll()
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentation_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderDocumentationEntity> list = new List<Plugin_ProviderDocumentationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ProviderDocumentationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_ProviderDocumentationEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentation_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderDocumentationEntity> list = new List<Plugin_ProviderDocumentationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ProviderDocumentationEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_ProviderDocumentationEntity>> InsertProviderDocumentation(Plugin_ProviderDocumentationEntity entity)
        {

            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentTypeID, entity.DocumentTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.FileName, entity.FileName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentaionID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;

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
        public static ResultEntity<Plugin_ProviderDocumentationEntity> InsertProviderDocumentationNotAsync(Plugin_ProviderDocumentationEntity entity)
        {

            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentTypeID, entity.DocumentTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.FileName, entity.FileName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentaionID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                result.Entity = entity;
                //entity.ProviderID = Convert.ToInt64(sqlCommand.Parameters[Plugin_ProviderDocumentationRepositoryConstant.ProviderID].Value);


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
        public async static Task<ResultList<Plugin_ProviderDocumentationEntity>> SelectByProviderID(long ProviderID)
        {

            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_SelectByProviderID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderDocumentationEntity> list = new List<Plugin_ProviderDocumentationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ProviderRepositoryConstants.ProviderID, ProviderID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Plugin_ProviderDocumentationEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_ProviderDocumentationEntity>> UpdateProviderDocument(Plugin_ProviderDocumentationEntity entity)
        {

            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentaionID, entity.ProviderDocumentaionID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentTypeID, entity.DocumentTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.FileName, entity.FileName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditUser, entity.EditUser);

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
        public static ResultEntity<Plugin_ProviderDocumentationEntity> UpdateProviderDocumentNotAsync(Plugin_ProviderDocumentationEntity entity)
        {

            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentaionID, entity.ProviderDocumentaionID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentTypeID, entity.DocumentTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.FileName, entity.FileName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.EditUser, entity.EditUser);

                sqlCommand.ExecuteNonQuery();
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
        public async static Task<ResultEntity<Plugin_ProviderDocumentationEntity>> ProviderDocumentUpdateByIsDeleted(Plugin_ProviderDocumentationEntity entity)
        {

            ResultEntity<Plugin_ProviderDocumentationEntity> result = new ResultEntity<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderDocumentationRepositoryConstant.ProviderID, entity.ProviderID);

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
        public static ResultList<Plugin_ProviderDocumentationEntity> SelectByProviderIDNonasync(long ProviderID)
        {

            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.SP_SelectByProviderID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderDocumentationEntity> list = new List<Plugin_ProviderDocumentationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ProviderDocumentationRepositoryConstant.ProviderID, ProviderID));
                SqlDataReader reader = sqlCommand.ExecuteReader();


                while (reader.Read())
                {
                    Plugin_ProviderDocumentationEntity entity = EntityHelper(reader, false);
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
        static Plugin_ProviderDocumentationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ProviderDocumentationEntity entity = new Plugin_ProviderDocumentationEntity();
            entity.ProviderDocumentaionID = Convert.ToInt32(reader[Plugin_ProviderDocumentationEntityConstants.ProviderDocumentaionID].ToString());
            entity.ProviderID = Convert.ToInt64(reader[Plugin_ProviderDocumentationEntityConstants.ProviderID].ToString());
            entity.DocumentTypeID = Convert.ToInt32(reader[Plugin_ProviderDocumentationEntityConstants.DocumentTypeID].ToString());
            entity.DocumentType = reader[Plugin_ProviderDocumentationEntityConstants.DocumentType].ToString();
            entity.FileName = reader[Plugin_ProviderDocumentationEntityConstants.FileName].ToString();
            entity.IsApproved = Convert.ToBoolean(reader[Plugin_ProviderDocumentationEntityConstants.IsApproved].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_ProviderDocumentationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_ProviderDocumentationEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_ProviderDocumentationEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_ProviderDocumentationEntityConstants.AddUser].ToString();
            entity.EditDate = Convert.ToDateTime(reader[Plugin_ProviderDocumentationEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_ProviderDocumentationEntityConstants.EditUser].ToString();

            return entity;
        }
    }

}
