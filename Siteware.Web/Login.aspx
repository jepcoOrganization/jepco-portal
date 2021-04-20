<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Siteware.Web.Login" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <title>CMS - SiteWare</title>

    <link rel="stylesheet" href="AppTheme/css/style.default.css" type="text/css" />
    <link href="AppTheme/css/style.navyblue.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
<script src="js/html5shiv.js"></script>
<script src="js/respond.min.js"></script>
<![endif]-->

    <script src="AppTheme/Script/jquery-1.10.2.min.js"></script>
    <script src="AppTheme/Script/jquery-migrate-1.2.1.min.js"></script>
    <script src="AppTheme/Script/jquery-ui-1.10.3.min.js"></script>

    <script src="AppTheme/Script/bootstrap.min.js"></script>

    <script src="AppTheme/Script/modernizr.min.js"></script>
    <script src="AppTheme/Script/jquery.cookies.js"></script>

    <script src="AppTheme/Script/custom.js"></script>

    <script>
        jQuery(document).ready(function () {
            jQuery('#login').submit(function () {
                var u = jQuery('#txtusername').val();
                var p = jQuery('#txtPassword').val();
                if (u == '' && p == '') {
                    jQuery('.login-alert').fadeIn();
                    return false;
                }
            });
        });

        function validateLength(oSrc, arguments) {

            var str = arguments.Value;
            // var n = str.indexOf("<>");
            if (str.search('<'))
                arguments.IsValid = true;
            else
                arguments.IsValid = false;
            // args.IsValid = (args.Value.length >= 8);
        }
</script>
</head>
<body class="loginpage">
    <div class="loginpanel">
        <div class="loginpanelinner">
            <div class="logo animate0 bounceIn">
                <img src="AppTheme/images/logo.png" alt="" />
            </div>
            <form id="login" runat="server">
                
                <div class="inputwrapper login-alert">
                    <div class="alert alert-error">Invalid username or password</div>
                </div>
                <div class="inputwrapper animate1 bounceIn">
                    <asp:TextBox ID="txtusername" runat="server" placeholder="Enter any username"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="Login"
                        ControlToValidate="txtusername"
                        ErrorMessage="*" Style="color: Red; font-size: 20px; display: inline; position: relative; right: 5%; top: 17%;"
                        ClientValidationFunction="validateLength" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                </div>
                <div class="inputwrapper animate2 bounceIn">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter any password"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ValidationGroup="Login"
                        ControlToValidate="txtPassword"
                        ErrorMessage="*" Style="color: Red; font-size: 20px; display: inline; position: relative; right: 5%; top: 17%;"
                        ClientValidationFunction="validateLength" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                </div>
                <div class="inputwrapper animate3 bounceIn">
                    <asp:Button ID="btnLogin" runat="server" Text="Sign In" ValidationGroup="Login" OnClick="btnLogin_Click" style="display: block;border: 1px solid #0c57a3; padding: 10px;background: #0972dd;width: 100%;color: #fff;text-transform: uppercase;" />
                </div>
<%--                <div class="inputwrapper animate4 bounceIn">
                    <div class="pull-right">Not a member? <a href="registration.html">Sign Up</a></div>
                    <label>
                        <input type="checkbox" class="remember" name="signin" />
                        Keep me sign in</label>
                </div>--%>

            </form>
        </div>
        <!--loginpanelinner-->
    </div>

    <div class="loginfooter">
        <p>&copy; 2015. Auratechs Solutions. All Rights Reserved.</p>
    </div>
</body>
</html>
