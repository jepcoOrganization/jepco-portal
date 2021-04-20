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
    public static class PluginServiceRepository
    {

        public async static Task<ResultEntity<PluginServiceEntity>> SelectByID(int ID)
        {

            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginServiceRepositoryConstants.ID, ID));
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

        public async static Task<ResultList<PluginServiceEntity>> SelectAll()
        {
            ResultList<PluginServiceEntity> result = new ResultList<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginServiceEntity> list = new List<PluginServiceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginServiceEntity entity = EntityHelper(reader, false);
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

        public static ResultList<PluginServiceEntity> SelectAllNotAsync()
        {
            ResultList<PluginServiceEntity> result = new ResultList<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginServiceEntity> list = new List<PluginServiceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginServiceEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<PluginServiceEntity>> Update(PluginServiceEntity entity)
        {

            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            //try
            //{
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceName, entity.ServiceName);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Page, entity.Page);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Color, entity.Color);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ShowonSlider, entity.ShowonSlider);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceIcon, entity.ServiceIcon);
                //sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceType, entity.ServiceType);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.UserMustLoggedin, entity.UserMustLoggedin);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceTabID, entity.ServiceTabID);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Target, entity.Target);                
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.IsPublished, entity.IsPublished);                
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Image2, entity.Image2);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ID, entity.ID);

                await sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
            //}
            //catch (Exception ex)
            //{
            //    result.Status = ErrorEnums.Exception;
            //    result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //    sqlConnection.Dispose();
            //    sqlCommand.Dispose();
            //}

            return result;
        }

        public async static Task<ResultEntity<PluginServiceEntity>> UpdateByIsDeleted(PluginServiceEntity entity)
        {

            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<PluginServiceEntity>> Insert(PluginServiceEntity entity)
        {

            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceName, entity.ServiceName);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Page, entity.Page);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Color, entity.Color);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ShowonSlider, entity.ShowonSlider);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceIcon, entity.ServiceIcon);
                //sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceType, entity.ServiceType);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.UserMustLoggedin, entity.UserMustLoggedin);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ServiceTabID, entity.ServiceTabID);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.EditUser, entity.EditUser); 
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.Image2, entity.Image2);

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

        public async static Task<ResultEntity<PluginServiceEntity>> Delete(PluginServiceEntity entity)
        {

            ResultEntity<PluginServiceEntity> result = new ResultEntity<PluginServiceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginServiceRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginServiceRepositoryConstants.ID, entity.ID);

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

        static PluginServiceEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginServiceEntity entity = new PluginServiceEntity();

            entity.ID = Convert.ToInt32(reader[PluginServiceEntityConstants.ID].ToString());            
            entity.ServiceName = reader[PluginServiceEntityConstants.ServiceName].ToString();
            entity.Title = reader[PluginServiceEntityConstants.Title].ToString();
            entity.Page = reader[PluginServiceEntityConstants.Page].ToString();
            entity.Color = reader[PluginServiceEntityConstants.Color].ToString();
            entity.ShowonSlider = Convert.ToBoolean(reader[PluginServiceEntityConstants.ShowonSlider].ToString());
            entity.ServiceIcon = reader[PluginServiceEntityConstants.ServiceIcon].ToString();
            //entity.ServiceType = reader[PluginServiceEntityConstants.ServiceType].ToString();
            entity.UserMustLoggedin = Convert.ToBoolean(reader[PluginServiceEntityConstants.UserMustLoggedin].ToString());
            entity.ServiceTabID = Convert.ToInt32(reader[PluginServiceEntityConstants.ServiceTabID].ToString());
            entity.Target = reader[PluginServiceEntityConstants.Target].ToString();
            entity.Order = Convert.ToInt64(reader[PluginServiceEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[PluginServiceEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[PluginServiceEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[PluginServiceEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[PluginServiceEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[PluginServiceEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PluginServiceEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PluginServiceEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PluginServiceEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[PluginServiceEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[PluginServiceEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("Image");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Image = reader[PluginServiceEntityConstants.Image] == DBNull.Value ? string.Empty : reader[PluginServiceEntityConstants.Image].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("Image2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Image2 = reader[PluginServiceEntityConstants.Image2] == DBNull.Value ? string.Empty : reader[PluginServiceEntityConstants.Image2].ToString();
            }
           

            return entity;
        }
    }
}
