<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchPage.aspx.cs" Inherits="DetailsPage_en_SearchPage" Async="true" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .highlight {          
            color: #c5ad71 !important;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="about-us-wrapper section">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1 class="about-us">
                        <asp:Literal runat="server" ID="lblPageTitle"></asp:Literal></h1>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">HOME</a></li>
                        <li runat="server" id="lstParent" visible="false" class="breadcrumb-item">
                            <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                        </li>
                        <li class="breadcrumb-item active" aria-current="page">
                            <asp:Literal ID="lblChildName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
    <!---------------------------------------------------------------------------------------------------------->
    <div class="about-us-content section" runat="server" id="divMain">
        <div class="container">

            <div class="row">
                <div class="col-lg-12">
                    <asp:HiddenField runat="server" ID="lblAliasPath" />
                    <asp:UpdatePanel runat="server" ID="PanelUpdate">
                        <ContentTemplate>
                            <asp:HiddenField runat="server" ID="lblCount" Value="0" />
                            <table style="width: 100%;" class="customTab1">
                                <tr>
                                    <td>
                                        <asp:Label ID="EnKeyword" Style="color: #868686; font-size: 20px;" Text=" Word Search : " runat="server"></asp:Label>
                                        <asp:Label ID="Label6" Style="color: #868686; font-size: 16px;" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Style="color: #868686; font-size: 20px;">Search Results : 
                                            <asp:Literal ID="lblEnSearchCount" Text="" runat="server"></asp:Literal></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:ListView ID="lstEnSearchData" runat="server" OnItemDataBound="lstData_ItemDataBound" ItemPlaceholderID="itemPlaceHolder1" OnPagePropertiesChanging="OnPagePropertiesChanging" GroupPlaceholderID="groupPlaceHolder1">
                                <LayoutTemplate>
                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                    <div class="clearfix"></div>
                                <section class="section">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-12">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstEnSearchData" class="pagination add-custom-pagination justify-content-center">
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
                                    <div>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                                    </div>
                                </GroupTemplate>
                                <ItemTemplate>
                                    <table style="width: 100%;" class="customTab2">
                                        <tr>
                                            <td class="webResult">
                                                <h3 style="margin-bottom: 10px;">
                                                    <b>
                                                        <asp:HyperLink ID="LnkTitleText" NavigateUrl='<%# Eval("LivePath")%>' runat="server" Style="color: #c5ad71 !important;">
                                                            <asp:Label ID="lblURL" runat="server" Text='<%# Bind("Name")%>' CssClass="searchResultText"></asp:Label>
                                                        </asp:HyperLink>
                                                    </b>
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="LnkContainedText" Style="color: #898989;"
                                                    NavigateUrl='<%# Eval("LivePath")%>' runat="server"
                                                    CssClass="searchResultText ">
                                                    <asp:Label runat="server" ID="lblContent" Text='<%# Eval("ContentHTML") %>' Class="example"> </asp:Label>
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                        <div style="border-bottom: 1px dotted #808080;"></div>
                                    </table>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <div style="padding-top: 10px;">
                                        <asp:Label runat="server" ID="lblNoresultFound" Text="No Results Found" Style="color: #898989; font-size: 16px;"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:ListView>
                            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
                            <script type="text/javascript">
                                $("document").ready(function () {
                                    highlightWord('.example', '<%=Request.QueryString["keyword"]%>', 'highlight');
                                });
                                function highlightWord(element, searchFor, classWrapper) {
                                    var EnCount = $("#ContentPlaceHolder1_lblEnSearchCount").text();
                                    var ArCount = "لم يتم العثور على نتائج";
                                    var Count = <%=ConfigurationManager.AppSettings["SearchPageSize"]%>;

                                    for (var j = 0; j < Count; j++) {
                                        var id = "#ContentPlaceHolder1_lstEnSearchData_ctrl" + j + "_lblContent_" + j;
                                        var textString = $(id).html(),
                                            wordArray = [];
                                        if (textString != undefined) {
                                            wordArray.push(searchFor);
                                            wordArray.push(searchFor.substr(0, 1).toUpperCase() + searchFor.substr(1, searchFor.length - 1));
                                            wordArray.push(searchFor.toUpperCase());
                                            wordArray.push(searchFor.toLowerCase());

                                            for (var i = 0; i < wordArray.length; i++) {
                                                if (textString.indexOf(wordArray[i]) >= 0) {
                                                    var findAll = new RegExp(wordArray[i], 'g');
                                                    textString = textString.replace(findAll, '<span class="' + classWrapper + '">' + wordArray[i] + '</span>');
                                                }
                                            }
                                            $(id).html(textString);
                                        }
                                    }
                                }
                            </script>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

