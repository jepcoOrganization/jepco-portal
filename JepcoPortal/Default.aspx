<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Culture="en-US" UICulture="en-US" Async="true" EnableEventValidation="false" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>JEPCO-Portal</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>


        <header>
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-12 col-sm-12">
                        <div class="logo">
                            <a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/home">
                                <asp:Image ID="imgLogo" runat="server" ImageUrl='<%# Bind("Image") %>' />
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12">
                        <ul class="list-unstyled temperature">
                            <li>
                                <strong>
                                    <asp:Label ID="lblDayName" runat="server"></asp:Label>
                                </strong>
                                <asp:Label ID="lbldate" runat="server" class="LTR"></asp:Label>
                                <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                <asp:Label ID="lblYear" runat="server" class="LTR"></asp:Label>

                                <%--                                <span class="LTR">14</span>
                                <span>نيسان </span>
                                <span class="LTR">2020</span>--%>


                            </li>
                            <li>



                                <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="1000">
                                        </asp:Timer>
                                        <strong class="LTR">
                                          
                                             
                                            <asp:Literal ID="lblcurrenttime" runat="server" Text="" ></asp:Literal>
                                        </strong>
                                         <span>(غرينتش <span class="LTR">+3</span>) </span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>--%>



                                <strong class="LTR">
                                    <div id="time"></div>
                                </strong>
                                <span>(غرينتش <span class="LTR">+3</span>) </span>


                                <%-- <strong class="LTR">09:36 AM</strong>--%>
                               
                            </li>
                            <li>
                                <strong class="LTR">
                                    <label id="labelTempMax"></label>
                                    C</strong>
                                <span class="LTR">
                                    <label id="labelTempMin"></label>
                                    C</span>
                                <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/temp.png" alt="">
                            </li>
                        </ul>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12">
                        <span class="searchdiv">
                            <input type="text" placeholder="ادخل كلمات البحث">
                            <i class="fa fa-search"></i>
                        </span>
                        <span class="noti">
                             <a href="/ar/Home/MessagesAndNotificationsList">
                            <span class="uncheckmail">
                                <small>
                                   
                                    <asp:Label ID="unReadMSGCount" runat="server"></asp:Label>
                                      
                                </small>
                                <i class="fa fa-envelope-o"></i>
                            </span>
                                   </a>
                            <i class="fa fa-bell-o bell"></i>
                        </span>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </header>


        <div class="protal_menu">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">


                        <ul class="list-unstyled">
                            <asp:ListView runat="server" ID="lstNavigation" OnItemDataBound="lstNavigation_ItemDataBound">
                                <ItemTemplate>
                                    <li>

                                        <asp:HiddenField ID="hdnid" runat="server" Value='<%# Bind("ID") %>' />
                                        <asp:HyperLink runat="server" ID="lnkNav" NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("TargetID") %>'>

                                            <aside>
                                               <asp:Literal runat="server" ID="unReadMSgMenu"> </asp:Literal>
                                                <asp:Image ID="img" runat="server" ImageUrl='<%# Bind("MenuImage") %>' />
                                            </aside>

                                            <span>
                                                <asp:Literal ID="lblTitle" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                                            </span>
                                        </asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>

                        </ul>
                    </div>
                </div>
            </div>
        </div>


        <div class="protal_menu mobile_menu">
            <%--  <button>القائمة</button>--%>
            <a href="javascript:void(0);">القائمة</a>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="list-unstyled">
                            <asp:ListView runat="server" ID="lstMobileNavigation" OnItemDataBound="lstNavigation_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                         <asp:HiddenField ID="hdnid" runat="server" Value='<%# Bind("ID") %>' />
                                        <asp:HyperLink runat="server" ID="lnkNav" NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("TargetID") %>'>
                                             <asp:Literal runat="server" ID="unReadMSgMenu"> </asp:Literal>
                                            <asp:Image ID="img" runat="server" ImageUrl='<%# Bind("MenuImage") %>' />
                                            <span>
                                                <asp:Literal ID="lblTitle" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                                            </span>
                                        </asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>


                        </ul>
                    </div>
                </div>
            </div>
        </div>




        <section class="prrtal_mainpart">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-12 col-sm-12">
                        <button class="show_profilebtn">الملف الشخصي</button>
                        <div class="hidendiv">
                            <div class="profilediv">
                                <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Profile_pic.png" class="propic" alt="" />
                                <div class="welcm">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <small>اهلا وسهلا</small>
                                            <strong>
                                                <asp:Literal ID="lblUserName" runat="server"></asp:Literal>
                                                <asp:Literal ID="lblUserLastName" runat="server"></asp:Literal>
                                            </strong>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                            <small>&nbsp;</small>
                                            <p>
                                                اخر تسجيل دخول
                                                <asp:Literal ID="lblLastLogin" runat="server"></asp:Literal>
                                            </p>
                                            <asp:HiddenField runat="server" ID="hdhLastLoginId" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <small>
                                                <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/setting.png" alt="">
                                                الملف الشخصي </small>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6 text-right">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>

                                                    <asp:LinkButton runat="server" ID="logout" OnClick="logout_Click">

                                                  <small>
                                                <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/logout.png" alt="">
                                                تسجيل الخروج</small>

                                                    </asp:LinkButton>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>
                                </div>
                                <ul class="list-unstyled pro_list">
                                    <li>
                                        <strong>العنوان</strong>
                                        <asp:Literal ID="lblUserAddress" runat="server"></asp:Literal>
                                    </li>
                                    <li><strong>البريد الالكتروني</strong><asp:Literal ID="lblUSerEmail" runat="server"></asp:Literal></li>
                                    <li><strong>رقم الهاتف</strong><span class="LTR"><asp:Literal ID="lblUSerMobile" runat="server"></asp:Literal>
                                        <asp:HiddenField ID="hdnmobileno" runat="server" />
                                    </span></li>
                                    <li><strong>تاريخ التسجيل</strong><asp:Label ID="lblUSerRegiDate" runat="server" Style="font-family: Montserrat"></asp:Label></li>
                                </ul>
                            </div>
                            <ul class="list-unstyled service_list">


                                <asp:ListView runat="server" ID="lstBanner" OnItemDataBound="lstBanner_ItemDataBound">
                                    <ItemTemplate>
                                        <li class="libg1" runat="server" id="li">
                                            <asp:HyperLink runat="server" ID="lnkNav" NavigateUrl='<%# Bind("Link") %>' Target='<%# Bind("Target") %>'>
                                                <strong>
                                                    <asp:Literal ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Literal>
                                                </strong>
                                                <asp:Image ID="img" runat="server" ImageUrl='<%# Bind("BannerImage") %>' />

                                            </asp:HyperLink>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>


                            </ul>
                            <div class="opinion_matters">
                                <aside>
                                    <h1><small>التصويت</small>رأيك يهمنا </h1>
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/voting.png" alt="">
                                </aside>

                                <div class="check_box">
                                    <p>ما رأيك بالخدمات التي تقدمها البوابة الالكترونية لشركة الكهرباء</p>

                                    <%--<asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">ممتازة   <span class="checkmark" for="RadioButtonList2_0"></span></asp:ListItem>
                                        <asp:ListItem> جيدة <span class="checkmark" for="RadioButtonList2_1"></span></asp:ListItem>
                                        <asp:ListItem> مقبولة <span class="checkmark" for="RadioButtonList2_2"></span></asp:ListItem>
                                        <asp:ListItem>غير راضي <span class="checkmark" for="RadioButtonList2_3"></span></asp:ListItem>
                                    </asp:RadioButtonList>--%>
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">ممتازة </asp:ListItem>
                                        <asp:ListItem> جيدة </asp:ListItem>
                                        <asp:ListItem> مقبولة</asp:ListItem>
                                        <asp:ListItem>غير راضي </asp:ListItem>
                                    </asp:RadioButtonList>

                                </div>
                                <div class="vote">

                                    <button class="btn action-button" type="button" id="btbvalid" onclick="VoteClick();">تصويت</button>
                                    <asp:Button ID="btnVotes" runat="server" Text="تصويت" OnClick="btnVote_click" Style="display: none;" />

                                    <%-- <button>تصويت</button>--%>
                                    <a href="javascript:void">نتائج التصويت</a>
                                </div>

                            </div>
                            <div class="sidebar_tips">
                                <aside>
                                    <h1>
                                        <small>من اجل سلامتكم</small>
                                        نصائح ارشادية
                                    </h1>
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/info.png" alt="" />
                                </aside>
                                <div id="tips" class="owl-carousel">

                                    <asp:ListView runat="server" ID="lstDailyAdv">
                                        <ItemTemplate>

                                            <div class="item">
                                                <p>
                                                    <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                                </p>
                                                <asp:HyperLink runat="server" ID="lnkNav" NavigateUrl='<%# Bind("Link") %>' Target='<%# Bind("Target") %>'>
                                                     <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/left-arrow.png" alt="">
                                                </asp:HyperLink>

                                            </div>


                                        </ItemTemplate>
                                    </asp:ListView>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8 col-md-12 col-sm-12">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="mitarbg1 mitar_service">
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/tax.png" alt="">
                                    <strong>
                                        <label id="sumofBillsCount"></label>
                                    </strong>
                                    <span>الفواتير الغير مسددة </span>
                                    <p>على جميع الاشتراكات</p>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="mitarbg2 mitar_service">
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/money.png" alt="">
                                    <%--<strong>278,983</strong>--%>
                                    <strong>
                                        <label id="sumofBills"></label>
                                    </strong>
                                    <span>اجمالي المبلغ المطلوب</span>
                                    <p>على جميع الاشتراكات</p>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="mitarbg3 mitar_service">
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Energy.png" alt="">
                                    <strong>KW/h
                                        <label id="sumofconsumptionQty"></label>
                                    </strong>
                                    <span>استهلاك 12 شهرا لاشتراك</span>
                                    <p>
                                        <label id="FilesNumberlbl"></label>
                                    </p>
                                    <%-- <span>معدل استهلاك الطاقة</span>
                                    <p>على جميع الاشتراكات</p>--%>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="mitarbg4 mitar_service">
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/problem.png" alt="">
                                    <strong>
                                        <asp:Literal runat="server" ID="ComplainCount"></asp:Literal>
                                        <asp:HiddenField runat="server" ID="hndCountofCmpln" />
                                    </strong>
                                    <span>الشكاوى المقدمة</span>
                                </div>
                            </div>
                        </div>

                        <div class="protal_tabs">
                            <div class="Report_counter">


                                <a href="/ar/Home/ComplainForm">
                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/electric-meter.png" alt="">

                                    <strong>تقديم شكوى
                                    </strong>
                                </a>
                            </div>

                            <div id="Mytabs"></div>

                            

                            <!-- Tab panes -->

                            <div id="MyFileData" class="tab-content emptyfilecls">
                            </div>

                            
                        </div>

                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <div class="energy_consumption">
                                    <aside>
                                        <h1><small>الاستهلاك في الاربعة اشهر الاخيرة</small> معدل استهلاكك للطاقة</h1>
                                        <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/energy-icon.png" alt="">
                                    </aside>

                                    <div id="grphdiv">
                                        <div class="Counter_number">


                                            <p>
                                                <strong>رقم العداد</strong>
                                                <span class="LTR">
                                                    <label id="lblfileNo"></label>
                                                </span>
                                                منطقة
                                             :<label id="lblAreaGrapgh"></label>
                                                <a href="#" class="ahrefcallGraph">عدادات اخرى؟</a>
                                                <%--href="javascript:void"--%>
                                            </p>
                                            <%-- <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/graph.png" alt="">--%>
                                            <div class="canvasdiv" id="mycanvasdivs">
                                                <canvas id="ctx" width="450" height="250"></canvas>
                                            </div>


                                        </div>
                                    </div>
                                    <div id="grpnulldiv" class="emptyfilecls" style="display: none">
                                        <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-4.png" alt="">

                                        <strong>
                                            <a href="#" class="aheffuncation">اضافة/ تعديل رقم عداد</a>
                                        </strong>
                                    </div>

                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <div class="Complaints_submitted">
                                    <aside>
                                        <h1><small>متابعة الشكاوي التي تقدمت بها</small> الشكاوي المقدمة</h1>
                                        <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/problem-icon.png" alt="">
                                    </aside>

                                    <div class="complaints_box">


                                        <div id="CopmlainEmptyDiv" class="emptyfilecls" style="display: none" runat="server">
                                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-2.png" alt="">
                                            <strong>
                                                <a href="/ar/Home/ComplainForm" class="a_ComplainBox">تقديم شكوى جديدة</a>
                                            </strong>
                                        </div>
                                        <%-- style="height: 250px; width: 250px;"--%>



                                        <h5>
                                            <asp:Literal runat="server" ID="lblCountCoplains"></asp:Literal></h5>

                                        <%--<ul class="list-unstyled">--%>

                                        
                                        <div class='tab-pane fade in active'><div class='residential_sector'>

                                            <div class="content demo-y">
                                         
                                        <ul class="nav nav-tabs">
                                           

                                            <asp:ListView runat="server" ID="lstComplain" OnItemDataBound="lstComplain_ItemDataBound">
                                                <ItemTemplate>

                                                    <li>
                                                        <p>
                                                            <asp:Literal runat="server" ID="lblComplainType" Text='<%# Bind("ComplainType") %>'></asp:Literal>
                                                            <asp:Literal runat="server" ID="lblCompainDate" Text='<%# Bind("PublishedDate") %>'></asp:Literal>
                                                            <asp:HiddenField runat="server" ID="hdnCoplianStatusResult" Value='<%# Bind("IssueResultNo") %>' />
                                                            <asp:HiddenField runat="server" ID="hdnBranchID" Value='<%# Bind("Governate") %>' />
                                                            <%-- <small><span class="LTR">14</span> نيسان  <span class="LTR">2020</span></small>--%>
                                                        </p>
                                                        <div class="btndiv" id="ComplaiStatusbtndiv" runat="server">
                                                            <%--<button style="background: #f9db32; color: #007fc3;">قيد التنفيذ</button>--%>
                                                            <%--<button>التفاصيل</button>--%>
                                                        </div>
                                                    </li>

                                                </ItemTemplate>
                                            </asp:ListView>

                                            <%--<li>
                                                <p>
                                                    وصل التيار الكهربائي
                    <small><span class="LTR">14</span> نيسان  <span class="LTR">2020</span></small>
                                                </p>
                                                <div class="btndiv">
                                                    <button style="background: #f9db32; color: #007fc3;">قيد التنفيذ</button>
                                                    <button>التفاصيل</button>
                                                </div>
                                            </li>
                                            <li>
                                                <p>
                                                    وصل التيار الكهربائي
                    <small><span class="LTR">14</span> نيسان  <span class="LTR">2020</span></small>
                                                </p>
                                                <div class="btndiv">
                                                    <button style="background: #a4dfff;">تم حل المشكلة</button>
                                                    <button>التفاصيل</button>
                                                </div>
                                            </li>
                                            <li>
                                                <p>
                                                    وصل التيار الكهربائي
                    <small><span class="LTR">14</span> نيسان  <span class="LTR">2020</span></small>
                                                </p>
                                                <div class="btndiv">
                                                    <button style="background: #f2efef; color: #8a8a8a;">قيد المراجعة</button>
                                                    <button>التفاصيل</button>
                                                </div>
                                            </li>--%>

                                                

                                        </ul>


                                        </div></div></div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                            </div>
                        </div>


                        <%-- <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                               <div class="canvas_div">
        <canvas id="barChart" height="310"></canvas>
    </div>
                            </div></div>--%>



                        <div class="latest_news_company">
                            <aside>
                                <h1><small>تابع اهم واخر الاخبار والفعاليات</small> رأيك يهمنا</h1>
                                <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/new-icon.png" alt="">
                            </aside>

                            <div class="newsscroolsdiv">

                                <ul class="list-unstyled newslist">


                                    <asp:ListView runat="server" ID="lstNews" OnItemDataBound="lstNews_ItemDataBound">
                                        <ItemTemplate>
                                            <li>
                                                <div class="row">
                                                    <div class="col-lg-5 col-md-6 col-sm-6">
                                                        <div class="newimg">

                                                            <asp:Literal runat="server" ID="lblDate" Text='<%# Bind("NewsDate") %>'></asp:Literal>
                                                            <asp:HiddenField runat="server" ID="hdnNewsID" Value='<%# Bind("NewsID") %>' />
                                                            <asp:Image ID="imgNews" runat="server" ImageUrl='<%# Bind("NewsImage") %>' alt="" />
                                                            <%-- <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/E-1.jpg" alt="" />--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-7 col-md-6 col-sm-6">
                                                        <div class="newstext">
                                                            <h4>
                                                                <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("Headline") %>'></asp:Literal></h4>
                                                            <p>
                                                                <asp:Literal runat="server" ID="lbl" Text='<%# Bind("Summary") %>'></asp:Literal>
                                                            </p>

                                                            <%-- <a href="javascript:void">شاهد المزيد <i class="fa fa-long-arrow-left"></i></a>--%>
                                                            <asp:HyperLink runat="server" ID="lnkNews">
                                    شاهد المزيد <i class="fa fa-long-arrow-left"></i>
                                                            </asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>





                                </ul>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>

        <section class="subscribe_news">
            <div class="container">
                <div class="row">
                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>


                            <div class="col-lg-6 col-md-12 col-sm-12">
                                <div class="news">
                                    <strong>النشرة الإخبارية</strong>
                                    <span>اشترك في قائمتنا البريدية للحصول على آخر الأخبار على صندوق الوارد الخاص بك</span>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-sm-12">
                                <div class="subscribe">

                                    <asp:RequiredFieldValidator runat="server" CssClass="validator" ErrorMessage="" ID="RequiredFieldValidator4"
                                        ControlToValidate="txtSubscribe" Font-Size="11" Display="Dynamic" Text=""
                                        ForeColor="Red" ValidationGroup="grp1" EnableClientScript="false" SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="RequiredFieldValidator16" runat="server"
                                        CssClass="validator"
                                        ControlToValidate="txtSubscribe"
                                        ErrorMessage=""
                                        ForeColor="red"
                                        ValidationGroup="grp1"
                                        Display="Dynamic"
                                        ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                                        Style="color: Red; float: right; margin-top: 2%; margin-right: -1.5%;"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtSubscribe" runat="server" PlaceHolder="ادخل البريد الالكتروني "></asp:TextBox>
                                    <%-- <button onclick="EmailSendClick()">اشترك الآن</button>--%>
                                    <asp:Button ID="btnSubscribes" runat="server" Text="اشترك الآن" ValidationGroup="grp1" OnClick="btnSubscribes_click" />
                                    <%--<asp:LinkButton runat="server" ID="btnSubscribes" OnClick="btnSubscribes_click" Style="display: none;"></asp:LinkButton>--%>
                                </div>
                                <%--<div class="subscribe">
                            <input type="text" placeholder="ادخل البريد الالكتروني ">
                            <button>اشترك الآن</button>
                        </div>--%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </section>

        <!------------------------------------------------------------------->

        <div class="protal_copyright">
            <div class="container">
                <div class="row">
                    <div class="col-lg-5 col-md-7 col-sm-12">





                        <div class="ftsecondlink">


                            <asp:ListView runat="server" ID="lstSecondNavFooter1" OnItemDataBound="lstSecondNav_ItemDataBound">
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("Title") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("Target") %>'>
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:ListView>

                            <%--<asp:ListView runat="server" ID="lstSecondNavFooter1" OnItemDataBound="lstSecondNav_ItemDataBound">
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("MenuName") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("TargetID") %>'>
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:ListView>--%>
                            <%--  <a href="javascript:void">طلبات التوظيف</a>
                            <a href="javascript:void">أسئلة شائعة</a>
                            <a href="javascript:void">معرض الصور</a>
                            <a href="javascript:void">الشروط والاحكام</a>
                            <a href="javascript:void">خريطة الموقع</a>--%>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-5 col-sm-12">
                        <div class="ftsecondlink text-right">
                            <asp:ListView runat="server" ID="lstSecondNavFooter2" OnItemDataBound="lstSecondNav_ItemDataBound">
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("Title") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("Target") %>'>
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:ListView>

                            <%--<asp:ListView runat="server" ID="lstSecondNavFooter2" OnItemDataBound="lstSecondNav_ItemDataBound">
                                <ItemTemplate>

                                    <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("MenuName") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("TargetID") %>'>
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:ListView>--%>
                            <%-- <a href="javascript:void">امكانية الوصول</a>
                            <a href="javascript:void">الشروط و الأحكام</a>
                            <a href="javascript:void">سياسة الخصوصية</a>--%>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-12 col-sm-12">
                        <div class="followon">
                            <span>تابعونا على</span>
                            <asp:ListView runat="server" ID="lstSocialFooter" OnItemDataBound="lstSocial_ItemDataBound">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("Link") %>' Target='<%# Bind("Target") %>'>
                                        <asp:HiddenField runat="server" ID="imgURL" Value='<%# Bind("Imageover") %>' />
                                        <asp:Image ID="imgsocial" runat="server" ImageUrl='<%# Bind("Image") %>' />
                                    </asp:HyperLink>

                                </ItemTemplate>
                            </asp:ListView>
                            <%-- <a href="javascript:void" class="fa fa-youtube"></a>
                            <a href="javascript:void" class="fa fa-instagram"></a>
                            <a href="javascript:void" class="fa fa-twitter"></a>
                            <a href="javascript:void" class="fa fa-facebook"></a>--%>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <!------------------------------------------------------------------->

        <div class="copyright">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">

                        <asp:Literal ID="lblCopyright" runat="server"></asp:Literal>
                        <%-- <aside>
                            جميع الحقوق الملكية محفوظة <span style="font-family: 'Poppins', sans-serif;">2020</span>.<strong>جيبكو</strong>  ©     
                        </aside>
                        <small>|</small>
                        <aside>
                            <span>تصميم وتطوير بواسطة</span>
                            <a href="javascript:void">Auratechs Solutions </a>
                        </aside>--%>
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField runat="server" ID="htdFilenameDetais" />
        <asp:Button ID="lnkFileDetails" runat="server" Text="تصويت" OnClick="lnkFileDetails_Click" Style="display: none;" />
        <%-- <asp:HyperLink runat="server" ID="lnkFileDetails" onclick="ShowFileDetails" style="display:none"></asp:HyperLink>--%>
        <%-- <asp:LinkButton ID="lnkSubscribe" runat="server"></asp:LinkButton>
        <cc1:ModalPopupExtender runat="server" ID="mpeSuccess"
            TargetControlID="lnkSubscribe" BehaviorID="mpeSuccess"
            BackgroundCssClass="modalBackground" PopupControlID="panelNewsLetter"
            CancelControlID="btnNewLetterClose">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="panelNewsLetter" runat="server" CssClass="modalPopup d_model_popup l_modelpopup" Style="display: none">
            <div class="modal-dialog modal-md">
              
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="Title">
                            <h2>
                                <asp:Literal runat="server" ID="lblTitle">Message</asp:Literal>
                            </h2>
                        </div>
                        <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnNewLetterClose">&times;</asp:LinkButton>
                    </div>
                    <div class="modal-body">
                        <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                            <asp:Literal runat="server" ID="lblMessage">  
                                 Your email has been successfully registered
