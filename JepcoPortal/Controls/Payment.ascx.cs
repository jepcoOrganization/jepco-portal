using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Payment : System.Web.UI.UserControl
{
    public object LnkArrayDetails { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["PaymentDetails"] != null)
            {
                hdnFileNAme.Value = Session["PaymentDetails"].ToString();
            }
      

        }
    }
    protected void hiddenArrayBills_ValueChanged(object sender, EventArgs e)
    {

    }


    protected async void paymentreq(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine(txtEmail.Text);

    }
}