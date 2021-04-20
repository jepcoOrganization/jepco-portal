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
    public static class DirectNoteRepository
    {
        public async static Task<ResultEntity<DirectNoteEntity>> SelectByID(int ID)
        {

            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(DirectNoteRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<DirectNoteEntity>> SelectAll()
        {
            ResultList<DirectNoteEntity> result = new ResultList<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<DirectNoteEntity> list = new List<DirectNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    DirectNoteEntity entity = EntityHelper(reader, false);
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
        public static ResultList<DirectNoteEntity> SelectAllNotAsync()
        {
            ResultList<DirectNoteEntity> result = new ResultList<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<DirectNoteEntity> list = new List<DirectNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    DirectNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<DirectNoteEntity>> SelectTopOne()
        {
            ResultList<DirectNoteEntity> result = new ResultList<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_SelectTopOne, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<DirectNoteEntity> list = new List<DirectNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    DirectNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<DirectNoteEntity>> Update(DirectNoteEntity entity)
        {

            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<DirectNoteEntity>> UpdateByIsDeleted(DirectNoteEntity entity)
        {

            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<DirectNoteEntity>> InsertWelcomeNote(DirectNoteEntity entity)
        {

            ResultEntity<DirectNoteEntity> result = new ResultEntity<DirectNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(DirectNoteRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.TargetID, entity.TargetID);

                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(DirectNoteRepositoryConstants.EditUser, entity.EditUser);

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
        static DirectNoteEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            DirectNoteEntity entity = new DirectNoteEntity();

            entity.ID = Convert.ToInt32(reader[DirectNoteEntityConstants.ID].ToString());
            entity.Image = reader[DirectNoteEntityConstants.Image].ToString();
            entity.Link = reader[DirectNoteEntityConstants.Link].ToString();
            entity.TargetID = Convert.ToByte(reader[DirectNoteEntityConstants.TargetID].ToString());
            entity.Title = reader[DirectNoteEntityConstants.Title].ToString();
            entity.Summary = reader[DirectNoteEntityConstants.Summary].ToString();
            entity.Description = reader[DirectNoteEntityConstants.Description].ToString();
            entity.LanguageID = Convert.ToByte(reader[DirectNoteEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[DirectNoteEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[DirectNoteEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[DirectNoteEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[DirectNoteEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[DirectNoteEntityConstants.EditDate].ToString());
            entity.AddUser = reader[DirectNoteEntityConstants.AddUser].ToString();
            entity.EditUser = reader[DirectNoteEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[DirectNoteEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
