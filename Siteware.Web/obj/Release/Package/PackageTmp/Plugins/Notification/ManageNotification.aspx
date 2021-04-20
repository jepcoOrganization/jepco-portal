<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="ManageNotification.aspx.cs" Inherits="Siteware.Web.Plugins.Notification.ManageNotification" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../AppTheme/ScriptDataTable/datatables.min.css" rel="stylesheet" />
    <link href="../../AppTheme/css/style.navyblue.css" rel="stylesheet" />
    <script src="../../AppTheme/Script/prettify/prettify.js"></script>
    <script src="../../AppTheme/Script/jquery.dataTables.min.js"></script>
    <style>
        #lang-search {
            margin: 10px;
            padding: 7px;
        }

        div.dataTables_wrapper div.dataTables_info {
            padding-top: 50px !Important;
            white-space: nowrap;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="rightpanel">
        <ul class="breadcrumbs">
            <li><a href="<%= ResolveUrl("~/")%>Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li>Notification</li>
        </ul>

        <div class="pageheader">
            <div>
                <asp:LinkButton ID="BtnDelete2" runat="server" class="btn btn-primary" Text="Delete Notification" OnClick="Delete_Click"
                    Style="position: relative; float: right; top: 31px; color: white">
                    <span class="glyphicon glyphicon-remove" style="color:white;padding-right: 4%;"></span> Delete Notification
                </asp:LinkButton>
                <%--       <asp:LinkButton ID="BtnPDF2" runat="server" class="btn btn-danger" Text="Export to PDF"
                    Style="position: relative; float: right; top: 31px; right: 0.5%; color: white">
                    <span class="glyphicon glyphicon-file" style="color:white;padding-right: 4%;"></span> Export to PDF
                </asp:LinkButton>
                <asp:LinkButton ID="btnExcelSheet2" runat="server" class="btn btn-success" Text="Export to Excel"
                    Style="position: relative; float: right; top: 31px; right: 1%; color: white">
                    <span class="glyphicon glyphicon-file" style="color:white;padding-right: 4%;"></span> Export to Excel
                </asp:LinkButton>--%>
                <asp:LinkButton ID="btnAdd2" runat="server" class="btn btn-primary" Text="Add Notification" OnClick="btnAdd_Click"
                    Style="position: relative; float: right; top: 31px; right: 0.5%; color: white">
                    <span class="glyphicon glyphicon-plus" style="color:white;padding-right: 4%;"></span> Add Notification
                </asp:LinkButton>
            </div>
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Notification List</h1>
            </div>
        </div>
        <div class="maincontent">
            <div class="maincontentinner">
                <h4 class="widgettitle">Data Table</h4>
                <div class="wrapper wrapper-content animated fadeInRight">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="ibox float-e-margins">
                                <div class="ibox-title">
                                    <div class="ibox-tools">
                                        <a class="collapse-link">
                                            <i class="fa fa-chevron-up"></i>
                                        </a>
                                        <a class="dropdown-toggle" data-toggle="dropdown" href="table_data_tables.html#">
                                            <i class="fa fa-wrench"></i>
                                        </a>
                                        <ul class="dropdown-menu dropdown-user">
                                            <li><a href="table_data_tables.html#">Config option 1</a>
                                            </li>
                                            <li><a href="table_data_tables.html#">Config option 2</a>
                                            </li>
                                        </ul>
                                        <a class="close-link">
                                            <i class="fa fa-times"></i>
                                        </a>
                                    </div>
                                </div>
                                <div class="ibox-content">
                                    <div class="table-responsive">
                                        <table id="mytbl" class="table table-striped table-bordered table-hover dataTables-example">
                                            <colgroup>
                                                <col class="con0" style="text-align: center; width: 4%" />
                                                <col class="con1" />
                                                <col class="con2" />
                                                <col class="con3" />
                                                <col class="con4" />
                                                <col class="con5" />
                                            </colgroup>
                                            <thead>
                                                <tr>
                                                    <th class="head0 nosort">
                                                        <input type="checkbox" class="checkall" id="selectAll" /></th>
                                                    <th class="head1">ID</th>
                                                    <th class="head2">Title</th>
                                                    <th class="head3">Language</th>
                                                    <th class="head4">Target</th>
                                                    <th class="head5">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:ListView ID="lstPages" runat="server" OnItemDataBound="lstPages_ItemDataBound" OnItemCommand="lstPages_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="gradeX">
                                                            <td class="aligncenter">
                                                                <span class="center">
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPageID" runat="server" Text='<%# Bind("NotificationID") %>'></asp:Label>
                                                            </td>
                                                            <td class="center">
                                                                <asp:Label ID="lblPageName" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                                            </td>
                                                            <td class="center">
                                                                <asp:Label ID="lblLang" runat="server" Text='<%# Bind("LanguageName") %>'></asp:Label>
                                                            </td>
                                                            <td class="center">
                                                                <asp:Label ID="lblTarget" runat="server" Text='<%# Bind("Target") %>'></asp:Label>
                                                            </td>
                                                            <%--  <td class="center">
                                    <asp:Label ID="lblIsDeleted" runat="server" ></asp:Label>
                                </td>--%>
                                                            <%-- <td>
                                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                                                            </td>--%>
                                                            <td class="center">&nbsp;
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="ViewEdit" CommandArgument='<%# Eval("NotificationID") %>' ToolTip="Edit Notification">
                                        <span class="glyphicon iconsweets-create"></span>
                                    </asp:LinkButton>
                                                                &nbsp;
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("NotificationID") %>' ToolTip="Delete Notification">
                                        <span class="glyphicon glyphicon-remove ColorDelete" style="position: relative;top: 3px;"></span>
                                    </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
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
        <h1 style="cursor: move;" id="popup_title">Delete Status</h1>
        <div class="alert" id="popup_content">
            <div id="popup_message" style="text-align: center;">Are you sure to Delete Item</div>
            <div id="popup_panel">
                <asp:Button ID="btnOk11" runat="server" Text="Ok" OnClick="btnOk_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
                <asp:Button ID="butCancel" runat="server" Text="Cancel" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeSuccess" runat="server" CancelControlID="butCancel"
        TargetControlID="lblpopup"
        BehaviorID="mpeSuccess"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup"></asp:Label>


    <script src="../../AppTheme/ScriptDataTablejquery-2.1.1.js"></script>
    <%--<script src="../../AppTheme/ScriptDataTable/bootstrap.min.js"></script>--%>
    <script src="../../AppTheme/ScriptDataTable/jquery.metisMenu.js"></script>
    <script src="../../AppTheme/ScriptDataTable/jquery.slimscroll.min.js"></script>
    <script src="../../AppTheme/ScriptDataTable/datatables.min.js"></script>
    <script src="../../AppTheme/ScriptDataTable/inspinia.js"></script>
    <script src="../../AppTheme/ScriptDataTable/pace.min.js"></script>
    <script>
        $('#selectAll').click(function (e) {
            var table = $(e.target).closest('table');
            $('td input:checkbox', table).prop('checked', this.checked);
        });

        $(document).ready(function () {

            var table = $('.dataTables-example').DataTable({
                pageLength: 10,
                responsive: true,
                select: true,
                dom: '<"html5buttons"B>lTfgitp',
                buttons: [
                    //{ extend: 'copy' },
                    //{ extend: 'csv' },
                    { extend: 'excel', title: 'Logo', text: '<span class="glyphicon glyphicon-file" style="color:white;padding-right: 4%;"></span> Export to Excel', className: 'btn btn-success btn-Excel', titleAttr: 'Excel' },
                    { extend: 'pdf', title: 'Logo', text: '<span class="glyphicon glyphicon-file" style="color:white;padding-right: 4%;"></span> Export to PDF', className: 'btn btn-success btn-PDF', titleAttr: 'PDF' },
                    {
                        extend: 'print', title: 'Logo', text: '<span class="glyphicon glyphicon-file" style="color:white;padding-right: 4%;"></span> Print', className: 'btn btn-success btn-Print', titleAttr: 'Print',
                        customize: function (win) {
                            $(win.document.body).addClass('white-bg');
                            $(win.document.body).css('font-size', '10px');

                            $(win.document.body).find('table')
                                .addClass('compact')
                                .css('font-size', 'inherit');
                        }
                    }
                ]

            });
            
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "ManageNotification.aspx/BindDatatoDropdown",
                data: "{}",
                dataType: "json",
                async: true,
                success: function (data) {
                     
                    $('<lable class="pull-right">Select Language:' +
                   '<select id="lang-search" class="class=form-control input-sm"">' +                   
                   '</select>' +
                   '</lable>').appendTo("#mytbl_wrapper .dataTables_filter");

                    $.each(data.d, function (key, value) {
                        $("#lang-search").append($("<option></option>").html(value.LangName));
                    });

                    var selectedVal = $("#lang-search").val();
                    table.columns('.head3').search(selectedVal).draw();

                    $('#lang-search').on('change', function () {
                        table.columns('.head3').search(this.value).draw();
                    });
                },
                error: function (result) {
                    alert("Error");
                }
            });

            $(".dataTables_filter label").addClass("pull-right");
            
        });
    </script>
</asp:Content>
