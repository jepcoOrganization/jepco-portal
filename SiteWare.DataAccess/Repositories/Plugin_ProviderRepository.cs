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
    public static class Plugin_ProviderRepository
    {
        public async static Task<ResultList<Plugin_ProviderEntity>> SelectAll()
        {
            ResultList<Plugin_ProviderEntity> result = new ResultList<Plugin_ProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderEntity> list = new List<Plugin_ProviderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ProviderEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_ProviderEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_ProviderEntity> result = new ResultList<Plugin_ProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderEntity> list = new List<Plugin_ProviderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ProviderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_ProviderEntity>> Update(Plugin_ProviderEntity entity)
        {

            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderName, entity.ProviderName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderLogo, entity.ProviderLogo);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.TradeName, entity.TradeName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderGoal, entity.ProviderGoal);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CEO, entity.CEO);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.GeneralManager, entity.GeneralManager);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ActingManagerName, entity.ActingManagerName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ActingManagerPhoneNo, entity.ActingManagerPhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PartnerName, entity.PartnerName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PartnerPhoneNo, entity.PartnerPhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CityID, entity.CityID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CityName, entity.CityName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Neighborhood, entity.Neighborhood);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PO, entity.PO);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PhoneNumber, entity.PhoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Fax, entity.Fax);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PostalCode, entity.PostalCode);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CertificationTypeID, entity.CertificationTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CertificationType, entity.CertificationType);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Capital, entity.Capital);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.RegistrationNumber, entity.RegistrationNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.RegistrationDate, entity.RegistrationDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.MembershipDate, entity.MembershipDate);

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
        public async static Task<ResultEntity<Plugin_ProviderEntity>> InsertProvider(Plugin_ProviderEntity entity)
        {

            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderName, entity.ProviderName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderGoal, entity.ProviderGoal);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderLogo, entity.ProviderLogo);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.TradeName, entity.TradeName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CEO, entity.CEO);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.GeneralManager, entity.GeneralManager);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ActingManagerName, entity.ActingManagerName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ActingManagerPhoneNo, entity.ActingManagerPhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PartnerName, entity.PartnerName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PartnerPhoneNo, entity.PartnerPhoneNo);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CityID, entity.CityID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CityName, entity.CityName);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Neighborhood, entity.Neighborhood);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PO, entity.PO);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Website, entity.Website);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PhoneNumber, entity.PhoneNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Fax, entity.Fax);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PostalCode, entity.PostalCode);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CertificationTypeID, entity.CertificationTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.CertificationType, entity.CertificationType);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Capital, entity.Capital);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.RegistrationNumber, entity.RegistrationNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.RegistrationDate, entity.RegistrationDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.MembershipDate, entity.MembershipDate);
                sqlCommand.Parameters.Add(Plugin_ProviderRepositoryConstants.ProviderID, SqlDbType.BigInt).Direction = ParameterDirection.Output;


                //sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.PublishDate, entity.PublishDate);
                //sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsPublished, entity.IsPublished);
                //sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsDelete, entity.IsDelete);


                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ProviderID = Convert.ToInt64(sqlCommand.Parameters[Plugin_ProviderRepositoryConstants.ProviderID].Value);

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
        public async static Task<ResultEntity<Plugin_ProviderEntity>> SelectByProviderID(long ProviderID)
        {

            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ProviderRepositoryConstants.ProviderID, ProviderID));
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
        public async static Task<ResultEntity<Plugin_ProviderEntity>> UpdateByIsDeleted(Plugin_ProviderEntity entity)
        {

            ResultEntity<Plugin_ProviderEntity> result = new ResultEntity<Plugin_ProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_UpdateByIsDelete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_ProviderRepositoryConstants.ProviderID, entity.ProviderID);

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
        static Plugin_ProviderEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ProviderEntity entity = new Plugin_ProviderEntity();

            entity.ProviderID = Convert.ToInt64(reader[Plugin_ProviderEntityConstants.ProviderID].ToString());
            entity.LanguageID = Convert.ToInt32(reader[Plugin_ProviderEntityConstants.LanguageID].ToString());
            entity.ProviderName = reader[Plugin_ProviderEntityConstants.ProviderName].ToString();
            entity.ProviderLogo = reader[Plugin_ProviderEntityConstants.ProviderLogo].ToString();
            entity.TradeName = reader[Plugin_ProviderEntityConstants.TradeName].ToString();
            entity.ProviderGoal = reader[Plugin_ProviderEntityConstants.ProviderGoal].ToString();
            entity.CEO = reader[Plugin_ProviderEntityConstants.CEO].ToString();
            entity.GeneralManager = reader[Plugin_ProviderEntityConstants.GeneralManager].ToString();
            entity.ActingManagerName = reader[Plugin_ProviderEntityConstants.ActingManagerName].ToString();
            entity.ActingManagerPhoneNo = reader[Plugin_ProviderEntityConstants.ActingManagerPhoneNo].ToString();
            entity.PartnerName = reader[Plugin_ProviderEntityConstants.PartnerName].ToString();
            entity.PartnerPhoneNo = reader[Plugin_ProviderEntityConstants.PartnerPhoneNo].ToString();
            entity.CityID = Convert.ToInt32(reader[Plugin_ProviderEntityConstants.CityID].ToString());
            entity.CityName = reader[Plugin_ProviderEntityConstants.CityName].ToString();
            entity.Neighborhood = reader[Plugin_ProviderEntityConstants.Neighborhood].ToString();
            entity.Street = reader[Plugin_ProviderEntityConstants.Street].ToString();
            entity.PO = reader[Plugin_ProviderEntityConstants.PO].ToString();
            entity.Website = reader[Plugin_ProviderEntityConstants.Website].ToString();
            entity.PhoneNumber = reader[Plugin_ProviderEntityConstants.PhoneNumber].ToString();
            entity.Fax = reader[Plugin_ProviderEntityConstants.Fax].ToString();
            entity.MobileNumber = reader[Plugin_ProviderEntityConstants.MobileNumber].ToString();
            entity.PostalCode = reader[Plugin_ProviderEntityConstants.PostalCode].ToString();
            entity.Email = reader[Plugin_ProviderEntityConstants.Email].ToString();
            entity.CertificationTypeID = Convert.ToInt32(reader[Plugin_ProviderEntityConstants.CertificationTypeID].ToString());
            entity.CertificationType = reader[Plugin_ProviderEntityConstants.CertificationType].ToString();
            entity.Capital = reader[Plugin_ProviderEntityConstants.Capital].ToString();
            entity.RegistrationNumber = Convert.ToInt64(reader[Plugin_ProviderEntityConstants.RegistrationNumber].ToString());
            entity.RegistrationDate = Convert.ToDateTime(reader[Plugin_ProviderEntityConstants.RegistrationDate].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[Plugin_ProviderEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_ProviderEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Plugin_ProviderEntityConstants.IsDelete].ToString());
            entity.Order = Convert.ToInt32(reader[Plugin_ProviderEntityConstants.Order].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_ProviderEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_ProviderEntityConstants.AddUser].ToString();
            entity.EditDate = Convert.ToDateTime(reader[Plugin_ProviderEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_ProviderEntityConstants.EditUser].ToString();



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
                entity.LanguageName = reader[Plugin_ProviderEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("IsApproved");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IsApproved = reader[Plugin_ProviderEntityConstants.IsApproved] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_ProviderEntityConstants.IsApproved].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("MembershipDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.MembershipDate = reader[Plugin_ProviderEntityConstants.MembershipDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_ProviderEntityConstants.MembershipDate].ToString());
            }

            return entity;
        }

    }
}
