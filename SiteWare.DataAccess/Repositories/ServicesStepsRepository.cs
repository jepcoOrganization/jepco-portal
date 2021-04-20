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
    public static class ServicesStepsRepository
    {
        public async static Task<ResultEntity<ServicesStepsEntity>> SelectByID(long StepID)
        {

            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ServicesStepsRepositoryConstants.StepID, StepID));
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
        public static ResultEntity<ServicesStepsEntity> SelectByIDNotAsync(long StepID)
        {

            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ServicesStepsRepositoryConstants.StepID, StepID));
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
        public async static Task<ResultList<ServicesStepsEntity>> SelectAll()
        {
            ResultList<ServicesStepsEntity> result = new ResultList<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<ServicesStepsEntity> list = new List<ServicesStepsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    ServicesStepsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<ServicesStepsEntity> SelectAllNotAsync()
        {
            ResultList<ServicesStepsEntity> result = new ResultList<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<ServicesStepsEntity> list = new List<ServicesStepsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    ServicesStepsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<ServicesStepsEntity>> Insert(ServicesStepsEntity entity)
        {

            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.StepID, entity.StepID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.ServiceID, entity.ServiceID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.StepNumber, entity.StepNumber);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.FromUser, entity.FromUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.ToUser, entity.ToUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.SendSMS, entity.SendSMS);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.SMSContent, entity.SMSContent);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.SendMail, entity.SendMail);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.MailContent, entity.MailContent);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed1, entity.Filed1);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed2, entity.Filed2);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed3, entity.Filed3);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed4, entity.Filed4);
               



                sqlCommand.Parameters.Add(ServicesStepsRepositoryConstants.StepID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.StepID = Convert.ToInt64(sqlCommand.Parameters[ServicesStepsRepositoryConstants.StepID].Value);

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
        public static ResultEntity<ServicesStepsEntity> InsertNotAsync(ServicesStepsEntity entity)
        {

            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.StepID, entity.StepID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.ServiceID, entity.ServiceID);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.StepNumber, entity.StepNumber);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.FromUser, entity.FromUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.ToUser, entity.ToUser);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.SendSMS, entity.SendSMS);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.SMSContent, entity.SMSContent);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.SendMail, entity.SendMail);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.MailContent, entity.MailContent);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed1, entity.Filed1);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed2, entity.Filed2);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed3, entity.Filed3);
                sqlCommand.Parameters.AddWithValue(ServicesStepsRepositoryConstants.Filed4, entity.Filed4);


                sqlCommand.Parameters.Add(ServicesStepsRepositoryConstants.StepID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.StepID = Convert.ToInt64(sqlCommand.Parameters[ServicesStepsRepositoryConstants.StepID].Value);

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
        static ServicesStepsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            ServicesStepsEntity entity = new ServicesStepsEntity();

            try
            {

                entity.StepID = Convert.ToInt64(reader[ServicesStepsEntityConstants.StepID].ToString());
                entity.ServiceID = reader[ServicesStepsEntityConstants.ServiceID] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.ServiceID].ToString();
                entity.StepNumber = reader[ServicesStepsEntityConstants.StepNumber] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.StepNumber].ToString();
                entity.FromUser = reader[ServicesStepsEntityConstants.FromUser] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.FromUser].ToString();
                entity.ToUser = reader[ServicesStepsEntityConstants.ToUser] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.ToUser].ToString();
                entity.StepName = reader[ServicesStepsEntityConstants.StepName] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.StepName].ToString();
                entity.SendSMS = reader[ServicesStepsEntityConstants.SendSMS] == DBNull.Value ? false : Convert.ToBoolean(reader[ServicesStepsEntityConstants.SendSMS].ToString());
                entity.SMSContent = reader[ServicesStepsEntityConstants.SMSContent] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.SMSContent].ToString();

                
                entity.SendMail = reader[ServicesStepsEntityConstants.SendMail] == DBNull.Value ? false : Convert.ToBoolean(reader[ServicesStepsEntityConstants.SendMail].ToString());
                entity.MailContent = reader[ServicesStepsEntityConstants.MailContent] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.MailContent].ToString();


                entity.Filed1 = reader[ServicesStepsEntityConstants.Filed1] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.Filed1].ToString();
                entity.Filed2 = reader[ServicesStepsEntityConstants.Filed2] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.Filed2].ToString();
                entity.Filed3 = reader[ServicesStepsEntityConstants.Filed3] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.Filed3].ToString();
                entity.Filed4 = reader[ServicesStepsEntityConstants.Filed4] == DBNull.Value ? string.Empty : reader[ServicesStepsEntityConstants.Filed4].ToString();

                bool ColumnExists = false;
               
            }
            catch (Exception ex)
            {

            }

            return entity;
        }

        public async static Task<ResultEntity<ServicesStepsEntity>> SelectByServiceID(string ServiceID)
        {

            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_SelectByServiceID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ServicesStepsRepositoryConstants.ServiceID, ServiceID));
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
        public static ResultEntity<ServicesStepsEntity> SelectByServiceIDNotAsync(string ServiceID)
        {

            ResultEntity<ServicesStepsEntity> result = new ResultEntity<ServicesStepsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ServicesStepsRepositoryConstants.SP_SelectByServiceID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ServicesStepsRepositoryConstants.ServiceID, ServiceID));
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
    }
}

        
