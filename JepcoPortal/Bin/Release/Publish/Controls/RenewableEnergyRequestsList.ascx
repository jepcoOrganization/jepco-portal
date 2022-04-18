<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyRequestsList.ascx.cs" Inherits="Controls_RenewableEnergyRequestsList" %>
<div class="average_energy">
    <%--<aside>
        <h1>قائمة المفوضين<small>عدد المفوضين :
            <asp:Literal runat="server" ID="lblTotalCount"></asp:Literal></small>
        </h1>
        <a href="/ar/Home/RenewableEnergyCompanyUserAdd">اضافة مفوض جديد</a>
    </aside>--%>
    <div class="detil_counter_rowone">
                <div class="newcounterBox ReportMess1" style="display:none">
                    <a href="/ar/Home/RenewableEnergyCompanySolarCellList">
                    <p>الخلايا الشمسية<img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/solar-cell.png" alt=""></p>                     
                    </a>
                </div>
                <div class="newcounterBox ReportMess1" style="display:none">
                    <a href="/ar/Home/RenewableEnergyCompanyDeviceList">
                    <p>أجهزة العكس<img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/solar-Panel.png" alt=""></p>
                    </a>
                </div>
                <div class="newcounterBox newcounter2" >
                     <a href="/ar/Home/RenewableEnergyRequestsList/RenewableEnergyCompanyUserList">
                    <p>المفوضون<img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/team.png" class="teamImg" alt=""></p>
                    </a>                   
                </div>
            </div>
    <div class="billlist">
        <div class="top-cart-detail">
            <div class="detil_counter_rowone">
                <div class="newcounterBox ReportMess1">
                    <p>عدد الطلبات المستلمة</p>
                    <label class="LTR" id="lblUnpaidAmount115588">
                        <asp:Literal runat="server" ID="lblTotalCount">0</asp:Literal></label>
                </div>
                <div class="newcounterBox ReportMess2">
                    <p>عدد الطلبات المشغلة</p>
                    <label class="LTR" id="lblUnpaidAmount1199">
                        <asp:Literal runat="server" ID="lblAppoverCount">0</asp:Literal></label>
                </div>
                <div class="newcounterBox newcounter2">
                    <p>عدد الطلبات قيد الاجراء</p>
                    <%--  <asp:Label runat="server" ID="lblReversingCount"></asp:Label>--%>
                    <label class="LTR" id="lblUnpaidAmount77">
                        <asp:Literal runat="server" ID="lblReversingCount">0</asp:Literal></label>
                </div>
            </div>
            <ul class="list-unstyled">
                 <asp:ListView runat="server" ID="lstUserRequstdevice" OnItemDataBound="lstUserRequstdevice_itemdatabound" OnPagePropertiesChanging="lstnewsrow_pagepropertieschanging" ItemPlaceholderID="itemplaceholder1" GroupPlaceholderID="groupplaceholder1" OnItemCommand="lstUserRequstdevice_ItemCommand">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="groupplaceholder1"></asp:PlaceHolder>
                    <asp:DataPager ID="datapager1" runat="server" PagedControlID="lstUserRequstdevice" class="pagination">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="link" ShowFirstPageButton="false"
                                ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<i class='fa fa-angle-right' aria-hidden='true'></i>" ButtonCssClass="prev" />
                            <asp:NumericPagerField ButtonType="link" CurrentPageLabelCssClass="active num" Visible="true" NumericButtonCssClass="num" NextPreviousButtonCssClass="num" />
                            <asp:NextPreviousPagerField ButtonType="link" ShowLastPageButton="false"
                                ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="<i class='fa fa-angle-left' aria-hidden='true'></i>" ButtonCssClass="next" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>
                <ItemTemplate>
                    <li class="clscls">
                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>تاريخ الطلب</h4>
                                <asp:Label runat="server" ID="lblPublishDate" Text='<%# Bind("PublishDate") %>'></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnRenwableID" Value='<%# Bind("RenwableEnergyID") %>' />
                                <asp:HiddenField runat="server" ID="hdnRenwableEnergyTypeID" Value='<%# Bind("RenwableEnergyTypeID") %>' />
                                <asp:HiddenField runat="server" ID="hdnDetailsID" /> 
                                <%--<span></span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>اسم صاحب الطلب</h4>
                                <%--<asp:Label runat="server" ID="lblCompany" Text='<%# Bind("CompanyID") %>'></asp:Label>--%>
                                 <asp:Label runat="server" ID="lblAddUser" Text='<%# Bind("AddUser") %>'></asp:Label>
                                <%--  <span>الموديل</span>--%>
                            </div>

                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>نوع الطلب</h4>
                                <asp:Label runat="server" ID="ReqType"></asp:Label>
                               
                            </div>

                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>رقم العداد\رقم الطلب</h4>
                                <asp:Label runat="server" ID="lblDevice" Text='<%# Bind("ReferenceNumber") %>'></asp:Label>
                                <%--  <span>256 PM</span>--%>
                            </div>
                           <%-- <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>رقم الهاتف</h4>
                                <asp:Label runat="server" ID="lblTelePhone"></asp:Label>
                               
                            </div>--%>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>رقم المرجعي للطلب</h4>
                                <asp:Label runat="server" ID="lblTokenNo"></asp:Label>
                                <%-- <span>C1</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-1"> 
                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("RenwableEnergyID") %>' class="GoFileDetails">
                                        التفاصيل
                                </asp:LinkButton>
                                 <asp:LinkButton ID="lnkDetilsAfterdata" runat="server" CommandName="ViewDetailsAfterData"  class="GoFileDetails" style="display:none">
                                        التفاصيل
                                </asp:LinkButton>

                                <asp:LinkButton ID="lnkPhase2" runat="server" CommandName="ViewPhase2"  class="GoFileDetails" style="display:none">
                                       Phase 2
                                </asp:LinkButton>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
                <GroupTemplate>
                    <asp:PlaceHolder runat="server" ID="itemplaceholder1"></asp:PlaceHolder>
                </GroupTemplate>
            </asp:ListView>
            </ul>
        </div>

    </div>
