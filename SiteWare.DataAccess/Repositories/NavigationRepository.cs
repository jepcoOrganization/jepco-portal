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
    public static class NavigationRepository
    {
        public static ResultList<NavigationEntity> SelectAllToWebSiteNotAsync()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();
            //sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.IsPublished, true));
            //sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.IsDeleted,false));
            //sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ParentID, 0));
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
                    if (entity.IsPublished == true && entity.IsDeleted == false && entity.ParentID == 0)
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
        public static ResultList<NavigationEntity> SelectAllSubItemByParentID(int ID)
        {

            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByParentMenuID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ParentID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
                    if (entity.IsPublished == true && entity.IsDeleted == false && entity.ParentID == ID)
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
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }

        public async static Task<ResultEntity<NavigationEntity>> SelectByID(int ID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ID, ID));
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
        public  static ResultEntity<NavigationEntity> SelectByIDNotAsync(int ID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ID, ID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
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
        public async static Task<ResultEntity<NavigationEntity>> SelectParentMenuByID(int ID,byte LangID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectParentByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ID, ID));
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.LanguageID, LangID));
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
        public async static Task<ResultEntity<NavigationEntity>> SelectByUrl(string Url,byte langID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByUrl, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.URL, Url));
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.LanguageID, langID));
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

        public static ResultEntity<NavigationEntity> SelectByUrlNotAsync(string Url, byte langID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByUrl, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.URL, Url));
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.LanguageID, langID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
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


        public async static Task<ResultList<NavigationEntity>> SelectAll()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<NavigationEntity> SelectAllNotAsync()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<NavigationEntity>> SelectByRootMenu()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByRootMenu, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<NavigationEntity> SelectByRootMenuNotAsync()
        {
            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByRootMenu, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<NavigationEntity>> SelectByParentMenuID(int ParentMenuID)
        {

            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByParentMenuID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ParentID, ParentMenuID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
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
        public  static ResultList<NavigationEntity> SelectByParentMenuIDNotAsync(int ParentMenuID)
        {

            ResultList<NavigationEntity> result = new ResultList<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_SelectByParentMenuID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NavigationEntity> list = new List<NavigationEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(NavigationRepositoryConstants.ParentID, ParentMenuID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    NavigationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<NavigationEntity>> Update(NavigationEntity entity)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuName, entity.MenuName);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuOrder, entity.MenuOrder);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuTitle, entity.MenuTitle);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuImage, entity.MenuImage);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.HoverImage, entity.HoverImage);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.Summary2, entity.Summary2);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ShowCompany, entity.ShowCompany);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ShowUser, entity.ShowUser);

                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<NavigationEntity>> UpdateByIsDeleted(int ID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ID, ID);

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
        public async static Task<ResultEntity<NavigationEntity>> UpdateParentID(int ParentID, int ID)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_UpdateParentID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ParentID, ParentID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ID, ID);

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
        public async static Task<ResultEntity<NavigationEntity>> InsertNavigation(NavigationEntity entity)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuName, entity.MenuName);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuOrder, entity.MenuOrder);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuTitle, entity.MenuTitle);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.MenuImage, entity.MenuImage);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.HoverImage, entity.HoverImage);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.Summary2, entity.Summary2);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ShowCompany, entity.ShowCompany);
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ShowUser, entity.ShowUser);

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
        public async static Task<ResultEntity<NavigationEntity>> DeleteNavigation(NavigationEntity entity)
        {

            ResultEntity<NavigationEntity> result = new ResultEntity<NavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NavigationRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(NavigationRepositoryConstants.ID, entity.ID);

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
        static NavigationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            NavigationEntity entity = new NavigationEntity();

            entity.ID = Convert.ToInt32(reader[NavigationEntityConstants.ID].ToString());
            entity.MenuName = reader[NavigationEntityConstants.MenuName].ToString();
            entity.URL = reader[NavigationEntityConstants.URL].ToString();
            entity.TargetID = Convert.ToByte(reader[NavigationEntityConstants.TargetID].ToString());
            entity.ParentID = Convert.ToByte(reader[NavigationEntityConstants.ParentID].ToString());
            entity.MenuOrder = Convert.ToByte(reader[NavigationEntityConstants.MenuOrder].ToString());
            entity.LanguageID = Convert.ToByte(reader[NavigationEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[NavigationEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[NavigationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[NavigationEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[NavigationEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[NavigationEntityConstants.EditDate].ToString());
            entity.AddUser = reader[NavigationEntityConstants.AddUser].ToString();
            entity.EditUser = reader[NavigationEntityConstants.EditUser].ToString();
                                                
            try {
                entity.MenuTitle = reader[NavigationEntityConstants.MenuTitle].ToString();
            } catch { }
            try {
                entity.Summary = reader[NavigationEntityConstants.Summary].ToString();
            } catch { }
            try {
                entity.MenuImage = reader[NavigationEntityConstants.MenuImage].ToString();
            } catch { }
            try {
                entity.HoverImage = reader[NavigationEntityConstants.HoverImage].ToString();
            } catch { }

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
                entity.LanguageName = reader[NavigationEntityConstants.LanguageName].ToString();
            }
            
            try
            {
                int columnOrdinal = reader.GetOrdinal("Summary2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Summary2 = reader[NavigationEntityConstants.Summary2].ToString();
            }


            try
            {
                int columnOrdinal = reader.GetOrdinal("ShowUser");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ShowUser = reader[NavigationEntityConstants.ShowUser] == DBNull.Value ? false : Convert.ToBoolean(reader[NavigationEntityConstants.ShowUser].ToString());
                
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ShowCompany");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.ShowCompany = reader[NavigationEntityConstants.ShowCompany] == DBNull.Value ? false : Convert.ToBoolean(reader[NavigationEntityConstants.ShowCompany].ToString());
               
            }


            return entity;
        }
    }
}
