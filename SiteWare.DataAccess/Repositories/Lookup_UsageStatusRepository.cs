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
    public static class Lookup_UsageStatusRepository
    {
        public static ResultList<Lookup_UsageStatusEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_UsageStatusEntity> result = new ResultList<Lookup_UsageStatusEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_UsageStatusRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_UsageStatusEntity> list = new List<Lookup_UsageStatusEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_UsageStatusEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Lookup_UsageStatusEntity>> SelectAll()
        {
            ResultList<Lookup_UsageStatusEntity> result = new ResultList<Lookup_UsageStatusEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_UsageStatusRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_UsageStatusEntity> list = new List<Lookup_UsageStatusEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_UsageStatusEntity entity = EntityHelper(reader, false);
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
        static Lookup_UsageStatusEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_UsageStatusEntity entity = new Lookup_UsageStatusEntity();

            entity.UsageStatusID = Convert.ToInt32(reader[Lookup_UsageStatusEntityConstant.UsageStatusID].ToString());
            entity.UsageStatus = reader[Lookup_UsageStatusEntityConstant.UsageStatus].ToString();
            entity.LanguageID = Convert.ToInt32(reader[Lookup_UsageStatusEntityConstant.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Lookup_UsageStatusEntityConstant.IsDeleted].ToString());

            return entity;
        }
    }
}
