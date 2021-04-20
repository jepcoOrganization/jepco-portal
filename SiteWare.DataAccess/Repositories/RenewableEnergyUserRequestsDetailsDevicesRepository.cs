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
    public static class RenewableEnergyUserRequestsDetailsDevicesRepository
    {
        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>> SelectByID(long ID)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID, ID));
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
        public static ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>> SelectAll()
        {
            ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsDevicesEntity> list = new List<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsDevicesEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsDevicesEntity> list = new List<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsDevicesEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>> Insert(RenewableEnergyUserRequestsDetailsDevicesEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID, entity.ID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.RenewableEnergyUserRequestsDetailsID, entity.RenewableEnergyUserRequestsDetailsID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DeviceID, entity.DeviceID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DeviceName, entity.DeviceName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DeviceDocument, entity.DeviceDocument);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID].Value);

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
        public static ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> InsertNotAsync(RenewableEnergyUserRequestsDetailsDevicesEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.RenewableEnergyUserRequestsDetailsID, entity.RenewableEnergyUserRequestsDetailsID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DeviceID, entity.DeviceID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DeviceName, entity.DeviceName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.DeviceDocument, entity.DeviceDocument);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.EditUser, entity.EditUser);




                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetailsDevicesRepositoryConstants.ID].Value);

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
        static RenewableEnergyUserRequestsDetailsDevicesEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyUserRequestsDetailsDevicesEntity entity = new RenewableEnergyUserRequestsDetailsDevicesEntity();

            try
            {

                entity.ID = Convert.ToInt64(reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.ID].ToString());
                entity.RenewableEnergyUserRequestsDetailsID = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.RenewableEnergyUserRequestsDetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.RenewableEnergyUserRequestsDetailsID].ToString());
                entity.DeviceID = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceID].ToString());
                entity.DeviceName = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceName] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceName].ToString();
                entity.DevicePower = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DevicePower] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DevicePower].ToString();
                entity.DeviceDocument = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceDocument] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.DeviceDocument].ToString();
                entity.NumberofUnits = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.NumberofUnits] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.NumberofUnits].ToString();
                entity.AddDate = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyUserRequestsDetailsDevicesEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}

