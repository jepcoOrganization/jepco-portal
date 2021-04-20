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
    public static class SettingRepository
    {
        public async static Task<ResultEntity<SettingEntity>> SelectByID(int ID)
        {

            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SettingRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SettingRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<SettingEntity>> SelectAll()
        {
            ResultList<SettingEntity> result = new ResultList<SettingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SettingRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SettingEntity> list = new List<SettingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    SettingEntity entity = EntityHelper(reader, false);
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
        public static ResultList<SettingEntity> SelectAllWithoutAsync()
        {
            ResultList<SettingEntity> result = new ResultList<SettingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SettingRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SettingEntity> list = new List<SettingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    SettingEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<SettingEntity>> Insert(SettingEntity entity)
        {

            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SettingRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Logo, entity.Logo);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.GoogleAnalytic, entity.GoogleAnalytic);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.DateFormat, entity.DateFormat);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PasswordEmail, entity.PasswordEmail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.SMTPServer, entity.SMTPServer);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PageName, entity.PageName);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.CopyRights, entity.CopyRights);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PortNumber, entity.PortNumber);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.WorkingHours, entity.WorkingHours);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.FooterLogo, entity.FooterLogo);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsEnableSSL, entity.IsEnableSSL);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.FromMail, entity.FromMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.MailContent, entity.MailContent);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.UserMailContent, entity.UserMailContent);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableDeviceUserMail, entity.RenewableDeviceUserMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableDeviceAdminMail, entity.RenewableDeviceAdminMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableSolarCellUserMail, entity.RenewableSolarCellUserMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableSolarCellAdminMail, entity.RenewableSolarCellAdminMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableRegistrationUserMail, entity.RenewableRegistrationUserMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableRegistrationAdminMail, entity.RenewableRegistrationAdminMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.ForgetPasswordUser, entity.ForgetPasswordUser);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.ForgetPasswordAdmin, entity.ForgetPasswordAdmin);
                

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
        public async static Task<ResultEntity<SettingEntity>> Update(SettingEntity entity)
        {

            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SettingRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Logo, entity.Logo);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.GoogleAnalytic, entity.GoogleAnalytic);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.DateFormat, entity.DateFormat);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PasswordEmail, entity.PasswordEmail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.SMTPServer, entity.SMTPServer);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PageName, entity.PageName);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.CopyRights, entity.CopyRights);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.PortNumber, entity.PortNumber);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.WorkingHours, entity.WorkingHours);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.FooterLogo, entity.FooterLogo);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsEnableSSL, entity.IsEnableSSL);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.FromMail, entity.FromMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.MailContent, entity.MailContent);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.UserMailContent, entity.UserMailContent);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableDeviceUserMail, entity.RenewableDeviceUserMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableDeviceAdminMail, entity.RenewableDeviceAdminMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableSolarCellUserMail, entity.RenewableSolarCellUserMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableSolarCellAdminMail, entity.RenewableSolarCellAdminMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableRegistrationUserMail, entity.RenewableRegistrationUserMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.RenewableRegistrationAdminMail, entity.RenewableRegistrationAdminMail);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.ForgetPasswordUser, entity.ForgetPasswordUser);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.ForgetPasswordAdmin, entity.ForgetPasswordAdmin);

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
        public async static Task<ResultEntity<SettingEntity>> UpdateByIsDeleted(SettingEntity entity)
        {

            ResultEntity<SettingEntity> result = new ResultEntity<SettingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SettingRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(SettingRepositoryConstants.ID, entity.ID);

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
        static SettingEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            SettingEntity entity = new SettingEntity();

            entity.ID = Convert.ToInt32(reader[SettingEntityConstants.ID].ToString());
            entity.Website = reader[SettingEntityConstants.Website].ToString();
            entity.Logo = reader[SettingEntityConstants.Logo].ToString();
            entity.GoogleAnalytic = reader[SettingEntityConstants.GoogleAnalytic].ToString();
            entity.DateFormat = reader[SettingEntityConstants.DateFormat].ToString();
            entity.Email = reader[SettingEntityConstants.Email].ToString();
            entity.PasswordEmail = reader[SettingEntityConstants.PasswordEmail].ToString();
            entity.SMTPServer = reader[SettingEntityConstants.SMTPServer].ToString();
            entity.Longitude = reader[SettingEntityConstants.Longitude].ToString();
            entity.Latitude = reader[SettingEntityConstants.Latitude].ToString();
            entity.LanguageID = Convert.ToByte(reader[SettingEntityConstants.LanguageID].ToString());
            entity.PageName = reader[SettingEntityConstants.PageName].ToString();
            entity.CopyRights = reader[SettingEntityConstants.CopyRights].ToString();
            entity.PublishDate = Convert.ToDateTime(reader[SettingEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[SettingEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[SettingEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[SettingEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[SettingEntityConstants.EditDate].ToString());
            entity.AddUser = reader[SettingEntityConstants.AddUser].ToString();
            entity.EditUser = reader[SettingEntityConstants.EditUser].ToString();
            entity.WorkingHours = reader[SettingEntityConstants.WorkingHours] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.WorkingHours].ToString();
            entity.FooterLogo = reader[SettingEntityConstants.FooterLogo] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.FooterLogo].ToString();
            entity.Year = reader[SettingEntityConstants.Year] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.Year].ToString();


            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("PortNumber");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.PortNumber = reader[SettingEntityConstants.PortNumber] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.PortNumber].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("IsEnableSSL");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IsEnableSSL = reader[SettingEntityConstants.IsEnableSSL] == DBNull.Value ? false : Convert.ToBoolean(reader[SettingEntityConstants.IsEnableSSL].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("FromMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.FromMail = reader[SettingEntityConstants.FromMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.FromMail].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("MailContent");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.MailContent = reader[SettingEntityConstants.MailContent] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.MailContent].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("UserMailContent");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.UserMailContent = reader[SettingEntityConstants.UserMailContent] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.UserMailContent].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("RenewableDeviceUserMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RenewableDeviceUserMail = reader[SettingEntityConstants.RenewableDeviceUserMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.RenewableDeviceUserMail].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("RenewableDeviceAdminMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RenewableDeviceAdminMail = reader[SettingEntityConstants.RenewableDeviceAdminMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.RenewableDeviceAdminMail].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("RenewableSolarCellUserMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RenewableSolarCellUserMail = reader[SettingEntityConstants.RenewableSolarCellUserMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.RenewableSolarCellUserMail].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("RenewableSolarCellAdminMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RenewableSolarCellAdminMail = reader[SettingEntityConstants.RenewableSolarCellAdminMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.RenewableSolarCellAdminMail].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("RenewableRegistrationUserMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RenewableRegistrationUserMail = reader[SettingEntityConstants.RenewableRegistrationUserMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.RenewableRegistrationUserMail].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("RenewableRegistrationAdminMail");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RenewableRegistrationAdminMail = reader[SettingEntityConstants.RenewableRegistrationAdminMail] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.RenewableRegistrationAdminMail].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ForgetPasswordUser");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ForgetPasswordUser = reader[SettingEntityConstants.ForgetPasswordUser] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.ForgetPasswordUser].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ForgetPasswordAdmin");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ForgetPasswordAdmin = reader[SettingEntityConstants.ForgetPasswordAdmin] == DBNull.Value ? string.Empty : reader[SettingEntityConstants.ForgetPasswordAdmin].ToString();
            }

            return entity;
        }
    }
}
