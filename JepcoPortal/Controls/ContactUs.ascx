<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="Controls_ContactUs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<section class="contact">
    <div class="container">
        <div class="row">
            <%-- <asp:Literal runat="server" ID="lblContentdetail"></asp:Literal>--%>
            <div class="col-lg-6 col-md-12 col-sm-12">
                <asp:Literal runat="server" ID="lblContentdetail"></asp:Literal>

              <%--  <h1>شركة الكهرباء الأردنية المساهمة العامة المحدودة</h1>
                <small>شارع مكة/عمارة رغدان - مقابل جوايكو</small>
                <p>تسعى شركة الكهرباء الأردنية المساهمة العامة المحدودة لتبقى الأولى في موثوقية تقديم خدمات توزيع الكهرباء في الأردن، والشركة الريادية في استخدام أحدث وسائل التكنولوجيا الآمنة ونقل المعرفة في أداء الخدمة بالأردن والوطن العربي. </p>
                <aside><strong>هاتف</strong> <span>06-5503600</span> <span>06-5503660</span></aside>
                <aside><strong>فاكس </strong><span>06-5503619</span></aside>
                <br>
                <address>
                    <strong>الرمز البريدي</strong> 11118  صندوق بريد: 618
 عمان -الاردن
                    <h6>
                        <strong>البريد الإلكتروني</strong>
                        <a href="mailto:jepco@go.co.mjo">jepco@go.co.mjo</a>
                    </h6>
                </address>--%>

            </div>

            <div id="dvMap" style="width: 50%; height: 407px;">
            </div>

            <%-- <div class="col-lg-6 col-md-12 col-sm-12">
                <div class="map">
                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img//map-1.jpg" alt="">
                </div>
            </div>--%>
        </div>
    </div>
</section>


<section class="Complaint_receiving_centers">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                 <asp:HiddenField runat="server" ID="HdnContausCount" />
                <h1>مراكز تلقي الشكاوي</h1>
                <div class="owl-carousel" id="Complaint_receiving_centers">
                   
                    <asp:ListView runat="server" ID="lstContactUs">
                        <ItemTemplate>
                            
                            <div class="mapbox">
                                <h5><asp:Literal runat="server" ID="Literal2" Text='<%# Bind("Description") %>'></asp:Literal></h5>
                                <asp:HiddenField runat="server" ID="hdnLongitude" Value='<%# Bind("Latitude") %>' />
                            <asp:HiddenField runat="server" ID="hndLatitude" Value='<%# Bind("Longitude") %>' />
                                <span><asp:Literal runat="server" ID="Literal1" Text='<%# Bind("Title") %>'></asp:Literal></span>
                               
                                <%-- <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/map-01.jpg" alt="">--%>
                                <div id="dvMapsml" runat="server" style="width: 292px; height: 123px;">
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:ListView>


                    <%--  <div class="item">
                        <div class="mapbox">
                            <h5>مركز الاتصال الرئيسي - عمان</h5>
                            <span>60-4696000</span>
                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/map-01.jpg" alt="">
                        </div>
                    </div>
                    <div class="item">
                        <div class="mapbox">
                            <h5>مركز الاتصال - فرع الزرقاء</h5>
                            <span>60-4696000</span>
                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/map-02.jpg" alt="">
                        </div>
                    </div>
                    <div class="item">
                        <div class="mapbox">
                            <h5>مركز الاتصال - فرع مادبا</h5>
                            <span>60-4696000</span>
                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/map-03.jpg" alt="">
                        </div>
                    </div>
                    <div class="item">
                        <div class="mapbox">
                            <h5>مركز الاتصال - فرع السلط</h5>
                            <span>60-4696000</span>
                            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/map-04.jpg" alt="">
                        </div>
                    </div>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="estext">
                    <small>ابقى على تواصل</small>
                    <h3>أرسل لنا رسالة وسنكون سعداء للمساعدة</h3>
                    <p>تسعى شركة الكهرباء الأردنية المساهمة العامة المحدودة لتبقى الأولى في موثوقية تقديم خدمات توزيع الكهرباء في الأردن، والشركة الريادية في استخدام أحدث وسائل التكنولوجيا الآمنة ونقل المعرفة في أداء الخدمة بالأردن والوطن العربي. </p>
                </div>
                <div class="follow_onsite">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-sm-6">
                            <div class="estext">
                                <small>التواصل الاجتماعي</small>
                                <h3><strong>تابعونا على مواقع
