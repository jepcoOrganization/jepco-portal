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
    public static class RenewableEnergyCompanyUserRepository
    {
        public async static Task<ResultEntity<RenewableEnergyCompanyUserEntity>> SelectByID(long RenewableEnergyCompanyUserID)
        {

            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyUserRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID, RenewableEnergyCompanyUserID));
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
        public static ResultEntity<RenewableEnergyCompanyUserEntity> SelectByIDNotAsync(long RenewableEnergyCompanyUserID)
        {

            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyUserRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID, RenewableEnergyCompanyUserID));
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
        public async static Task<ResultList<RenewableEnergyCompanyUserEntity>> SelectAll()
        {
            ResultList<RenewableEnergyCompanyUserEntity> result = new ResultList<RenewableEnergyCompanyUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyUserRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyUserEntity> list = new List<RenewableEnergyCompanyUserEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanyUserEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyCompanyUserEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyCompanyUserEntity> result = new ResultList<RenewableEnergyCompanyUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyUserRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyUserEntity> list = new List<RenewableEnergyCompanyUserEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanyUserEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyCompanyUserEntity>> Insert(RenewableEnergyCompanyUserEntity entity)
        {

            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyUserRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID, entity.RenewableEnergyCompanyUserID);

                //sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID, entity.RenewableEnergyCompanyUserID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.FatherName, entity.FatherName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.Grandfathername, entity.Grandfathername);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumnetNo, entity.DocumnetNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.MobileNo, entity.MobileNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.EmailID, entity.EmailID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.RegisterDate, entity.RegisterDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.ExpireDate, entity.ExpireDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumentUpload, entity.DocumentUpload);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumentUploadPhoto, entity.DocumentUploadPhoto);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.CompanyID, entity.CompanyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.IsActive, entity.IsActive);


                sqlCommand.Parameters.Add(RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.RenewableEnergyCompanyUserID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID].Value);

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
        public static ResultEntity<RenewableEnergyCompanyUserEntity> InsertNotAsync(RenewableEnergyCompanyUserEntity entity)
        {

            ResultEntity<RenewableEnergyCompanyUserEntity> result = new ResultEntity<RenewableEnergyCompanyUserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyUserRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.FatherName, entity.FatherName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.Grandfathername, entity.Grandfathername);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumentType, entity.DocumentType);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumnetNo, entity.DocumnetNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.MobileNo, entity.MobileNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.EmailID, entity.EmailID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.RegisterDate, entity.RegisterDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.ExpireDate, entity.ExpireDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumentUpload, entity.DocumentUpload);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.DocumentUploadPhoto, entity.DocumentUploadPhoto);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.CompanyID, entity.CompanyID);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyUserRepositoryConstants.IsActive, entity.IsActive);

                sqlCommand.Parameters.Add(RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.RenewableEnergyCompanyUserID = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyCompanyUserRepositoryConstants.RenewableEnergyCompanyUserID].Value);

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
        static RenewableEnergyCompanyUserEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyCompanyUserEntity entity = new RenewableEnergyCompanyUserEntity();

            try
            {

                entity.RenewableEnergyCompanyUserID = Convert.ToInt64(reader[RenewableEnergyCompanyUserEntityConstants.RenewableEnergyCompanyUserID].ToString());

                entity.FirstName = reader[RenewableEnergyCompanyUserEntityConstants.FirstName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.FirstName].ToString();
                entity.FatherName = reader[RenewableEnergyCompanyUserEntityConstants.FatherName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.FatherName].ToString();
                entity.Grandfathername = reader[RenewableEnergyCompanyUserEntityConstants.Grandfathername] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.Grandfathername].ToString();
                entity.FamilyName = reader[RenewableEnergyCompanyUserEntityConstants.FamilyName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.FamilyName].ToString();
                entity.DocumentType = reader[RenewableEnergyCompanyUserEntityConstants.DocumentType] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.DocumentType].ToString();
                entity.DocumnetNo = reader[RenewableEnergyCompanyUserEntityConstants.DocumnetNo] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.DocumnetNo].ToString();
                entity.MobileNo = reader[RenewableEnergyCompanyUserEntityConstants.MobileNo] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.MobileNo].ToString();
                entity.EmailID = reader[RenewableEnergyCompanyUserEntityConstants.EmailID] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.EmailID].ToString();
                entity.RegisterDate = reader[RenewableEnergyCompanyUserEntityConstants.RegisterDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyUserEntityConstants.RegisterDate].ToString());
                entity.ExpireDate = reader[RenewableEnergyCompanyUserEntityConstants.ExpireDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyUserEntityConstants.ExpireDate].ToString());
                entity.DocumentUpload = reader[RenewableEnergyCompanyUserEntityConstants.DocumentUpload] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.DocumentUpload].ToString();
                entity.DocumentUploadPhoto = reader[RenewableEnergyCompanyUserEntityConstants.DocumentUploadPhoto] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.DocumentUploadPhoto].ToString();
                entity.LanguageID = reader[RenewableEnergyCompanyUserEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyCompanyUserEntityConstants.LanguageID].ToString());
                entity.PublishDate = reader[RenewableEnergyCompanyUserEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyUserEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[RenewableEnergyCompanyUserEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanyUserEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[RenewableEnergyCompanyUserEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanyUserEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[RenewableEnergyCompanyUserEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyUserEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyCompanyUserEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyUserEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyCompanyUserEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyCompanyUserEntityConstants.EditUser].ToString();

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
                    entity.LanguageName = reader[RenewableEnergyCompanyUserEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyUserEntityConstants.LanguageName].ToString();
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("CompanyID");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.CompanyID = reader[RenewableEnergyCompanyUserEntityConstants.CompanyID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyCompanyUserEntityConstants.CompanyID].ToString());
                    
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("IsActive");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.IsActive = reader[RenewableEnergyCompanyUserEntityConstants.IsActive] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanyUserEntityConstants.IsActive].ToString());
                    
                }

            }
            catch (Exception ex)
            {

            }

            return entity;
        }
    }
}
















