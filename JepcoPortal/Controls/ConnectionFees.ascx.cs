using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ConnectionFees : System.Web.UI.UserControl
{
    public object LnkArrayDetails { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ConncetionFees"] != null)
            {
                hdnFileNAme.Value = Session["ConncetionFees"].ToString();
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