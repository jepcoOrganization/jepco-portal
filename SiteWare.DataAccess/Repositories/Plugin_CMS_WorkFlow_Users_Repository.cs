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
   public static class Plugin_CMS_WorkFlow_Users_Repository
    {
        public static ResultList<Plugin_CMS_WorkFlow_Users_Entity> SelectAllNotAsync()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_RepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Entity> list = new List<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Entity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Entity>> SelectByID(int ID)
        {

            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_RepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Entity> list = new List<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_Users_RepositoryConstants.ID, ID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Entity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_CMS_WorkFlow_Users_Entity> SelectByIDNotAsync(int ID)
        {

            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_RepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Entity> list = new List<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CMS_WorkFlow_Users_RepositoryConstants.ID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Entity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Plugin_CMS_WorkFlow_Users_Entity>> SelectAll()
        {
            ResultList<Plugin_CMS_WorkFlow_Users_Entity> result = new ResultList<Plugin_CMS_WorkFlow_Users_Entity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_RepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CMS_WorkFlow_Users_Entity> list = new List<Plugin_CMS_WorkFlow_Users_Entity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CMS_WorkFlow_Users_Entity entity = EntityHelper(reader, false);
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
        static Plugin_CMS_WorkFlow_Users_Entity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CMS_WorkFlow_Users_Entity entity = new Plugin_CMS_WorkFlow_Users_Entity();

            entity.ID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.ID].ToString());
            entity.WF_ID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.WF_ID].ToString());
            entity.FromUserID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.FromUserID].ToString());
            entity.ToUserID = Convert.ToInt64(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.ToUserID].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.EditDate].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Plugin_CMS_WorkFlow_Users_EntityConstants.IsDelete].ToString());
            
            return entity;
        }

    }
}
