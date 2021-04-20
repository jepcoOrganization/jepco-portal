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
    public static class CalendarRepository
    {
        public async static Task<ResultEntity<CalendarEntity>> SelectByID(int ID)
        {

            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CalendarRepositoryConstants.ID, ID));
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

        public static ResultList<CalendarEntity> SelectByCalendarEvents()
        {

            ResultList<CalendarEntity> result = new ResultList<CalendarEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarRepositoryConstants.SP_SelectByCalendarEvents, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CalendarEntity> list = new List<CalendarEntity>();
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    CalendarEntity entity = EntityHelper(reader, false);
                    list.Add(entity);
                }

                if (list.Count > 0)
                {
                    reader.Close();
                    result.List = list;
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

        public async static Task<ResultList<CalendarEntity>> SelectAll()
        {
            ResultList<CalendarEntity> result = new ResultList<CalendarEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CalendarEntity> list = new List<CalendarEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    CalendarEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<CalendarEntity>> Update(CalendarEntity entity)
        {

            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.CalendarName, entity.CalendarName);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EntityID, entity.EntityID);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EventDate, entity.EventDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<CalendarEntity>> UpdateByIsDeleted(CalendarEntity entity)
        {

            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<CalendarEntity>> Insert(CalendarEntity entity)
        {

            ResultEntity<CalendarEntity> result = new ResultEntity<CalendarEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.CalendarName, entity.CalendarName);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EntityID, entity.EntityID);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EventDate, entity.EventDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(CalendarRepositoryConstants.EditUser, entity.EditUser);

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
        static CalendarEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            CalendarEntity entity = new CalendarEntity();
            try
            {
                entity.ID = Convert.ToInt32(reader[CalendarEntityConstants.ID].ToString());
                entity.CalendarName = reader[CalendarEntityConstants.CalendarName].ToString();
                entity.EventDate = Convert.ToDateTime(reader[CalendarEntityConstants.EventDate].ToString());
                entity.LanguageID = Convert.ToByte(reader[CalendarEntityConstants.LanguageID].ToString());
                entity.PublishDate = Convert.ToDateTime(reader[CalendarEntityConstants.PublishDate].ToString());
                entity.IsPublished = Convert.ToBoolean(reader[CalendarEntityConstants.IsPublished].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[CalendarEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[CalendarEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[CalendarEntityConstants.EditDate].ToString());
                entity.AddUser = reader[CalendarEntityConstants.AddUser].ToString();
                entity.EditUser = reader[CalendarEntityConstants.EditUser].ToString();
                bool ColumnExists = false;
                bool coluEventTitle = false;
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
                    entity.LanguageName = reader[CalendarEntityConstants.LanguageName].ToString();
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("EntityID");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }
                if (ColumnExists)
                {
                    entity.EntityID = reader[CalendarEntityConstants.EntityID] == DBNull.Value ? 0 : Convert.ToInt64(reader[CalendarEntityConstants.EntityID].ToString());
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("EntityName");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }
                if (ColumnExists)
                {
                    entity.EntityName = reader[CalendarEntityConstants.EntityName] == DBNull.Value ? string.Empty : Convert.ToString(reader[CalendarEntityConstants.EntityName].ToString());
                }
                try
                {
                    int columnEventTitle = reader.GetOrdinal("EventTitle");
                    coluEventTitle = true;
                }
                catch (IndexOutOfRangeException)
                {
                    coluEventTitle = false;
                }

                if (coluEventTitle)
                {
                    entity.EventTitle = reader[CalendarEntityConstants.EventTitle].ToString();
                    entity.EventDescription = reader[CalendarEntityConstants.EventDescription].ToString();
                    entity.EventURL = reader[CalendarEntityConstants.EventURL].ToString();
                    entity.TargetID = Convert.ToByte(reader[CalendarEntityConstants.TargetID]);
                    entity.EventTime = Convert.ToDateTime(reader[CalendarEntityConstants.EventTime]);
                    entity.Summary = Convert.ToString(reader[CalendarEntityConstants.Summary]);
                }
            }
            catch
            {
            }
            
            return entity;
        }
    }
}
