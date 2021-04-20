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
    public static class SecondNavigationRepository
    {
        public static ResultList<SecondNavigationEntity> SelectAllToWebSiteNotAsync()
        {
            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SecondNavigationEntity> list = new List<SecondNavigationEntity>();
            //sqlCommand.Parameters.Add(new SqlParameter(SecondNavigationRepositoryConstants.IsPublished, true));
            //sqlCommand.Parameters.Add(new SqlParameter(SecondNavigationRepositoryConstants.IsDeleted,false));
            //sqlCommand.Parameters.Add(new SqlParameter(SecondNavigationRepositoryConstants.ParentID, 0));
            try
            {
                sqlConnection.Open(); 
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    SecondNavigationEntity entity = EntityHelper(reader, false);
                    if(entity.IsPublished == true &&  entity.IsDeleted == false)
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
        public async static Task<ResultEntity<SecondNavigationEntity>> SelectByID(int ID)
        {

            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SecondNavigationRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<SecondNavigationEntity>> SelectAll()
        {
            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SecondNavigationEntity> list = new List<SecondNavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    SecondNavigationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<SecondNavigationEntity> SelectAllNotAsync()
        {
            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SecondNavigationEntity> list = new List<SecondNavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    SecondNavigationEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<SecondNavigationEntity>> SelectByParentMenuID(int ID)
        {

            ResultList<SecondNavigationEntity> result = new ResultList<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SecondNavigationEntity> list = new List<SecondNavigationEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SecondNavigationRepositoryConstants.ID, ID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    SecondNavigationEntity entity = EntityHelper(reader, false);
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
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        public async static Task<ResultEntity<SecondNavigationEntity>> Update(SecondNavigationEntity entity)
        {

            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.MenuName, entity.MenuName);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.MenuOrder, entity.MenuOrder);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.MenuType, entity.MenuType);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<SecondNavigationEntity>> InsertNavigation(SecondNavigationEntity entity)
        {

            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.MenuName, entity.MenuName);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.TargetID, entity.TargetID); 
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.MenuOrder, entity.MenuOrder);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.MenuType, entity.MenuType);

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
        public async static Task<ResultEntity<SecondNavigationEntity>> DeleteNavigation(SecondNavigationEntity entity)
        {

            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SecondNavigationRepositoryConstants.ID, entity.ID);

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

        public async static Task<ResultEntity<SecondNavigationEntity>> Navigation_DeleteByID(int ID)
        {
            ResultEntity<SecondNavigationEntity> result = new ResultEntity<SecondNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecondNavigationRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SecondNavigationRepositoryConstants.ID, ID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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
        static SecondNavigationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            SecondNavigationEntity entity = new SecondNavigationEntity();

            entity.ID = Convert.ToInt32(reader[SecondNavigationEntityConstants.ID].ToString());
            entity.MenuName = reader[SecondNavigationEntityConstants.MenuName].ToString();
            entity.URL = reader[SecondNavigationEntityConstants.URL].ToString();
            entity.Icon = reader[SecondNavigationEntityConstants.Icon].ToString();
            entity.TargetID = Convert.ToByte(reader[SecondNavigationEntityConstants.TargetID].ToString()); 
            entity.MenuOrder = Convert.ToByte(reader[SecondNavigationEntityConstants.MenuOrder].ToString());
            entity.LanguageID = Convert.ToByte(reader[SecondNavigationEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[SecondNavigationEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[SecondNavigationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[SecondNavigationEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[SecondNavigationEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[SecondNavigationEntityConstants.EditDate].ToString());
            entity.AddUser = reader[SecondNavigationEntityConstants.AddUser].ToString();
            entity.EditUser = reader[SecondNavigationEntityConstants.EditUser].ToString();


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
                entity.LanguageName = reader[SecondNavigationEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("MenuType");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.MenuType = reader[SecondNavigationEntityConstants.MenuType] == DBNull.Value ? 0 : Convert.ToInt32(reader[SecondNavigationEntityConstants.MenuType].ToString());
            }

            return entity;

        }
    }
}
