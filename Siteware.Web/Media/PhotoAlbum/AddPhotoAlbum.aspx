<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPhotoAlbum.aspx.cs" Inherits="Siteware.Web.Pages.AddPhotoAlbum" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

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
            <li><a href="<%= ResolveUrl("~/")%>Dashboard.aspx"><i class="iconfa-home"></i></a> <span class="separator"></span></li>
            <li><a href="../PhotoAlbum/ManagePhotoAlbum.aspx">Photo Ablum List</a> <span class="separator"></span></li>
            <li>Add Photo Ablum</li>           
        </ul> 
        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ph1" OnClick="BtnAdd_Click"
                style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server" >Siteware</asp:Label>
                </h5>
                <h1>Add Photo Ablum</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 385px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">Photo Ablum Information</a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">SEO Attributes</a></li>
                                    <li><a href="#a-3" style="font-size: 14px;">Photo Ablum Image </a></li>
                                </ul>
                                <br />
                                <div id="a-1" style="min-height: 283px;">
                                     <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Select Language:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                             <asp:DropDownList ID="ddlLanguages" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                            </asp:DropDownList>                                            
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" InitialValue="0" style="margin: 70px;" ErrorMessage="Please Select Language" ID="validLang"
                                            ControlToValidate="ddlLanguages" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="ph1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Title:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtPageName" runat="server" PlaceHolder="Title" style="width: 273px;"  class="form-control"></asp:TextBox>
                                        </div>

                                    </div>  
                                     <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Order:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtorder" runat="server" PlaceHolder="Order" style="width: 273px;"  class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator1"
                                            ControlToValidate="txtorder" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="ph1" EnableClientScript="True" />
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Style="left: 3%;position: relative;color: red;" ValidationGroup="ph1" 
                                                 ControlToValidate="txtorder" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+">
                                          </asp:RegularExpressionValidator>
                                    </div> 
                                     <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Is Published:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="CBIsPublished" runat="server" Style="position: relative; top: 4px;" />
                                        </div>
                                    </div>
                                     <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Publish Date:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <input id="txtPublishDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                        </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="ph1"
                                              ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtPublishDate" ForeColor="Red"
                                              ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator> 
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator4"
                                            ControlToValidate="txtPublishDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="ph1" EnableClientScript="True" />
                                    </div>

                                </div>

                                <div id="a-2" style="min-height: 283px;">
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Image Title:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <asp:TextBox ID="txtMetaTitle" runat="server" PlaceHolder="Image Title" class="form-control" Style="width: 90%; float: left;width: 273px"></asp:TextBox>
                                      <%--      <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 34px;" data-content="meta title it prest title to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>--%>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Image Alternate:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <asp:TextBox ID="txtMetaDescription" runat="server" PlaceHolder="Image Alternate" class="form-control" Style="width: 90%; ;width: 273px;float: left"></asp:TextBox>
                                          <%--  <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 34px;" data-content="meta Description it prest title to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>--%>
                                        </div>
                                    </div>
                                  <%--  <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 10%; padding-left: 1.2%;">Keywords:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <input name="tags" id="txtKeyWords" runat="server" class="tagsss input-large" style="position: relative; left: 1.5%; width: 90%; float: left" />
                                            <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 100px;" data-content="Keyword it prest title to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>
                                        </div>

                                    </div>--%>
                                </div>

                                <div id="a-3" style="min-height: 283px;">
                                      <div class="form-group">
                                         <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;"> 
                                            <div class="profilethumb" id="logotransitions" style="min-height: 150px;">
                                                <asp:Image ID="ImagePage" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px; padding-top: 5px;" /> 
                                                 <input runat=server  style="display:none" class="form-control input-lg" id="newWinField" type="text">
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
                                            <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal" data-toggle="modal">Choose a file</a>
                                        </div>
                                    </div>
                                </div>

                                
                            </div>
                        </div>
                        <br />
<%--                        <br />
                        <div class="widgetbox personal-information">
                            <h4 class="widgettitle"></h4>
                            <div class="widgetcontent form-horizontal">

                            </div>
                        </div>--%>
                        <p style="text-align: right;">
                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="ph1" OnClick="BtnAdd_Click"/>
                        </p>
                    </div>
                </div>

                <div class="footer">
                        <div class="footer-left" >
                            <span>&copy; 2015. Auratechs Solutions. All Rights Reserved.</span>
                        </div>
                        <div class="footer-right" style="height: 26px;">
                            <asp:HyperLink ID="lnkFooter" runat="server" NavigateUrl="http://www.aura-techs.com" Target="_blank">
                            <asp:Image ID="imglogo" runat="server" ImageUrl="~/AppTheme/Images/auratechs-logo.png" style="height: 35px;width: 100%;margin-top: -5px;"/>
                            </asp:HyperLink>
                        </div>
                    </div>
            </div>
        </div>
    </div>
    <div id="popup_container" class="ui-draggable" style="display:none;position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Add Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">Photo Ablum Information Add Sucessfully</div>
            <div id="popup_panel">
                <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" style="color: #3b6c8e;border: 2px solid #3b6c8e;padding: 7px 0;background: #fff;" />
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
