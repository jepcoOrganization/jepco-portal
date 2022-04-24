using SiteWare.Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Subscriptions : System.Web.UI.UserControl
{
    public int LangID = 0;
    string lang = string.Empty;
    private byte CurrLangID;
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrLangID = Convert.ToByte(Session["CurrentLanguage"]);
        if (Convert.ToInt32(Session["CurrentLanguage"]) == (int)EnumLanguage.English)
        {
            LangID = 1;
            lang = "/en";

            //lblLangID.Value = "2";
            // lnkLanguage.Text = "عربى";
        }
        else
        {
            LangID = 2;
            lang = "/ar";
            // lblLangID.Value = "1";
            // lnkLanguage.Text = "English";
        }
    }

    protected void LnkPaymentDetails_Click(object sender, EventArgs e)
    {
        Session["FileDetailsSub"] = htdFilenameDetais.Value.ToString();
        Response.Redirect(lang + "/Home/fileUpdate", false);
    }
}