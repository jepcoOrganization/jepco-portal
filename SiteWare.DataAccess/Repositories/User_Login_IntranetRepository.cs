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
    public static class User_Login_IntranetRepository
    {
        public static ResultList<User_Login_IntranetEntity> SelectAllNotAsync()
        {
            ResultList<User_Login_IntranetEntity> result = new ResultList<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<User_Login_IntranetEntity> list = new List<User_Login_IntranetEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    User_Login_IntranetEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<User_Login_IntranetEntity>> User_Login_ResetUpdate(User_Login_IntranetEntity entity)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants. SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_ResetPasswordUpdate, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.Password, entity.Password);
                // sqlCommand.Parameters.Add(User_Login_IntranetRepositoryConstant.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[User_Login_IntranetRepositoryConstant.ID].Value);

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

        public async static Task<ResultList<User_Login_IntranetEntity>> SelectAll()
        {
            ResultList<User_Login_IntranetEntity> result = new ResultList<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<User_Login_IntranetEntity> list = new List<User_Login_IntranetEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    User_Login_IntranetEntity entity = EntityHelper(reader, false);
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

        public async static Task<ResultEntity<User_Login_IntranetEntity>> User_Login_SelectByID(long ProviderID)
        {

            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_SelectByProviderID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.ProviderID, ProviderID));
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

        public static ResultEntity<User_Login_IntranetEntity> User_Login_SelectByIDNotAsync(long ProviderID)
        {

            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_SelectByProviderID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.ProviderID, ProviderID));
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


        public async static Task<ResultEntity<User_Login_IntranetEntity>> User_Login_CheckValid(string UserID, string Password)
        {

            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_CheckValid, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.UserID, UserID));
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.Password, Password));
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

        public static ResultEntity<User_Login_IntranetEntity> User_Login_CheckValidNotAsync(string UserID, string Password)
        {

            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_CheckValid, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.UserID, UserID));
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.Password, Password));
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

        public async static Task<ResultEntity<User_Login_IntranetEntity>> User_Login_UpdateIsMail(long ID)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_IsMailUpdate, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.ID, ID));
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

        public async static Task<ResultEntity<User_Login_IntranetEntity>> User_Login_UpdateIsFirstLogIn(long ID)
        {
            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_IsFirstLogin, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(User_Login_IntranetRepositoryConstant.ID, ID));
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

        public async static Task<ResultEntity<User_Login_IntranetEntity>> User_Login_Insert(User_Login_IntranetEntity entity)
        {

            ResultEntity<User_Login_IntranetEntity> result = new ResultEntity<User_Login_IntranetEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection_Intranet].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(User_Login_IntranetRepositoryConstant.User_Login_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.ProviderID, entity.ProviderID);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.Password, entity.Password);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.IsFirstLogin, entity.IsFirstLogin);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.IsMail, entity.IsMail);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(User_Login_IntranetRepositoryConstant.EditUser, entity.EditUser);
                sqlCommand.Parameters.Add(User_Login_IntranetRepositoryConstant.ID, SqlDbType.BigInt).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[User_Login_IntranetRepositoryConstant.ID].Value);

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


        static User_Login_IntranetEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            User_Login_IntranetEntity entity = new User_Login_IntranetEntity();

            entity.ID = Convert.ToInt32(reader[User_Login_IntranetEntityConstants.ID].ToString());
            entity.ProviderID = Convert.ToInt32(reader[User_Login_IntranetEntityConstants.ProviderID].ToString());
            entity.UserID = reader[User_Login_IntranetEntityConstants.UserID].ToString();
            entity.Password = reader[User_Login_IntranetEntityConstants.Password].ToString();
            entity.IsFirstLogin = Convert.ToBoolean(reader[User_Login_IntranetEntityConstants.IsFirstLogin].ToString());
            entity.IsMail = Convert.ToBoolean(reader[User_Login_IntranetEntityConstants.IsMail].ToString());
            entity.IsPublished = Convert.ToBoolean(reader[User_Login_IntranetEntityConstants.IsPublished].ToString());
            entity.IsDelete = Convert.ToBoolean(reader[User_Login_IntranetEntityConstants.IsDelete].ToString());
            entity.AddDate = Convert.ToDateTime(reader[User_Login_IntranetEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[User_Login_IntranetEntityConstants.EditDate].ToString());
            entity.AddUser = reader[User_Login_IntranetEntityConstants.AddUser].ToString();
            entity.EditUser = reader[User_Login_IntranetEntityConstants.EditUser].ToString();

            //bool ColumnExists = false;
            //try
            //{
            //    int columnOrdinal = reader.GetOrdinal("EmailId");
            //    ColumnExists = true;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    ColumnExists = false;
            //}

            //if (ColumnExists)
            //{
            //    entity.EmailId = reader[User_Login_IntranetEntityConstants.EmailId] == DBNull.Value ? string.Empty : reader[User_Login_IntranetEntityConstants.EmailId].ToString();
            //}
            return entity;
        }
    }
}
