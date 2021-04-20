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
    public static class WelcomeNote_ImageRepository
    {
        public static ResultList<WelcomeNote_ImageEntity> SelectAllNotAsync(long NoteID)
        {
            ResultList<WelcomeNote_ImageEntity> result = new ResultList<WelcomeNote_ImageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNote_ImageRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<WelcomeNote_ImageEntity> list = new List<WelcomeNote_ImageEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(WelcomeNote_ImageRepositoryConstant.WelcomeNoteID, NoteID));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    WelcomeNote_ImageEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<WelcomeNote_ImageEntity>> SelectAll(long NoteID)
        {
            ResultList<WelcomeNote_ImageEntity> result = new ResultList<WelcomeNote_ImageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNote_ImageRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<WelcomeNote_ImageEntity> list = new List<WelcomeNote_ImageEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(WelcomeNote_ImageRepositoryConstant.WelcomeNoteID, NoteID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    WelcomeNote_ImageEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> SelectByID(long ID)
        {

            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNote_ImageRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(WelcomeNote_ImageRepositoryConstant.ImageID, ID));
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
        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> UpdateImage(WelcomeNote_ImageEntity entity)
        {

            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNote_ImageRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.ImageID, entity.ImageID);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.WelcomeNoteID, entity.WelcomeNoteID);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.ImageOrder, entity.ImageOrder);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Publisheddate, entity.Publisheddate);                
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> InsertImage(WelcomeNote_ImageEntity entity)
        {

            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNote_ImageRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.WelcomeNoteID, entity.WelcomeNoteID);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.ImageOrder, entity.ImageOrder);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.Publisheddate, entity.Publisheddate);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(WelcomeNote_ImageRepositoryConstant.EditUser, entity.EditUser);                

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
        public async static Task<ResultEntity<WelcomeNote_ImageEntity>> DeleteImage(long ID)
        {
            ResultEntity<WelcomeNote_ImageEntity> result = new ResultEntity<WelcomeNote_ImageEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(WelcomeNote_ImageRepositoryConstant.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(WelcomeNote_ImageRepositoryConstant.ImageID, ID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.DeleteSuccessMessage;
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
        static WelcomeNote_ImageEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            WelcomeNote_ImageEntity entity = new WelcomeNote_ImageEntity();
            try
            {
                entity.ImageID = Convert.ToInt64(reader[WelcomeNote_ImageEntityConstants.ImageID].ToString());
                entity.WelcomeNoteID = Convert.ToInt32(reader[WelcomeNote_ImageEntityConstants.WelcomeNoteID].ToString());
                entity.Title = reader[WelcomeNote_ImageEntityConstants.Title].ToString();
                entity.Image = reader[WelcomeNote_ImageEntityConstants.Image].ToString();
                entity.Link = reader[WelcomeNote_ImageEntityConstants.Link].ToString();
                entity.Target = reader[WelcomeNote_ImageEntityConstants.Target].ToString();
                entity.ImageOrder = Convert.ToInt64(reader[WelcomeNote_ImageEntityConstants.ImageOrder].ToString());
                entity.IsPublished = Convert.ToBoolean(reader[WelcomeNote_ImageEntityConstants.IsPublished].ToString());
                entity.Publisheddate = Convert.ToDateTime(reader[WelcomeNote_ImageEntityConstants.Publisheddate].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[WelcomeNote_ImageEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[WelcomeNote_ImageEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[WelcomeNote_ImageEntityConstants.EditDate].ToString());
                entity.AddUser = reader[WelcomeNote_ImageEntityConstants.AddUser].ToString();
                entity.EditUser = reader[WelcomeNote_ImageEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {
            }
            return entity;
        }
    }
}
