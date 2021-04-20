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
    public static class FAQRepository
    {
        public static ResultList<FAQEntity> SelectAllNotAsync()
        {
            ResultList<FAQEntity> result = new ResultList<FAQEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FAQRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<FAQEntity> list = new List<FAQEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    FAQEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<FAQEntity>> SelectByID(int ID)
        {

            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FAQRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(FAQRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<FAQEntity>> SelectAll()
        {
            ResultList<FAQEntity> result = new ResultList<FAQEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FAQRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<FAQEntity> list = new List<FAQEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    FAQEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<FAQEntity>> Insert(FAQEntity entity)
        {

            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FAQRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open(); 
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.Question, entity.Question);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.Answer, entity.Answer);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.EditUser, entity.EditUser);

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;

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
        public async static Task<ResultEntity<FAQEntity>> Update(FAQEntity entity)
        {

            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FAQRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open(); 
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.Question, entity.Question);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.Answer, entity.Answer);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.ID, entity.ID);

                await sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
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
        public async static Task<ResultEntity<FAQEntity>> UpdateByIsDeleted(FAQEntity entity)
        {

            ResultEntity<FAQEntity> result = new ResultEntity<FAQEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FAQRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(FAQRepositoryConstants.ID, entity.ID);

                await sqlCommand.ExecuteNonQueryAsync();
                result.Entity = entity;

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.UpdateSuccessMessage;
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
        static FAQEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            FAQEntity entity = new FAQEntity();

            entity.ID = Convert.ToInt32(reader[FAQEntityConstants.ID].ToString()); 
            entity.Question = reader[FAQEntityConstants.Question].ToString();
            entity.Answer = reader[FAQEntityConstants.Answer].ToString();
            entity.LanguageID = Convert.ToByte(reader[FAQEntityConstants.LanguageID].ToString());
            //entity.Order= Convert.ToInt32(reader[FAQEntityConstants.Order].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[FAQEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[FAQEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[FAQEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[FAQEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[FAQEntityConstants.EditDate].ToString());
            entity.AddUser = reader[FAQEntityConstants.AddUser].ToString();
            entity.EditUser = reader[FAQEntityConstants.EditUser].ToString();

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
                entity.LanguageName = reader[FAQEntityConstants.LanguageName].ToString();
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("Order");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.Order = reader[FAQEntityConstants.Order] == DBNull.Value ? 1 : Convert.ToInt32(reader[FAQEntityConstants.Order].ToString());
            }
            return entity;
        }
    }
}
