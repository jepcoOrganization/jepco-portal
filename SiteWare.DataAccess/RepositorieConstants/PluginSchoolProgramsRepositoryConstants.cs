using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    public static class PluginSchoolProgramsRepositoryConstants

    {

        public const string ID = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.ID;
        public const string Icon = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.Icon;
        public const string Title = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.Title;
        public const string Image = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.Image;
        public const string Brief = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.Brief;
        public const string Link = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.Link;
        public const string Target = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.Target;
        public const string ProgramOrder = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.ProgramOrder;
        public const string LanguageID = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.LanguageID;
        public const string PublishDate = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.PublishDate;
        public const string IsPublished = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.IsPublished;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.AddDate;
        public const string AddUser = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.AddUser;
        public const string EditDate = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.EditDate;
        public const string EditUser = CommonRepositoryConstants.PreSQLParameter + PluginSchoolProgramsEntityConstants.EditUser;


        public const string SP_Insert = "Plugin_SchoolPrograms_Insert";
        public const string SP_Update = "Plugin_SchoolPrograms_Update";
        public const string SP_Delete = "Plugin_SchoolPrograms_Delete";
        public const string SP_SelectAll = "Plugin_SchoolPrograms_SelectAll";
        public const string SP_SelectByID = "Plugin_SchoolPrograms_SelectByID";
        // public const string SP_SelectByLoginIDAndPassword = "User_SelectByLoginIDAndPassword";
        //public const string SP_UpdateToLoginID = "User_UpdateToLoginID";
        //public const string SP_UpdateByPassword = "User_UpdateByPassword";

    }
}
