using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class Plugin_CMS_WorkFlow_RepositoryConstants
    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.ID;
        public const string WF_ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.WF_ID;
        public const string RequestID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.RequestID;
        public const string From_User = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.From_User;
        public const string To_User = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.To_User;
        public const string Send_Date = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.Send_Date;
        public const string ProcessName = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.ProcessName;
        public const string ShowToUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.ShowToUser;
        public const string Notes = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.Notes;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.AddDate;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.EditDate;
        public const string ReqBackFlag = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.ReqBackFlag;
        public const string InsertMultiFlag = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.InsertMultiFlag;
        public const string Attachment = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.Attachment;
        public const string Attachment2 = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.Attachment2;
        public const string Attachment3 = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_EntityConstants.Attachment3;



        public const string SP_Insert = "Plugin_CMS_WorkFlow_Insert";
        public const string SP_Update = "Plugin_CMS_WorkFlow_Update";
        public const string SP_Delete = "Plugin_CMS_WorkFlow_Delete";
        public const string SP_SelectAll = "Plugin_CMS_WorkFlow_SelectAll";
        public const string SP_SelectByID = "Plugin_CMS_WorkFlow_SelectByID";
        public const string SP_SelectAllRequestID = "Plugin_CMS_WorkFlow_SelectAllRequestID";

    }
}
