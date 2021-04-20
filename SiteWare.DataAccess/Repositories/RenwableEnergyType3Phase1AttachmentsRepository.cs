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
    public static class RenwableEnergyType3Phase1AttachmentsRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>> SelectByID(long Type3Phase1Attachments)
        {

            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments, Type3Phase1Attachments));
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
        public static ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> SelectByIDNotAsync(long Type3Phase1Attachments)
        {

            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments, Type3Phase1Attachments));
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
        public async static Task<ResultList<RenwableEnergyType3Phase1AttachmentsEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultList<RenwableEnergyType3Phase1AttachmentsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1AttachmentsEntity> list = new List<RenwableEnergyType3Phase1AttachmentsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1AttachmentsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase1AttachmentsEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultList<RenwableEnergyType3Phase1AttachmentsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase1AttachmentsEntity> list = new List<RenwableEnergyType3Phase1AttachmentsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase1AttachmentsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>> Insert(RenwableEnergyType3Phase1AttachmentsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments, entity.Type3Phase1Attachments);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments1, entity.Attachments1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments2, entity.Attachments2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments3, entity.Attachments3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments4, entity.Attachments4);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments5, entity.Attachments5);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments6, entity.Attachments6);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments7, entity.Attachments7);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments8, entity.Attachments8);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments9, entity.Attachments9);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments10, entity.Attachments10);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Type3Phase1Attachments = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> InsertNotAsync(RenwableEnergyType3Phase1AttachmentsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity> result = new ResultEntity<RenwableEnergyType3Phase1AttachmentsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments1, entity.Attachments1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments2, entity.Attachments2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments3, entity.Attachments3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments4, entity.Attachments4);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments5, entity.Attachments5);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments6, entity.Attachments6);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments7, entity.Attachments7);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments8, entity.Attachments8);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments9, entity.Attachments9);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Attachments10, entity.Attachments10);                
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.Type3Phase1Attachments = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase1AttachmentsRepositoryConstants.Type3Phase1Attachments].Value);

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
        static RenwableEnergyType3Phase1AttachmentsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase1AttachmentsEntity entity = new RenwableEnergyType3Phase1AttachmentsEntity();

            try
            {
                entity.Type3Phase1Attachments = Convert.ToInt64(reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Type3Phase1Attachments].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.DetailsID].ToString());
                entity.Attachments1 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments1] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments1].ToString();
                entity.Attachments2 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments2] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments2].ToString();
                entity.Attachments3 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments3] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments3].ToString();
                entity.Attachments4 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments4] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments4].ToString();
                entity.Attachments5 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments5] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments5].ToString();
                entity.Attachments6 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments6] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments6].ToString();
                entity.Attachments7 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments7] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments7].ToString();
                entity.Attachments8 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments8] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments8].ToString();
                entity.Attachments9 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments9] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments9].ToString();
                entity.Attachments10 = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments10] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.Attachments10].ToString();
                entity.AddDate = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase1AttachmentsEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}

 

