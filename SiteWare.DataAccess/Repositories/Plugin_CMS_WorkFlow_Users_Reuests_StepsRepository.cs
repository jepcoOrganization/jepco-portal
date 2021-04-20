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
   public static class Plugin_CMS_WorkFlow_Users_Reuests_StepsRepository
    {
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, ID));
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
         public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, ID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
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

        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> SelectAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> list = new List<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> list = new List<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> Update(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.CloseStep, entity.CloseStep);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.IsDelete, entity.IsDelete);
                
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> UpdateNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.CloseStep, entity.CloseStep);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, entity.ID);

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


        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> Insert(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.CloseStep, entity.CloseStep);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> InsertNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.WF_ID, entity.WF_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.CloseStep, entity.CloseStep);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID].Value);

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

        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>> Delete(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, entity.ID);

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
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> DeleteNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants.ID, entity.ID);

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

        static Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity entity = new Plugin_CMS_WorkFlow_Users_Reuests_StepsEntity();

            entity.ID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.ID].ToString());
            entity.WF_ID = reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.WF_ID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.WF_ID]);
            entity.StepName = reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.StepName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.StepName]);
            entity.CloseStep = reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.CloseStep] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.CloseStep]);
            entity.Order = reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.Order]);
            entity.IsDelete = reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.IsDelete]);
            
            
            //bool ColumnExists = false;
            //try
            //{
            //    int columnOrdinal = reader.GetOrdinal("LanguageName");
            //    ColumnExists = true;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    ColumnExists = false;
            //}

            //if (ColumnExists)
            //{
            //    entity.LanguageName = reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.LanguageName].ToString();
            //}


            return entity;
        }

    }
}
