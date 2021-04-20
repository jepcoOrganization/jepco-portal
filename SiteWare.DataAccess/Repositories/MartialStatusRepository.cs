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
   public class MartialStatusRepository
    {
        public async static Task<ResultList<MartialStatusEntity>> SelectAll()
        {
            ResultList<MartialStatusEntity> result = new ResultList<MartialStatusEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MartialStatusRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MartialStatusEntity> list = new List<MartialStatusEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    MartialStatusEntity entity = EntityHelper(reader, false);
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

        public static ResultList<MartialStatusEntity> SelectAllNotAsync()
        {
            ResultList<MartialStatusEntity> result = new ResultList<MartialStatusEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(MartialStatusRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<MartialStatusEntity> list = new List<MartialStatusEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    MartialStatusEntity entity = EntityHelper(reader, false);
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

        static MartialStatusEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            MartialStatusEntity entity = new MartialStatusEntity();

            entity.MaritalStatusID = Convert.ToByte(reader[MartialStatusEntityConstatnts.MaritalStatusID].ToString());
            entity.LanguageID = Convert.ToByte(reader[MartialStatusEntityConstatnts.LanguageID].ToString());
            entity.Name = reader[MartialStatusEntityConstatnts.Name].ToString();
            entity.AddDate = Convert.ToDateTime(reader[MartialStatusEntityConstatnts.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[MartialStatusEntityConstatnts.EditDate].ToString());
            entity.AddUser = reader[MartialStatusEntityConstatnts.AddUser].ToString();
            entity.EditUser = reader[MartialStatusEntityConstatnts.EditUser].ToString();

            return entity;
        }
    }
}

