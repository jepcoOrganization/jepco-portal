using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SiteWare.Entity.Entities
{
    [DataContract]
    public class SettingEntity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string Logo { get; set; }
        [DataMember]
        public string GoogleAnalytic { get; set; }
        [DataMember]
        public string DateFormat { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PasswordEmail { get; set; }
        [DataMember]
        public string SMTPServer { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public byte? LanguageID { get; set; }
        [DataMember]
        public string PageName { get; set; }
        [DataMember]
        public string CopyRights { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public Boolean IsPublished { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }
        [DataMember]
        public string AddUser { get; set; }
        [DataMember]
        public DateTime EditDate { get; set; }
        [DataMember]
        public string EditUser { get; set; }
        [DataMember]
        public string PortNumber { get; set; }
        [DataMember]
        public string WorkingHours { get; set; }
        [DataMember]
        public string FooterLogo { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public Boolean IsEnableSSL { get; set; }
        [DataMember]
        public string FromMail { get; set; }
        [DataMember]
        public string MailContent { get; set; }
        [DataMember]
        public string UserMailContent { get; set; }
        [DataMember]
        public string RenewableDeviceUserMail { get; set; }
        [DataMember]
        public string RenewableDeviceAdminMail { get; set; }
        [DataMember]
        public string RenewableSolarCellUserMail { get; set; }
        [DataMember]
        public string RenewableSolarCellAdminMail { get; set; }
        [DataMember]
        public string RenewableRegistrationUserMail { get; set; }
        [DataMember]
        public string RenewableRegistrationAdminMail { get; set; }
        [DataMember]
        public string ForgetPasswordUser { get; set; }
        [DataMember]
        public string ForgetPasswordAdmin { get; set; }

    }
}
