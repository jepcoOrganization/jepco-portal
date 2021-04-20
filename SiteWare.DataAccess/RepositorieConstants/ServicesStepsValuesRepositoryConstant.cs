using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.RepositorieConstants
{
   public class ServicesStepsValuesRepositoryConstant
    {
        public const string ID = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.ID;
        public const string StepID = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.StepID;
        public const string ServiceID = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.ServiceID;
        public const string Value1 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.Value1;
        public const string Value2 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.Value2;
        public const string Value3 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.Value3;
        public const string Value4 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.Value4;
        public const string Notes = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.Notes;
        public const string IsDone = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.IsDone;
        public const string ReceivedDateTime = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.ReceivedDateTime;
        public const string DoneDateTime = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.DoneDateTime;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + ServicesStepsValuesEntityConstant.EditUser;

        public const string SP_Insert = "ServicesStepsValues_Insert";
        public const string SP_Update = "ServicesStepsValues_Update";
        public const string SP_SelectAll = "ServicesStepsValues_SelectAll";
        public const string SP_SelectByID = "ServicesStepsValues_SelectByID";
        
    }
}
