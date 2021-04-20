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
   public static class E_Plugin_ServiceInformationRepository
    {

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> SelectByID(int ID)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceInformationRepositoryConstants.ID, ID));
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
         public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> SelectByServiceTypeID(int ID)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectByEServiceID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceInformationRepositoryConstants.ServiceTypeID, ID));
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
         public  static ResultEntity<E_Plugin_ServiceInformationEntity> SelectByServiceTypeIDNotAsync(int ID)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectByEServiceID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceInformationRepositoryConstants.ServiceTypeID, ID));
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
        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> SelectByUserTypeID(int ID)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectByUserTypeID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceInformationRepositoryConstants.UserTypeID, ID));
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
         public  static ResultEntity<E_Plugin_ServiceInformationEntity> SelectByUserTypeIDNotAsync(int ID)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectByUserTypeID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_ServiceInformationRepositoryConstants.UserTypeID, ID));
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

        public async static Task<ResultList<E_Plugin_ServiceInformationEntity>> SelectAll()
        {
            ResultList<E_Plugin_ServiceInformationEntity> result = new ResultList<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceInformationEntity> list = new List<E_Plugin_ServiceInformationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Plugin_ServiceInformationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<E_Plugin_ServiceInformationEntity> SelectAllNotAsync()
        {
            ResultList<E_Plugin_ServiceInformationEntity> result = new ResultList<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_ServiceInformationEntity> list = new List<E_Plugin_ServiceInformationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Plugin_ServiceInformationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> Update(E_Plugin_ServiceInformationEntity entity)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Time, entity.Time);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Fees, entity.Fees);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Target, entity.Target);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsDeleted, entity.IsDeleted);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<E_Plugin_ServiceInformationEntity> UpdateNotAsync(E_Plugin_ServiceInformationEntity entity)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Time, entity.Time);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Fees, entity.Fees);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Target, entity.Target);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsDeleted, entity.IsDeleted);

                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ID, entity.ID);

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


        //public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> UpdateByIsDeleted(E_Plugin_ServiceInformationEntity entity)
        //{

        //    ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> Insert(E_Plugin_ServiceInformationEntity entity)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Time, entity.Time);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Fees, entity.Fees);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ServiceInformationRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
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
        public static ResultEntity<E_Plugin_ServiceInformationEntity> InsertNotAsync(E_Plugin_ServiceInformationEntity entity)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.UserTypeID, entity.UserTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Time, entity.Time);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Fees, entity.Fees);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_ServiceInformationRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public async static Task<ResultEntity<E_Plugin_ServiceInformationEntity>> Delete(E_Plugin_ServiceInformationEntity entity)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ID, entity.ID);

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
        public static ResultEntity<E_Plugin_ServiceInformationEntity> DeleteNotAsync(E_Plugin_ServiceInformationEntity entity)
        {

            ResultEntity<E_Plugin_ServiceInformationEntity> result = new ResultEntity<E_Plugin_ServiceInformationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_ServiceInformationRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_ServiceInformationRepositoryConstants.ID, entity.ID);

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

        static E_Plugin_ServiceInformationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            E_Plugin_ServiceInformationEntity entity = new E_Plugin_ServiceInformationEntity();

            entity.ID = Convert.ToInt64(reader[E_Plugin_ServiceInformationEntityConstants.ID].ToString());
            entity.Description = reader[E_Plugin_ServiceInformationEntityConstants.Description] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceInformationEntityConstants.Description]);
            entity.UserTypeID = reader[E_Plugin_ServiceInformationEntityConstants.UserTypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ServiceInformationEntityConstants.UserTypeID]);
            entity.Time = reader[E_Plugin_ServiceInformationEntityConstants.Time] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceInformationEntityConstants.Time]);
            entity.Fees = reader[E_Plugin_ServiceInformationEntityConstants.Fees] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceInformationEntityConstants.Fees]);
            entity.Link = reader[E_Plugin_ServiceInformationEntityConstants.Link] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceInformationEntityConstants.Link]);
            entity.Target = reader[E_Plugin_ServiceInformationEntityConstants.Target] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_ServiceInformationEntityConstants.Target]);

            entity.Order = Convert.ToInt64(reader[E_Plugin_ServiceInformationEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[E_Plugin_ServiceInformationEntityConstants.LanguageID].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[E_Plugin_ServiceInformationEntityConstants.PublishedDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[E_Plugin_ServiceInformationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[E_Plugin_ServiceInformationEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[E_Plugin_ServiceInformationEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[E_Plugin_ServiceInformationEntityConstants.EditDate].ToString());
            entity.AddUser = reader[E_Plugin_ServiceInformationEntityConstants.AddUser].ToString();
            entity.EditUser = reader[E_Plugin_ServiceInformationEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[E_Plugin_ServiceInformationEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[E_Plugin_ServiceInformationEntityConstants.LanguageName].ToString();
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
                entity.ServiceTypeID = reader[E_Plugin_ServiceInformationEntityConstants.ServiceTypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_ServiceInformationEntityConstants.ServiceTypeID].ToString());
            }

            return entity;
        }


    }
}
