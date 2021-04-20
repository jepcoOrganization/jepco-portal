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
    public static class Lookup_AreaTwoRepository
    {
        public async static Task<ResultList<Lookup_AreaTwoEntity>> SelectAll()
        {
            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaTwoRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaTwoEntity> list = new List<Lookup_AreaTwoEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_AreaTwoEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_AreaTwoEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaTwoRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaTwoEntity> list = new List<Lookup_AreaTwoEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_AreaTwoEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_AreaTwoEntity>> SelectByID(int AreaTwoID)
        {

            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaTwoRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaTwoEntity> list = new List<Lookup_AreaTwoEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_AreaTwoRepositoryConstants.AreaTwoID, AreaTwoID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_AreaTwoEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_AreaTwoEntity> SelectByIDNotAsync(int AreaTwoID)
        {

            ResultList<Lookup_AreaTwoEntity> result = new ResultList<Lookup_AreaTwoEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaTwoRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaTwoEntity> list = new List<Lookup_AreaTwoEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_AreaTwoRepositoryConstants.AreaTwoID, AreaTwoID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_AreaTwoEntity entity = EntityHelper(reader, false);
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



        static Lookup_AreaTwoEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_AreaTwoEntity entity = new Lookup_AreaTwoEntity();

            entity.AreaTwoID = Convert.ToInt32(reader[Lookup_AreaTwoEntityConstants.AreaTwoID].ToString());
            entity.AreaTwoName = reader[Lookup_AreaTwoEntityConstants.AreaTwoName] == DBNull.Value ? string.Empty : reader[Lookup_AreaTwoEntityConstants.AreaTwoName].ToString();
            entity.Order = reader[Lookup_AreaTwoEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_AreaTwoEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_AreaTwoEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_AreaTwoEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_AreaTwoEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_AreaTwoEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_AreaTwoEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_AreaTwoEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_AreaTwoEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_AreaTwoEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_AreaTwoEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_AreaTwoEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_AreaTwoEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_AreaTwoEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_AreaTwoEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_AreaTwoEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_AreaTwoEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_AreaTwoEntityConstants.EditUser].ToString();

            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("AreaOneId");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.AreaOneId = reader[Lookup_AreaTwoEntityConstants.AreaOneId] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_AreaTwoEntityConstants.AreaOneId].ToString());
            }

            return entity;
        }
    }
}
