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
    public static class TypeusefullinksRepository
    {
        public static ResultList<TypeusefullinksEntity> SelectAllNotAsync()
        {
            ResultList<TypeusefullinksEntity> result = new ResultList<TypeusefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(TypeusefullinksRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<TypeusefullinksEntity> list = new List<TypeusefullinksEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    TypeusefullinksEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<TypeusefullinksEntity>> SelectByID(int ID)
        {

            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(TypeusefullinksRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(TypeusefullinksRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<TypeusefullinksEntity>> SelectAll()
        {
            ResultList<TypeusefullinksEntity> result = new ResultList<TypeusefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(TypeusefullinksRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<TypeusefullinksEntity> list = new List<TypeusefullinksEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    TypeusefullinksEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<TypeusefullinksEntity>> Insert(TypeusefullinksEntity entity)
        {

            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(TypeusefullinksRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.Tilte, entity.Tilte); 
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.LanguageID, entity.LanguageID); 
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<TypeusefullinksEntity>> Update(TypeusefullinksEntity entity)
        {

            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(TypeusefullinksRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.Tilte, entity.Tilte); 
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.LanguageID, entity.LanguageID); 
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<TypeusefullinksEntity>> UpdateByIsDeleted(TypeusefullinksEntity entity)
        {

            ResultEntity<TypeusefullinksEntity> result = new ResultEntity<TypeusefullinksEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(TypeusefullinksRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(TypeusefullinksRepositoryConstants.ID, entity.ID);

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
        static TypeusefullinksEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            TypeusefullinksEntity entity = new TypeusefullinksEntity();

            entity.ID = Convert.ToInt32(reader[TypeusefullinksEntityConstants.ID].ToString());
            entity.Tilte = reader[TypeusefullinksEntityConstants.Tilte].ToString(); 
            entity.LanguageID = Convert.ToByte(reader[TypeusefullinksEntityConstants.LanguageID].ToString()); 
            entity.IsDeleted = Convert.ToBoolean(reader[TypeusefullinksEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[TypeusefullinksEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[TypeusefullinksEntityConstants.EditDate].ToString());
            entity.AddUser = reader[TypeusefullinksEntityConstants.AddUser].ToString();
            entity.EditUser = reader[TypeusefullinksEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
