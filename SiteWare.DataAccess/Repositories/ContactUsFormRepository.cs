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
    public static class ContactUsFormRepository
    {
        public static ResultList<ContactUsFormEntity> SelectAllNotAsync()
        {
            ResultList<ContactUsFormEntity> result = new ResultList<ContactUsFormEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ContactUsFormRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<ContactUsFormEntity> list = new List<ContactUsFormEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    ContactUsFormEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<ContactUsFormEntity>> SelectByID(int ID)
        {

            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ContactUsFormRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(ContactUsFormRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<ContactUsFormEntity>> SelectAll()
        {
            ResultList<ContactUsFormEntity> result = new ResultList<ContactUsFormEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ContactUsFormRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<ContactUsFormEntity> list = new List<ContactUsFormEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    ContactUsFormEntity entity = EntityHelper(reader, false);
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
        public  static ResultEntity<ContactUsFormEntity> Insert(ContactUsFormEntity entity)
        {

            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ContactUsFormRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.Name, entity.Name); 
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.Email, entity.Email);  
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.Message, entity.Message);
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.Contact, entity.Contact);
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.Add(ContactUsFormRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader =  sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[ContactUsFormRepositoryConstants.ID].Value);
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

        public async static Task<ResultEntity<ContactUsFormEntity>> UpdateByIsDeleted(ContactUsFormEntity entity)
        {

            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(ContactUsFormRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(ContactUsFormRepositoryConstants.ID, entity.ID);

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

        static ContactUsFormEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            ContactUsFormEntity entity = new ContactUsFormEntity();

            entity.ID = Convert.ToInt32(reader[ContactUsFormEntityConstants.ID].ToString());
            entity.Name = reader[ContactUsFormEntityConstants.Name].ToString(); 
            entity.Email = reader[ContactUsFormEntityConstants.Email].ToString(); 
            entity.Message = reader[ContactUsFormEntityConstants.Message].ToString();
            entity.Contact = Convert.ToInt64(reader[ContactUsFormEntityConstants.Contact]);
            entity.AddDate = Convert.ToDateTime(reader[ContactUsFormEntityConstants.AddDate].ToString());
            entity.Title = reader[ContactUsFormEntityConstants.Title].ToString();

            return entity;
        }
    }
}
