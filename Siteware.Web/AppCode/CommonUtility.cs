using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for CommonUtility
/// </summary>
public static class CommonUtility
{
    public static string Encryption(string value)
    {
        string key = ConfigurationManager.AppSettings["EncyDecyKey"].ToString();

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
        string key = ConfigurationManager.AppSettings["EncyDecyKey"].ToString(); ;

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