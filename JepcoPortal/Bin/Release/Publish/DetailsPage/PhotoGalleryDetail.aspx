<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoGalleryDetail.aspx.cs" Inherits="DetailsPage_PhotoGalleryDetail" Async="true" %>

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

                <ul class="list-unstyled Photo_list">
                    <asp:ListView runat="server" ID="lstPhotoList" OnItemDataBound="lstPhotoList_ItemDataBound">
                        <ItemTemplate>
                            <li class="news_box">
                                <div class="listPhoto">
                                    <asp:Image runat="server" ID="imgPhoto" href="#lightbox" data-toggle="modal" ImageUrl='<%# Bind("ItemLink") %>' />
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
                                <asp:ListView runat="server" ID="lstPhoto" OnItemDataBound="lstPhoto_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="carousel-item" runat="server" id="divImage">
                                            <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%# Bind("ItemLink") %>' />
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
        function ItemActive(e) {
            debugger;
            var id = e.id;
            id = id.substring(id.lastIndexOf("_") + 1);
            var lst = document.getElementsByClassName("item active");
            if (lst.length > 0) {
                for (var i = 0; i < lst.length; i++) {
                    var pid = lst[i].id;
                    $('#' + pid).removeClass('active');
                }

            }
            var i = "ContentPlaceHolder1_lstPhotoGallery1_divImage_" + id;
            $("#ContentPlaceHolder1_lstPhotoGallery1_divImage_" + id).addClass("item active");
        }
    </script>--%>
</asp:Content>

