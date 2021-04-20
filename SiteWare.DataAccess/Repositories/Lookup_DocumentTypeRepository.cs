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
   public static class Lookup_DocumentTypeRepository
    {
        public async static Task<ResultList<Lookup_DocumentTypeEntity>> SelectAll()
        {
            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_DocumentTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_DocumentTypeEntity> list = new List<Lookup_DocumentTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_DocumentTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_DocumentTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_DocumentTypeRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_DocumentTypeEntity> list = new List<Lookup_DocumentTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_DocumentTypeEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<Lookup_DocumentTypeEntity>> SelectByID(int DocumentTypeID)
        {

            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_DocumentTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_DocumentTypeEntity> list = new List<Lookup_DocumentTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_DocumentTypeRepositoryConstants.DocumentTypeID, DocumentTypeID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Lookup_DocumentTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_DocumentTypeEntity> SelectByIDNotAsync(int DocumentTypeID)
        {

            ResultList<Lookup_DocumentTypeEntity> result = new ResultList<Lookup_DocumentTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_DocumentTypeRepositoryConstants.SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_DocumentTypeEntity> list = new List<Lookup_DocumentTypeEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Lookup_DocumentTypeRepositoryConstants.DocumentTypeID, DocumentTypeID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Lookup_DocumentTypeEntity entity = EntityHelper(reader, false);
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



        static Lookup_DocumentTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_DocumentTypeEntity entity = new Lookup_DocumentTypeEntity();

            entity.DocumentTypeID = Convert.ToInt32(reader[Lookup_DocumentTypeEntityConstants.DocumentTypeID].ToString());
            entity.DocumentType = reader[Lookup_DocumentTypeEntityConstants.DocumentType] == DBNull.Value ? string.Empty : reader[Lookup_DocumentTypeEntityConstants.DocumentType].ToString();
            entity.IsPublished = reader[Lookup_DocumentTypeEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[Lookup_DocumentTypeEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[Lookup_DocumentTypeEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[Lookup_DocumentTypeEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[Lookup_DocumentTypeEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_DocumentTypeEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Lookup_DocumentTypeEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[Lookup_DocumentTypeEntityConstants.AddUser].ToString();
            entity.EditDate = reader[Lookup_DocumentTypeEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[Lookup_DocumentTypeEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Lookup_DocumentTypeEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[Lookup_DocumentTypeEntityConstants.EditUser].ToString();

            return entity;
        }

    }
}
