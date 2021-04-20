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
    public static class PluginDataPointRepository
    {

        public async static Task<ResultEntity<PluginDataPointEntity>> SelectByID(int ID)
        {

            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginDataPointRepositoryConstants.ID, ID));
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

        public async static Task<ResultList<PluginDataPointEntity>> SelectAll()
        {
            ResultList<PluginDataPointEntity> result = new ResultList<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginDataPointEntity> list = new List<PluginDataPointEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginDataPointEntity entity = EntityHelper(reader, false);
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

        public static ResultList<PluginDataPointEntity> SelectAllNotAsync()
        {
            ResultList<PluginDataPointEntity> result = new ResultList<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginDataPointEntity> list = new List<PluginDataPointEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginDataPointEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginDataPointEntity>> Update(PluginDataPointEntity entity)
        {

            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Points, entity.Points);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.IsPublished, entity.IsPublished);                
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<PluginDataPointEntity>> UpdateByIsDeleted(PluginDataPointEntity entity)
        {

            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<PluginDataPointEntity>> Insert(PluginDataPointEntity entity)
        {

            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.FocusID, entity.FocusID);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Points, entity.Points);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<PluginDataPointEntity>> Delete(PluginDataPointEntity entity)
        {

            ResultEntity<PluginDataPointEntity> result = new ResultEntity<PluginDataPointEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginDataPointRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginDataPointRepositoryConstants.ID, entity.ID);

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

        static PluginDataPointEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginDataPointEntity entity = new PluginDataPointEntity();

            entity.ID = Convert.ToInt32(reader[PluginDataPointEntityConstants.ID].ToString());
            entity.FocusID = Convert.ToInt64(reader[PluginDataPointEntityConstants.FocusID].ToString());
            entity.Image = reader[PluginDataPointEntityConstants.Image].ToString();
            entity.Title = reader[PluginDataPointEntityConstants.Title].ToString();
            entity.Points = reader[PluginDataPointEntityConstants.Points].ToString();
            entity.Summary = reader[PluginDataPointEntityConstants.Summary].ToString();
            entity.Link = reader[PluginDataPointEntityConstants.Link].ToString();
            entity.Target = reader[PluginDataPointEntityConstants.Target].ToString();
            entity.Order = Convert.ToInt64(reader[PluginDataPointEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[PluginDataPointEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[PluginDataPointEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[PluginDataPointEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginDataPointEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginDataPointEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginDataPointEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginDataPointEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginDataPointEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[PluginDataPointEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[PluginDataPointEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("AreaName");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.AreaName = reader[PluginDataPointEntityConstants.AreaName] == DBNull.Value ? string.Empty : reader[PluginDataPointEntityConstants.AreaName].ToString();
            }

            return entity;
        }
    }
}
