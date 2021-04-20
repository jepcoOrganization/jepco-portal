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
    public static class Plugin_Provider_GovernateRepository
    {
        public static ResultList<Plugin_GovernateEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_GovernateEntity> result = new ResultList<Plugin_GovernateEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_GovernateRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_GovernateEntity> list = new List<Plugin_GovernateEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_GovernateEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Plugin_GovernateEntity>> SelectAll()
        {
            ResultList<Plugin_GovernateEntity> result = new ResultList<Plugin_GovernateEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_GovernateRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_GovernateEntity> list = new List<Plugin_GovernateEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_GovernateEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Plugin_GovernateEntity>> SelectByCountryID(int CountryID)
        {
            ResultList<Plugin_GovernateEntity> result = new ResultList<Plugin_GovernateEntity>();

            SqlConnection sqlConnection=new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_GovernateRepositoryConstant.SP_SelectGovernatebyCountryID, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_GovernateEntity> list = new List<Plugin_GovernateEntity>();

            try
            {

                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Provider_GovernateRepositoryConstant.CountryID, CountryID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_GovernateEntity entity = EntityHelper(reader, false);
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


        static Plugin_GovernateEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_GovernateEntity entity = new Plugin_GovernateEntity();

            entity.GovernateID = Convert.ToInt64(reader[Plugin_GovernateEntityConstants.GovernateID].ToString());
            entity.Name = reader[Plugin_GovernateEntityConstants.Name].ToString();
            entity.Order = Convert.ToInt32(reader[Plugin_GovernateEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[Plugin_GovernateEntityConstants.LanguageID].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_GovernateEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_GovernateEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_GovernateEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_GovernateEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_GovernateEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_GovernateEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
