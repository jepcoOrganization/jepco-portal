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
   public class Lookup_CountryRepository
    {
        public static CommandType CommandType { get; set; }

        public async static Task<ResultList<Lookup_CountryEntity>> SelectAll()
        {
            ResultList<Lookup_CountryEntity> result = new ResultList<Lookup_CountryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CountryRepositoryConstants.SP_SelectAll, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            List<Lookup_CountryEntity> list = new List<Lookup_CountryEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while(reader.Read())
                {
                    Lookup_CountryEntity entity = EntityHelper(reader, false);
                    list.Add(entity);

                }

                if(list.Count>0)
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

        public static ResultList<Lookup_CountryEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_CountryEntity> result = new ResultList<Lookup_CountryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CountryRepositoryConstants.SP_SelectAll, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            List<Lookup_CountryEntity> list = new List<Lookup_CountryEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_CountryEntity entity = EntityHelper(reader, false);
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
        static Lookup_CountryEntity EntityHelper(SqlDataReader reader, bool v)
        {

            Lookup_CountryEntity entity = new Lookup_CountryEntity();
            entity.CountryID = Convert.ToInt32(reader[Lookup_CountryEntityConstants.CountryID].ToString());
            entity.CountryName = reader[Lookup_CountryEntityConstants.CountryName].ToString();
            entity.IsDelete = Convert.ToBoolean(reader[Lookup_CountryEntityConstants.IsDelete].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_CountryEntityConstants.IsPublished].ToString());
            entity.AddUser = Convert.ToInt32(reader[Lookup_CountryEntityConstants.AddUser].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_CountryEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_CountryEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToInt32(reader[Lookup_CountryEntityConstants.EditUser].ToString());

            return entity;
        }
    }
}
