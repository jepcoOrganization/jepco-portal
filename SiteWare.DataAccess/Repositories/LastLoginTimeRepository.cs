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
    public static class LastLoginTimeRepository
    {
        public async static Task<ResultEntity<LastLoginTimeEntity>> SelectByServiceUserID(long ServiceUserID)
        {

            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LastLoginTimeRepositoryConstants.GetLastLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(LastLoginTimeRepositoryConstants.ServiceUserID, ServiceUserID));
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
        public static ResultEntity<LastLoginTimeEntity> SelectByServiceUserIDNotAsync(long ServiceUserID)
        {

            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LastLoginTimeRepositoryConstants.GetLastLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(LastLoginTimeRepositoryConstants.ServiceUserID, ServiceUserID));
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
        

        public async static Task<ResultEntity<LastLoginTimeEntity>> UpdateLastLogin(LastLoginTimeEntity entity)
        {

            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LastLoginTimeRepositoryConstants.UpadateLastLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.ServiceUserID, entity.ServiceUserID);                
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.LastLoginTime, entity.LastLoginTime);
               


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
        public static ResultEntity<LastLoginTimeEntity> UpdateNotAsyncLastLogin(LastLoginTimeEntity entity)
        {

            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LastLoginTimeRepositoryConstants.UpadateLastLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.LastLoginTime, entity.LastLoginTime);

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


        public async static Task<ResultEntity<LastLoginTimeEntity>> Insert(LastLoginTimeEntity entity)
        {

            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LastLoginTimeRepositoryConstants.InsertLastLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.LastLoginTime, entity.LastLoginTime);
                


                sqlCommand.Parameters.Add(LastLoginTimeRepositoryConstants.LoginId, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.LoginId = Convert.ToInt64(sqlCommand.Parameters[LastLoginTimeRepositoryConstants.LoginId].Value);

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
        public static ResultEntity<LastLoginTimeEntity> InsertNotAsync(LastLoginTimeEntity entity)
        {

            ResultEntity<LastLoginTimeEntity> result = new ResultEntity<LastLoginTimeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LastLoginTimeRepositoryConstants.InsertLastLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(LastLoginTimeRepositoryConstants.LastLoginTime, entity.LastLoginTime);

                sqlCommand.Parameters.Add(LastLoginTimeRepositoryConstants.LoginId, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.LoginId = Convert.ToInt64(sqlCommand.Parameters[LastLoginTimeRepositoryConstants.LoginId].Value);

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
        static LastLoginTimeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            LastLoginTimeEntity entity = new LastLoginTimeEntity();


            entity.LoginId = Convert.ToInt64(reader[LastLoginTimeEntityConstants.LoginId].ToString());
            entity.ServiceUserID = Convert.ToInt64(reader[LastLoginTimeEntityConstants.ServiceUserID].ToString());
            entity.LastLoginTime = reader[LastLoginTimeEntityConstants.LastLoginTime] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[LastLoginTimeEntityConstants.LastLoginTime].ToString());
           
            return entity;
        }
    }
}
