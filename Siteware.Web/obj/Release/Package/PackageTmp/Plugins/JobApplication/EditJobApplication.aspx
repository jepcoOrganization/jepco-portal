<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditJobApplication.aspx.cs" Inherits="Siteware.Web.Plugins.JobApplication.EditJobApplication" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../AppTheme/css/style.navyblue.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../AppTheme/css/bootstrap-fileupload.min.css" />
    <link rel="stylesheet" href="../../AppTheme/css/bootstrap-timepicker.min.css" />

    <script src="../../AppTheme/Script/jquery.bxSlider.min.js"></script>
    <script src="../../AppTheme/Script/bootstrap-fileupload.min.js"></script>
    <script src="../../AppTheme/Script/bootstrap-timepicker.min.js"></script>
    <script src="../../AppTheme/Script/jquery.validate.min.js"></script>
    <script src="../../AppTheme/Script/jquery.tagsinput.min.js"></script>
    <script src="../../AppTheme/Script/jquery.autogrow-textarea.js"></script>
    <script src="../../AppTheme/Script/charCount.js"></script>
    <script src="../../AppTheme/Script/colorpicker.js"></script>
    <script src="../../AppTheme/Script/ui.spinner.min.js"></script>
    <script src="../../AppTheme/Script/chosen.jquery.min.js"></script>
    <script src="../../AppTheme/Script/forms.js"></script>

    <link rel="stylesheet" href="../../AppTheme/Script/prettify/prettify.css" />
    <script src="../../AppTheme/Script/prettify/prettify.js"></script>
    <script src="../../AppTheme/Script/elements.js"></script>
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
        div.tagsinput {
            width: 90% !important;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="rightpanel">
        <ul class="breadcrumbs">
            <li><a href="<%= ResolveUrl("~/")%>Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li>Plugins<span class="separator"></span></li>
            <li><a href="../JobApplication/ManageJobApplication.aspx">Job Application List</a> <span class="separator"></span></li>
            <li>Edit
                <asp:Label ID="lblNewsname1" runat="server"></asp:Label>
                List</li>
        </ul>

        <div class="pageheader">
            <%--<asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click"
                Style="position: relative; float: right; top: 31px;" />--%>
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <%--<asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>--%>
                </h5>
                <h1>View
                    <asp:Label ID="lblNewsname2" runat="server"></asp:Label>
                    Job Application</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">Job Apply for</a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">Qualification</a></li>
                                    <li><a href="#a-3" style="font-size: 14px;">Experiance & Cources</a></li>
                                    <li><a href="#a-4" style="font-size: 14px;">Contact Detail</a></li>
                                </ul>
                                <div id="a-1" style="min-height: 283px;">
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="col-md-6 control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Job Type:</label>
                                                    <asp:DropDownList ID="ddlJobType" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="col-md-6 control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Job Name:</label>
                                                    <asp:DropDownList ID="ddlJobName" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    &nbsp;
                                    <fieldset>
                                        <legend>Personal Info</legend>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">1st Name:</label>
                                                    <asp:TextBox ID="txtFirstName" runat="server" PlaceHolder="1st Name" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">2nd Name:</label>
                                                    <asp:TextBox ID="txtSecondname" runat="server" PlaceHolder="2nd Name" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">3rd Name:</label>
                                                    <asp:TextBox ID="txtthirdName" runat="server" PlaceHolder="3rd Name" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-3">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Last Name:</label>
                                                    <asp:TextBox ID="txtlastName" runat="server" PlaceHolder="Last Name" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    &nbsp;
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">National ID:</label>
                                                    <asp:TextBox ID="txtNationalID" runat="server" PlaceHolder="National ID" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        &nbsp;
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Date of birth:</label>
                                                    <input id="txtBirthdate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" disabled="disabled" />
                                                </div>
                                            </div>
                                        </div>
                                        &nbsp;
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="col-md-6 control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Marital Status:</label>
                                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Child Number:</label>
                                                    <asp:TextBox ID="txtChildNumber" runat="server" PlaceHolder="Child Number" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    &nbsp;
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-6 col-md-6 col-sm-6">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Have license:</label>
                                                    <asp:RadioButtonList runat="server" ID="rbllicense" RepeatDirection="Horizontal" class="" Enabled="false">
                                                       <asp:ListItem Text="نعم" Value="True"></asp:ListItem>
                                                        <asp:ListItem Text="لا" Value="False"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divLicenseDetail" runat="server" visible="false">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="col-md-6 control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">License Type:</label>
                                                    <asp:DropDownList ID="ddllicenseType" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="col-md-6 control-label" style="text-align: left; width: 100%; padding-left: 1.2%;">Year of license:</label>
                                                    <asp:DropDownList ID="ddlYearoflicense" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    &nbsp;
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Qualification</label>
                                                    <asp:DropDownList ID="ddlQualification" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>

                                </div>

                                <div id="a-2" style="min-height: 283px;">

                                    <fieldset id="divQualification" runat="server">
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divuniname" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Uni Name</label>
                                                    <asp:TextBox ID="txtUniName" runat="server" PlaceHolder="Uni Name" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divname" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Name</label>
                                                    <asp:TextBox ID="txtname" runat="server" PlaceHolder="Name" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divyear" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Year</label>
                                                  <%--  <asp:DropDownList ID="ddlYear" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>--%>
                                                    <asp:TextBox ID="txtYear" runat="server" PlaceHolder="Year" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        &nbsp;
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divmajor" runat="server"  visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Major</label>
                                                    <asp:TextBox ID="txtMajor" runat="server" PlaceHolder="Major" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divmajor2" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Major2</label>
                                                    <asp:TextBox ID="txtMajor2" runat="server" PlaceHolder="Major2" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divmajorfrom" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Major From</label>
                                                    <asp:TextBox ID="txtMajorFrom" runat="server" PlaceHolder="Major From" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divavg" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Avg</label>
                                                    <asp:TextBox ID="txtAvg" runat="server" PlaceHolder="Avg" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4" id="divOverallEval" runat="server" visible="false">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Overall Eval</label>
                                                    <asp:TextBox ID="txtOverallEval" runat="server" PlaceHolder="Overall Eval" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>

                                <div id="a-3" style="min-height: 283px;">
                                    <fieldset id="fildsetPreviousExperiance" runat="server">
                                        <legend>Previous Experiance</legend>
                                        &nbsp;                                        
                                        <table class="table table-striped table-bordered table-hover dataTables-example">
                                            <thead>
                                                <tr>
                                                    <th>Entity Name
                                                    </th>
                                                    <th>Experiance Type
                                                    </th>
                                                    <th>Number of Year
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:ListView ID="lstPreviousExperiance" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="gradeX">

                                                            <td>
                                                                <asp:Label ID="lblEntityName" runat="server" Text='<%# Bind("EntityName") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblExperianceType" runat="server" Text='<%# Bind("ExperianceType") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblNumberOfYear" runat="server" Text='<%# Bind("NumberOfYear") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                        </table>

                                    </fieldset>
                                    &nbsp;
                                    <fieldset id="fildsetTrainingCources" runat="server">
                                        <legend>Training Cources</legend>
                                        &nbsp;                                       
                                        <table class="table table-striped table-bordered table-hover dataTables-example">
                                            <thead>
                                                <tr>
                                                    <th>Cource Type
                                                    </th>
                                                    <th>Cource Name
                                                    </th>
                                                    <th>Cource Dureation
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:ListView ID="lstTrainingCources" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="gradeX">

                                                            <td>
                                                                <asp:Label ID="lblCourceType" runat="server" Text='<%# Bind("CourceType") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCourceName" runat="server" Text='<%# Bind("CourceName") %>'></asp:Label>
                                                            </td>
                                                            <td class="center">
                                                                <asp:Label ID="lblCourceDuration" runat="server" Text='<%# Bind("CourceDuration") %>'></asp:Label>
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                        </table>
                                    </fieldset>

                                </div>

                                <div id="a-4" style="min-height: 283px;">
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Provenance</label>
                                                    <asp:DropDownList ID="ddlProvenance" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Area</label>
                                                    <asp:DropDownList ID="ddlArea" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Area2</label>
                                                    <asp:DropDownList ID="ddlArea2" runat="server" class="form-control" TabIndex="2" Width="100%" disabled="disabled">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    &nbsp;
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Street</label>
                                                    <asp:TextBox ID="txtStreet" runat="server" PlaceHolder="Street" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Building Number</label>
                                                    <asp:TextBox ID="txtBuildingNumber" runat="server" PlaceHolder="Building Number" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                    &nbsp;
                                    <fieldset>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Tel 1</label>
                                                    <asp:TextBox ID="txtTel1" runat="server" PlaceHolder="Tel1" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Tel 2</label>
                                                    <asp:TextBox ID="txtTel2" runat="server" PlaceHolder="Tel 2" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        &nbsp;
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Email</label>
                                                    <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Email" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         &nbsp;
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="control-label" style="text-align: left; width: 100%;">Uploaded File</label>
                                                    <asp:HyperLink runat="server" ID="lnkUploadFile" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>


                        </div>



                    </div>
                </div>
                <br />
                <%-- <p style="text-align: right;">
                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click" />
                        </p>--%>
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
    </div>
    <%--  <div id="popup_container" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Add Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">News Information Update Sucessfully</div>
            <div id="popup_panel">
                <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeSuccess" runat="server"
        TargetControlID="lblpopup"
        BehaviorID="mpeSuccess"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup"></asp:Label>--%>

    <%--<script type="text/javascript">
        $("document").ready(function () {


            var rblAnyOtherSchoolValue = $("#<%= rblAnyOtherSchool.ClientID %> input:checked").val();

            if (rblAnyOtherSchoolValue == 'False') {

                $('#PreSchool').hide();
            }
            else {
                $('#PreSchool').show();
            }

            var rblBusTransPortValue = $("#<%= rblBusTransPort.ClientID %> input:checked").val();
            if (rblBusTransPortValue == 'False') {

                $('#buswaydetail').hide();
            }
            else {
                $('#buswaydetail').show();
            }
            var rbltakinganymedicationValue = $("#<%= rbltakinganymedication.ClientID %> input:checked").val();
            if (rbltakinganymedicationValue == 'False') {

                $('#medicationDetails').hide();
            }
            else {
                $('#medicationDetails').show();
            }


            var rblallergiesValue = $("#<%= rblallergies.ClientID %> input:checked").val();
            if (rblallergiesValue == 'False') {


                $('#allergiesDetalis').hide();
            }
            else {
                $('#allergiesDetalis').show();
            }


            var rblsupportprogrammeValue = $("#<%= rblsupportprogramme.ClientID %> input:checked").val();
            if (rblsupportprogrammeValue == 'False') {

                $('#supportprogrammeDetials').hide();
            }
            else {
                $('#supportprogrammeDetials').show();
            }

            var rblSuspendedValue = $("#<%= rblSuspended.ClientID %> input:checked").val();
            if (rblSuspendedValue == 'False') {

                $('#SuspendedDetails').hide();
            }
            else {
                $('#SuspendedDetails').show();
            }

            $("[id*=<%=rblBusTransPort.ClientID %>]").change(function () {

                if ($(this).val() == 'False') {
                    $('#buswaydetail').hide();
                }
                else {
                    $('#buswaydetail').show();
                }
                return false;
            });



            $("[id*=<%=rbltakinganymedication.ClientID %>]").change(function () {

                if ($(this).val() == 'False') {
                    $('#medicationDetails').hide();
                }
                else {
                    $('#medicationDetails').show();
                }
                return false;
            });



            $("[id*=<%=rblallergies.ClientID %>]").change(function () {

                if ($(this).val() == 'False') {
                    $('#allergiesDetalis').hide();
                }
                else {
                    $('#allergiesDetalis').show();
                }
                return false;
            });


            $("[id*=<%=rblsupportprogramme.ClientID %>]").change(function () {

                if ($(this).val() == 'False') {
                    $('#supportprogrammeDetials').hide();
                }
                else {
                    $('#supportprogrammeDetials').show();
                }
                return false;
            });

            $("[id*=<%=rblSuspended.ClientID %>]").change(function () {

                if ($(this).val() == 'False') {
                    $('#SuspendedDetails').hide();
                }
                else {
                    $('#SuspendedDetails').show();
                }
                return false;
            });


        });








    </script>--%>
</asp:Content>
