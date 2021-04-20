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
    public static class E_Plugin_ServiceTypeRepository
    {
        public async static Task<ResultList<E_Plugin_ServiceTypeEntity>> SelectByParentMenu()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectByParentMenu, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceTypeEntity> list = new List<E_Plugin_ServiceTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Plugin_ServiceTypeEntity entity = EntityHelper(reader, false);
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
        public static ResultList<E_Plugin_ServiceTypeEntity> SelectByParentMenuNotAsync()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectByParentMenu, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceTypeEntity> list = new List<E_Plugin_ServiceTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Plugin_ServiceTypeEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> SelectByID(int ID)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceTypeRepositoryConstants.ID, ID));
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

        public  static ResultEntity<E_Plugin_ServiceTypeEntity> SelectByIDNotAsync(int ID)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceTypeRepositoryConstants.ID, ID));
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
   
        public async static Task<ResultList<E_Plugin_ServiceTypeEntity>> SelectAll()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceTypeEntity> list = new List<E_Plugin_ServiceTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Plugin_ServiceTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<E_Plugin_ServiceTypeEntity> SelectAllNotAsync()
        {
            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceTypeEntity> list = new List<E_Plugin_ServiceTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Plugin_ServiceTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<E_Plugin_ServiceTypeEntity>> SelectByParentID(int ParentMenuID)
        {

            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectByParentID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceTypeEntity> list = new List<E_Plugin_ServiceTypeEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceTypeRepositoryConstants.ParentID, ParentMenuID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    E_Plugin_ServiceTypeEntity entity = EntityHelper(reader, false);
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
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public static ResultList<E_Plugin_ServiceTypeEntity> SelectByParentIDNotAsync(int ParentMenuID)
        {

            ResultList<E_Plugin_ServiceTypeEntity> result = new ResultList<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_SelectByParentID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceTypeEntity> list = new List<E_Plugin_ServiceTypeEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceTypeRepositoryConstants.ParentID, ParentMenuID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    E_Plugin_ServiceTypeEntity entity = EntityHelper(reader, false);
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
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
     
        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> Update(E_Plugin_ServiceTypeEntity entity)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ServiceName, entity.ServiceName);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.HasUserType, entity.HasUserType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EServiceID, entity.EServiceID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<E_Plugin_ServiceTypeEntity> UpdateNotAsync(E_Plugin_ServiceTypeEntity entity)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ServiceName, entity.ServiceName);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EServiceID, entity.EServiceID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.HasUserType, entity.HasUserType);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsPublished, entity.IsPublished);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ID, entity.ID);

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


        //public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> UpdateByIsDeleted(E_Plugin_ServiceTypeEntity entity)
        //{

        //    ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> Insert(E_Plugin_ServiceTypeEntity entity)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ServiceName, entity.ServiceName);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EServiceID, entity.EServiceID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.HasUserType, entity.HasUserType);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ServiceTypeRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[E_Plugin_ServiceTypeRepositoryConstants.ID].Value);

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
        public static ResultEntity<E_Plugin_ServiceTypeEntity> InsertNotAsync(E_Plugin_ServiceTypeEntity entity)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ServiceName, entity.ServiceName);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EServiceID, entity.EServiceID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.HasUserType, entity.HasUserType);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ServiceTypeRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[E_Plugin_ServiceTypeRepositoryConstants.ID].Value);
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

        public async static Task<ResultEntity<E_Plugin_ServiceTypeEntity>> Delete(int ID)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ID, ID);

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
        public static ResultEntity<E_Plugin_ServiceTypeEntity> DeleteNotAsync(int ID)
        {

            ResultEntity<E_Plugin_ServiceTypeEntity> result = new ResultEntity<E_Plugin_ServiceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceTypeRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceTypeRepositoryConstants.ID, ID);

                sqlCommand.ExecuteReader();
               

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

        static E_Plugin_ServiceTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            E_Plugin_ServiceTypeEntity entity = new E_Plugin_ServiceTypeEntity();

            entity.ID = Convert.ToInt64(reader[E_Plugin_ServiceTypeEntityConstants.ID].ToString());
            entity.ServiceName = reader[E_Plugin_ServiceTypeEntityConstants.ServiceName] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceTypeEntityConstants.ServiceName]);
            entity.ParentID = reader[E_Plugin_ServiceTypeEntityConstants.ParentID] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ServiceTypeEntityConstants.ParentID]);
            entity.EServiceID = reader[E_Plugin_ServiceTypeEntityConstants.EServiceID] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ServiceTypeEntityConstants.EServiceID]);
            entity.HasUserType = reader[E_Plugin_ServiceTypeEntityConstants.HasUserType] == DBNull.Value ? false : Convert.ToBoolean(reader[E_Plugin_ServiceTypeEntityConstants.HasUserType]);

            entity.Order = Convert.ToInt64(reader[E_Plugin_ServiceTypeEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[E_Plugin_ServiceTypeEntityConstants.LanguageID].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[E_Plugin_ServiceTypeEntityConstants.PublishedDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[E_Plugin_ServiceTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[E_Plugin_ServiceTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[E_Plugin_ServiceTypeEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[E_Plugin_ServiceTypeEntityConstants.EditDate].ToString());
            entity.AddUser = reader[E_Plugin_ServiceTypeEntityConstants.AddUser].ToString();
            entity.EditUser = reader[E_Plugin_ServiceTypeEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[E_Plugin_ServiceTypeEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[E_Plugin_ServiceTypeEntityConstants.LanguageName].ToString();
            }

            return entity;
        }


    }
}
