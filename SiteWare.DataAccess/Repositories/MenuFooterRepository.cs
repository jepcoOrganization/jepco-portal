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
    public static class MenuFooterRepository
    {
        public async static Task<ResultEntity<MenuFooterEntity>> SelectByID(int ID)
        {

            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MenuFooterRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(MenuFooterRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<MenuFooterEntity>> SelectAll()
        {
            ResultList<MenuFooterEntity> result = new ResultList<MenuFooterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MenuFooterRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MenuFooterEntity> list = new List<MenuFooterEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    MenuFooterEntity entity = EntityHelper(reader, false);
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
        public static ResultList<MenuFooterEntity> SelectAllWithoutAsync()
        {
            ResultList<MenuFooterEntity> result = new ResultList<MenuFooterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MenuFooterRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MenuFooterEntity> list = new List<MenuFooterEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    MenuFooterEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<MenuFooterEntity>> Insert(MenuFooterEntity entity)
        {

            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MenuFooterRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<MenuFooterEntity>> Update(MenuFooterEntity entity)
        {

            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MenuFooterRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.Title, entity.Title);                
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<MenuFooterEntity>> UpdateByIsDeleted(MenuFooterEntity entity)
        {

            ResultEntity<MenuFooterEntity> result = new ResultEntity<MenuFooterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MenuFooterRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(MenuFooterRepositoryConstants.ID, entity.ID);

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
        static MenuFooterEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            MenuFooterEntity entity = new MenuFooterEntity();

            entity.ID = Convert.ToInt32(reader[MenuFooterEntityConstants.ID].ToString());
            entity.Title = reader[MenuFooterEntityConstants.Title].ToString();
            entity.URL = reader[MenuFooterEntityConstants.URL].ToString();
            entity.Target = reader[MenuFooterEntityConstants.Target].ToString();
            entity.LanguageID = Convert.ToByte(reader[MenuFooterEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[MenuFooterEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[MenuFooterEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[MenuFooterEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[MenuFooterEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[MenuFooterEntityConstants.EditDate].ToString());
            entity.AddUser = reader[MenuFooterEntityConstants.AddUser].ToString();
            entity.EditUser = reader[MenuFooterEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
