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
    public static class Lookup_LicenceTypeRepository
    {
        public async static Task<ResultList<Lookup_LicenceTypeEntity>> SelectAll()
        {
            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceTypeEntity> list = new List<Lookup_LicenceTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_LicenceTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_LicenceTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceTypeEntity> list = new List<Lookup_LicenceTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_LicenceTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_LicenceTypeEntity>> SelectByID(int LicenceTypeID)
        {

            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceTypeEntity> list = new List<Lookup_LicenceTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_LicenceTypeRepositoryConstants.LicenceTypeID, LicenceTypeID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_LicenceTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_LicenceTypeEntity> SelectByIDNotAsync(int LicenceTypeID)
        {

            ResultList<Lookup_LicenceTypeEntity> result = new ResultList<Lookup_LicenceTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceTypeEntity> list = new List<Lookup_LicenceTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_LicenceTypeRepositoryConstants.LicenceTypeID, LicenceTypeID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_LicenceTypeEntity entity = EntityHelper(reader, false);
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



        static Lookup_LicenceTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_LicenceTypeEntity entity = new Lookup_LicenceTypeEntity();

            entity.LicenceTypeID = Convert.ToInt32(reader[Lookup_LicenceTypeEntityConstants.LicenceTypeID].ToString());
            entity.LicenceTypeName = reader[Lookup_LicenceTypeEntityConstants.LicenceTypeName] == DBNull.Value ? string.Empty : reader[Lookup_LicenceTypeEntityConstants.LicenceTypeName].ToString();
            entity.Order = reader[Lookup_LicenceTypeEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_LicenceTypeEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_LicenceTypeEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_LicenceTypeEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_LicenceTypeEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_LicenceTypeEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_LicenceTypeEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_LicenceTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_LicenceTypeEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_LicenceTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_LicenceTypeEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_LicenceTypeEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_LicenceTypeEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_LicenceTypeEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_LicenceTypeEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_LicenceTypeEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_LicenceTypeEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_LicenceTypeEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
