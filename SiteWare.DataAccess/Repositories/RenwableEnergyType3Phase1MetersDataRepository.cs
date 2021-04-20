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
    public static class RenwableEnergyType3Phase1MetersDataRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>> SelectByID(long Type3Phase1MetersData)
        {

            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1MetersDataRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData, Type3Phase1MetersData));
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
        public static ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> SelectByIDNotAsync(long Type3Phase1MetersData)
        {

            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1MetersDataRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData, Type3Phase1MetersData));
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
        public async static Task<ResultList<RenwableEnergyType3Phase1MetersDataEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultList<RenwableEnergyType3Phase1MetersDataEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1MetersDataRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1MetersDataEntity> list = new List<RenwableEnergyType3Phase1MetersDataEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1MetersDataEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase1MetersDataEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultList<RenwableEnergyType3Phase1MetersDataEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1MetersDataRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1MetersDataEntity> list = new List<RenwableEnergyType3Phase1MetersDataEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1MetersDataEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>> Insert(RenwableEnergyType3Phase1MetersDataEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1MetersDataRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData, entity.Type3Phase1MetersData);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.NumberofConnection, entity.NumberofConnection);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.MeterNumber, entity.MeterNumber);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.FileNumber, entity.FileNumber);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.MeterAddress, entity.MeterAddress);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Attachment1, entity.Attachment1);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Type3Phase1MetersData = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> InsertNotAsync(RenwableEnergyType3Phase1MetersDataEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1MetersDataEntity> result = new ResultEntity<RenwableEnergyType3Phase1MetersDataEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1MetersDataRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.NumberofConnection, entity.NumberofConnection);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.MeterNumber, entity.MeterNumber);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.FileNumber, entity.FileNumber);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.MeterAddress, entity.MeterAddress);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Attachment1, entity.Attachment1);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.Type3Phase1MetersData = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1MetersDataRepositoryConstants.Type3Phase1MetersData].Value);

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
        static RenwableEnergyType3Phase1MetersDataEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase1MetersDataEntity entity = new RenwableEnergyType3Phase1MetersDataEntity();

            try
            {
                entity.Type3Phase1MetersData = Convert.ToInt64(reader[RenwableEnergyType3Phase1MetersDataEntityConstants.Type3Phase1MetersData].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase1MetersDataEntityConstants.DetailsID].ToString());               
                entity.NumberofConnection = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.NumberofConnection] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1MetersDataEntityConstants.NumberofConnection].ToString();
                entity.Name = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.Name] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1MetersDataEntityConstants.Name].ToString();
                entity.MeterNumber = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.MeterNumber] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1MetersDataEntityConstants.MeterNumber].ToString();
                entity.FileNumber = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.FileNumber] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1MetersDataEntityConstants.FileNumber].ToString();
                entity.MeterAddress = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.MeterAddress] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1MetersDataEntityConstants.MeterAddress].ToString();
                entity.AddDate = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1MetersDataEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1MetersDataEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.EditUser].ToString();

                bool ColumnExists = false;
                try
                {
                    int columnOrdinal = reader.GetOrdinal("Attachment1");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Attachment1 = reader[RenwableEnergyType3Phase1MetersDataEntityConstants.Attachment1] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1MetersDataEntityConstants.Attachment1].ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}

 