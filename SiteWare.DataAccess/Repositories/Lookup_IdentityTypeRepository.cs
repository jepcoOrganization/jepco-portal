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
   public static class Lookup_IdentityTypeRepository
    {

        public static ResultList<Lookup_IdentityTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_IdentityTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_IdentityTypeEntity> list = new List<Lookup_IdentityTypeEntity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_IdentityTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_IdentityTypeEntity>> SelectByID(int ID)
        {

            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_IdentityTypeRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_IdentityTypeEntity> list = new List<Lookup_IdentityTypeEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_IdentityTypeRepositoryConstants.ID, ID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_IdentityTypeEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Lookup_IdentityTypeEntity> SelectByIDNotAsync(int ID)
        {

            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_IdentityTypeRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_IdentityTypeEntity> list = new List<Lookup_IdentityTypeEntity>();
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_IdentityTypeRepositoryConstants.ID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_IdentityTypeEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<Lookup_IdentityTypeEntity>> SelectAll()
        {
            ResultList<Lookup_IdentityTypeEntity> result = new ResultList<Lookup_IdentityTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_IdentityTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_IdentityTypeEntity> list = new List<Lookup_IdentityTypeEntity>();
            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_IdentityTypeEntity entity = EntityHelper(reader, false);
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
        static Lookup_IdentityTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_IdentityTypeEntity entity = new Lookup_IdentityTypeEntity();

            entity.ID = Convert.ToInt32(reader[Lookup_IdentityTypeEntityConstants.ID].ToString());
            entity.IDType = reader[Lookup_IdentityTypeEntityConstants.IDType].ToString();
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_IdentityTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Lookup_IdentityTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_IdentityTypeEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_IdentityTypeEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Lookup_IdentityTypeEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Lookup_IdentityTypeEntityConstants.EditUser].ToString();

            return entity;
        }


    }
}
