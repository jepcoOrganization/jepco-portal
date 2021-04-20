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
    public static class RenwableEnergyType3Phase2DetailsRepository
    {
        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsEntity>> SelectByID(long Type3Phase2Details)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsRepositoryConstants.Type3Phase2Details, Type3Phase2Details));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    reader.Read();
                    result.Entity = EntityHelper(reader, true);
                }
                else
                {
                    result.Status = ErrorEnums.Warning;
                    result.Message = MessageConstants.NotFoundMessage;
                    result.Details = MessageConstants.NotFoundDetails;
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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsEntity> SelectByIDNotAsync(long Type3Phase2Details)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenwableEnergyType3Phase2DetailsRepositoryConstants.Type3Phase2Details, Type3Phase2Details));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result.Entity = EntityHelper(reader, true);
                }
                else
                {
                    result.Status = ErrorEnums.Warning;
                    result.Message = MessageConstants.NotFoundMessage;
                    result.Details = MessageConstants.NotFoundDetails;
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
        public async static Task<ResultList<RenwableEnergyType3Phase2DetailsEntity>> SelectAll()
        {
            ResultList<RenwableEnergyType3Phase2DetailsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsEntity> list = new List<RenwableEnergyType3Phase2DetailsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenwableEnergyType3Phase2DetailsEntity> SelectAllNotAsync()
        {
            ResultList<RenwableEnergyType3Phase2DetailsEntity> result = new ResultList<RenwableEnergyType3Phase2DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenwableEnergyType3Phase2DetailsEntity> list = new List<RenwableEnergyType3Phase2DetailsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenwableEnergyType3Phase2DetailsEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenwableEnergyType3Phase2DetailsEntity>> Insert(RenwableEnergyType3Phase2DetailsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.DetailsID, entity.DetailsID);              
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.CompanyUserID, entity.CompanyUserID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.ACPower, entity.ACPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.DCPower, entity.DCPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment1, entity.Attachment1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment4, entity.Attachment4);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.IsAgree, entity.IsAgree);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsRepositoryConstants.Type3Phase2Details, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Type3Phase2Details = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsRepositoryConstants.Type3Phase2Details].Value);

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
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
        public static ResultEntity<RenwableEnergyType3Phase2DetailsEntity> InsertNotAsync(RenwableEnergyType3Phase2DetailsEntity entity)
        {

            ResultEntity<RenwableEnergyType3Phase2DetailsEntity> result = new ResultEntity<RenwableEnergyType3Phase2DetailsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenwableEnergyType3Phase2DetailsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.DetailsID, entity.DetailsID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.CompanyUserID, entity.CompanyUserID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.ACPower, entity.ACPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.DCPower, entity.DCPower);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment1, entity.Attachment1);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Attachment4, entity.Attachment4);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.IsAgree, entity.IsAgree);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenwableEnergyType3Phase2DetailsRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.Add(RenwableEnergyType3Phase2DetailsRepositoryConstants.Type3Phase2Details, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.Type3Phase2Details = Convert.ToInt64(sqlCommand.Parameters[RenwableEnergyType3Phase2DetailsRepositoryConstants.Type3Phase2Details].Value);

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.InsertSuccessMessage;
            }
            catch (Exception ex)
            {
                result.Status = ErrorEnums.Exception;
                //result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
                result.Details = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }

            return result;
        }
        static RenwableEnergyType3Phase2DetailsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenwableEnergyType3Phase2DetailsEntity entity = new RenwableEnergyType3Phase2DetailsEntity();

            try
            {

                entity.Type3Phase2Details = Convert.ToInt64(reader[RenwableEnergyType3Phase2DetailsEntityConstants.Type3Phase2Details].ToString());
                entity.DetailsID = reader[RenwableEnergyType3Phase2DetailsEntityConstants.DetailsID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenwableEnergyType3Phase2DetailsEntityConstants.DetailsID].ToString());               
                entity.CompanyUserID = reader[RenwableEnergyType3Phase2DetailsEntityConstants.CompanyUserID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenwableEnergyType3Phase2DetailsEntityConstants.CompanyUserID].ToString());
                entity.ACPower = reader[RenwableEnergyType3Phase2DetailsEntityConstants.ACPower] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.ACPower].ToString();
                entity.DCPower = reader[RenwableEnergyType3Phase2DetailsEntityConstants.DCPower] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.DCPower].ToString();
                entity.Attachment1 = reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment1] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment1].ToString();
                entity.Attachment2 = reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment2] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment2].ToString();
                entity.Attachment3 = reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment3] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment3].ToString();
                entity.Attachment4 = reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment4] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.Attachment4].ToString();
                entity.IsAgree = reader[RenwableEnergyType3Phase2DetailsEntityConstants.IsAgree] == DBNull.Value ? false : Convert.ToBoolean(reader[RenwableEnergyType3Phase2DetailsEntityConstants.IsAgree].ToString());
                entity.Order = reader[RenwableEnergyType3Phase2DetailsEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsEntityConstants.Order].ToString());
                entity.LanguageID = reader[RenwableEnergyType3Phase2DetailsEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenwableEnergyType3Phase2DetailsEntityConstants.LanguageID].ToString());
                entity.PublishDate = reader[RenwableEnergyType3Phase2DetailsEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[RenwableEnergyType3Phase2DetailsEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[RenwableEnergyType3Phase2DetailsEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[RenwableEnergyType3Phase2DetailsEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[RenwableEnergyType3Phase2DetailsEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[RenwableEnergyType3Phase2DetailsEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenwableEnergyType3Phase2DetailsEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenwableEnergyType3Phase2DetailsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenwableEnergyType3Phase2DetailsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenwableEnergyType3Phase2DetailsEntityConstants.EditUser].ToString();



                bool ColumnExists = false;
                try
                {
                    int columnOrdinal = reader.GetOrdinal("LanguageName");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.LanguageName = reader[RenwableEnergyType3Phase2DetailsEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[RenwableEnergyType3Phase2DetailsEntityConstants.LanguageName].ToString();
                }



            }
            catch (Exception ex)
            {

            }

            return entity;
        }



    }
}
