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
    public static class Plugin_PriceRepository
    {
        public async static Task<ResultEntity<Plugin_PriceEntity>> SelectByID(long PriceID)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PriceRepositoryConstants.PriceID, PriceID));
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
        public static ResultEntity<Plugin_PriceEntity> SelectByIDNotAsync(long PriceID)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PriceRepositoryConstants.PriceID, PriceID));
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
        public async static Task<ResultList<Plugin_PriceEntity>> SelectAll()
        {
            ResultList<Plugin_PriceEntity> result = new ResultList<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PriceEntity> list = new List<Plugin_PriceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PriceEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_PriceEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_PriceEntity> result = new ResultList<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PriceEntity> list = new List<Plugin_PriceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PriceEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_PriceEntity>> Update(Plugin_PriceEntity entity)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PriceID, entity.PriceID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Summery, entity.Summery);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Prices, entity.Prices);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditUser, entity.EditUser);


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
        public static ResultEntity<Plugin_PriceEntity> UpdateNotAsync(Plugin_PriceEntity entity)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PriceID, entity.PriceID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Summery, entity.Summery);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Prices, entity.Prices);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.ExecuteNonQueryAsync();
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
        public async static Task<ResultEntity<Plugin_PriceEntity>> Delete(long PriceID)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PriceID, PriceID);

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
        public async static Task<ResultEntity<Plugin_PriceEntity>> Insert(Plugin_PriceEntity entity)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Summery, entity.Summery);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Prices, entity.Prices);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(Plugin_PriceRepositoryConstants.PriceID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.PriceID = Convert.ToInt64(sqlCommand.Parameters[Plugin_PriceRepositoryConstants.PriceID].Value);

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
        public static ResultEntity<Plugin_PriceEntity> InsertNotAsync(Plugin_PriceEntity entity)
        {

            ResultEntity<Plugin_PriceEntity> result = new ResultEntity<Plugin_PriceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PriceRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PriceID, entity.PriceID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Summery, entity.Summery);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Prices, entity.Prices);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Target, entity.Target);


                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PriceRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_PriceRepositoryConstants.PriceID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.PriceID = Convert.ToInt64(sqlCommand.Parameters[Plugin_PriceRepositoryConstants.PriceID].Value);

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

        static Plugin_PriceEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_PriceEntity entity = new Plugin_PriceEntity();


            entity.PriceID = Convert.ToInt64(reader[Plugin_PriceEntityConstants.PriceID].ToString());
            entity.Title = reader[Plugin_PriceEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.Title].ToString();
            entity.Summery = reader[Plugin_PriceEntityConstants.Summery] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.Summery].ToString();
            entity.Title2 = reader[Plugin_PriceEntityConstants.Title2] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.Title2].ToString();
            entity.Prices = reader[Plugin_PriceEntityConstants.Prices] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.Prices].ToString();
            entity.Link = reader[Plugin_PriceEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.Link].ToString();
            entity.Target = reader[Plugin_PriceEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.Target].ToString();
            entity.Order = reader[Plugin_PriceEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_PriceEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_PriceEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_PriceEntityConstants.LanguageID].ToString());
            entity.PublishedDate = reader[Plugin_PriceEntityConstants.PublishedDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_PriceEntityConstants.PublishedDate].ToString());
            entity.IsPublished = reader[Plugin_PriceEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_PriceEntityConstants.IsPublished].ToString());
            entity.IsDelete = reader[Plugin_PriceEntityConstants.IsDelete] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_PriceEntityConstants.IsDelete].ToString());
            entity.AddDate = reader[Plugin_PriceEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_PriceEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_PriceEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_PriceEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_PriceEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_PriceEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_PriceEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_PriceEntityConstants.LanguageName].ToString();
            }

            return entity;
        }

    }
}
