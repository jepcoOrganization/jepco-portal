using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class ServicesStepsRepositoryConstants
    {
        public const string StepID = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.StepID;
        public const string ServiceID = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.ServiceID;
        public const string StepNumber = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.StepNumber;
        public const string FromUser = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.FromUser;
        public const string ToUser = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.ToUser;
        public const string StepName = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.StepName;
        public const string SendSMS = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.SendSMS;
        public const string SMSContent = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.SMSContent;
        public const string SendMail = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.SendMail;
        public const string MailContent = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.MailContent;
        public const string Filed1 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.Filed1;
        public const string Filed2 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.Filed2;
        public const string Filed3 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.Filed3;
        public const string Filed4 = CommonRepositoryConstants.PreSQLParameter + ServicesStepsEntityConstants.Filed4;

        public const string SP_Insert = "ServicesSteps_Insert";
        public const string SP_SelectByID = "ServicesSteps_SelectByID";
        public const string SP_SelectAll = "ServicesSteps_SelectAll";

        public const string SP_SelectByServiceID = "ServicesSteps_SelectByServiceID";
    }
}
