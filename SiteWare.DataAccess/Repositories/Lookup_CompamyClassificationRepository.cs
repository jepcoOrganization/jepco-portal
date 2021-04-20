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
    public static class Lookup_CompamyClassificationRepository
    {

        public async static Task<ResultList<Lookup_CompamyClassificationEntity>> SelectAll()
        {
            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CompamyClassificationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CompamyClassificationEntity> list = new List<Lookup_CompamyClassificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_CompamyClassificationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_CompamyClassificationEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CompamyClassificationRepositoryConstants.SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CompamyClassificationEntity> list = new List<Lookup_CompamyClassificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_CompamyClassificationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_CompamyClassificationEntity>> SelectByID(int CompanyClassificationID)
        {

            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CompamyClassificationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CompamyClassificationEntity> list = new List<Lookup_CompamyClassificationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_CompamyClassificationRepositoryConstants.CompanyClassificationID, CompanyClassificationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_CompamyClassificationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_CompamyClassificationEntity> SelectByIDNotAsync(int CompanyClassificationID)
        {

            ResultList<Lookup_CompamyClassificationEntity> result = new ResultList<Lookup_CompamyClassificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CompamyClassificationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CompamyClassificationEntity> list = new List<Lookup_CompamyClassificationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_CompamyClassificationRepositoryConstants.CompanyClassificationID, CompanyClassificationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_CompamyClassificationEntity entity = EntityHelper(reader, false);
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



        static Lookup_CompamyClassificationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_CompamyClassificationEntity entity = new Lookup_CompamyClassificationEntity();

            entity.CompanyClassificationID = Convert.ToInt32(reader[Lookup_CompamyClassificationEntityConstants.CompanyClassificationID].ToString());
            entity.CompanyClassificationName = reader[Lookup_CompamyClassificationEntityConstants.CompanyClassificationName] == DBNull.Value ? string.Empty : reader[Lookup_CompamyClassificationEntityConstants.CompanyClassificationName].ToString();
            entity.IsPublished = reader[Lookup_CompamyClassificationEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_CompamyClassificationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_CompamyClassificationEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_CompamyClassificationEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_CompamyClassificationEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_CompamyClassificationEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_CompamyClassificationEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_CompamyClassificationEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_CompamyClassificationEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_CompamyClassificationEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_CompamyClassificationEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_CompamyClassificationEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
