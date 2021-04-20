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
    public static class RenwableEnergyType3Phase2DetailsDevicesRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>> SelectByID(long ID)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID, ID));
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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsDevicesEntity> list = new List<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsDevicesEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsDevicesEntity> list = new List<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsDevicesEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>> Insert(RenwableEnergyType3Phase2DetailsDevicesEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID, entity.ID);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DeviceID, entity.DeviceID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DeviceName, entity.DeviceName);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DeviceDocument, entity.DeviceDocument);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> InsertNotAsync(RenwableEnergyType3Phase2DetailsDevicesEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsDevicesEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DeviceID, entity.DeviceID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DeviceName, entity.DeviceName);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.DeviceDocument, entity.DeviceDocument);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.EditUser, entity.EditUser);




                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsDevicesRepositoryConstants.ID].Value);

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
        static RenwableEnergyType3Phase2DetailsDevicesEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase2DetailsDevicesEntity entity = new RenwableEnergyType3Phase2DetailsDevicesEntity();

            try
            {

                entity.ID = Convert.ToInt64(reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.ID].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DetailsID].ToString());
                entity.DeviceID = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceID].ToString());
                entity.DeviceName = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceName] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceName].ToString();
                entity.DevicePower = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DevicePower] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DevicePower].ToString();
                entity.DeviceDocument = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceDocument] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.DeviceDocument].ToString();
                entity.NumberofUnits = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.NumberofUnits] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.NumberofUnits].ToString();
                entity.AddDate = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase2DetailsDevicesEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
