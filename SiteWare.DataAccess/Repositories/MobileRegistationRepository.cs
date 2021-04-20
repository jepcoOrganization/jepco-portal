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
    public static class MobileRegistationRepository
    {

        public async static Task<ResultEntity<MobileRegistationEntity>> SelectByServiceUserID(long ServiceUserID)
        {

            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.SelectByServiceUserID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(MobileRegistationRepositoryConstants.ServiceUserID, ServiceUserID));
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

        public static ResultEntity<MobileRegistationEntity> SelectByServiceUserIDNotAsync(long ServiceUserID)
        {

            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.SelectByServiceUserID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(MobileRegistationRepositoryConstants.ServiceUserID, ServiceUserID));
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

        public async static Task<ResultEntity<MobileRegistationEntity>> Update(MobileRegistationEntity entity)
        {

            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.RegistationID, entity.RegistationID);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.OTP, entity.OTP);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.IsVerify, entity.IsVerify);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.VerifyDate, entity.VerifyDate);


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

        public static ResultEntity<MobileRegistationEntity> UpdateNotAsync(MobileRegistationEntity entity)
        {

            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.RegistationID, entity.RegistationID);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.OTP, entity.OTP);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.IsVerify, entity.IsVerify);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.VerifyDate, entity.VerifyDate);

                sqlCommand.ExecuteNonQuery();
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


        public async static Task<ResultEntity<MobileRegistationEntity>> Insert(MobileRegistationEntity entity)
        {

            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.OTP, entity.OTP);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.IsVerify, entity.IsVerify);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.VerifyDate, entity.VerifyDate);

                sqlCommand.Parameters.Add(MobileRegistationRepositoryConstants.RegistationID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;

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

        public static ResultEntity<MobileRegistationEntity> InsertNotAsync(MobileRegistationEntity entity)
        {

            ResultEntity<MobileRegistationEntity> result = new ResultEntity<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.OTP, entity.OTP);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.IsVerify, entity.IsVerify);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MobileRegistationRepositoryConstants.VerifyDate, entity.VerifyDate);

                sqlCommand.Parameters.Add(MobileRegistationRepositoryConstants.RegistationID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;

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



        public async static Task<ResultList<MobileRegistationEntity>> SelectAll()
        {
            ResultList<MobileRegistationEntity> result = new ResultList<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MobileRegistationEntity> list = new List<MobileRegistationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    MobileRegistationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<MobileRegistationEntity> SelectAllNotAsync()
        {
            ResultList<MobileRegistationEntity> result = new ResultList<MobileRegistationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MobileRegistationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MobileRegistationEntity> list = new List<MobileRegistationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    MobileRegistationEntity entity = EntityHelper(reader, false);
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

        
        static MobileRegistationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            MobileRegistationEntity entity = new MobileRegistationEntity();

            entity.RegistationID = Convert.ToInt64(reader[MobileRegistationEntityConstants.RegistationID].ToString());
            entity.ServiceUserID = reader[MobileRegistationEntityConstants.ServiceUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[MobileRegistationEntityConstants.ServiceUserID]);
            entity.MobileNumber = reader[MobileRegistationEntityConstants.MobileNumber] == DBNull.Value ? string.Empty : Convert.ToString(reader[MobileRegistationEntityConstants.MobileNumber]);
            entity.OTP = reader[MobileRegistationEntityConstants.OTP] == DBNull.Value ? string.Empty : Convert.ToString(reader[MobileRegistationEntityConstants.OTP]);
            entity.IsVerify = Convert.ToBoolean(reader[MobileRegistationEntityConstants.IsVerify].ToString());



            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("AddDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.AddDate = reader[MobileRegistationEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[MobileRegistationEntityConstants.AddDate].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("VerifyDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.VerifyDate = reader[MobileRegistationEntityConstants.VerifyDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[MobileRegistationEntityConstants.VerifyDate].ToString());
            }
            return entity;
        }


    }
}
