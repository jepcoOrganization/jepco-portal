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
    public class Plugin_CVContactRepository
    {
        public async static Task<ResultEntity<Plugin_CVContactEntity>> SelectByID(long ContactID)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVContactRepositoryConstants.ContactID, ContactID));
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
        public static ResultEntity<Plugin_CVContactEntity> SelectByIDNotAsync(long ContactID)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVContactRepositoryConstants.ContactID, ContactID));
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

        public async static Task<ResultList<Plugin_CVContactEntity>> SelectAll()
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVContactEntity> list = new List<Plugin_CVContactEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CVContactEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CVContactEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVContactEntity> list = new List<Plugin_CVContactEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CVContactEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_CVContactEntity>> Update(Plugin_CVContactEntity entity)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.ContactID, entity.ContactID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.JobApplicationID, entity.JobApplicationID);

                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Provenance, entity.Provenance);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaOne, entity.AreaOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaTwo, entity.AreaTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Building, entity.Building);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.BuildingNumber, entity.BuildingNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneOne, entity.TeliphoneOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneTwo, entity.TeliphoneTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Resume, entity.Resume);



                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_CVContactEntity> UpdateNotAsync(Plugin_CVContactEntity entity)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.ContactID, entity.ContactID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.JobApplicationID, entity.JobApplicationID);

                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Provenance, entity.Provenance);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaOne, entity.AreaOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaTwo, entity.AreaTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Building, entity.Building);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.BuildingNumber, entity.BuildingNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneOne, entity.TeliphoneOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneTwo, entity.TeliphoneTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Resume, entity.Resume);

                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_CVContactEntity>> Delete(long ContactID)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.ContactID, ContactID);

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

        public async static Task<ResultEntity<Plugin_CVContactEntity>> Insert(Plugin_CVContactEntity entity)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();



                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.JobApplicationID, entity.JobApplicationID);

                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Provenance, entity.Provenance);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaOne, entity.AreaOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaTwo, entity.AreaTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Building, entity.Building);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.BuildingNumber, entity.BuildingNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneOne, entity.TeliphoneOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneTwo, entity.TeliphoneTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Resume, entity.Resume);


                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditUser, entity.EditUser);


                sqlCommand.Parameters.Add(Plugin_CVContactRepositoryConstants.ContactID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ContactID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CVContactRepositoryConstants.ContactID].Value);

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
        public static ResultEntity<Plugin_CVContactEntity> InsertNotAsync(Plugin_CVContactEntity entity)
        {

            ResultEntity<Plugin_CVContactEntity> result = new ResultEntity<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();


                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.JobApplicationID, entity.JobApplicationID);

                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Provenance, entity.Provenance);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaOne, entity.AreaOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AreaTwo, entity.AreaTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Building, entity.Building);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.BuildingNumber, entity.BuildingNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneOne, entity.TeliphoneOne);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.TeliphoneTwo, entity.TeliphoneTwo);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Resume, entity.Resume);

                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CVContactRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_CVContactRepositoryConstants.ContactID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ContactID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CVContactRepositoryConstants.ContactID].Value);

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

        public async static Task<ResultList<Plugin_CVContactEntity>> SelectByAdmissionID(long JobApplicationID)
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVContactEntity> list = new List<Plugin_CVContactEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVContactRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CVContactEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CVContactEntity> SelectByAdmissionIDNotAsync(long JobApplicationID)
        {
            ResultList<Plugin_CVContactEntity> result = new ResultList<Plugin_CVContactEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CVContactRepositoryConstants.SelectByAdmissionID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CVContactEntity> list = new List<Plugin_CVContactEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CVContactRepositoryConstants.JobApplicationID, JobApplicationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CVContactEntity entity = EntityHelper(reader, false);
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

        static Plugin_CVContactEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CVContactEntity entity = new Plugin_CVContactEntity();


            entity.ContactID = Convert.ToInt64(reader[Plugin_CVContactEntityConstants.ContactID].ToString());
            entity.JobApplicationID = reader[Plugin_CVContactEntityConstants.JobApplicationID] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CVContactEntityConstants.JobApplicationID].ToString());
            entity.Provenance = reader[Plugin_CVContactEntityConstants.Provenance] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_CVContactEntityConstants.Provenance].ToString());
            entity.AreaOne = reader[Plugin_CVContactEntityConstants.AreaOne] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_CVContactEntityConstants.AreaOne].ToString());
            entity.AreaTwo = reader[Plugin_CVContactEntityConstants.AreaTwo] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_CVContactEntityConstants.AreaTwo].ToString());
            entity.Street = reader[Plugin_CVContactEntityConstants.Street] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.Street].ToString();
            entity.Building = reader[Plugin_CVContactEntityConstants.Building] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.Building].ToString();
            entity.BuildingNumber = reader[Plugin_CVContactEntityConstants.BuildingNumber] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.BuildingNumber].ToString();
            entity.TeliphoneOne = reader[Plugin_CVContactEntityConstants.TeliphoneOne] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.TeliphoneOne].ToString();
            entity.TeliphoneTwo = reader[Plugin_CVContactEntityConstants.TeliphoneTwo] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.TeliphoneTwo].ToString();
            entity.Email = reader[Plugin_CVContactEntityConstants.Email] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.Email].ToString();
            entity.Resume = reader[Plugin_CVContactEntityConstants.Resume] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.Resume].ToString();



            entity.Order = reader[Plugin_CVContactEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[Plugin_CVContactEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_CVContactEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_CVContactEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_CVContactEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CVContactEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_CVContactEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_CVContactEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_CVContactEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_CVContactEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_CVContactEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CVContactEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_CVContactEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_CVContactEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_CVContactEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_CVContactEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_CVContactEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_CVContactEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
