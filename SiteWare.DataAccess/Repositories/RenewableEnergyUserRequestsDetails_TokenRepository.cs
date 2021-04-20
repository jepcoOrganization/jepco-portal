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
    public static class RenewableEnergyUserRequestsDetails_TokenRepository
    {

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>> SelectByLastData()
        {

            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.SP_SelectByLastData, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.ID, ID));
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
        public static ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> SelectByLastDataNotAsync()
        {

            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.SP_SelectByLastData, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.ID, ID));
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
        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>> Insert(RenewableEnergyUserRequestsDetails_TokenEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.TokenNo, entity.TokenNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.AddYear, entity.AddYear);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.AddMonth, entity.AddMonth);                
                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.ID].Value);

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
        public static ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> InsertNotAsync(RenewableEnergyUserRequestsDetails_TokenEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetails_TokenEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.TokenNo, entity.TokenNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.AddYear, entity.AddYear);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.AddMonth, entity.AddMonth);
                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;
               

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.ID].Value);

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                //result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Details = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        static RenewableEnergyUserRequestsDetails_TokenEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyUserRequestsDetails_TokenEntity entity = new RenewableEnergyUserRequestsDetails_TokenEntity();

            try
            {

                entity.ID = Convert.ToInt64(reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.ID].ToString());
                entity.DetailsID = reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.DetailsID].ToString());               
                entity.TokenNo = reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.TokenNo] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.TokenNo].ToString();
                entity.AddDate = reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddDate].ToString());
                entity.AddYear = reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddYear] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddYear].ToString();
                entity.AddMonth = reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddMonth] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetails_TokenEntityConstants.AddMonth].ToString();

            }
            catch (Exception ex)
            {

            }

            return entity;
        }


        public async static Task<ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>> SelectAll()
        {
            ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetails_TokenEntity> list = new List<RenewableEnergyUserRequestsDetails_TokenEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetails_TokenEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetails_TokenEntity> result = new ResultList<RenewableEnergyUserRequestsDetails_TokenEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetails_TokenRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetails_TokenEntity> list = new List<RenewableEnergyUserRequestsDetails_TokenEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetails_TokenEntity entity = EntityHelper(reader, false);
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

    }
}
