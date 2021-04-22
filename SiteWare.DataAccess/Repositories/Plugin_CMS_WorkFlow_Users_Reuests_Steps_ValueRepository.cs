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
   public static class Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepository
    {
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, ID));
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
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
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

        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> SelectAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> list = new List<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> list = new List<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> GetAllByRequestIDNotAsync(long RequestID)
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_SelectAllByRequestID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> list = new List<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestID, RequestID);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> Update(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestUserStepID, entity.RequestUserStepID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepNotes, entity.StepNotes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.CompletedDate, entity.CompletedDate);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> UpdateNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestUserStepID, entity.RequestUserStepID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepNotes, entity.StepNotes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.CompletedDate, entity.CompletedDate);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> UpdateStatusNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_UpdateStatus, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
               
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepNotes, entity.StepNotes);                
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.CompletedDate, entity.CompletedDate);
                //sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, entity.ID);

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


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> Insert(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestUserStepID, entity.RequestUserStepID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepNotes, entity.StepNotes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Adddate, entity.Adddate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Attachment, entity.Attachment);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.CompletedDate, entity.CompletedDate);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> InsertNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.RequestUserStepID, entity.RequestUserStepID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepNotes, entity.StepNotes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Adddate, entity.Adddate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Attachment, entity.Attachment);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.CompletedDate, entity.CompletedDate);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID].Value);

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

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>> Delete(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, entity.ID);

                await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> DeleteNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants.ID, entity.ID);

                sqlCommand.ExecuteReader();
                result.Entity = entity;


                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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

        static Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity entity = new Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntity();

            entity.ID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.ID].ToString());
            entity.RequestID = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.RequestID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.RequestID]);
            entity.RequestUserStepID = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.RequestUserStepID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.RequestUserStepID]);
            entity.StepName = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepName]);
            entity.StepNotes = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepNotes] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepNotes]);
            entity.IsDelete = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.IsDelete]);
            entity.AddUser = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.AddUser] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.AddUser]);
            entity.EditUser = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.EditUser] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.EditUser]);
            entity.AddUserName = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.AddUserName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.AddUserName]);
            entity.StepStatus = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepStatus] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepStatus]);            

            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("Adddate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Adddate = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Adddate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Adddate].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("EditDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.EditDate = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.EditDate].ToString());
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("Attachment");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Attachment = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment].ToString());
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("Attachment2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Attachment2 = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment2] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment2].ToString());
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("Attachment3");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Attachment3 = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment3] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment3].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("CompletedDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.CompletedDate = reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.CompletedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.CompletedDate].ToString());
            }


            return entity;
        }



    }
}
