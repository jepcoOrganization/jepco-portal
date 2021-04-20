<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList.ascx.cs" Inherits="Controls_NewsList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<%--<div class="about-us-content section news_section">
    <div class="container">--%>
      <%--  <div class="row">
            <div class="col-12 col-xl-5 col-lg-6 col-md-12">
                <asp:HiddenField runat="server" ID="hdnNeesid" />
                <h2 class="h2">
                    <asp:Literal runat="server" ID="lblFirstNewsTitle"></asp:Literal>
                </h2>
                <p>
                    <asp:Literal runat="server" ID="lblFirstNewsSummery"></asp:Literal>
                </p>
                <p>
                    <asp:Literal runat="server" ID="lblFirstNewsTime"></asp:Literal>
                </p>
                <asp:HyperLink runat="server" ID="lnkNewsDetail1" class="read_btn">
                               Read More
                </asp:HyperLink>


            </div>
            <div class="col-12 col-xl-7 col-lg-6 col-md-12">
                <div class="about-us-welcome-col">
                    <asp:Image ID="imgfirstNews" runat="server" />
                    
                </div>
            </div>

        </div>
        <div class="clearfix"></div>
        <div class="row">--%>

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

            <%-- <ul class="list-unstyled news_list">
                <asp:UpdatePanel runat="server" ID="upanel1">
                    <ContentTemplate>
                        <asp:ListView runat="server" ID="lstNews" OnItemDataBound="lstRecentNews_ItemDataBound" ItemPlaceholderID="itemPlaceHolder1" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstNewsRow_PagePropertiesChanging">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                <div class="clearfix"></div>
                                <section class="section">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-12">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstNews" class="pagination justify-content-center">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="false"
                                                            ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="Prev" ButtonCssClass="pagi_comn_btn Prev" />
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false"
                                                            ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<i class='fa fa-caret-left' aria-hidden='true'></i>" ButtonCssClass="page-link grey_bg" />
                                                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="page-link num" Visible="true" NumericButtonCssClass="page-link num" NextPreviousButtonCssClass="page-link num" />
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false"
                                                            ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="<i class='fa fa-caret-right' aria-hidden='true'></i>" ButtonCssClass="page-link grey_bg" />
                                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="false"
                                                            ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="Next" ButtonCssClass="pagi_comn_btn Next" />
                                                    </Fields>
                                                </asp:DataPager>
                                            </div>
                                        </div>
                                    </div>
                                </section>

                            </LayoutTemplate>
                            <GroupTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                            </GroupTemplate>
                            <ItemTemplate>
                                <li class="news_box">
                                    <asp:HiddenField runat="server" ID="hdNewsID" Value='<%# Bind("NewsID")%>' />
                                    <asp:HiddenField runat="server" ID="hdnViewCount" Value='<%# Bind("ViewCount")%>' />
                                    <asp:HyperLink runat="server" ID="lnkNewsDetail" CssClass="newslistimg">
                                        <asp:Image ID="imgNews" runat="server" ImageUrl='<%# Bind("NewsImage")%>' />
                                    </asp:HyperLink>
                                    <p>
                                        <asp:HiddenField runat="server" ID="hdnnewsTime" Value='<%# Bind("NewsDate")%>' />
                                        <asp:Literal runat="server" ID="lblNewsTime"></asp:Literal>
                                    </p>
                                    <h3>
                                        <asp:Literal runat="server" ID="lblNewsTitle" Text='<%# Bind("Headline")%>'></asp:Literal>
                                    </h3>
                                    <asp:HyperLink runat="server" ID="lnkNewsDetail2">
                                 Read More
                                    </asp:HyperLink>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ul>
        </div>
        <div class="clearfix"></div>--%>
   <%-- </div>
</div>--%>

