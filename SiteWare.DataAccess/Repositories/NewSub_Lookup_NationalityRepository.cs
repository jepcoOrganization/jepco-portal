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
   public static class NewSub_Lookup_NationalityRepository
    {
        public async static Task<ResultList<NewSub_Lookup_NationalityEntity>> SelectAll()
        {
            ResultList<NewSub_Lookup_NationalityEntity> result = new ResultList<NewSub_Lookup_NationalityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewSub_Lookup_NationalityRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewSub_Lookup_NationalityEntity> list = new List<NewSub_Lookup_NationalityEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    NewSub_Lookup_NationalityEntity entity = EntityHelper(reader, false);
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

        public static ResultList<NewSub_Lookup_NationalityEntity> SelectAllNotAsync()
        {
            ResultList<NewSub_Lookup_NationalityEntity> result = new ResultList<NewSub_Lookup_NationalityEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(NewSub_Lookup_NationalityRepositoryConstants.SelectALL, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<NewSub_Lookup_NationalityEntity> list = new List<NewSub_Lookup_NationalityEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    NewSub_Lookup_NationalityEntity entity = EntityHelper(reader, false);
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
        
        static NewSub_Lookup_NationalityEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            NewSub_Lookup_NationalityEntity entity = new NewSub_Lookup_NationalityEntity();

            entity.ID = Convert.ToInt32(reader[NewSub_Lookup_NationalityEntityConstants.ID].ToString());
            entity.Name = reader[NewSub_Lookup_NationalityEntityConstants.Name] == DBNull.Value ? string.Empty : reader[NewSub_Lookup_NationalityEntityConstants.Name].ToString();
            entity.IsPublished = reader[NewSub_Lookup_NationalityEntityConstants.IsPublished] == DBNull.Value ? true : Convert.ToBoolean(reader[NewSub_Lookup_NationalityEntityConstants.IsPublished].ToString());
            entity.IsDeleted = reader[NewSub_Lookup_NationalityEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[NewSub_Lookup_NationalityEntityConstants.IsDeleted].ToString());
            entity.AddDate = reader[NewSub_Lookup_NationalityEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[NewSub_Lookup_NationalityEntityConstants.AddDate].ToString());
            entity.AddUser = reader[NewSub_Lookup_NationalityEntityConstants.AddUser] == DBNull.Value ? string.Empty : reader[NewSub_Lookup_NationalityEntityConstants.AddUser].ToString();
            entity.EditDate = reader[NewSub_Lookup_NationalityEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[NewSub_Lookup_NationalityEntityConstants.EditDate].ToString());
            entity.EditUser = reader[NewSub_Lookup_NationalityEntityConstants.EditUser] == DBNull.Value ? string.Empty : reader[NewSub_Lookup_NationalityEntityConstants.EditUser].ToString();

            return entity;
        }

    }
}
