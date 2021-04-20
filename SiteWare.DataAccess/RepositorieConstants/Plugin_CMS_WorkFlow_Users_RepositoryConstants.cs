using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public class Plugin_CMS_WorkFlow_Users_RepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.ID;
        public const string WF_ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.WF_ID;
        public const string FromUserID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.FromUserID;
        public const string ToUserID = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.ToUserID;
        public const string IsDelete = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.IsDelete;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.AddDate;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CMS_WorkFlow_Users_EntityConstants.EditDate;


        public const string SelectALL = "Plugin_CMS_WorkFlow_Users_SelectAll";
        public const string SelectByID = "Plugin_CMS_WorkFlow_Users_SelectByID";


    }
}
