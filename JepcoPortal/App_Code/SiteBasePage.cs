using System;
using Microsoft.CSharp;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web;
using SiteWare.Entity.Common.Enums;
/// <summary>
/// Summary description for SiteBasePage
/// </summary>
public class SiteBasePage : System.Web.UI.Page
{

    protected override void OnPreInit(System.EventArgs e)
    {
        base.OnPreInit(e);

        if (RouteData.Values["language"] != null)
        {
            string language = RouteData.Values["language"].ToString().ToLower();
            if (language == EnumUrlLang.en.ToString())
            {
                Session["CurrentLanguage"] = "1";
            }
            else
            {
                Session["CurrentLanguage"] = "2";
            }
        }
        else
        {
            if (Session["CurrentLanguage"] == null || Session["CurrentLanguage"].ToString() != "")
            {
                Session["CurrentLanguage"] = "2";
            }
        }

        if (Convert.ToInt32(Session["CurrentLanguage"]) == 1)
        {
            SessionManager.CurrentSessionManager.SiteID = 1;
            SessionManager.CurrentSessionManager.ThemeName = "ThemeEn";
        }
        else
        {
            SessionManager.CurrentSessionManager.SiteID = 2;
            SessionManager.CurrentSessionManager.ThemeName = "ThemeAr";
        }
        this.Theme = SessionManager.CurrentSessionManager.ThemeName;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        AddMetaTagsToPage();
    }

    protected virtual void AddMetaTagsToPage()
    {
    }

    protected override void InitializeCulture()
    {
        CultureInfo EngCul = new CultureInfo("en-US");
        CultureInfo arCul = new CultureInfo("ar-JO");
        if ((SessionManager.CurrentSessionManager.ThemeName != null))
        {
            if (SessionManager.CurrentSessionManager.ThemeName.ToLower().Contains("ar"))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = arCul;
                System.Threading.Thread.CurrentThread.CurrentUICulture = arCul;
            }
            else if (SessionManager.CurrentSessionManager.ThemeName.ToLower().Contains("en"))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = EngCul;
                System.Threading.Thread.CurrentThread.CurrentUICulture = EngCul;
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = arCul;
                System.Threading.Thread.CurrentThread.CurrentUICulture = arCul;
            }
        }
        else
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = EngCul;
            System.Threading.Thread.CurrentThread.CurrentUICulture = EngCul;
        }

        base.InitializeCulture();
    }

}