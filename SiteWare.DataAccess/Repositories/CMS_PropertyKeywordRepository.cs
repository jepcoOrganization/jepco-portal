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
    public static class CMS_PropertyKeywordRepository
    {
        public async static Task<ResultList<CMS_PropertyKeywordEntity>> SelectKeywordByPropertyID(long PropertyID)
        {
            ResultList<CMS_PropertyKeywordEntity> result = new ResultList<CMS_PropertyKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_PropertyKeywordRepositoryConstants.SP_CMS_Property_SelectInnerJoinByPropertyID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CMS_PropertyKeywordEntity> list = new List<CMS_PropertyKeywordEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CMS_PropertyKeywordRepositoryConstants.PropertyID, PropertyID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    CMS_PropertyKeywordEntity entity = EntityHelper(reader, false);
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

        public static ResultList<CMS_PropertyKeywordEntity> SelectKeywordByPropertyIDNotAsync(long PropertyID)
        {
            ResultList<CMS_PropertyKeywordEntity> result = new ResultList<CMS_PropertyKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_PropertyKeywordRepositoryConstants.SP_CMS_Property_SelectInnerJoinByPropertyID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CMS_PropertyKeywordEntity> list = new List<CMS_PropertyKeywordEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CMS_PropertyKeywordRepositoryConstants.PropertyID, PropertyID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    CMS_PropertyKeywordEntity entity = EntityHelper(reader, false);
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

        public static ResultList<CMS_PropertyKeywordEntity> SelectKeywordListByKeywords(string keywords)
        {
            ResultList<CMS_PropertyKeywordEntity> result = new ResultList<CMS_PropertyKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_PropertyKeywordRepositoryConstants.SP_Keywordlistbykeywords, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CMS_PropertyKeywordEntity> list = new List<CMS_PropertyKeywordEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add("@String", SqlDbType.VarChar).Value = keywords;
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    CMS_PropertyKeywordEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<CMS_PropertyKeywordEntity>> DeleteByPropertyID(long PropertyID)
        {
            ResultEntity<CMS_PropertyKeywordEntity> result = new ResultEntity<CMS_PropertyKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_PropertyKeywordRepositoryConstants.SP_DeleteByPropertyID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CMS_PropertyKeywordRepositoryConstants.PropertyID, PropertyID));
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
        public async static Task<ResultEntity<CMS_PropertyKeywordEntity>> InsertKeyword(CMS_PropertyKeywordEntity entity)
        {

            ResultEntity<CMS_PropertyKeywordEntity> result = new ResultEntity<CMS_PropertyKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CMS_PropertyKeywordRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CMS_PropertyKeywordRepositoryConstants.PropertyID, entity.PropertyID);
                sqlCommand.Parameters.AddWithValue(CMS_PropertyKeywordRepositoryConstants.Keyword, entity.Keyword);
                sqlCommand.Parameters.AddWithValue(CMS_PropertyKeywordRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(CMS_PropertyKeywordRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(CMS_PropertyKeywordRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(CMS_PropertyKeywordRepositoryConstants.EditUser, entity.EditUser);

                await sqlCommand.ExecuteNonQueryAsync();
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
        static CMS_PropertyKeywordEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            CMS_PropertyKeywordEntity entity = new CMS_PropertyKeywordEntity();

            entity.ID = Convert.ToInt32(reader[CMS_PropertyKeywordEntityConstants.ID].ToString());
            entity.PropertyID = Convert.ToInt64(reader[CMS_PropertyKeywordEntityConstants.PropertyID].ToString());
            entity.Keyword = reader[CMS_PropertyKeywordEntityConstants.Keyword].ToString();
            entity.AddDate = Convert.ToDateTime(reader[CMS_PropertyKeywordEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[CMS_PropertyKeywordEntityConstants.EditDate].ToString());
            entity.AddUser = reader[CMS_PropertyKeywordEntityConstants.AddUser].ToString();
            entity.EditUser = reader[CMS_PropertyKeywordEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
