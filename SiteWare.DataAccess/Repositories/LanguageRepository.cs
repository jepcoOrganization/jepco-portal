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
    public static class LanguageRepository
    {
        public static ResultList<LanguageEntity> SelectAllNotAsync()
        {
            ResultList<LanguageEntity> result = new ResultList<LanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LanguageRepositoryConstants.Language_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<LanguageEntity> list = new List<LanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    LanguageEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<LanguageEntity>> Language_SelectByID(int ID)
        {

            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LanguageRepositoryConstants.Language_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(LanguageRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<LanguageEntity>> SelectAll()
        {
            ResultList<LanguageEntity> result = new ResultList<LanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LanguageRepositoryConstants.Language_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<LanguageEntity> list = new List<LanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    LanguageEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<LanguageEntity>> Language_Update(LanguageEntity entity)
        {

            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LanguageRepositoryConstants.Language_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<LanguageEntity>> Language_Insert(LanguageEntity entity)
        {

            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LanguageRepositoryConstants.Language_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(LanguageRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(LanguageRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[LanguageRepositoryConstants.ID].Value);

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


        public async static Task<ResultEntity<LanguageEntity>> Language_Delete(int ID)
        {
            ResultEntity<LanguageEntity> result = new ResultEntity<LanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(LanguageRepositoryConstants.Language_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(LanguageRepositoryConstants.ID, ID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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
        static LanguageEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            LanguageEntity entity = new LanguageEntity();

            entity.ID = Convert.ToInt32(reader[LanguageEntityConstants.LanguageID].ToString());
            entity.Name = reader[LanguageEntityConstants.Name].ToString();  
            entity.AddDate = Convert.ToDateTime(reader[LanguageEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[LanguageEntityConstants.EditDate].ToString());
            entity.AddUser = reader[LanguageEntityConstants.AddUser].ToString();
            entity.EditUser = reader[LanguageEntityConstants.EditUser].ToString();
            entity.IsDeleted = Convert.ToBoolean(reader[LanguageEntityConstants.IsDeleted].ToString());

            return entity;
        }
    }
}
