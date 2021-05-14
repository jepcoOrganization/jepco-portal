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
using System.Threading.Tasks;

namespace SiteWare.DataAccess.Repositories
{
    public static class RenewableEnergyUserRequestsDetailsSollarsRepository
    {
        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>> SelectByID(long ID)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID, ID));
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
        public static ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>> SelectAll()
        {
            ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsSollarsEntity> list = new List<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsSollarsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsSollarsEntity> list = new List<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsSollarsEntity entity = EntityHelper(reader, false);
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

        public static ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> GetAllByUserRequestsDetailsIDNotAsync(long ID)
        {
            ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_SelectByUserRequestsDetailsID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsSollarsEntity> list = new List<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.RenewableEnergyUserRequestsDetailsID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsSollarsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>> Insert(RenewableEnergyUserRequestsDetailsSollarsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID, entity.ID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.RenewableEnergyUserRequestsDetailsID, entity.RenewableEnergyUserRequestsDetailsID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellID, entity.SollarCellID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellName, entity.SollarCellName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellPower, entity.SollarCellPower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellDocument, entity.SollarCellDocument);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID].Value);

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
        public static ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> InsertNotAsync(RenewableEnergyUserRequestsDetailsSollarsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.RenewableEnergyUserRequestsDetailsID, entity.RenewableEnergyUserRequestsDetailsID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellID, entity.SollarCellID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellName, entity.SollarCellName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellPower, entity.SollarCellPower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.SollarCellDocument, entity.SollarCellDocument);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.EditUser, entity.EditUser);




                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetailsSollarsRepositoryConstants.ID].Value);

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
        static RenewableEnergyUserRequestsDetailsSollarsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyUserRequestsDetailsSollarsEntity entity = new RenewableEnergyUserRequestsDetailsSollarsEntity();

            try
            {

                entity.ID = Convert.ToInt64(reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.ID].ToString());
                entity.RenewableEnergyUserRequestsDetailsID = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.RenewableEnergyUserRequestsDetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.RenewableEnergyUserRequestsDetailsID].ToString());
                entity.SollarCellID = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellID].ToString());
                entity.SollarCellName = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellName] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellName].ToString();
                entity.SollarCellPower = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellPower] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellPower].ToString();
                entity.SollarCellDocument = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellDocument] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.SollarCellDocument].ToString();
                entity.NumberofUnits = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.NumberofUnits] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.NumberofUnits].ToString();
                entity.AddDate = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyUserRequestsDetailsSollarsEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
