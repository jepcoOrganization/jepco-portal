<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimelineList.ascx.cs" Inherits="Controls_TimelineList" %>
<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>

<asp:HiddenField runat="server" ID="mylistcount" />
<ul class="list-unstyled timeline_list">
    <asp:ListView runat="server" ID="lstTimeline" OnItemDataBound="lstTimeline_ItemDataBound">
        <ItemTemplate>
            <li id="ListCounts" runat="server" class="">
                <aside>
                     <asp:HiddenField runat="server" ID="hdnTimelineID" Value='<%# Bind("TimelineID")%>' />
                    <asp:HiddenField runat="server" ID="hdncolors" Value='<%# Bind("PluginAreaTitle")%>' />
                    <asp:HiddenField runat="server" ID="hdntextHead" Value='<%# Bind("Title")%>' />
                    <asp:HiddenField runat="server" ID="hdntextYear" Value='<%# Bind("Year")%>' />
                     
                    <asp:Literal runat="server" ID="lblTextheadYear"></asp:Literal>
                   
                </aside>
                <asp:HyperLink runat="server" ID="lnkTimelineDetail1">
                <p>
                        <asp:Literal runat="server" ID="lblSummery" Text='<%# Bind("Summary")%>'></asp:Literal>
                 </p>
                 </asp:HyperLink>

            </li>
        </ItemTemplate>
    </asp:ListView>
</ul>

<div class="timeline_logo">
    <asp:Image ID="imgbottom" runat="server" />
  <%--  <strong>2019</strong>--%>
       <strong> <asp:Literal runat="server" ID="lblpageYear" ></asp:Literal></strong>

    
</div>




<script type="text/javascript" src="/Scripts/jquery-3.3.1.js"></script>


<script src="/Scripts/wow.js"></script>

<script>
    new WOW().init();
</script>

<script type="text/javascript">

    $(document).ready(function () {

        var mylistcount = $("#<%=mylistcount.ClientID%>").val();
        //  listcount.val();
        for (var i = 1; i <= mylistcount; i++) {

            var j = i - 1;

            var abcd = $('#ContentPlaceHolder1_ctl00_lstTimeline_hdncolors' + i + '_' + j + ' ').val();


            $('<style>.color_' + i + ':before{color:' + abcd + ' }</style>').appendTo('head');
            $('<style>.color_' + i + '{color:' + abcd + ' }</style>').appendTo('head');
        }

    });



</script>
