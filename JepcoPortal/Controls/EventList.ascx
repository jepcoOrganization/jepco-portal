<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventList.ascx.cs" Inherits="Controls_EventList" %>
<%--<div class="main_heading">
    <h1 class="h1">Events Calendar</h1>

    <asp:DropDownList runat="server" ID="ddlMonths" class="calSelect h1" OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged" AutoPostBack="true">
    </asp:DropDownList>
</div>--%>


<%--<div class="main_calender_div">
    <ul class="list-unstyled weeks_div hiiden-xs">

        <li>Monday</li>
        <li>Tuesday</li>
        <li>Wednesday</li>
        <li>Thursday</li>
        <li>Friday</li>
        <li>Saturday</li>
        <li>Sunday</li>
    </ul>
    <ul class="list-unstyled weeks_div visible-xs">
        <li>Mon</li>
        <li>Tue</li>
        <li>Wed</li>
        <li>Thu</li>
        <li>Fri</li>
        <li>Sat</li>
        <li>Sun</li>
    </ul>
    <ul class="list-unstyled dates_div">
        <asp:HiddenField runat="server" ID="hdYear" />
        <asp:HiddenField runat="server" ID="hdMonth" />
        <asp:ListView runat="server" ID="lstDates" OnItemDataBound="lstDates_ItemDataBound">
            <ItemTemplate>
                <li>
                    <div class="event_list_date " runat="server" id="divDate">
                        <strong>
                            <asp:Literal runat="server" ID="lblDay"></asp:Literal></strong>
                        <p>
                            <asp:Literal runat="server" ID="lblEventCount"></asp:Literal>
                        </p>
                        <div class="cal_overlay">
                            <span>
                                <asp:Literal runat="server" ID="lblEventSpanCount"></asp:Literal></span>
                            <ul class="list-unstyled">
                                <asp:ListView runat="server" ID="lstEvents" OnItemDataBound="lstEvents_ItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                            <i class="fa fa-caret-right"></i>
                                            <asp:Literal runat="server" ID="lblEventTitle" Text='<%# Bind("EventTitle") %>'></asp:Literal>

                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </ul>
</div>--%>

<%--<div class="about-us-content section news_section Events">
    <div class="container">--%>
        <div class="row">
            <div class="col-12">
                <div class="main_heading">
                    <asp:LinkButton runat="server" ID="lnkPrevMonth" OnClick="lnkPrevMonth_Click" CssClass="lni-chevron-left"></asp:LinkButton>
                    <%--<a href="javascript:void" class="lni-chevron-left"></a>--%>
                    <asp:HiddenField runat="server" ID="hdYear" />
                    <asp:HiddenField runat="server" ID="hdMonth" />
                    <span>
                        <asp:Literal runat="server" ID="lblMonthYear"></asp:Literal></span>
                    <asp:LinkButton runat="server" ID="lnkNextMonth" OnClick="lnkNextMonth_Click" class="lni-chevron-right">
                    </asp:LinkButton>
                </div>
                <div class="main_calender_div">
                    <ul class="list-unstyled weeks_div first_ul">
                        <li>Monday</li>
                        <li>Tuesday</li>
                        <li>Wednesday</li>
                        <li>Thursday</li>
                        <li>Friday</li>
                        <li>Saturday</li>
                        <li>Sunday</li>
                    </ul>
                    <ul class="list-unstyled weeks_div secon_ul">
                        <li>Mon</li>
                        <li>Tue</li>
                        <li>Wed</li>
                        <li>Thu</li>
                        <li>Fri</li>
                        <li>Sat</li>
                        <li>Sun</li>
                    </ul>
                    <ul class="list-unstyled dates_div">
                        <asp:ListView runat="server" ID="lstDates" OnItemDataBound="lstDates_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <div class="event_list_date " runat="server" id="divDate">
                                        <p runat="server" id="pDate">
                                            <strong>
                                                <asp:Literal runat="server" ID="lblDay"></asp:Literal></strong>

                                            <asp:Literal runat="server" ID="lblEventCount"></asp:Literal>
                                        </p>
                                        <strong runat="server" id="strongDate">
                                            <asp:Literal runat="server" ID="lblDay2"></asp:Literal>
                                        </strong>
                                        <asp:ListView runat="server" ID="lstEvents" OnItemDataBound="lstEvents_ItemDataBound">
                                            <ItemTemplate>
                                                <aside>

                                                    <i runat="server" id="liEvent"></i>
                                                    <span>
                                                        <asp:HiddenField runat="server" ID="lblColor" Value='<%# Bind("Color") %>' />
                                                        <asp:Literal runat="server" ID="lblEntityName" Text='<%# Bind("EntityName") %>'></asp:Literal>
                                                        <asp:HiddenField runat="server" ID="lblEventTitle" Value='<%# Bind("EventTitle") %>' />
                                                        <asp:HiddenField runat="server" ID="lblEventID" Value='<%# Bind("ID") %>' />
                                                        <%--<asp:Literal runat="server" ID="lblEventTitle" Text='<%# Bind("EventTitle") %>'></asp:Literal>--%>
                                                    </span>
                                                </aside>
                                            </ItemTemplate>
                                        </asp:ListView>
                                        <div class="cal_overlay" runat="server" id="divOverlay">
                                            <p>
                                                 <a class="eventClose visible-xs">&times;</a>
                                                <strong>
                                                    <asp:Literal runat="server" ID="lblDay1"></asp:Literal></strong>

                                                <asp:Literal runat="server" ID="lblEventSpanCount"></asp:Literal>
                                            </p>
                                            <asp:ListView runat="server" ID="lstEventList" OnItemDataBound="lstEventList_ItemDataBound" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lnkEvent">
                                                        <asp:HiddenField runat="server" ID="hdnEventID" Value='<%# Bind("ID") %>' />
                                                        <asp:HiddenField runat="server" ID="lblColor" Value='<%# Bind("Color") %>' />
                                                        <b runat="server" id="bTitle">
                                                            <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("EventTitle") %>'></asp:Literal></b>
                                                        <div class="overlay_contant">
                                                            <asp:Literal runat="server" ID="lblSummary" Text='<%# Bind("Summary") %>'></asp:Literal>
                                                        </div>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:ListView>
                                            <asp:ListView runat="server" ID="lstEventList1" OnItemDataBound="lstEventList_ItemDataBound" Visible="false">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lnkEvent">
                                                        <asp:HiddenField runat="server" ID="hdnEventID" Value='<%# Bind("ID") %>' />
                                                        <asp:HiddenField runat="server" ID="lblColor" Value='<%# Bind("Color") %>' />
                                                        <b runat="server" id="bTitle">
                                                            <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("EventTitle") %>'></asp:Literal></b>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ul>
                </div>
            </div>
        </div>
 <%--   </div>
</div>--%>



<%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

<script> 
    $(".dates_div .event_list_date").click(function (e) {
        $('.event_list_date.active').removeClass('active');
        $(this).addClass("active");
        e.stopPropagation();
    });

    $(".cal_overlay li, .dates_div .event_list_date").click(function (e) {
        e.stopPropagation();
    });

    $("body").click(function () {
        $(".dates_div .event_list_date").removeClass("active");
    });
	  </script>--%>
