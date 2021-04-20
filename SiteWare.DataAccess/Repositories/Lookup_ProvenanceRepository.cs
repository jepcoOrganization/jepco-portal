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
    public static class Lookup_ProvenanceRepository
    {
        public async static Task<ResultList<Lookup_ProvenanceEntity>> SelectAll()
        {
            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ProvenanceRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ProvenanceEntity> list = new List<Lookup_ProvenanceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_ProvenanceEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_ProvenanceEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ProvenanceRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ProvenanceEntity> list = new List<Lookup_ProvenanceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_ProvenanceEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_ProvenanceEntity>> SelectByID(int ProvenanceID)
        {

            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ProvenanceRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ProvenanceEntity> list = new List<Lookup_ProvenanceEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_ProvenanceRepositoryConstants.ProvenanceID, ProvenanceID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_ProvenanceEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_ProvenanceEntity> SelectByIDNotAsync(int ProvenanceID)
        {

            ResultList<Lookup_ProvenanceEntity> result = new ResultList<Lookup_ProvenanceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ProvenanceRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ProvenanceEntity> list = new List<Lookup_ProvenanceEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_ProvenanceRepositoryConstants.ProvenanceID, ProvenanceID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_ProvenanceEntity entity = EntityHelper(reader, false);
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



        static Lookup_ProvenanceEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_ProvenanceEntity entity = new Lookup_ProvenanceEntity();

            entity.ProvenanceID = Convert.ToInt32(reader[Lookup_ProvenanceEntityConstants.ProvenanceID].ToString());
            entity.ProvenanceName = reader[Lookup_ProvenanceEntityConstants.ProvenanceName] == DBNull.Value ? string.Empty : reader[Lookup_ProvenanceEntityConstants.ProvenanceName].ToString();
            entity.Order = reader[Lookup_ProvenanceEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_ProvenanceEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_ProvenanceEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_ProvenanceEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_ProvenanceEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_ProvenanceEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_ProvenanceEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_ProvenanceEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_ProvenanceEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_ProvenanceEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_ProvenanceEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_ProvenanceEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_ProvenanceEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_ProvenanceEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_ProvenanceEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_ProvenanceEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_ProvenanceEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_ProvenanceEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
