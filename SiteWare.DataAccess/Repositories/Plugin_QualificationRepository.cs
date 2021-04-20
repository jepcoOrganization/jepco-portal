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
    public class Plugin_QualificationRepository
    {
        public async static Task<ResultEntity<Plugin_QualificationEntity>> SelectByID(long QualificationID)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_QualificationRepositoryConstants.QualificationID, QualificationID));
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
        public static ResultEntity<Plugin_QualificationEntity> SelectByIDNotAsync(long QualificationID)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_QualificationRepositoryConstants.QualificationID, QualificationID));
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

        public async static Task<ResultList<Plugin_QualificationEntity>> SelectAll()
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_QualificationEntity> list = new List<Plugin_QualificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_QualificationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_QualificationEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_QualificationEntity> list = new List<Plugin_QualificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_QualificationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_QualificationEntity>> Update(Plugin_QualificationEntity entity)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.QualificationID, entity.QualificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.UniName, entity.UniName);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major, entity.Major);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_Two, entity.Major_Two);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_From, entity.Major_From);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AVG, entity.AVG);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.OverAllEval, entity.OverAllEval);



                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_QualificationEntity> UpdateNotAsync(Plugin_QualificationEntity entity)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.QualificationID, entity.QualificationID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.UniName, entity.UniName);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major, entity.Major);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_Two, entity.Major_Two);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_From, entity.Major_From);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AVG, entity.AVG);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.OverAllEval, entity.OverAllEval);

                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_QualificationEntity>> Delete(long QualificationID)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.QualificationID, QualificationID);

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

        public async static Task<ResultEntity<Plugin_QualificationEntity>> Insert(Plugin_QualificationEntity entity)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();



                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.UniName, entity.UniName);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major, entity.Major);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_Two, entity.Major_Two);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_From, entity.Major_From);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AVG, entity.AVG);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.OverAllEval, entity.OverAllEval);


                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(Plugin_QualificationRepositoryConstants.QualificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.QualificationID = Convert.ToInt64(sqlCommand.Parameters[Plugin_QualificationRepositoryConstants.QualificationID].Value);

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
        public static ResultEntity<Plugin_QualificationEntity> InsertNotAsync(Plugin_QualificationEntity entity)
        {

            ResultEntity<Plugin_QualificationEntity> result = new ResultEntity<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();


                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.JobApplicationID, entity.JobApplicationID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.UniName, entity.UniName);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Year, entity.Year);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major, entity.Major);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_Two, entity.Major_Two);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Major_From, entity.Major_From);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AVG, entity.AVG);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.OverAllEval, entity.OverAllEval);


                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_QualificationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_QualificationRepositoryConstants.QualificationID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.QualificationID = Convert.ToInt64(sqlCommand.Parameters[Plugin_QualificationRepositoryConstants.QualificationID].Value);

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

        public async static Task<ResultList<Plugin_QualificationEntity>> SelectByAdmissionID(long JobApplicationID)
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_QualificationEntity> list = new List<Plugin_QualificationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_QualificationRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_QualificationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_QualificationEntity> SelectByAdmissionIDNotAsync(long JobApplicationID)
        {
            ResultList<Plugin_QualificationEntity> result = new ResultList<Plugin_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_QualificationRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_QualificationEntity> list = new List<Plugin_QualificationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_QualificationRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_QualificationEntity entity = EntityHelper(reader, false);
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

        static Plugin_QualificationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_QualificationEntity entity = new Plugin_QualificationEntity();


            entity.QualificationID = Convert.ToInt64(reader[Plugin_QualificationEntityConstants.QualificationID].ToString());
            entity.JobApplicationID = reader[Plugin_QualificationEntityConstants.JobApplicationID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_QualificationEntityConstants.JobApplicationID].ToString());
            entity.UniName = reader[Plugin_QualificationEntityConstants.UniName] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.UniName].ToString();
            entity.Name = reader[Plugin_QualificationEntityConstants.Name] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.Name].ToString();
            entity.Year = reader[Plugin_QualificationEntityConstants.Year] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.Year].ToString();
            entity.Major = reader[Plugin_QualificationEntityConstants.Major] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.Major].ToString();
            entity.Major_Two = reader[Plugin_QualificationEntityConstants.Major_Two] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.Major_Two].ToString();
            entity.Major_From = reader[Plugin_QualificationEntityConstants.Major_From] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.Major_From].ToString();
            entity.AVG = reader[Plugin_QualificationEntityConstants.AVG] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.AVG].ToString();
            entity.OverAllEval = reader[Plugin_QualificationEntityConstants.OverAllEval] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.OverAllEval].ToString();




            entity.Order = reader[Plugin_QualificationEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_QualificationEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_QualificationEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_QualificationEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_QualificationEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_QualificationEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_QualificationEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_QualificationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_QualificationEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_QualificationEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_QualificationEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_QualificationEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_QualificationEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_QualificationEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_QualificationEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_QualificationEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_QualificationEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_QualificationEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
