<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceStepPage.aspx.cs" Inherits="Pages_ServiceStepPage" Async="true" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">





    <section class="inner_banner">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 col-md-7 col-sm-12">
                    <div class="innerbannerheading">
                        <ol class="breadcrumb">
                            <%--<li><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">Home</a></li>--%>
                            <li><a href="<%= (Session["CurrentLanguage"].ToString() == Convert.ToInt32(EnumLanguage.Arabic).ToString() ? "/ar" : "/en") %>/Home">الصفحة الرئيسية</a></li>

                            <li runat="server" id="lstParent" class="active" visible="false">
                                <asp:HyperLink ID="lnkParentName" runat="server" NavigateUrl='<%# Bind("AliasPath") %>' Target='<%# Bind("Target") %>' Text='<%# Bind("MenuName") %>'></asp:HyperLink>
                            </li>

                        </ol>
                        <aside>
                            <asp:Literal ID="lblChildName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>
                            <%-- <asp:Literal ID="lblPageName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Literal>--%>
                        </aside>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-12">
                    <div class="innersocial">
                        <span>شارك هذه الصفحة</span>

                        <!-- Go to www.addthis.com/dashboard to customize your tools -->
                        <div class="addthis_inline_share_toolbox"></div>
                        <!-- Go to www.addthis.com/dashboard to customize your tools -->
                        <div class="addthis_inline_follow_toolbox_3jjb"></div>


                        <!-- Go to www.addthis.com/dashboard to customize your tools -->
                        <script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-5ee2061022ffd1bc"></script>

                        <%--<a href="javascript:void" class="fa fa-whatsapp"></a>
                        <a href="javascript:void" class="fa fa-instagram"></a>
                        <a href="javascript:void" class="fa fa-twitter"></a>
                        <a href="javascript:void" class="fa fa-facebook"></a>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <section class="comn_padding greybg sevice_step">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-12 col-sm-12">
                    <div class="sidebar_Accordion">
                        <aside>
                            <small>اختيار نوع المعاملة</small>
                            نوع المعاملة المطلوبة
                        </aside>



                        <asp:ListView runat="server" ID="lstServiceType" OnItemDataBound="lstServiceType_ItemDataBound">
                            <ItemTemplate>
                                <div runat="server" id="ca" class="collapsable collapsable-accordion">
                                    <h4 class="ca-control">
                                        <asp:HiddenField runat="server" ID="hdnId" Value='<%# Bind("ID") %>' />
                                        <asp:HyperLink runat="server" ID="lnkparent" Text='<%# Bind("ServiceName") %>'></asp:HyperLink>
                                        <%--  <a href="#ca-1" class="ca-ico">خدمات الاشتراكات</a>--%>
                                    </h4>
                                    <div class="ca-box">


                                        <asp:ListView runat="server" ID="lstSecondServiceType" OnItemDataBound="lstSecondServiceType_ItemDataBound">
                                            <ItemTemplate>

                                                <asp:HiddenField runat="server" ID="hdhServiceId" Value='<%# Bind("ID") %>' />
                                                <asp:HiddenField runat="server" ID="hdnHasUserType" Value='<%# Bind("HasUserType") %>' />
                                                <asp:HiddenField runat="server" ID="hdnServiceName" Value='<%# Bind("ServiceName") %>' />
                                                <asp:HiddenField runat="server" ID="hdnParentID" Value='<%# Bind("ParentID") %>' />
                                                <asp:HyperLink runat="server" ID="lnkSecondNav" Text='<%# Bind("ServiceName") %>'>
                                                </asp:HyperLink>

                                            </ItemTemplate>
                                        </asp:ListView>
                                        <%-- <a href="javascript:void">طلب عداد جديد ( 1 فاز/ 3 فاز) </a>
                                        <a href="javascript:void">طلب تبديل عداد1فاز الى 3 فاز او 3 فاز الى1 فاز </a>
                                        <a href="javascript:void">التحويل من مؤقت الى دائم</a>
                                        <a href="javascript:void">طلب معاملات الصيانة (نقل خطوط، رفع قدرة قاطع)</a>
                                        <a href="javascript:void">نقل عداد، تثبيت فناجين</a>--%>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:ListView>

                        <%--  <div id="ca-1" class="collapsable collapsable-accordion">
                            <h4 class="ca-control">
                                <a href="#ca-1" class="ca-ico">خدمات الاشتراكات</a>
                            </h4>
                            <div class="ca-box">
                                <a href="javascript:void">طلب عداد جديد ( 1 فاز/ 3 فاز) </a>
                                <a href="javascript:void">طلب تبديل عداد1فاز الى 3 فاز او 3 فاز الى1 فاز </a>
                                <a href="javascript:void">التحويل من مؤقت الى دائم</a>
                                <a href="javascript:void">طلب معاملات الصيانة (نقل خطوط، رفع قدرة قاطع)</a>
                                <a href="javascript:void">نقل عداد، تثبيت فناجين</a>
                            </div>
                        </div>
                        <div id="ca-2" class="collapsable collapsable-accordion">
                            <h4 class="ca-control">
                                <a href="#ca-2">خدمات دائرة الجباية</a>
                            </h4>
                            <div class="ca-box">

                                <asp:HyperLink runat="server" ID="lnkhyper1" onclick="chageui(1)">UserType1</asp:HyperLink>
                                <asp:HyperLink runat="server" ID="lnkhyper2" onclick="chageui(2)">USertType2</asp:HyperLink>

                                <a href="javascript:void">طلب تغيير اشتراك مشغول</a>
                                <a href="javascript:void">طلب انهاء عقد </a>
                                <a href="javascript:void">طلب فصل تيار </a>
                                <a href="javascript:void">طلب وصل تيار </a>
                                <a href="javascript:void">طلب فحص عداد </a>
                                <a href="javascript:void">طلب رفع عداد بسبب الهدم </a>
                                <a href="javascript:void">طلب تغيير تعرفة </a>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="col-lg-9 col-md-12 col-sm-12">
                    <div class="stepdiv" id="msform">

                        <!--------------------------- STEP 2 --------------------------->
                        <div class="stepbox step3">
                            <ul class="list-unstyled steplist" id="progressbar2">
                                <li class="active" ><a href="javascript:void" id="li1">معاملات الاشتراكات </a></li>
                                <li class="" ><a href="javascript:void" id="li2">طلب عداد جديد ( ١ فاز / ٣ فاز  )</a></li>
                                <li id="li3"><a href="javascript:void">الاوراق المطلوبة</a></li>
                            </ul>
                            <br class="clearfix">

                             
                            <div class="row">

                                <!--------------------------- STEP 1 --------------------------->

                                <fieldset>

                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/error.png" alt="">
                                    <p>ابدأ بإختيار نوع المعاملة المطلوبة</p>

                                    <input type="button" id="s1" name="next" class="next action-button" value="متابعة" />
                                </fieldset>

                                <fieldset>

                                    
                                    <h3>تقديم الخدمات الفضلى المستدامة</h3>
                                    <p>تسعى شركة الكهرباء الأردنية المساهمة العامة المحدودة لتبقى الأولى في موثوقية تقديم خدمات توزيع الكهرباء في الأردن، والشركة الريادية في استخدام أحدث لتبقى الأولى في موثوقية تقديم خدمات توزيع والشركة الريادية في استخدام أحدث لتبقى.</p>

                                      
                                    <div id="divLoadMore"></div>
                               
                                    <br class="clearfix">
                                  <input type="button" id="s2" name="next" class="next action-button" value="متابعة" style="display:none"/>
                                    
                                </fieldset>

                                <fieldset>


                                   <div id="divInformationMore"></div>
                                    <br class="clearfix">
                                    <input type="button" id="s3" name="previous" class="previous action-button-previous" value="السابق" />
                                </fieldset>



                                <%-- <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="stepiconbox">
                                        <div class="stepiconboximg">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-1.png" alt="">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-11.png" alt="" class="backimg">
                                        </div>
                                        <h4>طلب عداد سكني</h4>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="stepiconbox">
                                        <div class="stepiconboximg">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-2.png" alt="">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-22.png" alt="" class="backimg">
                                        </div>
                                        <h4>طلب عداد تجاري</h4>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="stepiconbox">
                                        <div class="stepiconboximg">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-3.png" alt="">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-33.png" alt="" class="backimg">
                                        </div>
                                        <h4>عداد شحن سيارة كهربائية</h4>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="stepiconbox">
                                        <div class="stepiconboximg">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-4.png" alt="">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-44.png" alt="" class="backimg">
                                        </div>
                                        <h4>طلب عداد مؤقت</h4>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="stepiconbox">
                                        <div class="stepiconboximg">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-5.png" alt="">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-55.png" alt="" class="backimg">
                                        </div>
                                        <h4>طلب عداد خدمات</h4>
                                    </div>
                                </div>--%>
                            </div>


                           <%-- <button>
                                متابعة
                                    <i class="fa fa-long-arrow-left"></i>
                            </button>--%>
                            <div class="clearfix"></div>
                               
                        </div>



                        <!--------------------------- STEP 3 --------------------------->
                        <%--<div class="stepbox step3">
                            <ul class="list-unstyled steplist">
                                <li class="activebg"><a href="javascript:void">معاملات الاشتراكات </a></li>
                                <li class="activebg"><a href="javascript:void">طلب عداد جديد ( ١ فاز / ٣ فاز  )</a></li>
                                <li class="active"><a href="javascript:void">الاوراق المطلوبة</a></li>
                            </ul>
                            <br class="clearfix">
                            <h3>خدمة عداد شحن السيارات الكهربائية</h3>
                            <p>تسعى شركة الكهرباء الأردنية المساهمة العامة المحدودة لتبقى الأولى في موثوقية تقديم خدمات توزيع الكهرباء في الأردن، والشركة الريادية في استخدام أحدث لتبقى الأولى في موثوقية تقديم خدمات توزيع والشركة الريادية في استخدام أحدث لتبقى.</p>

                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4">
                                    <div class="meterbg3 meter_service">
                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/clock.png" alt="">
                                        <p>المدة الزمنية لتفعيل الخدمة</p>
                                        <aside><span>4-6</span> ايام عمل</aside>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4">
                                    <div class="meterbg2 meter_service">
                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/money.png" alt="">
                                        <p>الرسوم المطلوبة للاشتراك</p>
                                        <aside><span>182</span> دينار</aside>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4">
                                    <div class="meterbg1 meter_service">
                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/save.png" alt="">
                                        <p>قم بتحميل النموذج لتعبئتة</p>
                                        <aside>تحميل النموذج</aside>
                                    </div>
                                </div>
                            </div>

                            <strong>الاوراق المطلوبة للمعاملة</strong>
                            <ul class="list-unstyled transaction">
                                <li>1-    صورة عن مخطط موقع تنظيمي ( حديث) </li>
                                <li>2-    صورة عن مخطط اراضي ( حديث)</li>
                                <li>3-    صورة عن سند تسجيل الملكية للمالك او عقد ايجار مصدق</li>
                                <li>4-    تفويض خطي من المالك مصادق على التوقيع بنكياً في حال تقديم الطلب من قبل شخص اخر او صورة عن الوكالة العدلية</li>
                                <li>5-    فاتورة عداد الكهرباء لصاحب رخصة السيارة الراكب في نفس العقار المطلوب تزويده بعداد الشحن</li>
                                <li>6-    صورة رخصة المركبة المطابق لسند التسجيل او عقد ايجار مصدق </li>
                                <li>7-    كتاب هيئة تنظيم قطاع الطاقة والمعادن</li>
                                <li>8-    صورة عن هوية طالب الاشتراك وصورة هوية المفوض ان وجد</li>
                            </ul>
                        </div>--%>

                    </div>
                </div>
                <div>
                </div>
            </div>
        </div>

    </section>

    <%--<div class="loader">
        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/AgitatedShyArabianwildcat-size_restricted.gif" alt="">
    </div>--%>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
   

    <%--<script type="text/javascript">
        var current_fs2, next_fs2, previous_fs2; //fieldsets
        var opacity2;
        var current2 = 1;

        var steps2 = $("fieldset").length;

        function setProgressBar2(curStep) {
            var percent = parseFloat(100 / steps2) * curStep;
            percent = percent.toFixed();
            $(".progress-bar")
                .css("width", percent + "%")
            //to scroll top of page
            window.scrollTo(0, 500);
        }

    </script>--%>

    <script type="text/javascript">
        $("document").ready(function () {

            //$(".loader").hide();
            var current_fs, next_fs, previous_fs; //fieldsets
            var opacity;
            var current = 1;
            var steps = $("fieldset").length;
            


            setProgressBar(current);

            $(".next").click(function () {
                

                current_fs = $(this).parent();

                next_fs = $(this).parent().next();

                //Add Class Active
                //$("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

                $("#progressbar2 li").eq($("fieldset").index(next_fs)).addClass("active");
                $("#progressbar2 li").eq($("fieldset").index(current_fs)).removeClass("active");
                $("#progressbar2 li").eq($("fieldset").index(current_fs)).addClass("activebg");

                //show the next fieldset
                next_fs.show();
                //hide the current fieldset with style
                current_fs.animate({ opacity: 0 }, {
                    step: function (now) {
                        // for making fielset appear animation
                        opacity = 1 - now;

                        current_fs.css({
                            'display': 'none',
                            'position': 'relative'
                        });
                        next_fs.css({ 'opacity': opacity });
                    },
                    duration: 500
                });
                setProgressBar(++current);


            });

            $(".previous").click(function () {

                current_fs = $(this).parent();
                previous_fs = $(this).parent().prev();
                next_fs = $(this).parent().next();

                //Remove class active
                //$("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");
                $("#progressbar2 li").eq($("fieldset").index(current_fs)).removeClass("active");
                $("#progressbar2 li").eq($("fieldset").index(previous_fs)).addClass("active");
                $("#progressbar2 li").eq($("fieldset").index(current_fs)).removeClass("activebg");
                //show the previous fieldset
                previous_fs.show();

                //hide the current fieldset with style
                current_fs.animate({ opacity: 0 }, {
                    step: function (now) {
                        // for making fielset appear animation
                        opacity = 1 - now;

                        current_fs.css({
                            'display': 'none',
                            'position': 'relative'
                        });
                        previous_fs.css({ 'opacity': opacity });
                    },
                    duration: 500
                });
                setProgressBar(--current);
            });

            function setProgressBar(curStep) {
                
                var percent = parseFloat(100 / steps) * curStep;
                percent = percent.toFixed();
                $(".progress-bar")
                    .css("width", percent + "%")
                //to scroll top of page
                window.scrollTo(0, 500);
            }
        });


        function chageStep2(id, serviceNAme, ParentNAme) {
            debugger;
           
            $("#li1").text(ParentNAme);
            //$("#li1").text(ParentNAme);
            $("#li2").text(serviceNAme);

            
           
            steps = $("fieldset").length;
            setProgressBar(1);
            
            var obj = {};
            obj.id = id;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Pages/ServiceStepPage.aspx/BindUserType",
                data: JSON.stringify(obj),
                success: function (result) {
                     
                    $("#divLoadMore").empty();
                    $("#divInformationMore").empty();
                    if (result.d != null) {
                       

                        $.each(result.d, function (i, itm) {


                            var dataR = `<div class="col-lg-3 col-md-4 col-sm-6">
                                    <div class="stepiconbox">
<a onclick="chageStep3By2(` + itm.ID + `)"> 
                                        <div class="stepiconboximg">
                                           

                                            <img src=` + itm.Icon + ` alt="">
                                                <img src=` + itm.IconHover + ` alt="" class="backimg">
                                        </div>

                                                <h4>` + itm.Title + `</h4>
</a>
                                    </div>
                                        </div>`;

                            $("#divLoadMore").append(dataR);

                        });
                    }

                },
                error: function (result) {
                    alert(result.status + " : " + result.StatusText);

                }
            });

           <%-- $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Pages/ServiceStepPage.aspx/BindServiceInformation",
                data: JSON.stringify(obj),
                success: function (result) {
                    debugger;
                    $("#divInformationMore").empty();

                    if (result.d != null) {

                        alert("Call Sussess");

                        debugger;
                        $.each(result.d, function (i, itm) {
                            debugger;

                            var dataR = `<div>
                                ` + itm.Description + `
                               
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4">
                                        <div class="meterbg3 meter_service">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/clock.png" alt="">
                                                <p>المدة الزمنية لتفعيل الخدمة</p>
                                                <aside><span>` + itm.Time + `</span> ايام عمل</aside>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <div class="meterbg2 meter_service">
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/money.png" alt="">
                                                    <p>الرسوم المطلوبة للاشتراك</p>
                                                    <aside><span>` + itm.Fees + `</span> دينار</aside>
                                            </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="meterbg1 meter_service">
                                                    <a href="` + itm.Link + `">
                                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/save.png" alt="">
                                                        <p>قم بتحميل النموذج لتعبئتة</p>
                                                        <aside>تحميل النموذج</aside>
                                                          </a>
                                            </div>
                                                </div>
                                            </div>

                                            <strong>الاوراق المطلوبة للمعاملة</strong>
                                            <div id="stepdata"></div>
</div>`;




                             $("#divInformationMore").append(dataR);



                            //-------------------  Calling Step Data 
                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "/Pages/ServiceStepPage.aspx/BindServiceStep",
                                data: JSON.stringify(obj),
                                success: function (result) {
                                    $("#stepdata").empty();

                                    if (result.d != null) {

                                        var GetLis = "";

                                        $.each(result.d, function (i, itm) {

                                            var dataLi = ` <li>` + itm.StepTitle + ` </li>`;

                                            GetLis = GetLis + dataLi;
                                            //GetLis.append(dataR);

                                        });

                                        var GetUI = `<ul class="list-unstyled transaction">
                            ` + GetLis + `
                            </ul>`;

                                        $("#stepdata").append(GetUI);

                                    }
                                    //$(".loader").hide();

                                },
                                error: function (result) {
                                    alert(result.status + " : " + result.StatusText);

                                }
                            });
                            //-------

                        });



                    }

                },
                error: function (result) {
                    alert(result.status + " : " + result.StatusText);

                }
            });--%>

            current_fs = $("#s2").parent();
            opacity = 0;
            //next_fs2 = $("#s1").parent().next();
            next_fs = $("#s2").parent().next();
            previous_fs = $("#s2").parent().prev();

            $("#progressbar2 li").eq($("fieldset").index(current_fs)).addClass("active");
            $("#progressbar2 li").eq($("fieldset").index(previous_fs)).removeClass("active");
            $("#progressbar2 li").eq($("fieldset").index(previous_fs)).addClass("activebg");
            $("#progressbar2 li").eq($("fieldset").index(next_fs)).removeClass("active");
            $("#progressbar2 li").eq($("fieldset").index(next_fs)).removeClass("activebg");
           

            current_fs.show();
            next_fs.animate({ opacity: 0 }, {

                step: function (now) {
                     
                    // for making fielset appear animation
                    opacity = 1 - now;

                    next_fs.css({
                        'display': 'none',
                        'position': 'relative'
                    });
                    current_fs.css({ 'opacity': opacity });

                },
                duration: 500
            });
            previous_fs.animate({ opacity: 0 }, {

                step: function (now) {
                     
                    // for making fielset appear animation
                    opacity = 1 - now;

                    previous_fs.css({
                        'display': 'none',
                        'position': 'relative'
                    });
                    current_fs.css({ 'opacity': opacity });

                },
                duration: 500
            });

            //alert("ok");
            
           
        }

        function setProgressBar(curStep) {

            var percent = parseFloat(100 / steps) * curStep;
            percent = percent.toFixed();
            $(".progress-bar")
                .css("width", percent + "%")
            //to scroll top of page
            window.scrollTo(0, 500);
        }

        
        function chageStep3(id, serviceNAme, ParentNAme) {
             
           
            $("#li1").text(ParentNAme);
           
            $("#li2").text(serviceNAme);
             

            steps = $("fieldset").length;
            setProgressBar(1);

            var obj = {};
            obj.id = id;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Pages/ServiceStepPage.aspx/BindServiceInformationByServiveTypeID",
                data: JSON.stringify(obj),
                success: function (result) {
                    $("#divInformationMore").empty();

                    if (result.d != null) {



                        $.each(result.d, function (i, itm) {


                            var dataR = `<div>
                                ` + itm.Description + `
                               
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4">
                                        <div class="meterbg3 meter_service">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/clock.png" alt="">
                                                <p>المدة الزمنية لتفعيل الخدمة</p>
                                                <aside><span>` + itm.Time + `</span> ايام عمل</aside>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <div class="meterbg2 meter_service">
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/money.png" alt="">
                                                    <p>الرسوم المطلوبة للاشتراك</p>
                                                    <aside><span>` + itm.Fees + `</span> دينار</aside>
                                            </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="meterbg1 meter_service">
                                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/save.png" alt="">
                                                        <p>قم بتحميل النموذج لتعبئتة</p>
                                                        <aside>تحميل النموذج</aside>
                                                          <a href="` + itm.Link + `">
                                            </div>
                                                </div>
                                            </div>

                                            <strong>الاوراق المطلوبة للمعاملة</strong>
                                            <div id="stepdata"></div>
</div>`;




                            $("#divInformationMore").append(dataR);


                            //--------------------  Calling Step Data 
                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "/Pages/ServiceStepPage.aspx/BindServiceStepByServiceTypeId",
                                data: JSON.stringify(obj),
                                success: function (result) {
                                    $("#stepdata").empty();

                                    if (result.d != null) {

                                        var GetLis = "";

                                        $.each(result.d, function (i, itm) {

                                            var dataLi = ` <li>` + itm.StepTitle + ` </li>`;

                                            GetLis = GetLis + dataLi;
                                            //GetLis.append(dataR);

                                        });

                                        var GetUI = `<ul class="list-unstyled transaction">
                            ` + GetLis + `
                            </ul>`;

                                        $("#stepdata").append(GetUI);

                                    }
                                    //$(".loader").hide();
                                },
                                error: function (result) {
                                    alert(result.status + " : " + result.StatusText);

                                }
                            });
                            //-------------
                        });



                    }

                },
                error: function (result) {
                    alert(result.status + " : " + result.StatusText);

                }
            });


            current_fs = $("#s3").parent();
             opacity = 0;
             //next_fs2 = $("#s1").parent().next();
            //next_fs = $("#s3").parent().next();
            previous_fs = $("#s3").parent().prev();
             
            previous_fs2 = $("#s3").parent().prev().prev();

             $("#progressbar2 li").eq($("fieldset").index(current_fs)).addClass("active");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs)).removeClass("active");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs)).addClass("activebg");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs2)).removeClass("active");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs2)).addClass("activebg");


             current_fs.show();
             //next_fs.animate({ opacity: 0 }, {

             //    step: function (now) {

             //        // for making fielset appear animation
             //        opacity = 1 - now;

             //        next_fs.css({
             //            'display': 'none',
             //            'position': 'relative'
             //        });
             //        current_fs.css({ 'opacity': opacity });

             //    },
             //    duration: 500
             //});
             previous_fs.animate({ opacity: 0 }, {

                 step: function (now) {

                     // for making fielset appear animation
                     opacity = 1 - now;

                     previous_fs.css({
                         'display': 'none',
                         'position': 'relative'
                     });
                     current_fs.css({ 'opacity': opacity });

                 },
                 duration: 500
             });

            previous_fs2.animate({ opacity: 0 }, {

                step: function (now) {
                     
                    // for making fielset appear animation
                    opacity = 1 - now;

                    previous_fs2.css({
                        'display': 'none',
                        'position': 'relative'
                    });
                    current_fs.css({ 'opacity': opacity });

                },
                duration: 500
            });

            $("#s3").hide();
           
        }

        function chageStep3By2(id) {


            //$("#li1").text(ParentNAme);

            //$("#li2").text(serviceNAme);


            steps = $("fieldset").length;
            setProgressBar(1);

            var obj = {};
            obj.id = id;

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Pages/ServiceStepPage.aspx/BindServiceInformation",
                data: JSON.stringify(obj),
                success: function (result) {
                    $("#divInformationMore").empty();

                    if (result.d != null) {



                        $.each(result.d, function (i, itm) {


                            var dataR = `<div>
                                ` + itm.Description + `
                               
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4">
                                        <div class="meterbg3 meter_service">
                                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/clock.png" alt="">
                                                <p>المدة الزمنية لتفعيل الخدمة</p>
                                                <aside><span>` + itm.Time + `</span> ايام عمل</aside>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <div class="meterbg2 meter_service">
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/money.png" alt="">
                                                    <p>الرسوم المطلوبة للاشتراك</p>
                                                    <aside><span>` + itm.Fees + `</span> دينار</aside>
                                            </div>
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                <div class="meterbg1 meter_service">
                                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/save.png" alt="">
                                                        <p>قم بتحميل النموذج لتعبئتة</p>
                                                        <aside>تحميل النموذج</aside>
                                                          <a href="` + itm.Link + `">
                                            </div>
                                                </div>
                                            </div>

                                            <strong>الاوراق المطلوبة للمعاملة</strong>
                                            <div id="stepdata"></div>
</div>`;




                            $("#divInformationMore").append(dataR);


                            //--------------------  Calling Step Data 
                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "/Pages/ServiceStepPage.aspx/BindServiceStep",
                                data: JSON.stringify(obj),
                                success: function (result) {
                                    $("#stepdata").empty();

                                    if (result.d != null) {

                                        var GetLis = "";

                                        $.each(result.d, function (i, itm) {

                                            var dataLi = ` <li>` + itm.StepTitle + ` </li>`;

                                            GetLis = GetLis + dataLi;
                                            //GetLis.append(dataR);

                                        });

                                        var GetUI = `<ul class="list-unstyled transaction">
                            ` + GetLis + `
                            </ul>`;

                                        $("#stepdata").append(GetUI);

                                    }
                                    //$(".loader").hide();
                                },
                                error: function (result) {
                                    alert(result.status + " : " + result.StatusText);

                                }
                            });
                            //-------------
                        });



                    }

                },
                error: function (result) {
                    alert(result.status + " : " + result.StatusText);

                }
            });






             current_fs = $("#s3").parent();
             opacity = 0;
             //next_fs2 = $("#s1").parent().next();
             //next_fs = $("#s3").parent().next();
             previous_fs = $("#s3").parent().prev();

             previous_fs2 = $("#s3").parent().prev().prev();

             $("#progressbar2 li").eq($("fieldset").index(current_fs)).addClass("active");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs)).removeClass("active");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs)).addClass("activebg");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs2)).removeClass("active");
             $("#progressbar2 li").eq($("fieldset").index(previous_fs2)).addClass("activebg");


             current_fs.show();
            
             previous_fs.animate({ opacity: 0 }, {

                 step: function (now) {

                     // for making fielset appear animation
                     opacity = 1 - now;

                     previous_fs.css({
                         'display': 'none',
                         'position': 'relative'
                     });
                     current_fs.css({ 'opacity': opacity });

                 },
                 duration: 500
             });

             previous_fs2.animate({ opacity: 0 }, {

                 step: function (now) {

                     // for making fielset appear animation
                     opacity = 1 - now;

                     previous_fs2.css({
                         'display': 'none',
                         'position': 'relative'
                     });
                     current_fs.css({ 'opacity': opacity });

                 },
                 duration: 500
             });


            $("#s3").show();

         }

      

        

    </script>
    

    <style>
        /* =================================================
	 17-02-2020 form stepper new css :start
===================================================== */



        html {
            height: 100%
        }

        p {
            color: grey
        }

        #heading {
            text-transform: uppercase;
            color: #673AB7;
            font-weight: normal
        }

        #msform {
            /*text-align: center;*/
            position: relative;
            margin-top: 0px;
            background: #f8f8f8;
            padding: 30px 0px;
        }

            #msform fieldset {
                /*background: white;*/
                border: 0 none;
                border-radius: 0.5rem;
                box-sizing: border-box;
                width: 100%;
                margin: 0;
                padding-bottom: 20px;
                position: relative
            }

        .form-card {
            text-align: left;
            padding: 0px 45px;
            background: #f8f8f8;
        }

        #msform fieldset:not(:first-of-type) {
            display: none
        }

        #msform input,
        #msform textarea {
            padding: 15px 20px;
            border: 1px solid #ccc;
            border-radius: 0px;
            margin-bottom: 25px;
            margin-top: 2px;
            width: 100%;
            box-sizing: border-box;
            color: #2C3E50;
            background-color: #fff;
            font-size: 16px;
            letter-spacing: 1px
        }

            #msform input:focus,
            #msform textarea:focus {
                -moz-box-shadow: none !important;
                -webkit-box-shadow: none !important;
                box-shadow: none !important;
                border: 1px solid #325925;
                outline-width: 0;
            }

        #msform .action-button {
            min-height: 60px;
            border-radius: 0;
            background: #007fc3;
            color: #fff;
            font-size: 18px;
            text-transform: uppercase;
            width: 180px;
            text-align: center;
            float: right;
            margin-top: 9px;
            margin-right: 45px;
        }

        #msform .action-button-previous {
            width: 100px;
            background: #616161;
            font-weight: bold;
            color: white;
            border: 0 none;
            border-radius: 0px;
            cursor: pointer;
            padding: 10px 5px;
            margin: 10px 5px 10px 0px;
            float: right
        }

            #msform .action-button-previous:hover,
            #msform .action-button-previous:focus {
                background-color: #000000
            }

        .card {
            z-index: 0;
            border: none;
            position: relative
        }

        .fs-title {
            font-size: 25px;
            color: #673AB7;
            margin-bottom: 15px;
            font-weight: normal;
            text-align: left
        }

        .purple-text {
            color: #673AB7;
            font-weight: normal
        }

        .steps {
            font-size: 25px;
            color: gray;
            margin-bottom: 10px;
            font-weight: normal;
            text-align: right
        }

        .fieldlabels {
            color: #848484;
            text-align: right;
            display: inline-block;
            width: 100%;
            font-size: 18px;
        }

        #progressbar {
            margin-bottom: 30px;
            overflow: hidden;
            color: #848484;
        }

        ul#progressbar strong {
            font-size: 18px;
        }

        ul#progressbar p {
            font-size: 16px;
        }

        #progressbar .active {
            color: #848484
        }

        #progressbar li {
            list-style-type: none;
            font-size: 15px;
            width: 20%;
            float: left;
            position: relative;
            font-weight: 400
        }

        /*#progressbar2 li {       
        width: 25%;        
    }*/

        #progressbar #account:before {
            content: "01";
            color: #fff;
        }

        #progressbar #personal:before {
            content: "02";
            color: #fff;
        }

        #progressbar #payment:before {
            content: "03";
            color: #fff;
        }

        #progressbar #contactd:before {
            content: "04";
            color: #fff;
        }

        #progressbar #confirm:before {
            content: "05";
            color: #fff;
        }

        #progressbar #FinalStep:before {
            content: "06";
            color: #fff;
        }

        #progressbar li:before {
            width: 84px;
            height: 84px;
            line-height: 78px;
            display: block;
            font-size: 30px;
            color: #ffffff;
            background: #ebeceb;
            border-radius: 50%;
            margin: 0 auto 10px auto;
            padding: 0px;
            -webkit-border-radius: 50%;
            -moz-border-radius: 50%;
            -ms-border-radius: 50%;
            -o-border-radius: 50%;
        }

        #progressbar li:first-child:after {
            width: 100%;
            right: 0;
            left: 42%;
        }

        #progressbar li:after {
            content: '';
            width: 100%;
            height: 8px;
            background: #ebeceb;
            position: absolute;
            left: 0;
            top: 38px;
            z-index: -1
        }

        #progressbar li:last-child:after {
            width: 100%;
            left: -42%;
        }


        #progressbar li.active:before,
        #progressbar li.active:after {
            /*background: #918768;*/
            background: #007fc3;
        }

        .progress {
            height: 20px
        }

        .progress-bar {
            background-color: #673AB7
        }

        .fit-image {
            width: 100%;
            object-fit: cover
        }

        li#account:active {
            color: #000;
        }

        #msform fieldset input,
        #msform fieldset select {
            background: #fff;
            height: 60px;
            border: 1px solid #e2e2e2;
            padding: 10px;
            margin-bottom: 15px;
        }

        #msform fieldset textarea {
            background: #fff;
            height: 160px;
            border: 1px solid #e2e2e2;
            padding: 10px;
            margin-bottom: 15px;
            resize: none;
        }



        .form-card .btn {
            border: 3px solid #e2e2e2;
            display: inline-block;
            /*padding: 14px 169px;*/
            font-size: 18px;
            font-weight: 600;
            background: #ffff;
            position: relative;
            text-align: center;
            -webkit-transition: background 600ms ease, color 600ms ease;
            transition: background 600ms ease, color 600ms ease;
            width: 98%;
            height: 50px;
            line-height: 40px;
        }

        .form-card input[type="radio"].toggle {
            display: none;
        }

            .form-card input[type="radio"].toggle + label {
                cursor: pointer;
                min-width: 60px;
            }

                .form-card input[type="radio"].toggle + label:hover {
                    background: #fff;
                    color: #c6c6c6;
                }


            .form-card input[type="radio"].toggle:checked + label {
                cursor: default;
                color: #848484;
                transition: color 200ms;
                background: #fff;
                border: 3px solid #007fc3;
                border-radius: 0;
            }

                .form-card input[type="radio"].toggle:checked + label:after {
                    left: 0;
                }

        .form-card input::-webkit-input-placeholder {
            color: #c6c6c6;
        }

        .form-card input::-moz-placeholder {
            color: #c6c6c6;
        }

        .form-card input::-ms-input-placeholder {
            color: #c6c6c6;
        }

        .form-card input::-moz-placeholder {
            color: #c6c6c6;
        }


        .sub_title_2 {
            font-size: 36px;
            color: #32592b;
            font-weight: bold;
            text-transform: uppercase;
            margin-bottom: 20px;
            margin: 50px 0;
        }

            .sub_title_2 span {
                font-size: 24px;
                color: #918768;
                font-weight: 400;
                text-transform: capitalize;
                display: block;
            }

        select#select_name {
            -webkit-appearance: none;
            font-size: 16px;
            color: #c6c6c6;
            position: relative;
        }

        select#new_select_name {
            -webkit-appearance: none;
            font-size: 16px;
            color: #c6c6c6;
            position: relative;
        }

        select#select_name {
            background: url(../images/down-arrow.png) no-repeat #fff !important;
            background-position: right !important;
        }

        select#new_select_name {
            background: url(../images/down-arrow.png) no-repeat #fff !important;
            background-position: right !important;
        }

        input[type="file"] {
            display: none;
        }

        .custom-file-upload {
            border: 1px solid #ccc;
            display: inline-block;
            cursor: pointer;
            background: #fff;
            padding: 16px 144px;
            font-size: 16px;
            border: 3px solid #b5b5b5;
            color: #848484;
        }

        span.file-select {
            font-size: 18px;
            color: #a0a0a0;
            margin-left: 14px;
        }

        .form-card textarea::-webkit-input-placeholder {
            color: #c6c6c6;
        }

        .form-card textarea::-moz-placeholder {
            color: #c6c6c6;
        }

        .form-card textarea::-ms-input-placeholder {
            color: #c6c6c6;
        }

        .form-card textarea::-moz-placeholder {
            color: #c6c6c6;
        }

        input[type="radio"],
        input[type="checkbox"] {
            width: auto !important;
            height: auto !important;
        }


        .datepicker-dropdown.dropdown-menu {
            background: #fff;
        }

        .forminfolabel {
            margin-bottom: 10px;
            font-size: 22px;
            /*color: #32592b;*/
            color: #007fc3;
            float: right;
        }

        .forminfolabelHead {
            margin-bottom: 0px;
            font-size: 35px;
            /*color: #32592b;*/
            color: #007fc3;
            float: right;
        }

        label.formdetailslbl {
            margin-top: 10px;
        }

        label.fieldlabels {
            margin-top: 0px;
            margin-bottom: 15px;
        }


        .steplist li:first-child.active::before {
            content: "";
            width: 0;
            height: 0;
            border-bottom: 66px solid #ffde23;
            border-left: 20px solid #f2f2f2;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 1;
            visibility: visible;
        }

        .steplist li:first-child.active::after {
            content: "";
            width: 20px;
            height: 100%;
            background: #ffde23;
            position: absolute;
            top: 0;
            right: 0px;
            border: none;
            visibility: visible;
        }
    </style>


    
</asp:Content>

