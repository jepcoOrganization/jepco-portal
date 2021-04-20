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
   public static class Plugin_FinancePerformanceRepository
    {
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> SelectByID(int FinanceID)
        {

            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FinancePerformanceRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_FinancePerformanceRepositoryConstants.FinanceID, FinanceID));
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
        public async static Task<ResultList<Plugin_FinancePerformanceEntity>> SelectAll()
        {
            ResultList<Plugin_FinancePerformanceEntity> result = new ResultList<Plugin_FinancePerformanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FinancePerformanceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_FinancePerformanceEntity> list = new List<Plugin_FinancePerformanceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_FinancePerformanceEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_FinancePerformanceEntity> SelectAllWithoutAsync()
        {
            ResultList<Plugin_FinancePerformanceEntity> result = new ResultList<Plugin_FinancePerformanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FinancePerformanceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_FinancePerformanceEntity> list = new List<Plugin_FinancePerformanceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_FinancePerformanceEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> Insert(Plugin_FinancePerformanceEntity entity)
        {

            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FinancePerformanceRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Description, entity.Description);

                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.Add(Plugin_FinancePerformanceRepositoryConstants.FinanceID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.FinanceID = Convert.ToInt64(sqlCommand.Parameters[Plugin_FinancePerformanceRepositoryConstants.FinanceID].Value);

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
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> Update(Plugin_FinancePerformanceEntity entity)
        {

            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FinancePerformanceRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Title2, entity.Title2);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Description, entity.Description);

                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.FinanceID, entity.FinanceID);

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
        public async static Task<ResultEntity<Plugin_FinancePerformanceEntity>> UpdateByIsDeleted(Plugin_FinancePerformanceEntity entity)
        {

            ResultEntity<Plugin_FinancePerformanceEntity> result = new ResultEntity<Plugin_FinancePerformanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_FinancePerformanceRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_FinancePerformanceRepositoryConstants.FinanceID, entity.FinanceID);

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
        static Plugin_FinancePerformanceEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_FinancePerformanceEntity entity = new Plugin_FinancePerformanceEntity();


            entity.FinanceID = Convert.ToInt64(reader[Plugin_FinancePerformanceEntityConstants.FinanceID].ToString());
            entity.Title = reader[Plugin_FinancePerformanceEntityConstants.Title] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Title].ToString();
            entity.Summary = reader[Plugin_FinancePerformanceEntityConstants.Summary] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Summary].ToString();
            entity.Image = reader[Plugin_FinancePerformanceEntityConstants.Image] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Image].ToString();
            entity.Title2 = reader[Plugin_FinancePerformanceEntityConstants.Title2] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Title2].ToString();
            entity.Description = reader[Plugin_FinancePerformanceEntityConstants.Description] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Description].ToString();
            entity.ParentID = reader[Plugin_FinancePerformanceEntityConstants.ParentID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_FinancePerformanceEntityConstants.ParentID].ToString());
            entity.Link = reader[Plugin_FinancePerformanceEntityConstants.Link] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Link].ToString();
            entity.Target = reader[Plugin_FinancePerformanceEntityConstants.Target] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.Target].ToString();
            entity.Order = reader[Plugin_FinancePerformanceEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_FinancePerformanceEntityConstants.Order].ToString());
            entity.LanguageID = reader[Plugin_FinancePerformanceEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Plugin_FinancePerformanceEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Plugin_FinancePerformanceEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_FinancePerformanceEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Plugin_FinancePerformanceEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Plugin_FinancePerformanceEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Plugin_FinancePerformanceEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Plugin_FinancePerformanceEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Plugin_FinancePerformanceEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_FinancePerformanceEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_FinancePerformanceEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Plugin_FinancePerformanceEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Plugin_FinancePerformanceEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_FinancePerformanceEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[Plugin_FinancePerformanceEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[Plugin_FinancePerformanceEntityConstants.LanguageName].ToString();
            }

            return entity;
        }

    }
}
