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
    public static class Plugin_RenwabaleEnergyCompanyRepository
    {
        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> SelectByID(long RenwabaleEnergyCompanyID)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, RenwabaleEnergyCompanyID));
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
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> SelectByIDNotAsync(long RenwabaleEnergyCompanyID)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, RenwabaleEnergyCompanyID));
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
        public async static Task<ResultList<Plugin_RenwabaleEnergyCompanyEntity>> SelectAll()
        {
            ResultList<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_RenwabaleEnergyCompanyEntity> list = new List<Plugin_RenwabaleEnergyCompanyEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_RenwabaleEnergyCompanyEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_RenwabaleEnergyCompanyEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultList<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_RenwabaleEnergyCompanyEntity> list = new List<Plugin_RenwabaleEnergyCompanyEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_RenwabaleEnergyCompanyEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> Update(Plugin_RenwabaleEnergyCompanyEntity entity)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, entity.RenwabaleEnergyCompanyID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyNationalID, entity.CompanyNationalID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyClassificationID, entity.CompanyClassificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.FaxNumber, entity.FaxNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EmailAddress, entity.EmailAddress);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyRegistrationDocument, entity.CompanyRegistrationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationDocument, entity.QualificationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationExpiryDate, entity.QualificationExpiryDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsMobileVerfied, entity.IsMobileVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ISEmailVerfied, entity.ISEmailVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditUser, entity.EditUser);
                //sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.LanguageName, entity.LanguageName);




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
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> UpdateNotAsync(Plugin_RenwabaleEnergyCompanyEntity entity)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, entity.RenwabaleEnergyCompanyID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyNationalID, entity.CompanyNationalID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyClassificationID, entity.CompanyClassificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.FaxNumber, entity.FaxNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EmailAddress, entity.EmailAddress);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyRegistrationDocument, entity.CompanyRegistrationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationDocument, entity.QualificationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationExpiryDate, entity.QualificationExpiryDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsMobileVerfied, entity.IsMobileVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ISEmailVerfied, entity.ISEmailVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditUser, entity.EditUser);
                //sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.LanguageName, entity.LanguageName);


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
        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> Delete(long RenwabaleEnergyCompanyID)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, RenwabaleEnergyCompanyID);

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
        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> Insert(Plugin_RenwabaleEnergyCompanyEntity entity)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, entity.RenwabaleEnergyCompanyID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyNationalID, entity.CompanyNationalID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyClassificationID, entity.CompanyClassificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.FaxNumber, entity.FaxNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EmailAddress, entity.EmailAddress);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyRegistrationDocument, entity.CompanyRegistrationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationDocument, entity.QualificationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationExpiryDate, entity.QualificationExpiryDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsMobileVerfied, entity.IsMobileVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ISEmailVerfied, entity.ISEmailVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditUser, entity.EditUser);
                

                sqlCommand.Parameters.Add(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.RenwabaleEnergyCompanyID = Convert.ToInt64(sqlCommand.Parameters[Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID].Value);

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
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> InsertNotAsync(Plugin_RenwabaleEnergyCompanyEntity entity)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Project_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ServiceUserID, entity.ServiceUserID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyNationalID, entity.CompanyNationalID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyClassificationID, entity.CompanyClassificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.TelephoneNumber, entity.TelephoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.FaxNumber, entity.FaxNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EmailAddress, entity.EmailAddress);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Governate, entity.Governate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Area2, entity.Area2);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.StreetID, entity.StreetID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.CompanyRegistrationDocument, entity.CompanyRegistrationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationDocument, entity.QualificationDocument);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.QualificationExpiryDate, entity.QualificationExpiryDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsMobileVerfied, entity.IsMobileVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ISEmailVerfied, entity.ISEmailVerfied);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_RenwabaleEnergyCompanyRepositoryConstants.EditUser, entity.EditUser);
               
                sqlCommand.Parameters.Add(Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.RenwabaleEnergyCompanyID = Convert.ToInt64(sqlCommand.Parameters[Plugin_RenwabaleEnergyCompanyRepositoryConstants.RenwabaleEnergyCompanyID].Value);

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
        static Plugin_RenwabaleEnergyCompanyEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_RenwabaleEnergyCompanyEntity entity = new Plugin_RenwabaleEnergyCompanyEntity();

            try
            {

                entity.RenwabaleEnergyCompanyID = Convert.ToInt64(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.RenwabaleEnergyCompanyID].ToString());
                entity.ServiceUserID = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.ServiceUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.ServiceUserID].ToString());
                entity.CompanyName = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyName] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyName].ToString();
                //entity.CompanyNationalID = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyNationalID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyNationalID].ToString());
                entity.CompanyClassificationID = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyClassificationID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyClassificationID].ToString());
                entity.Password = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Password] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Password].ToString();
                entity.MobileNumber = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.MobileNumber] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.MobileNumber].ToString();
                entity.TelephoneNumber = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.TelephoneNumber] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.TelephoneNumber].ToString();
                entity.FaxNumber = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.FaxNumber] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.FaxNumber].ToString();
                entity.EmailAddress = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.EmailAddress] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.EmailAddress].ToString();
                entity.Website = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Website] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Website].ToString();
                entity.Governate = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Governate] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Governate].ToString());
                entity.Area = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Area] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Area].ToString());
                entity.Area2 = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Area2] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Area2].ToString());
                entity.StreetID = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.StreetID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.StreetID].ToString());
                entity.Address = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Address] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Address].ToString();
                entity.CompanyRegistrationDocument = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyRegistrationDocument] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyRegistrationDocument].ToString();
                entity.QualificationDocument = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.QualificationDocument] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.QualificationDocument].ToString();
                entity.Order = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.Order].ToString());
                entity.LanguageID = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.LanguageID].ToString());
                entity.QualificationExpiryDate = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.QualificationExpiryDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.QualificationExpiryDate].ToString());
                entity.IsMobileVerfied = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.IsMobileVerfied] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.IsMobileVerfied].ToString());
                entity.ISEmailVerfied = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.ISEmailVerfied] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.ISEmailVerfied].ToString());
                entity.PublishDate = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.AddDate].ToString());
                entity.EditDate = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_RenwabaleEnergyCompanyEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.EditUser].ToString();

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
                    entity.LanguageName = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.LanguageName].ToString();
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("CompanyNationalID");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.CompanyNationalID = reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyNationalID] == DBNull.Value ? string.Empty : reader[Plugin_RenwabaleEnergyCompanyEntityConstants.CompanyNationalID].ToString();
                }


            }
            catch (Exception ex)
            {

            }

            return entity;
        }


        public async static Task<ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>> SelectByServiceUserID(long ServiceUserID)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_SelectByServiceUserID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ServiceUserID, ServiceUserID));
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
        public static ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> SelectByServiceUserIDNotAsync(long ServiceUserID)
        {

            ResultEntity<Plugin_RenwabaleEnergyCompanyEntity> result = new ResultEntity<Plugin_RenwabaleEnergyCompanyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_RenwabaleEnergyCompanyRepositoryConstants.SP_SelectByServiceUserID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_RenwabaleEnergyCompanyRepositoryConstants.ServiceUserID, ServiceUserID));
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



