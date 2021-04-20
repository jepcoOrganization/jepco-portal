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
    public class Plugin_PreviuesExperianceRepository
    {
        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> SelectByID(long PreviuesExperianceID)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, PreviuesExperianceID));
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
        public static ResultEntity<Plugin_PreviuesExperianceEntity> SelectByIDNotAsync(long PreviuesExperianceID)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, PreviuesExperianceID));
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

        public async static Task<ResultList<Plugin_PreviuesExperianceEntity>> SelectAll()
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PreviuesExperianceEntity> list = new List<Plugin_PreviuesExperianceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PreviuesExperianceEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_PreviuesExperianceEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PreviuesExperianceEntity> list = new List<Plugin_PreviuesExperianceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PreviuesExperianceEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> Update(Plugin_PreviuesExperianceEntity entity)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, entity.PreviuesExperianceID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EntityName, entity.EntityName);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.ExperianceType, entity.ExperianceType);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.NumberOfYear, entity.NumberOfYear);

                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_PreviuesExperianceEntity> UpdateNotAsync(Plugin_PreviuesExperianceEntity entity)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, entity.PreviuesExperianceID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EntityName, entity.EntityName);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.ExperianceType, entity.ExperianceType);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.NumberOfYear, entity.NumberOfYear);

                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> Delete(long PreviuesExperianceID)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, PreviuesExperianceID);

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

        public async static Task<ResultEntity<Plugin_PreviuesExperianceEntity>> Insert(Plugin_PreviuesExperianceEntity entity)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();



                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EntityName, entity.EntityName);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.ExperianceType, entity.ExperianceType);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.NumberOfYear, entity.NumberOfYear);


                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.PreviuesExperianceID = Convert.ToInt64(sqlCommand.Parameters[Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID].Value);

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
        public static ResultEntity<Plugin_PreviuesExperianceEntity> InsertNotAsync(Plugin_PreviuesExperianceEntity entity)
        {

            ResultEntity<Plugin_PreviuesExperianceEntity> result = new ResultEntity<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();


                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EntityName, entity.EntityName);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.ExperianceType, entity.ExperianceType);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.NumberOfYear, entity.NumberOfYear);


                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PreviuesExperianceRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.PreviuesExperianceID = Convert.ToInt64(sqlCommand.Parameters[Plugin_PreviuesExperianceRepositoryConstants.PreviuesExperianceID].Value);

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

        public async static Task<ResultList<Plugin_PreviuesExperianceEntity>> SelectByAdmissionID(long JobApplicationID)
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PreviuesExperianceEntity> list = new List<Plugin_PreviuesExperianceEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PreviuesExperianceRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PreviuesExperianceEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_PreviuesExperianceEntity> SelectByAdmissionIDNotAsync(long JobApplicationID)
        {
            ResultList<Plugin_PreviuesExperianceEntity> result = new ResultList<Plugin_PreviuesExperianceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PreviuesExperianceRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PreviuesExperianceEntity> list = new List<Plugin_PreviuesExperianceEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PreviuesExperianceRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PreviuesExperianceEntity entity = EntityHelper(reader, false);
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

        static Plugin_PreviuesExperianceEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_PreviuesExperianceEntity entity = new Plugin_PreviuesExperianceEntity();


            entity.PreviuesExperianceID = Convert.ToInt64(reader[Plugin_PreviuesExperianceEntityConstants.PreviuesExperianceID].ToString());
            entity.JobApplicationID = reader[Plugin_PreviuesExperianceEntityConstants.JobApplicationID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_PreviuesExperianceEntityConstants.JobApplicationID].ToString());
            entity.EntityName = reader[Plugin_PreviuesExperianceEntityConstants.EntityName] == DBNull.Value ? string.Empty : reader[Plugin_PreviuesExperianceEntityConstants.EntityName].ToString();
            entity.ExperianceType = reader[Plugin_PreviuesExperianceEntityConstants.ExperianceType] == DBNull.Value ? string.Empty : reader[Plugin_PreviuesExperianceEntityConstants.ExperianceType].ToString();
            entity.NumberOfYear = reader[Plugin_PreviuesExperianceEntityConstants.NumberOfYear] == DBNull.Value ? string.Empty : reader[Plugin_PreviuesExperianceEntityConstants.NumberOfYear].ToString();



            entity.Order = reader[Plugin_PreviuesExperianceEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_PreviuesExperianceEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_PreviuesExperianceEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_PreviuesExperianceEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_PreviuesExperianceEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_PreviuesExperianceEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_PreviuesExperianceEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_PreviuesExperianceEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_PreviuesExperianceEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_PreviuesExperianceEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_PreviuesExperianceEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_PreviuesExperianceEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_PreviuesExperianceEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_PreviuesExperianceEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_PreviuesExperianceEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_PreviuesExperianceEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_PreviuesExperianceEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_PreviuesExperianceEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_PreviuesExperianceEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_PreviuesExperianceEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