Thank you for Subscription.
                            </asp:Literal>
                        </div>
                    </div>
                    <div class="modal-footer">
                        
                        <asp:Button ID="Button8" runat="server" Text="Ok" CssClass="d_model_btn" type="button" OnClick="Button8_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>--%>

        <asp:LinkButton ID="lnkSubscribe" runat="server"></asp:LinkButton>
        <cc1:ModalPopupExtender runat="server" ID="mpeSuccess"
            TargetControlID="lnkSubscribe" BehaviorID="mpeSuccess"
            BackgroundCssClass="modalBackground" PopupControlID="panelNewsLetter"
            CancelControlID="btnClose">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="panelNewsLetter" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome in" Style="display: none; position: fixed; top: 0px; right: 0px; bottom: 0px; left: 0.5px; z-index: 1000001; overflow: hidden; outline: 0px;">
            <div class="modal-dialog modal-md">
                <!-- Modal content-->
                <div class="modal-content">

                    <div class="modal-header">


                        <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnClose"><span class="fa fa-close"></span></asp:LinkButton>
                        <h4 class="modal-title" id="myModalLabel">
                            <asp:Literal runat="server" ID="lblTitle" Text="م الاستلام بنجاح "></asp:Literal></h4>
                    </div>
                    <div class="modal-body">
                        <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                            <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                            <%--<p>
