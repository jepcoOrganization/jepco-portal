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
    public static class Lookup_AreaOneRepository
    {

        public async static Task<ResultList<Lookup_AreaOneEntity>> SelectAll()
        {
            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaOneRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaOneEntity> list = new List<Lookup_AreaOneEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_AreaOneEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_AreaOneEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaOneRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaOneEntity> list = new List<Lookup_AreaOneEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_AreaOneEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_AreaOneEntity>> SelectByID(int AreaOneID)
        {

            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaOneRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaOneEntity> list = new List<Lookup_AreaOneEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_AreaOneRepositoryConstants.AreaOneID, AreaOneID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_AreaOneEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_AreaOneEntity> SelectByIDNotAsync(int AreaOneID)
        {

            ResultList<Lookup_AreaOneEntity> result = new ResultList<Lookup_AreaOneEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_AreaOneRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_AreaOneEntity> list = new List<Lookup_AreaOneEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_AreaOneRepositoryConstants.AreaOneID, AreaOneID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_AreaOneEntity entity = EntityHelper(reader, false);
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



        static Lookup_AreaOneEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_AreaOneEntity entity = new Lookup_AreaOneEntity();

            entity.AreaOneID = Convert.ToInt32(reader[Lookup_AreaOneEntityConstants.AreaOneID].ToString());
            entity.AreaOneName = reader[Lookup_AreaOneEntityConstants.AreaOneName] == DBNull.Value ? string.Empty : reader[Lookup_AreaOneEntityConstants.AreaOneName].ToString();
            entity.Order = reader[Lookup_AreaOneEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_AreaOneEntityConstants.Order].ToString());
            entity.LanguageID = reader[Lookup_AreaOneEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_AreaOneEntityConstants.LanguageID].ToString());
            entity.PublishDate = reader[Lookup_AreaOneEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_AreaOneEntityConstants.PublishDate].ToString());
            entity.IsPublished = reader[Lookup_AreaOneEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_AreaOneEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_AreaOneEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_AreaOneEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_AreaOneEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_AreaOneEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_AreaOneEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_AreaOneEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_AreaOneEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_AreaOneEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_AreaOneEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_AreaOneEntityConstants.EditUser].ToString();

            bool ColumnExists = false;
            try
            {
                int columnOrdinal = reader.GetOrdinal("CityId");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.CityId = reader[Lookup_AreaOneEntityConstants.CityId] == DBNull.Value ? 0 : Convert.ToInt32(reader[Lookup_AreaOneEntityConstants.CityId].ToString());
            }

            return entity;
        }
    }
}
