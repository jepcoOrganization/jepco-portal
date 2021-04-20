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
   public class Lookup_CertficationType_Repository
    {
        public async static Task<ResultList<Lookup_CertificationTypeEntity>> SelectAll()
        {
            ResultList<Lookup_CertificationTypeEntity> result = new ResultList<Lookup_CertificationTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CertificationType_RepositoryConstatnts.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CertificationTypeEntity> list = new List<Lookup_CertificationTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Lookup_CertificationTypeEntity entity = EntityHelper(reader, false);
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


        public static ResultList<Lookup_CertificationTypeEntity> SelectAllNotAsync()
        {
            ResultList<Lookup_CertificationTypeEntity> result = new ResultList<Lookup_CertificationTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Lookup_CertificationType_RepositoryConstatnts.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Lookup_CertificationTypeEntity> list = new List<Lookup_CertificationTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Lookup_CertificationTypeEntity entity = EntityHelper(reader, false);
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

        static Lookup_CertificationTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Lookup_CertificationTypeEntity entity = new Lookup_CertificationTypeEntity();

            entity.CertificationTypeID = Convert.ToInt32(reader[Lookup_CertificationTypeEntityConstants.CertificationTypeID].ToString());

            entity.CertificationType = reader[Lookup_CertificationTypeEntityConstants.CertificationType].ToString();
            entity.LanguageID = Convert.ToInt32(reader[Lookup_CertificationTypeEntityConstants.LanguageID].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Lookup_CertificationTypeEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[Lookup_CertificationTypeEntityConstants.IsDelete].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Lookup_CertificationTypeEntityConstants.AddDate].ToString());
            entity.AddUser = Convert.ToInt32(reader[Lookup_CertificationTypeEntityConstants.AddUser].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Lookup_CertificationTypeEntityConstants.EditDate].ToString());
            entity.EditUser = Convert.ToInt32(reader[Lookup_CertificationTypeEntityConstants.EditUser].ToString());

            return entity;
        }
    }
}
