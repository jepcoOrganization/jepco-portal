<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList.ascx.cs" Inherits="Controls_NewsList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>


<section class="about news">
  <div class="container">
    <div class="row">
      <div class="col-lg-4 col-md-4 col-sm-12">
        <div class="sidebar">

            <asp:ListView runat="server" ID="lstAboutCompant">
                            <ItemTemplate>
                                <aside>
                                    <small>
                                        <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("Title") %>'></asp:Literal></small>
                                    <asp:Literal runat="server" ID="lblTitle2" Text='<%# Bind("Title2") %>'></asp:Literal>
                                </aside>
                            </ItemTemplate>
                        </asp:ListView>

         <%-- <aside>
            <small>اكتشف المزيد عن الشركة</small>
            الإلتزام بمعايير السلامة والصحة 
والبيئة العالمية
          </aside>--%>



            <asp:ListView runat="server" ID="lstSecNav" OnItemDataBound="lstSecNav_ItemDataBound">
                            <ItemTemplate>
                                 <asp:HiddenField runat="server" ID="hndID" Value='<%# Bind("ID") %>' />
                                <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("MenuName") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("TargetID") %>'>
                                </asp:HyperLink>

                            </ItemTemplate>
                        </asp:ListView>

         <%-- <a href="javascript:void">الهيكل التنظيمي</a>
          <a href="javascript:void">خدمة العملاء</a>
          <a href="javascript:void">قيم ومبادئ الشركة</a>
          <a href="javascript:void">التسديد الإلكتروني اي فواتيركم</a>
          <a href="javascript:void">قيم ومبادئ الشركة</a>
          <a href="javascript:void">الهيكل التنظيمي</a>
          <a href="javascript:void">خدمة العملاء</a>
          <a href="javascript:void">التسديد الإلكتروني اي فواتيركم</a>--%>
        </div>
        <div class="sidebar_tips">
          <aside>            
            <h1>
              <small>من اجل سلامتكم</small>
              نصائح ارشادية
            </h1>
            <img src="images/info.png" alt=""/>
          </aside>
          <div id="tips" class="owl-carousel">

              <asp:ListView runat="server" ID="lstNotification">
                                <ItemTemplate>
                                    <div class="item">
                                        <p>
                                            <asp:Literal runat="server" ID="lblSummary" Text='<%# Bind("Summary") %>'></asp:Literal>
                                        </p>
                                        <asp:HyperLink runat="server" ID="lnkCompanu" NavigateUrl='<%# Bind("Link") %>' Target='<%# Bind("Target") %>'>
                                     شاهد المزيد  <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/left-arrow.png" alt="">
                                        </asp:HyperLink>

                                        <%--<a href="javascript:void">شاهد المزيد 
                     <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/left-arrow.png" alt="">
                                        </a>--%>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

           <%-- <div class="item">
              <p>تشكل خطوط الطاقة الكهربائية الساقطة على الأرض خطراً كبيراُ، فلا تحاول الاقتراب منها أو محاولة تحريكها</p>
                <a href="javascript:void">
                  شاهد المزيد 
                  <img src="images/left-arrow.png" alt="">
                </a>
            </div>
            <div class="item">
              <p>تشكل خطوط الطاقة الكهربائية الساقطة على الأرض خطراً كبيراُ، فلا تحاول الاقتراب منها أو محاولة تحريكها</p>
              <a href="javascript:void">
                  شاهد المزيد 
                  <img src="images/left-arrow.png" alt="">
                </a>
            </div>
            <div class="item">
              <p>تشكل خطوط الطاقة الكهربائية الساقطة على الأرض خطراً كبيراُ، فلا تحاول الاقتراب منها أو محاولة تحريكها</p>
              <a href="javascript:void">
                  شاهد المزيد 
                  <img src="images/left-arrow.png" alt="">
                </a>
            </div>--%>
          </div>
        </div>
      </div>
      <div class="col-lg-8 col-md-8 col-sm-12">
        <ul class="list-unstyled newslist">
                <asp:ListView runat="server" ID="lstNews" OnItemDataBound="lstNews_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="newimg">

                                        <asp:Literal runat="server" ID="lblDate" Text='<%# Bind("NewsDate") %>'></asp:Literal>
                                        <asp:HiddenField runat="server" ID="hdnNewsID" Value='<%# Bind("NewsID") %>' />
                                        <asp:Image ID="imgNews" runat="server" ImageUrl='<%# Bind("NewsImage") %>' alt="" />
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="newstext">
                                        <h4>
                                            <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("Headline") %>'></asp:Literal></h4>
                                        <p>
                                            <asp:Literal runat="server" ID="lbl" Text='<%# Bind("Summary") %>'></asp:Literal>
                                        </p>
                                        <asp:HyperLink runat="server" ID="lnkNews">
                                    شاهد المزيد <i class="fa fa-long-arrow-left"></i>
                                        </asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>        
      </div>
    </div>
  </div>
</section>

            


