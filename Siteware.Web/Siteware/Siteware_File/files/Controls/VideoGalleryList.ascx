<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoGalleryList.ascx.cs" Inherits="Controls_VideoGalleryList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<div class="about-us-content section news_section video_gallery">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h2>Video Albums</h2>
            </div>
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <asp:ListView runat="server" ID="lstAlbumDots" OnItemDataBound="lstAlbumDots_ItemDataBound">
                        <ItemTemplate>
                            <li data-target="#carouselExampleIndicators" runat="server" id="liAlbum"></li>
                        </ItemTemplate>
                    </asp:ListView>
                </ol>
                <div class="carousel-inner">
                    <asp:ListView runat="server" ID="lstAlbumMain" OnItemDataBound="lstAlbumMain_ItemDataBound">
                        <ItemTemplate>
                            <div class="carousel-item" runat="server" id="divAlbum">
                                <ul class="list-unstyled news_list video_list">
                                    <asp:ListView runat="server" ID="lstVideoAlbum" OnItemDataBound="lstVideoAlbum_ItemDataBound">
                                        <ItemTemplate>
                                            <li class="news_box">
                                                <div class="video_img">
                                                    <asp:HyperLink runat="server" ID="lnkVideoAlbum">
                                                        <asp:HiddenField runat="server" ID="lblAlbumID" Value='<%# Bind("ID") %>' />
                                                        <asp:Image runat="server" ID="imgVideoAlbum" ImageUrl='<%# Bind("Image") %>' />
                                                    </asp:HyperLink>
                                                    <div class="about-us-play-col">
                                                        <asp:HyperLink runat="server" ID="lnkVideoAlbum2">
                                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/play-icon.png" alt="#">
                                                        </asp:HyperLink>
                                                    </div>
                                                </div>
                                                <h3>
                                                    <asp:HyperLink runat="server" ID="lnkVideoAlbum1">
                                                        <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                                    </asp:HyperLink>
                                                </h3>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                    <div class="carousel-item">
                        <ul class="list-unstyled news_list video_list">
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-1.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-2.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-3.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-4.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-5.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-6.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                        </ul>
                    </div>
                    <div class="carousel-item">
                        <ul class="list-unstyled news_list video_list">
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-1.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-2.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-3.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-4.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-5.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                            <li class="news_box">
                                <div class="video_img">
                                    <img src="./assets/images/news-6.jpg" alt="" />
                                    <div class="about-us-play-col">
                                        <img href="#lightbox1" src="./assets/images/play-icon.png" alt="#">
                                    </div>
                                </div>
                                <h3>Canadian Minister of International Development and La Francophonie Visits UNFPA Supported
                                        Clinic.
                                </h3>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="clearfix"></div>
    </div>
</div>


<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

<script>
    function playVideo(e) {
        debugger;
        var id = e.id;
        var c = id[id.length - 1];
        var string = "#ContentPlaceHolder1_ctl00_lstVideoGallery_ctrl1_lstVideos_1_pnlPopup2_0  ";
        var s = id.substr(0, id.lastIndexOf('_'));
        var s1 = s.substr(0, s.lastIndexOf('_'));
        var s2 = "#" + s1 + "_pnlPopup2_" + c;
        $(s2).show();
        $(s2).find('video')[0].play();
    }
    function ClosePopup(e) {
        debugger;
        var id = e.id;
        var c = id[id.length - 1];
        var s = id.substr(0, id.lastIndexOf('_'));
        var s1 = s.substr(0, s.lastIndexOf('_'));
        var s2 = "#" + s1 + "_pnlPopup2_" + c;
        $(s2).hide();
    }
</script>--%>
