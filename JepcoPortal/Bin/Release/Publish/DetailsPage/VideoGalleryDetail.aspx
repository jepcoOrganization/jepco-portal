<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VideoGalleryDetail.aspx.cs" Inherits="DetailsPage_VideoGalleryDetail" Async="true" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="about-us-wrapper section">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1 class="about-us">
                        <asp:Literal runat="server" ID="lblPageTitle"></asp:Literal>
                    </h1>
                    <!-- <p><a href="#">HOME</a> &nbsp;&nbsp;>&nbsp;&nbsp; ABOUT KHF</p> -->
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">الصفحة الرئيسية</a></li>
                        <li class="breadcrumb-item" runat="server" id="lstParent">
                            <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                        </li>
                        <li class="breadcrumb-item active">
                            <asp:Literal ID="lblChildName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                        </li>

                    </ol>
                </div>
            </div>
        </div>
    </div>
    <div class="about-us-content section news_section photo_albums">
        <div class="container">
            <div class="row">

                <ul class="list-unstyled Photo_list Video_list">
                    <asp:ListView runat="server" ID="lstVideoList" OnItemDataBound="lstVideoList_ItemDataBound">
                        <ItemTemplate>
                            <li class="news_box">
                                <div class="listPhoto">
                                    <asp:Image runat="server" ID="imgVideo" href="#lightbox" data-toggle="modal" ImageUrl='<%# Bind("CoverImage") %>' />
                                </div>
                                <h3>
                                    <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("Title") %>'></asp:Literal></h3>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </ul>
            </div>
        </div>
        <div class="modal" id="lightbox">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-body">
                        <div id="demo7" class="carousel slide" data-ride="carousel">
                            <!-- The slideshow -->
                            <div class="carousel-inner">
                                <asp:ListView runat="server" ID="lstVideo" OnItemDataBound="lstVideo_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="carousel-item" runat="server" id="divImage">
                                            <asp:HiddenField runat="server" ID="lblSource" Value='<%# Bind("ItemLink") %>' />
                                            <asp:HiddenField runat="server" ID="lblOpenIn" Value='<%# Bind("OpenIn") %>' />
                                            <iframe id="embed1" runat="server" autostart="false" style="display: none; height: 500px; width: 100%;" class="embed-responsive-item" src='<%# Bind("ItemLink") %>' />
                                            <video id="vidGallery" controls style="height: auto; width: 100%; display: none;" runat="server">
                                                <source runat="server" id="src1" />
                                            </video>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                            <a class="carousel-control-prev" href="#demo7" data-slide="prev"></a>
                            <a class="carousel-control-next" href="#demo7" data-slide="next"></a>

                        </div>
                    </div>
                    <!-- /.modal-body -->
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
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
</asp:Content>

