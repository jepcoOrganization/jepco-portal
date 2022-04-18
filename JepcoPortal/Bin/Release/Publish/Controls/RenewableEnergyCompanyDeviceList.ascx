<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyCompanyDeviceList.ascx.cs" Inherits="Controls_RenewableEnergyCompanyDeviceList" %>

<div class="top-cart-detail">
    <div class="row">
        <div class="col-md-10 col-sm-10">
            <h5><strong>أجهزة العكس
            </strong></h5>
        </div>
        <div class="col-md-2 pull-right text-right"><a href="/ar/Home/RenewableEnergyCompanyDeviceList/RenewableEnergyCompanyDeviceAdd">اضافة جهاز عكس جديد</a></div>
    </div>
    <div class="row">
    </div>
    <div class="detil_counter_rowone">
        <div class="newcounterBox ReportMess2">
            <p>عدد أجهزة العكس </p>

            <label id="lblUnpaidAmount1155">
                <asp:Label runat="server" ID="lblTotalCount" class="LTR"></asp:Label></label>

        </div>
        <div class="newcounterBox ReportMess1">
            <p>أجهزة العكس المستخدمة</p>

            <label id="lblUnpaidAmount11">
                <asp:Label runat="server" ID="lblAppoverCount" class="LTR"></asp:Label></label>


        </div>

        <div class="newcounterBox newcounter2">
            <p>أجهزة عكس تحت التجربة</p>

            <%--  <asp:Label runat="server" ID="lblReversingCount"></asp:Label>--%>
            <label id="lblUnpaidAmount">
                <asp:Label runat="server" ID="lblReversingCount" class="LTR"></asp:Label></label>


        </div>

    </div>

    <div class="billlist">

        <ul class="list-unstyled">


            <asp:ListView runat="server" ID="lstCompanyDevice" OnItemDataBound="lstCompanyDevice_ItemDataBound" OnPagePropertiesChanging="lstNewsRow_PagePropertiesChanging" ItemPlaceholderID="itemPlaceHolder1" GroupPlaceholderID="groupPlaceHolder1">

                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstCompanyDevice" class="pagination">

                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false"
                                ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<i class='fa fa-angle-right' aria-hidden='true'></i>" ButtonCssClass="prev" />
                            <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="active num" Visible="true" NumericButtonCssClass="num" NextPreviousButtonCssClass="num" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false"
                                ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="<i class='fa fa-angle-left' aria-hidden='true'></i>" ButtonCssClass="next" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>



                <ItemTemplate>
                    <li class="clscls">
                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>الشركة المصنعة</h4>
                                <asp:Label runat="server" ID="lblCompayname" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                <%--<span></span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-1">
                                <h4>الموديل</h4>

                                <asp:Label runat="server" ID="lblModel" Text='<%# Bind("ModelNo") %>'></asp:Label>
                                <%--  <span>الموديل</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>قدرة الجهاز </h4>
                                <asp:Label runat="server" ID="lblDevice" Text='<%# Bind("DevicePower") %>'></asp:Label>
                                <%--  <span>256 PM</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>بلد المنشأ</h4>
                                <asp:Label runat="server" ID="lblOrigin" Text='<%# Bind("CountryOfOrigin") %>'></asp:Label>
                                <%-- <span>C1</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>معلومات الجهاز</h4>

                                <asp:HyperLink runat="server" ID="lnkSecondNav2" NavigateUrl='<%# Bind("DeviceDocument") %>' Target="_blank">
                                <span>معلومات الجهاز</span>
                                </asp:HyperLink>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-1">
                                <%--<a href=""></a>--%>
                                <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("DeviceDocument") %>' Target="_blank">
                                   <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="" class="pdfimg">
                                </asp:HyperLink>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <asp:HiddenField runat="server" ID="hdnstatusRecord" Value='<%# Bind("Status") %>' />




                                <div id="divIsIsApproved" runat="server">
                                    <div id="ContentPlaceHolder1_ctl00_lstComplain_Statusbtnid_0" class="Cmpdetailsbtndiv1" style="background: #f9db32; color: #007fc3; border: none; text-align: center;">
                                        <a>موافق عليه</a>
                                    </div>
                                </div>




                                <div id="divIsUnderTest" runat="server">
                                    <div id="ContentPlaceHolder1_ctl00_lstComplain_Statusbtnid_1" class="Cmpdetailsbtndiv2" style="background: #e46a6a; color: #FFF; border: none; text-align: center;">
                                        <a> قيد التجربة</a>
                                    </div>
                                </div>




                            </div>

                        </div>
                    </li>
                </ItemTemplate>

                <GroupTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                </GroupTemplate>
            </asp:ListView>


        </ul>

    </div>

