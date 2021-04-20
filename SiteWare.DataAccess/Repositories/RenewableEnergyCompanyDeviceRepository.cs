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
    public static class RenewableEnergyCompanyDeviceRepository
    {
        public async static Task<ResultEntity<RenewableEnergyCompanyDeviceEntity>> SelectByID(long RenewbleCompnyDevice)
        {

            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice, RenewbleCompnyDevice));
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
        public static ResultEntity<RenewableEnergyCompanyDeviceEntity> SelectByIDNotAsync(long RenewbleCompnyDevice)
        {

            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice, RenewbleCompnyDevice));
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
        public async static Task<ResultList<RenewableEnergyCompanyDeviceEntity>> SelectAll()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyDeviceEntity> list = new List<RenewableEnergyCompanyDeviceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanyDeviceEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyCompanyDeviceEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyDeviceEntity> list = new List<RenewableEnergyCompanyDeviceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanyDeviceEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyCompanyDeviceEntity>> Insert(RenewableEnergyCompanyDeviceEntity entity)
        {

            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice, entity.RenewbleCompnyDevice);
              
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.ModelNo, entity.ModelNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.CountryOfOrigin, entity.CountryOfOrigin);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument, entity.DeviceDocument);
               

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.LanguageID, entity.LanguageID);
               
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.Status, entity.Status);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.CompanyID, entity.CompanyID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument2, entity.DeviceDocument2);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument3, entity.DeviceDocument3);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument4, entity.DeviceDocument4);


                sqlCommand.Parameters.Add(RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.RenewbleCompnyDevice = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice].Value);

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
        public static ResultEntity<RenewableEnergyCompanyDeviceEntity> InsertNotAsync(RenewableEnergyCompanyDeviceEntity entity)
        {

            ResultEntity<RenewableEnergyCompanyDeviceEntity> result = new ResultEntity<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.ModelNo, entity.ModelNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.CountryOfOrigin, entity.CountryOfOrigin);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument, entity.DeviceDocument);


                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.LanguageID, entity.LanguageID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.EditUser, entity.EditUser);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.Status, entity.Status);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.CompanyID, entity.CompanyID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument2, entity.DeviceDocument2);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument3, entity.DeviceDocument3);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanyDeviceRepositoryConstants.DeviceDocument4, entity.DeviceDocument4);

                sqlCommand.Parameters.Add(RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.RenewbleCompnyDevice = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyCompanyDeviceRepositoryConstants.RenewbleCompnyDevice].Value);

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
        static RenewableEnergyCompanyDeviceEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyCompanyDeviceEntity entity = new RenewableEnergyCompanyDeviceEntity();

            try
            {

                //entity.RenewbleCompnyDevice = Convert.ToInt64(reader[RenewableEnergyCompanyDeviceEntityConstants.RenewbleCompnyDevice].ToString());
                entity.RenewbleCompnyDevice = reader[RenewableEnergyCompanyDeviceEntityConstants.RenewbleCompnyDevice] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyCompanyDeviceEntityConstants.RenewbleCompnyDevice].ToString());
                entity.CompanyName = reader[RenewableEnergyCompanyDeviceEntityConstants.CompanyName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.CompanyName].ToString();               
                entity.ModelNo = reader[RenewableEnergyCompanyDeviceEntityConstants.ModelNo] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.ModelNo].ToString();
                entity.DevicePower = reader[RenewableEnergyCompanyDeviceEntityConstants.DevicePower] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.DevicePower].ToString();
                entity.CountryOfOrigin = reader[RenewableEnergyCompanyDeviceEntityConstants.CountryOfOrigin] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.CountryOfOrigin].ToString();
                entity.DeviceDocument = reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument].ToString();
                entity.Order = reader[RenewableEnergyCompanyDeviceEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyCompanyDeviceEntityConstants.Order].ToString());
                entity.LanguageID = reader[RenewableEnergyCompanyDeviceEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyCompanyDeviceEntityConstants.LanguageID].ToString());                
                entity.PublishDate = reader[RenewableEnergyCompanyDeviceEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyDeviceEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[RenewableEnergyCompanyDeviceEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanyDeviceEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[RenewableEnergyCompanyDeviceEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanyDeviceEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[RenewableEnergyCompanyDeviceEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyDeviceEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyCompanyDeviceEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanyDeviceEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyCompanyDeviceEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyCompanyDeviceEntityConstants.EditUser].ToString();

               

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
                    entity.LanguageName = reader[RenewableEnergyCompanyDeviceEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.LanguageName].ToString();
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("Status");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.Status = reader[RenewableEnergyCompanyDeviceEntityConstants.Status] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.Status].ToString();
                }



                try
                {
                    int columnOrdinal = reader.GetOrdinal("IsApproved");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.IsApproved = reader[RenewableEnergyCompanyDeviceEntityConstants.IsApproved] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanyDeviceEntityConstants.IsApproved].ToString());
                   
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("CompanyID");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.CompanyID = reader[RenewableEnergyCompanyDeviceEntityConstants.CompanyID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyCompanyDeviceEntityConstants.CompanyID].ToString());
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("DeviceDocument2");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.DeviceDocument2 = reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument2] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument2].ToString();
                    
                }


                try
                {
                    int columnOrdinal = reader.GetOrdinal("DeviceDocument3");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.DeviceDocument3 = reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument3] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument3].ToString();
                }



                try
                {
                    int columnOrdinal = reader.GetOrdinal("DeviceDocument4");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.DeviceDocument4 = reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument4] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.DeviceDocument4].ToString();
                }




            }
            catch (Exception ex)
            {

            }

            return entity;
        }

        public async static Task<ResultList<RenewableEnergyCompanyDeviceEntity>> SelectAllDistinctCompanyName()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_DistinctCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyDeviceEntity> list = new List<RenewableEnergyCompanyDeviceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanyDeviceEntity entity = EntityHelper2(reader, false);
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

        public static ResultList<RenewableEnergyCompanyDeviceEntity> SelectAllDistinctCompanyNameNotAsync()
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_DistinctCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyDeviceEntity> list = new List<RenewableEnergyCompanyDeviceEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanyDeviceEntity entity = EntityHelper2(reader, false);
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

        static RenewableEnergyCompanyDeviceEntity EntityHelper2(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyCompanyDeviceEntity entity = new RenewableEnergyCompanyDeviceEntity();

            try
            {
                entity.CompanyName = reader[RenewableEnergyCompanyDeviceEntityConstants.CompanyName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanyDeviceEntityConstants.CompanyName].ToString();
               

            }
            catch (Exception ex)
            {

            }

            return entity;
        }


        public async static Task<ResultList<RenewableEnergyCompanyDeviceEntity>> SelectAllByCompanyName(string ComapnyName)
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_ByCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyDeviceEntity> list = new List<RenewableEnergyCompanyDeviceEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanyDeviceRepositoryConstants.CompanyName, ComapnyName));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanyDeviceEntity entity = EntityHelper(reader, false);
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

        public static ResultList<RenewableEnergyCompanyDeviceEntity> SelectAllByNameNotAsync(string ComapnyName)
        {
            ResultList<RenewableEnergyCompanyDeviceEntity> result = new ResultList<RenewableEnergyCompanyDeviceEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanyDeviceRepositoryConstants.SP_ByCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanyDeviceEntity> list = new List<RenewableEnergyCompanyDeviceEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanyDeviceRepositoryConstants.CompanyName, ComapnyName));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanyDeviceEntity entity = EntityHelper(reader, false);
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
    }
}
