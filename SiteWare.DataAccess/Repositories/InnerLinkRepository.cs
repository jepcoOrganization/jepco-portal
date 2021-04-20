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
    public static class InnerLinkRepository
    {
        public async static Task<ResultEntity<InnerLinkEntity>> SelectByID(int ID)
        {

            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(InnerLinkRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(InnerLinkRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<InnerLinkEntity>> SelectAll()
        {
            ResultList<InnerLinkEntity> result = new ResultList<InnerLinkEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(InnerLinkRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<InnerLinkEntity> list = new List<InnerLinkEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    InnerLinkEntity entity = EntityHelper(reader, false);
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
        public static ResultList<InnerLinkEntity> SelectAllWithoutAsync()
        {
            ResultList<InnerLinkEntity> result = new ResultList<InnerLinkEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(InnerLinkRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<InnerLinkEntity> list = new List<InnerLinkEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    InnerLinkEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<InnerLinkEntity>> Insert(InnerLinkEntity entity)
        {

            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(InnerLinkRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<InnerLinkEntity>> Update(InnerLinkEntity entity)
        {

            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(InnerLinkRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<InnerLinkEntity>> UpdateByIsDeleted(InnerLinkEntity entity)
        {

            ResultEntity<InnerLinkEntity> result = new ResultEntity<InnerLinkEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(InnerLinkRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(InnerLinkRepositoryConstants.ID, entity.ID);

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
        static InnerLinkEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            InnerLinkEntity entity = new InnerLinkEntity();

            entity.ID = Convert.ToInt32(reader[InnerLinkEntityConstants.ID].ToString());
            entity.Title = reader[InnerLinkEntityConstants.Title].ToString();
            entity.Image = reader[InnerLinkEntityConstants.Image].ToString();
            entity.Link = reader[InnerLinkEntityConstants.Link].ToString();
            entity.Target = reader[InnerLinkEntityConstants.Target].ToString();
            entity.LanguageID = Convert.ToByte(reader[InnerLinkEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[InnerLinkEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[InnerLinkEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[InnerLinkEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[InnerLinkEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[InnerLinkEntityConstants.EditDate].ToString());
            entity.AddUser = reader[InnerLinkEntityConstants.AddUser].ToString();
            entity.EditUser = reader[InnerLinkEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
