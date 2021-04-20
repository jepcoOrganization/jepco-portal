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
    public static class RenwableEnergyType3Phase2DetailsSollarsRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>> SelectByID(long ID)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID, ID));
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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsSollarsEntity> list = new List<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsSollarsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsSollarsEntity> list = new List<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsSollarsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>> Insert(RenwableEnergyType3Phase2DetailsSollarsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID, entity.ID);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellID, entity.SollarCellID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellName, entity.SollarCellName);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellPower, entity.SollarCellPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellDocument, entity.SollarCellDocument);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> InsertNotAsync(RenwableEnergyType3Phase2DetailsSollarsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsSollarsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellID, entity.SollarCellID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellName, entity.SollarCellName);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellPower, entity.SollarCellPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.SollarCellDocument, entity.SollarCellDocument);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.NumberofUnits, entity.NumberofUnits);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.EditUser, entity.EditUser);




                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsSollarsRepositoryConstants.ID].Value);

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
        static RenwableEnergyType3Phase2DetailsSollarsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase2DetailsSollarsEntity entity = new RenwableEnergyType3Phase2DetailsSollarsEntity();

            try
            {

                entity.ID = Convert.ToInt64(reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.ID].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.DetailsID].ToString());
                entity.SollarCellID = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellID].ToString());
                entity.SollarCellName = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellName] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellName].ToString();
                entity.SollarCellPower = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellPower] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellPower].ToString();
                entity.SollarCellDocument = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellDocument] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.SollarCellDocument].ToString();
                entity.NumberofUnits = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.NumberofUnits] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.NumberofUnits].ToString();
                entity.AddDate = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase2DetailsSollarsEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
