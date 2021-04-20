<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList.ascx.cs" Inherits="Controls_NewsList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<section class="Latest_News">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h2 class="inner_heading">Latest News</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="news_box">
                    <asp:HyperLink runat="server" ID="lnkNewsDetail">
                        <%--<asp:Image runat="server" ID="imgLatestNews" class="ver_image"/>--%>
                        <div class="ol_div">
                            <div class="ver_image" runat="server" id="divNewsBack">
                            </div>
                        </div>
                    </asp:HyperLink>
                    <div class="news_overlay_div yellow">
                        <aside>
                            <i class="fa fa-calendar-o"></i>
                            <asp:Literal runat="server" ID="lblLatestNewsDate"></asp:Literal>
                            <a href="javascript:void">
                                <i class="fa fa-share-alt"></i>
                            </a>
                        </aside>

                        <p class="news_title">
                            <asp:HyperLink runat="server" ID="lnkNewsDetail1">
                                <asp:Literal runat="server" ID="lblLatestNewsHeadline"></asp:Literal>
                            </asp:HyperLink>
                        </p>

                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6">
                <asp:ListView runat="server" ID="lstRecentNews" OnItemDataBound="lstRecentNews_ItemDataBound">
                    <ItemTemplate>
                        <div class="news_box fix_height">
                            <asp:HiddenField runat="server" ID="hdNewsID" Value='<%# Bind("NewsID") %>' />
                            <asp:HyperLink runat="server" ID="lnkNewsDetail">
                                <div class="ol_div">
                                    <asp:Image runat="server" ID="imgNews" ImageUrl='<%# Bind("NewsImage") %>' class="hor_image" />
                                </div>
                            </asp:HyperLink>
                            <div class="news_overlay_div" runat="server" id="divOverlay">
                                <aside>
                                    <i class="fa fa-calendar-o"></i>
                                    <asp:Literal runat="server" ID="lblNewsDate" Text='<%# Bind("NewsDate") %>'></asp:Literal>
                                    <a href="javascript:void">
                                        <i class="fa fa-share-alt"></i>
                                    </a>
                                </aside>

                                <p class="news_title">
                                    <asp:HyperLink runat="server" ID="lnkNewsDetail1">
                                        <asp:Literal runat="server" ID="lblNewsHeadLine" Text='<%# Bind("Headline") %>'></asp:Literal>
                                    </asp:HyperLink>
                                </p>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
    </div>
</section>
<section class="Other_News">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h2 class="inner_heading">Other News</h2>
            </div>
        </div>
        <asp:ListView runat="server" ID="lstNewsRow" OnItemDataBound="lstNewsRow_ItemDataBound">
            <ItemTemplate>
                <div class="row">
                    <asp:ListView runat="server" ID="lstOtherNews" OnItemDataBound="lstOtherNews_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <asp:HiddenField runat="server" ID="hdNewsID" Value='<%# Bind("NewsID") %>' />
                                <div class="other_news_box">
                                    <asp:HyperLink runat="server" ID="lnkNewsDetail2">
                                        <div class="ol_div">
                                            <asp:Image runat="server" ID="imgNews" ImageUrl='<%# Bind("NewsImage") %>' />
                                        </div>
                                    </asp:HyperLink>
                                    <div class="news_overlay_div" runat="server" id="divOverlay">
                                        <aside>
                                            <i class="fa fa-calendar-o"></i>
                                            <asp:Literal runat="server" ID="lblNewsDate" Text='<%# Bind("NewsDate") %>'></asp:Literal>
                                            <a href="javascript:void">
                                                <i class="fa fa-share-alt"></i>
                                            </a>
                                        </aside>
                                    </div>
                                </div>
                                <asp:HyperLink runat="server" ID="lnkNewsDetail1">
                                    <h3 class="news_title">

                                        <asp:Literal runat="server" ID="lblNewsHeadLine" Text='<%# Bind("Headline") %>'></asp:Literal></h3>
                                    <p class="news_summary">
                                        <asp:Literal runat="server" ID="lblNewsSummary" Text='<%# Bind("Summary") %>'></asp:Literal>
                                    </p>
                                </asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnkNewsDetail" class="read_more">READ MORE</asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ItemTemplate>
        </asp:ListView>

    </div>
</section>