التواصل الاجتماعي</strong></h3>
                            </div>
                        </div>
                        <div class="col-lg-8 col-md-6 col-sm-6">
                            <ul class="list-unstyled">

                                 <asp:ListView runat="server" ID="lstSocialinContact" OnItemDataBound="lstSocialContact_ItemDataBound">
                                    <ItemTemplate>
                                        <li>
                                        <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("Link") %>' Target='<%# Bind("Target") %>'>
                                            <asp:HiddenField runat="server" ID="imgURL" Value='<%# Bind("Imageover") %>' />
                                            <asp:Image ID="imgsocial" runat="server" ImageUrl='<%# Bind("Image") %>' />
                                            <p><asp:Literal runat="server" ID="lbltile" Text='<%# Bind("Title") %>'></asp:Literal></p>
                                        </asp:HyperLink>
                                            </li>
                                    </ItemTemplate>
                                </asp:ListView>
                                <%--<li>
                                    <a href="javascript:void">
                                        <i class="fa fa-facebook"></i>
                                        <p>فيسبوك</p>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void">
                                        <i class="fa fa-twitter"></i>
                                        <p>تويتر</p>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void">
                                        <i class="fa fa-instagram"></i>
                                        <p>انستجرام</p>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void">
                                        <i class="fa fa-youtube"></i>
                                        <p>يوتيوب</p>
                                    </a>
                                </li>--%>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-12">
                <div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtName" placeholder="الاسم كامل" ClientIDMode="Static" CssClass="customClick"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtEmail" placeholder="البريد الالكتروني" ClientIDMode="Static" CssClass="customClick"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtMobile" placeholder="رقم الهاتف" ClientIDMode="Static" CssClass="customClick form-mobile"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" placeholder="ادخل نص الرسالة" CssClass="customClick"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <button class="send_msg_btn" onclick="validForm();" type="button">ارسال الرسالة</button>
                        <asp:Button runat="server" ID="lnkSubmitFrm" OnClick="lnkSubmitFrm_Click" Text="Send message" Style="display: none;" disbled="disabled"></asp:Button>
                    </div>

                    <%-- <div class="form-group">
                        <input type="text" placeholder="الاسم كامل">
                    </div>
                    <div class="form-group">
                        <input type="text" placeholder="البريد الالكتروني">
                    </div>
                    <div class="form-group">
                        <input type="text" placeholder="رقم الهاتف">
                    </div>
                    <div class="form-group">
                        <textarea placeholder="ادخل نص الرسالة"></textarea>
                    </div>
                    <div class="form-group">
                        <button>ارسال الرسالة</button>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
</section>



