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
    public static class PagesKeywordRepository
    {
        public async static Task<ResultList<PagesKeywordEntity>> SelectKeywordByPageID(int PageID)
        {
            ResultList<PagesKeywordEntity> result = new ResultList<PagesKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesKeywordRepositoryConstants.SP_CMS_Page_SelectInnerJoinByPageID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PagesKeywordEntity> list = new List<PagesKeywordEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesKeywordRepositoryConstants.PageID, PageID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PagesKeywordEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PagesKeywordEntity>> DeleteByPageID(int PageID)
        {
            ResultEntity<PagesKeywordEntity> result = new ResultEntity<PagesKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesKeywordRepositoryConstants.SP_DeleteByPageID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PagesKeywordRepositoryConstants.PageID, PageID));
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
        public async static Task<ResultEntity<PagesKeywordEntity>> InsertKeyword(PagesKeywordEntity entity)
        {

            ResultEntity<PagesKeywordEntity> result = new ResultEntity<PagesKeywordEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PagesKeywordRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PagesKeywordRepositoryConstants.PageID, entity.PageID);
                sqlCommand.Parameters.AddWithValue(PagesKeywordRepositoryConstants.Keyword, entity.Keyword);
                sqlCommand.Parameters.AddWithValue(PagesKeywordRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PagesKeywordRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PagesKeywordRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PagesKeywordRepositoryConstants.EditUser, entity.EditUser);

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
        static PagesKeywordEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PagesKeywordEntity entity = new PagesKeywordEntity();

            entity.ID = Convert.ToInt32(reader[PagesKeywordEntityConstants.ID].ToString());
            entity.PageID = Convert.ToInt32(reader[PagesKeywordEntityConstants.PageID].ToString());
            entity.Keyword = reader[PagesKeywordEntityConstants.Keyword].ToString();
            entity.AddDate = Convert.ToDateTime(reader[PagesKeywordEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[PagesKeywordEntityConstants.EditDate].ToString());
            entity.AddUser = reader[PagesKeywordEntityConstants.AddUser].ToString();
            entity.EditUser = reader[PagesKeywordEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
