using SiteWare.DataAccess.Common.Constants;
using SiteWare.DataAccess.RepositorieConstants;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.Repositories
{
    public static class Lookup_AreaRepository
    {
        public async static Task<ResultList<Lookup_AreaEntity>> SelectAll()
        {
            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaEntity> list = new List<Lookup_AreaEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_AreaEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_AreaEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaEntity> list = new List<Lookup_AreaEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_AreaEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_AreaEntity>> Lookup_Area_ByGovernateID(int GovernateID)
        {

            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaRepositoryConstants.SP_SelectByGovID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaEntity> list = new List<Lookup_AreaEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_AreaRepositoryConstants.GovernateID, GovernateID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_AreaEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_AreaEntity> Lookup_Area_ByGovernateIDNotAsync(int GovernateID)
        {

            ResultList<Lookup_AreaEntity> result = new ResultList<Lookup_AreaEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaRepositoryConstants.SP_SelectByGovID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaEntity> list = new List<Lookup_AreaEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_AreaRepositoryConstants.GovernateID, GovernateID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_AreaEntity entity = EntityHelper(reader, false);
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

        static Lookup_AreaEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_AreaEntity entity = new Lookup_AreaEntity();

            entity.AreaID = Convert.ToInt32(reader[Lookup_AreaEntityConstants.AreaID].ToString());
            entity.GovernateID = Convert.ToInt64(reader[Lookup_AreaEntityConstants.GovernateID].ToString());
            entity.AreaName = reader[Lookup_AreaEntityConstants.AreaName].ToString();
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_AreaEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Lookup_AreaEntityConstants.IsDelete].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_AreaEntityConstants.AddDate].ToString());
            
            entity.AddUser = Convert.ToInt32( reader[Lookup_AreaEntityConstants.AddUser].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_AreaEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToInt32(reader[BannerTypeEntityConstants.EditUser].ToString());

            return entity;
        }
    }
}
