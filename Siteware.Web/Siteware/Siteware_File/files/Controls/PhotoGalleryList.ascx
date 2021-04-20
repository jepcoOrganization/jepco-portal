<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhotoGalleryList.ascx.cs" Inherits="Controls_PhotoGalleryList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<div class="about-us-content section news_section photo_albums">
    <div class="container">

        <span>Photo Albums</span>

        <div class="row">
            <div class="col-xl-9 col-lg-9 col-md-8">
                <div class="row">
                    <asp:ListView runat="server" ID="lstTopPhotoAlbum" OnItemDataBound="lstTopPhotoAlbum_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-xl-6 col-lg-6 col-md-6">
                                <div class="photo_box">
                                    <asp:HyperLink runat="server" ID="lnkPhotoAlbum">
                                        <asp:HiddenField runat="server" ID="lblAlbumID" Value='<%# Bind("ID") %>' />
                                        <asp:Image runat="server" ID="imgPhotoAlbum" ImageUrl='<%# Bind("Image") %>' />
                                    </asp:HyperLink>
                                    <h2>
                                        <asp:HyperLink runat="server" ID="lnkPhotoAlbum1">
                                            <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                        </asp:HyperLink>
                                    </h2>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>

            <div class="col-xl-3 col-lg-3 col-md-4">
                <div class="photo_box2">
                    <asp:ListView runat="server" ID="lstPhotoAlbum2" OnItemDataBound="lstTopPhotoAlbum_ItemDataBound">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="lnkPhotoAlbum">
                                <asp:HiddenField runat="server" ID="lblAlbumID" Value='<%# Bind("ID") %>' />
                                <asp:Image runat="server" ID="imgPhotoAlbum" ImageUrl='<%# Bind("Image") %>' />
                            </asp:HyperLink>
                            <h2>
                                <asp:HyperLink runat="server" ID="lnkPhotoAlbum1">
                                    <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                </asp:HyperLink>
                            </h2>
                            <br runat="server" id="brTag" />
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>

        <div class="clearfix"></div>

        <div class="row">

            <ul class="list-unstyled Photo_list">
                <asp:ListView runat="server" ID="lstPhotoAlbum3" OnItemDataBound="lstTopPhotoAlbum_ItemDataBound">
                    <ItemTemplate>
                        <li class="news_box">
                            <asp:HyperLink runat="server" ID="lnkPhotoAlbum">
                                <asp:HiddenField runat="server" ID="lblAlbumID" Value='<%# Bind("ID") %>' />
                                <asp:Image runat="server" ID="imgPhotoAlbum" ImageUrl='<%# Bind("Image") %>' />
                            </asp:HyperLink>
                            <h2>
                                <asp:HyperLink runat="server" ID="lnkPhotoAlbum1">
                                    <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                </asp:HyperLink>
                            </h2>
                        </li>
                    </ItemTemplate>
                </asp:ListView>    
            </ul>
        </div>

    </div>
</div>

<section class="section">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <ul class="pagination justify-content-center">
                    <button class="pagi_comn_btn Prev">Prev</button>
                    <li class="page-item">
                        <a class="page-link grey_bg" href="#">
                            <img src="./assets/images/left-arrow.png" alt="" />
                        </a>
                    </li>
                    <li class="page-item active"><a class="page-link" href="#">1</a></li>
                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item">
                        <a class="page-link grey_bg" href="#">
                            <img src="./assets/images/right-arrow.png" alt="" />
                        </a>
                    </li>
                    <button class="pagi_comn_btn Next">Next</button>
                </ul>
            </div>
        </div>
    </div>
</section>


