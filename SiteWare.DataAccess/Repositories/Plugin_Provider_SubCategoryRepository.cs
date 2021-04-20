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
    public static class Plugin_Provider_SubCategoryRepository
    {
        public static ResultList<Plugin_Provider_SubCategoryEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_Provider_SubCategoryEntity> result = new ResultList<Plugin_Provider_SubCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_SubCategoryRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Provider_SubCategoryEntity> list = new List<Plugin_Provider_SubCategoryEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_Provider_SubCategoryEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_SubCategoryRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_Provider_SubCategoryRepositoryConstant.SubCategoryID, ID));
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
        public async static Task<ResultList<Plugin_Provider_SubCategoryEntity>> SelectAll()
        {
            ResultList<Plugin_Provider_SubCategoryEntity> result = new ResultList<Plugin_Provider_SubCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_SubCategoryRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_Provider_SubCategoryEntity> list = new List<Plugin_Provider_SubCategoryEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_Provider_SubCategoryEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> Insert(Plugin_Provider_SubCategoryEntity entity)
        {

            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_SubCategoryRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.CategoryID, entity.CategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.SubCatName, entity.SubCatName);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Summury, entity.Summury);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(Plugin_Provider_SubCategoryRepositoryConstant.SubCategoryID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

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
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> Update(Plugin_Provider_SubCategoryEntity entity)
        {

            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_SubCategoryRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.SubCategoryID, entity.SubCategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.CategoryID, entity.CategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.SubCatName, entity.SubCatName);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Summury, entity.Summury);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<Plugin_Provider_SubCategoryEntity>> UpdateByIsDeleted(long SubCatID)
        {

            ResultEntity<Plugin_Provider_SubCategoryEntity> result = new ResultEntity<Plugin_Provider_SubCategoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_Provider_SubCategoryRepositoryConstant.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_Provider_SubCategoryRepositoryConstant.SubCategoryID, SubCatID);

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
        static Plugin_Provider_SubCategoryEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_Provider_SubCategoryEntity entity = new Plugin_Provider_SubCategoryEntity();

            entity.SubCategoryID = Convert.ToInt64(reader[Plugin_Provider_SubCategoryEntityConstants.SubCategoryID].ToString());
            entity.CategoryID = Convert.ToInt64(reader[Plugin_Provider_SubCategoryEntityConstants.CategoryID].ToString());
            entity.SubCatName = reader[Plugin_Provider_SubCategoryEntityConstants.SubCatName].ToString();
            entity.Image = reader[Plugin_Provider_SubCategoryEntityConstants.Image].ToString();
            entity.Summury = reader[Plugin_Provider_SubCategoryEntityConstants.Summury].ToString();
            entity.Description = reader[Plugin_Provider_SubCategoryEntityConstants.Description].ToString();
            entity.Order = Convert.ToInt32(reader[Plugin_Provider_SubCategoryEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToByte(reader[Plugin_Provider_SubCategoryEntityConstants.LanguageID].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_Provider_SubCategoryEntityConstants.IsPublished].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[Plugin_Provider_SubCategoryEntityConstants.PublishedDate].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_Provider_SubCategoryEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_Provider_SubCategoryEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_Provider_SubCategoryEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_Provider_SubCategoryEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_Provider_SubCategoryEntityConstants.EditUser].ToString();

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
                entity.LanguageName = reader[Plugin_Provider_SubCategoryEntityConstants.LanguageName].ToString();
            }
            return entity;
        }
    }
}
