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
    public static class Lookup_LicenceYearRepository
    {
        public async static Task<ResultList<Lookup_LicenceYearEntity>> SelectAll()
        {
            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceYearRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceYearEntity> list = new List<Lookup_LicenceYearEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_LicenceYearEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_LicenceYearEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceYearRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceYearEntity> list = new List<Lookup_LicenceYearEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_LicenceYearEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_LicenceYearEntity>> SelectByID(int LicenceYearID)
        {

            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceYearRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceYearEntity> list = new List<Lookup_LicenceYearEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_LicenceYearRepositoryConstants.LicenceYearID, LicenceYearID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_LicenceYearEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_LicenceYearEntity> SelectByIDNotAsync(int LicenceYearID)
        {

            ResultList<Lookup_LicenceYearEntity> result = new ResultList<Lookup_LicenceYearEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_LicenceYearRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_LicenceYearEntity> list = new List<Lookup_LicenceYearEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_LicenceYearRepositoryConstants.LicenceYearID, LicenceYearID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_LicenceYearEntity entity = EntityHelper(reader, false);
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



        static Lookup_LicenceYearEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_LicenceYearEntity entity = new Lookup_LicenceYearEntity();

            entity.LicenceYearID = Convert.ToInt32(reader[Lookup_LicenceYearEntityConstants.LicenceYearID].ToString());
            entity.LicenceYearName = reader[Lookup_LicenceYearEntityConstants.LicenceYearName] == DBNull.Value ? string.Empty : reader[Lookup_LicenceYearEntityConstants.LicenceYearName].ToString();
            entity.Order = reader[Lookup_LicenceYearEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_LicenceYearEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_LicenceYearEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_LicenceYearEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_LicenceYearEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_LicenceYearEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_LicenceYearEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_LicenceYearEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_LicenceYearEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_LicenceYearEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_LicenceYearEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_LicenceYearEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_LicenceYearEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_LicenceYearEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_LicenceYearEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_LicenceYearEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_LicenceYearEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_LicenceYearEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
