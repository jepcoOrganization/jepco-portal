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
    public static class RenwableEnergyType3Phase1DetailsRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase1DetailsEntity>> SelectByID(long Type3Phase1DetailsID)
        {

            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, Type3Phase1DetailsID));
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
        public static ResultEntity<RenwableEnergyType3Phase1DetailsEntity> SelectByIDNotAsync(long Type3Phase1DetailsID)
        {

            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, Type3Phase1DetailsID));
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
        public async static Task<ResultList<RenwableEnergyType3Phase1DetailsEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase1DetailsEntity> result = new ResultList<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1DetailsEntity> list = new List<RenwableEnergyType3Phase1DetailsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1DetailsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase1DetailsEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1DetailsEntity> result = new ResultList<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1DetailsEntity> list = new List<RenwableEnergyType3Phase1DetailsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1DetailsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase1DetailsEntity>> Insert(RenwableEnergyType3Phase1DetailsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, entity.Type3Phase1DetailsID);
                
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.DetailsID, entity.DetailsID);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.ApprovedDate, entity.ApprovedDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.TotalPower, entity.TotalPower);                
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Type3Phase1DetailsID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase1DetailsEntity> InsertNotAsync(RenwableEnergyType3Phase1DetailsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.DetailsID, entity.DetailsID);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.ApprovedDate, entity.ApprovedDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.TotalPower, entity.TotalPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.Type3Phase1DetailsID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID].Value);

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
        static RenwableEnergyType3Phase1DetailsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase1DetailsEntity entity = new RenwableEnergyType3Phase1DetailsEntity();

            try
            {
                entity.Type3Phase1DetailsID = Convert.ToInt64(reader[RenwableEnergyType3Phase1DetailsEntityConstants.Type3Phase1DetailsID].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase1DetailsEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase1DetailsEntityConstants.DetailsID].ToString());                
                entity.ApprovedDate = reader[RenwableEnergyType3Phase1DetailsEntityConstants.ApprovedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1DetailsEntityConstants.ApprovedDate].ToString());
                entity.IsApproved = reader[RenwableEnergyType3Phase1DetailsEntityConstants.IsApproved] == DBNull.Value ? false : Convert.ToBoolean(reader[RenwableEnergyType3Phase1DetailsEntityConstants.IsApproved].ToString());
                entity.TotalPower = reader[RenwableEnergyType3Phase1DetailsEntityConstants.TotalPower] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1DetailsEntityConstants.TotalPower].ToString();
                entity.AddDate = reader[RenwableEnergyType3Phase1DetailsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1DetailsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase1DetailsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1DetailsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase1DetailsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase1DetailsEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }

        public async static Task<ResultEntity<RenwableEnergyType3Phase1DetailsEntity>> UpdateIsAccepted(RenwableEnergyType3Phase1DetailsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_UpadateIsAcceted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, entity.Type3Phase1DetailsID);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.ApprovedDate, entity.ApprovedDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.IsApproved, entity.IsApproved);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.TotalPower, entity.TotalPower);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddDate, entity.AddDate);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddUser, entity.AddUser);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditDate, entity.EditDate);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditUser, entity.EditUser);


                //sqlCommand.Parameters.Add(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Type3Phase1DetailsID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase1DetailsEntity> UpdateIsAcceptedWithOutAsny(RenwableEnergyType3Phase1DetailsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase1DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1DetailsRepositoryConstants.SP_UpadateIsAcceted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, entity.Type3Phase1DetailsID);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.ApprovedDate, entity.ApprovedDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.IsApproved, entity.IsApproved);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.TotalPower, entity.TotalPower);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddDate, entity.AddDate);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.AddUser, entity.AddUser);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditDate, entity.EditDate);
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1DetailsRepositoryConstants.EditUser, entity.EditUser);


                //sqlCommand.Parameters.Add(RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.Type3Phase1DetailsID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1DetailsRepositoryConstants.Type3Phase1DetailsID].Value);

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

    }
}
