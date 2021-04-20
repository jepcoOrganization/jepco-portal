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
   public static class Plugin_CMS_WorkFlow_Repository
    {
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_RepositoryConstants.ID, ID));
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
        public static ResultEntity<Plugin_CMS_WorkFlow_Entity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_RepositoryConstants.ID, ID));
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
        public async static Task<ResultList<Plugin_CMS_WorkFlow_Entity>> SelectAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Entity> list = new List<Plugin_CMS_WorkFlow_Entity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Entity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CMS_WorkFlow_Entity> SelectAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Entity> list = new List<Plugin_CMS_WorkFlow_Entity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Entity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CMS_WorkFlow_Entity> SelectAllRequestIDNotAsync(long RequestID)
        {
            ResultList<Plugin_CMS_WorkFlow_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_SelectAllRequestID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Entity> list = new List<Plugin_CMS_WorkFlow_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_RepositoryConstants.RequestID, RequestID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Entity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> Update(Plugin_CMS_WorkFlow_Entity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.From_User, entity.From_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.To_User, entity.To_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Send_Date, entity.Send_Date);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ProcessName, entity.ProcessName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ShowToUser, entity.ShowToUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ReqBackFlag, entity.ReqBackFlag);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.InsertMultiFlag, entity.InsertMultiFlag);
                


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
        public static ResultEntity<Plugin_CMS_WorkFlow_Entity> UpdateNotAsync(Plugin_CMS_WorkFlow_Entity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.From_User, entity.From_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.To_User, entity.To_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Send_Date, entity.Send_Date);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ProcessName, entity.ProcessName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ShowToUser, entity.ShowToUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.EditDate, entity.EditDate);
                 sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ReqBackFlag, entity.ReqBackFlag);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.InsertMultiFlag, entity.InsertMultiFlag);

                sqlCommand.ExecuteNonQueryAsync();
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
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> Delete(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ID, ID);

                await sqlCommand.ExecuteReaderAsync();

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
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Entity>> Insert(Plugin_CMS_WorkFlow_Entity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.From_User, entity.From_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.To_User, entity.To_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Send_Date, entity.Send_Date);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ProcessName, entity.ProcessName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ShowToUser, entity.ShowToUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ReqBackFlag, entity.ReqBackFlag);
                 sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.InsertMultiFlag, entity.InsertMultiFlag);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Attachment, entity.Attachment);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Attachment3, entity.Attachment3);

                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_RepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_CMS_WorkFlow_Entity> InsertNotAsync(Plugin_CMS_WorkFlow_Entity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Entity> result = new ResultEntity<Plugin_CMS_WorkFlow_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.From_User, entity.From_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.To_User, entity.To_User);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Send_Date, entity.Send_Date);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ProcessName, entity.ProcessName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ShowToUser, entity.ShowToUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.EditDate, entity.EditDate);
               sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.ReqBackFlag, entity.ReqBackFlag);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.InsertMultiFlag, entity.InsertMultiFlag);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Attachment, entity.Attachment);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_RepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_RepositoryConstants.ID].Value);

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

        static Plugin_CMS_WorkFlow_Entity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CMS_WorkFlow_Entity entity = new Plugin_CMS_WorkFlow_Entity();


            entity.ID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_EntityConstants.ID].ToString());
            entity.WF_ID = reader[Plugin_CMS_WorkFlow_EntityConstants.WF_ID] == DBNull.Value ? 1 : Convert.ToInt32(reader[Plugin_CMS_WorkFlow_EntityConstants.WF_ID].ToString());
            entity.RequestID = reader[Plugin_CMS_WorkFlow_EntityConstants.RequestID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CMS_WorkFlow_EntityConstants.RequestID].ToString());
            entity.From_User = reader[Plugin_CMS_WorkFlow_EntityConstants.From_User] == DBNull.Value ? string.Empty : reader[Plugin_CMS_WorkFlow_EntityConstants.From_User].ToString();
            entity.To_User = reader[Plugin_CMS_WorkFlow_EntityConstants.To_User] == DBNull.Value ? string.Empty : reader[Plugin_CMS_WorkFlow_EntityConstants.To_User].ToString();
            entity.Send_Date = reader[Plugin_CMS_WorkFlow_EntityConstants.Send_Date] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_EntityConstants.Send_Date].ToString());
            entity.ProcessName = reader[Plugin_CMS_WorkFlow_EntityConstants.ProcessName] == DBNull.Value ? string.Empty : reader[Plugin_CMS_WorkFlow_EntityConstants.ProcessName].ToString();
            entity.Notes = reader[Plugin_CMS_WorkFlow_EntityConstants.Notes] == DBNull.Value ? string.Empty : reader[Plugin_CMS_WorkFlow_EntityConstants.Notes].ToString();
            entity.ShowToUser = reader[Plugin_CMS_WorkFlow_EntityConstants.ShowToUser] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CMS_WorkFlow_EntityConstants.ShowToUser].ToString());
            entity.ProcessName = reader[Plugin_CMS_WorkFlow_EntityConstants.ProcessName] == DBNull.Value ? string.Empty : reader[Plugin_CMS_WorkFlow_EntityConstants.ProcessName].ToString();
            entity.IsDelete = reader[Plugin_CMS_WorkFlow_EntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CMS_WorkFlow_EntityConstants.IsDelete].ToString());
            entity.AddDate = reader[Plugin_CMS_WorkFlow_EntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_EntityConstants.AddDate].ToString());
            entity.EditDate = reader[Plugin_CMS_WorkFlow_EntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_EntityConstants.EditDate].ToString());
            

            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("ReqBackFlag");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ReqBackFlag = reader[Plugin_CMS_WorkFlow_EntityConstants.ReqBackFlag] == DBNull.Value ? false : Convert.ToBoolean( reader[Plugin_CMS_WorkFlow_EntityConstants.ReqBackFlag].ToString());
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("InsertMultiFlag");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.InsertMultiFlag = reader[Plugin_CMS_WorkFlow_EntityConstants.InsertMultiFlag] == DBNull.Value ? false : Convert.ToBoolean( reader[Plugin_CMS_WorkFlow_EntityConstants.InsertMultiFlag].ToString());
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
                entity.Attachment = reader[Plugin_CMS_WorkFlow_EntityConstants.Attachment] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_EntityConstants.Attachment].ToString());
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
                entity.Attachment2 = reader[Plugin_CMS_WorkFlow_EntityConstants.Attachment2] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_EntityConstants.Attachment2].ToString());
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
                entity.Attachment3 = reader[Plugin_CMS_WorkFlow_EntityConstants.Attachment3] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_EntityConstants.Attachment3].ToString());
            }

            return entity;
        }

    }
}
