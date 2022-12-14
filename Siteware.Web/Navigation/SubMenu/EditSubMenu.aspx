<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditSubMenu.aspx.cs" Inherits="Siteware.Web.Navigation.SubMenu.EditSubMenu" Async="true" %>

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
    <style>
        .ClassPages1 .chzn-container {
            width: 70% !important;
        }

            .ClassPages1 .chzn-container .chzn-drop {
                width: 100% !important;
            }
    </style>
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
            <li><a href="../ManageNavigation.aspx">Navigation List</a> <span class="separator"></span></li>
            <li><a href="../SubMenu/ManageSubMenu.aspx">Sub Menu List</a> <span class="separator"></span></li>
            <li>Edit
                <asp:Label ID="lblSubMenuName1" runat="server"></asp:Label>
                Item</li>
        </ul>

        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="btnAdd2_Click"
                Style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-briefcase"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Edit
                    <asp:Label ID="lblSubMenuName2" runat="server"></asp:Label>
                    Item</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <h4 class="widgettitle">Menu Information</h4>
                            <div class="widgetcontent form-horizontal">
                                <div class="form-group" style="height: 42px">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Select Language:</label>
                                    <div class="col-md-10" style="width: 22.9%;">
                                        <asp:DropDownList ID="ddlLanguages" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" InitialValue="0" ErrorMessage="Please Select Language" ID="validLang"
                                            ControlToValidate="ddlLanguages" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Menu Name:</label>
                                    <div class="col-md-10" style="width: 22.9%;">
                                        <asp:TextBox ID="txtMenuName" runat="server" PlaceHolder="Menu Name" class="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Menu URL:</label>
                                    <div class="col-md-10" style="width: 22.9%;">
                                        <asp:TextBox ID="txtMenuURL" runat="server" PlaceHolder="Menu URL" class="form-control"></asp:TextBox>
                                    </div>
                                    <div>
                                        <a data-toggle="modal" data-target="#MenuItem">Intenal Link</a>
                                    </div>

                                    <div class="modal fade" id="MenuItem" role="dialog">
                                        <div class="modal-dialog">
                                            <!-- Modal content-->
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <h3 class="modal-title" style="color: #000; text-align: center">List Of Pages</h3>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="BodyNewsLatter">
                                                        <div class="form-group ClassPages1">
                                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Pages:</label>
                                                            <asp:DropDownList ID="ddListPages" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button runat="server" ID="butOkPages" OnClick="butOkPages_Click" class="btn btn-primary" Text="OK" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Open In:</label>
                                    <div class="col-md-10" style="width: 22.9%;">
                                        <asp:DropDownList ID="ddlTargetID" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                            <asp:ListItem Text="-- Please Select --" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="New window" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Same window" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Parent Menu:</label>
                                    <div class="col-md-10" style="width: 22.9%;">
                                        <asp:DropDownList ID="ddlParentMenu" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Order:</label>
                                    <div class="col-md-10" style="width: 9%;">
                                        <asp:TextBox ID="txtMenuOrder" runat="server" PlaceHolder="Order" class="form-control"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator1"
                                        ControlToValidate="txtMenuOrder" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Style="left: 3%; position: relative; color: red;" ValidationGroup="1"
                                        ControlToValidate="txtMenuOrder" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+">
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Publish Date:</label>
                                    <div class="col-md-10" style="width: 22.9%;">
                                        <input id="txtPublishDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                    </div>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="1"
                                        ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtPublishDate" ForeColor="Red"
                                        ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator4"
                                        ControlToValidate="txtPublishDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Is Published:</label>
                                    <div class="col-md-10" style="width: 22%;">
                                        <asp:CheckBox ID="CBIsPublished" runat="server" Style="position: relative; top: 4px;" />
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
    </div>
    <div id="popup_container" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Update Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">Menu Information Update Sucessfully</div>
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
    <asp:Label runat="server" ID="lblpopup"></asp:Label>
</asp:Content>
