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
    public static class Plugin_CarrerRepository
    {
        public static ResultList<Plugin_CarrerEntity> SelectAllNotAsync()
        {
            ResultList<Plugin_CarrerEntity> result = new ResultList<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CarrerEntity> list = new List<Plugin_CarrerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_CarrerEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<Plugin_CarrerEntity>> SelectByID(int ID)
        {

            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CarrerRepositoryConstants.Carrer_ID, ID));
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
        public async static Task<ResultList<Plugin_CarrerEntity>> SelectByCarrer(int CatID)
        {
            ResultList<Plugin_CarrerEntity> result = new ResultList<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CarrerEntity> list = new List<Plugin_CarrerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CarrerEntity entity = EntityHelper(reader, false);
                    if (entity.Carrer_ID == CatID && entity.IsDeleted == false)
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
        public async static Task<ResultList<Plugin_CarrerEntity>> SelectAll()
        {
            ResultList<Plugin_CarrerEntity> result = new ResultList<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<Plugin_CarrerEntity> list = new List<Plugin_CarrerEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Plugin_CarrerEntity entity = EntityHelper(reader, false);

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
        public async static Task<ResultEntity<Plugin_CarrerEntity>> Update(Plugin_CarrerEntity entity)
        {

            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Carrer_ID, entity.Carrer_ID);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.FatherName, entity.FatherName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.GrandFatherName, entity.GrandFatherName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.DateOfBirth, entity.DateOfBirth);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Gender, entity.Gender);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Place, entity.Place);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Nationality, entity.Nationality);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.NationalID, entity.NationalID);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.LanguageSpoken, entity.LanguageSpoken);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Region, entity.Region);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.GradeLevel, entity.GradeLevel);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.AcademicYear, entity.AcademicYear);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Country, entity.Country);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.BuildingNO, entity.BuildingNO);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.TelephoneNO, entity.TelephoneNO);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Note, entity.Note);

                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.AddDate, entity.AddDate);

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
        public async static Task<ResultEntity<Plugin_CarrerEntity>> Insert(Plugin_CarrerEntity entity)
        {

            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.FirstName, entity.FirstName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.FatherName, entity.FatherName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.GrandFatherName, entity.GrandFatherName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.FamilyName, entity.FamilyName);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.DateOfBirth, entity.DateOfBirth);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Gender, entity.Gender);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Place, entity.Place);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Nationality, entity.Nationality);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.NationalID, entity.NationalID);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.LanguageSpoken, entity.LanguageSpoken);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Region, entity.Region);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.GradeLevel, entity.GradeLevel);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.AcademicYear, entity.AcademicYear);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Country, entity.Country);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Area, entity.Area);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Street, entity.Street);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.BuildingNO, entity.BuildingNO);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.TelephoneNO, entity.TelephoneNO);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.Note, entity.Note);

                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(Plugin_CarrerRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.Add(Plugin_CarrerRepositoryConstants.Carrer_ID, SqlDbType.Int).Direction = ParameterDirection.Output;

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.Carrer_ID = Convert.ToInt32(sqlCommand.Parameters[Plugin_CarrerRepositoryConstants.Carrer_ID].Value);

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
        public async static Task<ResultEntity<Plugin_CarrerEntity>> Delete(int ID)
        {
            ResultEntity<Plugin_CarrerEntity> result = new ResultEntity<Plugin_CarrerEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CarrerRepositoryConstants.SP_Delete, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(Plugin_CarrerRepositoryConstants.Carrer_ID, ID));
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
        static Plugin_CarrerEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            Plugin_CarrerEntity entity = new Plugin_CarrerEntity();

            entity.Carrer_ID = Convert.ToInt32(reader[Plugin_CarrerEntityConstants.Carrer_ID].ToString());
            entity.FirstName = reader[Plugin_CarrerEntityConstants.FirstName].ToString();
            entity.FatherName = reader[Plugin_CarrerEntityConstants.FatherName].ToString();
            entity.GrandFatherName = reader[Plugin_CarrerEntityConstants.GrandFatherName].ToString();
            entity.FamilyName = reader[Plugin_CarrerEntityConstants.FamilyName].ToString();
            entity.DateOfBirth = Convert.ToDateTime(reader[Plugin_CarrerEntityConstants.DateOfBirth].ToString());
            entity.Gender = Convert.ToInt32(reader[Plugin_CarrerEntityConstants.Gender].ToString());
            entity.Place = reader[Plugin_CarrerEntityConstants.Place].ToString();
            entity.Nationality = Convert.ToInt32(reader[Plugin_CarrerEntityConstants.Nationality].ToString());
            entity.NationalID = reader[Plugin_CarrerEntityConstants.NationalID].ToString();
            entity.LanguageSpoken = reader[Plugin_CarrerEntityConstants.LanguageSpoken].ToString();
            entity.Region = reader[Plugin_CarrerEntityConstants.Region].ToString();
            entity.GradeLevel = reader[Plugin_CarrerEntityConstants.GradeLevel].ToString();
            entity.AcademicYear = reader[Plugin_CarrerEntityConstants.AcademicYear].ToString();
            entity.Country = reader[Plugin_CarrerEntityConstants.Country].ToString();
            entity.Area = reader[Plugin_CarrerEntityConstants.Area].ToString();
            entity.Street = reader[Plugin_CarrerEntityConstants.Street].ToString();
            entity.BuildingNO = reader[Plugin_CarrerEntityConstants.BuildingNO].ToString();
            entity.TelephoneNO = reader[Plugin_CarrerEntityConstants.TelephoneNO].ToString();
            entity.Note = reader[Plugin_CarrerEntityConstants.Note].ToString();

            entity.IsDeleted = Convert.ToBoolean(reader[Plugin_CarrerEntityConstants.IsDeleted].ToString());
            entity.AddDate = Convert.ToDateTime(reader[Plugin_CarrerEntityConstants.AddDate].ToString()); ;


            return entity;
        }
    }
}
