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
    public static class Lookup_JobNameRepository
    {
        public async static Task<ResultList<Lookup_JobNameEntity>> SelectAll()
        {
            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobNameRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobNameEntity> list = new List<Lookup_JobNameEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_JobNameEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_JobNameEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobNameRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobNameEntity> list = new List<Lookup_JobNameEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_JobNameEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_JobNameEntity>> SelectByID(int JobNameID)
        {

            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobNameRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobNameEntity> list = new List<Lookup_JobNameEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_JobNameRepositoryConstants.JobNameID, JobNameID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_JobNameEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_JobNameEntity> SelectByIDNotAsync(int JobNameID)
        {

            ResultList<Lookup_JobNameEntity> result = new ResultList<Lookup_JobNameEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_JobNameRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_JobNameEntity> list = new List<Lookup_JobNameEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_JobNameRepositoryConstants.JobNameID, JobNameID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_JobNameEntity entity = EntityHelper(reader, false);
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



        static Lookup_JobNameEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_JobNameEntity entity = new Lookup_JobNameEntity();

            entity.JobNameID = Convert.ToInt32(reader[Lookup_JobNameEntityConstants.JobNameID].ToString());
            entity.JobName = reader[Lookup_JobNameEntityConstants.JobName] == DBNull.Value ? string.Empty : reader[Lookup_JobNameEntityConstants.JobName].ToString();
            entity.JobTypeID = reader[Lookup_JobNameEntityConstants.JobTypeID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_JobNameEntityConstants.JobTypeID].ToString());
            entity.Order = reader[Lookup_JobNameEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_JobNameEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_JobNameEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_JobNameEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_JobNameEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_JobNameEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_JobNameEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_JobNameEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_JobNameEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_JobNameEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_JobNameEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_JobNameEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_JobNameEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_JobNameEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_JobNameEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_JobNameEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_JobNameEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_JobNameEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
