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
   public class Plugin_ServiceUserRepository
    {
        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceUserRepositoryConstants.ID, ID));
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
        public static ResultEntity<Plugin_ServiceUserEntity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceUserRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<Plugin_ServiceUserEntity>> SelectAll()
        {
            ResultList<Plugin_ServiceUserEntity> result = new ResultList<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ServiceUserEntity> list = new List<Plugin_ServiceUserEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ServiceUserEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_ServiceUserEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_ServiceUserEntity> result = new ResultList<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ServiceUserEntity> list = new List<Plugin_ServiceUserEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ServiceUserEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> Update(Plugin_ServiceUserEntity entity)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDType, entity.IDType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDNumber, entity.IDNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Country, entity.Country);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.City, entity.City);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area1, entity.Area1);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Latitude, entity.Latitude);


                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.NationalityID, entity.NationalityID);
                


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
        public static ResultEntity<Plugin_ServiceUserEntity> UpdateNotAsync(Plugin_ServiceUserEntity entity)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDType, entity.IDType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDNumber, entity.IDNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Country, entity.Country);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.City, entity.City);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area1, entity.Area1);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Latitude, entity.Latitude);


                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.NationalityID, entity.NationalityID);

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
        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> Delete(long ID)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ID, ID);

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
        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> Insert(Plugin_ServiceUserEntity entity)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDType, entity.IDType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDNumber, entity.IDNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Country, entity.Country);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.City, entity.City);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area1, entity.Area1);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Latitude, entity.Latitude);


                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.NationalityID, entity.NationalityID);

                sqlCommand.Parameters.Add(Plugin_ServiceUserRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_ServiceUserRepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_ServiceUserEntity> InsertNotAsync(Plugin_ServiceUserEntity entity)
        {

            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDType, entity.IDType);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IDNumber, entity.IDNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Country, entity.Country);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.City, entity.City);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area1, entity.Area1);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Latitude, entity.Latitude);


                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceUserRepositoryConstants.NationalityID, entity.NationalityID);
                sqlCommand.Parameters.Add(Plugin_ServiceUserRepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_ServiceUserRepositoryConstants.ID].Value);

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

        static Plugin_ServiceUserEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ServiceUserEntity entity = new Plugin_ServiceUserEntity();


            entity.ID = Convert.ToInt64(reader[Plugin_ServiceUserEntityConstants.ID].ToString());
            entity.FirstName = reader[Plugin_ServiceUserEntityConstants.FirstName] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.FirstName].ToString();
            entity.SecondName = reader[Plugin_ServiceUserEntityConstants.SecondName] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.SecondName].ToString();
            entity.ThirdName = reader[Plugin_ServiceUserEntityConstants.ThirdName] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.ThirdName].ToString();
            entity.FamilyName = reader[Plugin_ServiceUserEntityConstants.FamilyName] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.FamilyName].ToString();
            entity.UserID = reader[Plugin_ServiceUserEntityConstants.UserID] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.UserID].ToString();
            entity.UserType = reader[Plugin_ServiceUserEntityConstants.UserType] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.UserType].ToString();
            entity.IDType = reader[Plugin_ServiceUserEntityConstants.IDType] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.IDType].ToString());
            entity.IDNumber = reader[Plugin_ServiceUserEntityConstants.IDNumber] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.IDNumber].ToString();
            entity.MobileNumber = reader[Plugin_ServiceUserEntityConstants.MobileNumber] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.MobileNumber].ToString();
            entity.TelephoneNumber = reader[Plugin_ServiceUserEntityConstants.TelephoneNumber] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.TelephoneNumber].ToString();
            entity.Email = reader[Plugin_ServiceUserEntityConstants.Email] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.Email].ToString();
            entity.Password = reader[Plugin_ServiceUserEntityConstants.Password] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.Password].ToString();
            entity.Country = reader[Plugin_ServiceUserEntityConstants.Country] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.Country].ToString());
            entity.City = reader[Plugin_ServiceUserEntityConstants.City] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.City].ToString());
            entity.Area1 = reader[Plugin_ServiceUserEntityConstants.Area1] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.Area1].ToString());
            entity.Area2 = reader[Plugin_ServiceUserEntityConstants.Area2] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.Area2].ToString());
            entity.Address = reader[Plugin_ServiceUserEntityConstants.Address] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.Address].ToString();
            entity.Longitude = reader[Plugin_ServiceUserEntityConstants.Longitude] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.Longitude].ToString();
            entity.Latitude = reader[Plugin_ServiceUserEntityConstants.Latitude] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.Latitude].ToString();



            entity.Order = reader[Plugin_ServiceUserEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_ServiceUserEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_ServiceUserEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_ServiceUserEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_ServiceUserEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_ServiceUserEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_ServiceUserEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_ServiceUserEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_ServiceUserEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_ServiceUserEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_ServiceUserEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_ServiceUserEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_ServiceUserEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_ServiceUserEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_ServiceUserEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_ServiceUserEntityConstants.LanguageName].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("NationalityID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.NationalityID = reader[Plugin_ServiceUserEntityConstants.NationalityID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_ServiceUserEntityConstants.NationalityID].ToString());
            }

            return entity;
        }

        public async static Task<ResultEntity<Plugin_ServiceUserEntity>> SelectByEmailAndPassword(string Email, string password)
        {
            ResultEntity<Plugin_ServiceUserEntity> result = new ResultEntity<Plugin_ServiceUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceUserRepositoryConstants.SP_SelectByEmailAndPassword, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceUserRepositoryConstants.Email, Email));
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceUserRepositoryConstants.Password, password));

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
    }
}
