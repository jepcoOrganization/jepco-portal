using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Common
{
    public static class CommonFunctions
    {
        #region --> Encryption 
        public static string Encrypt(string StringToEncode)
        {
            try
            {
                StringToEncode = StringToEncode.ToUpper();
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(StringToEncode);
                string str = Convert.ToBase64String(data);
                str = str + "@";
                return str;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
        #region --> Decryption
        public static string Decrypt(string stringToDecode)
        {
            string str = string.Empty;
            try
            {
                stringToDecode = stringToDecode.Replace("@", "");
                byte[] data = Convert.FromBase64String(stringToDecode);
                str = System.Text.ASCIIEncoding.ASCII.GetString(data);
                return str;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        #region--> Generate UserID
        public static string GenerateUserID(DateTime MemberShipDate)
        {
            string userID = string.Empty;
            try
            {
                string Year = Convert.ToString(MemberShipDate.Year);
                string FirstDigit = Year.Substring(0, 1);
                string LastDigit = Year.Substring(Year.Length - 2);

                ResultList<User_Login_IntranetEntity> result = new ResultList<User_Login_IntranetEntity>();
                result = User_Login_IntranetDomain.GetuserLoginAllNotAsync();
                if (result.Status == ErrorEnums.Success || result.Status == ErrorEnums.Information)
                {
                    var resultEntity = result.List.OrderByDescending(s => s.ID).FirstOrDefault();
                    if (resultEntity != null)
                    {
                        string Number = resultEntity.UserID.Substring(resultEntity.UserID.Length - 4);
                        int IncNo =  Convert.ToInt32(Number) + 1;
                        if (IncNo.ToString().Length == 1)
                        {
                            Number = "000" + IncNo.ToString();
                        }
                        else if (IncNo.ToString().Length == 2)
                        {
                            Number = "00" + IncNo.ToString();
                        }
                        else if(IncNo.ToString().Length==3)
                        {
                            Number = "0" + IncNo.ToString();
                        }
                        else
                        {
                            Number = IncNo.ToString();
                        }

                        userID = FirstDigit + LastDigit + Convert.ToString(Number);
                    }
                    else
                    {
                        userID = FirstDigit + LastDigit + "0001";
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return userID;
        }
        #endregion
        #region--> Generate Random Password
        public static string GeneratePassword()
        {
            string Password = string.Empty;
            try
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                return new string(Enumerable.Repeat(chars, 6)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
            //return Password;
        }
        #endregion
        #region--> Send Mail
        public async static Task<bool> SendCredMail(ProviderMailEntity entity)
        {
            try
            {
                string FROM = entity.fromMail;
                string FROMNAME = entity.fromMail;

                // Replace recipient@example.com with a "To" address. If your account 
                // is still in the sandbox, this address must be verified.
                string TO = entity.toMail;

                // Replace smtp_username with your Amazon SES SMTP user name.
                string SMTP_USERNAME = entity.userName;

                // Replace smtp_password with your Amazon SES SMTP user name.
                string SMTP_PASSWORD = entity.password;

                // (Optional) the name of a configuration set to use for this message.
                // If you comment out this line, you also need to remove or comment out
                // the "X-SES-CONFIGURATION-SET" header below.
                // const String CONFIGSET = "ConfigSet";

                // If you're using Amazon SES in a region other than US West (Oregon), 
                // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
                // endpoint in the appropriate Region.
                string HOST = entity.smtpServer;

                // The port you will connect to on the Amazon SES SMTP endpoint. We
                // are choosing port 587 because we will use STARTTLS to encrypt
                // the connection.
                int PORT = Convert.ToInt32(entity.port);

                // The subject line of the email
                string SUBJECT = entity.subject;

                // The body of the email
                string BODY = entity.body;

                // Create and build a new MailMessage object
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                message.Subject = SUBJECT;
                message.Body = BODY;
                // Comment or delete the next line if you are not using a configuration set
                //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                // Create and configure a new SmtpClient
                SmtpClient client =
                    new SmtpClient(HOST, PORT);
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
                // Enable SSL encryption
                client.EnableSsl = false;

                // Send the email. 
                try
                {
                    client.Send(message);
                }
                catch(Exception e)
                {
                    throw e;
                    //return false;
                }
                // Wait for a key press so that you can see the console output
            }
            catch (Exception e)
            {
                throw e;
               // return false;
            }
            return true;
        }
        #endregion
        public static string Encryption(string value)
        {
            string key = "JHDA_Intranet|2018|JHDA|$ APP";

            byte[] bytesBuff = Encoding.Unicode.GetBytes(value);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    value = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return value;
        }
        public static string Decryption(string value)
        {
            string key = "JHDA_Intranet|2018|JHDA|$ APP";

            value = value.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(value);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    value = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return value;
        }

    }
}
