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
   public static class Lookup_ComplainTypeRepository
    {
        public async static Task<ResultList<Lookup_ComplainTypeEntity>> SelectAll()
        {
            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ComplainTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ComplainTypeEntity> list = new List<Lookup_ComplainTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_ComplainTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_ComplainTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ComplainTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ComplainTypeEntity> list = new List<Lookup_ComplainTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_ComplainTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_ComplainTypeEntity>> SelectByID(int ComplainTypeID)
        {

            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ComplainTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ComplainTypeEntity> list = new List<Lookup_ComplainTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_ComplainTypeRepositoryConstants.ComplainTypeID, ComplainTypeID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_ComplainTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_ComplainTypeEntity> SelectByIDNotAsync(int ComplainTypeID)
        {

            ResultList<Lookup_ComplainTypeEntity> result = new ResultList<Lookup_ComplainTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ComplainTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_ComplainTypeEntity> list = new List<Lookup_ComplainTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_ComplainTypeRepositoryConstants.ComplainTypeID, ComplainTypeID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_ComplainTypeEntity entity = EntityHelper(reader, false);
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



        static Lookup_ComplainTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_ComplainTypeEntity entity = new Lookup_ComplainTypeEntity();

            entity.ComplainTypeID = Convert.ToInt32(reader[Lookup_ComplainTypeEntityConstants.ComplainTypeID].ToString());
            entity.ComplainType = reader[Lookup_ComplainTypeEntityConstants.ComplainType] == DBNull.Value ? string.Empty : reader[Lookup_ComplainTypeEntityConstants.ComplainType].ToString();
            entity.IsPublished = reader[Lookup_ComplainTypeEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_ComplainTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_ComplainTypeEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_ComplainTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_ComplainTypeEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_ComplainTypeEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_ComplainTypeEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_ComplainTypeEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_ComplainTypeEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_ComplainTypeEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_ComplainTypeEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_ComplainTypeEntityConstants.EditUser].ToString();
            
            return entity;
        }

    }
}
