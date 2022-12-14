<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditSetting.aspx.cs" Inherits="Siteware.Web.Setting.EditSetting" Async="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

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
            <li><a href="../Setting/ManageSetting.aspx">Settings</a> <span class="separator"></span></li>
            <li>Edit Setting</li>           
        </ul>

        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click"
                style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-cog"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server" >Siteware</asp:Label>
                </h5>
                <h1>Edit Setting</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 350px;">
                                <ul style="height:100px;">
                                    <li ><a href="#a-1" style="font-size: 10px;height:100px;padding:10px 14px;">Setting<br />Information</a></li>
                                    <li id="HeadlineImage" runat="server"><a href="#a-2" style="font-size: 10px;height:100px;padding:10px 14px;">Logo</a></li>                                    
                                    <li ><a href="#a-3" style="font-size: 10px;height:100px;padding:10px 14px;">SMTP<br />Server</a></li>
                                    <li ><a href="#a-5" style="font-size: 10px;height:100px;padding:10px 14px;">Email<br />Content</a></li>
                                    <li ><a href="#a-6" style="font-size: 10px;height:100px;padding:10px 14px;">User<br />Email<br />Content</a></li>
                                    <li ><a href="#a-4" style="font-size: 10px;height:100px;padding:10px 14px;">Copyright</a></li>
                                                                               
                                     <li><a href="#a-7" style="font-size: 10px;padding:10px 14px;">Renewable<br />Device<br />Admin<br />Email</a></li>
                                    <li ><a href="#a-8" style="font-size: 10px;padding:10px 14px;">Renewable<br />Device<br />User<br />Email</a></li>
                                                                                
                                    <li ><a href="#a-9" style="font-size: 10px;padding:10px 14px;">Renewable<br />Solar<br />Admin<br />Email</a></li>
                                    <li ><a href="#a-10" style="font-size: 10px;padding:10px 14px;">Renewable<br />Solar<br />User<br />Email</a></li>
                                                                                
                                    <li ><a href="#a-11" style="font-size: 10px;padding:10px 14px;">Renewable<br />Registration<br />Admin<br />Email</a></li>
                                    <li ><a href="#a-12" style="font-size: 10px;padding:10px 14px;">Renewable<br />Registration<br />User<br />Email</a></li>
                                    
                                    <li ><a href="#a-13" style="font-size: 10px;padding:19px 14px;">Forget<br />Password<br />Admin</a></li>
                                    <li ><a href="#a-14" style="font-size: 10px;padding:19px 14px;">Forget<br />Password<br />User</a></li>
                                    
                                </ul>
                                <div id="a-1" style="min-height: 283px;">
                                     <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Select Language:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                             <asp:DropDownList ID="ddLanguages" runat="server" class="chzn-select" TabIndex="2" Width="100%" style="width: 273px;">
                                            </asp:DropDownList>
                                        </div>
                                         <asp:RequiredFieldValidator runat="server" InitialValue="0" style="margin: 70px;" ErrorMessage="Please Select Language" ID="validLang"
                                            ControlToValidate="ddLanguages" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />

                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Website:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtwebsite" runat="server" PlaceHolder="Website" class="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                     <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Page Name:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtPageName" runat="server" PlaceHolder="Page Name" class="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height:61px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Google Analytic:</label>
                                        <div class="col-md-10" style="width: 89%;">
                                            <asp:TextBox ID="txtGoogleAnalytic" runat="server" Style="height: 54px;" PlaceHolder="Google Analytic" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div> 
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Year:</label>
                                        <div class="col-md-10" style="width: 9%;">
                                            <asp:TextBox ID="txtYear" runat="server" PlaceHolder="Year" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator2"
                                            ControlToValidate="txtYear" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Style="left: 3%; position: relative; color: red;" ValidationGroup="1"
                                            ControlToValidate="txtYear" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Date Format:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:RadioButton ID="RadioButton1" runat="server" Text="dd-MM-YYYY" Style="position: relative; top: 4px;" />
                                            <asp:RadioButton ID="RadioButton2" runat="server" Text="MM-dd-YYYY" Style="position: relative; top: 4px;left: 8%;" />
                                        </div>
                                    </div>  
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Longitude:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtLongitude" runat="server" PlaceHolder="Longitude" class="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Latitude:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtLatitude" runat="server" PlaceHolder="Latitude" class="form-control"></asp:TextBox>
                                        </div>
                                    </div> 
                                    <div class="form-group" style="height: 61px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Working Hours:</label>
                                        <div class="col-md-10" style="width: 89%;">
                                            <asp:TextBox ID="txtWorkingHours" runat="server" Style="height: 54px;" PlaceHolder="Working Hours" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Publish Date:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <input id="txtPublishDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                        </div>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="1"
                                              ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtPublishDate" ForeColor="Red"
                                              ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator> 
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator1"
                                            ControlToValidate="txtPublishDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Is Published:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="CBIsPublished" runat="server" Style="position: relative; top: 4px;" OnCheckedChanged="CBIsPublished_CheckedChanged" AutoPostBack="true" />
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
                                            <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal" data-toggle="modal">Choose a file</a>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;">
                                            <div class="profilethumb" id="logotransitions2" style="min-height: 150px;">
                                                <asp:Image ID="ImageFooter" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px; padding-top: 5px;" />
                                                <input runat="server" style="display: none" class="form-control input-lg" id="newWinField2" type="text">
                                            </div>
                                            <script>
                                                function fileBrowserCallBack2(fileurl) {
                                                    $('#logotransitions2 > img').prop({ src: fileurl });
                                                    $('#<%= newWinField2.ClientID %>').val(fileurl);
                                                    $('#FileBrowserModal2').modal('hide');
                                                }
                                            </script>
                                        </div>
                                        <div class="form-group">
                                            <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal2" data-toggle="modal">Choose a Footer file</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="a-3" style="min-height: 283px;">
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">SMTP Server:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtSMTPServer" runat="server" PlaceHolder="SMTP Server" class="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Email:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Email" class="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height:42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Password:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtPassword" runat="server" PlaceHolder="Password" class="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                       <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Port Number:</label>
                                        <div class="col-md-10" style="width: 22.9%; margin-left:11px">
                                            <asp:TextBox ID="txtPortNumber" runat="server" PlaceHolder="Port Number" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">From:</label>
                                        <div class="col-md-10" style="width: 22.9%;margin-left:11px">
                                            <asp:TextBox ID="txtFromemail" runat="server" PlaceHolder="Email" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                         <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Enable SSL</label>
                                        <div class="col-md-10" style="width: 22.9%;margin-left:11px"">
                                            <asp:CheckBox ID="cbEnableSSL" runat="server" />
                                        </div>
                                    </div>

                                </div>
                                <div id="a-4" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtContentHTML" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                 <div id="a-5" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtEmailContent" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                 <div id="a-6" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtUserEmailContent" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-7" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtDeviceAdmin" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-8" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtDeviceUser" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-9" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtSolarAdmin" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-10" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtSolarUser" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-11" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtRegistrationAdmin" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-12" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtRegistrationUser" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                 <div id="a-13" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtForgetPasswordAdmin" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-14" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtForgetPasswordUser" runat="server"></CKEditor:CKEditorControl>
                                </div>

                            </div>
                        </div>
                        <br />
                        <p style="text-align: right;">
                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click"/>
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
    <div id="popup_container" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Update Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">Setting Information Update Sucessfully</div>
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

        <div id="popup_container" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Warning Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">You Can't Publish More Than Setting</div>
            <div id="popup_panel">
                <asp:Button ID="btnInformation" runat="server" Text="Ok" OnClick="btnInformation_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeInformation" runat="server"
        TargetControlID="lblpopup2"
        BehaviorID="mpeInformation"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup2"></asp:Label>
</asp:Content>
