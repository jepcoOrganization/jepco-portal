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
   public static class ServicesStepsValuesRepository
    {
       
        public async static Task<ResultEntity<ServicesStepsValuesEntity>> SelectByID(long ID)
        {

            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ServicesStepsValuesRepositoryConstant.ID, ID));
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
        public static ResultEntity<ServicesStepsValuesEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ServicesStepsValuesRepositoryConstant.ID, ID));
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
        
        public async static Task<ResultList<ServicesStepsValuesEntity>> SelectAll()
        {
            ResultList<ServicesStepsValuesEntity> result = new ResultList<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<ServicesStepsValuesEntity> list = new List<ServicesStepsValuesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    ServicesStepsValuesEntity entity = EntityHelper(reader, false);
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
        public static ResultList<ServicesStepsValuesEntity> SelectAllNotAsync()
        {
            ResultList<ServicesStepsValuesEntity> result = new ResultList<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<ServicesStepsValuesEntity> list = new List<ServicesStepsValuesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    ServicesStepsValuesEntity entity = EntityHelper(reader, false);
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
        
        public async static Task<ResultEntity<ServicesStepsValuesEntity>> Update(ServicesStepsValuesEntity entity)
        {

            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.StepID, entity.StepID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ServiceID, entity.ServiceID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value1, entity.Value1);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value2, entity.Value2);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value3, entity.Value3);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value4, entity.Value4);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.IsDone, entity.IsDone);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ReceivedDateTime, entity.ReceivedDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.DoneDateTime, entity.DoneDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ID, entity.ID);

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
        public static ResultEntity<ServicesStepsValuesEntity> UpdateNotAsync(ServicesStepsValuesEntity entity)
        {

            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.StepID, entity.StepID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ServiceID, entity.ServiceID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value1, entity.Value1);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value2, entity.Value2);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value3, entity.Value3);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value4, entity.Value4);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.IsDone, entity.IsDone);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ReceivedDateTime, entity.ReceivedDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.DoneDateTime, entity.DoneDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ID, entity.ID);

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
        
        public async static Task<ResultEntity<ServicesStepsValuesEntity>> Insert(ServicesStepsValuesEntity entity)
        {

            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.StepID, entity.StepID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ServiceID, entity.ServiceID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value1, entity.Value1);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value2, entity.Value2);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value3, entity.Value3);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value4, entity.Value4);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.IsDone, entity.IsDone);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ReceivedDateTime, entity.ReceivedDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.DoneDateTime, entity.DoneDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.Add(ServicesStepsValuesRepositoryConstant.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[ServicesStepsValuesRepositoryConstant.ID].Value);

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
        public static ResultEntity<ServicesStepsValuesEntity> InsertNotAsync(ServicesStepsValuesEntity entity)
        {

            ResultEntity<ServicesStepsValuesEntity> result = new ResultEntity<ServicesStepsValuesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsValuesRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.StepID, entity.StepID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ServiceID, entity.ServiceID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value1, entity.Value1);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value2, entity.Value2);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value3, entity.Value3);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Value4, entity.Value4);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.Notes, entity.Notes);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.IsDone, entity.IsDone);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.ReceivedDateTime, entity.ReceivedDateTime);
                //sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.DoneDateTime, entity.DoneDateTime);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(ServicesStepsValuesRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.Add(ServicesStepsValuesRepositoryConstant.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[ServicesStepsValuesRepositoryConstant.ID].Value);

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
        
        static ServicesStepsValuesEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            ServicesStepsValuesEntity entity = new ServicesStepsValuesEntity();

            entity.ID = Convert.ToInt64(reader[ServicesStepsValuesEntityConstant.ID].ToString());
            entity.StepID = reader[ServicesStepsValuesEntityConstant.StepID] == DBNull.Value ? 0 : Convert.ToInt64(reader[ServicesStepsValuesEntityConstant.StepID].ToString());
            //entity.ServiceID = reader[ServicesStepsValuesEntityConstant.ServiceID] == DBNull.Value ? 0 : Convert.ToInt32(reader[ServicesStepsValuesEntityConstant.ServiceID].ToString());
            entity.ServiceID = reader[ServicesStepsValuesEntityConstant.ServiceID] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.ServiceID].ToString();
            entity.Value1 = reader[ServicesStepsValuesEntityConstant.Value1] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.Value1].ToString();
            entity.Value2 = reader[ServicesStepsValuesEntityConstant.Value2] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.Value2].ToString();
            entity.Value3 = reader[ServicesStepsValuesEntityConstant.Value3] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.Value3].ToString();
            entity.Value4 = reader[ServicesStepsValuesEntityConstant.Value4] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.Value4].ToString();
            entity.Notes = reader[ServicesStepsValuesEntityConstant.Notes] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.Notes].ToString();
            entity.IsDone = reader[ServicesStepsValuesEntityConstant.IsDone] == DBNull.Value ? false : Convert.ToBoolean(reader[ServicesStepsValuesEntityConstant.IsDone].ToString());
            entity.DoneDateTime = reader[ServicesStepsValuesEntityConstant.DoneDateTime] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[ServicesStepsValuesEntityConstant.DoneDateTime].ToString());
            entity.ReceivedDateTime = reader[ServicesStepsValuesEntityConstant.ReceivedDateTime] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[ServicesStepsValuesEntityConstant.ReceivedDateTime].ToString());

            entity.AddDate = reader[ServicesStepsValuesEntityConstant.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[ServicesStepsValuesEntityConstant.AddDate].ToString());
            entity.AddUser = reader[ServicesStepsValuesEntityConstant.AddUser] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.AddUser].ToString();
            entity.EditDate = reader[ServicesStepsValuesEntityConstant.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[ServicesStepsValuesEntityConstant.EditDate].ToString());
            entity.EditUser = reader[ServicesStepsValuesEntityConstant.EditUser] == DBNull.Value ? string.Empty : reader[ServicesStepsValuesEntityConstant.EditUser].ToString();


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
            //    entity.LanguageName = reader[ServicesStepsValuesEntityConstant.LanguageName].ToString();
            //}

            return entity;
        }

    }
}
