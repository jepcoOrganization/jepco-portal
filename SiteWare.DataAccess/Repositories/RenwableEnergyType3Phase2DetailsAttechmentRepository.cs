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
    public static class RenwableEnergyType3Phase2DetailsAttechmentRepository
    {

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>> SelectByID(long ID)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID, ID));
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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsAttechmentEntity> list = new List<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsAttechmentEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsAttechmentEntity> list = new List<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsAttechmentEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>> Insert(RenwableEnergyType3Phase2DetailsAttechmentEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID, entity.ID);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.DetailsID, entity.DetailsID);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment1, entity.Attechment1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment2, entity.Attechment2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment3, entity.Attechment3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment4, entity.Attechment4);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment5, entity.Attechment5);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment6, entity.Attechment6);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment7, entity.Attechment7);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment8, entity.Attechment8);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment9, entity.Attechment9);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment10, entity.Attechment10);




                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID].Value);

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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> InsertNotAsync(RenwableEnergyType3Phase2DetailsAttechmentEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsAttechmentEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.DetailsID, entity.DetailsID);

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment1, entity.Attechment1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment2, entity.Attechment2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment3, entity.Attechment3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment4, entity.Attechment4);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment5, entity.Attechment5);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment6, entity.Attechment6);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment7, entity.Attechment7);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment8, entity.Attechment8);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment9, entity.Attechment9);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.Attechment10, entity.Attechment10);


                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.EditUser, entity.EditUser);




                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsAttechmentRepositoryConstants.ID].Value);

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
        static RenwableEnergyType3Phase2DetailsAttechmentEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase2DetailsAttechmentEntity entity = new RenwableEnergyType3Phase2DetailsAttechmentEntity();

            try
            {

                entity.ID = Convert.ToInt64(reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.ID].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.DetailsID].ToString());
                
                entity.Attechment1 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment1] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment1].ToString();
                entity.Attechment2 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment2] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment2].ToString();
                entity.Attechment3 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment3] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment3].ToString();
                entity.Attechment4 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment4] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment4].ToString();
                entity.Attechment5 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment5] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment5].ToString();
                entity.Attechment6 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment6] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment6].ToString();
                entity.Attechment7 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment7] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment7].ToString();
                entity.Attechment8 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment8] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment8].ToString();
                entity.Attechment9 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment9] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment9].ToString();
                entity.Attechment10 = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment10] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.Attechment10].ToString();
                

                entity.AddDate = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase2DetailsAttechmentEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
