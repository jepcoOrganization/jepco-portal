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
    public static class PluginPartnerRepository
    {
        public static ResultList<PluginPartnerEntity> SelectAllNotAsync()
        {
            ResultList<PluginPartnerEntity> result = new ResultList<PluginPartnerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginPartnerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginPartnerEntity> list = new List<PluginPartnerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginPartnerEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginPartnerEntity>> Plugin_Partner_SelectByID(int ID)
        {

            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginPartnerRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginPartnerRepositoryConstants.ID, ID));
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

        public async static Task<ResultList<PluginPartnerEntity>> SelectAll()
        {
            ResultList<PluginPartnerEntity> result = new ResultList<PluginPartnerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginPartnerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginPartnerEntity> list = new List<PluginPartnerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginPartnerEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginPartnerEntity>> Plugin_Partner_Update(PluginPartnerEntity entity)
        {

            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginPartnerRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.PublishDate, entity.PublishDate);

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

        public async static Task<ResultEntity<PluginPartnerEntity>> Plugin_Partner_Insert(PluginPartnerEntity entity)
        {

            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginPartnerRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginPartnerRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginBannerRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.Add(PluginPartnerRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginPartnerRepositoryConstants.ID].Value);

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

        public async static Task<ResultEntity<PluginPartnerEntity>> Plugin_Partner_Delete(int ID)
        {
            ResultEntity<PluginPartnerEntity> result = new ResultEntity<PluginPartnerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginPartnerRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginPartnerRepositoryConstants.ID, ID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.CannotUpdateDetails;
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

        static PluginPartnerEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginPartnerEntity entity = new PluginPartnerEntity();

            entity.ID = Convert.ToInt32(reader[PluginPartnerEntityConstants.ID].ToString());
            entity.Title = reader[PluginPartnerEntityConstants.Title].ToString();
            entity.Summary = reader[PluginPartnerEntityConstants.Summary].ToString();
            entity.Image = reader[PluginPartnerEntityConstants.Image].ToString();
            entity.URL = reader[PluginPartnerEntityConstants.URL].ToString();
            entity.LanguageID = Convert.ToInt32(reader[PluginPartnerEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginPartnerEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginPartnerEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginPartnerEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginPartnerEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginPartnerEntityConstants.EditUser].ToString();
            entity.Target = reader[PluginPartnerEntityConstants.Target].ToString();




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
                entity.LanguageName = Convert.ToString(reader[PluginPartnerEntityConstants.LanguageName]);
            }
            //------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("Order");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Order = reader[PluginPartnerEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt64(reader[PluginPartnerEntityConstants.Order].ToString());
            }
            else
            {
                entity.Order = 0;
            }

            //------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("PublishDate");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.PublishDate = reader[PluginBannerEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[PluginBannerEntityConstants.PublishDate].ToString());
            }
            else
            {
                entity.PublishDate = DateTime.Now;
            }

            //------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("IsPublished");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.IsPublished = reader[PluginBannerEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[PluginBannerEntityConstants.IsPublished].ToString());
            }
            else
            {
                entity.IsPublished = true;
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ParentID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ParentID = reader[PluginPartnerEntityConstants.ParentID] == DBNull.Value ? 0 : Convert.ToInt32(reader[PluginPartnerEntityConstants.ParentID].ToString());
            }
            return entity;
        }
    }
}
