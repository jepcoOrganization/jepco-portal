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
    public class Plugin_Provider_DocumentRepository
    {
        public async static Task<ResultList<Plugin_ProviderDocumentationEntity>> SelectAll()
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderRepositoryConstants.Provider_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderDocumentationEntity> list = new List<Plugin_ProviderDocumentationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ProviderDocumentationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_ProviderDocumentationEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_ProviderDocumentationEntity> result = new ResultList<Plugin_ProviderDocumentationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ProviderDocumentationRepositoryConstant.ProviderDocumentation_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ProviderDocumentationEntity> list = new List<Plugin_ProviderDocumentationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ProviderDocumentationEntity entity = EntityHelper(reader, false);
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


        static Plugin_ProviderDocumentationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ProviderDocumentationEntity entity = new Plugin_ProviderDocumentationEntity();
            entity.ProviderDocumentaionID = Convert.ToInt32(reader[Plugin_ProviderDocumentationEntityConstants.ProviderDocumentaionID].ToString());
            entity.ProviderID = Convert.ToInt64(reader[Plugin_ProviderDocumentationEntityConstants.ProviderID].ToString());
            entity.DocumentTypeID = Convert.ToInt32(reader[Plugin_ProviderDocumentationEntityConstants.DocumentTypeID].ToString());
            entity.DocumentType = reader[Plugin_ProviderDocumentationEntityConstants.DocumentType].ToString();
            entity.FileName = reader[Plugin_ProviderDocumentationEntityConstants.FileName].ToString();
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_ProviderDocumentationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_ProviderDocumentationEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_ProviderDocumentationEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_ProviderDocumentationEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_ProviderDocumentationEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_ProviderDocumentationEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
