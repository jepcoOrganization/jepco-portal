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
    public static class BannerTypeRepository
    {
        public static ResultList<BannerTypeEntity> SelectAllNotAsync()
        {
            ResultList<BannerTypeEntity> result = new ResultList<BannerTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(BannerTypeRepositoryConstants.BannerType_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<BannerTypeEntity> list = new List<BannerTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    BannerTypeEntity entity = EntityHelper(reader, false);
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


        public async static Task<ResultEntity<BannerTypeEntity>> BannerType_SelectByID(int ID)
        {

            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(BannerTypeRepositoryConstants.BannerType_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(BannerTypeRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<BannerTypeEntity>> SelectAll()
        {
            ResultList<BannerTypeEntity> result = new ResultList<BannerTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(BannerTypeRepositoryConstants.BannerType_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<BannerTypeEntity> list = new List<BannerTypeEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    BannerTypeEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<BannerTypeEntity>> BannerType_Update(BannerTypeEntity entity)
        {

            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(BannerTypeRepositoryConstants.BannerType_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.BannerName, entity.BannerName); 
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.IsDeleted, entity.IsDeleted); 
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<BannerTypeEntity>> BannerType_Insert(BannerTypeEntity entity)
        {

            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(BannerTypeRepositoryConstants.BannerType_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.BannerName, entity.BannerName); 
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.IsDeleted, entity.IsDeleted); 
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(BannerTypeRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(BannerTypeRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[BannerTypeRepositoryConstants.ID].Value);

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


        public async static Task<ResultEntity<BannerTypeEntity>> BannerType_Delete(int ID)
        {
            ResultEntity<BannerTypeEntity> result = new ResultEntity<BannerTypeEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(BannerTypeRepositoryConstants.BannerType_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(BannerTypeRepositoryConstants.ID, ID));
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
        static BannerTypeEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            BannerTypeEntity entity = new BannerTypeEntity();

            entity.ID = Convert.ToInt32(reader[BannerTypeEntityConstants.ID].ToString());
            entity.BannerName = reader[BannerTypeEntityConstants.BannerName].ToString();  
            entity.IsDeleted = Convert.ToBoolean(reader[BannerTypeEntityConstants.IsDeleted].ToString()); 
            entity.AddDate = Convert.ToDateTime(reader[BannerTypeEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[BannerTypeEntityConstants.EditDate].ToString());
            entity.AddUser = reader[BannerTypeEntityConstants.AddUser].ToString();
            entity.EditUser = reader[BannerTypeEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
