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
    public static class Plugin_PropertyRepository
    {
        public static ResultList<Plugin_PropertyEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyEntity> list = new List<Plugin_PropertyEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PropertyEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_PropertyEntity>> Property_SelectByID(long ID)
        {

            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyRepositoryConstants.PropertyID, ID));
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

        public static ResultEntity<Plugin_PropertyEntity> Property_SelectByIDNotAsync(int ID)
        {

            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyRepositoryConstants.PropertyID, ID));
                SqlDataReader reader = sqlCommand.ExecuteReader();
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
        public async static Task<ResultList<Plugin_PropertyEntity>> SelectAll()
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyEntity> list = new List<Plugin_PropertyEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_PropertyEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<Plugin_PropertyEntity>> Property_Update(Plugin_PropertyEntity entity)
        {

            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyID, entity.PropertyID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyTitle, entity.PropertyTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyTypeID, entity.PropertyTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.CountryID, entity.CountryID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.GovernateID, entity.GovernateID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AreaID, entity.AreaID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyType, entity.PropertyType);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.ProviderName, entity.ProviderName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.CountryName, entity.CountryName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AreaName, entity.AreaName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.GovernateName, entity.GovernateName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyCost, entity.PropertyCost);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyAge, entity.PropertyAge);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyArea, entity.PropertyArea);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.NoOfBedrooms, entity.NoOfBedrooms);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.NoOfBathrooms, entity.NoOfBathrooms);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.EditUser, entity.EditUser);

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

        public async static Task<ResultEntity<Plugin_PropertyEntity>> Property_Insert(Plugin_PropertyEntity entity)
        {

            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyTitle, entity.PropertyTitle);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyTypeID, entity.PropertyTypeID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.CountryID, entity.CountryID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.GovernateID, entity.GovernateID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AreaID, entity.AreaID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyType, entity.PropertyType);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.ProviderName, entity.ProviderName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.CountryName, entity.CountryName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AreaName, entity.AreaName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.GovernateName, entity.GovernateName);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyCost, entity.PropertyCost);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyAge, entity.PropertyAge);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyArea, entity.PropertyArea);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.NoOfBedrooms, entity.NoOfBedrooms);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.NoOfBathrooms, entity.NoOfBathrooms);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Description, entity.Description);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Longitude, entity.Longitude);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Latitude, entity.Latitude);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.AddUser, entity.AddUser);

                sqlCommand.Parameters.Add(Plugin_PropertyRepositoryConstants.PropertyID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.PropertyID = Convert.ToInt32(sqlCommand.Parameters[Plugin_PropertyRepositoryConstants.PropertyID].Value);

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

        public async static Task<ResultEntity<Plugin_PropertyEntity>> Property_Delete(long ID)
        {
            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_PropertyRepositoryConstants.PropertyID, ID));
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

        public async static Task<ResultEntity<Plugin_PropertyEntity>> UpdateByIsDeleted(Plugin_PropertyEntity entity)
        {

            ResultEntity<Plugin_PropertyEntity> result = new ResultEntity<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.Property_UpdateByIsdeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_PropertyRepositoryConstants.PropertyID, entity.PropertyID);

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

        public static ResultList<Plugin_PropertyEntity> GetFilterPropertyAll(VMSearchEntity data)
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            //SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.GetAll_Property_SearchByFilter, sqlConnection);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.GetAll_Property_SearchFilter, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyEntity> list = new List<Plugin_PropertyEntity>();

            try
            {
                sqlConnection.Open();                

                //sqlCommand.Parameters.Add("@GovernateID", SqlDbType.Int).Value = (data.GovernateID == 0 ? DBNull.Value : (object)data.GovernateID);
                //sqlCommand.Parameters.Add("@PropertyTypeID", SqlDbType.BigInt).Value = data.PropertyTypeID == 0 ? DBNull.Value : (object)data.PropertyTypeID;
                //sqlCommand.Parameters.Add("@AreaID", SqlDbType.Int).Value = data.AreaID == 0 ? DBNull.Value : (object)data.AreaID;
                //sqlCommand.Parameters.Add("@AreaMax", SqlDbType.NVarChar).Value = data.AreaMax.Equals("0") ? DBNull.Value : (object)data.AreaMax;
                //sqlCommand.Parameters.Add("@AreaMin", SqlDbType.NVarChar).Value = data.AreaMin.Equals("0") ? DBNull.Value : (object)data.AreaMin;
                //sqlCommand.Parameters.Add("@PriceMax", SqlDbType.NVarChar).Value = data.PriceMax == 0 ? DBNull.Value : (object)data.PriceMax;
                //sqlCommand.Parameters.Add("@PriceMin", SqlDbType.NVarChar).Value = data.PriceMin == 0 ? DBNull.Value : (object)data.PriceMin;
                //sqlCommand.Parameters.Add("@ProviderIDS", SqlDbType.NVarChar).Value = data.ProviderIDS.Equals("0") ? DBNull.Value : (object)data.ProviderIDS;
                //sqlCommand.Parameters.Add("@NumofBedrooms", SqlDbType.Int).Value = data.NumofBedrooms == 0 ? DBNull.Value : (object)data.NumofBedrooms;
                //sqlCommand.Parameters.Add("@NumofBathrooms", SqlDbType.Int).Value = data.NumofBathrooms == 0 ? DBNull.Value : (object)data.NumofBathrooms;

                if(data.GovernateID>0)
                    sqlCommand.Parameters.Add("@GovernateID", SqlDbType.Int).Value = data.GovernateID;
                if (data.PropertyTypeID > 0)
                    sqlCommand.Parameters.Add("@PropertyTypeID", SqlDbType.BigInt).Value = data.PropertyTypeID;
                if (data.AreaID > 0)
                    sqlCommand.Parameters.Add("@AreaID", SqlDbType.Int).Value = data.AreaID;
                if (!data.AreaMax.Equals("0"))
                    sqlCommand.Parameters.Add("@AreaMax", SqlDbType.NVarChar).Value = data.AreaMax;
                if (!data.AreaMin.Equals("0") && !data.AreaMax.Equals("0"))
                    sqlCommand.Parameters.Add("@AreaMin", SqlDbType.NVarChar).Value = data.AreaMin;
                if (data.PriceMax > 0)
                    sqlCommand.Parameters.Add("@PriceMax", SqlDbType.NVarChar).Value = data.PriceMax;
                if (data.PriceMax > 0)
                    sqlCommand.Parameters.Add("@PriceMin", SqlDbType.NVarChar).Value = data.PriceMin;
                if (data.NumofBedrooms > 0)
                    sqlCommand.Parameters.Add("@NumofBedrooms", SqlDbType.Int).Value = data.NumofBedrooms;
                if (data.NumofBathrooms > 0)
                    sqlCommand.Parameters.Add("@NumofBathrooms", SqlDbType.Int).Value = data.NumofBathrooms;
                if (data.ProviderIDS != "")
                    sqlCommand.Parameters.Add("@ProviderIDS", SqlDbType.NVarChar).Value = data.ProviderIDS;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PropertyEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_PropertyEntity> GetPropertyIDSList(string propertyids)
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.GetAll_PropertyIDS, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyEntity> list = new List<Plugin_PropertyEntity>();

            try
            {
                sqlConnection.Open();
                
                sqlCommand.Parameters.Add("@ProviderIDS", SqlDbType.NVarChar).Value = propertyids;
                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PropertyEntity entity = EntityHelper(reader, false);
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

        public static ResultList<Plugin_PropertyEntity> GetCMSFilterPropertyAll(int GovernateID, int AreaID, int NumofBedrooms, string PropertyArea, int PropertyCost, int PropertyAge)
        {
            ResultList<Plugin_PropertyEntity> result = new ResultList<Plugin_PropertyEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_PropertyRepositoryConstants.GetAll_CMSPropertySearch, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_PropertyEntity> list = new List<Plugin_PropertyEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add("@GovernateID", SqlDbType.Int).Value = GovernateID;
                sqlCommand.Parameters.Add("@AreaID", SqlDbType.BigInt).Value = AreaID;
                sqlCommand.Parameters.Add("@NumofBedrooms", SqlDbType.Int).Value = NumofBedrooms;
                sqlCommand.Parameters.Add("@PropertyArea", SqlDbType.NVarChar).Value = PropertyArea;
                sqlCommand.Parameters.Add("@PropertyCost", SqlDbType.NVarChar).Value = PropertyCost;
                sqlCommand.Parameters.Add("@PropertyAge", SqlDbType.NVarChar).Value = PropertyAge;
                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_PropertyEntity entity = EntityHelper(reader, false);
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

        static Plugin_PropertyEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_PropertyEntity entity = new Plugin_PropertyEntity();

            entity.PropertyID = Convert.ToInt64(reader[Plugin_PropertyEntityConstants.PropertyID].ToString());
            entity.PropertyTitle = reader[Plugin_PropertyEntityConstants.PropertyTitle].ToString();
            entity.PropertyTypeID = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.PropertyTypeID].ToString());
            entity.ProviderID = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.ProviderID].ToString());
            entity.CountryID = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.CountryID].ToString());
            entity.GovernateID = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.GovernateID].ToString());
            entity.AreaID = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.AreaID].ToString());
            entity.LanguageID = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.LanguageID].ToString());
            entity.PropertyType = reader[Plugin_PropertyEntityConstants.PropertyType].ToString();
            entity.ProviderName = reader[Plugin_PropertyEntityConstants.ProviderName].ToString();
            entity.CountryName = reader[Plugin_PropertyEntityConstants.CountryName].ToString();
            entity.AreaName = reader[Plugin_PropertyEntityConstants.AreaName].ToString();
            entity.GovernateName = reader[Plugin_PropertyEntityConstants.GovernateName].ToString();
            entity.PropertyCost = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.PropertyCost].ToString());
            entity.PropertyAge = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.PropertyAge].ToString());
            entity.PropertyArea = reader[Plugin_PropertyEntityConstants.PropertyArea].ToString();
            entity.NoOfBedrooms = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.NoOfBedrooms].ToString());
            entity.NoOfBathrooms = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.NoOfBathrooms].ToString());
            entity.Description = reader[Plugin_PropertyEntityConstants.Description].ToString();
            entity.Longitude = reader[Plugin_PropertyEntityConstants.Longitude].ToString();
            entity.Latitude = reader[Plugin_PropertyEntityConstants.Latitude].ToString();
            entity.PublishDate = Convert.ToDateTime(reader[Plugin_PropertyEntityConstants.PublishDate].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[Plugin_PropertyEntityConstants.IsPublished].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_PropertyEntityConstants.IsDeleted].ToString());
            entity.Order = Convert.ToInt32(reader[Plugin_PropertyEntityConstants.Order].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_PropertyEntityConstants.AddDate].ToString());
            entity.AddUser = reader[Plugin_PropertyEntityConstants.AddUser].ToString();
            entity.EditDate = Convert.ToDateTime(reader[Plugin_PropertyEntityConstants.EditDate].ToString());
            entity.EditUser = reader[Plugin_PropertyEntityConstants.EditUser].ToString();
            //entity.PhoneNumber = reader[Plugin_PropertyEntityConstants.PhoneNumber].ToString();
            //entity.MobileNumber = reader[Plugin_PropertyEntityConstants.MobileNumber].ToString();

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
                entity.LanguageName = reader[Plugin_PropertyEntityConstants.LanguageName].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("PhoneNumber");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.PhoneNumber = reader[Plugin_PropertyEntityConstants.PhoneNumber] == DBNull.Value ? string.Empty : reader[Plugin_PropertyEntityConstants.PhoneNumber].ToString();
            }

            try
            {
                int columnOrdinal = reader.GetOrdinal("MobileNumber");
                ColumnExists = true;
            }
            catch (IndexOutOfRangeException)
            {
                ColumnExists = false;
            }

            if (ColumnExists)
            {
                entity.MobileNumber = reader[Plugin_PropertyEntityConstants.MobileNumber] == DBNull.Value ? string.Empty : reader[Plugin_PropertyEntityConstants.MobileNumber].ToString();
            }

            return entity;
        }
    }
}
