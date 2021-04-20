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
    public static class StatisticNoteRepository
    {
        public async static Task<ResultEntity<StatisticNoteEntity>> SelectByID(int ID)
        {

            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(StatisticNoteRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<StatisticNoteEntity>> SelectAll()
        {
            ResultList<StatisticNoteEntity> result = new ResultList<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<StatisticNoteEntity> list = new List<StatisticNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    StatisticNoteEntity entity = EntityHelper(reader, false);
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
        public static ResultList<StatisticNoteEntity> SelectAllNotAsync()
        {
            ResultList<StatisticNoteEntity> result = new ResultList<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<StatisticNoteEntity> list = new List<StatisticNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    StatisticNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<StatisticNoteEntity>> SelectTopOne()
        {
            ResultList<StatisticNoteEntity> result = new ResultList<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_SelectTopOne, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<StatisticNoteEntity> list = new List<StatisticNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    StatisticNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<StatisticNoteEntity>> Update(StatisticNoteEntity entity)
        {

            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<StatisticNoteEntity>> UpdateByIsDeleted(StatisticNoteEntity entity)
        {

            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<StatisticNoteEntity>> InsertWelcomeNote(StatisticNoteEntity entity)
        {

            ResultEntity<StatisticNoteEntity> result = new ResultEntity<StatisticNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(StatisticNoteRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.TargetID, entity.TargetID);

                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(StatisticNoteRepositoryConstants.EditUser, entity.EditUser);

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
        static StatisticNoteEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            StatisticNoteEntity entity = new StatisticNoteEntity();

            entity.ID = Convert.ToInt32(reader[StatisticNoteEntityConstants.ID].ToString());
            entity.Image = reader[StatisticNoteEntityConstants.Image].ToString();
            entity.Link = reader[StatisticNoteEntityConstants.Link].ToString();
            entity.TargetID = Convert.ToByte(reader[StatisticNoteEntityConstants.TargetID].ToString());
            entity.Title = reader[StatisticNoteEntityConstants.Title].ToString();
            entity.Summary = reader[StatisticNoteEntityConstants.Summary].ToString();
            entity.Description = reader[StatisticNoteEntityConstants.Description].ToString();
            entity.LanguageID = Convert.ToByte(reader[StatisticNoteEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[StatisticNoteEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[StatisticNoteEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[StatisticNoteEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[StatisticNoteEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[StatisticNoteEntityConstants.EditDate].ToString());
            entity.AddUser = reader[StatisticNoteEntityConstants.AddUser].ToString();
            entity.EditUser = reader[StatisticNoteEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[StatisticNoteEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
