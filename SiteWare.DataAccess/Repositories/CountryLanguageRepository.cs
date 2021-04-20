using SiteWare.DataAccess.Common.Constants;
using SiteWare.DataAccess.RepositorieConstants;
using SiteWare.Entity;
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
   public class CountryLanguageRepository
    {
        public async static Task<ResultList<CountryLanguageEntity>> SelectAll()
        {
            ResultList<CountryLanguageEntity> result = new ResultList<CountryLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CountryLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CountryLanguageEntity> list = new List<CountryLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    CountryLanguageEntity entity =EntityHelper(reader, false);
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

        public static ResultList<CountryLanguageEntity> SelectAllNotAsync()
        {
            ResultList<CountryLanguageEntity> result = new ResultList<CountryLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CountryLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CountryLanguageEntity> list = new List<CountryLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    CountryLanguageEntity entity = EntityHelper(reader, false);
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
        static CountryLanguageEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            CountryLanguageEntity entity = new CountryLanguageEntity();

            entity.CountryID = Convert.ToByte(reader[CountryLanguageEntityConstants.CountryID].ToString());
            entity.LanguageID = Convert.ToByte(reader[CountryLanguageEntityConstants.LanguageID].ToString());
            entity.Name = reader[CountryLanguageEntityConstants.Name].ToString();
            entity.AddDate = Convert.ToDateTime(reader[CountryLanguageEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[CountryLanguageEntityConstants.EditDate].ToString());
            entity.AddUser = reader[CountryLanguageEntityConstants.AddUser].ToString();
            entity.EditUser = reader[CountryLanguageEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
