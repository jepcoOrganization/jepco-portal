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
    public static class WelcomeNoteRepository
    {
        public async static Task<ResultEntity<WelcomeNoteEntity>> SelectByID(int ID)
        {

            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(WelcomeNoteRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<WelcomeNoteEntity>> SelectAll()
        {
            ResultList<WelcomeNoteEntity> result = new ResultList<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<WelcomeNoteEntity> list = new List<WelcomeNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    WelcomeNoteEntity entity = EntityHelper(reader, false);
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
        public static ResultList<WelcomeNoteEntity> SelectAllNotAsync()
        {
            ResultList<WelcomeNoteEntity> result = new ResultList<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<WelcomeNoteEntity> list = new List<WelcomeNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    WelcomeNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<WelcomeNoteEntity>> SelectTopOne()
        {
            ResultList<WelcomeNoteEntity> result = new ResultList<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_SelectTopOne, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<WelcomeNoteEntity> list = new List<WelcomeNoteEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    WelcomeNoteEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<WelcomeNoteEntity>> Update(WelcomeNoteEntity entity)
        {

            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonText, entity.ButtonText);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonLink, entity.ButtonLink);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonTarget, entity.ButtonTarget);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonText1, entity.ButtonText1);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonLink1, entity.ButtonLink1);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonTarget1, entity.ButtonTarget1);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonText2, entity.ButtonText2);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonLink2, entity.ButtonLink2);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonTarget2, entity.ButtonTarget2);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Order, entity.Order);

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
        public async static Task<ResultEntity<WelcomeNoteEntity>> UpdateByIsDeleted(WelcomeNoteEntity entity)
        {

            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<WelcomeNoteEntity>> InsertWelcomeNote(WelcomeNoteEntity entity)
        {

            ResultEntity<WelcomeNoteEntity> result = new ResultEntity<WelcomeNoteEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNoteRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.TargetID, entity.TargetID);

                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonText, entity.ButtonText);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonLink, entity.ButtonLink);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonTarget, entity.ButtonTarget);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonText1, entity.ButtonText1);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonLink1, entity.ButtonLink1);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonTarget1, entity.ButtonTarget1);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonText2, entity.ButtonText2);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonLink2, entity.ButtonLink2);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.ButtonTarget2, entity.ButtonTarget2);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(WelcomeNoteRepositoryConstants.Order, entity.Order);

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
        static WelcomeNoteEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            WelcomeNoteEntity entity = new WelcomeNoteEntity();

            entity.ID = Convert.ToInt32(reader[WelcomeNoteEntityConstants.ID].ToString());
            entity.Image = reader[WelcomeNoteEntityConstants.Image].ToString();
            entity.Link = reader[WelcomeNoteEntityConstants.Link].ToString();
            entity.TargetID = reader[WelcomeNoteEntityConstants.TargetID].ToString();
            entity.Title = reader[WelcomeNoteEntityConstants.Title].ToString();
            //entity.ButtonText = reader[WelcomeNoteEntityConstants.ButtonText] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText].ToString();
            //entity.ButtonLink = reader[WelcomeNoteEntityConstants.ButtonLink] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonLink].ToString();
            //entity.ButtonTarget = reader[WelcomeNoteEntityConstants.ButtonTarget] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonTarget].ToString();
            //entity.ButtonText1 = reader[WelcomeNoteEntityConstants.ButtonText1] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText1].ToString();
            //entity.ButtonLink1 = reader[WelcomeNoteEntityConstants.ButtonLink1] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonLink1].ToString();
            //entity.ButtonTarget1 = reader[WelcomeNoteEntityConstants.ButtonText2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText2].ToString();
            //entity.ButtonText2 = reader[WelcomeNoteEntityConstants.ButtonText2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText2].ToString();
            //entity.ButtonLink2 = reader[WelcomeNoteEntityConstants.ButtonLink2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonLink2].ToString();
            //entity.ButtonTarget2 = reader[WelcomeNoteEntityConstants.ButtonTarget2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonTarget2].ToString();
            entity.Summary = reader[WelcomeNoteEntityConstants.Summary].ToString();
            entity.Description = reader[WelcomeNoteEntityConstants.Description].ToString();
            entity.LanguageID = Convert.ToByte(reader[WelcomeNoteEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[WelcomeNoteEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[WelcomeNoteEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[WelcomeNoteEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[WelcomeNoteEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[WelcomeNoteEntityConstants.EditDate].ToString());
            entity.AddUser = reader[WelcomeNoteEntityConstants.AddUser].ToString();
            entity.EditUser = reader[WelcomeNoteEntityConstants.EditUser].ToString();
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
                entity.LanguageName = reader[WelcomeNoteEntityConstants.LanguageName].ToString();
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
                entity.Order = reader[WelcomeNoteEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[WelcomeNoteEntityConstants.Order].ToString());
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonText");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonText = reader[WelcomeNoteEntityConstants.ButtonText] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonLink");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonLink = reader[WelcomeNoteEntityConstants.ButtonLink] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonLink].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonTarget");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonTarget = reader[WelcomeNoteEntityConstants.ButtonTarget] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonTarget].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonText1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonText1 = reader[WelcomeNoteEntityConstants.ButtonText1] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText1].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonLink1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonLink1 = reader[WelcomeNoteEntityConstants.ButtonLink1] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonLink1].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonTarget1");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonTarget1 = reader[WelcomeNoteEntityConstants.ButtonTarget1] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonTarget1].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonText2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonText2 = reader[WelcomeNoteEntityConstants.ButtonText2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonText2].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonLink2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonLink2 = reader[WelcomeNoteEntityConstants.ButtonLink2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonLink2].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("ButtonTarget2");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }
            if (ColumnExists)
            {
                entity.ButtonTarget2 = reader[WelcomeNoteEntityConstants.ButtonTarget2] == DBNull.Value ? string.Empty : reader[WelcomeNoteEntityConstants.ButtonTarget2].ToString();
            }
            return entity;
        }
    }
}
