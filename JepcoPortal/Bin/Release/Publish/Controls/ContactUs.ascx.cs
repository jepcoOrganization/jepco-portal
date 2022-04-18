using HtmlAgilityPack;
using SiteWare.Domain.Domains;
using SiteWare.Entity.Common.Entities;
using SiteWare.Entity.Common.Enums;
using SiteWare.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_ContactUs : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
              
               
                FillDetail();
                FillContactUs();
                FillSocialMedia();
            }
            ResultList<SettingEntity> Result = new ResultList<SettingEntity>();
            Result = SettingDomain.GetSettingAllWithoutAsync();
            if (Result.Status == ErrorEnums.Success)
            {
                if (!string.IsNullOrEmpty(Result.List[0].Latitude))
                    lblLatitude.Value = Result.List[0].Latitude;
                else
                    lblLatitude.Value = "32.465717";

                if (!string.IsNullOrEmpty(Result.List[0].Longitude))
                    lblLongiude.Value = Result.List[0].Longitude;
                else
                    lblLongiude.Value = "35.563362";
            }
        }
        catch
        {
        }
    }
    

    #region--> FetchLinksFromSource
    public string FetchLinksFromSource(string htmlSource)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(htmlSource);
        if (doc.DocumentNode.SelectNodes("//img") != null)
        {
            foreach (var img in doc.DocumentNode.SelectNodes("//img"))
            {
                string orig = img.Attributes["src"].Value;
                if (orig.Contains("http://") || orig.Contains("https://"))
                {
                    img.SetAttributeValue("src", orig);
                }
                else
                {
                    string newsrc = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + orig;
                    img.SetAttributeValue("src", newsrc);
                }

            }
        }
        if (doc.DocumentNode.SelectNodes("//table") != null)
        {
            foreach (var table in doc.DocumentNode.SelectNodes("//table"))
            {
                table.SetAttributeValue("class", "Tblres");
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
    #endregion
    #region--> lnkSubmitFrm_Click | Add | 30-10-2019
    protected void lnkSubmitFrm_Click(object sender, EventArgs e)
    {
        try
        {
            bool _isValid = false;
            bool _isValMob = false;
            bool _isValEmail = false;
            ResultEntity<ContactUsFormEntity> result = new ResultEntity<ContactUsFormEntity>();
            ContactUsFormEntity entity = new ContactUsFormEntity();
            entity.Name = txtName.Text;
            entity.Email = txtEmail.Text;
            entity.Title = string.Empty;
            entity.Message = txtMessage.Text;
            entity.AddDate = DateTime.Now;
            entity.IsDeleted = false;
            entity.Contact = 0;

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                _isValid = true;
            }

            if (!string.IsNullOrEmpty(txtMobile.Text))
            {
                _isValMob = true;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(txtEmail.Text);
                if (match.Success)
                {
                    _isValEmail = true;
                }
                else
                    _isValEmail = false;
            }
            if (_isValid && _isValEmail && _isValMob)
            {
                result = ContactUsFormDomain.InsertContactUsForm(entity);
                if (result.Status == ErrorEnums.Success)
                {
                    ResultList<SettingEntity> SettingResult = new ResultList<SettingEntity>();
                    SettingResult = SettingDomain.GetSettingAllWithoutAsync();
                    if (SettingResult.Status == ErrorEnums.Success)
                    {
                        string _fromMail = SettingResult.List[0].Email;
                        string _Password = SettingResult.List[0].PasswordEmail;
                        string _HOST = SettingResult.List[0].SMTPServer;
                        int _Port = Convert.ToInt32(SettingResult.List[0].PortNumber);
                        string _subject = "NES Inquiry";
                        string _toMail = txtEmail.Text;
                        string _Body = "<h1>Below are Contact Person Detail</h1>" +
                               "<p>Name :" + txtName.Text + "</p><br/>" +
                               "<p>Email :" + txtEmail.Text + "</p><br/>" +
                                "<p>Phone_No :" + txtMobile.Text + "</p><br/>" +
                               "<p>Message :" + txtMessage.Text + "</p>";
                        SendMail(_toMail, _fromMail, _Body, _subject, _Password, _HOST, _Port);
                    }
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtMessage.Text = "";
                    txtMobile.Text = "";
                    txtName.Style.Add("border", "none");
                    txtMobile.Style.Add("border", "none");
                    txtEmail.Style.Add("border", "none");

                    //lblInqTitle.Text = "Message";
                    //lblInqMessage.Text = "Your inquiry submitted successfully";

                    mpeInquiry.Show();
                }
            }
            else
            {
                if (_isValid)
                {
                    txtName.Style.Add("border", "none");
                }
                else
                {
                    txtName.Style.Add("border", "1px solid red");
                }
                if (_isValMob)
                {
                    txtMobile.Style.Add("border", "none");
                }
                else
                {
                    txtMobile.Style.Add("border", "1px solid red");
                }
                if (_isValEmail)
                {
                    txtEmail.Style.Add("border", "none");
                }
                else
                {
                    txtEmail.Style.Add("border", "1px solid red");
                }
                lnkSubmitFrm.Focus();
            }
        }
        catch
        {
        }
    }
    #endregion
    #region Send Mail | Add | 31-10-2019
    protected void SendMail(string toMail, string fromMail, string Body, string Subject, string Password, string HOST, int Port)
    {

        string FROM = fromMail;

        string TO = toMail;

        // Replace smtp_username with your SMTP user name.
        // string SMTP_USERNAME = ConfigurationManager.AppSettings["UserName"].ToString();
        string SMTP_USERNAME = FROM;

        // Replace smtp_password with your  SMTP password.
        //string SMTP_PASSWORD = ConfigurationManager.AppSettings["Password"].ToString();
        string SMTP_PASSWORD = Password;

        //string HOST = ConfigurationManager.AppSettings["SMTPServer"].ToString();
        // string HOST = HOST;

        //int PORT = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
        // int PORT = 587;
        // The subject line of the email
        //string SUBJECT = Subject;

        // The body of the email
        // string BODY = Body;

        // Create and build a new MailMessage object
        MailMessage message = new MailMessage();
        message.IsBodyHtml = true;
        //message.From = new MailAddress(FROM, FROMNAME);
        message.From = new MailAddress(FROM);
        message.To.Add(new MailAddress(TO));
        message.CC.Add(new MailAddress(FROM));
        message.Subject = Subject;
        message.Body = Body;

        // Create and configure a new SmtpClient
        SmtpClient client = new SmtpClient(HOST, Port);
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
        catch (Exception ex)
        {
        }

    }
    #endregion


    protected void FillContactUs()
    {
        try
        {
            ResultList<PluginContactUsEntity> res = new ResultList<PluginContactUsEntity>();
            res = PluginContactUsDomain.GetPluginContactAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstContactUs.DataSource = res.List.Where(s => !s.IsDeleted && s.IsPublished  && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.Order).ToList();
                lstContactUs.DataBind();
                //int Count = lstContactUs.Items.Count() + 1;
                HdnContausCount.Value = lstContactUs.Items.Count().ToString();


            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void FillDetail()
    {
        try
        {
            ResultEntity<PagesEntity> Result = new ResultEntity<PagesEntity>();
            string urllang = Page.RouteData.Values["Language"].ToString();
            string AliasPath = Page.RouteData.Values["RequestedPage"].ToString();
            string Alias = "/" + urllang + ConfigurationManager.AppSettings["RoutePath"].ToString() + AliasPath;
            Result = PagesDomain.GetPagesByAliasPathNotAsync(Alias, 2);
            if (Result.Status == ErrorEnums.Success)
            {
                if (Result.Entity.ContentHTML.Length > 0)
                {
                    lblContentdetail.Text = FetchLinksFromSource(Result.Entity.ContentHTML);
                }
                
            }
        }
        catch
        {
        }
    }

    #region--> FillSocialMedia
    protected  void FillSocialMedia()
    {
        try
        {
            ResultList<PluginSocialIconEntity> res = new ResultList<PluginSocialIconEntity>();
            res =  PluginSocialIconDomain.GetPluginSocialIconAllNotAsync();
            if (res.Status == ErrorEnums.Success)
            {

                lstSocialinContact.DataSource = res.List.Where(s => !s.IsDeleted && s.LanguageID == Convert.ToInt32(Session["CurrentLanguage"])).OrderBy(s => s.IconOrder).Skip(4).Take(4).ToList();
                lstSocialinContact.DataBind();

               

            }
        }
        catch (Exception ex)
        {
        }
    }


    protected void lstSocialContact_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image imgsocial = (Image)e.Item.FindControl("imgsocial");
                if (!string.IsNullOrEmpty(imgsocial.ImageUrl))
                    imgsocial.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgsocial.ImageUrl.Replace("~/", "~/Siteware/");

                //Image ImgSocialIcon = (Image)e.Item.FindControl("SocialIconImg");
                HiddenField imgURL = (HiddenField)e.Item.FindControl("imgURL");
                //if (!string.IsNullOrEmpty(ImgSocialIcon.ImageUrl))
                //    ImgSocialIcon.ImageUrl = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + ImgSocialIcon.ImageUrl.Replace("~/", "~/Siteware/");
                if (imgURL != null)
                {
                    if (!string.IsNullOrEmpty(imgURL.Value))
                    {
                        string imageover = (ConfigurationManager.AppSettings["ImagePath"]).ToString().Trim() + imgURL.Value.Replace("~/", "~/Siteware/");
                        imgsocial.Attributes.Add("onmouseover", "this.src='" + imageover + "'");
                        imgsocial.Attributes.Add("onmouseout", "this.src='" + imgsocial.ImageUrl + "'");
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    #endregion
}