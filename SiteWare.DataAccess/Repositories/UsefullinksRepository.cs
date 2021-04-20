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
    public static class UsefullinksRepository
    {
        public static ResultList<UsefullinksEntity> SelectAllNotAsync()
        {
            ResultList<UsefullinksEntity> result = new ResultList<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<UsefullinksEntity> list = new List<UsefullinksEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    UsefullinksEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<UsefullinksEntity>> SelectByID(int ID)
        {

            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(UsefullinksRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<UsefullinksEntity>> SelectAll()
        {
            ResultList<UsefullinksEntity> result = new ResultList<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<UsefullinksEntity> list = new List<UsefullinksEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    UsefullinksEntity entity = EntityHelper(reader, false);
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
        public static ResultList<UsefullinksEntity> SelectByType(int Type)
        {
            ResultList<UsefullinksEntity> result = new ResultList<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_SelectByType, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<UsefullinksEntity> list = new List<UsefullinksEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(UsefullinksRepositoryConstants.Type, Type));
                SqlDataReader reader =  sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    UsefullinksEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<UsefullinksEntity>> Insert(UsefullinksEntity entity)
        {

            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.Type, entity.Type);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.Tilte, entity.Tilte);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<UsefullinksEntity>> Update(UsefullinksEntity entity)
        {

            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.Type, entity.Type);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.Tilte, entity.Tilte);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<UsefullinksEntity>> UpdateByIsDeleted(UsefullinksEntity entity)
        {

            ResultEntity<UsefullinksEntity> result = new ResultEntity<UsefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UsefullinksRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(UsefullinksRepositoryConstants.ID, entity.ID);

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
        static UsefullinksEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            UsefullinksEntity entity = new UsefullinksEntity();

            entity.ID = Convert.ToInt32(reader[UsefullinksEntityConstants.ID].ToString());
            entity.Type = Convert.ToInt32(reader[UsefullinksEntityConstants.Type].ToString());
            entity.Tilte = reader[UsefullinksEntityConstants.Tilte].ToString();
            entity.URL = reader[UsefullinksEntityConstants.URL].ToString();
            entity.Target = reader[UsefullinksEntityConstants.Target].ToString(); 
            entity.LanguageID = Convert.ToByte(reader[UsefullinksEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[UsefullinksEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[UsefullinksEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[UsefullinksEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[UsefullinksEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[UsefullinksEntityConstants.EditDate].ToString());
            entity.AddUser = reader[UsefullinksEntityConstants.AddUser].ToString();
            entity.EditUser = reader[UsefullinksEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
