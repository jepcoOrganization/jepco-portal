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
   public static class Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepository
    {        
        public async static Task<ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity>> Insert(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.RequestUserStepID, entity.RequestUserStepID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.RequestStepValuesID, entity.RequestStepValuesID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.StepNotes, entity.StepNotes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Adddate, entity.Adddate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Attachment, entity.Attachment);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.CompletedDate, entity.CompletedDate);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.ID].Value);

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
        public static ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity> InsertNotAsync(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity entity)
        {

            ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity> result = new ResultEntity<Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryEntity>();

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[CommonRepositoryConstants.SQLDBConnection].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.SP_Insert, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.RequestID, entity.RequestID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.RequestUserStepID, entity.RequestUserStepID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.RequestStepValuesID, entity.RequestStepValuesID);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.StepName, entity.StepName);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.StepNotes, entity.StepNotes);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.IsDelete, entity.IsDelete);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.AddUser, entity.AddUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Adddate, entity.Adddate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.EditUser, entity.EditUser);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.EditDate, entity.EditDate);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.StepStatus, entity.StepStatus);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Attachment, entity.Attachment);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Attachment2, entity.Attachment2);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.Attachment3, entity.Attachment3);
                sqlCommand.Parameters.AddWithValue(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.CompletedDate, entity.CompletedDate);
                sqlCommand.Parameters.Add(Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.ID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                result.Entity = entity;
                entity.ID = Convert.ToInt64(sqlCommand.Parameters[Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_HistoryRepositoryConstants.ID].Value);

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
