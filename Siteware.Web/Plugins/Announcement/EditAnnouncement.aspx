<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditAnnouncement.aspx.cs" Inherits="Siteware.Web.Plugins.Announcement.EditAnnouncement" Async="true" %>

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
            <li><a href="../Announcement/ManageAnnouncement.aspx">Announcement List</a> <span class="separator"></span></li>
            <li>Edit
                <asp:Label ID="lblAnnouncement1" runat="server"></asp:Label>
                List</li>
        </ul>

        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click"
                Style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Edit
                    <asp:Label ID="lblAnnouncement2" runat="server"></asp:Label>
                    Announcement</h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">New Information</a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">Content</a></li>
                                    <li runat="server" id="HeadlineVideo"><a id="LiVideo" runat="server" clientidmode="static" href="#a-4" style="font-size: 14px; display: none;">Announcement Video</a></li>
                                    <li runat="server" id="HeadlineImage"><a id="LiImage" runat="server" href="#a-3" clientidmode="static" style="font-size: 14px; display: none;">Announcement Image</a></li>
                                </ul>
                                <div id="a-1" style="min-height: 283px;">
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Select Language:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddlLanguages" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" InitialValue="0" ErrorMessage="Please Select Language" ID="validLang"
                                            ControlToValidate="ddlLanguages" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px;">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Title:</label>
                                        <div class="col-md-10" style="width: 23.9%;">
                                            <asp:TextBox ID="txtTitle" runat="server" PlaceHolder="Title" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Enter Title" ID="validTitle"
                                            ControlToValidate="txtTitle" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px;display:none;">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Media Content:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:DropDownList ID="ddlType" ClientIDMode="Static" runat="server" class="chzn-select" Style="width: 210px;" TabIndex="2" Width="100%">
                                                <asp:ListItem Value="0">Select type of upload</asp:ListItem>
                                                <asp:ListItem Value="1">Image</asp:ListItem>
                                                <asp:ListItem Value="2">Video</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Announcement Date:</label>
                                        <div class="col-md-10" style="width: 23.9%;">
                                            <input id="txtAnnounceDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="1"
                                            ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtAnnounceDate" ForeColor="Red"
                                            ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator4"
                                            ControlToValidate="txtAnnounceDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Publish Date:</label>
                                        <div class="col-md-10" style="width: 23.9%;">
                                            <input id="txtPublishDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="1"
                                            ErrorMessage="Please enter date in mm/dd/yyyy format" ControlToValidate="txtPublishDate" ForeColor="Red"
                                            ValidationExpression="(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Please Fill Date" ID="RequiredFieldValidator1"
                                            ControlToValidate="txtPublishDate" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Is Published:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="CBIsPublished" runat="server" Style="position: relative; top: 4px;" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px;display:none;">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Link:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:TextBox ID="txtLink" runat="server" PlaceHolder="Link" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator3" Style="display: inline;"
                                            ControlToValidate="txtLink" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="a1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px;display:none;">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Target:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:DropDownList ID="ddlTarget" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                <asp:ListItem Value="_parent">Same Window</asp:ListItem>
                                                <asp:ListItem Value="_blank">New Window</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" InitialValue="0" ErrorMessage="Please Select Language" ID="RequiredFieldValidator10"
                                            ControlToValidate="ddlTarget" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="a1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Order:</label>
                                        <div class="col-md-10" style="width: 9%;">
                                            <asp:TextBox ID="txtorderr" runat="server" PlaceHolder="Order" class="form-control"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator2"
                                            ControlToValidate="txtorderr" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Style="left: 3%; position: relative; color: red;" ValidationGroup="1"
                                            ControlToValidate="txtorderr" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div id="a-2" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtDescription" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-3" style="min-height: 283px; display: none">
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
                                </div>
                                <div id="a-4" style="min-height: 283px; display: none;">
                                    <div class="row col-lg-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Open In:</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:DropDownList class="chzn-select" TabIndex="2" Width="100%" Style="width: 210px" runat="server" ID="ddchoisLink">
                                                    <asp:ListItem Value="0">
                                                    Select Option  
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="1">
                                                    Upload to server 
                                                    </asp:ListItem>
                                                    <asp:ListItem Value="2">
                                                     External link
                                                    </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server" id="DivFileUpload" clientidmode="static" style="display: none;">
                                        <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;">
                                            <div class="profilethumb" id="logotransitions2" style="min-height: 60px; margin-top: 20px;">
                                                <video controls id="VideoID" clientidmode="static" runat="server">
                                                    <source id="sur1" />
                                                    <source id="sur2" />
                                                </video>
                                                <input runat="server" style="display: none" class="form-control input-lg" id="newWinField2" type="text">
                                            </div>
                                            <a class="btn btn-primary btn-lg" style="color: white; margin-top: 10px;" href="#FileBrowserModal2" data-toggle="modal">Choose a file</a>
                                        </div>
                                        <script>
                                                $(document).ready(function () {
                                                    $('#sur1').attr('src', $('#<%= newWinField2.ClientID %>').val()).appendTo($('#VideoID'));
                                                    $('#sur2').attr('src', $('#<%= newWinField2.ClientID %>').val()).appendTo($('#VideoID'));
                                                });
                                                function fileBrowserCallBack2(fileurl) {
                                                    debugger;
                                                    // $('<source />').attr('src', path).appendTo('#VideoIDCont');
                                                    //$('#VideoIDCont').attr('src', src);
                                                    $('#<%= newWinField2.ClientID %>').val(fileurl);
                                                    $('#FileBrowserModal2').modal('hide');
                                                    $('#sur1').attr('src', $('#<%= newWinField2.ClientID %>').val()).appendTo($('#VideoID'));
                                                    $('#sur2').attr('src', $('#<%= newWinField2.ClientID %>').val()).appendTo($('#VideoID'));
                                                    $('#VideoID').attr('src', $('#<%= newWinField2.ClientID %>').val());
                                                }
                                        </script>
                                    </div>
                                    <div class="form-group" style="height: 42px; display: none;" clientidmode="static" id="DivLink" runat="server">
                                        <div style="margin-top: 20px;">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Link :</label>
                                            <div class="col-md-10" style="width: 30%;">
                                                <asp:TextBox ID="txtlnkURL" runat="server" PlaceHolder="Image Alternate" class="form-control" Style="width: 90%; float: left; width: 400px"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <p style="text-align: right;">
                            <asp:Button ID="BtnAdd" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click" />
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
            <div id="popup_message" style="text-align: center;">Announcement Updated Sucessfully</div>
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
    <script>
                                                $("#ddlType").change(function () {
                                                    debugger;
                                                    if ($("#ddlType").val() == "0") {
                                                        $("#LiImage").css('display', 'none');
                                                        //$("#a-3").css('display', 'block');
                                                        $("#LiVideo").css('display', 'none');
                                                        //$("#a-4").css('display', 'none');
                                                    }
                                                    else {
                                                        if ($("#ddlType").val() == "1") {
                                                            $("#LiImage").css('display', 'block');
                                                            //$("#a-3").css('display', 'block');
                                                            $("#LiVideo").css('display', 'none');
                                                            //$("#a-4").css('display', 'none');
                                                        }
                                                        else {
                                                            $("#LiVideo").css('display', 'block');
                                                            //$("#a-4").css('display', 'block');
                                                            $("#LiImage").css('display', 'none');
                                                            //$("#a-3").css('display', 'none');
                                                        }
                                                    }
                                                });
                                                $("#ddchoisLink").change(function () {
                                                    debugger;
                                                    if ($("#ddchoisLink").val() == "1") {
                                                        $("#DivFileUpload").css('display', 'block');
                                                        $("#DivLink").css('display', 'none');
                                                    }
                                                    else {
                                                        $("#DivLink").css('display', 'block');
                                                        $("#DivFileUpload").css('display', 'none');
                                                    }
                                                });
    </script>
</asp:Content>
