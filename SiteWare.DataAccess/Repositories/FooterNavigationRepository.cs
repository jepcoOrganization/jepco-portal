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
    public static class FooterNavigationRepository
    {
        public async static Task<ResultEntity<FooterNavigationEntity>> SelectByID(int ID)
        {

            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FooterNavigationRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(FooterNavigationRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<FooterNavigationEntity>> SelectAll()
        {
            ResultList<FooterNavigationEntity> result = new ResultList<FooterNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FooterNavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<FooterNavigationEntity> list = new List<FooterNavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    FooterNavigationEntity entity = EntityHelper(reader, false);
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
        public static ResultList<FooterNavigationEntity> SelectAllWithoutAsync()
        {
            ResultList<FooterNavigationEntity> result = new ResultList<FooterNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FooterNavigationRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<FooterNavigationEntity> list = new List<FooterNavigationEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    FooterNavigationEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<FooterNavigationEntity>> Insert(FooterNavigationEntity entity)
        {

            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FooterNavigationRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.MenuOrder, entity.MenuOrder);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.ParentID, entity.ParentID);

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
        public async static Task<ResultEntity<FooterNavigationEntity>> Update(FooterNavigationEntity entity)
        {

            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FooterNavigationRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.URL, entity.URL);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.MenuOrder, entity.MenuOrder);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.ParentID, entity.ParentID);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<FooterNavigationEntity>> UpdateByIsDeleted(FooterNavigationEntity entity)
        {

            ResultEntity<FooterNavigationEntity> result = new ResultEntity<FooterNavigationEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(FooterNavigationRepositoryConstants.SP_UpdateByIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(FooterNavigationRepositoryConstants.ID, entity.ID);

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
        static FooterNavigationEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            FooterNavigationEntity entity = new FooterNavigationEntity();

            entity.ID = Convert.ToInt32(reader[FooterNavigationEntityConstants.ID].ToString());
            entity.Title = reader[FooterNavigationEntityConstants.Title].ToString();
            entity.URL = reader[FooterNavigationEntityConstants.URL].ToString();
            entity.Target = reader[FooterNavigationEntityConstants.Target].ToString();
            entity.LanguageID = Convert.ToByte(reader[FooterNavigationEntityConstants.LanguageID].ToString());
            entity.PublishDate = Convert.ToDateTime(reader[FooterNavigationEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[FooterNavigationEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[FooterNavigationEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[FooterNavigationEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[FooterNavigationEntityConstants.EditDate].ToString());
            entity.AddUser = reader[FooterNavigationEntityConstants.AddUser].ToString();
            entity.EditUser = reader[FooterNavigationEntityConstants.EditUser].ToString();
            entity.ParentID = Convert.ToInt32(reader[FooterNavigationEntityConstants.ParentID]);

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
                entity.LanguageName = reader[FooterNavigationEntityConstants.LanguageName].ToString();
            }
            try
            {
                int columnOrdinal = reader.GetOrdinal("MenuOrder");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.MenuOrder = reader[FooterNavigationEntityConstants.MenuOrder] == DBNull.Value ? 0 : Convert.ToInt32(reader[FooterNavigationEntityConstants.MenuOrder].ToString());
            }
            else
            {
                entity.MenuOrder = 0;
            }
            return entity;
        }
    }
}
