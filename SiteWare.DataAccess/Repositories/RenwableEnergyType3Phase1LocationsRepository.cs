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
    public static class RenwableEnergyType3Phase1LocationsRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase1LocationsEntity>> SelectByID(long Type3Phase1LocationsID)
        {

            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1LocationsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID, Type3Phase1LocationsID));
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
        public static ResultEntity<RenwableEnergyType3Phase1LocationsEntity> SelectByIDNotAsync(long Type3Phase1LocationsID)
        {

            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1LocationsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID, Type3Phase1LocationsID));
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
        public async static Task<ResultList<RenwableEnergyType3Phase1LocationsEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase1LocationsEntity> result = new ResultList<RenwableEnergyType3Phase1LocationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1LocationsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1LocationsEntity> list = new List<RenwableEnergyType3Phase1LocationsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1LocationsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase1LocationsEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1LocationsEntity> result = new ResultList<RenwableEnergyType3Phase1LocationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1LocationsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1LocationsEntity> list = new List<RenwableEnergyType3Phase1LocationsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1LocationsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase1LocationsEntity>> Insert(RenwableEnergyType3Phase1LocationsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1LocationsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID, entity.Type3Phase1LocationsID);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.LocationName, entity.LocationName);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Area1, entity.Area1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Area3, entity.Area3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.AreaNumber, entity.AreaNumber);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Attachment1, entity.Attachment1);

                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Type3Phase1LocationsID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase1LocationsEntity> InsertNotAsync(RenwableEnergyType3Phase1LocationsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1LocationsEntity> result = new ResultEntity<RenwableEnergyType3Phase1LocationsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1LocationsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.LocationName, entity.LocationName);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Area1, entity.Area1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Area3, entity.Area3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.AreaNumber, entity.AreaNumber);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1LocationsRepositoryConstants.Attachment1, entity.Attachment1);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.Type3Phase1LocationsID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1LocationsRepositoryConstants.Type3Phase1LocationsID].Value);

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
        static RenwableEnergyType3Phase1LocationsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase1LocationsEntity entity = new RenwableEnergyType3Phase1LocationsEntity();

            try
            {

                entity.Type3Phase1LocationsID = Convert.ToInt64(reader[RenwableEnergyType3Phase1LocationsEntityConstants.Type3Phase1LocationsID].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase1LocationsEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase1LocationsEntityConstants.DetailsID].ToString());
                entity.LocationName = reader[RenwableEnergyType3Phase1LocationsEntityConstants.LocationName] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.LocationName].ToString();
                entity.Governate = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Governate] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Governate].ToString();
                entity.Area1 = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Area1] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Area1].ToString();
                entity.Area2 = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Area2] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Area2].ToString();
                entity.Area3 = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Area3] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Area3].ToString();
                entity.AreaNumber = reader[RenwableEnergyType3Phase1LocationsEntityConstants.AreaNumber] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.AreaNumber].ToString();
                entity.Longitude = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Longitude] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Longitude].ToString();
                entity.Latitude = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Latitude] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Latitude].ToString();
                entity.AddDate = reader[RenwableEnergyType3Phase1LocationsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1LocationsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase1LocationsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1LocationsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase1LocationsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase1LocationsEntityConstants.EditUser].ToString();

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
                    entity.Attachment1 = reader[RenwableEnergyType3Phase1LocationsEntityConstants.Attachment1] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1LocationsEntityConstants.Attachment1].ToString();
                }
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}


                   
