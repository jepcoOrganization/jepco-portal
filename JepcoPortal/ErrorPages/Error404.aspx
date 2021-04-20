<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error404.aspx.cs" Inherits="ErrorPages_Error404" %>

<link href="../App_Themes/ThemeEn/css/bootstrap.min.css" rel="stylesheet" />
<link href="../App_Themes/ThemeEn/css/bootstrap-timepicker.min.css" rel="stylesheet" />
<link href="../App_Themes/ThemeEn/css/main.css" rel="stylesheet" />
<!DOCTYPE html>
<style>
    body {
        /*<img src="../App_Themes/ThemeEn/images/Error_Image.jpg" />*/
        background: url('/App_Themes/ThemeEn/images/Error_Image.jpg') no-repeat;
        background-size: cover;
    }

    .headerError {
        color: rgb(245, 222, 152);
        font-size: 40px;
    }

    .divHome {
        padding: 8px;
        text-decoration: navajowhite;
        /*background: #00538D;*/
        border: 2px solid #fff;
        padding-right: 20px;
        padding-left: 20px;
        color: #fff;
    }
    label {
        font-weight: inherit;
    }
    .div {
    }

    .footer {
        height: 45px;
        background-color: #fff;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background: url(/App_Themes/ThemeEn/images/Error_Image.jpg) no-repeat; background-size: cover;">
    <!--<img src="../App_Themes/ThemeEn/images/BK_SABA.png" />-->
    <form id="form1" runat="server">
        <div>
        <div style="margin-top: 17%;">
            <center style="position: relative; left:4%;  width: 95%">
            <!--<img src="../App_Themes/ThemeAr/images/Logo.png" />-->
         <div>
             <Label class="headerError">Error 404</Label> 
         </div>
               
          <div style="color: #fff;margin: 11px;">
              <label Style="font-size: 24px;">The  Page you requested could not be found  </label>
          </div> 
            <br /><br />
            <a href="/default.aspx" class="divHome">Go Home</a>
            <br /><br /><br />
                <div  class="col-sm-12" style="height: 85px;">
                     <label Style="font-size: 30px;color:rgb(245, 222, 152);text-decoration:underline">Cotact Us:</label> 
                </div>
                  <br />
                <br />
            
                         <div class="col-sm-12">
                            <asp:ListView id="lstContactUs" runat="server" OnItemDataBound="lstContactUs_ItemDataBound">
                            <ItemTemplate>
                                <div class="col-sm-6">
                                    <asp:Image runat="server" Style="height: 34px;width: 34px;" ID="Img" ImageUrl='<%# Bind("Image") %>' /> 
                                    <asp:HyperLink runat="server" ID="lblItem" text='<%# Bind("Title") %>' Style="color:#fff">

                                    </asp:HyperLink>
                                </div>
                            </ItemTemplate> 
                        </asp:ListView> 
                       </div>
        </center>
        </div>
        <footer class="container-fluid" style="margin-top: 7.9%;position:relative;" >
            <div class="copyrights row text-center">
                <span id="lblCopyRight"> All rights reservied for Asamiah International School 2016 , Powered by </span>
                <a id="lnkCopyRight" href="http://www.aura-techs.com/">
                    <img src="/App_Themes/ThemeEn/images/auratechs-logo.png" alt="Auratechs"> 
                </a>
            </div>
        </footer>

       </div>
    </form>

</body>
</html>
