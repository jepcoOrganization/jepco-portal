using Siteware.DataAccess.RepositorieConstants;
using Siteware.Entity.Constants.Entity;
using Siteware.Entity.Entities;
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
    public class Plugin_JobApplicationRepository
    {
        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> SelectByID(long JobApplicationID)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_JobApplicationRepositoryConstants.JobApplicationID, JobApplicationID));
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
        public static ResultEntity<Plugin_JobApplicationEntity> SelectByIDNotAsync(long JobApplicationID)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_JobApplicationRepositoryConstants.JobApplicationID, JobApplicationID));
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

        public async static Task<ResultList<Plugin_JobApplicationEntity>> SelectAll()
        {
            ResultList<Plugin_JobApplicationEntity> result = new ResultList<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_JobApplicationEntity> list = new List<Plugin_JobApplicationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_JobApplicationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_JobApplicationEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_JobApplicationEntity> result = new ResultList<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_JobApplicationEntity> list = new List<Plugin_JobApplicationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_JobApplicationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> Update(Plugin_JobApplicationEntity entity)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobType, entity.JobType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobName, entity.JobName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LastName, entity.LastName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Nationalid, entity.Nationalid);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.BirthDate, entity.BirthDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.MaritalState, entity.MaritalState);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.NoofChild, entity.NoofChild);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.HaveLicence, entity.HaveLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LicenceType, entity.LicenceType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.YearOfLicence, entity.YearOfLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Qualification, entity.Qualification);

                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_JobApplicationEntity> UpdateNotAsync(Plugin_JobApplicationEntity entity)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobType, entity.JobType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobName, entity.JobName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LastName, entity.LastName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Nationalid, entity.Nationalid);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.BirthDate, entity.BirthDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.MaritalState, entity.MaritalState);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.NoofChild, entity.NoofChild);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.HaveLicence, entity.HaveLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LicenceType, entity.LicenceType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.YearOfLicence, entity.YearOfLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Qualification, entity.Qualification);

                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> Delete(long JobApplicationID)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobApplicationID, JobApplicationID);

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

        public async static Task<ResultEntity<Plugin_JobApplicationEntity>> Insert(Plugin_JobApplicationEntity entity)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();



                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobType, entity.JobType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobName, entity.JobName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LastName, entity.LastName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Nationalid, entity.Nationalid);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.BirthDate, entity.BirthDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.MaritalState, entity.MaritalState);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.NoofChild, entity.NoofChild);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.HaveLicence, entity.HaveLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LicenceType, entity.LicenceType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.YearOfLicence, entity.YearOfLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Qualification, entity.Qualification);


                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(Plugin_JobApplicationRepositoryConstants.JobApplicationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.JobApplicationID = Convert.ToInt64(sqlCommand.Parameters[Plugin_JobApplicationRepositoryConstants.JobApplicationID].Value);

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
        public static ResultEntity<Plugin_JobApplicationEntity> InsertNotAsync(Plugin_JobApplicationEntity entity)
        {

            ResultEntity<Plugin_JobApplicationEntity> result = new ResultEntity<Plugin_JobApplicationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_JobApplicationRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();


                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobType, entity.JobType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.JobName, entity.JobName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.ThirdName, entity.ThirdName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LastName, entity.LastName);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Nationalid, entity.Nationalid);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.BirthDate, entity.BirthDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.MaritalState, entity.MaritalState);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.NoofChild, entity.NoofChild);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.HaveLicence, entity.HaveLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LicenceType, entity.LicenceType);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.YearOfLicence, entity.YearOfLicence);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Qualification, entity.Qualification);

                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_JobApplicationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_JobApplicationRepositoryConstants.JobApplicationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.JobApplicationID = Convert.ToInt64(sqlCommand.Parameters[Plugin_JobApplicationRepositoryConstants.JobApplicationID].Value);

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



        static Plugin_JobApplicationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_JobApplicationEntity entity = new Plugin_JobApplicationEntity();


            entity.JobApplicationID = Convert.ToInt64(reader[Plugin_JobApplicationEntityConstants.JobApplicationID].ToString());
            entity.JobType = reader[Plugin_JobApplicationEntityConstants.JobType] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.JobType].ToString());
            entity.JobName = reader[Plugin_JobApplicationEntityConstants.JobName] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.JobName].ToString());
            entity.FirstName = reader[Plugin_JobApplicationEntityConstants.FirstName] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.FirstName].ToString();
            entity.SecondName = reader[Plugin_JobApplicationEntityConstants.SecondName] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.SecondName].ToString();
            entity.ThirdName = reader[Plugin_JobApplicationEntityConstants.ThirdName] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.ThirdName].ToString();
            entity.LastName = reader[Plugin_JobApplicationEntityConstants.LastName] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.LastName].ToString();
            entity.Nationalid = reader[Plugin_JobApplicationEntityConstants.Nationalid] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.Nationalid].ToString();


            entity.BirthDate = reader[Plugin_JobApplicationEntityConstants.BirthDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_JobApplicationEntityConstants.BirthDate].ToString());
            entity.MaritalState = reader[Plugin_JobApplicationEntityConstants.MaritalState] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.MaritalState].ToString());
            entity.NoofChild = reader[Plugin_JobApplicationEntityConstants.NoofChild] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.NoofChild].ToString();
            entity.HaveLicence = reader[Plugin_JobApplicationEntityConstants.HaveLicence] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.HaveLicence].ToString();
            entity.LicenceType = reader[Plugin_JobApplicationEntityConstants.LicenceType] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.LicenceType].ToString());
            entity.YearOfLicence = reader[Plugin_JobApplicationEntityConstants.YearOfLicence] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.YearOfLicence].ToString());
            entity.Qualification = reader[Plugin_JobApplicationEntityConstants.Qualification] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.Qualification].ToString());



            entity.Order = reader[Plugin_JobApplicationEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_JobApplicationEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_JobApplicationEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_JobApplicationEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_JobApplicationEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_JobApplicationEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_JobApplicationEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_JobApplicationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_JobApplicationEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_JobApplicationEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_JobApplicationEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_JobApplicationEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_JobApplicationEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_JobApplicationEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_JobApplicationEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_JobApplicationEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_JobApplicationEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_JobApplicationEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
