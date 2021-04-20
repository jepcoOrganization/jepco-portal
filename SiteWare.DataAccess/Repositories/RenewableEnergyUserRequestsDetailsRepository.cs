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
    public static class RenewableEnergyUserRequestsDetailsRepository
    {

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsEntity>> SelectByID(long DetailsID)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsRepositoryConstants.DetailsID, DetailsID));
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
        public static ResultEntity<RenewableEnergyUserRequestsDetailsEntity> SelectByIDNotAsync(long DetailsID)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsDetailsRepositoryConstants.DetailsID, DetailsID));
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
        public async static Task<ResultList<RenewableEnergyUserRequestsDetailsEntity>> SelectAll()
        {
            ResultList<RenewableEnergyUserRequestsDetailsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsEntity> list = new List<RenewableEnergyUserRequestsDetailsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyUserRequestsDetailsEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsDetailsEntity> result = new ResultList<RenewableEnergyUserRequestsDetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsDetailsEntity> list = new List<RenewableEnergyUserRequestsDetailsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsDetailsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyUserRequestsDetailsEntity>> Insert(RenewableEnergyUserRequestsDetailsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.UserRequestID, entity.UserRequestID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EnergyType, entity.EnergyType);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EnergyTypeOther, entity.EnergyTypeOther);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.PowerType, entity.PowerType);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.CompanyUserID, entity.CompanyUserID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.ACPower, entity.ACPower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.DCPower, entity.DCPower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment1, entity.Attachment1);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment4, entity.Attachment4);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.IsAgree, entity.IsAgree);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetailsRepositoryConstants.DetailsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.DetailsID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetailsRepositoryConstants.DetailsID].Value);

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
        public static ResultEntity<RenewableEnergyUserRequestsDetailsEntity> InsertNotAsync(RenewableEnergyUserRequestsDetailsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsDetailsEntity> result = new ResultEntity<RenewableEnergyUserRequestsDetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsDetailsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.UserRequestID, entity.UserRequestID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EnergyType, entity.EnergyType);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EnergyTypeOther, entity.EnergyTypeOther);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.PowerType, entity.PowerType);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.CompanyUserID, entity.CompanyUserID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.ACPower, entity.ACPower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.DCPower, entity.DCPower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment1, entity.Attachment1);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Attachment4, entity.Attachment4);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.IsAgree, entity.IsAgree);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsDetailsRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsDetailsRepositoryConstants.DetailsID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.DetailsID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsDetailsRepositoryConstants.DetailsID].Value);

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                //result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Details = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        static RenewableEnergyUserRequestsDetailsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyUserRequestsDetailsEntity entity = new RenewableEnergyUserRequestsDetailsEntity();

            try
            {

                entity.DetailsID = Convert.ToInt64(reader[RenewableEnergyUserRequestsDetailsEntityConstants.DetailsID].ToString());
                entity.UserRequestID = reader[RenewableEnergyUserRequestsDetailsEntityConstants.UserRequestID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyUserRequestsDetailsEntityConstants.UserRequestID].ToString());
                entity.EnergyType = reader[RenewableEnergyUserRequestsDetailsEntityConstants.EnergyType] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsEntityConstants.EnergyType].ToString());
                entity.EnergyTypeOther = reader[RenewableEnergyUserRequestsDetailsEntityConstants.EnergyTypeOther] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.EnergyTypeOther].ToString();
                entity.PowerType = reader[RenewableEnergyUserRequestsDetailsEntityConstants.PowerType] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsEntityConstants.PowerType].ToString());
                entity.CompanyUserID = reader[RenewableEnergyUserRequestsDetailsEntityConstants.CompanyUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyUserRequestsDetailsEntityConstants.CompanyUserID].ToString());
                entity.ACPower = reader[RenewableEnergyUserRequestsDetailsEntityConstants.ACPower] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.ACPower].ToString();
                entity.DCPower = reader[RenewableEnergyUserRequestsDetailsEntityConstants.DCPower] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.DCPower].ToString();
                entity.Attachment1 = reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment1] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment1].ToString();
                entity.Attachment2 = reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment2] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment2].ToString();
                entity.Attachment3 = reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment3] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment3].ToString();
                entity.Attachment4 = reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment4] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.Attachment4].ToString();
                entity.IsAgree = reader[RenewableEnergyUserRequestsDetailsEntityConstants.IsAgree] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyUserRequestsDetailsEntityConstants.IsAgree].ToString());    
                entity.Order = reader[RenewableEnergyUserRequestsDetailsEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsEntityConstants.Order].ToString());
                entity.LanguageID = reader[RenewableEnergyUserRequestsDetailsEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsDetailsEntityConstants.LanguageID].ToString());
                entity.PublishDate = reader[RenewableEnergyUserRequestsDetailsEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[RenewableEnergyUserRequestsDetailsEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyUserRequestsDetailsEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[RenewableEnergyUserRequestsDetailsEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyUserRequestsDetailsEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[RenewableEnergyUserRequestsDetailsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyUserRequestsDetailsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsDetailsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyUserRequestsDetailsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyUserRequestsDetailsEntityConstants.EditUser].ToString();



                bool ColumnExists = false;
                try
                {
                    int columnOrdinal = reader.GetOrdinal("LanguageName");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.LanguageName = reader[RenewableEnergyUserRequestsDetailsEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsDetailsEntityConstants.LanguageName].ToString();
                }



            }
            catch (Exception ex)
            {

            }

            return entity;
        }



      
    }
}


    