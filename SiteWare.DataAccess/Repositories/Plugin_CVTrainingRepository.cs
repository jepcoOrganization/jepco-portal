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
    public class Plugin_CVTrainingRepository
    {
        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> SelectByID(long TrainingID)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVTrainingRepositoryConstants.TrainingID, TrainingID));
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
        public static ResultEntity<Plugin_CVTrainingEntity> SelectByIDNotAsync(long TrainingID)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVTrainingRepositoryConstants.TrainingID, TrainingID));
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

        public async static Task<ResultList<Plugin_CVTrainingEntity>> SelectAll()
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVTrainingEntity> list = new List<Plugin_CVTrainingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CVTrainingEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CVTrainingEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVTrainingEntity> list = new List<Plugin_CVTrainingEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CVTrainingEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> Update(Plugin_CVTrainingEntity entity)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.TrainingID, entity.TrainingID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceType, entity.CourceType);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceName, entity.CourceName);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceDuration, entity.CourceDuration);


                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_CVTrainingEntity> UpdateNotAsync(Plugin_CVTrainingEntity entity)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.TrainingID, entity.TrainingID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceType, entity.CourceType);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceName, entity.CourceName);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceDuration, entity.CourceDuration);

                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> Delete(long TrainingID)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.TrainingID, TrainingID);

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

        public async static Task<ResultEntity<Plugin_CVTrainingEntity>> Insert(Plugin_CVTrainingEntity entity)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();



                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceType, entity.CourceType);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceName, entity.CourceName);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceDuration, entity.CourceDuration);


                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(Plugin_CVTrainingRepositoryConstants.TrainingID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.TrainingID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CVTrainingRepositoryConstants.TrainingID].Value);

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
        public static ResultEntity<Plugin_CVTrainingEntity> InsertNotAsync(Plugin_CVTrainingEntity entity)
        {

            ResultEntity<Plugin_CVTrainingEntity> result = new ResultEntity<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();


                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceType, entity.CourceType);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceName, entity.CourceName);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.CourceDuration, entity.CourceDuration);


                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVTrainingRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_CVTrainingRepositoryConstants.TrainingID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.TrainingID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CVTrainingRepositoryConstants.TrainingID].Value);

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

        public async static Task<ResultList<Plugin_CVTrainingEntity>> SelectByAdmissionID(long JobApplicationID)
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVTrainingEntity> list = new List<Plugin_CVTrainingEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVTrainingRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CVTrainingEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CVTrainingEntity> SelectByAdmissionIDNotAsync(long JobApplicationID)
        {
            ResultList<Plugin_CVTrainingEntity> result = new ResultList<Plugin_CVTrainingEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVTrainingRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVTrainingEntity> list = new List<Plugin_CVTrainingEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVTrainingRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CVTrainingEntity entity = EntityHelper(reader, false);
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

        static Plugin_CVTrainingEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CVTrainingEntity entity = new Plugin_CVTrainingEntity();


            entity.TrainingID = Convert.ToInt64(reader[Plugin_CVTrainingEntityConstants.TrainingID].ToString());
            entity.JobApplicationID = reader[Plugin_CVTrainingEntityConstants.JobApplicationID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CVTrainingEntityConstants.JobApplicationID].ToString());
            entity.CourceType = reader[Plugin_CVTrainingEntityConstants.CourceType] == DBNull.Value ? string.Empty : reader[Plugin_CVTrainingEntityConstants.CourceType].ToString();
            entity.CourceName = reader[Plugin_CVTrainingEntityConstants.CourceName] == DBNull.Value ? string.Empty : reader[Plugin_CVTrainingEntityConstants.CourceName].ToString();
            entity.CourceDuration = reader[Plugin_CVTrainingEntityConstants.CourceDuration] == DBNull.Value ? string.Empty : reader[Plugin_CVTrainingEntityConstants.CourceDuration].ToString();


            entity.Order = reader[Plugin_CVTrainingEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CVTrainingEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_CVTrainingEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_CVTrainingEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_CVTrainingEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CVTrainingEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_CVTrainingEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_CVTrainingEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_CVTrainingEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CVTrainingEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_CVTrainingEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CVTrainingEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_CVTrainingEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_CVTrainingEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_CVTrainingEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CVTrainingEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_CVTrainingEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_CVTrainingEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_CVTrainingEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_CVTrainingEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
