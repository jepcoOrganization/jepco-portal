using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class Plugin_CMS_WorkFlow_Users_Reuests_StepsRepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.ID;
        public const string WF_ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.WF_ID;
        public const string StepName = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.StepName;
        public const string CloseStep = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.CloseStep;
        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.Order;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.IsDelete;
        public const string Adddate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.Adddate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_Reuests_StepsEntityConstants.EditUser;

        


        public const string SP_Insert = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Insert";
        public const string SP_Update = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Update";
        public const string SP_Delete = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_Delete";
        public const string SP_SelectAll = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_SelectAll";
        public const string SP_SelectByID = "Plugin_CMS_WorkFlow_Users_Reuests_Steps_SelectByID";
    }
}
