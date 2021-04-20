<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddPages.aspx.cs" Inherits="Siteware.Web.Pages.AddPages" Async="true" %>

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
            //Replaces data-rel attribute to rel.
            //We use data-rel because of w3c validation issue
            jQuery('a[data-rel]').each(function () {
                jQuery(this).attr('rel', jQuery(this).data('rel'));
            });

            jQuery('#tooltips .btn').tooltip();
            jQuery('#popovers .btn').popover();

            jQuery('.clickMeta').click(function () {
                jQuery('.popover ').css({ display: "none" });

            });
        });
    </script>
    <style>
        div.tagsinput {
            width: 90% !important;
            float: left;
        }

        .ClassPages1 .chzn-container {
            width: 70% !important;
        }

            .ClassPages1 .chzn-container .chzn-drop {
                width: 100% !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightpanel">
        <ul class="breadcrumbs">
            <li><a href="../Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="ManagePages.aspx">Pages List</a> <span class="separator"></span></li>
            <li>Add Page List</li>
        </ul>

        <div class="pageheader">
            <asp:Button ID="btnAdd2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnAdd_Click"
                Style="position: relative; float: right; top: 31px;" />
            <div class="pageicon"><span class="iconfa-table"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Add Page List</h1>
            </div>
        </div>
        <script>

</script>
        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row" style="min-height: 456px;">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" class="clickMeta" style="font-size: 14px;">Page Information</a></li>
                                    <li><a href="#a-2" class="clickMeta" style="font-size: 14px;">SEO Attributes</a></li>
                                    <li><a href="#a-3" class="clickMeta" style="font-size: 14px;">Content</a></li>
                                    <li><a href="#a-7" class="clickMeta" style="font-size: 14px;">Content1</a></li>
                                    <li><a href="#a-4" class="clickMeta" style="font-size: 14px;display:none">Page Image</a></li>
                                    <li runat="server" id="IsListPage"><a href="#a-5" class="clickMeta" style="font-size: 14px;">Page Is List</a></li>
                                    <li><a href="#a-6" class="clickMeta" style="font-size: 14px;">Page Mapping</a></li>
                                </ul>
                                <div id="a-1" style="min-height: 283px;">
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Select Page Language:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddlLanguages" runat="server" class="chzn-select" TabIndex="2" Width="100%" OnSelectedIndexChanged="ddlLanguages_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" InitialValue="0" ErrorMessage="Please Select Language" ID="validLang"
                                            ControlToValidate="ddlLanguages" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="1" EnableClientScript="True" />
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Page Name:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtPageName" runat="server" PlaceHolder="Page Name" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Parent Page:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:DropDownList ID="ddlParentPage" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 61px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Description:</label>
                                        <div class="col-md-10" style="width: 89%;">
                                            <asp:TextBox ID="txtpageDescription" runat="server" Style="height: 54px;" PlaceHolder="Description" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
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
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Is Published:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="CBIsPublished" runat="server" Style="position: relative; top: 4px;" />
                                        </div>
                                    </div>
                                    <div class="form-group" id="divpageurl" runat="server" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Alias Path:</label>
                                        <div class="col-md-10" style="width: 23%;">
                                            <asp:TextBox ID="txtAliasPath" runat="server" PlaceHolder="Alias Path" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Name Path:</label>
                                        <div class="col-md-10" style="width: 23%;">
                                            <asp:TextBox ID="txtNamePath" runat="server" PlaceHolder="Name Path" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div id="a-2" style="min-height: 313px;">
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Title:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <asp:TextBox ID="txtMetaTitle" runat="server" PlaceHolder="Meta Title" class="form-control" Style="width: 90%; float: left"></asp:TextBox>
                                            <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 34px;" data-content="meta title it prest title to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Description:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <asp:TextBox ID="txtMetaDescription" runat="server" PlaceHolder="Meta Description" class="form-control" Style="width: 90%; float: left"></asp:TextBox>
                                            <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 34px;" data-content="meta Description it prest title to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Author:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <asp:TextBox ID="txtSEOAttribute" runat="server" PlaceHolder="Author" class="form-control" Style="width: 90%; float: left"></asp:TextBox>
                                            <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 34px;" data-content="meta SEO Attribute it prest SEO Attribute to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Keywords:</label>
                                        <div class="col-md-10" style="width: 30%;">
                                            <input name="tags" id="txtKeyWords" runat="server" class="tagsss input-large" style="position: relative; left: 1.5%; width: 90%; float: left" />
                                            <div id="popovers" style="width: 10%; float: right;">
                                                <button style="height: 100px;" data-content="Keyword it prest title to" data-placement="right" data-toggle="popover" data-container="body" class="btn btn-default" type="button" data-original-title="" title="">
                                                    ?
                                                </button>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div id="a-3" style="min-height: 283px;">

                                    <%-- <div class="form-group">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <label class="col-md-2 control-label" style="text-align: left; width: 12%; padding-left: 1.2%;">Is List:</label>
                                                <asp:CheckBox runat="server" AutoPostBack="true" ID="CheckList" OnCheckedChanged="CheckList_CheckedChanged" />
                                                <div class="col-md-10" style="width: 89%;" id="DivUpladFile" runat="server" visible="false" >
                                                     <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;padding-top: 1%;">File:</label>
                                                    <asp:FileUpload ID="FileUpload2" runat="server" Style="width: 33%; float: left; padding-left: 1%; padding-top: 1%;" />
                                                    <span class="btn btn-default btn-file" style="width: 12%; float: left;">
                                                        <span class="fileupload-new">
                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkFileUpload_Click">Preview</asp:LinkButton>
                                                        </span>
                                                </span>
                                            </div>  
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>  
                                    <br />
                                    <br />
                                    <br />--%>
                                    <CKEditor:CKEditorControl ID="txtContentHTML" runat="server"></CKEditor:CKEditorControl>

                                </div>
                                <div id="a-7" style="min-height: 283px;">
                                    <CKEditor:CKEditorControl ID="txtContentHTML1" runat="server"></CKEditor:CKEditorControl>
                                </div>

                                <div id="a-4" style="min-height: 283px;">
                                    <div class="form-group">
                                        <input type="hidden" id="txtModel" />
                                        <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;">
                                            <div class="profilethumb" id="logotransitions" style="min-height: 150px;">
                                                <asp:Image ID="ImagePage" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px; padding-top: 5px;" />
                                                <input runat="server" style="display: none" class="form-control input-lg" id="newWinField" type="text">
                                            </div>
                                            <%-- <script>
                                                function fileBrowserCallBack(fileurl) {
                                                    $('#logotransitions > img').prop({ src: fileurl });
                                                    $('#<%= newWinField.ClientID %>').val(fileurl);
                                                    $('#FileBrowserModal').modal('hide');
                                                }
                                            </script>--%>
                                        </div>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <a class="btn btn-primary btn-lg" style="color: white" href="#" onclick="showModel(1);" data-toggle="modal">Choose Banner Image</a>
                                    </div>
                                    <div class="form-group">
                                        <div class="widgetbox profile-photo" style="width: 39.5%; padding-left: 15px;">
                                            <div class="profilethumb" id="logotransitions1" style="min-height: 150px;">
                                                <asp:Image ID="MobileImage" runat="server" alt="" class="img-polaroid" Style="max-height: 109px; min-height: 109px; padding-top: 5px;" />
                                                <input runat="server" style="display: none" class="form-control input-lg" id="newWinField1" type="text">
                                            </div>
                                            <script>
                                                function showModel(id) {
                                                    debugger;
                                                    $("#txtModel").val(id);
                                                    $('#FileBrowserModal').modal('show');
                                                }
                                                function fileBrowserCallBack(fileurl) {
                                                    debugger;
                                                    var txtId = $("#txtModel").val();
                                                    if (txtId == "1") {
                                                        $('#logotransitions > img').prop({ src: fileurl });
                                                        $('#<%= newWinField.ClientID %>').val(fileurl);
                                                    }
                                                    else {
                                                        $('#logotransitions1 > img').prop({ src: fileurl });
                                                        $('#<%= newWinField1.ClientID %>').val(fileurl);
                                                    }
                                                    $('#FileBrowserModal').modal('hide');
                                                }
                                            </script>

                                        </div>
                                        <br />
                                    </div>
                                    <div class="form-group">
                                        <a class="btn btn-primary btn-lg" style="color: white" href="#" onclick="showModel(2);" data-toggle="modal">Choose Mobile Banner</a>
                                    </div>
                                </div>
                                <div id="a-5" style="min-height: 283px;">
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Is List:</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="checkIsList" runat="server" Style="position: relative; top: 4px;" />
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
                                            <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal2" data-toggle="modal">Choose a file</a>
                                        </div>
                                    </div>
                                </div>

                                <div id="a-6" style="min-height: 283px;">
                                    <div class="form-group" style="height: 42px;">
                                        <%--<label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Page URL:</label>--%>
                                        <asp:Label runat="server" class="col-md-2 control-label" ID="lblMapPageURL1" Style="text-align: left; width: 15%; padding-left: 1.2%; font-weight: bold;">Page URL:</asp:Label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtPageURL1" runat="server" PlaceHolder="Detail Page-URL" class="form-control"></asp:TextBox>
                                        </div>
                                        <div>
                                            <a data-toggle="modal" data-target="#MenuItem1">Intenal Link</a>
                                        </div>

                                        <div class="modal fade" id="MenuItem1" role="dialog">
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
                                                                <asp:DropDownList ID="ddListPages1" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button runat="server" ID="butOkPages1" OnClick="butOkPages1_Click" class="btn btn-primary" Text="OK" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px; visibility: hidden;">
                                        <%--<label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Page URL:</label>--%>
                                        <asp:Label runat="server" class="col-md-2 control-label" ID="lblMapPageURL2" Style="text-align: left; width: 15%; padding-left: 1.2%; font-weight: bold;">Page URL:</asp:Label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtPageURL2" runat="server" PlaceHolder="Detail Page-URL" class="form-control"></asp:TextBox>
                                        </div>
                                        <div>
                                            <a data-toggle="modal" data-target="#MenuItem2">Intenal Link</a>
                                        </div>

                                        <div class="modal fade" id="MenuItem2" role="dialog">
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
                                                                <asp:DropDownList ID="ddListPages2" runat="server" class="chzn-select" TabIndex="2" Width="100%">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button runat="server" ID="butOkPages2" OnClick="butOkPages2_Click" class="btn btn-primary" Text="OK" />
                                                    </div>
                                                </div>
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
            <div id="popup_message" style="text-align: center;">Page Information Add Sucessfully</div>
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