</div>


<style>
    .newcounter1 {
        background: #007fc3;
    }

        .newcounter1 p {
            font-size: 10px;
            color: #4db6c9;
        }

        .newcounter1 label {
            font-size: 10px;
            color: white;
        }

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
        background: #4db6c9;
    }

    .ReportMess2 {
        background: #007fc3;
    }

    .newcounter2 {
        background: #e46a6a;
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
        padding: 20px 40px;
        width: 31%;
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

    .Cmpdetailsbtndiv1 a {
        color: #007fc3;
        font-size: 18px;
        border: none;
        width: 133px;
        line-height: 60px;
        margin-left: 10px;
        text-align: center;
    }


    .Cmpdetailsbtndiv2 a {
        color: #fff;
        font-size: 18px;
        border: none;
        width: 133px;
        line-height: 60px;
        margin-left: 10px;
        text-align: center;
    }
    /*a.num {
        position: relative;
        float: left;
        padding: 9px 17px;
        margin-right: -1px;
        line-height: 1.42857143;
        color: #8c8c8c;
        text-decoration: none;
        background-color: #fff;
        border: 1px solid #ddd;
        font-size: 20px;
    }

    span.active.num {
        position: relative;
        float: left;
        padding: 9px 17px;
        margin-right: -1px;
        line-height: 1.42857143;
        color: #fff;
        text-decoration: none;
        background-color: #007fc3;
        border: 1px solid #ddd;
        font-size: 20px;
    }

    .pagination:last-child a, .pagination:first-child a {
        background: #007fc3;
        color: #fff;
        border-radius: 0;
        -webkit-border-radius: 0;
        -moz-border-radius: 0;
        -ms-border-radius: 0;
        -o-border-radius: 0;
        margin: 0 20px;
    }*/

    /*---------------------------------------*/


    /*.pagination {
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
    }*/
    /*----------------------------------------*/


    a.next,
    a.prev {
        background: #007fc3;
        color: #fff;
        margin: 0 15px;
        position: relative;
        display: inline-block;
        padding: 9px 17px;
        border: 1px solid #ddd;
        font-size: 20px;
        text-decoration: none;
    }

    span.num {
        position: relative;
        padding: 9px 17px;
        margin-right: -1px;
        line-height: 1.42857143;
        color: #8c8c8c;
        text-decoration: none;
        background-color: #fff;
        border: 1px solid #ddd;
        font-size: 20px;
        margin: 0 5px;
    }

    span.active.num {
        color: #fff;
        background-color: #007fc3;
        border: 1px solid #ddd;
    }

    .newcounterBox label span {
        color: #FFF;
        font-size: 30px;
    }

    span#ContentPlaceHolder1_ctl00_lstCompanyDevice_DataPager1 {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: row-reverse;
}

    /* strong {
    font-size: 25px !important;
} */

    @media only screen and (max-width: 1367px) and (min-width: 1300px) {
        .newcounter4 p strong {
            font-size: 12px;
        }

        .newcounter4 p span {
            font-size: 12px;
        }
    }
    @media only screen and (max-width: 767px) {
        .detil_counter_rowone {
            display: block;
        }

        .newcounterBox,
        .newcounter4 {
            width: 100%;
            float: none;
        }
    }
</style>
