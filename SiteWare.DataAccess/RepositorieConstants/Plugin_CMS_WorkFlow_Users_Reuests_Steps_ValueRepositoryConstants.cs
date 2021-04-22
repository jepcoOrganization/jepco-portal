using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.ID;
        public const string RequestID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.RequestID;
        public const string RequestUserStepID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.RequestUserStepID;
        public const string StepName = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepName;
        public const string StepNotes = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepNotes;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.IsDelete;
        public const string Adddate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Adddate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.EditUser;
        public const string StepStatus = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.StepStatus;
        public const string Attachment = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment;
        public const string Attachment2 = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment2;
        public const string Attachment3 = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.Attachment3;
        public const string CompletedDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_Steps_ValueEntityConstants.CompletedDate;


        public const string SP_Insert = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_Insert";
        public const string SP_Update = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_Update";
        public const string SP_Delete = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_ Delete";
        public const string SP_SelectAll = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_ SelectAll";
        public const string SP_SelectByID = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_ SelectByID";
        public const string SP_SelectAllByRequestID = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_SelectAllByRequestID";
        public const string SP_UpdateStatus = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Value_UpdateStatus";
    }
}
