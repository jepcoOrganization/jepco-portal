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
   public static class E_Plugin_ServiceStepRepository
    {
        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> SelectByID(int ID)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceStepRepositoryConstants.ID, ID));
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

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> SelectByServiceTypeID(int ID)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectByEServiceID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceStepRepositoryConstants.ServiceTypeID, ID));
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
        public static ResultEntity<E_Plugin_ServiceStepEntity> SelectByServiceTypeIDNotAsync(int ID)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectByEServiceID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceStepRepositoryConstants.ServiceTypeID, ID));
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
        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> SelectByUserTypeID(int ID)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectByUserTypeID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceStepRepositoryConstants.UserTypeID, ID));
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
        public static ResultEntity<E_Plugin_ServiceStepEntity> SelectByUserTypeIDNotAsync(int ID)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectByUserTypeID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceStepRepositoryConstants.UserTypeID, ID));
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


        public async static Task<ResultList<E_Plugin_ServiceStepEntity>> SelectAll()
        {
            ResultList<E_Plugin_ServiceStepEntity> result = new ResultList<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceStepEntity> list = new List<E_Plugin_ServiceStepEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Plugin_ServiceStepEntity entity = EntityHelper(reader, false);
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

        public static ResultList<E_Plugin_ServiceStepEntity> SelectAllNotAsync()
        {
            ResultList<E_Plugin_ServiceStepEntity> result = new ResultList<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceStepEntity> list = new List<E_Plugin_ServiceStepEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Plugin_ServiceStepEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> Update(E_Plugin_ServiceStepEntity entity)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.StepTitle, entity.StepTitle);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsDeleted, entity.IsDeleted);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<E_Plugin_ServiceStepEntity> UpdateNotAsync(E_Plugin_ServiceStepEntity entity)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.StepTitle, entity.StepTitle);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsDeleted, entity.IsDeleted);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ID, entity.ID);

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


        //public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> UpdateByIsDeleted(E_Plugin_ServiceStepEntity entity)
        //{

        //    ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> Insert(E_Plugin_ServiceStepEntity entity)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.StepTitle, entity.StepTitle);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ServiceStepRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[E_Plugin_ServiceStepRepositoryConstants.ID].Value);

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
        public static ResultEntity<E_Plugin_ServiceStepEntity> InsertNotAsync(E_Plugin_ServiceStepEntity entity)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.StepTitle, entity.StepTitle);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ServiceStepRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[E_Plugin_ServiceStepRepositoryConstants.ID].Value);

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

        public async static Task<ResultEntity<E_Plugin_ServiceStepEntity>> Delete(E_Plugin_ServiceStepEntity entity)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ID, entity.ID);

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
        public static ResultEntity<E_Plugin_ServiceStepEntity> DeleteNotAsync(E_Plugin_ServiceStepEntity entity)
        {

            ResultEntity<E_Plugin_ServiceStepEntity> result = new ResultEntity<E_Plugin_ServiceStepEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceStepRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceStepRepositoryConstants.ID, entity.ID);

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

        static E_Plugin_ServiceStepEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            E_Plugin_ServiceStepEntity entity = new E_Plugin_ServiceStepEntity();

            entity.ID = Convert.ToInt64(reader[E_Plugin_ServiceStepEntityConstants.ID].ToString());
            entity.StepTitle = reader[E_Plugin_ServiceStepEntityConstants.StepTitle] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceStepEntityConstants.StepTitle]);
            entity.UserTypeID = reader[E_Plugin_ServiceStepEntityConstants.UserTypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ServiceStepEntityConstants.UserTypeID]);
            
            entity.Order = Convert.ToInt64(reader[E_Plugin_ServiceStepEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[E_Plugin_ServiceStepEntityConstants.LanguageID].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[E_Plugin_ServiceStepEntityConstants.PublishedDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[E_Plugin_ServiceStepEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[E_Plugin_ServiceStepEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[E_Plugin_ServiceStepEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[E_Plugin_ServiceStepEntityConstants.EditDate].ToString());
            entity.AddUser = reader[E_Plugin_ServiceStepEntityConstants.AddUser].ToString();
            entity.EditUser = reader[E_Plugin_ServiceStepEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[E_Plugin_ServiceStepEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[E_Plugin_ServiceStepEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ServiceTypeID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ServiceTypeID = reader[E_Plugin_ServiceStepEntityConstants.LanguageName] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ServiceStepEntityConstants.ServiceTypeID].ToString());
            }

            return entity;
        }

    }
}
