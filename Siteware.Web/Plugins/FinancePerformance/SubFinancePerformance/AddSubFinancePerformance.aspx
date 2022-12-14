<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="AddSubFinancePerformance.aspx.cs" Inherits="Siteware.Web.Plugins.FinancePerformance.SubFinancePerformance.AddSubFinancePerformance" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../AppTheme/css/style.navyblue.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../../AppTheme/css/bootstrap-fileupload.min.css" />
    <link rel="stylesheet" href="../../../AppTheme/css/bootstrap-timepicker.min.css" />

    <script src="../../../AppTheme/Script/jquery.bxSlider.min.js"></script>
    <script src="../../../AppTheme/Script/bootstrap-fileupload.min.js"></script>
    <script src="../../../AppTheme/Script/bootstrap-timepicker.min.js"></script>
    <script src="../../../AppTheme/Script/jquery.validate.min.js"></script>
    <script src="../../../AppTheme/Script/jquery.tagsinput.min.js"></script>
    <script src="../../../AppTheme/Script/jquery.autogrow-textarea.js"></script>
    <script src="../../../AppTheme/Script/charCount.js"></script>
    <script src="../../../AppTheme/Script/colorpicker.js"></script>
    <script src="../../../AppTheme/Script/ui.spinner.min.js"></script>
    <script src="../../../AppTheme/Script/chosen.jquery.min.js"></script>
    <script src="../../../AppTheme/Script/forms.js"></script>

    <link rel="stylesheet" href="../../../AppTheme/Script/prettify/prettify.css" />
    <script src="../../../AppTheme/Script/prettify/prettify.js"></script>
    <script src="../../../AppTheme/Script/elements.js"></script>
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
            <li><a href="../SubFinancePerformance/ManageSubFinancePerformance.aspx">Sub Finance Performance List</a> <span class="separator"></span></li>
            <li>Add Sub Finance Performance</li>
        </ul>
        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="m1" OnClick="btnAdd2_Click"
                Style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Add Sub Finance Performance</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">Finance Performance Information</a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">Finance Performance Image</a></li>
                                </ul>
                                <asp:HiddenField runat="server" ID="lblLanguageID" />
                                <asp:HiddenField runat="server" ID="HDFinanceID" /> 
                                <br />
                                    <div id="a-1" style="min-height: 283px;">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Title:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtTitle" runat="server" PlaceHolder="Title" Style="width: 273px;" class="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator1"
                                                ControlToValidate="txtTitle" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
                                        </div>
                                        <div class="form-group" style="height: 125px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Summary:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtSummary" runat="server" PlaceHolder="Summary" Style="width: 273px;" TextMode="MultiLine" Rows="6" class="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator5"
                                                ControlToValidate="txtSummary" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
                                        </div>
                                         <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Title2:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtTitle2" runat="server" Style="width: 273px;" PlaceHolder="Title2" class="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator6"
                                                ControlToValidate="txtTitle2" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
                                        </div>
                                        
                                        <div class="form-group" style="height: 125px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%;  padding-left: 1.2%;">Description:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtDescription" runat="server" Style="width: 273px;" TextMode="MultiLine" Rows="6" PlaceHolder="Description" class="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator7"
                                                ControlToValidate="txtDescription" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
                                        </div>
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">URL:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtURL" runat="server" Style="width: 273px;" PlaceHolder="URL" class="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator2"
                                                ControlToValidate="txtURL" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
                                        </div>
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Order:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtMenuOrder" runat="server" Style="width: 273px;" PlaceHolder="Order" class="form-control"></asp:TextBox>
                                            </div>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator3"
                                                ControlToValidate="txtMenuOrder" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
                                        </div>
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Open In:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:DropDownList ID="ddlTargetID" runat="server" class="chzn-select" TabIndex="2" Style="width: 273px;">
                                                    <asp:ListItem Value="_parent">Same Window</asp:ListItem>
                                                    <asp:ListItem Value="_blank">New Window</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Publish Date:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <input id="txtPublishDate" runat="server" type="text" Style="width: 273px;" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                            </div>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="m1"
                                                ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtPublishDate" ForeColor="Red"
                                                ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator4"
                                                ControlToValidate="txtPublishDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="m1" EnableClientScript="True" />
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
                                                <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal" data-toggle="modal">Choose an Image</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                </div>
                            </div>
                        <br />
                        <p style="text-align: right;">
                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="m1" OnClick="btnAdd2_Click" />
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
            <div id="popup_message" style="text-align: center;">Sub Finance Performance Information Add Sucessfully</div>
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
