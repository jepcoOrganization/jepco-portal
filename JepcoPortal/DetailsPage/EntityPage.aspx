<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EntityPage.aspx.cs" Inherits="DetailsPage_EntityPage" Async="true" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="about-us-wrapper section">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1 class="about-us">
                         <asp:Literal runat="server" ID="lblPageTitle"></asp:Literal>
                    </h1>
                    <!-- <p><a href="#">HOME</a> &nbsp;&nbsp;>&nbsp;&nbsp; ABOUT KHF</p> -->
                    <ol class="breadcrumb">
                         <%--<li class="breadcrumb-item"><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">Home</a></li>--%>
                        <li class="breadcrumb-item"><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">الصفحة الرئيسية</a></li>
                           <li class="breadcrumb-item" runat="server" id="lstParent">
                            <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                        </li>
                        <li class="breadcrumb-item active" >
                            <asp:Literal ID="lblChildName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                        </li>
                        
                    </ol>
                </div>
            </div>
        </div>

    </div>

    <div class="about-us-content section">
        <div class="container">
             <asp:Literal runat="server" ID="lblDetails"></asp:Literal>
        </div>
    </div>
</asp:Content>

