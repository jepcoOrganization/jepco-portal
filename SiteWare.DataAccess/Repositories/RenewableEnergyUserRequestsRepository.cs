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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.Repositories
{
    public static class RenewableEnergyUserRequestsRepository
    {
        public async static Task<ResultEntity<RenewableEnergyUserRequestsEntity>> SelectByID(long RenwableEnergyID)
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, RenwableEnergyID));
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
        public static ResultEntity<RenewableEnergyUserRequestsEntity> SelectByIDNotAsync(long RenwableEnergyID)
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, RenwableEnergyID));
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
        public async static Task<ResultList<RenewableEnergyUserRequestsEntity>> SelectAll()
        {
            ResultList<RenewableEnergyUserRequestsEntity> result = new ResultList<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsEntity> list = new List<RenewableEnergyUserRequestsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyUserRequestsEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyUserRequestsEntity> result = new ResultList<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyUserRequestsEntity> list = new List<RenewableEnergyUserRequestsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyUserRequestsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyUserRequestsEntity>> Insert(RenewableEnergyUserRequestsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
              
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyTypeID, entity.RenwableEnergyTypeID);
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, entity.RenwableEnergyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.MeterStatus, entity.MeterStatus);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.ReferenceNumber, entity.ReferenceNumber);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.CompanyID, entity.CompanyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.CompanyAcceptedStatus, entity.CompanyAcceptedStatus);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusDate, entity.AcceptStatusDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusUser, entity.AcceptStatusUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt1, entity.Attachemnt1);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt2, entity.Attachemnt2);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt3, entity.Attachemnt3);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt4, entity.Attachemnt4);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RefeenceType, entity.RefeenceType);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt5, entity.Attachemnt5);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.GUID, entity.GUID);



                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.RenwableEnergyID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID].Value);

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
        public static ResultEntity<RenewableEnergyUserRequestsEntity> InsertNotAsync(RenewableEnergyUserRequestsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyTypeID, entity.RenwableEnergyTypeID);
               
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.MeterStatus, entity.MeterStatus);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.ReferenceNumber, entity.ReferenceNumber);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.CompanyID, entity.CompanyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.CompanyAcceptedStatus, entity.CompanyAcceptedStatus);
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusDate, entity.AcceptStatusDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusUser, entity.AcceptStatusUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt1, entity.Attachemnt1);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt2, entity.Attachemnt2);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt3, entity.Attachemnt3);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt4, entity.Attachemnt4);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RefeenceType, entity.RefeenceType);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.Attachemnt5, entity.Attachemnt5);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.GUID, entity.GUID);

                sqlCommand.Parameters.Add(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.RenwableEnergyID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID].Value);

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
        static RenewableEnergyUserRequestsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyUserRequestsEntity entity = new RenewableEnergyUserRequestsEntity();

            try
            {

                entity.RenwableEnergyID = Convert.ToInt64(reader[RenewableEnergyUserRequestsEntityConstants.RenwableEnergyID].ToString());
                entity.UserID = reader[RenewableEnergyUserRequestsEntityConstants.UserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyUserRequestsEntityConstants.UserID].ToString());
                //entity.RenwableEnergyTypeID = reader[RenewableEnergyUserRequestsEntityConstants.RenwableEnergyTypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsEntityConstants.RenwableEnergyTypeID].ToString());
                entity.RenwableEnergyTypeID = reader[RenewableEnergyUserRequestsEntityConstants.RenwableEnergyTypeID] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.RenwableEnergyTypeID].ToString();
                entity.MeterStatus = reader[RenewableEnergyUserRequestsEntityConstants.MeterStatus] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.MeterStatus].ToString();
                entity.ReferenceNumber = reader[RenewableEnergyUserRequestsEntityConstants.ReferenceNumber] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.ReferenceNumber].ToString();
                entity.CompanyID = reader[RenewableEnergyUserRequestsEntityConstants.CompanyID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyUserRequestsEntityConstants.CompanyID].ToString());
                entity.CompanyAcceptedStatus = reader[RenewableEnergyUserRequestsEntityConstants.CompanyAcceptedStatus] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyUserRequestsEntityConstants.CompanyAcceptedStatus].ToString());
                entity.AcceptStatusDate = reader[RenewableEnergyUserRequestsEntityConstants.AcceptStatusDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsEntityConstants.AcceptStatusDate].ToString());
                entity.AcceptStatusUser = reader[RenewableEnergyUserRequestsEntityConstants.AcceptStatusUser] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.AcceptStatusUser].ToString();

                entity.Attachemnt1 = reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt1] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt1].ToString();
                entity.Attachemnt2 = reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt2] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt2].ToString();
                entity.Attachemnt3 = reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt3] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt3].ToString();
                entity.Attachemnt4 = reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt4] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt4].ToString();

                entity.RefeenceType = reader[RenewableEnergyUserRequestsEntityConstants.RefeenceType] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.RefeenceType].ToString();

                entity.Order = reader[RenewableEnergyUserRequestsEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsEntityConstants.Order].ToString());
                entity.LanguageID = reader[RenewableEnergyUserRequestsEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyUserRequestsEntityConstants.LanguageID].ToString());
                entity.PublishDate = reader[RenewableEnergyUserRequestsEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[RenewableEnergyUserRequestsEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyUserRequestsEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[RenewableEnergyUserRequestsEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyUserRequestsEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[RenewableEnergyUserRequestsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyUserRequestsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyUserRequestsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyUserRequestsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyUserRequestsEntityConstants.EditUser].ToString();

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
                    entity.LanguageName = reader[RenewableEnergyUserRequestsEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.LanguageName].ToString();
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("Attachemnt5");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Attachemnt5 = reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt5] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.Attachemnt5].ToString();
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("GUID");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.GUID = reader[RenewableEnergyUserRequestsEntityConstants.GUID] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.GUID].ToString();
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("TokenNo");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.TokenNo = reader[RenewableEnergyUserRequestsEntityConstants.TokenNo] == DBNull.Value ? string.Empty : reader[RenewableEnergyUserRequestsEntityConstants.TokenNo].ToString();
                }


            }
            catch (Exception ex)
            {

            }

            return entity;
        }




        public async static Task<ResultEntity<RenewableEnergyUserRequestsEntity>> UpdateAfterCompanyRequest(RenewableEnergyUserRequestsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.Update_AfterCompanyRequest, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, entity.RenwableEnergyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.CompanyAcceptedStatus, entity.CompanyAcceptedStatus);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusDate, entity.AcceptStatusDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusUser, entity.AcceptStatusUser);


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
        public static ResultEntity<RenewableEnergyUserRequestsEntity> UpdateAfterCompanyRequestNotAsync(RenewableEnergyUserRequestsEntity entity)
        {

            ResultEntity<RenewableEnergyUserRequestsEntity> result = new ResultEntity<RenewableEnergyUserRequestsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyUserRequestsRepositoryConstants.Update_AfterCompanyRequest, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.RenwableEnergyID, entity.RenwableEnergyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.CompanyAcceptedStatus, entity.CompanyAcceptedStatus);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusDate, entity.AcceptStatusDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyUserRequestsRepositoryConstants.AcceptStatusUser, entity.AcceptStatusUser);

                sqlCommand.ExecuteNonQueryAsync();
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

    }
}


