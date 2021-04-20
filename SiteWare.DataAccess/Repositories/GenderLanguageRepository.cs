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
   public class GenderLanguageRepository
    {
        public async static Task<ResultList<GenderLanguageEntity>> SelectAll()
        {
            ResultList<GenderLanguageEntity> result = new ResultList<GenderLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(GenderLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<GenderLanguageEntity> list = new List<GenderLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    GenderLanguageEntity entity = EntityHelper(reader, false);
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
        public  static ResultList<GenderLanguageEntity> SelectAllNotAsync()
        {
            ResultList<GenderLanguageEntity> result = new ResultList<GenderLanguageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(GenderLanguageRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<GenderLanguageEntity> list = new List<GenderLanguageEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader =  sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    GenderLanguageEntity entity = EntityHelper(reader, false);
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
        static GenderLanguageEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            try
            { 
                GenderLanguageEntity entity = new GenderLanguageEntity();
                entity.GenderID = Convert.ToByte(reader[GenderLanguageEntityConstants.GenderID].ToString());
                entity.LanguageID = Convert.ToByte(reader[GenderLanguageEntityConstants.LanguageID].ToString());
                entity.Name = reader[GenderLanguageEntityConstants.Name].ToString();
                entity.AddDate = Convert.ToDateTime(reader[GenderLanguageEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[GenderLanguageEntityConstants.EditDate].ToString());
                entity.AddUser = reader[GenderLanguageEntityConstants.AddUser].ToString();
                entity.EditUser = reader[GenderLanguageEntityConstants.EditUser].ToString();

                return entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
            
        
    }
}

