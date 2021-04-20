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
   public class Plugin_UserComplainRepository
    {
        public async static Task<ResultEntity<Plugin_UserComplainEntity>> SelectByID(long ComplainID)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_UserComplainRepositoryConstants.ComplainID, ComplainID));
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
        public static ResultEntity<Plugin_UserComplainEntity> SelectByIDNotAsync(long ComplainID)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_UserComplainRepositoryConstants.ComplainID, ComplainID));
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

        public async static Task<ResultList<Plugin_UserComplainEntity>> SelectAll()
        {
            ResultList<Plugin_UserComplainEntity> result = new ResultList<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_UserComplainEntity> list = new List<Plugin_UserComplainEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_UserComplainEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_UserComplainEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_UserComplainEntity> result = new ResultList<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_UserComplainEntity> list = new List<Plugin_UserComplainEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_UserComplainEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_UserComplainEntity>> Update(Plugin_UserComplainEntity entity)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainID, entity.ComplainID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainTitle, entity.ComplainTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainDetails, entity.ComplainDetails);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainType, entity.ComplainType);


                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentNumber, entity.DocumentNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Nationality, entity.Nationality);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MobileNo, entity.MobileNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MeterNumber, entity.MeterNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetName, entity.StreetName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Longitude, entity.Longitude);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueStatus, entity.IssueStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueResultNo, entity.IssueResultNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageIDAPI, entity.LanguageIDAPI);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ServiceUserID, entity.ServiceUserID);

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
        public static ResultEntity<Plugin_UserComplainEntity> UpdateNotAsync(Plugin_UserComplainEntity entity)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainID, entity.ComplainID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainTitle, entity.ComplainTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainDetails, entity.ComplainDetails);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainType, entity.ComplainType);


                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentNumber, entity.DocumentNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Nationality, entity.Nationality);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MobileNo, entity.MobileNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MeterNumber, entity.MeterNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetName, entity.StreetName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Longitude, entity.Longitude);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueStatus, entity.IssueStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueResultNo, entity.IssueResultNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageIDAPI, entity.LanguageIDAPI);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ServiceUserID, entity.ServiceUserID);

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

        public async static Task<ResultEntity<Plugin_UserComplainEntity>> Delete(long ComplainID)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainID, ComplainID);

                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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

        public async static Task<ResultEntity<Plugin_UserComplainEntity>> Insert(Plugin_UserComplainEntity entity)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();


                
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainTitle, entity.ComplainTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainDetails, entity.ComplainDetails);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainType, entity.ComplainType);


                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentNumber, entity.DocumentNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Nationality, entity.Nationality);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MobileNo, entity.MobileNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MeterNumber, entity.MeterNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetName, entity.StreetName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Longitude, entity.Longitude);



                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueStatus, entity.IssueStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueResultNo, entity.IssueResultNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageIDAPI, entity.LanguageIDAPI);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                

                sqlCommand.Parameters.Add(Plugin_UserComplainRepositoryConstants.ComplainID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ComplainID = Convert.ToInt64(sqlCommand.Parameters[Plugin_UserComplainRepositoryConstants.ComplainID].Value);

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
        public static ResultEntity<Plugin_UserComplainEntity> InsertNotAsync(Plugin_UserComplainEntity entity)
        {

            ResultEntity<Plugin_UserComplainEntity> result = new ResultEntity<Plugin_UserComplainEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_UserComplainRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainTitle, entity.ComplainTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainDetails, entity.ComplainDetails);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ComplainType, entity.ComplainType);


                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.DocumentNumber, entity.DocumentNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Nationality, entity.Nationality);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MobileNo, entity.MobileNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.MeterNumber, entity.MeterNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetName, entity.StreetName);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Longitude, entity.Longitude);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueStatus, entity.IssueStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.IssueResultNo, entity.IssueResultNo);
                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.LanguageIDAPI, entity.LanguageIDAPI);

                sqlCommand.Parameters.AddWithValue(Plugin_UserComplainRepositoryConstants.ServiceUserID, entity.ServiceUserID);

                sqlCommand.Parameters.Add(Plugin_UserComplainRepositoryConstants.ComplainID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ComplainID = Convert.ToInt64(sqlCommand.Parameters[Plugin_UserComplainRepositoryConstants.ComplainID].Value);

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



        static Plugin_UserComplainEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_UserComplainEntity entity = new Plugin_UserComplainEntity();


            entity.ComplainID = Convert.ToInt64(reader[Plugin_UserComplainEntityConstants.ComplainID].ToString());

            entity.ComplainTitle = reader[Plugin_UserComplainEntityConstants.ComplainTitle] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.ComplainTitle].ToString());
            entity.ComplainDetails = reader[Plugin_UserComplainEntityConstants.ComplainDetails] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.ComplainDetails].ToString());
            entity.ComplainType = reader[Plugin_UserComplainEntityConstants.ComplainType] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.ComplainType].ToString());


            entity.FirstName = reader[Plugin_UserComplainEntityConstants.FirstName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.FirstName].ToString());
            entity.SecondName = reader[Plugin_UserComplainEntityConstants.SecondName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.SecondName].ToString());
            entity.ThirdName = reader[Plugin_UserComplainEntityConstants.ThirdName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.ThirdName].ToString());
            entity.FamilyName = reader[Plugin_UserComplainEntityConstants.FamilyName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.FamilyName].ToString());
            entity.Email = reader[Plugin_UserComplainEntityConstants.Email] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.Email].ToString());



            entity.DocumentType = reader[Plugin_UserComplainEntityConstants.DocumentType] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.DocumentType].ToString());
            entity.DocumentNumber = reader[Plugin_UserComplainEntityConstants.DocumentNumber] == DBNull.Value ? string.Empty : reader[Plugin_UserComplainEntityConstants.DocumentNumber].ToString();
            entity.Nationality = reader[Plugin_UserComplainEntityConstants.Nationality] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_UserComplainEntityConstants.Nationality].ToString());
            entity.MobileNo = reader[Plugin_UserComplainEntityConstants.MobileNo] == DBNull.Value ? string.Empty : reader[Plugin_UserComplainEntityConstants.MobileNo].ToString();
            entity.MeterNumber = reader[Plugin_UserComplainEntityConstants.MeterNumber] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.MeterNumber].ToString());
            entity.Governate = reader[Plugin_UserComplainEntityConstants.Governate] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_UserComplainEntityConstants.Governate].ToString());
            entity.Area = reader[Plugin_UserComplainEntityConstants.Area] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.Area].ToString());
            entity.StreetName = reader[Plugin_UserComplainEntityConstants.StreetName] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.StreetName].ToString());
            entity.Latitude = reader[Plugin_UserComplainEntityConstants.Latitude] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.Latitude].ToString());
            entity.Longitude = reader[Plugin_UserComplainEntityConstants.Longitude] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.Longitude].ToString());
            

            entity.Order = reader[Plugin_UserComplainEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_UserComplainEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.LanguageID].ToString());
            entity.PublishedDate = reader[Plugin_UserComplainEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_UserComplainEntityConstants.PublishedDate].ToString());
            entity.IsPublished = reader[Plugin_UserComplainEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_UserComplainEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_UserComplainEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_UserComplainEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_UserComplainEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_UserComplainEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_UserComplainEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_UserComplainEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_UserComplainEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_UserComplainEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_UserComplainEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_UserComplainEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_UserComplainEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_UserComplainEntityConstants.LanguageName].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("Area2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Area2 = reader[Plugin_UserComplainEntityConstants.Area2] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.Area2].ToString());
                
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("StreetID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.StreetID = reader[Plugin_UserComplainEntityConstants.StreetID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.StreetID].ToString());

            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("IssueStatus");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IssueStatus = reader[Plugin_UserComplainEntityConstants.IssueStatus] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_UserComplainEntityConstants.IssueStatus].ToString());
             
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("IssueResultNo");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IssueResultNo = reader[Plugin_UserComplainEntityConstants.IssueResultNo] == DBNull.Value ? string.Empty : Convert.ToString(reader[Plugin_UserComplainEntityConstants.IssueResultNo].ToString());
               
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("LanguageIDAPI");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                
                entity.LanguageIDAPI = reader[Plugin_UserComplainEntityConstants.LanguageIDAPI] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_UserComplainEntityConstants.LanguageIDAPI].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ServiceUserID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {

                entity.ServiceUserID = reader[Plugin_UserComplainEntityConstants.ServiceUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_UserComplainEntityConstants.ServiceUserID].ToString());
            }

            return entity;
        }

    }
}