<asp:Literal runat="server" ID="lblInquiryMessage" Text="تم استلام معلومات سيرتك الذاتية بنجاح.">
</asp:Literal>
</p>--%>
                            <p>
                                <asp:Literal runat="server" ID="lblMessage" Text="شكرا لكم ">
                                </asp:Literal>
                            </p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button class="button" type="button" id="btnok" onclick="HidePopup();">موافق</button>
                        <%--<asp:Button ID="btn_ok" runat="server" data-dismiss="modal" Text="موافق" CssClass="button" type="button"  OnClick="Button8_Click" />--%>
                    </div>


                </div>
            </div>

        </asp:Panel>



        <div class="modal fade welcome" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span class="fa fa-close"></span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel123">اضافة ملف مرجعي جديد</h4>
                    </div>
                    <div class="modal-body popupForm">

                        <div class="step_form">

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label style="float: right">الرقم المرجعي </label>
                                        <input type="text" id="fileadddata" style="font-family: Montserrat" />
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label style="float: right">التسمية </label>
                                        <input type="text" id="Aliasadddata" style="font-family: Montserrat" />
                                    </div>
                                </div>

                            </div>


                            <%--  <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                      <label style="float:right">رقم الهاتف المحمول </label>
                        <input type="text" id="MobileNoadddata" />
                                    </div>
                                </div>

                            </div>--%>
                        </div>


                        <%--<img src="images/logo.png" alt="">--%>
                    </div>
                    <div class="modal-footer">
                        <button id="SubmitFillCall">حفظ</button>

                        <%-- <button>موافق</button>--%>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade welcome" id="myModalSucesss" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title" id="myModalLabel1234"></h4>
                    </div>
                    <div class="modal-body">
                        <h4>تم اضافة الملف المرجعي بنجاح</h4>
                    </div>
                    <div class="modal-footer">


                        <button>موافق</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade welcome" id="myModalFailed" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">

                        <h4 class="modal-title" id="myModalLabel123444"></h4>
                    </div>
                    <div class="modal-body">

                        <h4>
                            <label id="errroreCreate">
                            </label>
                        </h4>
                    </div>
                    <div class="modal-footer">


                        <button>موافق</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade welcome" id="myModalForFileGraph" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span class="fa fa-close"></span>
                        </button>
                        <h4 class="modal-title">قائمة العدادات المضافة</h4>
                    </div>
                    <div class="modal-body">
                        <div id="filegraph" class="protal_tabs"></div>
                    </div>

                </div>
            </div>
        </div>




        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
        <cc1:ModalPopupExtender runat="server" ID="ModalOTP"
            TargetControlID="LinkButton1" BehaviorID="ModalOTP"
            BackgroundCssClass="modalBackground" PopupControlID="panelOTP"
            CancelControlID="btnClose">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="panelOTP" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome in" Style="display: none; position: fixed; top: 0px; right: 0px; bottom: 0px; left: 0.5px; z-index: 1000001; overflow: hidden; outline: 0px;">
            <div class="modal-dialog modal-md">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel11">الرقم التعريفي الخاص بكم 
                        </h4>
                    </div>
                    <div class="modal-body">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                        <div class="step_form">

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <p>
                                            <asp:Literal runat="server" ID="lblOTPString" Text="أهلا وسهلا بكم في البوابة الالكترونية الخاصة بشركة الكهرباء الأردنية. الرجاء ادخال رقم التعريف الخاص بكم والذي تم ارساله الى الرقم "></asp:Literal>

                                            <asp:Label runat="server" ID="lblOTPMobile" Style='font-family: TimesNewRoman,Times,serif;'></asp:Label>
                                        </p>

                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">

                                        <asp:TextBox ID="txtOPT" runat="server" PlaceHolder="الرقم التعريفي"></asp:TextBox>
                                        <asp:Literal runat="server" ID="lblErroreOTP" Visible="false" Text="Invalid OTP"></asp:Literal>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Required Field" ID="RequiredFieldValidator3" Style="display: inline;"
                                            ControlToValidate="txtOPT" Display="Dynamic" Text="Required Field" ForeColor="Red" ValidationGroup="OTPValidation" EnableClientScript="True" />
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <asp:Button ID="btn_ok" runat="server" Text="موافق" CssClass="d_model_btn" type="button" OnClick="btn_ok_Click" />
                    </div>


                </div>
            </div>

        </asp:Panel>


        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>
        <script type="text/javascript" src="/Scripts/owl.carousel.min.js"></script>
        <%--  <script type="text/javascript"  src="js/jquery.mCustomScrollbar.concat.min.js"></script>--%>
        <script type="text/javascript" src="/Scripts/jquery.mCustomScrollbar.concat.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.min.js"></script>

        <%-- <script type="text/javascript" src="/Scripts/chartJs/Chart.min.js"></script>--%>

        <%--For Chart--%>




        <script>
            $("document").ready(function () {



                $.ajax({
                    type: "GET",
                    //contentType: "application/json; charset=utf-8",
                    url: "http://api.openweathermap.org/data/2.5/weather?lat=31.96&lon=35.95&units=metric&APPID=f6958e5632dd97b4efbb2b092a0573e2",
                    dataType: "json",
                    async: false,
                    success: function (data) {



                        var MaxTemp = data.main.temp_max;
                        var MinTemp = data.main.temp_min;
                        $("#labelTempMax").text(MaxTemp);
                        $("#labelTempMin").text(MinTemp);


                    },
                    error: function (result) {
                        //alert("Error");
                    }
                });

                var MobileNoURL = $("#hdnmobileno").val();

                var AllcustomerSubAccountList = [];

                var GetAllcustomerSubAccountList = [];
                var SumOfUnPaidBill = 0;
                var CountOfUnPaidBill = 0;
                var AllBillconsumptionQty = 0;
                var AllTab = [];
                var AllBills = [];
                var AllpaidBills = [];
                var AllunpaidBills = [];
                var ALLGraphdata = [];
                var AllFileForGraph = "";
                var DesingAllFileForGraph = "";
                //var apiConfiguUrl = '@System.Configuration.ConfigurationManager.AppSettings["MobileAPIurl"]';
                var apiConfiguUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["MobileAPIurl"].ToString() %>';
                //var ApiURLprofile = apiConfiguUrl + "profile/+962790121435";
                var ApiURLprofile = apiConfiguUrl + "profile/" + MobileNoURL;

                $.ajax({
                    type: "GET",
                    //contentType: "application/json; charset=utf-8",
                    //url: "https://mobile.jepco.com.jo:8443/JepcoMobApiProd/profile/+962790121435",    
                    url: ApiURLprofile,
                    dataType: "json",
                    async: false,
                    success: function (data) {

                        if (data.status == "success") {

                            var GetAllFile = data.body.customerSubAccountList;


                            if (GetAllFile.length > 0) {

                            }
                            else {
                                var imageofdiv2this123new = "<img src='<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/house1.png' class='backimg' >";
                                var Stringh5this123new = "<strong> <a href='#' class='aheffuncation'>اضافة/ تعديل رقم عداد</a></strong>";
                                var thisData123new = imageofdiv2this123new + Stringh5this123new;
                                $("#MyFileData").append(thisData123new);

                                $("#grphdiv").css("display", "none");
                                $("#grpnulldiv").css("display", "block");
                            }
                        }
                        else {
                            var imageofdiv2this123 = "<img src='<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/house1.png' class='backimg' >";
                            var Stringh5this123 = "<strong> <a href='#' class='aheffuncation'>اضافة/ تعديل رقم عداد</a></strong>";
                            var thisData123 = imageofdiv2this123 + Stringh5this123;
                            $("#MyFileData").append(thisData123);

                            $("#grphdiv").css("display", "none");
                            $("#grpnulldiv").css("display", "block");
                        }


                        var tab_Pop = "<div class='tab-content'>";
                        var StringUI123_pop = "<ul class='list-unstyled'>";
                        var HtmlScroolingdivHRD_pop = "<div class='content demo-y'>";
                        var ENDHtmlScroolingdivHRD123_pop = "</div>";
                        var EndStringUI123_pop = "</ul>";
                        var ENDtab_Pop = "</div>";


                        $.each(GetAllFile, function (key, value) {

                            var FileData = {};
                            var id = value.id;
                            var alias = value.alias;
                            var fileNumber = value.fileNumber;
                            var meterNumber = value.meterNumber;
                            var FileStusus = value.status;


                            FileData.id = id;
                            FileData.alias = alias;
                            FileData.fileNumber = fileNumber;
                            FileData.meterNumber = meterNumber;


                            AllcustomerSubAccountList.push(FileData);

                            var FileGrpData = {};
                            FileGrpData.fileNumber = fileNumber;

                            //if (value.status == "success") {
                            var HTMLLI_pop = "<li>";
                            var HTMLDiv1_pop = "<div><strong>التعريف</strong><span>" + alias + "</span></div>";
                            var HTMLDiv2_pop = "<div><strong> الرقم المرجعي</strong><p> " + fileNumber + " </p></div>"

                            var HTMLa_pop = "<a href='#' data-filename=" + fileNumber + " class='fileGraphChangecls' >عرض التفاصيل </a >";
                            var EndHTMLLI_pop = "</li>";


                            //var HTMLmyFileName = "<a  data-filename=" + fileNumber + " class='fileGraphChangecls'> " + fileNumber + "</a><br />";
                            var HTMLmyFileName = HTMLLI_pop + HTMLDiv1_pop + HTMLDiv2_pop + HTMLa_pop + EndHTMLLI_pop;

                            AllFileForGraph = AllFileForGraph + HTMLmyFileName;
                            //}


                            //console.log("FileNo is " + value.fileNumber);


                        });

                        DesingAllFileForGraph = tab_Pop + StringUI123_pop + HtmlScroolingdivHRD_pop + AllFileForGraph + ENDHtmlScroolingdivHRD123_pop + EndStringUI123_pop + ENDtab_Pop;
                        //console.log("Last Array Data " + AllcustomerSubAccountList);

                    },
                    error: function (result) {



                        var imageofdiv2this = "<img src='<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/house1.png' class='backimg'>";
                        var Stringh5this = "<strong> <a class='aheffuncation'>اضافة/ تعديل رقم عداد</a></strong>";
                        var thisData = imageofdiv2this + Stringh5this;
                        $("#MyFileData").append(thisData);

                        $("#grphdiv").css("display", "none");

                        $("#grpnulldiv").css("display", "block");
                        //alert("Error"); /App_Themes/ThemeAr/img/energy-icon.png
                    }
                });



                // $("#filegraph").append(AllFileForGraph);
                $("#filegraph").append(DesingAllFileForGraph);


                //console.log("oufdgfgt");
                //console.log("out" + AllcustomerSubAccountList);
                //console.log("545454545");
                //var ApiURLhistory = apiConfiguUrl + "history/+962790121435";
                var ApiURLhistory = apiConfiguUrl + "history/" + MobileNoURL;
                var FileCount = 1;
                var FileCountGraph = 1;

                //AllcustomerSubAccountList.reverse();
                $.each(AllcustomerSubAccountList, function (key, value) {

                    var FilecustomerData = {};
                    var GetFileNo = value.fileNumber;


                    var callURl = ApiURLhistory + "/" + GetFileNo;

                    if (FileCountGraph == 1) {
                        $('#lblfileNo').text(GetFileNo);

                    }


                    //$("#lblfileNo").text = GetFileNo;

                    var id = value.id;
                    var alias = value.alias;
                    var fileNumber = value.fileNumber;
                    var meterNumber = value.meterNumber;
                    var UnpaidBillCount = 0;
                    var UnpaidBillvalue = 0;
                    var UnpaidBillTabData = "";
                    var BillAreas = "";
                    var Fillstatus = "";



                    $.ajax({
                        type: "GET",
                        //contentType: "application/json; charset=utf-8",
                        url: callURl,
                        dataType: "json",
                        async: false,
                        success: function (data) {

                            if (data.status == "success") {

                                Fillstatus = "success";
                                // For Totol Unpaid Bill Amout Start ------------------------------------
                                SumOfUnPaidBill = parseFloat(SumOfUnPaidBill) + parseFloat(data.body.fileNumberInfo.mConBalance);
                                UnpaidBillvalue = parseFloat(data.body.fileNumberInfo.mConBalance);
                                UnpaidBillTabData = data.body.allBills[0].billHTMLData.values[3];
                                BillAreas = data.body.allBills[0].billHTMLData.values[1];
                                // For Totol Unpaid Bill Amout End  ------------------------------------

                                // For Totol Unpaid Bill Count Start  ------------------------------------                            
                                CountOfUnPaidBill = CountOfUnPaidBill + parseFloat(data.body.unpaidBills.length);
                                UnpaidBillCount = parseFloat(data.body.unpaidBills.length);
                                // For Totol Unpaid Bill Count End  ------------------------------------

                                // For All Bill consumptionQty Start  ------------------------------------
                                var GetAllBillconsumptionQty = data.body.allBills;
                                var FileCountloop = 1;
                                var GraphMonthLoop = 1;

                                $.each(GetAllBillconsumptionQty, function (key, value) {
                                    var consQty = value.consumptionQty;
                                    var consMonth = value.readDate;
                                    //AllBillconsumptionQty = AllBillconsumptionQty + parseFloat(consQty);
                                    //For Tabs Start  ------------------------------------

                                    var TabFileData = {};


                                    var tabNAme = value.billHTMLData.values[3];

                                    TabFileData.tabNAme = tabNAme;


                                    AllTab.push(tabNAme);
                                    //For Tabs End ------------------------------------

                                    if (FileCountGraph == 1) {

                                        AllBillconsumptionQty = AllBillconsumptionQty + parseFloat(consQty);
                                        var Fno = GetFileNo;
                                        $("#FilesNumberlbl").text(Fno);



                                        if (GraphMonthLoop <= 4) {
                                            var Graphdata = {};
                                            var BillMonth = consMonth;
                                            var BillConQTY = consQty;

                                            Graphdata.BillMonth = BillMonth;
                                            Graphdata.BillConQTY = BillConQTY;

                                            //ALLGraphdata.push(Graphdata);
                                            ALLGraphdata.push(Graphdata);
                                            GraphMonthLoop++;
                                        }
                                        var AreasNAme = value.billHTMLData.values[1];
                                        $("#lblAreaGrapgh").text(AreasNAme);


                                    }



                                });
                                // For All Bill consumptionQty End ------------------------------------


                                //var HtmlScroolingdivHRD123 = "<div class='content demo-y'>";
                                //var StringUI123 = "<ul class='list-unstyled'>";
                                //var EndStringUI123 = "</ul>";
                                //var ENDHtmlScroolingdivHRD123 = "</div>";

                                //$.each(GetAllBillconsumptionQty, function (key, value) {

                                //    var PFileName = value.fileNumber;
                                //    var PFileAlea = value.billHTMLData.values[1];



                                //    var HTMLLI_123 = "<li>";
                                //    var HTMLDiv1_123 = "<div><strong>رقم العداد</strong><span class='LTR'>" + SubAccountListValue.fileNumber + "</span><p>المنطقة: " + SubAccountListValue.area + " </p></div>";
                                //    var HTMLDiv2_123 = "<div><strong>الفواتير الغير مسددة</strong><p>لديك عدد " + SubAccountListValue.UnpaidBillCount + " فواتير غير مسددة</p></div>"
                                //    var HTMLDiv3_123 = "<div><strong>القيمة المطلوبة</strong><p>اجمالي المبلغ المطلوب " + SubAccountListValue.UnpaidBillvalue + "</p></div>"
                                //    var HTMLa_123 = "<a href='#' data-filename=" + SubAccountListValue.fileNumber + " class='GoFileDetails' >التفاصيل </a >";
                                //    var EndHTMLLI_123 = "</li>";


                                //});

                                //var getPopupFileDetails = HtmlScroolingdivHRD123 + StringUI123 + EndStringUI123 + ENDHtmlScroolingdivHRD123;


                                FileCount++;


                            }
                            else {
                                Fillstatus = "error";


                            }



                        },
                        error: function (result) {
                            // alert("Errorinhistory");
                        }
                    });
                    FilecustomerData.Fillstatus = Fillstatus;
                    FilecustomerData.id = id;
                    FilecustomerData.alias = alias;
                    FilecustomerData.area = BillAreas;
                    FilecustomerData.fileNumber = fileNumber;
                    FilecustomerData.meterNumber = meterNumber;
                    FilecustomerData.UnpaidBillCount = UnpaidBillCount;
                    FilecustomerData.UnpaidBillvalue = UnpaidBillvalue;
                    FilecustomerData.UnpaidBillTabData = UnpaidBillTabData;
                    GetAllcustomerSubAccountList.push(FilecustomerData);

                    FileCountGraph++;
                });



                var TotalUnpaid = parseFloat(SumOfUnPaidBill);
                $('#sumofBills').text(TotalUnpaid.toFixed(2));

                var TotalUnpaidCount = parseFloat(CountOfUnPaidBill);
                $('#sumofBillsCount').text(TotalUnpaidCount);

                var TotalconsumptionQty = parseFloat(AllBillconsumptionQty);
                $('#sumofconsumptionQty').text(TotalconsumptionQty);
                //$("#sumofBills").text(TotalUnpaid);

                //console.log(AllTab);

                var uniqueTabs = [];
                $.each(AllTab, function (i, el) {
                    if ($.inArray(el, uniqueTabs) === -1) uniqueTabs.push(el);
                });


                var intloopForTab = 1;
                var htmlScroolDiv = "<div class='resi_indu_comm'><div class='content demo-x'>";


                var stringStartDiv = "<ul class='nav nav-tabs' role='tablist'>";
                var allHtml = "";
                $.each(uniqueTabs, function (key, value) {
                    //$.each(outputArrTab, function (key, value) {

                    var Li = "";
                    if (intloopForTab == 1) {
                        Li = "<li role='presentation' class='active'>";
                    }
                    else {
                        Li = "<li role='presentation'>";
                    }

                    var a = "<a href='#home" + intloopForTab + "' aria-controls='home' role='tab' data-toggle='tab'>";
                    var divicon = "<div class='icon'>";
                    var imageofdiv = "<img src='<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/house.png'  class='frontimg'>";
                    var imageofdiv2 = "<img src='<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/house1.png' class='backimg'>";
                    var Closedivicon = "</div>";
                    var CloseA = "</a>";
                    var CloseLi = "</li>";

                    var Html = Li + a + divicon + imageofdiv + imageofdiv2 + Closedivicon + value + CloseA + CloseLi;
                    allHtml = allHtml + Html;
                    intloopForTab++;
                    //<a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">




                });
                var stringendDiv = "</ul>";
                var EndhtmlScroolDiv = "</div></div>"

                var Totaldiv = htmlScroolDiv + stringStartDiv + allHtml + stringendDiv + EndhtmlScroolDiv;
                $("#Mytabs").append(Totaldiv);

                //console.log("AllForFiles" + GetAllcustomerSubAccountList);


                var countoutputArrTab = 1;
                var HtmlMyDivData = "";
                $.each(uniqueTabs, function (key, value) {

                    var StringDivtabpanel = "";
                    if (countoutputArrTab == 1) {
                        StringDivtabpanel = "<div role='tabpanel' class='tab-pane fade in active' id='home" + countoutputArrTab + "'> <div class='residential_sector' >"
                    } else {
                        StringDivtabpanel = "<div role='tabpanel' class='tab-pane fade' id='home" + countoutputArrTab + "'><div class='residential_sector' >"
                    }

                    var DetialList = "";
                    var CountData = "";

                    var LiHtmlDatas = GetFileDetialList(value, DetialList);
                    var Countdata = parseFloat(LiHtmlDatas[1]) - 1;

                    var Stringh5 = "<h5> متوفر لديك عدد " + Countdata + " عدادات في " + value + " مسجلة <a href='#' class='aheffuncation'>اضافة/ تعديل رقم عداد</a></h5>";
                    // var Stringh5 = "<h5> " + value + " لديك عدد " + Countdata + " عدادات في   <a class='aheffuncation'>اضافة/ تعديل رقم عداد</a></h5>";
                    var HtmlScroolingdivHRD = "<div class='content demo-y'>";
                    var StringUI = "<ul class='list-unstyled'>";
                    var EndStringUI = "</ul>";
                    var ENDHtmlScroolingdivHRD = "</div>";
                    var ENDStringDivtabpanel = "</div></div>";

                    var AllDesign = StringDivtabpanel + Stringh5 + StringUI + HtmlScroolingdivHRD + LiHtmlDatas[0] + EndStringUI + ENDHtmlScroolingdivHRD + ENDStringDivtabpanel;
                    HtmlMyDivData = HtmlMyDivData + AllDesign;

                    countoutputArrTab++;
                });
                $("#MyFileData").append(HtmlMyDivData);




                function GetFileDetialList(value, DetialList) {



                    var countAllSubList = 1;
                    var AllLiHTML = "";
                    var AllLiContalt = "";

                    $.each(GetAllcustomerSubAccountList, function (key, SubAccountListValue) {

                        if (SubAccountListValue.Fillstatus == "success") {

                            if (value === SubAccountListValue.UnpaidBillTabData) {
                                var HTMLLI = "<li>";
                                var HTMLDiv1 = "<div><strong>رقم العداد</strong><span class='LTR'>" + SubAccountListValue.fileNumber + "</span><p>المنطقة: " + SubAccountListValue.area + " </p></div>";
                                var HTMLDiv2 = "<div><strong>الفواتير الغير مسددة</strong><p>لديك عدد " + SubAccountListValue.UnpaidBillCount + " فواتير غير مسددة</p></div>"
                                var HTMLDiv3 = "<div><strong>القيمة المطلوبة</strong><p>اجمالي المبلغ المطلوب " + SubAccountListValue.UnpaidBillvalue + "</p></div>"
                                var HTMLa = "<a href='#' data-filename=" + SubAccountListValue.fileNumber + " class='GoFileDetails' >التفاصيل </a >";
                                var EndHTMLLI = "</li>";

                                AllLiHTML = HTMLLI + HTMLDiv1 + HTMLDiv2 + HTMLDiv3 + HTMLa + EndHTMLLI
                                AllLiContalt = AllLiContalt + AllLiHTML;

                                countAllSubList++;

                            }

                        }

                    });

                    var arr = [AllLiContalt, countAllSubList];
                    return arr;

                    //DetialList = AllLiContalt;
                    //return DetialList;
                }

                $(".aheffuncation").click(function () {

                    $('#myModal').modal('show');
                });




                $(".ahrefcallGraph").click(function () {

                    $('#myModalForFileGraph').modal('show');
                });

                $("#SubmitFillCall").click(function () {
                    event.preventDefault();


                    var aliasNAme = $("#Aliasadddata").val();
                    var fileNumberNAme = $("#fileadddata").val();
                    var mobileNumberNAme = MobileNoURL; // $("#MobileNoadddata").val();



                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "https://mobile.jepco.com.jo:8443/JepcoMobApiProd/sub/create",

                        // data: JSON.stringify({ alias: 'myATest', fileNumber: '0110892277693', mobileNumber: '+962790121435' }),
                        data: JSON.stringify({ alias: aliasNAme, fileNumber: fileNumberNAme, mobileNumber: mobileNumberNAme }),
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            // alert("Call Success");
                            $('#myModal').modal('hide');
                            $('#myModalSucesss').modal('show');


                        },
                        error: function (result) {

                            console.log(result);
                            //alert("Error");

                            //var absajdvbajsd = result.responseJSON.key;
                            $('#myModal').modal('hide');
                            $("#errroreCreate").text(absajdvbajsd);
                            $('#myModalFailed').modal('show');


                        }
                    });

                });

                if (ALLGraphdata.length < 4) {

                    var AryLength = ALLGraphdata.length;
                    for (var i = AryLength; i < 5; i++) {

                        var Graphdata = {};
                        var BillMonth = "0000-01";
                        var BillConQTY = "0";
                        var abcd = BillMonth;
                        //var myString = abcd.split("-").pop();
                        //var converm = parseFloat(myString);

                        //var streetaddress = BillMonth.split('-')[0];
                        //var abcd2 = streetaddress + "-" + months[converm];

                        //var abcd2 = months[converm];


                        Graphdata.BillMonth = BillMonth;
                        Graphdata.BillConQTY = BillConQTY;
                        //Graphdata.BillMonthString = abcd2;





                        ALLGraphdata.push(Graphdata);


                    }
                }



                var chart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: [[ALLGraphdata[0].BillMonth, ALLGraphdata[0].BillConQTY], [ALLGraphdata[1].BillMonth, ALLGraphdata[1].BillConQTY], [ALLGraphdata[2].BillMonth, ALLGraphdata[2].BillConQTY], [ALLGraphdata[3].BillMonth, ALLGraphdata[3].BillConQTY]],// responsible for how many bars are gonna show on the chart
                        //labels: [["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"]],// responsible for how many bars are gonna show on the chart
                        // create 12 datasets, since we have 12 items
                        // data[0] = labels[0] (data for first bar - 'Standing costs') | data[1] = labels[1] (data for second bar - 'Running costs')
                        // put 0, if there is no data for the particular bar
                        datasets: [{
                            label: 'Washing and cleaning',
                            data: [ALLGraphdata[0].BillConQTY, ALLGraphdata[1].BillConQTY, ALLGraphdata[2].BillConQTY, ALLGraphdata[3].BillConQTY],
                            //data: [5, 8, 2, 4, 6, 4, 5, 6, 7, 8, 2, 4],
                            backgroundColor: '#a4dfff'
                        }, {
                            //label: 'Traffic tickets',
                            //data: [5, 2, 8, 6, 4, 6, 5, 4, 3, 2, 8, 6],
                            //backgroundColor: '#f2efef'
                        }]
                    },
                    options: {
                        responsive: false,
                        legend: false,
                        showLine: false,
                        responsive: false,
                        maintainAspectRatio: false,
                        tooltips: {
                            enabled: false
                        },
                        scales: {
                            xAxes: [{
                                barThickness: 70,
                                stacked: true, // this should be set to make the bars stacked
                                gridLines: {
                                    drawOnChartArea: false,
                                    drawBorder: false,
                                    display: false
                                },
                                ticks: {
                                    fontFamily: "",
                                    fontColor: "#007fc3",
                                    fontSize: 14,
                                    padding: 50
                                }
                            }],
                            yAxes: [{
                                stacked: true, // this also..
                                gridLines: {
                                    drawOnChartArea: false,
                                    drawBorder: false,
                                    display: false
                                },
                                ticks: {
                                    display: false, //this will remove only the label

                                }
                            }]
                        }
                    }
                });


                $(".fileGraphChangecls").click(function () {

                    var filename = $(this).data("filename");
                    //alert(filename);
                    var callFileURl = ApiURLhistory + "/" + filename;
                    $('#lblfileNo').text(filename);
                    $("#FilesNumberlbl").text(filename);

                    $.ajax({
                        type: "GET",
                        //contentType: "application/json; charset=utf-8",
                        url: callFileURl,
                        dataType: "json",
                        async: false,
                        success: function (data) {

                            if (data.status == "success") {

                                AllBillconsumptionQty = 0;
                                var GetAllBillconsumptionQty2 = data.body.allBills;
                                ALLGraphdata = [];
                                var GraphMonthLoopChn = 1;
                                $.each(GetAllBillconsumptionQty2, function (key, value) {

                                    var consQty = value.consumptionQty;
                                    var consMonth = value.readDate;

                                    if (GraphMonthLoopChn == 1) {
                                        var Myareas = value.billHTMLData.values[1];
                                        $("#lblAreaGrapgh").text(Myareas);
                                    }


                                    if (GraphMonthLoopChn <= 4) {
                                        var Graphdata = {};
                                        var BillMonth = consMonth;
                                        var BillConQTY = consQty;

                                        Graphdata.BillMonth = BillMonth;
                                        Graphdata.BillConQTY = BillConQTY;

                                        //ALLGraphdata.push(Graphdata);
                                        ALLGraphdata.push(Graphdata);


                                        GraphMonthLoopChn++;
                                    }
                                    AllBillconsumptionQty = AllBillconsumptionQty + parseFloat(consQty);
                                    var TotalconsumptionQtyChange = parseFloat(AllBillconsumptionQty);
                                    $('#sumofconsumptionQty').text(TotalconsumptionQtyChange);
                                });




                            }
                            else {
                                Fillstatus = "error";
                            }



                        },
                        error: function (result) {
                            // alert("Errorinhistory");
                        }
                    });



                    //-------------------------------------------------------
                    $('#ctx').remove(); // this is my <canvas> element
                    $('#mycanvasdivs').append('<canvas id="ctx" width="450" height="250"></canvas>');



                    var chart = new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: [[ALLGraphdata[0].BillMonth, ALLGraphdata[0].BillConQTY], [ALLGraphdata[1].BillMonth, ALLGraphdata[1].BillConQTY], [ALLGraphdata[2].BillMonth, ALLGraphdata[2].BillConQTY], [ALLGraphdata[3].BillMonth, ALLGraphdata[3].BillConQTY]],// responsible for how many bars are gonna show on the chart
                            //labels: [["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"]],// responsible for how many bars are gonna show on the chart
                            // create 12 datasets, since we have 12 items
                            // data[0] = labels[0] (data for first bar - 'Standing costs') | data[1] = labels[1] (data for second bar - 'Running costs')
                            // put 0, if there is no data for the particular bar
                            datasets: [{
                                label: 'Washing and cleaning',
                                data: [ALLGraphdata[0].BillConQTY, ALLGraphdata[1].BillConQTY, ALLGraphdata[2].BillConQTY, ALLGraphdata[3].BillConQTY],
                                //data: [5, 8, 2, 4, 6, 4, 5, 6, 7, 8, 2, 4],
                                backgroundColor: '#a4dfff'
                            }, {
                                //label: 'Traffic tickets',
                                //data: [5, 2, 8, 6, 4, 6, 5, 4, 3, 2, 8, 6],
                                //backgroundColor: '#f2efef'
                            }]
                        },
                        options: {
                            responsive: false,
                            legend: false,
                            showLine: false,
                            responsive: false,
                            maintainAspectRatio: false,
                            tooltips: {
                                enabled: false
                            },
                            scales: {
                                xAxes: [{
                                    barThickness: 70,
                                    stacked: true, // this should be set to make the bars stacked
                                    gridLines: {
                                        drawOnChartArea: false,
                                        drawBorder: false,
                                        display: false
                                    },
                                    ticks: {
                                        fontFamily: "",
                                        fontColor: "#007fc3",
                                        fontSize: 14,
                                        padding: 50
                                    }
                                }],
                                yAxes: [{
                                    stacked: true, // this also..
                                    gridLines: {
                                        drawOnChartArea: false,
                                        drawBorder: false,
                                        display: false
                                    },
                                    ticks: {
                                        display: false, //this will remove only the label

                                    }
                                }]
                            }
                        }
                    });

                    $('#myModalForFileGraph').modal('hide');

                });



                $(".GoFileDetails").click(function () {

                    var filename = $(this).data("filename");
                    $('#<%=htdFilenameDetais.ClientID %>').val(filename);

                    $("[id*=<%=lnkFileDetails.ClientID %>]").click();

                    // Session["FileNumberDetails"] = filename;
                    // alert(Session["FileNumberDetails"]);

                });


            });




        </script>




        <script>
            (function ($) {
                $(window).on("load", function () {

                    $.mCustomScrollbar.defaults.theme = "light-2"; //set "light-2" as the default theme

                    $(".demo-y").mCustomScrollbar();

                    $(".demo-x").mCustomScrollbar({
                        axis: "x",
                        advanced: { autoExpandHorizontalScroll: true }
                    });

                    $(".demo-yx").mCustomScrollbar({
                        axis: "yx"
                    });

                    $(".scrollTo a").click(function (e) {
                        e.preventDefault();
                        var $this = $(this),
                            rel = $this.attr("rel"),
                            el = rel === "content-y" ? ".demo-y" : rel === "content-x" ? ".demo-x" : ".demo-yx",
                            data = $this.data("scroll-to"),
                            href = $this.attr("href").split(/#(.+)/)[1],
                            to = data ? $(el).find(".mCSB_container").find(data) : el === ".demo-yx" ? eval("(" + href + ")") : href,
                            output = $("#info > p code"),
                            outputTXTdata = el === ".demo-yx" ? data : "'" + data + "'",
                            outputTXThref = el === ".demo-yx" ? href : "'" + href + "'",
                            outputTXT = data ? "$('" + el + "').find('.mCSB_container').find(" + outputTXTdata + ")" : outputTXThref;
                        $(el).mCustomScrollbar("scrollTo", to);
                        output.text("$('" + el + "').mCustomScrollbar('scrollTo'," + outputTXT + ");");
                    });

                });
            })(jQuery);
        </script>


        <script>
            $("document").ready(function () {


                function checkTime(i) {
                    if (i < 10) {
                        i = "0" + i;
                    }
                    return i;
                }

                function startTime() {

                    var today = new Date();
                    var h = today.getHours();
                    var m = today.getMinutes();
                    var s = today.getSeconds();


                    //m = checkTime(m);
                    //s = checkTime(s);
                    document.getElementById('time').innerHTML = h + ":" + m + ":" + s;

                    //var livetime = new Date().toString("hh:mm tt");
                    //document.getElementById('time').innerHTML = livetime;

                    t = setTimeout(function () {
                        startTime()
                    }, 500);


                }
                startTime();






                $('#<%=RadioButtonList2.ClientID  %>_0').next('label').addClass("container-checkbox");
                $('#<%=RadioButtonList2.ClientID  %>_1').next('label').addClass("container-checkbox");
                $('#<%=RadioButtonList2.ClientID  %>_2').next('label').addClass("container-checkbox");
                $('#<%=RadioButtonList2.ClientID  %>_3').next('label').addClass("container-checkbox");

                $('#<%=RadioButtonList2.ClientID  %>_0').addClass("rdoBig");
                $('#<%=RadioButtonList2.ClientID  %>_1').addClass("rdoBig");
                $('#<%=RadioButtonList2.ClientID  %>_2').addClass("rdoBig");
                $('#<%=RadioButtonList2.ClientID  %>_3').addClass("rdoBig");

              <%-- $('#<%=RadioButtonList2.ClientID  %>_0').next('span').addClass("checkmark");
                $('#<%=RadioButtonList2.ClientID  %>_1').next('span').addClass("checkmark");
                $('#<%=RadioButtonList2.ClientID  %>_2').next('span').addClass("checkmark");
                $('#<%=RadioButtonList2.ClientID  %>_3').next('span').addClass("checkmark");--%>


               <%-- $("[id*=<%=RadioButtonList2.ClientID %>]").change(function () {
                     
                   // $("[id*=<%=RadioButtonList2.ClientID %>]").removeClass();
                    $(this).next('label').addClass("checkmark");

                    $(this).next('label').prop("checked", true);
                    //$(this).addClass('mychecked');
                });--%>

            });

        </script>


        <script>
            jQuery("#tips").owlCarousel({
                autoplay: true,
                // loop: true,
                margin: 10,
                responsiveClass: true,
                rtl: true,
                dots: true,
                nav: false,
                responsive: {
                    0: {
                        items: 1
                    },

                    600: {
                        items: 1
                    },

                    1024: {
                        items: 1
                    }
                }
            });
        </script>

        <script>
            $(".show_profilebtn").click(function () {
                $(".hidendiv").slideToggle();
            });

            $(".mobile_menu button").click(function () {
                $(".mobile_menu .container").slideToggle();
            });


        </script>

        <!-- Global site tag (gtag.js) - Google Analytics -->
        <script async src="https://www.googletagmanager.com/gtag/js?id=UA-169198484-1"></script>
        <script>
            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', 'UA-169198484-1');
        </script>

        <script>
            function VoteClick() {
                $("[id*=<%=btnVotes.ClientID %>]").click();
            }
        </script>

        <style>
            .subscribe input[type="submit"] {
                background: #007fc3;
                color: #fff;
                height: 80px;
                width: 165px;
                font-size: 20px;
                padding: 10px;
                border: none;
            }

            .vote #btbvalid {
                background: #007fc3;
                color: #fff;
                font-size: 21px;
                border: none;
                width: 200px;
                line-height: 60px;
                text-align: center;
                font-weight: bold;
            }

            /*input#RadioButtonList2_0 {display: none;}
            input#RadioButtonList2_1 {display: none;}
            input#RadioButtonList2_2 {display: none;}
            input#RadioButtonList2_3 {display: none;}*/



            .container-checkbox input:checked ~ .checkmark {
                background-color: #007fc3;
            }

            .container-checkbox input:checked ~ span.checkmark {
                background-color: #007fc3;
            }

            .check_box .rdoBig {
                height: 20px;
                width: 20px;
            }

            .emptyfilecls {
                text-align: center;
            }

                a.aheffuncation,
                .emptyfilecls a.ahrefcallGraph {
                    display: table;
                    margin: 20px auto 0;
                }


            .welcome .popupForm {
                text-align: center;
                padding: 50px 100px;
            }

            #myModalForFileGraph .modal-body {
                padding: 0;
            }

            #filegraph {
                margin: 0;
            }

            .aheffuncation {
                color: #23527c;
                font-size: 18px;
            }

            .emptyfilecls {
                padding: 40px;
            }

            .protal_tabs .tab-content h5 a {
                margin: 0;
                display: inherit;
            }

            .residential_sector h5 {
                margin-bottom: 20px;
            }

            input#btn_ok {
                background: #007fc3;
                color: #fff;
                font-size: 24px;
                font-weight: bold;
                border: none;
                width: 100%;
                max-width: 200px;
                line-height: 60px;
            }

            div#panelOTP:before {
                content: "";
                background: rgb(0 0 0 / 0.7);
                position: absolute;
                width: 100%;
                height: 100%;
                top: 0;
                left: 0;
            }

            .complaints_box .btndiv a {
                background: #007fc3;
                color: #fff;
                font-size: 18px;
                border: none;
                width: 130px;
                line-height: 60px;
                margin-left: 10px;
                text-align: center;
            }

            .Report_counter strong {
                color: white;
            }

            #CopmlainEmptyDiv a {
                display: table;
                margin: 20px auto 0;
                color: #007fc3;
                font-size: 18px;
            }

            #CopmlainEmptyDiv img {
            }

            .emptyfilecls img {
            }

            .mCS-light-2.mCSB_scrollTools
            .mCSB_dragger
            .mCSB_dragger_bar,
            .mCS-dark-2.mCSB_scrollTools
            .mCSB_dragger
            .mCSB_dragger_bar,
            .mCS-light-2.mCSB_scrollTools
            .mCSB_dragger:hover
            .mCSB_dragger_bar 
            {
                 background-color: rgb(0 127 195);
            }
        </style>


        <script>
            $(".show_profilebtn").click(function () {

                $(".hidendiv").slideToggle();
            });

            $(".mobile_menu button").click(function () {
                $(".mobile_menu .container").slideToggle();
            });

            $(".mobile_menu a").click(function () {
                $(".mobile_menu .container").slideToggle();
            });


        </script>

        <script>
            $("document").ready(function () {

                debugger;
                // var fsjdf = $("[id$=ComplainCount]").text();
                var fsjdf = $("[id$=hndCountofCmpln]").val();
                debugger;

                for (var i = 0; i < fsjdf; i++) {


                    var statusResul = $("#lstComplain_hdnCoplianStatusResult_" + i).val();
                    var StutuBtranchid = $("#lstComplain_hdnBranchID_" + i).val();

                    var StatusID = "0";

                    $.ajax({

                        type: "POST",
                        url: "/Default.aspx/GetComplainStatus",
                        data: "{RefCode:'" + statusResul + "',BranchID:'" + StutuBtranchid + "'}",
                        contentType: "application/json; charset-utf-8",
                        dataType: "json",
                        async: false,

                        //contentType: 'application/json',
                        // data: govidSelected //JSON.stringify(govidSelected),

                        success: function (result) {
                            console.log(result);

                            StatusID = result.d;



                            $.ajax({
                                type: "POST",
                                url: "/Default.aspx/BindCopalianStstubyID",
                                data: "{CompalinStatusID:'" + StatusID + "',StutuBtranchid:'" + StutuBtranchid + "'}",
                                contentType: "application/json; charset-utf-8",
                                dataType: "json",
                                async: false,
                                success: function (result) {
                                    console.log(result);
                                    var ThisStatu = "";
                                    $.each(result.d, function (key, value) {
                                        ThisStatu = value.StatusName;
                                        //$("#ddlGeove").append($("<option></option>").val(value.BranchID).html(value.desc1));
                                    });

                                    //$("#lstComplain_ComplaiStatusbtndiv_" + i).append("<button style='background: #f9db32; color: #007fc3;'>" + ThisStatu + "</button> <button href='/ar/Home/ComplainList'>التفاصيل</button> <a href='/ar/Home/ComplainList'>	تقديم شكوى جديدة</a>");
                                    //$("#lstComplain_ComplaiStatusbtndiv_" + i).append("<button style='background: #f9db32; color: #007fc3;'>" + ThisStatu + "</button> <a href='/ar/Home/ComplainList'>التفاصيل</a>");
                                    $("#lstComplain_ComplaiStatusbtndiv_" + i).append("<a style='background: #f9db32; color: #007fc3;'>" + ThisStatu + "</a> <a href='/ar/Home/ComplainList'>التفاصيل</a>");

                                },
                                error: function (result) {
                                    // alert(result.status + " : " + result.StatusText);
                                }
                            });
                        },
                        error: function (result) {
                            // alert(result.status + " : " + result.StatusText);
                        }
                    });





                }


            });


        </script>

    </form>
</body>
</html>
