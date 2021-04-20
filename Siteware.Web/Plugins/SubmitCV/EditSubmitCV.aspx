<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditSubmitCV.aspx.cs" Inherits="Siteware.Web.Plugins.SubmitCV.EditSubmitCV" Async="true" %>

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
            <li><a href="../SubmitCV/ManageSubmitCV.aspx">Submited CV List</a> <span class="separator"></span></li>
            <li>View
                <asp:Label ID="lblNewsname1" runat="server"></asp:Label>
                List</li>
        </ul>

        <div class="pageheader">
            <%-- <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click"
                Style="position: relative; float: right; top: 31px;" />--%>
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>View
                    <asp:Label ID="lblNewsname2" runat="server"></asp:Label>
                    Submited CV</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">Information</a></li>
                                </ul>
                                <div id="a-1" style="min-height: 283px;">
                                    <%--<div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">View Count:</label>
                                        <div class="col-md-10" style="width: 9%;">
                                            <asp:Label ID="lblViewCount" runat="server" Style="position: relative; top: 5px;"></asp:Label>
                                            <asp:Label ID="lblNewsLanguageId" Visible="false" runat="server" Style="position: relative; top: 5px;"></asp:Label>
                                        </div>
                                    </div>--%>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Name:</label>
                                        <div class="col-md-10" style="width: 22.9%;">

                                            <asp:TextBox runat="server" ID="txtName" placeholder="Add your full name" class="form-control" disabled="disabled"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Email:</label>
                                        <div class="col-md-10" style="width: 22.9%;">

                                            <asp:TextBox runat="server" ID="txtEmail" placeholder="Email" class="form-control" disabled="disabled"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Phone:</label>
                                        <div class="col-md-10" style="width: 22.9%;">

                                            <asp:TextBox runat="server" ID="txtPhone" placeholder="Phone" class="form-control" disabled="disabled"></asp:TextBox>
                                        </div>

                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Select Interest:</label>
                                        <div class="col-md-10" style="width: 22.9%;">

                                            <%-- <asp:DropDownList ID="ddlTarget" runat="server" class="chzn-select" TabIndex="2" Width="100%" AutoPostBack="true">
                                                <asp:ListItem Value="_parent">Same Window</asp:ListItem>
                                                <asp:ListItem Value="_blank">New Window</asp:ListItem>
                                            </asp:DropDownList>--%>


                                            <asp:DropDownList ID="ddlInterest" runat="server" class="chzn-select" TabIndex="2" Style="width: 203px;" AutoPostBack="true" disabled="disabled">
                                                <asp:ListItem Value="Full Time" Text="Full Time"></asp:ListItem>
                                                <asp:ListItem Value="Internship" Text="Internship"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">CV :</label>
                                        <div class="col-md-10">
                                            <asp:HyperLink runat="server" ID="lnlCV" Target="_blank"></asp:HyperLink>
                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Publish Date:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <input id="txtPublishDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" disabled="disabled" />

                                        </div>
                                    </div>



                                </div>

                            </div>
                        </div>
                        <br />
                        <p style="text-align: right;">
                            <%--<asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click" />--%>
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
    </div>
    <div id="popup_container" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Add Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">News Information Update Sucessfully</div>
            <div id="popup_panel">
                <%-- <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />--%>
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
</asp:Content>
