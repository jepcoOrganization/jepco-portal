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
    public static class Lookup_QualificationRepository
    {
        public async static Task<ResultList<Lookup_QualificationEntity>> SelectAll()
        {
            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_QualificationRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_QualificationEntity> list = new List<Lookup_QualificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_QualificationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_QualificationEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_QualificationRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_QualificationEntity> list = new List<Lookup_QualificationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_QualificationEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_QualificationEntity>> SelectByID(int QualificationID)
        {

            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_QualificationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_QualificationEntity> list = new List<Lookup_QualificationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_QualificationRepositoryConstants.QualificationID, QualificationID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_QualificationEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_QualificationEntity> SelectByIDNotAsync(int QualificationID)
        {

            ResultList<Lookup_QualificationEntity> result = new ResultList<Lookup_QualificationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_QualificationRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_QualificationEntity> list = new List<Lookup_QualificationEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_QualificationRepositoryConstants.QualificationID, QualificationID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_QualificationEntity entity = EntityHelper(reader, false);
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



        static Lookup_QualificationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_QualificationEntity entity = new Lookup_QualificationEntity();

            entity.QualificationID = Convert.ToInt32(reader[Lookup_QualificationEntityConstants.QualificationID].ToString());
            entity.QualificationName = reader[Lookup_QualificationEntityConstants.QualificationName] == DBNull.Value ? string.Empty : reader[Lookup_QualificationEntityConstants.QualificationName].ToString();
            entity.Order = reader[Lookup_QualificationEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_QualificationEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_QualificationEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_QualificationEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_QualificationEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_QualificationEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_QualificationEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_QualificationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_QualificationEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_QualificationEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_QualificationEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_QualificationEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_QualificationEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_QualificationEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_QualificationEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_QualificationEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_QualificationEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_QualificationEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
