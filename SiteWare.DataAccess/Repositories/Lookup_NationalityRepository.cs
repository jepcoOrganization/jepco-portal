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
   public static class Lookup_NationalityRepository
    {
        public static ResultList<Lookup_NationalityEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_NationalityRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_NationalityEntity> list = new List<Lookup_NationalityEntity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_NationalityEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_NationalityEntity>> SelectByID(int NationalityID)
        {

            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_NationalityRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_NationalityEntity> list = new List<Lookup_NationalityEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_NationalityRepositoryConstants.NationalityID, NationalityID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_NationalityEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Lookup_NationalityEntity> SelectByIDNotAsync(int NationalityID)
        {

            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_NationalityRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_NationalityEntity> list = new List<Lookup_NationalityEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_NationalityRepositoryConstants.NationalityID, NationalityID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_NationalityEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Lookup_NationalityEntity>> SelectAll()
        {
            ResultList<Lookup_NationalityEntity> result = new ResultList<Lookup_NationalityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_NationalityRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_NationalityEntity> list = new List<Lookup_NationalityEntity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_NationalityEntity entity = EntityHelper(reader, false);
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
        static Lookup_NationalityEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_NationalityEntity entity = new Lookup_NationalityEntity();

            entity.NationalityID = Convert.ToInt32(reader[Lookup_NationalityEntityConstants.NationalityID].ToString());
            entity.Name = reader[Lookup_NationalityEntityConstants.Name].ToString();
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_NationalityEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Lookup_NationalityEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_NationalityEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_NationalityEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Lookup_NationalityEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Lookup_NationalityEntityConstants.EditUser].ToString();

            return entity;
        }

    }
}
