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
    public static class Plugin_ServiceProviderRepository
    {
        public static ResultList<Plugin_ServiceProviderEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_ServiceProviderEntity> result = new ResultList<Plugin_ServiceProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceProviderRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ServiceProviderEntity> list = new List<Plugin_ServiceProviderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_ServiceProviderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> SelectByID(long ID)
        {

            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceProviderRepositoryConstant.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_ServiceProviderRepositoryConstant.ProviderID, ID));
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
        public async static Task<ResultList<Plugin_ServiceProviderEntity>> SelectAll()
        {
            ResultList<Plugin_ServiceProviderEntity> result = new ResultList<Plugin_ServiceProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceProviderRepositoryConstant.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_ServiceProviderEntity> list = new List<Plugin_ServiceProviderEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_ServiceProviderEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> Insert(Plugin_ServiceProviderEntity entity)
        {

            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceProviderRepositoryConstant.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.CategoryID, entity.CategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.SubCategoryID, entity.SubCategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Address1, entity.Address1);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Address2, entity.Address2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.GovernateID, entity.GovernateID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.RegionID, entity.RegionID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Details, entity.Details);
                sqlCommand.Parameters.Add(Plugin_ServiceProviderRepositoryConstant.ProviderID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

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
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> Update(Plugin_ServiceProviderEntity entity)
        {

            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceProviderRepositoryConstant.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.CategoryID, entity.CategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.SubCategoryID, entity.SubCategoryID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Name, entity.Name);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Address1, entity.Address1);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Address2, entity.Address2);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.MobileNumber, entity.MobileNumber);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.GovernateID, entity.GovernateID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.RegionID, entity.RegionID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.PublishedDate, entity.PublishedDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.Details, entity.Details);

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
        public async static Task<ResultEntity<Plugin_ServiceProviderEntity>> UpdateByIsDeleted(long ProviderID)
        {

            ResultEntity<Plugin_ServiceProviderEntity> result = new ResultEntity<Plugin_ServiceProviderEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_ServiceProviderRepositoryConstant.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_ServiceProviderRepositoryConstant.ProviderID, ProviderID);

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
        static Plugin_ServiceProviderEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_ServiceProviderEntity entity = new Plugin_ServiceProviderEntity();

            entity.ProviderID = Convert.ToInt64(reader[Plugin_ServiceProviderEntityConstants.ProviderID].ToString());
            entity.SubCategoryID = Convert.ToInt64(reader[Plugin_ServiceProviderEntityConstants.SubCategoryID].ToString());
            entity.CategoryID = Convert.ToInt64(reader[Plugin_ServiceProviderEntityConstants.CategoryID].ToString());
            entity.Name = reader[Plugin_ServiceProviderEntityConstants.Name].ToString();
            entity.Address1 = reader[Plugin_ServiceProviderEntityConstants.Address1].ToString();
            entity.Address2 = reader[Plugin_ServiceProviderEntityConstants.Address2].ToString();
            entity.MobileNumber = reader[Plugin_ServiceProviderEntityConstants.MobileNumber].ToString();
            entity.GovernateID = Convert.ToInt64(reader[Plugin_ServiceProviderEntityConstants.GovernateID].ToString());
            entity.RegionID = Convert.ToInt64(reader[Plugin_ServiceProviderEntityConstants.RegionID].ToString());
            entity.Longitude = reader[Plugin_ServiceProviderEntityConstants.Longitude].ToString();
            entity.Latitude = reader[Plugin_ServiceProviderEntityConstants.Latitude].ToString();
            entity.Image = reader[Plugin_ServiceProviderEntityConstants.Image].ToString();
            entity.Order = Convert.ToInt32(reader[Plugin_ServiceProviderEntityConstants.Order].ToString());
            entity.LanguageID = Convert.ToInt32(reader[Plugin_ServiceProviderEntityConstants.LanguageID].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_ServiceProviderEntityConstants.IsDeleted].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_ServiceProviderEntityConstants.IsPublished].ToString());
            entity.PublishedDate = Convert.ToDateTime(reader[Plugin_ServiceProviderEntityConstants.PublishedDate].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_ServiceProviderEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_ServiceProviderEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_ServiceProviderEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_ServiceProviderEntityConstants.EditUser].ToString();
            entity.Details = reader[Plugin_ServiceProviderEntityConstants.Details].ToString();

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
                entity.LanguageName = reader[Plugin_ServiceProviderEntityConstants.LanguageName].ToString();
            }

            //------------------------------ Get Category Name -------------------------------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("CategoryName");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.CategoryName = reader[Plugin_ServiceProviderEntityConstants.CategoryName].ToString();
            }

            //------------------------------ Get SubCategory Name -------------------------------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("SubCatName");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.SubCatName = reader[Plugin_ServiceProviderEntityConstants.SubCatName].ToString();
            }

            //------------------------------ Get Governate Name -------------------------------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("GovernateName");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.GovernateName = reader[Plugin_ServiceProviderEntityConstants.GovernateName].ToString();
            }

            //------------------------------ Get Region Name -------------------------------------------------
            try
            {
                int columnOrdinal = reader.GetOrdinal("RegionName");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.RegionName = reader[Plugin_ServiceProviderEntityConstants.RegionName].ToString();
            }
            return entity;
        }
    }
}