<%--<section class="contact_part">
    <div class="Headquarters">
        <div class="container">
            <div class="row">
                <div class="col-xl-6 col-lg-6 col-md-12">
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12">
                   <div id="dvMap" style="width: auto; height: 487px;">
                    </div>
                   <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/contact-map.jpg" alt="">
                </div>
            </div>
        </div>
    </div>

    <div class="message_help">
        <div class="container">
            <div class="row">
                <div class="col-xl-6 col-lg-6 col-md-12">
                    <h3>Please send us a message and
                            we'll be glad to help!
                    </h3>
                    <p>
                        Feel free to contact us with any questions you may have.
                            We will be pleased and honored to discuss our services in detail.
                    </p>

                    <div class="Followuson">
                        <span>Follow us on</span>
                        <ul class="list-unstyled">
                            <asp:ListView runat="server" ID="lstSocialIcon" OnItemDataBound="lstSocialIcon_ItemDataBound">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink runat="server" ID="lnkSocial" NavigateUrl='<%# Bind("Link") %>' Target='<%# Bind("Target") %>'>
                                            <asp:Image runat="server" ID="imgSocial" ImageUrl='<%# Bind("ImageOver") %>' />
                                            <br />
                                            <asp:Literal runat="server" ID="lblSocialTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                        </asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-6 col-md-12">
                  
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtName" placeholder="Add your full name" ClientIDMode="Static" CssClass="customClick"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtEmail" placeholder="Add your email address" ClientIDMode="Static" CssClass="customClick"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtMobile" placeholder="Enter your phone number" ClientIDMode="Static" CssClass="customClick form-mobile"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" placeholder="Type your message" CssClass="customClick"></asp:TextBox>
                    </div>
                    <button class="send_msg_btn" onclick="validForm();" type="button">Send message</button>
                    <asp:Button runat="server" ID="lnkSubmitFrm" OnClick="lnkSubmitFrm_Click" Text="Send message" Style="display: none;" disbled="disabled"></asp:Button>
                   
                </div>
            </div>

            <div class="clearfix"></div>


        </div>
    </div>
    <div class="sending_email_policy">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="new_sitelink">
                        <asp:ListView runat="server" ID="lstMainEntity" OnItemDataBound="lstMainEntity_ItemDataBound">
                            <ItemTemplate>
                                <ul class="list-unstyled sitelink" runat="server" id="mainUl">
                                    <asp:ListView runat="server" ID="lstEntities" OnItemDataBound="lstEntities_ItemDataBound">
                                        <ItemTemplate>
                                            <li>
                                                <asp:HiddenField runat="server" ID="lblEntityID" Value='<%# Bind("FocusEntityId") %>' />
                                                <h4>
                                                    <asp:HyperLink runat="server" ID="lnkDetailentity">
                                                        <asp:Literal runat="server" ID="lblTitle" Text='<%# Bind("Title") %>'></asp:Literal>
                                                        <asp:Literal runat="server" ID="lblTitle1" Text='<%# Bind("Title1") %>'></asp:Literal>
                                                    </asp:HyperLink>
                                                </h4>
                                                <p>
                                                    <asp:HyperLink runat="server" ID="lnkEmail" Text='<%# Bind("Email") %>' CssClass="emaillink"></asp:HyperLink>
                                                </p>
                                                <p>
                                                    <asp:Literal runat="server" ID="lblTelephone" Text='<%# Bind("Telephone") %>'></asp:Literal>
                                                    <asp:Literal runat="server" ID="lblFax" Text='<%# Bind("Fax") %>'></asp:Literal>
                                                   
                                                </p>

                                                <asp:HyperLink runat="server" ID="lnkWebsite" class="websitelink" Text='<%# Bind("Website") %>' NavigateUrl='<%# Bind("Website") %>' Target="_blank"></asp:HyperLink>
                                                <p>
                                                    <asp:Literal runat="server" ID="lblAddress" Text='<%# Bind("Address") %>'></asp:Literal>
                                                </p>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </ul>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Literal runat="server" ID="lblContentdetail1"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</section>--%>
<asp:LinkButton ID="lnkInquiry" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender runat="server" ID="mpeInquiry"
    TargetControlID="lnkInquiry" BehaviorID="mpeInquiry"
    BackgroundCssClass="modalBackground" PopupControlID="panelInqiry"
    CancelControlID="btnCloseInq">
