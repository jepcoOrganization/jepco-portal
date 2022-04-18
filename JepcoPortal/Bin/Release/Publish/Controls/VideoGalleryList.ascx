<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoGalleryList.ascx.cs" Inherits="Controls_VideoGalleryList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<%--<div class="about-us-content section news_section video_gallery">
    <div class="container">--%>
<%--<asp:UpdatePanel runat="server" ID="upanel">
    <ContentTemplate>--%>
<div class="row">
    <%--<div class="col-12">
        <h2>Video Albums</h2>
    </div>--%>
    <div class="col-12">
        <asp:HiddenField runat="server" ID="hdnRowIndex" Value="0" />
        <ul class="list-unstyled news_list">
            <asp:ListView runat="server" ID="lstAlbumMain" OnItemDataBound="lstAlbumMain_ItemDataBound" ItemPlaceholderID="itemPlaceHolder1" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstAlbumMain_PagePropertiesChanging">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                    <div class="clearfix"></div>
                    <section class="section">
                        <div class="container">
                            <div class="row">
                                <div class="col-12">
                                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstAlbumMain" class="pagination justify-content-center">
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
                        <div class="video_img">
                            <asp:HyperLink runat="server" ID="lnkVideoAlbum" href="#lightbox" data-toggle="modal">
                                <asp:HiddenField runat="server" ID="lblAlbumID" Value='<%# Bind("ID") %>' />
                                <div class="imgVideo">
                                    <asp:Image runat="server" ID="imgVideoAlbum" ImageUrl='<%# Bind("CoverImage") %>' />
                                </div>
                            </asp:HyperLink>
                            <div class="about-us-play-col">
                                <asp:HyperLink runat="server" ID="lnkVideoAlbum2" href="#lightbox" data-toggle="modal">
                                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/play-icon.png" alt="#">
                                </asp:HyperLink>
                            </div>
                        </div>
                        <h3>
                            <asp:HyperLink runat="server" ID="lnkVideoAlbum1" href="#lightbox" data-toggle="modal">
                                <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                            </asp:HyperLink>
                        </h3>
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </ul>
    </div>
</div>
<div class="clearfix"></div>
<%--  </div>
</div>--%>
<div class="modal" id="lightbox">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <div id="demo7" class="carousel slide" data-ride="carousel" data-interval="false">
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
                                    <div class="carousel-item-title">
                                        <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                    </div>
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
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
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
