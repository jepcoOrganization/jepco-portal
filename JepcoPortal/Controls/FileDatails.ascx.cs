using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_FileDatails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["FileDetails"] != null)
            {
                hdnFileNAme.Value = Session["FileDetails"].ToString();
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string Billnumber = BillNo.Value.ToString();
        Decimal PaymentAmount = Convert.ToDecimal(BillAmount.Value);

        string URLValueACnk = Billnumber + "|" + "1051" + "|" + "61283" + "|" + "1" + "|" + "JOD" + "|" + Billnumber + "|" + "|" + PaymentAmount + "|" + "|" + "|" + "AR" + "|" + "|" + "d3abe71adf8c4c769a5cab5fea581663";


        var EncrypCode = BCrypt.Net.BCrypt.HashString(URLValueACnk);

        if (EncrypCode != null)
        {
            string Urlpayment = ConfigurationManager.AppSettings["PaymentefawateerAPIurl"].ToString();

            string UrlRedirect = Urlpayment + "RequestParams=" + Billnumber + "|" + "1051" + "|" + "61283" + "|" + "1" + "|" + "JOD" + "|" + Billnumber + "|" + "|" + PaymentAmount + "|" + "|" + "|" + "AR" + "|" + "|" + EncrypCode;

            Response.Redirect(UrlRedirect, false);
            //Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$R3K7OZt.PClq7gjXCmUrguVPkgBugQp3ra35l5ibw/IcT1YwSkAX2", false);
        }
        //20201000 | 1051 | 61283 | 1 | JOD | 20201000 || 29.778 ||| AR || d3abe71adf8c4c769a5cab5fea581663

        //Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6", false);
        //string abcd = ConfigurationManager.AppSettings["RedirectURLPaymentLocal"].ToString() + "20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6";
        //Response.Redirect(ConfigurationManager.AppSettings["RedirectURLPaymentLocal"].ToString() + "20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6", false);
        //Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FJsGs0gO8UeOKdphjbYdOu0WFpnx46YfCjJi0F8ttILeBL2JAlJ8i",false);
         //Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$R3K7OZt.PClq7gjXCmUrguVPkgBugQp3ra35l5ibw/IcT1YwSkAX2", false);
                              //https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$R3K7OZt.PClq7gjXCmUrguVPkgBugQp3ra35l5ibw/IcT1YwSkAX2
    }

    public class PaymentResopnce
    {
        public string BilrTrxNo { get; set; }
        public int TrxStatus { get; set; }
        public string DirectPayTrxNo { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string OtherDetails { get; set; }
        public string SecureHash { get; set; }
    }
}