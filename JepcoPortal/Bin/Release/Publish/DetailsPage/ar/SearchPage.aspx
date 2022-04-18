<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchPage.aspx.cs" Inherits="Pages_SearchPage" Async="true" EnableEventValidation="false" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .highlight {
            background-color: #ffde23;
            color: #ffffff !important;
            font-weight: bold;
        }
        .example {
            color: #424242;
        }
    </style>

    <section class="inner_banner">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-12">
                    <div class="innerbannerheading">
                        <ol class="breadcrumb">
                            <%--<li><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">Home</a></li>--%>
                            <li><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">الصفحة الرئيسية</a></li>
                           <%-- <li><a href="#">الرئيسية</a></li>--%>

                             <li runat="server" id="lstParent" visible="false" >
                                <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                            </li>
                               <li class="active">
                                <asp:Literal ID="lblChildName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                            </li>


                           <%-- <li class="active">نبذة عن الشركة</li>--%>
                        </ol>
                        <aside> <asp:Literal ID="lblPageName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal></aside>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-12">
                    <div class="innersocial">
                        <span>شارك هذه الصفحة</span>
                        <a href="javascript:void" class="fa fa-whatsapp"></a>
                        <a href="javascript:void" class="fa fa-instagram"></a>
                        <a href="javascript:void" class="fa fa-twitter"></a>
                        <a href="javascript:void" class="fa fa-facebook"></a>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--<div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="pagetitle">

                    <h3>
                        <asp:Literal runat="server" ID="lblPageName"></asp:Literal>
                    </h3>
                    <ol class="breadcrumb">
                        <li>

                            <a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">الرئيسية
                            </a>
                        </li>
                        <li runat="server" id="lstParent" visible="false">
                            <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                        </li>
                        <li class="active">
                            <asp:Literal ID="lblChildName" runat="server"></asp:Literal>
                        </li>


                    </ol>
                </div>
            </div>
        </div>
    </div>--%>
 

    <section class="about custom_height">
        <div class="container">
            <asp:UpdatePanel runat="server" ID="Update">
                <ContentTemplate>
                    <asp:HiddenField runat="server" ID="lblCount" Value="0" />
                    <div style="text-align: right; border-bottom: 1px dashed #808080;">
                        <asp:Label ID="ltlSearchKeyWord" Style="color: #868686; font-size: 16px;" runat="server" />
                        <asp:Label ID="ArKeyword" Style="color: #868686; font-size: 20px;" Text="كلمة البحث :" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Style="color: #868686; font-size: 20px;">نتائج البحث :</asp:Label>
                        <asp:Label ID="lblArSearchCount" Style="color: #868686; font-size: 20px;" Text="" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div style="text-align: right;">
                        <asp:ListView ID="lstArSearchData" runat="server" OnItemDataBound="lstData_ItemDataBound" ItemPlaceholderID="itemPlaceHolder1" GroupPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstData_PagePropertiesChanging">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>


                                <div class="Page_navigation">
                                    <div class="container">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstArSearchData" class="pagination">
                                                    <Fields>

                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false"
                                                            ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<i class='fa fa-angle-right' aria-hidden='true'></i>" ButtonCssClass="firstbtn" />
                                                        <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="num" Visible="true" NumericButtonCssClass="num" NextPreviousButtonCssClass="num" />
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false"
                                                            ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="<i class='fa fa-angle-left' aria-hidden='true'></i>" ButtonCssClass="lastbtn" />

                                                    </Fields>
                                                </asp:DataPager>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </LayoutTemplate>
                            <GroupTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                            </GroupTemplate>
                            <ItemTemplate>
                                <div id="trBorder" runat="server" class="custom_div">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="webResult">
                                                <h3>
                                                    <b>
                                                        <asp:HyperLink ID="LnkTitleText" NavigateUrl='<%# Eval("LivePath")%>' runat="server" style="color:#007fc3;">
                                                            <asp:Label ID="lblURL" runat="server" Text='<%# Bind("Name")%>' CssClass="searchResultText"></asp:Label>
                                                        </asp:HyperLink>
                                                    </b>
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="LnkContainedText" Style="color: #000"
                                                    NavigateUrl='<%# Eval("LivePath")%>' runat="server"
                                                    CssClass="searchResultText ">
                                                    <p>
                                                        <asp:Label runat="server" ID="lblContent" Text='<%# Eval("ContentHTML") %>' CssClass="example"> </asp:Label>
                                                    </p>
                                                </asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
                    <script type="text/javascript">
                        $("document").ready(function () {
                            highlightWord('.example', '<%=Request.QueryString["keyword"]%>', 'highlight');
                        });
                        function highlightWord(element, searchFor, classWrapper) {
                            debugger;
                            var EnCount = $("#<%=lblArSearchCount.ClientID%>").text();
                            var ArCount = "لم يتم العثور على نتائج";
                            var Count = <%=ConfigurationManager.AppSettings["SearchPageSize"]%>;
                            //if (ArCount != "لم يتم العثور على نتائج" && ArCount != "")
                            //{

                            //    for (var j = 0; j < Count; j++) {
                            //        var id = "#ContentPlaceHolder1_lstArSearchData_ctrl"+j+"_lblContent_"+j;
                            //        var textString = $(id).html(),
                            //    wordArray = [];
                            //        if(textString!=undefined)
                            //        {
                            //            wordArray.push(searchFor);
                            //            wordArray.push(searchFor.substr(0, 1).toUpperCase() + searchFor.substr(1, searchFor.length - 1));
                            //            wordArray.push(searchFor.toUpperCase());
                            //            wordArray.push(searchFor.toLowerCase());

                            //            for (var i = 0; i < wordArray.length; i++) {
                            //                if (textString.indexOf(wordArray[i]) >= 0) {
                            //                    var findAll = new RegExp(wordArray[i], 'g');
                            //                    textString = textString.replace(findAll, '<span class="' + classWrapper + '">' + wordArray[i] + '</span>');
                            //                }
                            //            }
                            //            $(id).html(textString);
                            //        }
                            //    }
                            //}
                            //else if (EnCount != "No result found" && EnCount != "")
                            //{
                            for (var j = 0; j < Count; j++) {
                                var id = "#ContentPlaceHolder1_lstArSearchData_ctrl" + j + "_lblContent_" + j;
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
                            //}
                        }
                    </script>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
