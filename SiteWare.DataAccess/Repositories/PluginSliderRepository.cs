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
    public static class PluginSliderRepository
    {
        public static ResultList<PluginSliderEntity> SelectAllNotAsync()
        {
            ResultList<PluginSliderEntity> result = new ResultList<PluginSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSliderRepositoryConstants.Plugin_Slider_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSliderEntity> list = new List<PluginSliderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginSliderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginSliderEntity>> Plugin_Slider_SelectByID(int ID)
        {

            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSliderRepositoryConstants.Plugin_Slider_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginSliderRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<PluginSliderEntity>> SelectAll()
        {
            ResultList<PluginSliderEntity> result = new ResultList<PluginSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSliderRepositoryConstants.Plugin_Slider_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSliderEntity> list = new List<PluginSliderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginSliderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginSliderEntity>> Plugin_Slider_Update(PluginSliderEntity entity)
        {

            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSliderRepositoryConstants.Plugin_Slider_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Sammery, entity.Sammery);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.IconImage, entity.IconImage);
                

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
        public async static Task<ResultEntity<PluginSliderEntity>> Plugin_Slider_Insert(PluginSliderEntity entity)
        {

            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSliderRepositoryConstants.Plugin_Slider_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Sammery, entity.Sammery);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.ImageTitle, entity.ImageTitle);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.AltIamge, entity.AltIamge);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.IsPublish, entity.IsPublish);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginSliderRepositoryConstants.IconImage, entity.IconImage);              

                sqlCommand.Parameters.Add(PluginSliderRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginSliderRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginSliderEntity>> Plugin_Slider_Delete(int ID)
        {
            ResultEntity<PluginSliderEntity> result = new ResultEntity<PluginSliderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSliderRepositoryConstants.Plugin_Slider_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginSliderRepositoryConstants.ID, ID));
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
        static PluginSliderEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginSliderEntity entity = new PluginSliderEntity();

            entity.ID = Convert.ToInt32(reader[PluginSliderEntityConstants.ID].ToString());
            entity.Title = reader[PluginSliderEntityConstants.Title].ToString();
            entity.Image = reader[PluginSliderEntityConstants.Image].ToString();
            entity.Target = reader[PluginSliderEntityConstants.Target].ToString();
            entity.Sammery = reader[PluginSliderEntityConstants.Sammery].ToString();
            entity.LanguageID = Convert.ToInt32(reader[PluginSliderEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginSliderEntityConstants.IsDeleted].ToString());
            entity.ImageTitle = reader[PluginSliderEntityConstants.ImageTitle].ToString();            
            entity.AltIamge = reader[PluginSliderEntityConstants.AltIamge].ToString();
            entity.AddDate = Convert.ToDateTime(reader[PluginSliderEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginSliderEntityConstants.EditDate].ToString());
            entity.AddUser = Convert.ToInt32(reader[PluginSliderEntityConstants.AddUser].ToString());
            entity.EditUser = Convert.ToInt32(reader[PluginSliderEntityConstants.EditUser].ToString());
            entity.IsPublish = Convert.ToBoolean(reader[PluginSliderEntityConstants.IsPublish].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[PluginSliderEntityConstants.PublishDate].ToString());
            entity.Link = reader[PluginSliderEntityConstants.Link].ToString();            
            entity.IconImage = reader[PluginSliderEntityConstants.IconImage] == DBNull.Value ? string.Empty : reader[PluginSliderEntityConstants.IconImage].ToString();

            

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
                entity.LanguageName = reader[PluginSliderEntityConstants.LanguageName].ToString();
            }

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
                entity.Order = Convert.ToInt32(reader[PluginSliderEntityConstants.Order].ToString());
            }

            return entity;
        }
    }
}
