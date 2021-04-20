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
   public static class E_Plugin_UserTypeRepository
    {
        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> SelectByID(int ID)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(E_Plugin_UserTypeRepositoryConstants.ID, ID));
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

        public async static Task<ResultList<E_Plugin_UserTypeEntity>> SelectAll()
        {
            ResultList<E_Plugin_UserTypeEntity> result = new ResultList<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_UserTypeEntity> list = new List<E_Plugin_UserTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    E_Plugin_UserTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<E_Plugin_UserTypeEntity> SelectAllNotAsync()
        {
            ResultList<E_Plugin_UserTypeEntity> result = new ResultList<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<E_Plugin_UserTypeEntity> list = new List<E_Plugin_UserTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    E_Plugin_UserTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> Update(E_Plugin_UserTypeEntity entity)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IconHover, entity.IconHover);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ID, entity.ID);

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

        public static ResultEntity<E_Plugin_UserTypeEntity> UpdateNotAsync(E_Plugin_UserTypeEntity entity)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IconHover, entity.IconHover);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ID, entity.ID);

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


        //public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> UpdateByIsDeleted(E_Plugin_UserTypeEntity entity)
        //{

        //    ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> Insert(E_Plugin_UserTypeEntity entity)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IconHover, entity.IconHover);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_UserTypeRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
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
        public static ResultEntity<E_Plugin_UserTypeEntity> InsertNotAsync(E_Plugin_UserTypeEntity entity)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ServiceTypeID, entity.ServiceTypeID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IconHover, entity.IconHover);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(E_Plugin_UserTypeRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
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

        public async static Task<ResultEntity<E_Plugin_UserTypeEntity>> Delete(E_Plugin_UserTypeEntity entity)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ID, entity.ID);

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
        public static ResultEntity<E_Plugin_UserTypeEntity> DeleteNotAsync(E_Plugin_UserTypeEntity entity)
        {

            ResultEntity<E_Plugin_UserTypeEntity> result = new ResultEntity<E_Plugin_UserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(E_Plugin_UserTypeRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(E_Plugin_UserTypeRepositoryConstants.ID, entity.ID);

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

        static E_Plugin_UserTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            E_Plugin_UserTypeEntity entity = new E_Plugin_UserTypeEntity();

            entity.ID = Convert.ToInt64(reader[E_Plugin_UserTypeEntityConstants.ID].ToString());
            entity.Title = reader[E_Plugin_UserTypeEntityConstants.Title] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_UserTypeEntityConstants.Title]);
            entity.Icon = reader[E_Plugin_UserTypeEntityConstants.Icon] == DBNull.Value ? string.Empty : Convert.ToString(reader[E_Plugin_UserTypeEntityConstants.Icon]);
            entity.ServiceTypeID = reader[E_Plugin_UserTypeEntityConstants.ServiceTypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[E_Plugin_UserTypeEntityConstants.ServiceTypeID]);

            entity.Order = Convert.ToInt64(reader[E_Plugin_UserTypeEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[E_Plugin_UserTypeEntityConstants.LanguageID].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[E_Plugin_UserTypeEntityConstants.PublishedDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[E_Plugin_UserTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[E_Plugin_UserTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[E_Plugin_UserTypeEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[E_Plugin_UserTypeEntityConstants.EditDate].ToString());
            entity.AddUser = reader[E_Plugin_UserTypeEntityConstants.AddUser].ToString();
            entity.EditUser = reader[E_Plugin_UserTypeEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[E_Plugin_UserTypeEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[E_Plugin_UserTypeEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("IconHover");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IconHover = reader[E_Plugin_UserTypeEntityConstants.IconHover] == DBNull.Value ? string.Empty : reader[E_Plugin_UserTypeEntityConstants.IconHover].ToString();
            }

            return entity;
        }

    }
}
