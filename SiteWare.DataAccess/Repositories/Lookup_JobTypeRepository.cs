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
    public static class Lookup_JobTypeRepository
    {
        public async static Task<ResultList<Lookup_JobTypeEntity>> SelectAll()
        {
            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobTypeEntity> list = new List<Lookup_JobTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_JobTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_JobTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobTypeEntity> list = new List<Lookup_JobTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_JobTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_JobTypeEntity>> SelectByID(int JobTypeID)
        {

            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobTypeEntity> list = new List<Lookup_JobTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_JobTypeRepositoryConstants.JobTypeID, JobTypeID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_JobTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_JobTypeEntity> SelectByIDNotAsync(int JobTypeID)
        {

            ResultList<Lookup_JobTypeEntity> result = new ResultList<Lookup_JobTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobTypeEntity> list = new List<Lookup_JobTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_JobTypeRepositoryConstants.JobTypeID, JobTypeID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_JobTypeEntity entity = EntityHelper(reader, false);
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



        static Lookup_JobTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_JobTypeEntity entity = new Lookup_JobTypeEntity();

            entity.JobTypeID = Convert.ToInt32(reader[Lookup_JobTypeEntityConstants.JobTypeID].ToString());
            entity.JobTypeName = reader[Lookup_JobTypeEntityConstants.JobTypeName] == DBNull.Value ? string.Empty : reader[Lookup_JobTypeEntityConstants.JobTypeName].ToString();
            entity.Order = reader[Lookup_JobTypeEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_JobTypeEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_JobTypeEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_JobTypeEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_JobTypeEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_JobTypeEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_JobTypeEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_JobTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_JobTypeEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_JobTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_JobTypeEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_JobTypeEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_JobTypeEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_JobTypeEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_JobTypeEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_JobTypeEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_JobTypeEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_JobTypeEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
