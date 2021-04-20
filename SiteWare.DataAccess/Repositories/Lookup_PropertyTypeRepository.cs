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
    public static class Lookup_PropertyTypeRepository
    {

        public static ResultList<Lookup_PropertyTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_PropertyTypeEntity> result = new ResultList<Lookup_PropertyTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_PropertyTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_PropertyTypeEntity> list = new List<Lookup_PropertyTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_PropertyTypeEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultList<Lookup_PropertyTypeEntity>> SelectAll()
        {
            ResultList<Lookup_PropertyTypeEntity> result = new ResultList<Lookup_PropertyTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_PropertyTypeRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_PropertyTypeEntity> list = new List<Lookup_PropertyTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_PropertyTypeEntity entity = EntityHelper(reader, false);
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

      

        static Lookup_PropertyTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_PropertyTypeEntity entity = new Lookup_PropertyTypeEntity();

            entity.PropertyTypeID = Convert.ToInt32(reader[Lookup_PropertyTypeEntityConstants.PropertyTypeID].ToString());
            
            entity.PropertyType = reader[Lookup_PropertyTypeEntityConstants.PropertyType].ToString();
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_PropertyTypeEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Lookup_PropertyTypeEntityConstants.IsDelete].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_PropertyTypeEntityConstants.AddDate].ToString());

            entity.AddUser = Convert.ToInt32(reader[Lookup_PropertyTypeEntityConstants.AddUser].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_PropertyTypeEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToInt32(reader[Lookup_PropertyTypeEntityConstants.EditUser].ToString());

            return entity;
        }

    }
}
