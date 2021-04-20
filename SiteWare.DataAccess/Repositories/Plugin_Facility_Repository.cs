using Siteware.DataAccess.RepositorieConstants;
using Siteware.Entity.Constants.Entity;
using Siteware.Entity.Entities;
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

namespace Siteware.DataAccess.Repositories
{
    public class Plugin_Facility_Repository
    {

        public static ResultList<Plugin_Facility_Entity> SelectAllSubItemByParentID(int ID)
        {

            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectParentByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Facility_Entity> list = new List<Plugin_Facility_Entity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.ParentID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Plugin_Facility_Entity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_Facility_Entity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.ID, ID));
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
        public static ResultEntity<Plugin_Facility_Entity> SelectByIDNotAsync(long ID)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.ID, ID));
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
        public async static Task<ResultEntity<Plugin_Facility_Entity>> SelectParentMenuByID(int ID, byte LangID)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectParentByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.ID, ID));
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.LanguageID, LangID));
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



        public async static Task<ResultList<Plugin_Facility_Entity>> SelectAll()
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Facility_Entity> list = new List<Plugin_Facility_Entity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_Facility_Entity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_Facility_Entity> SelectAllNotAsync()
        {
            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Facility_Entity> list = new List<Plugin_Facility_Entity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_Facility_Entity entity = EntityHelper(reader, false);
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


        public async static Task<ResultList<Plugin_Facility_Entity>> SelectByParentMenuID(long ParentMenuID)
        {

            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectParentByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Facility_Entity> list = new List<Plugin_Facility_Entity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.ParentID, ParentMenuID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Plugin_Facility_Entity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_Facility_Entity> SelectByParentMenuIDNotAsync(long ParentMenuID)
        {

            ResultList<Plugin_Facility_Entity> result = new ResultList<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_SelectParentByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Facility_Entity> list = new List<Plugin_Facility_Entity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Facility_RepositoryConstants.ParentID, ParentMenuID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Plugin_Facility_Entity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_Facility_Entity>> Update(Plugin_Facility_Entity entity)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ID, entity.ID);

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
        public static ResultEntity<Plugin_Facility_Entity> UpdateNotAsync(Plugin_Facility_Entity entity)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<Plugin_Facility_Entity>> Delete(long ID)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ID, ID);

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
        public async static Task<ResultEntity<Plugin_Facility_Entity>> DeleteByParentID(long ParentID)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_DeleteByParentID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ParentID, ParentID);

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
        public async static Task<ResultEntity<Plugin_Facility_Entity>> Insert(Plugin_Facility_Entity entity)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Facility_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Facility_RepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_Facility_Entity> InsertNotAsync(Plugin_Facility_Entity entity)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ImageUrl, entity.ImageUrl);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Facility_RepositoryConstants.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_Facility_RepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<Plugin_Facility_Entity>> Delete(Plugin_Facility_Entity entity)
        {

            ResultEntity<Plugin_Facility_Entity> result = new ResultEntity<Plugin_Facility_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Facility_RepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Facility_RepositoryConstants.ID, entity.ID);

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
        static Plugin_Facility_Entity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_Facility_Entity entity = new Plugin_Facility_Entity();

            entity.ID = Convert.ToInt64(reader[Plugin_Facility_EntityConstants.ID].ToString());
            entity.Title = reader[Plugin_Facility_EntityConstants.Title].ToString();
            entity.Summary = reader[Plugin_Facility_EntityConstants.Summary].ToString();
            entity.URL = reader[Plugin_Facility_EntityConstants.URL].ToString();
            entity.ImageUrl = reader[Plugin_Facility_EntityConstants.ImageUrl].ToString();
            entity.TargetID = Convert.ToByte(reader[Plugin_Facility_EntityConstants.TargetID].ToString());
            entity.ParentID = Convert.ToByte(reader[Plugin_Facility_EntityConstants.ParentID].ToString());
            entity.Order = Convert.ToByte(reader[Plugin_Facility_EntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[Plugin_Facility_EntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[Plugin_Facility_EntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_Facility_EntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_Facility_EntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_Facility_EntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_Facility_EntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_Facility_EntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_Facility_EntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[Plugin_Facility_EntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
