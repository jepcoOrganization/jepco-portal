<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyUserRequestsList.ascx.cs" Inherits="Controls_RenewableEnergyUserRequestsList" %>

<div class="top-cart-detail">
    <div class="row">
        <div class="col-md-10 col-sm-10">
            <h5><strong>طلبات الطاقة المتجددة
            </strong></h5>
        </div>

    </div>
    <div class="row">
    </div>
    <div class="detil_counter_rowone">
        <div class="newcounterBox ReportMess2">
             <a href="/ar/Home/RenewableEnergyUserRequestsList/RenewableEnergyUserRequestsAdd">
            <p>تقديم طلب جديد</p>
             </a>

            <%-- <label id="lblUnpaidAmount1155"><asp:label runat="server" ID="lblTotalCount" class="LTR"></asp:label></label>--%>
            <a href="/ar/Home/RenewableEnergyUserRequestsList/RenewableEnergyUserRequestsAdd">
                <img src="<%=ResolveUrl("~/")%>App_Themes/ThemeAr/img/shop.png" alt="">
            </a>
        </div>
        <div class="newcounterBox ReportMess1">
            <p>عدد الطلبات المقدمة</p>

            <label id="lblUnpaidAmount11">
                <asp:Label runat="server" ID="lblAppoverCount" class="LTR"></asp:Label></label>


        </div>

        <div class="newcounterBox newcounter2">
            <p>عدد الطلبات التي تم تشغيلها</p>

            <%--  <asp:Label runat="server" ID="lblReversingCount"></asp:Label>--%>
            <label id="lblUnpaidAmount">
                <asp:Label runat="server" ID="lblReversingCount" class="LTR"></asp:Label></label>


        </div>

    </div>

    <div class="billlist">

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
                                <asp:HiddenField runat="server" ID="hdnID" Value='<%# Bind("RenwableEnergyID") %>'/>
                                <asp:Label runat="server" ID="lblPublishDate" Text='<%# Bind("PublishDate") %>'></asp:Label>
                                <%--<span></span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>اسم الشركة</h4>

                                <asp:Label runat="server" ID="lblCompany" Text='<%# Bind("CompanyID") %>'></asp:Label>
                                <%--  <span>الموديل</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-1">
                                <h4>رقم العداد\رقم الطلب</h4>
                                <asp:Label runat="server" ID="lblDevice" Text='<%# Bind("ReferenceNumber") %>'></asp:Label>
                                <%--  <span>256 PM</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>رقم الهاتف</h4>
                                <asp:Label runat="server" ID="lblTelePhone"></asp:Label>
                                <%-- <span>C1</span>--%>
                            </div>

                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>نوع الطلب</h4>

                                <asp:Label runat="server" ID="ReqType"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdnRenwableEnergyTypeID" Value='<%# Bind("RenwableEnergyTypeID") %>' />
                                <%-- <span>C1</span>--%>
                            </div>


                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>رقم المرجعي للطلب</h4>
                                <asp:Label runat="server" ID="lblTokanNo"></asp:Label>
                                <%-- <span>C1</span>--%>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-1">
                                 <asp:LinkButton ID="lnkEdit" class="GoFileDetails" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("RenwableEnergyID") %>'>
                                        التفاصيل
                                </asp:LinkButton>
                               <%-- <a href="#" data-filename="0130707645872" class="GoFileDetails">التفاصيل</a>--%>

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
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
          <div id="loading">
              <div id="loader"></div><br />
              <h3 style="color:#007fc3;font-weight:bold">شركة الكهرباء الأردنية  </h3>
                            <h4 style="color:#007fc3;font-weight:bold">الرجاء الأنتظار  </h4>

  <%--<img id="loading-image" src="/App_Themes/ThemeAr/img/Dual Ring-1s-200px (3).gif" alt="Loading..." style="width:200px;height:200px" />--%>
</div>
        <style>
            #loader {
    display: block;
    position: relative;

    width: 150px;
    height: 150px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #3498db;
    -webkit-animation: spin 2s linear infinite;
    animation: spin 2s linear infinite;
}
            #loader:before {
    content: "";
    position: absolute;
    top: 5px;
    left: 5px;
    right: 5px;
    bottom: 5px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #e74c3c;
    -webkit-animation: spin 3s linear infinite;
    animation: spin 3s linear infinite;
}
#loader:after {
    content: "";
    position: absolute;
    top: 15px;
    left: 15px;
    right: 15px;
    bottom: 15px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #f9c922;
    -webkit-animation: spin 1.5s linear infinite;
    animation: spin 1.5s linear infinite;
}
            #loading {
  position: fixed;
  display: flex;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  text-align: center;
  background-color: rgba(255, 255, 255,1);
  z-index: 99;
  justify-content:center;
  align-items:center;
      flex-direction: column;

}

#loading-image {

  z-index: 99999;
}
@-webkit-keyframes spin {
	0%   {-webkit-transform: rotate(0deg);}

	100% {-webkit-transform: rotate(360deg);}
}
@keyframes spin {
	0%   {transform: rotate(0deg);}

	100% {transform: rotate(360deg);}
}
        </style>
 <script>
     $(window).on('load', function () {
         $('#loading').hide();
     });
 </script> 
<style>
    a.GoFileDetails {
        background: #007fc3;
        color: #fff;
        font-size: 18px;
        font-weight: bold;
        min-width: 70px;
        text-align: center;
        line-height: 40px;
        display: inline-block;
        align-self: center;
    }

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

    strong {
        font-size: 19px !important;
    }

     span#ContentPlaceHolder1_ctl00_lstUserRequstdevice_datapager1 {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: row-reverse;
}

.top-cart-detail .ReportMess2 a {
    border-bottom: 0;
    cursor: pointer;
}

.billlist h4 {
    font-size: 11px;    
}

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
