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
    public class Plugin_SecondSliderRepository
    {
        public static ResultList<Plugin_SecondSliderEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_SecondSliderEntity> result = new ResultList<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_SecondSliderEntity> list = new List<Plugin_SecondSliderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_SecondSliderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> Plugin_SecondSlider_SelectByID(long ID)
        {

            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_SecondSliderRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<Plugin_SecondSliderEntity>> SelectSecondSliderByCategory()
        {
            ResultList<Plugin_SecondSliderEntity> result = new ResultList<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_SecondSliderEntity> list = new List<Plugin_SecondSliderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_SecondSliderEntity entity = EntityHelper(reader, false);
                    if (entity.IsDeleted == false)
                    {
                        list.Add(entity);
                    }
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
        public async static Task<ResultList<Plugin_SecondSliderEntity>> SelectAll()
        {
            ResultList<Plugin_SecondSliderEntity> result = new ResultList<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_SecondSliderEntity> list = new List<Plugin_SecondSliderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_SecondSliderEntity entity = EntityHelper(reader, false);

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
        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> Plugin_SecondSlider_Update(Plugin_SecondSliderEntity entity)
        {

            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Brief, entity.Brief);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.EditUser, entity.EditUser);
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
        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> Plugin_SecondSlider_Insert(Plugin_SecondSliderEntity entity)
        {

            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(Plugin_SecondSliderRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Brief, entity.Brief);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_SecondSliderRepositoryConstants.EditUser, entity.EditUser);


                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[Plugin_SecondSliderRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<Plugin_SecondSliderEntity>> Plugin_SecondSlider_Delete(long ID)
        {
            ResultEntity<Plugin_SecondSliderEntity> result = new ResultEntity<Plugin_SecondSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_SecondSliderRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_SecondSliderRepositoryConstants.ID, ID));
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
        static Plugin_SecondSliderEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_SecondSliderEntity entity = new Plugin_SecondSliderEntity();
            try
            {
                entity.ID = Convert.ToInt64(reader[Plugin_SecondSliderEntityConstants.ID].ToString());
                entity.Image = reader[Plugin_SecondSliderEntityConstants.Image] == DBNull.Value ? string.Empty : reader[Plugin_SecondSliderEntityConstants.Image].ToString();
                entity.Title = reader[Plugin_SecondSliderEntityConstants.Title].ToString();
                entity.Brief = reader[Plugin_SecondSliderEntityConstants.Brief].ToString();
                entity.Link = reader[Plugin_SecondSliderEntityConstants.Link].ToString();
                entity.Target = reader[Plugin_SecondSliderEntityConstants.Target].ToString();
                entity.Order = Convert.ToInt32(reader[Plugin_SecondSliderEntityConstants.Order].ToString());
                entity.LanguageID = Convert.ToInt32(reader[Plugin_SecondSliderEntityConstants.LanguageID].ToString());
                entity.PublishedDate = Convert.ToDateTime(reader[Plugin_SecondSliderEntityConstants.PublishedDate].ToString());
                entity.IsPublished = Convert.ToBoolean(reader[Plugin_SecondSliderEntityConstants.IsPublished].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[Plugin_SecondSliderEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[Plugin_SecondSliderEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[Plugin_SecondSliderEntityConstants.EditDate].ToString());
                entity.AddUser = reader[Plugin_SecondSliderEntityConstants.AddUser].ToString();
                entity.EditUser = reader[Plugin_SecondSliderEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {
            }
            return entity;
        }
    }
}
