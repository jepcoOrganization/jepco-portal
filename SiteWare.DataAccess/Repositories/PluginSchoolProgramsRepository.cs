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
    public static class PluginSchoolProgramsRepository
    {
        public static ResultList<PluginSchoolProgramsEntity> SelectAllNotAsync()
        {
            ResultList<PluginSchoolProgramsEntity> result = new ResultList<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSchoolProgramsEntity> list = new List<PluginSchoolProgramsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PluginSchoolProgramsEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> Plugin_SchoolProgramss_SelectByID(long ID)
        {

            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginSchoolProgramsRepositoryConstants.ID, ID));
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
        public async static Task<ResultList<PluginSchoolProgramsEntity>> SelectSchoolProgramsByCategory()
        {
            ResultList<PluginSchoolProgramsEntity> result = new ResultList<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSchoolProgramsEntity> list = new List<PluginSchoolProgramsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginSchoolProgramsEntity entity = EntityHelper(reader, false);
                    if (entity.IsDeleted == false)
                    {
                        list.Add(entity);
                    }
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
        public async static Task<ResultList<PluginSchoolProgramsEntity>> SelectAll()
        {
            ResultList<PluginSchoolProgramsEntity> result = new ResultList<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<PluginSchoolProgramsEntity> list = new List<PluginSchoolProgramsEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    PluginSchoolProgramsEntity entity = EntityHelper(reader, false);

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
        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> Plugin_SchoolProgramss_Update(PluginSchoolProgramsEntity entity)
        {

            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Brief, entity.Brief);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.ProgramOrder, entity.ProgramOrder);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.EditUser, entity.EditUser);
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
        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> Plugin_SchoolProgramss_Insert(PluginSchoolProgramsEntity entity)
        {

            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(PluginSchoolProgramsRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Title, entity.Title);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Image, entity.Image);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Icon, entity.Icon);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Brief, entity.Brief);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Link, entity.Link);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.Target, entity.Target);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.ProgramOrder, entity.ProgramOrder);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(PluginSchoolProgramsRepositoryConstants.EditUser, entity.EditUser);
                

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt32(sqlCommand.Parameters[PluginSchoolProgramsRepositoryConstants.ID].Value);

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
        public async static Task<ResultEntity<PluginSchoolProgramsEntity>> Plugin_SchoolProgramss_Delete(int ID)
        {
            ResultEntity<PluginSchoolProgramsEntity> result = new ResultEntity<PluginSchoolProgramsEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(PluginSchoolProgramsRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(PluginSchoolProgramsRepositoryConstants.ID, ID));
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
        static PluginSchoolProgramsEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            PluginSchoolProgramsEntity entity = new PluginSchoolProgramsEntity();
            try
            {
                entity.ID = Convert.ToInt32(reader[PluginSchoolProgramsEntityConstants.ID].ToString());
                entity.Icon = Convert.ToString(reader[PluginSchoolProgramsEntityConstants.Icon]);
                entity.Title = reader[PluginSchoolProgramsEntityConstants.Title].ToString();
                entity.Image = Convert.ToString(reader[PluginSchoolProgramsEntityConstants.Image]);
                entity.Brief = Convert.ToString(reader[PluginSchoolProgramsEntityConstants.Brief]);
                entity.Link = reader[PluginSchoolProgramsEntityConstants.Link].ToString();
                entity.Target = reader[PluginSchoolProgramsEntityConstants.Target].ToString();
                entity.ProgramOrder = Convert.ToInt32(reader[PluginSchoolProgramsEntityConstants.ProgramOrder].ToString());
                entity.LanguageID = Convert.ToInt32(reader[PluginSchoolProgramsEntityConstants.LanguageID].ToString());
                entity.PublishDate = Convert.ToDateTime(reader[PluginSchoolProgramsEntityConstants.PublishDate].ToString());
                entity.IsPublished = Convert.ToBoolean(reader[PluginSchoolProgramsEntityConstants.IsPublished].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[PluginSchoolProgramsEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[PluginSchoolProgramsEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[PluginSchoolProgramsEntityConstants.EditDate].ToString());
                entity.AddUser = reader[PluginSchoolProgramsEntityConstants.AddUser].ToString();
                entity.EditUser = reader[PluginSchoolProgramsEntityConstants.EditUser].ToString();
            }
            catch (Exception ex)
            {
            }            
            return entity;
        }
    }
}
