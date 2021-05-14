<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="ViewRenewableEnergyUserRequests.aspx.cs" Inherits="Siteware.Web.Plugins.RenewableEnergyUserRequests.ViewRenewableEnergyUserRequests" Async="true" %>

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

        .paddt tr.first td {
            padding-top: 10px;
        }

        .paddt tr.last td {
            padding-bottom: 10px;
        }

        .paddt td.first {
            padding-left: 10px;
        }

        .paddt td.last {
            padding-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightpanel">
        <ul class="breadcrumbs">
            <li><a href="<%= ResolveUrl("~/")%>Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="../RenewableEnergyUserRequests/ManageRenewableEnergyUserRequests.aspx">Service Note List</a> <span class="separator"></span></li>
            <li>View Renwabale Energy User Request
                <asp:Label ID="lblPagename1" runat="server"></asp:Label></li>
        </ul>

        <div class="pageheader">
            <%--  <asp:Button ID="btnUpdate2" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="btnUpdate_Click"
                Style="position: relative; float: right; top: 31px;" />--%>
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>View Renwabale Energy User Request
                    <asp:Label ID="lblPagename2" runat="server"></asp:Label></h1>
            </div>
        </div>

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="row">
                    <div class="col-lg-8" style="width: 100%;">
                        <div class="widgetbox personal-information">
                            <div class="tabbedwidget tab-primary" style="min-height: 330px;">
                                <ul>
                                    <li><a href="#a-1" style="font-size: 14px;">Renwabale Energy User Request Information</a></li>
                                    <li><a href="#a-3" style="font-size: 14px;">Company Information </a></li>
                                    <li><a href="#a-2" style="font-size: 14px;">Attachments </a></li>
                                    <li><a href="#a-8" style="font-size: 14px;">Request Details </a></li>
                                    <li><a href="#a-4" style="font-size: 14px;" runat="server" id="li4" visible="false">Phase 1 Attahment </a></li>
                                    <li><a href="#a-5" style="font-size: 14px;" runat="server" id="li5" visible="false">Phase 2 Attahment </a></li>
                                    <li><a href="#a-6" style="font-size: 14px;">Workflow </a></li>
                                    <li><a href="#a-7" style="font-size: 14px;">Workflow Step Values </a></li>
                                </ul>
                                <br />
                                <div id="a-1" style="min-height: 283px;">


                                    <asp:HiddenField runat="server" ID="hdnServiceUserID" />
                                    <asp:HiddenField runat="server" ID="hdnGovernate" />
                                    <asp:HiddenField runat="server" ID="hdnArea" />
                                    <asp:HiddenField runat="server" ID="hdnArea2" />
                                    <asp:HiddenField runat="server" ID="hdnStreetID" />
                                    <asp:HiddenField runat="server" ID="hdnUSerEmailId" />

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Renwable Energy Type:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:RadioButtonList runat="server" ID="rblRenwableEnergyType" RepeatDirection="Horizontal" Enabled="False">
                                                <asp:ListItem Text="صغير صافي قياس" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="كبير صافي قياس" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="عبور" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>



                                    <div class="form-group" style="height: 42px" runat="server" visible="false" id="Type3AcceptDiv">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">IS Accepted :</label>
                                        <div class="col-md-10" style="width: 22%;">
                                            <asp:CheckBox ID="RequestType3IsAccepted" runat="server" Style="position: relative; top: 4px;" />
                                            <asp:HiddenField runat="server" ID="Type3Phase1DetailsID" />

                                        </div>
                                    </div>

                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Meter Status:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:RadioButtonList runat="server" ID="rblMeterStatus" RepeatDirection="Horizontal" Enabled="False">
                                                <asp:ListItem Text="عداد عامل" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="عداد جديد" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="مبنى قيد الانشاء" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Reference Number:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtCounter_refNo" runat="server" PlaceHolder=" رقم العداد" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">First Name:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtFirstName" runat="server" PlaceHolder="الاسم الاول" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Second Name:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtSecondName" runat="server" PlaceHolder="اسم الأب" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Third Name:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtThirdName" runat="server" PlaceHolder="اسم الجد" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Family Name:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtFamilyName" runat="server" PlaceHolder="اسم العائلة" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Telephone:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtUserTelephone" runat="server" PlaceHolder="هاتف" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Email:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtUserEmail" runat="server" PlaceHolder="بريد إلكتروني" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Accept Status Date:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <input id="txtStatusDate" runat="server" type="text" style="width: 273px;" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Company Aceepted Status:</label>
                                            <div class="col-md-10" style="width: 22%;">
                                                <asp:CheckBox ID="chkStatus" runat="server" Style="position: relative; top: 4px;" onclick="javascript: return false;" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">City:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtCity" runat="server" PlaceHolder="المحافظة" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Area 1:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtArea1" runat="server" PlaceHolder="المنطقة ١" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Area 2:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtArea2" runat="server" PlaceHolder="المنطقة ٢" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-sm-12">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Address :</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:TextBox ID="txtAddress" runat="server" PlaceHolder="اسم الشارع" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div id="a-3" style="min-height: 283px;">
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Company Name:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddlCompanyName" runat="server" class="chzn-select" TabIndex="2" Width="100%" disabled="disabled">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Mobile No:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="رقم هاتف الشركة " Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">National No:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtNationalNo" runat="server" PlaceHolder="الرقم الوطني للمنشأة " Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Email:</label>
                                        <div class="col-md-10" style="width: 22.9%;">
                                            <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="البريد الالكتروني " Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="height: 42px">
                                        <label class="col-md-4 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">قم بتحديد المفوض لهذا الطلب:</label>
                                        <div class="col-md-8" style="width: 22.9%;">
                                            <asp:DropDownList ID="ddlUSerType" runat="server" class="chzn-select" TabIndex="2" Width="100%" disabled="disabled">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="container" style="display: grid;">

                                        <asp:ListView ID="lstUSerData" runat="server" OnItemDataBound="lstUSerData_ItemDataBound">
                                            <LayoutTemplate>

                                                <table class="table-responsive table-bordered paddt">
                                                    <thead>
                                                        <tr>

                                                            <th>اسم المفوض</th>
                                                            <th>رقم الهاتف</th>
                                                            <th>البريد الالكتروني</th>
                                                            <th>هوية احوال مدنية</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="itemPlaceholder" runat="server"></tbody>
                                                </table>

                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <tr>

                                                    <td>
                                                       <%-- <asp:Image ID="imgProfileimge" runat="server" ImageUrl='<%# Bind("DocumentUploadPhoto") %>' />--%>
                                                        <asp:Literal runat="server" ID="lblname" Text='<%# Eval("FirstName") + " " + Eval("FatherName") + " " + Eval("FamilyName") %>'></asp:Literal></td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="lblTelePhone" Text='<%# Bind("MobileNo") %>'></asp:Literal></span></td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="lblEmail" Text='<%# Bind("EmailID") %>'></asp:Literal></span></td>
                                                    <td>
                                                        <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("DocumentUpload") %>' Target="_blank">                                  
                                                        </asp:HyperLink>

                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <h3>No Records!</h3>
                                            </EmptyDataTemplate>
                                        </asp:ListView>

                                    </div>
                                </div>
                                <div id="a-2" style="min-height: 283px;">
                                    <div class="row">

                                        <div class="form-group" style="height: 42px">

                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="lblguid" runat="server" PlaceHolder="" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>

                                                <%-- <asp:Label runat="server" ID="lblguid" class="col-md-10 control-label" Style="text-align: left; width: 15%; padding-left: 1.2%;"></asp:Label>
                                                --%>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">ارفاق هوية:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="lnkA1" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">تفويض الشركة:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="lnkA2" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مخطط أراضي:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="lnkA3" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">صورة سند قبض رسوم عداد جديد:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="lnkA4" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="display: none">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">Attachment 5 :</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="lnkA5" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="a-8" style="min-height: 283px;">
                                    <div class="row">

                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">قدرة النظام AC  (KW):</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtACVal" runat="server" PlaceHolder="ادخل قدرة النظام" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">قدرة النظام DC  (KW):</label>
                                            <div class="col-md-10" style="width: 22.9%;">
                                                <asp:TextBox ID="txtDCVal" runat="server" PlaceHolder="ادخل قدرة النظام" Style="width: 273px;" class="form-control" disabled="disabled"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">صورة مخطط أحادي:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="inkDetail1" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">دراسة تصميمية:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="inkDetail2" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">صورة مخطط أراضي:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="inkDetail3" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">
                                            <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">شهادة سلامة عامة للخلايا والعكس:</label>
                                            <div class="col-md-10">
                                                <asp:HyperLink runat="server" ID="inkDetail4" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-md-6 control-label" style="text-align: left; padding-left: 1.2%;">معلومات جهاز العكس:</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="container" style="display: grid;">
                                                <asp:ListView ID="lstdevice_information" runat="server" OnItemDataBound="lstdevice_information_ItemDataBound">
                                                    <LayoutTemplate>

                                                        <table class="table-responsive table-bordered paddt">
                                                            <thead>
                                                                <tr>

                                                                    <th>Device ID</th>
                                                                    <th>Device Name</th>
                                                                    <th>Device Power</th>
                                                                    <th>Number of Units</th>
                                                                    <th>Device Document</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="itemPlaceholder" runat="server"></tbody>
                                                        </table>

                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblDeviceID" Text='<%# Bind("DeviceID") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblDeviceName" Text='<%# Bind("DeviceName") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblDevicePower" Text='<%# Bind("DevicePower") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblNumberofUnits" Text='<%# Bind("NumberofUnits") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink runat="server" ID="lnkDeviceDocument" NavigateUrl='<%# Bind("DeviceDocument") %>' Target="_blank">                                  
                                                                </asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <h3>No Records!</h3>
                                                    </EmptyDataTemplate>
                                                </asp:ListView>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label class="col-md-6 control-label" style="text-align: left; padding-left: 1.2%;">معلومات الخلايا الشمسية:</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group" style="height: 42px">                                            
                                            <div class="container" style="display: grid;">
                                                <asp:ListView ID="lstSollerDevice" runat="server" OnItemDataBound="lstSollerDevice_ItemDataBound">
                                                    <LayoutTemplate>

                                                        <table class="table-responsive table-bordered paddt">
                                                            <thead>
                                                                <tr>

                                                                    <th>Sollar Cell ID</th>
                                                                    <th>Sollar Cell Name</th>
                                                                    <th>Sollar Cell Power</th>
                                                                    <th>Number of Units</th>
                                                                    <th>Device Document</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="itemPlaceholder" runat="server"></tbody>
                                                        </table>

                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblSollarCellID" Text='<%# Bind("SollarCellID") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblSollarCellName" Text='<%# Bind("SollarCellName") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblSollarCellPower" Text='<%# Bind("SollarCellPower") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal runat="server" ID="lblNumberofUnits" Text='<%# Bind("NumberofUnits") %>'></asp:Literal></span>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink runat="server" ID="lnkDeviceDocument" NavigateUrl='<%# Bind("SollarCellDocument") %>' Target="_blank">                                  
                                                                </asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <h3>No Records!</h3>
                                                    </EmptyDataTemplate>
                                                </asp:ListView>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="a-6" style="min-height: 283px;">
                                    <asp:UpdatePanel runat="server" ID="updt1">
                                        <ContentTemplate>
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Send To:</label>
                                                <div class="col-md-10" style="width: 22.9%;">
                                                    <asp:DropDownList ID="DDLWorkflowUser" runat="server" class="chzn-select" TabIndex="2" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="DDLWorkflowUser_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>



                                            <div runat="server" id="divNotes" style="display: none;">
                                                <div class="form-group" style="height: 42px">
                                                    <label class="col-md-2 control-label" style="text-align: left; width: 15%; padding-left: 1.2%;">Notes :</label>
                                                    <div class="col-md-10" style="width: 35.9%;">
                                                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" PlaceHolder="Notes" class="form-control"></asp:TextBox>
                                                    </div>
                                                    <%--<asp:Button ID="BtnSend" runat="server" Text="Send" class="btn btn-primary" ValidationGroup="1" OnClick="BtnSend_Click" />--%>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal" data-toggle="modal">Choose a file</a>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="widgetbox profile-photo" style="/*width: 39.5%; */ padding-left: 0px;">
                                                                <div class="profilethumb" id="logotransitions" style="min-height: 100px;">
                                                                    <asp:Image ID="ImagePage" runat="server" alt="" class="img-polaroid" Style="max-height: 100px; min-height: 100px; padding-top: 5px;" />
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
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal2" data-toggle="modal">Choose a file</a>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="widgetbox profile-photo" style="/*width: 39.5%; */ padding-left: 0px;">
                                                                <div class="profilethumb" id="logotransitions2" style="min-height: 100px;">
                                                                    <asp:Image ID="ImagePage2" runat="server" alt="" class="img-polaroid" Style="max-height: 100px; min-height: 100px; padding-top: 5px;" />
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
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal3" data-toggle="modal">Choose a file</a>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="widgetbox profile-photo" style="/*width: 39.5%; */ padding-left: 0px;">
                                                                <div class="profilethumb" id="logotransitions3" style="min-height: 100px;">
                                                                    <asp:Image ID="ImagePage3" runat="server" alt="" class="img-polaroid" Style="max-height: 100px; min-height: 100px; padding-top: 5px;" />
                                                                    <input runat="server" style="display: none" class="form-control input-lg" id="newWinField3" type="text">
                                                                </div>
                                                                <script>
                                                                    function fileBrowserCallBack3(fileurl) {
                                                                        $('#logotransitions3 > img').prop({ src: fileurl });
                                                                        $('#<%= newWinField3.ClientID %>').val(fileurl);
                                                                        $('#FileBrowserModal3').modal('hide');
                                                                    }
                                                                </script>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group" style="text-align: center; margin-right: 46%">
                                                    <asp:Button ID="BtnSend" runat="server" Text="Send" class="btn btn-primary" ValidationGroup="1" OnClick="BtnSend_Click" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="container" style="display: grid;">
                                                <asp:ListView ID="lstWorkflowHistory" OnItemDataBound="lstWorkflowHistory_ItemDataBound" runat="server">
                                                    <LayoutTemplate>

                                                        <table class="table-responsive table-bordered paddt">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 15%;">From User</th>
                                                                    <th style="width: 15%;">To User</th>
                                                                    <th style="width: 15%;">Date and Time</th>
                                                                    <th>Notes</th>
                                                                    <th style="width: 15%;">Attachment1</th>
                                                                    <th style="width: 15%;">Attachment 2</th>
                                                                    <th style="width: 15%;">Attachment 3</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="itemPlaceholder" runat="server"></tbody>
                                                        </table>

                                                    </LayoutTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="width: 15%;">
                                                                <asp:Label ID="lblFromUser" runat="server" Text='<%# Bind("From_User") %>'></asp:Label>
                                                            </td>
                                                            <td style="width: 15%;">
                                                                <asp:Label ID="lblToUser" runat="server" Text='<%# Bind("To_User") %>'></asp:Label>
                                                            </td>
                                                            <td style="width: 15%;"><%# Eval("Send_Date") %></td>
                                                            <td><%# Eval("Notes") %></td>
                                                            <td style="width: 15%;">
                                                                <asp:HyperLink runat="server" ID="Attachment" Target="_blank" NavigateUrl='<%# Eval("Attachment") %>'></asp:HyperLink></td>
                                                            <td style="width: 15%;">
                                                                <asp:HyperLink runat="server" ID="Attachment2" Target="_blank" NavigateUrl='<%# Eval("Attachment2") %>'></asp:HyperLink></td>
                                                            <td style="width: 15%;">
                                                                <asp:HyperLink runat="server" ID="Attachment3" Target="_blank" NavigateUrl='<%# Eval("Attachment3") %>'></asp:HyperLink></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <EmptyDataTemplate>
                                                        <h3>No Records!</h3>
                                                    </EmptyDataTemplate>
                                                </asp:ListView>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DDLWorkflowUser" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                                <div id="a-7" style="min-height: 283px;">
                                    <div class="row">
                                        <div style="margin-left: 1.5%;">
                                            <asp:RadioButtonList ID="RbtnUserReqSteps" runat="server"></asp:RadioButtonList>
                                        </div>
                                        <div style="margin-left: 1.5%; margin-top: 2%;">
                                            <asp:DropDownList ID="ddlstepstatus" runat="server" class="chzn-select" TabIndex="2" Width="30%">
                                            </asp:DropDownList>
                                        </div>
                                        <br />
                                        <div class="col-md-10" style="width: 35.9%;">
                                            <asp:TextBox ID="txtStepsNote" runat="server" TextMode="MultiLine" PlaceHolder="Notes" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="padding-top: 13px;">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal4" data-toggle="modal">Choose a file</a>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="widgetbox profile-photo" style="/*width: 39.5%; */ padding-left: 0px;">
                                                    <div class="profilethumb" id="logotransitions4" style="min-height: 100px;">
                                                        <asp:Image ID="Image1" runat="server" alt="" class="img-polaroid" Style="max-height: 100px; min-height: 100px; padding-top: 5px;" />
                                                        <input runat="server" style="display: none" class="form-control input-lg" id="newWinField4" type="text">
                                                    </div>
                                                    <script>
                                                        function fileBrowserCallBack4(fileurl) {
                                                            $('#logotransitions4 > img').prop({ src: fileurl });
                                                            $('#<%= newWinField4.ClientID %>').val(fileurl);
                                                            $('#FileBrowserModal4').modal('hide');
                                                        }
                                                    </script>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal5" data-toggle="modal">Choose a file</a>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="widgetbox profile-photo" style="/*width: 39.5%; */ padding-left: 0px;">
                                                    <div class="profilethumb" id="logotransitions5" style="min-height: 100px;">
                                                        <asp:Image ID="Image2" runat="server" alt="" class="img-polaroid" Style="max-height: 100px; min-height: 100px; padding-top: 5px;" />
                                                        <input runat="server" style="display: none" class="form-control input-lg" id="newWinField5" type="text">
                                                    </div>
                                                    <script>
                                                        function fileBrowserCallBack5(fileurl) {
                                                            $('#logotransitions5 > img').prop({ src: fileurl });
                                                            $('#<%= newWinField5.ClientID %>').val(fileurl);
                                                            $('#FileBrowserModal5').modal('hide');
                                                        }
                                                    </script>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <a class="btn btn-primary btn-lg" style="color: white" href="#FileBrowserModal6" data-toggle="modal">Choose a file</a>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="widgetbox profile-photo" style="/*width: 39.5%; */ padding-left: 0px;">
                                                    <div class="profilethumb" id="logotransitions6" style="min-height: 100px;">
                                                        <asp:Image ID="Image3" runat="server" alt="" class="img-polaroid" Style="max-height: 100px; min-height: 100px; padding-top: 5px;" />
                                                        <input runat="server" style="display: none" class="form-control input-lg" id="newWinField6" type="text">
                                                    </div>
                                                    <script>
                                                        function fileBrowserCallBack6(fileurl) {
                                                            $('#logotransitions6 > img').prop({ src: fileurl });
                                                            $('#<%= newWinField6.ClientID %>').val(fileurl);
                                                            $('#FileBrowserModal6').modal('hide');
                                                        }
                                                    </script>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row" style="text-align: center;">
                                        <div class="col-md-6">
                                            <asp:Button ID="BtnStepSave" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="BtnStepSave_Click" />
                                        </div>
                                    </div>
                                    <br />
                                    <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
                                    <div class="container" style="display: grid;">
                                        <asp:ListView ID="lstStepsValue" OnItemDataBound="lstStepsValue_ItemDataBound" OnItemCommand="lstStepsValue_ItemCommand" runat="server">
                                            <LayoutTemplate>

                                                <table class="table-responsive table-bordered paddt">
                                                    <thead>
                                                        <tr>
                                                            <%--<th>Request ID</th>--%>
                                                            <th>Step ID</th>
                                                            <th>Step Name</th>
                                                            <th>Date and Time</th>
                                                            <th>Notes</th>
                                                            <th>Step Status</th>
                                                            <th>Add By</th>
                                                            <th>Comp. Date</th>
                                                            <th>Attachment1</th>
                                                            <th>Attachment 2</th>
                                                            <th>Attachment 3</th>
                                                            <th>Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="itemPlaceholder" runat="server"></tbody>
                                                </table>

                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <%--  <td>
                                                        <asp:Label ID="lblFromUser1" runat="server" Text='<%# Bind("RequestID") %>'></asp:Label>
                                                    </td>--%>
                                                    <td>
                                                        <asp:Label ID="lblToUser1" runat="server" Text='<%# Bind("RequestUserStepID") %>'></asp:Label>
                                                    </td>
                                                    <td><%# Eval("StepName") %></td>
                                                    <td>
                                                        <asp:Label ID="lblAddDate" runat="server" Text=' <%# Eval("Adddate") %>'></asp:Label>
                                                        <asp:HiddenField runat="server" ID="hndadduser" Value='<%# Eval("AddUser") %>' />
                                                    </td>
                                                    <td><%# Eval("StepNotes") %></td>
                                                    <td>
                                                        <asp:Label ID="lblStepStatus" runat="server" Text='<%# Eval("StepStatus")%>'></asp:Label></td>
                                                    <td><%# Eval("AddUserName") %></td>
                                                    <td>
                                                        <asp:Label ID="lblCompletedDate" runat="server" Text=' <%# Eval("CompletedDate") %>' Visible='<%# Convert.ToString(Eval("StepStatus")) == "Done"? true:false %>'></asp:Label>
                                                    <td>
                                                        <asp:HyperLink runat="server" ID="Attachment" Target="_blank" NavigateUrl='<%# Eval("Attachment") %>'></asp:HyperLink></td>
                                                    <td>
                                                        <asp:HyperLink runat="server" ID="Attachment2" Target="_blank" NavigateUrl='<%# Eval("Attachment2") %>'></asp:HyperLink></td>
                                                    <td>
                                                        <asp:HyperLink runat="server" ID="Attachment3" Target="_blank" NavigateUrl='<%# Eval("Attachment3") %>'></asp:HyperLink></td>
                                                    <td style="text-align: center">
                                                        <%--<asp:Button ID="btneditStep" runat="server" CommandName="ViewEdit" CommandArgument='<%# Eval("ID") %>' Text="Save" class="btn btn-primary" />--%>
                                                        <asp:LinkButton ID="btneditStep" runat="server" CommandName="ViewEdit" CommandArgument='<%# Eval("ID") %>' ToolTip="View User Request" Enabled="false">
                                        <span class="glyphicon iconsweets-create"></span>
                                                        </asp:LinkButton>

                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <h3>No Records!</h3>
                                            </EmptyDataTemplate>
                                        </asp:ListView>

                                    </div>
                                    <%--  </contenttemplate>
                                        <triggers>
                                            <asp:asyncpostbacktrigger controlid="lststepsvalue" EventName="ItemCommand"/>
                                        </triggers>
                                    </asp:updatepanel>--%>
                                </div>

                                <div id="a-4" style="min-height: 283px;">

                                    <div runat="server" id="Phase1AttechmentDiv" visible="false">
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 1 :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt1" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 2 :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt2" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 3  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt3" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 4 :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt4" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 5  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt5" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 6  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt6" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 7  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt7" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 8  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt8" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 9  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt9" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 10  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase1Attachemnt10" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                                <div id="a-5" style="min-height: 283px;">

                                    <div runat="server" id="Phase2AttechmentDiv" visible="false">
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 1  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt1" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 2 :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt2" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 3  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt3" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 4 :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt4" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 5  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt5" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 6  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt6" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 7  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt7" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 8  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt8" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 9  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt9" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group" style="height: 42px">
                                                <label class="col-md-2 control-label" style="text-align: left; width: 11%; padding-left: 1.2%;">مرفق 10  :</label>
                                                <div class="col-md-10">
                                                    <asp:HyperLink runat="server" ID="Phase2Attachemnt10" Target="_blank"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                </div>



                            </div>
                        </div>
                        <br />
                        <div runat="server" id="divUpdatebtn" visible="false">
                            <p style="text-align: right;">
                                <asp:Button ID="btnUpdate" runat="server" Text="Save" class="btn btn-primary" ValidationGroup="1" OnClick="btnUpdate_Click" />
                            </p>
                        </div>

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
            <div id="popup_message" style="text-align: center;">Request information Update Sucessfully</div>
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

    <div id="popup_container1" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 300px; max-width: 300px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title">Workflow Request Value Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">Request step's value saved Sucessfully</div>
            <div id="popup_panel">
                <asp:Button ID="btnOk1" runat="server" Text="Ok" OnClick="btnOk1_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeSuccess1" runat="server"
        TargetControlID="lblpopup1"
        BehaviorID="mpeSuccess1"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container1">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup1"></asp:Label>

    <div id="popup_container2" class="ui-draggable" style="display: none; position: fixed; z-index: 99999; padding: 0px; margin: 0px; min-width: 500px; max-width: 500px; top: 35.5px; left: 524.5px;">
        <h1 style="cursor: move;" id="popup_title2">Edit Workflow Request Value</h1>
        <div class="alert" id="popup_content2">

            <div class="maincontent">
                <div class="maincontentinner">
                    <div class="row">
                        <div class="col-lg-8" style="width: 100%;">
                            <div class="widgetbox personal-information">
                                <div class="" style="min-height: 105px;">
                                    <div class="row" style="display: none;">
                                        <div style="margin-left: 5.5%; margin-top: 2%;">
                                            <asp:RadioButtonList ID="RbtnUserReqSteps1" runat="server"></asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10" style="margin-left: 5.5%; margin-top: 1.5%; margin-bottom: 1.5%; width: 100%;">
                                            <asp:DropDownList ID="ddlstepstatus1" runat="server" class="chzn-select" TabIndex="2" Width="200%">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-10" style="margin-left: 5.5%; margin-bottom: 1.5%;">
                                            <asp:TextBox ID="txtStepsNote1" runat="server" TextMode="MultiLine" PlaceHolder="Notes" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="popup_panel2">
                <asp:Button ID="BtnEditSave" runat="server" Text="Update" OnClick="BtnEditSave_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeStepedit" runat="server" CancelControlID="btncancel"
        TargetControlID="lblpopup2"
        BehaviorID="mpeStepedit"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container2">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup2"></asp:Label>

    <script>
        $("document").ready(function () {
            $('#<%=DDLWorkflowUser.ClientID%>').addClass("chzn-select");
            $('#<%=DDLWorkflowUser.ClientID%>').on("click", function () {
                $(this).removeClass("chzn-select").addClass("chzn-select");
            });
        });
    </script>
</asp:Content>
