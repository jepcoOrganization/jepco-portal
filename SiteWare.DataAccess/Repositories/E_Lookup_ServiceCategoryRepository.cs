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
   public static class E_Lookup_ServiceCategoryRepository
    {
        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> SelectByID(int ID)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Lookup_ServiceCategoryRepositoryConstants.ID, ID));
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


        public async static Task<ResultList<E_Lookup_ServiceCategoryEntity>> SelectAll()
        {
            ResultList<E_Lookup_ServiceCategoryEntity> result = new ResultList<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_SelectAll, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            List<E_Lookup_ServiceCategoryEntity> list = new List<E_Lookup_ServiceCategoryEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Lookup_ServiceCategoryEntity entity = EntityHelper(reader, false);
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

        public static ResultList<E_Lookup_ServiceCategoryEntity> SelectAllNotAsync()
        {
            ResultList<E_Lookup_ServiceCategoryEntity> result = new ResultList<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ServiceUserTypeRepositoryConstants.SP_SelectAll, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            List<E_Lookup_ServiceCategoryEntity> list = new List<E_Lookup_ServiceCategoryEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Lookup_ServiceCategoryEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> Update(E_Lookup_ServiceCategoryEntity entity)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.Name, entity.Name);
                
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<E_Lookup_ServiceCategoryEntity> UpdateNotAsync(E_Lookup_ServiceCategoryEntity entity)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsDeleted, entity.IsDeleted);

                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.ID, entity.ID);

                sqlCommand.ExecuteNonQuery();
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


        //public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> UpdateByIsDeleted(E_Lookup_ServiceCategoryEntity entity)
        //{

        //    ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.ID, entity.ID);

        //        await sqlCommand.ExecuteNonQueryAsync();
        //        result.Entity = entity;

        //        result.Status = ErrorEnums.Success;
        //        result.Message = MessageConstants.UpdateSuccessMessage;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Status = ErrorEnums.Exception;
        //        result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        sqlConnection.Dispose();
        //        sqlCommand.Dispose();
        //    }

        //    return result;
        //}

        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> Insert(E_Lookup_ServiceCategoryEntity entity)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Lookup_ServiceCategoryRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
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
        public static ResultEntity<E_Lookup_ServiceCategoryEntity> InsertNotAsync(E_Lookup_ServiceCategoryEntity entity)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Lookup_ServiceCategoryRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
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

        public async static Task<ResultEntity<E_Lookup_ServiceCategoryEntity>> Delete(E_Lookup_ServiceCategoryEntity entity)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.ID, entity.ID);

                await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;


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
        public static ResultEntity<E_Lookup_ServiceCategoryEntity> DeleteNotAsync(E_Lookup_ServiceCategoryEntity entity)
        {

            ResultEntity<E_Lookup_ServiceCategoryEntity> result = new ResultEntity<E_Lookup_ServiceCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Lookup_ServiceCategoryRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Lookup_ServiceCategoryRepositoryConstants.ID, entity.ID);

                sqlCommand.ExecuteReader();
                result.Entity = entity;


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


        static E_Lookup_ServiceCategoryEntity EntityHelper(SqlDataReader reader, bool v)
        {

            E_Lookup_ServiceCategoryEntity entity = new E_Lookup_ServiceCategoryEntity();
            entity.ID = Convert.ToInt32(reader[E_Lookup_ServiceCategoryEntityConstants.ID].ToString());
            entity.Name = reader[E_Lookup_ServiceCategoryEntityConstants.Name].ToString();
            entity.IsDeleted = Convert.ToBoolean(reader[E_Lookup_ServiceCategoryEntityConstants.IsDeleted].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[E_Lookup_ServiceCategoryEntityConstants.IsPublished].ToString());
            entity.AddUser = Convert.ToString(reader[E_Lookup_ServiceCategoryEntityConstants.AddUser].ToString());
            entity.AddDate = Convert.ToDateTime(reader[E_Lookup_ServiceCategoryEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[E_Lookup_ServiceCategoryEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToString(reader[E_Lookup_ServiceCategoryEntityConstants.EditUser].ToString());

            return entity;
        }

    }
}
