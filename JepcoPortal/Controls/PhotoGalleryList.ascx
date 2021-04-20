<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhotoGalleryList.ascx.cs" Inherits="Controls_PhotoGalleryList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<p>Photo Albums</p>

<asp:ListView runat="server" ID="lstPhotoAlbum3" OnItemDataBound="lstTopPhotoAlbum_ItemDataBound" ItemPlaceholderID="itemPlaceHolder1" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstPhotoAlbum3_PagePropertiesChanging">
    <LayoutTemplate>
        <div class="row">
            <ul class="list-unstyled Photo_list" style="width:100%;">
                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            </ul>
        </div>
        <div class="clearfix"></div>
        <section class="section">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstPhotoAlbum3" class="pagination justify-content-center">
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
            <asp:HyperLink runat="server" ID="lnkPhotoAlbum">
                <asp:HiddenField runat="server" ID="lblAlbumID" Value='<%# Bind("ID") %>' />
                <div class="listPhoto">
                    <asp:Image runat="server" ID="imgPhotoAlbum" ImageUrl='<%# Bind("Image") %>' />
                </div>
            </asp:HyperLink>
            <h3>
                <asp:HyperLink runat="server" ID="lnkPhotoAlbum1">
                    <asp:Literal runat="server" ID="lblAlbumTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                </asp:HyperLink>
            </h3>
        </li>
    </ItemTemplate>
</asp:ListView>

