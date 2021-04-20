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
    public static class Plugin_News_LetterRepository
    {
        //public async static Task<ResultEntity<Plugin_News_LetterEntity>> SelectByPlugin_News_LetterID(int Plugin_News_LetterID)
        //{

        //    ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_SelectByPlugin_News_LetterID, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.Add(new SqlParameter(Plugin_News_LetterRepositoryConstants.Plugin_News_LetterID, Plugin_News_LetterID));
        //        SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            result.Entity = EntityHelper(reader, true);
        //        }
        //        else
        //        {
        //            result.Status = ErrorEnums.Warning;
        //            result.Message = MessageConstants.NotFoundMessage;
        //            result.Details = MessageConstants.NotFoundDetails;
        //        }
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
        public async static Task<ResultList<Plugin_News_LetterEntity>> SelectAll()
        {
            ResultList<Plugin_News_LetterEntity> result = new ResultList<Plugin_News_LetterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_News_LetterEntity> list = new List<Plugin_News_LetterEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_News_LetterEntity entity = EntityHelper(reader, false);
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
        public static ResultList<Plugin_News_LetterEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_News_LetterEntity> result = new ResultList<Plugin_News_LetterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_News_LetterEntity> list = new List<Plugin_News_LetterEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_News_LetterEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_News_LetterEntity>> Update(Plugin_News_LetterEntity entity)
        {

            ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.EmailNewsLetter, entity.EmailNewsLetter);
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.SubscribeNewsLetter, entity.SubscribeNewsLetter);
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.IdNewsLetter, entity.IdNewsLetter);

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
        //public async static Task<ResultEntity<Plugin_News_LetterEntity>> UpdateByIsDeleted(Plugin_News_LetterEntity entity)
        //{

        //    ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.IsDeleted, entity.IsDeleted);
        //        sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.Plugin_News_LetterID, entity.Plugin_News_LetterID);

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
        public async static Task<ResultEntity<Plugin_News_LetterEntity>> InsertPlugin_News_Letter(Plugin_News_LetterEntity entity)
        {

            ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.EmailNewsLetter, entity.EmailNewsLetter);
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.SubscribeNewsLetter, entity.SubscribeNewsLetter);

                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.AddUser, entity.AddUser);


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
        //public async static Task<ResultEntity<Plugin_News_LetterEntity>> DeletePlugin_News_Letter(Plugin_News_LetterEntity entity)
        //{

        //    ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
        //    SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_Delete, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.Plugin_News_LetterID, entity.Plugin_News_LetterID);

        //        await sqlCommand.ExecuteReaderAsync();
        //        result.Entity = entity;


        //        result.Status = ErrorEnums.Success;
        //        result.Message = MessageConstants.DeleteSuccessMessage;
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
        static Plugin_News_LetterEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_News_LetterEntity entity = new Plugin_News_LetterEntity();

            entity.IdNewsLetter = Convert.ToInt32(reader[Plugin_News_LetterEntityConstants.IdNewsLetter].ToString());
            entity.EmailNewsLetter = reader[Plugin_News_LetterEntityConstants.EmailNewsLetter].ToString();
            entity.SubscribeNewsLetter = Convert.ToBoolean(reader[Plugin_News_LetterEntityConstants.SubscribeNewsLetter].ToString());

            entity.AddDate = Convert.ToDateTime(reader[Plugin_News_LetterEntityConstants.AddDate].ToString());
            entity.EditDate = Convert.ToDateTime(reader[Plugin_News_LetterEntityConstants.EditDate].ToString());
            entity.AddUser = reader[Plugin_News_LetterEntityConstants.AddUser].ToString();
            entity.EditUser = reader[Plugin_News_LetterEntityConstants.EditUser].ToString();


            return entity;
        }

        public static ResultEntity<Plugin_News_LetterEntity> InsertPlugin_News_LetterNonasync(Plugin_News_LetterEntity entity)
        {

            ResultEntity<Plugin_News_LetterEntity> result = new ResultEntity<Plugin_News_LetterEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_News_LetterRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.EmailNewsLetter, entity.EmailNewsLetter);
                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.SubscribeNewsLetter, entity.SubscribeNewsLetter);

                sqlCommand.Parameters.AddWithValue(Plugin_News_LetterRepositoryConstants.AddUser, entity.AddUser);


                SqlDataReader reader = sqlCommand.ExecuteReader();
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
    }
}
