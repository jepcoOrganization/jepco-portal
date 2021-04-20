using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class CMS_WorkFlow_SettingsRepositoryConstants
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + CMS_WorkFlow_SettingsEntityConstants.ID;
        public const string SettingID = CommonRepositoryConstants.PreSQLParameter + CMS_WorkFlow_SettingsEntityConstants.SettingID;
        public const string WF_ID = CommonRepositoryConstants.PreSQLParameter + CMS_WorkFlow_SettingsEntityConstants.WF_ID;
        public const string UserID = CommonRepositoryConstants.PreSQLParameter + CMS_WorkFlow_SettingsEntityConstants.UserID;
        public const string Value = CommonRepositoryConstants.PreSQLParameter + CMS_WorkFlow_SettingsEntityConstants.Value;


        public const string SP_SelectAll = "Plugin_CMS_WorkFlow_Settings_SelectAll";
    }
}
