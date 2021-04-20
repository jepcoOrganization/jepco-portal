﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditNavigation.aspx.cs" Inherits="Siteware.Web.Navigation.EditNavigation" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

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
            <li><a href="../Navigation/ManageNavigation.aspx">Navigation List</a> <span class="separator"></span></li>
            <li>Edit
                <asp:Label ID="lblNavigationName1" runat="server"></asp:Label>
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
                    <asp:Label ID="lblNavigationName2" runat="server"></asp:Label>
                    Item</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <%--  <h4 class="widgettitle">Menu Information</h4>
                            <div class="widgetcontent form-horizontal">--%>
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">Menu Information</a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">Menu Image</a></li>
                                    <li><a href="#a-3" style="font-size: 14px;">Menu Summary2</a></li>
                                </ul>
                                <div id="a-1" style="min-height: 283px;">
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Select Language:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddLanguages" runat="server" class="chzn-select" TabIndex="2" Width="100%" Style="width: 211px;">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" InitialValue="0" ErrorMessage="Please Select Language" ID="validLang"
                                            ControlToValidate="ddLanguages" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n2" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Menu Name:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtMenuName" runat="server" PlaceHolder="Menu Name" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator2"
                                            ControlToValidate="txtMenuName" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n2" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Menu Title:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtMenuTitle" runat="server" PlaceHolder="Menu Title" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator6"
                                            ControlToValidate="txtMenuTitle" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Menu URL:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtMenuURL" runat="server" PlaceHolder="Menu URL" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator3"
                                            ControlToValidate="txtMenuURL" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n2" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Summary:</label>
                                        <div class="col-md-10" style="width:50%;">
                                            <asp:TextBox ID="txtSummary" TextMode="MultiLine" runat="server" PlaceHolder="Summary" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator5"
                                            ControlToValidate="txtSummary" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Open In:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddlTargetID" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                <asp:ListItem Text="-- Please Select --" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="New window" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Same window" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Parent Menu:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddlParentMenu" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                     <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Show Company:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="chkShowCompany" runat="server" Style="position: relative; top: 4px;" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Show User:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="chkShowUser" runat="server" Style="position: relative; top: 4px;" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Order:</label>
                                        <div class="col-md-10" style="width: 9%;">
                                            <asp:TextBox ID="txtMenuOrder" runat="server" PlaceHolder="Order" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator1"
                                            ControlToValidate="txtMenuOrder" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n2" EnableClientScript="True" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Style="left: 3%; position: relative; color: red;" ValidationGroup="n2"
                                            ControlToValidate="txtMenuOrder" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Publish Date:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <input id="txtPublishDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="n2"
                                            ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtPublishDate" ForeColor="Red"
                                            ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator4"
                                            ControlToValidate="txtPublishDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="n2" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Is Published:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="CBIsPublished" runat="server" Style="position: relative; top: 4px;" />
                                        </div>
                                    </div>
                                </div>
                                 <div id="a-2" style="min-height: 283px;">
                                    <div class="form-group">
                                        <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;">
                                            <div class="profilethumb" id="logotransitions" style="min-height: 150px;">
                                                <asp:Image ID="ImagePage" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px; padding-top: 5px;" />
                                                <input runat="server" style="display: none" class="form-control input-lg" id="newWinField" type="text">
                                            </div>
                                            <script>
                                                function fileBrowserCallBack(fileurl) {
                                                    $('#logotransitions > img').prop({ src: fileurl });
                                                    $('#<%= newWinField.ClientID %>').val(fileurl);
                                                    $('#FileBrowserModal').modal('hide');
                                                }
                                            </script>
                                        </div>
                                        <div class="form-group">
                                            <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal" data-toggle="modal">Choose Icon</a>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;">
                                            <div class="profilethumb" id="logotransitions2" style="min-height: 150px;">
                                                <asp:Image ID="ImagePage2" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px; padding-top: 5px;" />
                                                <input runat="server" style="display: none" class="form-control input-lg" id="newWinField2" type="text">
                                            </div>

                                        </div>
                                        <script> 
                                            function fileBrowserCallBack2(fileurl) {
                                                $('#logotransitions2 > img').prop({ src: fileurl });
                                                $('#<%= newWinField2.ClientID %>').val(fileurl);
                                                $('#FileBrowserModal2').modal('hide');

                                            }
                                        </script>
                                        <div class="form-group">
                                            <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal2" data-toggle="modal">Choose hover Icon</a>
                                        </div>

                                    </div>
                                </div>
                                <div id="a-3" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtSummary2" runat="server"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                        </div>
                        <br />
                        <p style="text-align: right;">
                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="n2" OnClick="btnAdd2_Click" />
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