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
   public class SectionLanguageRepository
    {
        public async static Task<ResultList<SectionLanguageEntity>> SelectAll()
        {
            ResultList<SectionLanguageEntity> result = new ResultList<SectionLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SectionLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SectionLanguageEntity> list = new List<SectionLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    SectionLanguageEntity entity = EntityHelper(reader, false);
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

        public static ResultList<SectionLanguageEntity> SelectAllNotAsync()
        {
            ResultList<SectionLanguageEntity> result = new ResultList<SectionLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SectionLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SectionLanguageEntity> list = new List<SectionLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    SectionLanguageEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultList<SectionLanguageEntity>> SelectByDepartmentID(int DepartmentID)
        {
            ResultList<SectionLanguageEntity> result = new ResultList<SectionLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SectionLanguageRepositoryConstants.SP_SelectByDepartmentID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<SectionLanguageEntity> list = new List<SectionLanguageEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SectionLanguageRepositoryConstants.DepartmentID, DepartmentID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    SectionLanguageEntity entity = EntityHelper(reader, false);
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
        static SectionLanguageEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            SectionLanguageEntity entity = new SectionLanguageEntity();

            entity.SectionID = Convert.ToByte(reader[SectionLanguageEntityConstants.SectionID].ToString());
            entity.LanguageID = Convert.ToByte(reader[SectionLanguageEntityConstants.LanguageID].ToString());
            entity.Name = reader[SectionLanguageEntityConstants.Name].ToString();
            entity.AddDate = Convert.ToDateTime(reader[SectionLanguageEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[SectionLanguageEntityConstants.EditDate].ToString());
            entity.AddUser = reader[SectionLanguageEntityConstants.AddUser].ToString();
            entity.EditUser = reader[SectionLanguageEntityConstants.EditUser].ToString();

            return entity;
        }
    }
}
