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
    public static class Plugin_Provider_CategoryRepository
    {
        public static ResultList<Plugin_Provider_CategoryEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_Provider_CategoryEntity> result = new ResultList<Plugin_Provider_CategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_CategoryRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Provider_CategoryEntity> list = new List<Plugin_Provider_CategoryEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_Provider_CategoryEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_CategoryRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Provider_CategoryRepositoryConstant.CategoryID, ID));
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
        public async static Task<ResultList<Plugin_Provider_CategoryEntity>> SelectAll()
        {
            ResultList<Plugin_Provider_CategoryEntity> result = new ResultList<Plugin_Provider_CategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_CategoryRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Provider_CategoryEntity> list = new List<Plugin_Provider_CategoryEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_Provider_CategoryEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> Insert(Plugin_Provider_CategoryEntity entity)
        {

            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_CategoryRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.CategoryName, entity.CategoryName);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Summury, entity.Summury);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Provider_CategoryRepositoryConstant.CategoryID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

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
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> Update(Plugin_Provider_CategoryEntity entity)
        {

            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_CategoryRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.CategoryName, entity.CategoryName);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Summury, entity.Summury);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.CategoryID, entity.CategoryID);

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
        public async static Task<ResultEntity<Plugin_Provider_CategoryEntity>> UpdateByIsDeleted(long CatID)
        {

            ResultEntity<Plugin_Provider_CategoryEntity> result = new ResultEntity<Plugin_Provider_CategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_CategoryRepositoryConstant.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_CategoryRepositoryConstant.CategoryID, CatID);

                await sqlCommand.ExecuteNonQueryAsync();
               // result.Entity = entity;

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
        static Plugin_Provider_CategoryEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_Provider_CategoryEntity entity = new Plugin_Provider_CategoryEntity();

            entity.CategoryID = Convert.ToInt64(reader[Plugin_Provider_CategoryEntityConstants.CategoryID].ToString());
            entity.CategoryName = reader[Plugin_Provider_CategoryEntityConstants.CategoryName].ToString();
            entity.Image = reader[Plugin_Provider_CategoryEntityConstants.Image].ToString();
            entity.Summury = reader[Plugin_Provider_CategoryEntityConstants.Summury].ToString();
            entity.Description = reader[Plugin_Provider_CategoryEntityConstants.Description].ToString();
            entity.Order = Convert.ToInt32(reader[Plugin_Provider_CategoryEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[Plugin_Provider_CategoryEntityConstants.LanguageID].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_Provider_CategoryEntityConstants.IsPublished].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[Plugin_Provider_CategoryEntityConstants.PublishedDate].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_Provider_CategoryEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_Provider_CategoryEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_Provider_CategoryEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_Provider_CategoryEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_Provider_CategoryEntityConstants.EditUser].ToString();

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
                entity.LanguageName = reader[Plugin_Provider_CategoryEntityConstants.LanguageName].ToString();
            }

            return entity;
        }
    }
}
