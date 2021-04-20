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
   public class Lookup_ServiceUserTypeRepository
    {
        public async static Task<ResultList<Lookup_ServiceUserTypeEntity>> SelectAll()
        {
            ResultList<Lookup_ServiceUserTypeEntity> result = new ResultList<Lookup_ServiceUserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ServiceUserTypeRepositoryConstants.SP_SelectAll, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            List<Lookup_ServiceUserTypeEntity> list = new List<Lookup_ServiceUserTypeEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_ServiceUserTypeEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Lookup_ServiceUserTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_ServiceUserTypeEntity> result = new ResultList<Lookup_ServiceUserTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_ServiceUserTypeRepositoryConstants.SP_SelectAll, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            List<Lookup_ServiceUserTypeEntity> list = new List<Lookup_ServiceUserTypeEntity>();

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_ServiceUserTypeEntity entity = EntityHelper(reader, false);
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
        static Lookup_ServiceUserTypeEntity EntityHelper(SqlDataReader reader, bool v)
        {

            Lookup_ServiceUserTypeEntity entity = new Lookup_ServiceUserTypeEntity();
            entity.ID = Convert.ToInt32(reader[Lookup_ServiceUserTypeEntityConstants.ID].ToString());
            entity.Name = reader[Lookup_ServiceUserTypeEntityConstants.Name].ToString();
            entity.IsDeleted = Convert.ToBoolean(reader[Lookup_ServiceUserTypeEntityConstants.IsDeleted].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_ServiceUserTypeEntityConstants.IsPublished].ToString());
            entity.AddUser = Convert.ToInt32(reader[Lookup_ServiceUserTypeEntityConstants.AddUser].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_ServiceUserTypeEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_ServiceUserTypeEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToInt32(reader[Lookup_ServiceUserTypeEntityConstants.EditUser].ToString());

            return entity;
        }

    }
}
