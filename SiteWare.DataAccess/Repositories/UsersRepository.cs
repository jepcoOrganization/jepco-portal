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
    public static class UsersRepository
    {

        public async static Task<ResultEntity<UserEntity>> SelectByLoginIDAndPassword(string useranme, string password)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_SelectByLoginIDAndPassword, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(UserRepositoryConstants.LoginID, useranme));
                sqlCommand.Parameters.Add(new SqlParameter(UserRepositoryConstants.Password, password));

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
        public async static Task<ResultEntity<UserEntity>> SelectByUserID(int UserID)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_SelectByUserID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(UserRepositoryConstants.UserID, UserID));
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
        public static ResultEntity<UserEntity> SelectByUserIDWithoutAsync(int UserID)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_SelectByUserID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(UserRepositoryConstants.UserID, UserID));
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

        public async static Task<ResultEntity<UserEntity>> Insert(UserEntity entity)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();

                //sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.UserID, entity.UserID);

                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.LoginID, entity.LoginID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Password, entity.Passwordd);


                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.CountryID, entity.CountryID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.LastName, entity.LastName);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.BirthDate, entity.BirthDate);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.MaritalStatusID, entity.MaritalStatusID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.GenderID, entity.GenderID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.DepartmentID, entity.DepartmentID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.SectionID, entity.SectionID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Telephone, entity.Telephone);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Ext, entity.Ext);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Mobile, entity.Mobile);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.HireDate, entity.HireDate);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Status, entity.Status);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.AddUser, entity.AddUser);

                //sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.EditDate, entity.EditDate);
                //sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.EditUser, entity.EditUser);

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



        public async static Task<ResultEntity<UserEntity>> Update(UserEntity entity)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.LoginID, entity.LoginID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.CountryID, entity.CountryID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.SecondName, entity.SecondName);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.LastName, entity.LastName);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Email, entity.Email);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.BirthDate, entity.BirthDate);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.MaritalStatusID, entity.MaritalStatusID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.GenderID, entity.GenderID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.DepartmentID, entity.DepartmentID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.SectionID, entity.SectionID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Telephone, entity.Telephone);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Ext, entity.Ext);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Mobile, entity.Mobile);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.HireDate, entity.HireDate);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Status, entity.Status);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Address, entity.Address);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.EditUser, entity.EditUser);

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
        public async static Task<ResultEntity<UserEntity>> UpdateByPassword(UserEntity entity)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_UpdateByPassword, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.UserID, entity.UserID);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Password, entity.Passwordd);

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


        public async static Task<ResultList<UserEntity>> SelectAll()
        {
            ResultList<UserEntity> result = new ResultList<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<UserEntity> list = new List<UserEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    UserEntity entity = EntityHelper(reader, false);
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

        public static ResultEntity<UserEntity> UpdateStatus(UserEntity entity)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_UpdateStatus, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.UserID, ((object)entity.UserID) ?? DBNull.Value);
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Status, ((object)entity.Status) ?? DBNull.Value);

                sqlCommand.ExecuteNonQuery();
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
        public static ResultEntity<UserEntity> Delete(UserEntity entity)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(UserRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.UserID, ((object)entity.UserID) ?? DBNull.Value);
                //sqlCommand.Parameters.AddWithValue(UserRepositoryConstants.Status, ((object)entity.Status) ?? DBNull.Value);

                sqlCommand.ExecuteNonQuery();
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


        static UserEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            UserEntity entity = new UserEntity();

            entity.UserID = Convert.ToInt32(reader[UsersEntityConstants.UserID].ToString());
            entity.LoginID = reader[UsersEntityConstants.LoginID].ToString();
            entity.Passwordd = reader[UsersEntityConstants.Password].ToString();
            entity.Image = reader[UsersEntityConstants.Image].ToString();
            entity.FirstName = reader[UsersEntityConstants.FirstName].ToString();
            entity.SecondName = reader[UsersEntityConstants.SecondName].ToString();
            entity.LastName = reader[UsersEntityConstants.LastName].ToString();
            entity.Email = reader[UsersEntityConstants.Email].ToString();
            entity.LastLoginDate = Convert.ToDateTime(reader[UsersEntityConstants.LastLoginDate].ToString());
            entity.BirthDate = Convert.ToDateTime(reader[UsersEntityConstants.BirthDate].ToString());
            entity.MaritalStatusID = Convert.ToByte(reader[UsersEntityConstants.MaritalStatusID].ToString());
            entity.GenderID = Convert.ToByte(reader[UsersEntityConstants.GenderID].ToString());
            entity.CountryID = Convert.ToByte(reader[UsersEntityConstants.CountryID].ToString());
            entity.DepartmentID = Convert.ToByte(reader[UsersEntityConstants.DepartmentID].ToString());
            entity.SectionID = Convert.ToByte(reader[UsersEntityConstants.SectionID].ToString());
            entity.Title = reader[UsersEntityConstants.Title].ToString();
            entity.Telephone = reader[UsersEntityConstants.Telephone].ToString();
            entity.Ext = reader[UsersEntityConstants.Ext].ToString();
            entity.Mobile = reader[UsersEntityConstants.Mobile].ToString();
            entity.HireDate = Convert.ToDateTime(reader[UsersEntityConstants.HireDate].ToString());
            entity.Status = Convert.ToBoolean(reader[UsersEntityConstants.Status].ToString());
            entity.IsDeleted = Convert.ToBoolean(reader[UsersEntityConstants.IsDeleted].ToString());
            entity.Address = reader[UsersEntityConstants.Address].ToString();
            entity.AddDate = Convert.ToDateTime(reader[UsersEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[UsersEntityConstants.EditDate].ToString());
            entity.AddUser = reader[UsersEntityConstants.AddUser].ToString();
            entity.EditUser = reader[UsersEntityConstants.EditUser].ToString();


            return entity;
        }


    }
}
