<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewsPage.aspx.cs" Inherits="DetailsPage_NewsPage" Async="true" EnableViewState="true" EnableEventValidation="false" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  <%--  <div class="col-lg-8 col-md-8 col-sm-12">--%>
        <div class="greybg subscribe_div">
                    <asp:Label runat="server" ID="lblContentDetails"></asp:Label>
            </div>
               <%-- </div>--%>
    <%--<section class="inner_banner">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-12">
                    <div class="innerbannerheading">
                        <ol class="breadcrumb">
                           
                            <li><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">الصفحة الرئيسية</a></li>
                            

                            <li runat="server" id="lstParent" visible="false">
                                <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                            </li>
                            <li class="active">
                                <asp:Literal ID="lblChildName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                            </li>

                        </ol>
                        <aside>
                            <asp:Literal ID="lblPageName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal></aside>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-12">
                    <div class="innersocial">
                        <span>شارك هذه الصفحة</span>

                         <div class="addthis_inline_share_toolbox"></div>
                       
                        <div class="addthis_inline_follow_toolbox_3jjb"></div>


                        <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-5ee2061022ffd1bc"></script>

                    
                    </div>
                </div>
            </div>
        </div>
    </section>--%>

     <%--<section class="about">
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





                        <asp:ListView runat="server" ID="lstSecNav" OnItemDataBound="lstSecNav_ItemDataBound">
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hndID" Value='<%# Bind("ID") %>' />
                                <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("MenuName") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("TargetID") %>'>
                                </asp:HyperLink>

                            </ItemTemplate>
                        </asp:ListView>

                    </div>
                    <div class="sidebar_tips">
                        <aside>
                            <h1>
                                <small>من اجل سلامتكم</small>
                                نصائح ارشادية
                            </h1>

                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/info.png" alt="" />
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


                                    </div>
                                </ItemTemplate>
                            </asp:ListView>

                         
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </section>--%>



    
</asp:Content>