</cc1:ModalPopupExtender>
<asp:Panel ID="panelInqiry" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome" Style="display: none">
    <div class="modal-dialog modal-md">
        <!-- Modal content-->
        <div class="modal-content">

            <div class="modal-header">
                <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnCloseInq"><span class="fa fa-close"></span></asp:LinkButton>
              <%--  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>--%>
                <h4 class="modal-title" id="myModalLabel">اهلا بكم في الموقع</h4>
            </div>
            <%--<div class="modal-body">
              
                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeEn/img/logo.png" />
                <div class="divContent">
                    <strong>
                        <asp:Literal runat="server" ID="lblInqTitle" Text="Message"></asp:Literal>
                    </strong>
                    <p>
                        <asp:Literal runat="server" ID="lblInqMessage">                             
                        </asp:Literal>
                    </p>
                </div>
            </div>--%>
            <div class="modal-body">
                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/logo.png" />
                <p>قررت شركة الكهرباء الاردنية وموظفوها التبرع بأجر يوم عمل كامل بمبلغ إجمالي مقداره مئة الف دينار لوزارة الصحة دعما للجهود الوطنية التي تبذلها المملكة قيادة وحكومة.</p>
            </div>
            <div class="modal-footer">
                <button>موافق</button>
            </div>
        </div>
    </div>
</asp:Panel>
<asp:HiddenField runat="server" ID="lblLatitude" />
<asp:HiddenField runat="server" ID="lblLongiude" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="http://maps.google.com/maps/api/js?key=AIzaSyDw7R6UWQg5NiY7uR6T-GKmwkscSaBmVtY"></script>

<script>    
    $(".customClick").keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
        }
    });
    function validForm() {
        debugger;
        var vname = false;
        var vEmail = false;
        var vMobile = false;
        if ($("#txtName").val() != "") {
            $("#txtName").css('border', 'none');
            vname = true;
        }
        else {
            $("#txtName").css('border', '1px solid red');
        }
        if ($("#txtEmail").val() != "") {
            var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!regex.test($("#txtEmail").val())) {
                $("#txtEmail").css('border', '1px solid red');
            } else {
                $("#txtEmail").css('border', 'none');
                vEmail = true;
            }
        }
        else {
            $("#txtEmail").css('border', '1px solid red');
        }
        if ($("#txtMobile").val() != "") {
            $("#txtMobile").css('border', 'none');
            vMobile = true;
        }
        else {
            $("#txtMobile").css('border', '1px solid red');
        }
        if (vname && vEmail && vMobile) {
            $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
        }
    }
</script>
<script>
    $(".form-mobile").keypress(function (e) {

        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            //$("#errmsg").html("Digits Only").show().fadeOut("slow");

            return false;
        }
        else {
            var len = $(".form-mobile").val().length;
            //if (len > 10)
            //{
            //    return false;
            //}
        }

    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var markers = [];
        var lati = $("#<%=lblLatitude.ClientID%>").val();
        var lang = $("#<%=lblLongiude.ClientID%>").val();
        markers.push({ "lat": lati, "lng": lang });

        console.log(markers);
        var iconBase = '<%=ConfigurationManager.AppSettings["ImagePath"]%>';
        //------------- Generate Map----------------------------------------
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 10,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var latlngbounds = new google.maps.LatLngBounds();
        var geocoder = geocoder = new google.maps.Geocoder();
        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
        for (var i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title,
                draggable: false,
                clickable: false,
                //icon: 'http://localhost:53817//App_Themes/ThemeEn/img/pin.png'
                icon: iconBase + '/App_Themes/ThemeAR/img/Maplogo.png'
                //animation: google.maps.Animation.DROP
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
                        if (status == google.maps.GeocoderStatus.OK) {
                            if (results[0]) {
                                infoWindow.setContent("<div style='width:110px;text-align:left;'>" + results[0].formatted_address + "</div>");
                            }
                        }
                    });
                    //infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
                google.maps.event.addListener(marker, "dragend", function (e) {
                    var lat, lng, address;
                    geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
                        if (status == google.maps.GeocoderStatus.OK) {
                            lat = marker.getPosition().lat();
                            lng = marker.getPosition().lng();
                            address = results[0].formatted_address;
                            // alert("Latitude: " + lat + "\nLongitude: " + lng + "\nAddress: " + address);
                        }
                    });
                });
            })(marker, data);
            latlngbounds.extend(marker.position);
        }
        var bounds = new google.maps.LatLngBounds();
        map.setCenter(latlngbounds.getCenter());
        //map.fitBounds(latlngbounds);
    });
