<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyCompanyUserList.ascx.cs" Inherits="Controls_RenewableEnergyCompanyUserList" %>
<div class="average_energy">
    <aside>
        <h1> قائمة المفوضين<small>عدد المفوضين : <asp:label runat="server" ID="lblTotalCount" class="LTR"></asp:label></small>
           </h1>
        <a href="/ar/Home/RenewableEnergyCompanyUserList/RenewableEnergyCompanyUserAdd" class="energy_a">اضافة مفوض جديد</a>

    </aside>

    <div class="billlist">
        <div class="top-cart-detail">
            <div class="row">
                <div class="col-md-10 col-sm-10">
                    <span>قائمة المفوضين:</span>
                    <strong>
                        <label id="CostName"></label>
                    </strong>
                </div>
                <div class="col-md-2 pull-right text-right"><a href="#" class="cllChangeFile">عدادات اخرى؟</a></div>
            </div>

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



                        <div class="col-xs-6 col-sm-6 col-md-1">
                             <asp:Image ID="imgProfileimge" runat="server" ImageUrl='<%# Bind("DocumentUploadPhoto") %>' />
                            <%--<img src=" /App_Themes/ThemeAr/img/Profile_pic.png" alt="" style="height: 50px; width: 50px;">--%>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>اسم المفوض</h4>
                            <span> <asp:Literal runat="server" ID="lblNAme" Text='<%# Bind("FirstName") %>'></asp:Literal> </span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>رقم الهاتف</h4>
                            <span><asp:Literal runat="server" ID="lblMobileno" Text='<%# Bind("MobileNo") %>'></asp:Literal> </span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>البريد الالكتروني</h4>
                            <span><asp:Literal runat="server" ID="Literal2" Text='<%# Bind("EmailID") %>'></asp:Literal> </span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>هوية احوال مدنية</h4>
                            <span>
                                 <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("DocumentUpload") %>' Target="_parent">
                                   <i class="fa fa fa-download"></i>
                                </asp:HyperLink>
                                عرض الوثيقة</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <a href="#" data-filename="0130707645872" class="GoFileDetails">التفاصيل</a>
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
</div>


<style>
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


    
a.next,
a.prev{
        background: #007fc3;
    color: #fff;
        margin: 0 15px;
        position: relative;
        display:inline-block;
    padding: 9px 17px;
        border: 1px solid #ddd;
    font-size: 20px;
        text-decoration: none;
}
span.num{
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
span.active.num{
    color: #fff;
    background-color: #007fc3;
    border: 1px solid #ddd;
}

    .average_energy a { color:white }

    .average_energy aside h1 small span {
    color: #4db6c9;
    font-size: 30px;
}

    a.energy_a {
        padding-top: 55px;
    text-decoration: underline !important;
    }

    .pagination a{
        color:#337ab7;
    }
    .pagination a.next, 
    .pagination a.prev{
         color:#fff;
    }
    span#ContentPlaceHolder1_ctl00_lstCompanyDevice_DataPager1 {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-direction: row-reverse;
}
</style>

