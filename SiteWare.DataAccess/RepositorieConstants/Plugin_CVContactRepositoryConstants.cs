using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class Plugin_CVContactRepositoryConstants
    {
        public const string ContactID = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.ContactID;
        public const string JobApplicationID = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.JobApplicationID;
        public const string Provenance = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.Provenance;
        public const string AreaOne = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.AreaOne;
        public const string AreaTwo = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.AreaTwo;
        public const string Street = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.Street;
        public const string Building = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.Building;
        public const string BuildingNumber = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.BuildingNumber;
        public const string TeliphoneOne = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.TeliphoneOne;
        public const string TeliphoneTwo = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.TeliphoneTwo;
        public const string Email = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.Email;
        public const string Resume = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.Resume;




        public const string Order = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.Order;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + Plugin_CVContactEntityConstants.EditUser;


        public const string SelectAll = "Plugin_CVContactDetails_SelectAll";
        public const string SelectByID = "Plugin_CVContactDetails_SelectByID";
        public const string SelectByAdmissionID = "Plugin_CVContactDetails_SelectByJobApplicationID";
        public const string Insert = "Plugin_CVContactDetails_Insert";
        public const string Update = "Plugin_CVContactDetails_Update";
        public const string Delete = "Plugin_CVContactDetails_Delete";
    }
}
