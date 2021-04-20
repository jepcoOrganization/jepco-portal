<%@ WebHandler Language="C#" Class="Uploader" %>

using System;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

public class Uploader : IHttpHandler, IRequiresSessionState
{
    

public void ProcessRequest(HttpContext context)
{
    try
    {
        context.Response.ContentType = "text/plain";
        string id = context.Request.QueryString["username"].ToString();
        string username = Guid.NewGuid().ToString();
        
        if (context.Request.QueryString["username"].ToString() != "")
        {

            string dirFullPath = HttpContext.Current.Server.MapPath("~/Siteware_File/");
            string[] files;
            int numFiles  ;
           
            string str_image = "";
            if ((context.Request.QueryString["username"].ToString() != ""))
            {
                
                HttpFileCollection fil = context.Request.Files;
                for (int s = 0; s < fil.Count; s++)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;
                    files = System.IO.Directory.GetFiles(dirFullPath);
                    numFiles = files.Length;
                    numFiles = numFiles + 1;

                    /////// Image Path Get ///////

                    fileExtension = Path.GetExtension(fileName);
                    str_image = username  + fileExtension;

                    /////// Image Path Get End ///////

                    string pathToSave = HttpContext.Current.Server.MapPath("~/Siteware_File/") + str_image;
                    file.SaveAs(pathToSave); 
                    // img size  ////
                    System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                    int height = img.Height;
                    int width = img.Width;
                    decimal size = Math.Round(((decimal)file.ContentLength / (decimal)1024), 2);
                    
                    // image size end   // 
                    
                    //SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SiteWareCMS_DB"].ToString());
                    //con.Open();
                    //DateTime dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    //string month = dt.Month.ToString() + "/" + dt.Year.ToString();
                    //string date = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();
                    //SqlCommand cmd = new SqlCommand("insert into imagereg(imgname,username,imgpath,imgheight,imgwidth,imgsize,date1,month1) values('" + str_image.ToString() + "','" + id.ToString() + "','" + "~/Siteware_File/" + str_image.ToString() + "','" + height.ToString() + "','" + width.ToString() + "','" + size.ToString() + "','" + date.ToString() + "','" + month.ToString() + "')", con);
                    //cmd.ExecuteNonQuery();
                    context.Session["ImageFile3"] = str_image.ToString();
                    
                    context.Response.Write(str_image.ToString());

                }

            }
        }
    }
    catch (Exception ex)
    {

        context.Response.Write("ERROR: "+ex.Message);
    }
    }
     
    
    public bool IsReusable {
        get {
            return false;
        }
         
    }
 
  

}