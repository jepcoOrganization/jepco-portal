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
   public class DepartmentLanguageRepository
    {
        public async static Task<ResultList<DepartmentLanguageEntity>> SelectAll()
        {
            ResultList<DepartmentLanguageEntity> result = new ResultList<DepartmentLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DepartmentLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<DepartmentLanguageEntity> list = new List<DepartmentLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    DepartmentLanguageEntity entity = EntityHelper(reader, false);
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

        public  static ResultList<DepartmentLanguageEntity> SelectAllNotAsync()
        {
            ResultList<DepartmentLanguageEntity> result = new ResultList<DepartmentLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DepartmentLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<DepartmentLanguageEntity> list = new List<DepartmentLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    DepartmentLanguageEntity entity = EntityHelper(reader, false);
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
        static DepartmentLanguageEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            DepartmentLanguageEntity entity = new DepartmentLanguageEntity();

            entity.DepartmentID = Convert.ToByte(reader[DepartmentLanguageEntityConstants.DepartmentID].ToString());
            entity.LanguageID = Convert.ToByte(reader[DepartmentLanguageEntityConstants.LanguageID].ToString());
            entity.Name = reader[DepartmentLanguageEntityConstants.Name].ToString();
            entity.AddDate = Convert.ToDateTime(reader[DepartmentLanguageEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[DepartmentLanguageEntityConstants.EditDate].ToString());
            entity.AddUser = reader[DepartmentLanguageEntityConstants.AddUser].ToString();
            entity.EditUser = reader[DepartmentLanguageEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
