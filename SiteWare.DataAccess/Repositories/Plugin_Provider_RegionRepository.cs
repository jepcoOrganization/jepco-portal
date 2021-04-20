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
    public static class Plugin_Provider_RegionRepository
    {
        public static ResultList<Plugin_Provider_RegionEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_Provider_RegionEntity> result = new ResultList<Plugin_Provider_RegionEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_RegionRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Provider_RegionEntity> list = new List<Plugin_Provider_RegionEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_Provider_RegionEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Plugin_Provider_RegionEntity>> SelectAll()
        {
            ResultList<Plugin_Provider_RegionEntity> result = new ResultList<Plugin_Provider_RegionEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_RegionRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Provider_RegionEntity> list = new List<Plugin_Provider_RegionEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_Provider_RegionEntity entity = EntityHelper(reader, false);
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
        static Plugin_Provider_RegionEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_Provider_RegionEntity entity = new Plugin_Provider_RegionEntity();

            entity.RegionID = Convert.ToInt64(reader[Plugin_Provider_RegionEntityConstants.RegionID].ToString());
            entity.GovernateID = Convert.ToInt64(reader[Plugin_Provider_RegionEntityConstants.GovernateID].ToString());
            entity.Name = reader[Plugin_Provider_RegionEntityConstants.Name].ToString();
            entity.Order = Convert.ToInt32(reader[Plugin_Provider_RegionEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[Plugin_Provider_RegionEntityConstants.LanguageID].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_Provider_RegionEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_Provider_RegionEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_Provider_RegionEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_Provider_RegionEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_Provider_RegionEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_Provider_RegionEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
