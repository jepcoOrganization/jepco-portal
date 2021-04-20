<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageSubmitCV.aspx.cs" Inherits="Siteware.Web.Plugins.SubmitCV.ManageSubmitCV" Async="true" %>
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
            <li>Plugins<span class="separator"></span></li>
            <li>Submited CV List</li>
        </ul>

        <div class="pageheader">
            <div>
               
            </div>
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>
                    <asp:Label ID="lblHeaderName" runat="server">Siteware</asp:Label>
                </h5>
                <h1>Submited CV List</h1>
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
                                                <col class="con6" />
                                                <col class="con7" />
                                            </colgroup>
                                            <thead>
                                                <tr>
                                                    <th class="head0">
                                                        <input type="checkbox" class="checkall" id="selectAll" />
                                                    </th>
                                                    <th class="head1">CV ID</th>
                                                    <th class="head2">Name</th>
                                                      <th class="head3">Email</th>
                                                    <th class="head5">Order</th>
                                                    <th class="head6">Publish Date</th>
                                                    <th class="head9">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:ListView ID="lstdata" runat="server" OnItemDataBound="lstdata_ItemDataBound" OnItemCommand="lstdata_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="gradeX">
                                                            <td class="aligncenter">
                                                                <span class="center">
                                                                    <asp:CheckBox ID="CBID" runat="server" />
                                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("SubmitCVID") %>' Visible="false"></asp:Label>
                                                                </span>
                                                            </td>
                                                             <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SubmitCVID") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblNewsID" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblHeadline" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                                            </td>
                                                           
                                                           
                                                            <td class="center">
                                                                <asp:Label ID="lblNewsOrder" runat="server" Text='<%# Bind("Order") %>'></asp:Label>
                                                            </td>
                                                            <td class="center">
                                                                <asp:Label ID="lblPublishDate" runat="server" Text='<%# Bind("PublishedDate") %>'></asp:Label>
                                                            </td>
                                                            
                                                           

                                                            <td class="center">&nbsp;
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="ViewEdit" CommandArgument='<%# Eval("SubmitCVID") %>' ToolTip="Edit New">
                                        <span class="glyphicon iconsweets-create"></span>
                                    </asp:LinkButton>
                                                             <%--   &nbsp;
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("NewsID") %>' ToolTip="Delete Page">
                                        <span class="glyphicon glyphicon-remove ColorDelete" style="position: relative;top: 3px;"></span>
                                    </asp:LinkButton>--%>
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
                <%--<asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />--%>
                <asp:Button ID="ButCancel" runat="server" Text="Cancel" Style="color: #3b6c8e; border: 2px solid #3b6c8e; padding: 7px 0; background: #fff;" />
            </div>

        </div>

    </div>
    <cc1:ModalPopupExtender ID="mpeSuccess" runat="server" CancelControlID="ButCancel"
        TargetControlID="lblpopup"
        BehaviorID="mpeSuccess"
        BackgroundCssClass="modalBackground"
        PopupControlID="popup_container">
    </cc1:ModalPopupExtender>
    <asp:Label runat="server" ID="lblpopup"></asp:Label>
    <%--<script src='<%= ResolveUrl("~/AppTheme/ScriptDataTable/jquery-2.1.1.js") %>' type="text/javascript"></script>--%>

    <%--<script src="../../AppTheme/ScriptDataTablejquery-2.1.1.js"></script>--%>
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

          
            //$.ajax({
            //    type: "POST",
            //    contentType: "application/json; charset=utf-8",
            //    url: "ManageNews.aspx/BindDatatoDropdown",
            //    data: "{}",
            //    dataType: "json",
            //    async: true,
            //    success: function (data) {

            //        $('<lable class="pull-right">Select Language:' +
            //            '<select id="lang-search" class="class=form-control input-sm"">' +
            //            '</select>' +
            //            '</lable>').appendTo("#mytbl_wrapper .dataTables_filter");

            //        $.each(data.d, function (key, value) {
            //            $("#lang-search").append($("<option></option>").html(value.LangName));
            //        });

            //        var selectedVal = $("#lang-search").val();
            //        table.columns('.head4').search(selectedVal).draw();

            //        $('#lang-search').on('change', function () {
            //            table.columns('.head4').search(this.value).draw();
            //        });
            //    },
            //    error: function (result) {
            //        alert("Error");
            //    }
            //});

            $(".dataTables_filter label").addClass("pull-right");

        });
    </script>
</asp:Content>
