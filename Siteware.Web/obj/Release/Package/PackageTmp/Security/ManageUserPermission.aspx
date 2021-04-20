<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageUserPermission.aspx.cs" Inherits="Siteware.Web.Security.ManageUserPermission" Async="true" EnableViewState="true" EnableEventValidation="false" %>

<%--EnableEventValidation="false"  --%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../AppTheme/css/style.navyblue.css" rel="stylesheet" />
    <link rel="stylesheet" href="../AppTheme/css/bootstrap-fileupload.min.css" />
    <link rel="stylesheet" href="../AppTheme/css/bootstrap-timepicker.min.css" />

    <script src="../AppTheme/Script/jquery.bxSlider.min.js"></script>
    <script src="../AppTheme/Script/bootstrap-fileupload.min.js"></script>
    <script src="../AppTheme/Script/bootstrap-timepicker.min.js"></script>
    <script src="../AppTheme/Script/jquery.validate.min.js"></script>
    <script src="../AppTheme/Script/jquery.tagsinput.min.js"></script>
    <script src="../AppTheme/Script/jquery.autogrow-textarea.js"></script>
    <script src="../AppTheme/Script/charCount.js"></script>
    <script src="../AppTheme/Script/colorpicker.js"></script>
    <script src="../AppTheme/Script/ui.spinner.min.js"></script>
    <script src="../AppTheme/Script/chosen.jquery.min.js"></script>
    <script src="../AppTheme/Script/forms.js"></script>

    <link rel="stylesheet" href="../AppTheme/Script/prettify/prettify.css" />
    <script src="../AppTheme/Script/prettify/prettify.js"></script>
    <script src="../AppTheme/Script/elements.js"></script>
    <script>
        jQuery(document).ready(function () {

            jQuery('.taglist .close').click(function () {
                jQuery(this).parent().remove();
                return false;
            });

        });
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            // Tags Input
            jQuery('.tagsss').tagsInput();
            jQuery(".spinner").spinner({ min: 0, max: 100, increment: 2 });
            //Replaces data-rel attribute to rel.
            //We use data-rel because of w3c validation issue
            jQuery('a[data-rel]').each(function () {
                jQuery(this).attr('rel', jQuery(this).data('rel'));
            });

            jQuery('#tooltips .btn').tooltip();
            jQuery('#popovers .btn').popover();


        });
    </script>
    <style>
        div.tagsinput
        {
            width: 90% !important;
            float: left;
        }

        option
        {
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightpanel">
        <ul class="breadcrumbs">
            <li><a href="<%= ResolveUrl("~/")%>Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="../Security/ManageUser.aspx">Manage User</a> <span class="separator"></span></li>
            <li>Edit
                <asp:Label ID="lblNavigationName1" runat="server"></asp:Label>
                Item</li>
        </ul>
        <%-- <asp:UpdatePanel runat="server" ID="updatepanelSearche">
            <ContentTemplate>--%>

        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="btnAdd2_Click"
                Style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-briefcase"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Edit
                    <asp:Label ID="lblNavigationName2" runat="server"></asp:Label>
                    Item</h1>
            </div>
        </div>


        <%--Manage User Permission--%>
        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-12" style="width: 100%;">
                        <div class="widgetbox personal-information">

                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">User Information</a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">Plugins</a></li>

                                    <li><a href="#a-3" style="font-size: 14px;">Pages</a></li>

                                </ul>

                                <div id="a-1" style="min-height: 283px;">
                                    <div class="col-md-4 profile-left">

                                        <div class="widgetbox profile-photo">
                                            <div class="headtitle">
                                                <%--<div class="btn-group">
                                    <button data-toggle="dropdown" class="btn dropdown-toggle">Action <span class="caret"></span></button>
                                    <ul class="dropdown-menu">
                                      <li><a href="#">Change Photo</a>
                                      </li>
                                      <li><a href="#">Remove Photo</a></li>
                                    </ul>
                                </div>--%>
                                                <h4 class="widgettitle">Profile Photo</h4>
                                            </div>
                                            <div class="widgetcontent" style="padding: 10px 0px; min-height: 187px;">

                                                <div class="profilethumb">
                                                    <asp:Image ID="ImageUser" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px;" />
                                                </div>
                                                <div class="form-group" style="position: relative; top: 15px;">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Style="width: 70%; float: left; padding-left: 2%; padding-top: 2%;" />
                                                    <span class="btn btn-default btn-file" style="width: 28%; float: left;">
                                                        <span class="fileupload-new">
                                                            <asp:LinkButton ID="lnkFileUpload" runat="server" OnClick="lnkFileUpload_Click">Preview</asp:LinkButton>
                                                        </span>
                                                    </span>
                                                    <%--<label for="inputPassword" class="col-md-2 control-label" style="width: 40%;">File Upload</label>
                            <div class="col-md-10" style="width: 60%; float: left;">
                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                    <div class="input-append" style="padding-left: 2%; border-left: 1px solid rgb(215, 215, 215); float: right;">
                                        <div class="uneditable-input" visible="true">
                                            <i class="glyphicon glyphicon-file fileupload-exists"></i>
                                            <asp:Label ID="lblFileUploaded" runat="server" class="fileupload-preview"></asp:Label>
                                        </div>
                                        <span class="btn btn-default btn-file">
                                            <span class="fileupload-new">Select file
                                            </span>
                                            <span class="fileupload-exists">Change</span>
                                            <input type="file" id="UploadFile" runat="server"/>
                                        </span>
                                        <a href="#" class="btn btn-default fileupload-exists" data-dismiss="fileupload">Remove</a>
                                    </div>
                                </div>
                            </div>--%>
                                                </div>

                                                <!--profilethumb-->
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-8">
                                        <div class="widgetbox login-information">
                                            <div class="tabbedwidget tab-primary" style="min-height: 229px;">
                                                <ul>
                                                    <li><a href="#a-4" style="font-size: 14px;">Login Information</a></li>
                                                    <li><a href="#a-5" style="font-size: 14px;">Change Password</a></li>
                                                </ul>
                                                <div id="a-4" style="min-height: 184px;">
                                                    <br />
                                                    <div>
                                                        <label style="padding-top: 6px;">Username:</label>
                                                        <div class="input-group" style="width: 89%; float: right;">
                                                            <span class="input-group-addon">
                                                                <i class="iconsweets-user"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" PlaceHolder="Ex: alaa.a"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                                                ControlToValidate="txtusername"
                                                                ErrorMessage="*"
                                                                ForeColor="red"
                                                                ValidationGroup="1"
                                                                Display="Dynamic"
                                                                Style="color: Red; float: right; margin-top: 2%; margin-right: -1.5%;"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div>
                                                        <label style="float: left; padding-top: 11px;">Email:</label>
                                                        <div class="input-group" style="width: 89%; float: right; position: relative; top: 5px;">
                                                            <span class="input-group-addon">
                                                                <i class="iconfa-envelope"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" PlaceHolder="Ex: i.3ala2@gmail.com"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                                ControlToValidate="txtEmail"
                                                                ErrorMessage="*"
                                                                ForeColor="red"
                                                                ValidationGroup="1"
                                                                Display="Dynamic"
                                                                Style="color: Red; float: right; margin-top: 2%; margin-right: -1.5%;"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RequiredFieldValidator16" runat="server"
                                                                ControlToValidate="txtEmail"
                                                                ErrorMessage="*"
                                                                ForeColor="red"
                                                                ValidationGroup="1"
                                                                Display="Dynamic"
                                                                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                                                                Style="color: Red; float: right; margin-top: 2%; margin-right: -1.5%;"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div style="width: 12%; float: left; margin-left: 11%; display: none;">
                                                        <label>Status:</label>
                                                        <asp:CheckBox ID="CbStatus" runat="server" Enabled="false" />
                                                    </div>
                                                    <div style="width: 25%; float: left; display: none;">
                                                        <label>IsDeleted:</label>
                                                        <asp:CheckBox ID="CbIsDeleted" runat="server" Enabled="false" />
                                                    </div>
                                                </div>
                                                <div id="a-5" style="min-height: 184px; text-align: center">
                                                    <h3>Reset Password Same User Name</h3>
                                                    <br />
                                                    <br />
                                                    <asp:Button ID="btnRestPass" runat="server" Text="Rest Password" CssClass="btn btn-primary" OnClick="btnRestPass_Click" />

                                                    <%--<br />
                                                    <div>
                                                        <asp:Label ID="lblOldPassword" runat="server" Style="font-weight: bold; font-size: 13px;">Old Password:</asp:Label>
                                                        <div class="input-group" style="width: 80%; float: right;">
                                                          
                                                            <asp:Label Text="*" runat="server" ID="lblOldPassValidation" Style="color: Red; float: right; position: relative; right: 4%; margin-right: -2%;" Visible="false"></asp:Label>
                                                            <div id="popovers" style="width: 10%; float: right; position: relative; top: -6px;">
                                                                <button style="height: 34px;" data-content="At Least 8 Char , At Least 1 Digit , At Least 1 Character , At Least 1 Capital Letter , At Least 1 Special Character." data-placement="left" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                                    ?
                                                                </button>
                                                            </div>

                                                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" PlaceHolder="Old Password"
                                                                Style="width: 90%; float: left; position: relative; top: -6px;" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div>
                                                        <asp:Label ID="lblNewPassword" runat="server" Style="font-weight: bold; font-size: 13px; position: relative; top: 7px;">New Password:</asp:Label>
                                                        <div class="input-group" style="width: 80%; float: right;">
                                                          
                                                            <asp:RegularExpressionValidator ID="RequiredFieldValidator21" runat="server"
                                                                ControlToValidate="txtNewPassword"
                                                                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
                                                                ErrorMessage="*"
                                                                ForeColor="red"
                                                                ValidationGroup="1"
                                                                Display="Dynamic"
                                                                Style="color: Red; float: right; margin-top: 2%; margin-right: 2%;"></asp:RegularExpressionValidator>
                                                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" PlaceHolder="New Password" Style="position: relative; top: -23%; width: 95.6%;" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div>
                                                        <asp:Label ID="lblConfirmPassword" runat="server" Style="font-weight: bold; font-size: 13px; position: relative; top: 6px;">Confirm Password:</asp:Label>
                                                        <div class="input-group" style="width: 80%; float: right;">
                                                        
                                                            <asp:CompareValidator ID="RequiredFieldValidator20" runat="server"
                                                                ControlToValidate="txtConfirmPassword"
                                                                ControlToCompare="txtNewPassword"
                                                                ErrorMessage="*"
                                                                ForeColor="red"
                                                                ValidationGroup="1"
                                                                Display="Dynamic"
                                                                Style="color: Red; float: right; margin-top: 2%; margin-right: 2%;"></asp:CompareValidator>
                                                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" PlaceHolder="Confirm Password" Style="position: relative; top: -23%; width: 95.6%;" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="col-lg-8" style="width: 100%;">
                                        <div class="widgetbox personal-information">
                                            <h4 class="widgettitle">Personal Information</h4>
                                            <div class="widgetcontent form-horizontal">

                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">First Name:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtFirstName" runat="server" PlaceHolder="First Name" class="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="txtFirstName"
                                                            ErrorMessage="*"
                                                            ForeColor="red"
                                                            ValidationGroup="1"
                                                            Display="Dynamic"
                                                            Style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <label class="col-md-2 control-label" style="width: 12%;">Second Name:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtSecondName" runat="server" PlaceHolder="Second Name" class="form-control"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="txtSecondName"
                                            ErrorMessage="*"
                                            ForeColor="red"
                                            ValidationGroup="1"
                                            Display="Dynamic" 
                                            style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <label class="col-md-2 control-label" style="width: 10%;">Last Name:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtLastName" runat="server" PlaceHolder="Last Name" class="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                            ControlToValidate="txtLastName"
                                                            ErrorMessage="*"
                                                            ForeColor="red"
                                                            ValidationGroup="1"
                                                            Display="Dynamic"
                                                            Style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">BirthDay:</label>
                                                    <div class="col-md-10" style="width: 22%; position: relative; top: 3px;">
                                                        <input id="datepicker" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                                    </div>
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 3.2%;">Martial Status:</label>
                                                    <div class="col-md-10" style="width: 22%; position: relative; top: 3px;">
                                                        <asp:DropDownList ID="ddlMartialStatus" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="ddlMartialStatus"
                                            ErrorMessage="*"
                                            ForeColor="Red"
                                            InitialValue="0"
                                            ValidationGroup="1"  
                                            Display="Dynamic"
                                            style="color: Red; float: right; margin-top: -3%; margin-right: -5%;">
                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Gender:</label>
                                                    <div class="col-md-10" style="width: 22%; position: relative; top: 1px;">
                                                        <asp:DropDownList ID="ddlGender" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="ddlGender"
                                            ErrorMessage="*"
                                            ForeColor="Red"
                                            InitialValue="-1"
                                            ValidationGroup="1"  
                                            Display="Dynamic"
                                            style="color: Red; float: right; margin-top: 3%; margin-right: -5%;">
                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 3.2%;">Country:</label>
                                                    <div class="col-md-10" style="width: 22%; position: relative; top: 1px;">
                                                        <asp:DropDownList ID="ddlCountry" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="ddlCountry"
                                            ErrorMessage="*"
                                            ForeColor="Red"
                                            InitialValue="0"
                                            ValidationGroup="1"  
                                            Display="Dynamic"
                                            style="color: Red; float: right; margin-top: -3%; margin-right: -5%;">
                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="widgetbox personal-information">
                                            <h4 class="widgettitle">Contact Details</h4>
                                            <div class="widgetcontent form-horizontal">

                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Telephone:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtTelephone" runat="server" PlaceHolder="Telephone" class="form-control"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RequiredFieldValidator71" runat="server"
                                                            ControlToValidate="txtTelephone"
                                                            ValidationExpression="^\d+"
                                                            ErrorMessage="*"
                                                            ForeColor="red"
                                                            ValidationGroup="1"
                                                            Display="Dynamic"
                                                            Style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RegularExpressionValidator>
                                                    </div>
                                                    <label class="col-md-2 control-label" style="width: 12%;">EXT:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtEXT" runat="server" PlaceHolder="Extension" class="form-control"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RequiredFieldValidator81" runat="server"
                                                            ControlToValidate="txtEXT"
                                                            ValidationExpression="^\d+"
                                                            ErrorMessage="*"
                                                            ForeColor="red"
                                                            ValidationGroup="1"
                                                            Display="Dynamic"
                                                            Style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Mobile:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtMobile" runat="server" Style="position: relative; top: 3px;" PlaceHolder="Mobile" class="form-control"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RequiredFieldValidator91" runat="server"
                                                            ControlToValidate="txtMobile"
                                                            ValidationExpression="^\d+"
                                                            ErrorMessage="*"
                                                            ForeColor="red"
                                                            ValidationGroup="1"
                                                            Display="Dynamic"
                                                            Style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Address:</label>
                                                    <div class="col-md-10" style="width: 88%;">
                                                        <asp:TextBox ID="txtaddress" runat="server" Style="position: relative; top: 6px;" PlaceHolder="Address" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                            ControlToValidate="txtaddress"
                                            ErrorMessage="*"
                                            ForeColor="red"
                                            ValidationGroup="1"
                                            Display="Dynamic" 
                                            style="color: Red; float: right; margin-top: -8%; margin-right: -2%;"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="widgetbox personal-information">
                                            <h4 class="widgettitle">Working Information</h4>
                                            <div class="widgetcontent form-horizontal">
                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Hire Date:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <input id="datepicker2" type="text" style="position: relative; top: 3px;" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Department:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" class="chzn-select" TabIndex="2" Width="100%" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                            ControlToValidate="ddlDepartment"
                                            ErrorMessage="*"
                                            ForeColor="Red"
                                            InitialValue="0"
                                            ValidationGroup="1"  
                                            Display="Dynamic"
                                            style="color: Red; float: right; margin-right: -4%; margin-top: 3%;">
                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 13%; padding-left: 8.2%;">Section:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:DropDownList ID="ddlSection" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                            ControlToValidate="ddlSection"
                                            ErrorMessage="*"
                                            ForeColor="Red"
                                            InitialValue="0"
                                            ValidationGroup="1"  
                                            Display="Dynamic"
                                            style="color: Red; float: right; margin-top: 3%; margin-right: -4%;">
                                        </asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Title:</label>
                                                    <div class="col-md-10" style="width: 22%;">
                                                        <asp:TextBox ID="txtTitle" runat="server" PlaceHolder="Title" class="form-control"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                            ControlToValidate="txtTitle"
                                            ErrorMessage="*"
                                            ForeColor="red"
                                            ValidationGroup="1"
                                            Display="Dynamic" 
                                            style="color: Red; float: right; margin-top: -12%; margin-right: -5%;"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <p style="text-align: right; display: none">
                                            <asp:Button ID="btnUpdate" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="btnUpdate_Click" />
                                        </p>
                                    </div>
                                </div>

                                <div id="a-2" style="min-height: 283px;">
                                    <div class="form-group col-md-5">
                                        <label class="col-md-12 control-label" style="text-align: left; padding-left: 1.2%;">Plugins</label>

                                    </div>
                                    <div class="form-group col-md-1">
                                        <br />
                                    </div>
                                    <div class="form-group col-md-5">
                                        <label class="col-md-12 control-label" style="text-align: left; padding-left: 1.2%;">User Plugins</label>

                                    </div>
                                    <div class="form-group col-md-5">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel runat="server" ID="updatepanel1">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="lstPlugins" runat="server" SelectionMode="Multiple" Width="100%" Style="min-height: 250px"></asp:ListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                    <asp:UpdatePanel runat="server" ID="updatepanelSearche">
                                        <ContentTemplate>

                                            <div class="form-group col-md-1">
                                                <br />
                                                <br />
                                                <%--<input type="button" id="btnPluginsleft" value="<<" />--%>
                                                <asp:Button ID="btnPluginsRemoveList" runat="server" CssClass="btn btn-primary" Text="<<" OnClick="btnPluginsRemoveList_Click" />

                                                <br />
                                                <br />
                                                <%--<input type="button" id="btnPluginsright" value=">>" />--%>
                                                <asp:Button ID="btnPluginsAddList" runat="server" CssClass="btn btn-primary" Text=">>" OnClick="btnPluginsAddList_Click" />

                                            </div>

                                        </ContentTemplate>
                                        <%-- <Triggers>
                                            <asp:PostBackTrigger ControlID="btnPluginsRemoveList" />
                                            <asp:PostBackTrigger ControlID="btnPluginsAddList" />
                                        </Triggers>--%>
                                    </asp:UpdatePanel>
                                    <div class="form-group col-md-5">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel runat="server" ID="updatepanel2">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="lstUsersPlugins" runat="server" SelectionMode="Multiple" Width="100%" Style="min-height: 250px"></asp:ListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                </div>

                                <div id="a-3" style="min-height: 283px;">
                                    <div class="form-group col-md-5">
                                        <label class="col-md-12 control-label" style="text-align: left; padding-left: 1.2%;">Pages</label>

                                    </div>
                                    <div class="form-group col-md-1">
                                        <br />
                                    </div>
                                    <div class="form-group col-md-5">
                                        <label class="col-md-12 control-label" style="text-align: left; padding-left: 1.2%;">User Pages</label>

                                    </div>
                                    <div class="form-group col-md-5">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel runat="server" ID="updatepanel4">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="lstPages" runat="server" SelectionMode="Multiple" Width="100%" Style="min-height: 250px"></asp:ListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                    <asp:UpdatePanel runat="server" ID="updatepanel3">
                                        <ContentTemplate>
                                            <div class="form-group col-md-1">
                                                <br />
                                                <br />
                                                <%--<input type="button" id="btnPagesleft" value="<<" />--%>
                                                <asp:Button ID="btnPagesRemoveList" runat="server" Text="<<" CssClass="btn btn-primary" OnClick="btnPagesRemoveList_Click" />
                                                <br />
                                                <br />
                                                <%--<input type="button" id="btnPagesright" value=">>" />--%>
                                                <asp:Button ID="btnPagesAddList" runat="server" Text=">>" CssClass="btn btn-primary" OnClick="btnPagesAddList_Click" />

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group col-md-5">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel runat="server" ID="updatepanel5">
                                                <ContentTemplate>
                                                    <asp:ListBox ID="lstUsersPages" runat="server" SelectionMode="Multiple" Width="100%" Style="min-height: 250px"></asp:ListBox>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                </div>



                                

                            </div>

                        </div>
                        <br />
                        <p style="text-align: right;">

                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="btnAdd2_Click" />

                        </p>
                    </div>
                </div>

                <div class="footer">
                    <div class="footer-left">
                        <span>&copy; 2015. Auratechs Solutions. All Rights Reserved.</span>
                    </div>
                    <div class="footer-right" style="height: 26px;">
                        <asp:HyperLink ID="lnkFooter" runat="server" NavigateUrl="http://www.aura-techs.com" Target="_blank">
                            <asp:Image ID="imglogo" runat="server" ImageUrl="~/AppTheme/Images/auratechs-logo.png" Style="height: 35px; width: 100%; margin-top: -5px;" />
                        </asp:HyperLink>
                    </div>

                </div>
            </div>
        </div>


        <%--  </ContentTemplate>

            <Triggers>
                <asp:PostBackTrigger ControlID="BtnAdd" />
            </Triggers>

        </asp:UpdatePanel>--%>
    </div>
    <div id="popup_container" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Update Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">User Information Update Sucessfully</div>
            <div id="popup_panel">
                <asp:Button ID="btnOk" OnClick="btnOk_Click"  runat="server" Text="Ok" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeSuccess" runat="server"
        TargetControlID="lblpopup"
        BehaviorID="mpeSuccess"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup"></asp:Label>


    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(function () {
            $("#btnPagesleft").bind("click", function () {
                var options = $("[id*=lstUsersPages] option:selected");
                for (var i = 0; i < options.length; i++) {
                    var opt = $(options[i]).clone();
                    $(options[i]).remove();
                    $("[id*=lstPages]").append(opt);
                }
            });
            $("#btnPagesright").bind("click", function () {
                var options = $("[id*=lstPages] option:selected");
                for (var i = 0; i < options.length; i++) {
                    var opt = $(options[i]).clone();
                    $(options[i]).remove();
                    $("[id*=lstUsersPages]").append(opt);
                }
            });

            ////////
            $("#btnPluginsleft").bind("click", function () {
                var options = $("[id*=lstUsersPlugins] option:selected");
                for (var i = 0; i < options.length; i++) {
                    var opt = $(options[i]).clone();
                    $(options[i]).remove();
                    $("[id*=lstPlugins]").append(opt);
                }
            });
            $("#btnPluginsright").bind("click", function () {
                var options = $("[id*=lstPlugins] option:selected");
                for (var i = 0; i < options.length; i++) {
                    var opt = $(options[i]).clone();
                    $(options[i]).remove();
                    $("[id*=lstUsersPlugins]").append(opt);
                }
            });


        });
    </script>
    <script type="text/javascript">
        $(function () {

 
            $("[id*=btnSubmit]").bind("click", function () {
                $("[id*=lstPages] option").attr("selected", "selected");
                $("[id*=lstUsersPages] option").attr("selected", "selected");


                $("[id*=lstPlugins] option").attr("selected", "selected");
                $("[id*=lstUsersPlugins] option").attr("selected", "selected");

            });


        });
    </script>

</asp:Content>
