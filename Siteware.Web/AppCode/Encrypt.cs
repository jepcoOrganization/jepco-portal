using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace Siteware.Web.AppCode
{
    public class Encrypt
    {
        public static string Decrypted(string SrcStr)
        {
            // ERROR: Not supported in C#: OnErrorStatement

            string TempStr = null;
            SrcStr = Strings.StrReverse(SrcStr.Trim());

            int i = 0;

            for (i = 1; i <= Strings.Len(SrcStr.Trim()); i++)
            {
                TempStr = TempStr + Strings.ChrW(Strings.AscW(Strings.Mid(SrcStr, i, 1)) + (1));
            }

            TempStr = Strings.Mid(TempStr, 1, Strings.InStr(1, TempStr, "(-(") - 1);
            return TempStr;
        }

        public static string Encrypted(string SrcStr)
        {
            string TempStr = null;
            SrcStr = Strings.StrReverse(SrcStr.Trim());

            for (int i = 1; i <= Strings.Len(SrcStr.Trim()); i++)
            {
                TempStr += Strings.ChrW(Strings.AscW(Strings.Mid(SrcStr, i, 1)) - (1));
            }
            try
            {
                TempStr = Strings.Mid(TempStr, 1, Strings.InStr(1, TempStr, "(-(") - 1);
            }
            catch (Exception ex)
            {
            }
            return TempStr;
        }
    }
}