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
   public static class RenewableEnergyCompanySolarCellRepository
    {
        public async static Task<ResultEntity<RenewableEnergyCompanySolarCellEntity>> SelectByID(long RenewbleCompnySolarCell)
        {

            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell, RenewbleCompnySolarCell));
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
        public static ResultEntity<RenewableEnergyCompanySolarCellEntity> SelectByIDNotAsync(long RenewbleCompnySolarCell)
        {

            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell, RenewbleCompnySolarCell));
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
        public async static Task<ResultList<RenewableEnergyCompanySolarCellEntity>> SelectAll()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanySolarCellEntity> list = new List<RenewableEnergyCompanySolarCellEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanySolarCellEntity entity = EntityHelper(reader, false);
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
        public static ResultList<RenewableEnergyCompanySolarCellEntity> SelectAllNotAsync()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanySolarCellEntity> list = new List<RenewableEnergyCompanySolarCellEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanySolarCellEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<RenewableEnergyCompanySolarCellEntity>> Insert(RenewableEnergyCompanySolarCellEntity entity)
        {

            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell, entity.RenewbleCompnySolarCell);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.ModelNo, entity.ModelNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.CountryOfOrigin, entity.CountryOfOrigin);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.SolarCellDocument, entity.SolarCellDocument);


                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.LanguageID, entity.LanguageID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.Status, entity.Status);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.CompanyID, entity.CompanyID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.SolarCellDocument2, entity.SolarCellDocument2);

                

                sqlCommand.Parameters.Add(RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.RenewbleCompnySolarCell = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell].Value);

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
        public static ResultEntity<RenewableEnergyCompanySolarCellEntity> InsertNotAsync(RenewableEnergyCompanySolarCellEntity entity)
        {

            ResultEntity<RenewableEnergyCompanySolarCellEntity> result = new ResultEntity<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.CompanyName, entity.CompanyName);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.ModelNo, entity.ModelNo);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.DevicePower, entity.DevicePower);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.CountryOfOrigin, entity.CountryOfOrigin);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.SolarCellDocument, entity.SolarCellDocument);


                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.Order, entity.Order);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.LanguageID, entity.LanguageID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.Status, entity.Status);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.IsApproved, entity.IsApproved);
                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.CompanyID, entity.CompanyID);

                sqlCommand.Parameters.AddWithValue(RenewableEnergyCompanySolarCellRepositoryConstants.SolarCellDocument2, entity.SolarCellDocument2);

                sqlCommand.Parameters.Add(RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.RenewbleCompnySolarCell = Convert.ToInt64(sqlCommand.Parameters[RenewableEnergyCompanySolarCellRepositoryConstants.RenewbleCompnySolarCell].Value);

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
        static RenewableEnergyCompanySolarCellEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyCompanySolarCellEntity entity = new RenewableEnergyCompanySolarCellEntity();

            try
            {

                entity.RenewbleCompnySolarCell = Convert.ToInt64(reader[RenewableEnergyCompanySolarCellEntityConstants.RenewbleCompnySolarCell].ToString());
                entity.CompanyName = reader[RenewableEnergyCompanySolarCellEntityConstants.CompanyName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.CompanyName].ToString();
                entity.ModelNo = reader[RenewableEnergyCompanySolarCellEntityConstants.ModelNo] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.ModelNo].ToString();
                entity.DevicePower = reader[RenewableEnergyCompanySolarCellEntityConstants.DevicePower] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.DevicePower].ToString();
                entity.CountryOfOrigin = reader[RenewableEnergyCompanySolarCellEntityConstants.CountryOfOrigin] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.CountryOfOrigin].ToString();
                entity.SolarCellDocument = reader[RenewableEnergyCompanySolarCellEntityConstants.SolarCellDocument] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.SolarCellDocument].ToString();
                entity.Order = reader[RenewableEnergyCompanySolarCellEntityConstants.Order] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyCompanySolarCellEntityConstants.Order].ToString());
                entity.LanguageID = reader[RenewableEnergyCompanySolarCellEntityConstants.LanguageID] == DBNull.Value ? 0 : Convert.ToInt32(reader[RenewableEnergyCompanySolarCellEntityConstants.LanguageID].ToString());
                entity.PublishDate = reader[RenewableEnergyCompanySolarCellEntityConstants.PublishDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanySolarCellEntityConstants.PublishDate].ToString());
                entity.IsPublished = reader[RenewableEnergyCompanySolarCellEntityConstants.IsPublished] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanySolarCellEntityConstants.IsPublished].ToString());
                entity.IsDeleted = reader[RenewableEnergyCompanySolarCellEntityConstants.IsDeleted] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanySolarCellEntityConstants.IsDeleted].ToString());
                entity.AddDate = reader[RenewableEnergyCompanySolarCellEntityConstants.AddDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanySolarCellEntityConstants.AddDate].ToString());
                entity.EditDate = reader[RenewableEnergyCompanySolarCellEntityConstants.EditDate] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader[RenewableEnergyCompanySolarCellEntityConstants.EditDate].ToString());
                entity.AddUser = reader[RenewableEnergyCompanySolarCellEntityConstants.AddUser].ToString();
                entity.EditUser = reader[RenewableEnergyCompanySolarCellEntityConstants.EditUser].ToString();

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
                    entity.LanguageName = reader[RenewableEnergyCompanySolarCellEntityConstants.LanguageName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.LanguageName].ToString();
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
                    entity.Status = reader[RenewableEnergyCompanySolarCellEntityConstants.Status] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.Status].ToString();
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
                    entity.IsApproved = reader[RenewableEnergyCompanySolarCellEntityConstants.IsApproved] == DBNull.Value ? false : Convert.ToBoolean(reader[RenewableEnergyCompanySolarCellEntityConstants.IsApproved]);
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
                    entity.CompanyID = reader[RenewableEnergyCompanySolarCellEntityConstants.CompanyID] == DBNull.Value ? 0 : Convert.ToInt64(reader[RenewableEnergyCompanySolarCellEntityConstants.CompanyID]);
                }



                try
                {
                    int columnOrdinal = reader.GetOrdinal("SolarCellDocument2");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.SolarCellDocument2 = reader[RenewableEnergyCompanySolarCellEntityConstants.SolarCellDocument2] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.SolarCellDocument2].ToString();
                }




            }
            catch (Exception ex)
            {

            }

            return entity;
        }


        public async static Task<ResultList<RenewableEnergyCompanySolarCellEntity>> SelectAllDistinctCompanyName()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_DistinctCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanySolarCellEntity> list = new List<RenewableEnergyCompanySolarCellEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanySolarCellEntity entity = EntityHelper2(reader, false);
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

        public static ResultList<RenewableEnergyCompanySolarCellEntity> SelectAllDistinctCompanyNameNotAsync()
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_DistinctCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanySolarCellEntity> list = new List<RenewableEnergyCompanySolarCellEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanySolarCellEntity entity = EntityHelper2(reader, false);
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

        static RenewableEnergyCompanySolarCellEntity EntityHelper2(SqlDataReader reader, bool isFull)
        {
            RenewableEnergyCompanySolarCellEntity entity = new RenewableEnergyCompanySolarCellEntity();

            try
            {
                entity.CompanyName = reader[RenewableEnergyCompanySolarCellEntityConstants.CompanyName] == DBNull.Value ? string.Empty : reader[RenewableEnergyCompanySolarCellEntityConstants.CompanyName].ToString();


            }
            catch (Exception ex)
            {

            }

            return entity;
        }


        public async static Task<ResultList<RenewableEnergyCompanySolarCellEntity>> SelectAllByCompanyName(string ComapnyName)
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_ByCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanySolarCellEntity> list = new List<RenewableEnergyCompanySolarCellEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanySolarCellRepositoryConstants.CompanyName, ComapnyName));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    RenewableEnergyCompanySolarCellEntity entity = EntityHelper(reader, false);
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

        public static ResultList<RenewableEnergyCompanySolarCellEntity> SelectAllByNameNotAsync(string ComapnyName)
        {
            ResultList<RenewableEnergyCompanySolarCellEntity> result = new ResultList<RenewableEnergyCompanySolarCellEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(RenewableEnergyCompanySolarCellRepositoryConstants.SP_ByCompanyName, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<RenewableEnergyCompanySolarCellEntity> list = new List<RenewableEnergyCompanySolarCellEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(RenewableEnergyCompanySolarCellRepositoryConstants.CompanyName, ComapnyName));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    RenewableEnergyCompanySolarCellEntity entity = EntityHelper(reader, false);
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
