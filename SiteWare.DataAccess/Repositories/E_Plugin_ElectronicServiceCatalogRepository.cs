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
   public static class E_Plugin_ElectronicServiceCatalogRepository
    {


        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> SelectByID(int ElectronicServiceID)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, ElectronicServiceID));
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

        public  static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> SelectByIDNotAsync(int ElectronicServiceID)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, ElectronicServiceID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
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


        public async static Task<ResultList<E_Plugin_ElectronicServiceCatalogEntity>> SelectAll()
        {
            ResultList<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultList<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ElectronicServiceCatalogEntity> list = new List<E_Plugin_ElectronicServiceCatalogEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Plugin_ElectronicServiceCatalogEntity entity = EntityHelper(reader, false);
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

        public static ResultList<E_Plugin_ElectronicServiceCatalogEntity> SelectAllNotAsync()
        {
            ResultList<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultList<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ElectronicServiceCatalogEntity> list = new List<E_Plugin_ElectronicServiceCatalogEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Plugin_ElectronicServiceCatalogEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> Update(E_Plugin_ElectronicServiceCatalogEntity entity)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            
            try
            {

            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Title, entity.Title);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceType, entity.ServiceType);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceCategory, entity.ServiceCategory);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.UserType, entity.UserType);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.HasUserType, entity.HasUserType);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Order, entity.Order);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.LanguageID, entity.LanguageID);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.PublishedDate, entity.PublishedDate);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.IsPublished, entity.IsPublished);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditDate, entity.EditDate);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditUser, entity.EditUser);
            sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, entity.ElectronicServiceID);

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

        public  static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> UpdateNotAsync(E_Plugin_ElectronicServiceCatalogEntity entity)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceType, entity.ServiceType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceCategory, entity.ServiceCategory);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.HasUserType, entity.HasUserType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, entity.ElectronicServiceID);

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


        //public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> UpdateByIsDeleted(E_Plugin_ElectronicServiceCatalogEntity entity)
        //{

        //    ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, entity.ElectronicServiceID);

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


        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> Insert(E_Plugin_ElectronicServiceCatalogEntity entity)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceType, entity.ServiceType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceCategory, entity.ServiceCategory);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.HasUserType, entity.HasUserType);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public  static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> InsertNotAsync(E_Plugin_ElectronicServiceCatalogEntity entity)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceType, entity.ServiceType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ServiceCategory, entity.ServiceCategory);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.UserType, entity.UserType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.HasUserType, entity.HasUserType);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader =  sqlCommand.ExecuteReader();
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


        public async static Task<ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>> Delete(E_Plugin_ElectronicServiceCatalogEntity entity)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, entity.ElectronicServiceID);

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

        public  static ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> DeleteNotAsync(E_Plugin_ElectronicServiceCatalogEntity entity)
        {

            ResultEntity<E_Plugin_ElectronicServiceCatalogEntity> result = new ResultEntity<E_Plugin_ElectronicServiceCatalogEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ElectronicServiceCatalogRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ElectronicServiceCatalogRepositoryConstants.ElectronicServiceID, entity.ElectronicServiceID);

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

        static E_Plugin_ElectronicServiceCatalogEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            E_Plugin_ElectronicServiceCatalogEntity entity = new E_Plugin_ElectronicServiceCatalogEntity();

            entity.ElectronicServiceID = Convert.ToInt64(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.ElectronicServiceID].ToString());
            entity.Title = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.Title] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.Title]);
            entity.ServiceType = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.ServiceType] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.ServiceType]);
            entity.ServiceCategory = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.ServiceCategory] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.ServiceCategory]);
            entity.UserType = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.UserType] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.UserType]);
            entity.HasUserType = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.HasUserType] == DBNull.Value ? false : Convert.ToBoolean(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.HasUserType]);

            entity.Order = Convert.ToInt64(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.LanguageID].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.PublishedDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[E_Plugin_ElectronicServiceCatalogEntityConstants.EditDate].ToString());
            entity.AddUser = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.AddUser].ToString();
            entity.EditUser = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[E_Plugin_ElectronicServiceCatalogEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[E_Plugin_ElectronicServiceCatalogEntityConstants.LanguageName].ToString();
            }
            
            return entity;
        }


    }
}
