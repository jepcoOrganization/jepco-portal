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
   public static class CMS_WorkFlow_SettingsRepository
    {
        public async static Task<ResultList<CMS_WorkFlow_SettingsEntity>> SelectAll()
        {
            ResultList<CMS_WorkFlow_SettingsEntity> result = new ResultList<CMS_WorkFlow_SettingsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_WorkFlow_SettingsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CMS_WorkFlow_SettingsEntity> list = new List<CMS_WorkFlow_SettingsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    CMS_WorkFlow_SettingsEntity entity = EntityHelper(reader, false);
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

        public static ResultList<CMS_WorkFlow_SettingsEntity> SelectAllNotAsync()
        {
            ResultList<CMS_WorkFlow_SettingsEntity> result = new ResultList<CMS_WorkFlow_SettingsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_WorkFlow_SettingsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CMS_WorkFlow_SettingsEntity> list = new List<CMS_WorkFlow_SettingsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    CMS_WorkFlow_SettingsEntity entity = EntityHelper(reader, false);
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
        static CMS_WorkFlow_SettingsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            CMS_WorkFlow_SettingsEntity entity = new CMS_WorkFlow_SettingsEntity();

            entity.ID = Convert.ToInt32(reader[CMS_WorkFlow_SettingsEntityConstants.ID].ToString());
            entity.SettingID = reader[CMS_WorkFlow_SettingsEntityConstants.SettingID] == DBNull.Value ? 0 : Convert.ToInt64(reader[CMS_WorkFlow_SettingsEntityConstants.SettingID].ToString());
            entity.WF_ID = reader[CMS_WorkFlow_SettingsEntityConstants.WF_ID] == DBNull.Value ? 0 : Convert.ToInt32(reader[CMS_WorkFlow_SettingsEntityConstants.WF_ID].ToString());
            entity.UserID = reader[CMS_WorkFlow_SettingsEntityConstants.UserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[CMS_WorkFlow_SettingsEntityConstants.UserID].ToString());
            entity.Value = reader[CMS_WorkFlow_SettingsEntityConstants.Value] == DBNull.Value ? false : Convert.ToBoolean(reader[CMS_WorkFlow_SettingsEntityConstants.Value].ToString());
           


            bool ColumnExists = false;
            //try
            //{
            //    int columnOrdinal = reader.GetOrdinal("AreaOneId");
            //    ColumnExists = true;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    ColumnExists = false;
            //}

            //if (ColumnExists)
            //{
            //    entity.AreaOneId = reader[CMS_WorkFlow_SettingsEntityConstants.AreaOneId] == DBNull.Value ? 0 : Convert.ToInt32(reader[CMS_WorkFlow_SettingsEntityConstants.AreaOneId].ToString());
            //}

            return entity;
        }
    }
}