</div>


<style>

    
     .ReportMess label {
        color: white;
    }

    .newcounter label {
        color: white;
    }

    .ReportMess1 p, .newcounter2 p {
        font-size: 22px;
    }

    .ReportMess1 {
        background: #007fc3;
    }

    .billlist .ReportMess1 {
        background: #71a4c5;
    }

    .billlist .ReportMess2 {
        background: #4db6c9;
    }
    
    .newcounter2 {
        background: #007fc3;
    }

   .billlist .newcounter2 {
        background: #e4545d;
    }

    p.counter_new1 {
        display: inline-block;
    }

    .newcounter4 {
        background: #007fc3;
        text-align: right;
        float: right;
        width: 31%;
        align-items: center;
        padding: 20px;
    }

        .newcounter4 p {
            margin-bottom: 0;
        }

            .newcounter4 p strong {
                color: white;
                font-size: 18px;
            }

            .newcounter4 p span {
                color: #4db6c9;
                font-size: 18px;
            }


    .newcounterBox {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 34px 40px;
        width: 31%;
        position: relative;
    }
    img.teamImg {
    position: absolute;
    left: 12px;
    top: 8px;
}

        .newcounterBox p {
            color: #fff;
            font-size: 18px;
            font-weight: bold;
            margin: 0;
            white-space: pre-line;
        }

        .newcounterBox label {
            font-size: 30px;
            color: white;
        }



    a.GoFileDetails {
        background: #007fc3;
        color: #fff;
        font-size: 18px;
        font-weight: bold;
        min-width: 100px;
        text-align: center;
        line-height: 40px;
        display: inline-block;
        align-self: center;
    }




    .pagination {
        text-align: right;
        margin-top: 15px;
    }

        .pagination span {
            font-size: 26px;
            color: #a8a8a8;
            display: inline-block;
            padding: 0px 15px;
        }

            .pagination span:first-child,
            .pagination span:last-child {
                padding: 0;
            }

            .pagination span i {
                font-size: 48px;
                color: #007fc3;
                vertical-align: sub;
                cursor: pointer;
            }

            .pagination span.active {
                background: #007fc3;
                color: #fff;
                margin: 0px 15px;
            }

        .pagination a.prev i, .pagination a.next i {
            font-size: 48px;
            color: #007fc3;
            vertical-align: sub;
            cursor: pointer;
        }

    .pagination {
        display: block;
    }

        .pagination a.num {
            font-size: 26px;
            color: #a8a8a8;
            display: inline-block;
            margin: 0px 15px;
        }

    .average_energy a {
        color: white
    }
      .newcounterBox p img{
            margin-right: 20px;
    }

      span#ContentPlaceHolder1_ctl00_lstUserRequstdevice_datapager1 {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: row-reverse;
}


</style>
