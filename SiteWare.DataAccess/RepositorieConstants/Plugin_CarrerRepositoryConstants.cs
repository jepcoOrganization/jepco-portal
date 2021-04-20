using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteWare.DataAccess.Common.Constants;
using SiteWare.Entity.Constants.Entity;

namespace SiteWare.DataAccess.RepositorieConstants
{
    class Plugin_CarrerRepositoryConstants
    {
        public const string Carrer_ID = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Carrer_ID;
        public const string FirstName = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.FirstName;
        public const string FatherName = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.FatherName;
        public const string GrandFatherName = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.GrandFatherName;
        public const string FamilyName = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.FamilyName;
        public const string DateOfBirth = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.DateOfBirth;
        public const string Gender = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Gender;
        public const string Place = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Place;
        public const string Nationality = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Nationality;
        public const string NationalID = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.NationalID;
        public const string LanguageSpoken = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.LanguageSpoken;
        public const string Region = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Region;
        public const string GradeLevel = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.GradeLevel;
        public const string AcademicYear = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.AcademicYear;
        public const string Country = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Country;
        public const string Area = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Area;
        public const string Street = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Street;
        public const string BuildingNO = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.BuildingNO;
        public const string TelephoneNO = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.TelephoneNO;
        public const string Note = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.Note;
        public const string IsDeleted = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.IsDeleted;
        public const string AddDate = CommonRepositoryConstants.PreSQLParameter + Plugin_CarrerEntityConstants.AddDate;

        public const string SP_Insert = "Plugin_Carrer_Insert";
        public const string SP_Update = "Plugin_Carrer_Update";
        public const string SP_Delete = "Plugin_Carrer_Delete";
        public const string SP_SelectAll = "Plugin_Carrer_SelectByAll";
        public const string SP_SelectByID = "Plugin_Carrer_SelectByID";
    }
}
