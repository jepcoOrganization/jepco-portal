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
    public static class Lookup_CityRepository
    {

        public async static Task<ResultList<Lookup_CityEntity>> SelectAll()
        {
            ResultList<Lookup_CityEntity> result = new ResultList<Lookup_CityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CityRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CityEntity> list = new List<Lookup_CityEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_CityEntity entity = EntityHelper(reader, false);
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


        public static ResultList<Lookup_CityEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_CityEntity> result = new ResultList<Lookup_CityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CityRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CityEntity> list = new List<Lookup_CityEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_CityEntity entity = EntityHelper(reader, false);
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

        static Lookup_CityEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_CityEntity entity = new Lookup_CityEntity();

            entity.CityID = Convert.ToInt32(reader[Lookup_CityEntityConstants.CityID].ToString());

            entity.CityName = reader[Lookup_CityEntityConstants.CityName].ToString();
            entity.LanguageID = Convert.ToInt32(reader[Lookup_CityEntityConstants.LanguageID].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_CityEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Lookup_CityEntityConstants.IsDelete].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_CityEntityConstants.AddDate].ToString());

            entity.AddUser = Convert.ToInt32(reader[Lookup_CityEntityConstants.AddUser].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_CityEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToInt32(reader[Lookup_CityEntityConstants.EditUser].ToString());

            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("CountryID");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.CountryID = reader[Lookup_CityEntityConstants.CountryID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_CityEntityConstants.CountryID].ToString());
            }
            return entity;

        }

    }
}