</script>

<script type="text/javascript">
    $(document).ready(function () {
        debugger;
        var CountactCount = $("[id*=<%=HdnContausCount.ClientID %>]").val();

        for (var k = 0; k < CountactCount; k++) {
            debugger;

            var markers2 = [];
            var lati2 = $("#ContentPlaceHolder1_ctl00_lstContactUs_hdnLongitude_" + k).val();
            var latiNew = (document.getElementById("ContentPlaceHolder1_ctl00_lstContactUs_hdnLongitude_" + k));
            var lang2 = $("#ContentPlaceHolder1_ctl00_lstContactUs_hndLatitude_" + k).val();
            markers2.push({ "lat": lati2, "lng": lang2 });

            console.log(markers2);
            var iconBase = '<%=ConfigurationManager.AppSettings["ImagePath"]%>';
            //------------- Generate Map----------------------------------------
            var mapOptions = {
                center: new google.maps.LatLng(markers2[0].lat, markers2[0].lng),
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            var geocoder = geocoder = new google.maps.Geocoder();
            var map = new google.maps.Map(document.getElementById("ContentPlaceHolder1_ctl00_lstContactUs_dvMapsml_"+ k), mapOptions);
            for (var i = 0; i < markers2.length; i++) {
                var data = markers2[i]
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title,
                    draggable: false,
                    clickable: false,
                    //icon: 'http://localhost:53817//App_Themes/ThemeEn/img/pin.png'
                    //icon: iconBase + '/App_Themes/ThemeAR/img/left-arrow.png'
                    //animation: google.maps.Animation.DROP
                });
                (function (marker, data) {
                    google.maps.event.addListener(marker, "click", function (e) {
                        geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
                            if (status == google.maps.GeocoderStatus.OK) {
                                if (results[0]) {
                                    infoWindow.setContent("<div style='width:110px;text-align:left;'>" + results[0].formatted_address + "</div>");
                                }
                            }
                        });
                        //infoWindow.setContent(data.description);
                        infoWindow.open(map, marker);
                    });
                    google.maps.event.addListener(marker, "dragend", function (e) {
                        var lat, lng, address;
                        geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
                            if (status == google.maps.GeocoderStatus.OK) {
                                lat = marker.getPosition().lat();
                                lng = marker.getPosition().lng();
                                address = results[0].formatted_address;
                                // alert("Latitude: " + lat + "\nLongitude: " + lng + "\nAddress: " + address);
                            }
                        });
                    });
                })(marker, data);
                latlngbounds.extend(marker.position);
            }
            var bounds = new google.maps.LatLngBounds();
            map.setCenter(latlngbounds.getCenter());

        }
    });
</script>

<%--<script>
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {
        $(".customClick").keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
            }
        });
        function validForm() {
            var vname = false;
            var vEmail = false;
            var vMobile = false;
            if ($("#txtName").val() != "") {
                $("#txtName").css('border', 'none');
                vname = true;
            }
            else {
                $("#txtName").css('border', '1px solid red');
            }
            if ($("#txtEmail").val() != "") {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test($("#txtEmail").val())) {
                    $("#txtEmail").css('border', '1px solid red');
                } else {
                    $("#txtEmail").css('border', 'none');
                    vEmail = true;
                }
            }
            else {
                $("#txtEmail").css('border', '1px solid red');
            }
            if ($("#txtMobile").val() != "") {
                $("#txtMobile").css('border', 'none');
                vMobile = true;
            }
            else {
                $("#txtMobile").css('border', '1px solid red');
            }
            if (vname && vEmail && vMobile) {
                $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
            }
        }

        $(".form-mobile").keypress(function (e) {

            //if the letter is not digit then display error and don't type anything
            if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                //display error message
                //$("#errmsg").html("Digits Only").show().fadeOut("slow");

                return false;
            }
            else {
                var len = $(".form-mobile").val().length;
                //if (len > 10)
                //{
                //    return false;
                //}
            }

        });
    });
</script>--%>
