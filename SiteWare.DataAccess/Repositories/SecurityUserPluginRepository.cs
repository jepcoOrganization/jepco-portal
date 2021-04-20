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
    public static class SecurityUserPluginRepository
    {


        //public async static Task<ResultEntity<UserEntity>> Update(UserEntity entity)
        //{

        //    ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_Update, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.UserID, entity.UserID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.LoginID, entity.LoginID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.CountryID, entity.CountryID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Image, entity.Image);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.FirstName, entity.FirstName);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.SecondName, entity.SecondName);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.LastName, entity.LastName);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Email, entity.Email);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.BirthDate, entity.BirthDate);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.MaritalStatusID, entity.MaritalStatusID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.GenderID, entity.GenderID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.DepartmentID, entity.DepartmentID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.SectionID, entity.SectionID);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Title, entity.Title);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Telephone, entity.Telephone);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Ext, entity.Ext);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Mobile, entity.Mobile);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.HireDate, entity.HireDate);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Status, entity.Status);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.IsDeleted, entity.IsDeleted);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Address, entity.Address);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.EditDate, entity.EditDate);
        //        sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.EditUser, entity.EditUser);

        //        await sqlCommand.ExecuteNonQueryAsync();
        //        result.Entity = entity;

        //        result.Status = ErrorEnums.Success;
        //        result.Message = MessageConstants.UpdateSuccessMessage;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Status = ErrorEnums.Exception;
        //        result.Details = ex.Message + Environment.NewLine + ex.StackTrace;
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        sqlConnection.Dispose();
        //        sqlCommand.Dispose();
        //    }

        //    return result;
        //}

        public async static Task<ResultEntity<SecurityUserPluginEntity>> Security_UserPlugin_Insert(SecurityUserPluginEntity entity)
        {

            ResultEntity<SecurityUserPluginEntity> result = new ResultEntity<SecurityUserPluginEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecurityUserPluginRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(SecurityUserPluginRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(SecurityUserPluginRepositoryConstants.PluginID, entity.PluginID);
                sqlCommand.Parameters.AddWithValue(SecurityUserPluginRepositoryConstants.AddUser, entity.AddUser);
      
                //sqlCommand.Parameters.Add(SecurityUserPluginRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                //entity.ID = Convert.ToInt32(sqlCommand.Parameters[SecurityUserPluginRepositoryConstants.ID].Value);

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

        public async static Task<ResultEntity<SecurityUserPluginEntity>> Security_UserPlugin_Delete(int UserID, int PluginID)
        {
            ResultEntity<SecurityUserPluginEntity> result = new ResultEntity<SecurityUserPluginEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecurityUserPluginRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SecurityUserPluginRepositoryConstants.UserID, UserID));
                sqlCommand.Parameters.Add(new SqlParameter(SecurityUserPluginRepositoryConstants.PluginID, UserID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.CannotUpdateDetails;
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
        public async static Task<ResultEntity<SecurityUserPluginEntity>> Security_UserPlugin_DeleteAll(int UserID)
        {
            ResultEntity<SecurityUserPluginEntity> result = new ResultEntity<SecurityUserPluginEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(SecurityUserPluginRepositoryConstants.SP_DeleteAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(SecurityUserPluginRepositoryConstants.UserID, UserID));
                //sqlCommand.Parameters.Add(new SqlParameter(SecurityUserPluginRepositoryConstants.PluginID, UserID));
                await sqlCommand.ExecuteReaderAsync();

                result.Status = ErrorEnums.Success;
                result.Message = MessageConstants.CannotUpdateDetails;
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

        static SecurityUserPluginEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            SecurityUserPluginEntity entity = new SecurityUserPluginEntity();

            entity.UserID = Convert.ToInt32(reader[SecurityUserPluginEntityConstants.UserID].ToString());
            entity.PluginID = Convert.ToInt32(reader[SecurityUserPluginEntityConstants.PluginID].ToString());

            entity.AddDate = Convert.ToDateTime(reader[SecurityUserPluginEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[SecurityUserPluginEntityConstants.EditDate].ToString());
            entity.AddUser = reader[SecurityUserPluginEntityConstants.AddUser].ToString();
            entity.EditUser = reader[SecurityUserPluginEntityConstants.EditUser].ToString();


            return entity;
        }
    }
}
