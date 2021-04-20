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
    public static class CalendarEventRepository
    {
        public static ResultList<CalendarEventEntity> SelectAllNotAsync()
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CalendarEventEntity> list = new List<CalendarEventEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    CalendarEventEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<CalendarEventEntity>> SelectByID(int ID)
        {

            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_SelectByID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CalendarEventRepositoryConstants.ID, ID));
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
        public async static Task<ResultEntity<CalendarEventEntity>> SelectByID(int ID, byte LanguageID)
        {

            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_SelectByID_With_Language, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CalendarEventRepositoryConstants.ID, ID));
                sqlCommand.Parameters.Add(new SqlParameter(CalendarEventRepositoryConstants.LanguageID, LanguageID));
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
        public async static Task<ResultList<CalendarEventEntity>> SelectByCalendarID(int CalendarID)
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_SelectByCalendarID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CalendarEventEntity> list = new List<CalendarEventEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CalendarEventRepositoryConstants.CalendarID, CalendarID));
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    CalendarEventEntity entity = EntityHelper(reader, false);
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
        public  static ResultList<CalendarEventEntity> SelectByCalendarIDNotAsync(int CalendarID)
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_SelectByCalendarID, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CalendarEventEntity> list = new List<CalendarEventEntity>();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CalendarEventRepositoryConstants.CalendarID, CalendarID));
                SqlDataReader reader =  sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    CalendarEventEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultList<CalendarEventEntity>> SelectAll()
        {
            ResultList<CalendarEventEntity> result = new ResultList<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_SelectAll, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            List<CalendarEventEntity> list = new List<CalendarEventEntity>();

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    CalendarEventEntity entity = EntityHelper(reader, false);
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
        public async static Task<ResultEntity<CalendarEventEntity>> Update(CalendarEventEntity entity)
        {

            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_Update, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.CalendarID, entity.CalendarID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventTitle, entity.EventTitle);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventDescription, entity.EventDescription);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventURL, entity.EventURL);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventTime, entity.EventTime);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.ID, entity.ID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.MapEventID1, entity.MapEventID1);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.MapEventID2, entity.MapEventID2);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsNotification, entity.IsNotification);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EntityID, entity.EntityID);

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
        public async static Task<ResultEntity<CalendarEventEntity>> UpdateByIsDeleted(CalendarEventEntity entity)
        {

            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_UpdateIsDeleted, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.ID, entity.ID);

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
        public async static Task<ResultEntity<CalendarEventEntity>> Insert(CalendarEventEntity entity)
        {

            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.CalendarID, entity.CalendarID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventTitle, entity.EventTitle);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventDescription, entity.EventDescription);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventURL, entity.EventURL);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.TargetID, entity.TargetID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EventTime, entity.EventTime);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.LanguageID, entity.LanguageID);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.PublishDate, entity.PublishDate);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsPublished, entity.IsPublished);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsDeleted, entity.IsDeleted);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.AddDate, entity.AddDate);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.MapEventID1, entity.MapEventID1);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.MapEventID2, entity.MapEventID2);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.Summary, entity.Summary);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.IsNotification, entity.IsNotification);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.EntityID, entity.EntityID);

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
        static CalendarEventEntity EntityHelper(SqlDataReader reader, bool isFull)
        {
            CalendarEventEntity entity = new CalendarEventEntity();

            try
            {
                entity.ID = Convert.ToInt32(reader[CalendarEventEntityConstants.ID].ToString());
                entity.CalendarID = Convert.ToInt32(reader[CalendarEventEntityConstants.CalendarID].ToString());
                entity.EventTitle = reader[CalendarEventEntityConstants.EventTitle].ToString();
                entity.EventDescription = reader[CalendarEventEntityConstants.EventDescription].ToString();
                entity.EventURL = reader[CalendarEventEntityConstants.EventURL].ToString();
                entity.TargetID = Convert.ToByte(reader[CalendarEventEntityConstants.TargetID].ToString());
                entity.ViewCount = Convert.ToInt64(reader[CalendarEventEntityConstants.ViewCount].ToString());
                entity.EventTime = Convert.ToDateTime(reader[CalendarEventEntityConstants.EventTime].ToString());
                entity.LanguageID = Convert.ToByte(reader[CalendarEventEntityConstants.LanguageID].ToString());
                entity.PublishDate = Convert.ToDateTime(reader[CalendarEventEntityConstants.PublishDate].ToString());
                entity.IsPublished = Convert.ToBoolean(reader[CalendarEventEntityConstants.IsPublished].ToString());
                entity.IsDeleted = Convert.ToBoolean(reader[CalendarEventEntityConstants.IsDeleted].ToString());
                entity.AddDate = Convert.ToDateTime(reader[CalendarEventEntityConstants.AddDate].ToString());
                entity.EditDate = Convert.ToDateTime(reader[CalendarEventEntityConstants.EditDate].ToString());
                entity.AddUser = reader[CalendarEventEntityConstants.AddUser].ToString();
                entity.EditUser = reader[CalendarEventEntityConstants.EditUser].ToString();
                entity.MapEventID1 = reader[CalendarEventEntityConstants.MapEventID1].ToString();
                entity.MapEventID2 = reader[CalendarEventEntityConstants.MapEventID2].ToString();
                entity.Summary = reader[CalendarEventEntityConstants.Summary].ToString();

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
                    entity.LanguageName = reader[CalendarEventEntityConstants.LanguageName].ToString();
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("IsNotification");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                if (ColumnExists)
                {
                    entity.IsNotification = reader[CalendarEventEntityConstants.IsNotification] == DBNull.Value ? false : Convert.ToBoolean(reader[CalendarEventEntityConstants.IsNotification].ToString());
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
                    entity.EntityName = reader[CalendarEventEntityConstants.EntityName] == DBNull.Value ? string.Empty : reader[CalendarEventEntityConstants.EntityName].ToString();
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
                    entity.EntityID = reader[CalendarEventEntityConstants.EntityID] == DBNull.Value ? 0 : Convert.ToInt32(reader[CalendarEventEntityConstants.EntityID].ToString());
                }

                try
                {
                    int columnOrdinal = reader.GetOrdinal("Color");
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }
                if (ColumnExists)
                {
                    entity.Color = reader[CalendarEventEntityConstants.Color] == DBNull.Value ? "#000" : reader[CalendarEventEntityConstants.Color].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            return entity;
        }

        public static ResultList<Plugin_EventYearMonthEntity> SelectMonthYearByLanguage(byte Lang)
        {
            ResultList<Plugin_EventYearMonthEntity> result = new ResultList<Plugin_EventYearMonthEntity>();
            List<Plugin_EventYearMonthEntity> list = new List<Plugin_EventYearMonthEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_GetMonthYearList, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.Add(new SqlParameter(CalendarEventRepositoryConstants.LanguageID, Lang));
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Plugin_EventYearMonthEntity entity = EntityHelper1(reader, false);
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
        public async static Task<ResultEntity<CalendarEventEntity>> UpdateViewCount(CalendarEventEntity entity)
        {

            ResultEntity<CalendarEventEntity> result = new ResultEntity<CalendarEventEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(CalendarEventRepositoryConstants.SP_UpdateViewCount, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.ViewCount, entity.ViewCount);
                sqlCommand.Parameters.AddWithValue(CalendarEventRepositoryConstants.ID, entity.ID);

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

        private static Plugin_EventYearMonthEntity EntityHelper1(SqlDataReader reader, bool v)
        {
            Plugin_EventYearMonthEntity entity = new Plugin_EventYearMonthEntity();

            entity.Months = Convert.ToInt64(reader[Plugin_EventYearMonthEntityConstants.Months].ToString());
            entity.Years = Convert.ToInt64(reader[Plugin_EventYearMonthEntityConstants.Years].ToString());

            return entity;
        }
    }
}
