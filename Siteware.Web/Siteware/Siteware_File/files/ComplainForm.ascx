<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComplainForm.ascx.cs" Inherits="Controls_ComplainForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<div class="greybg subscribe_div">
    <div class="step_form">
        <div class="subscribe_div1">
            <h3>تقديم شكوى الكترونية </h3>
            <label>الرجاء ادخال البيانات المطلوبة وسنقدم لكم كل مساعدة ممكنة </label>

            <h3>الشكوى المقدم لها</h3>
         

            <h3>المعلومات الشخصية</h3>

            <h3>تفاصيل الشكوى </h3>
          
        </div>
    </div>
</div>--%>
<%------------------------------------------------------%>



<div class="greybg subscribe_div">
    <div class="step_form">
        <div class="subscribe_div1">
            <h3>تقديم شكوى الكترونية </h3>
            <label>الرجاء ادخال البيانات المطلوبة وسنقدم لكم كل مساعدة ممكنة </label>

            <section class="step" id="msform">

                <div class="menuuu">
                    <%--<div class="col-lg-12 col-md-12 col-sm-12">
                        <label class="forminfolabelHead"><b>نموذج طلب توظيف</b></label>
                        <label class="fieldlabels" style="font-weight: normal;">الرجاء تعبئة البيانات أدناه مع مراعاة دقة المعلومات</label>
                    </div>--%>

                    <div>

                        <ul class="list-unstyled steplist" id="progressbar2" style="margin-bottom: 30px;">
                                <li class="active"><a href="javascript:void">الشكوى المقدم لها</a></li>
                                <li><a href="javascript:void">المعلومات الشخصية</a></li>
                                <li><a href="javascript:void">تفاصيل الشكوى</a></li>

                            </ul>

                        <div class="col-md-12">

                            
                        </div>
                    </div>


                </div>

                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">

                        <fieldset>
                            <h3>الشكوى المقدم لها</h3>
                            <div class="row">

                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">

                                        <label><span>*</span>نوع الشكوى</label>
                                        <asp:DropDownList ID="ddlComplainType" runat="server" TabIndex="2" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <input type="button" name="next" class="next action-button" value="التالي" />
                        </fieldset>
                        <fieldset>
                            <h3>المعلومات الشخصية</h3>

                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>الاسم الأول</label>
                                        <asp:TextBox ID="txtfirstName" runat="server" PlaceHolder="الاسم الأول"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>اسم الأب </label>
                                        <asp:TextBox ID="txtSecondNAme" runat="server" PlaceHolder="اسم الأب"></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>اسم الجد </label>
                                        <asp:TextBox ID="txtThirdName" runat="server" PlaceHolder="اسم الجد "></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>اسم العائلة </label>
                                        <asp:TextBox ID="txtFamilyName" runat="server" PlaceHolder="اسم العائلة "></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label><span>*</span>  الجنسية</label>
                                                <asp:DropDownList ID="ddlNationality" OnSelectedIndexChanged="ddlNationality_SelectedIndexChanged" AutoPostBack="true" runat="server" TabIndex="2" Width="100%">
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label><span>*</span>  نوع الوثيقة</label>
                                                <asp:DropDownList ID="ddlTypeDocument" runat="server" TabIndex="2" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label><span>*</span> رقم الوثيقة</label>
                                                <asp:TextBox ID="txtDocumnetNo" runat="server" PlaceHolder="رقم الوثيقة" class="mobileNo"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlNationality" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span> البريد الالكتروني </label>
                                        <asp:TextBox ID="txtEmail" runat="server" PlaceHolder=" البريد الالكتروني "></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>رقم الهاتف </label>
                                        <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="رقم الهاتف " class="mobileNo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>رقم العداد </label>
                                        <asp:TextBox ID="txtMeterNo" runat="server" PlaceHolder=" رقم العداد "></asp:TextBox>
                                    </div>
                                </div>

                            </div>


                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>  المحافظة </label>

                                        <select id="ddlGeove" name="ddlGeove" class="form-control" tabindex="2"></select>
                                    </div>

                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>الحي </label>

                                        <select id="ddlAreas" name="ddlAreas" class="form-control" tabindex="2"></select>

                                    </div>

                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>Area 2</label>
                                        <select id="ddlAreas2" name="ddlAreas2" class="form-control" tabindex="2"></select>
                                    </div>

                                </div>

                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label>Street</label>
                                        <select id="ddlsteet" name="ddlsteet" class="form-control" tabindex="2"></select>
                                    </div>

                                </div>

                            </div>


                            <div class="row" style="display: none">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label>اختر المنطقة بالتحديد</label>

                                        <div id="gmap" style="width: 100%; height: 450px;"></div>
                                        <div class="scribmap">

                                            <label>Latitude : </label>
                                            <label id="latlbl" style="font-family: Poppins, sans-serif; margin-left: 33px;"></label>
                                            <label>Longitude : </label>
                                            <label id="lonlbl" style="font-family: Poppins, sans-serif;"></label>

                                            <asp:HiddenField runat="server" ID="lblLatitude" />
                                            <asp:HiddenField runat="server" ID="lblLongiude" />


                                        </div>
                                    </div>
                                </div>
                            </div>

                            <input type="button" name="next" class="next action-button" value="التالي" />
                            <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                        </fieldset>

                        <fieldset>

                            <h3>تفاصيل الشكوى </h3>

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label><span>*</span>عنوان الشكوى </label>
                                        <asp:TextBox ID="txtComplianTitle" runat="server" PlaceHolder="عنوان الشكوى "></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label><span>*</span> تفاصيل الشكوى </label>
                                        <asp:TextBox ID="txtComplainDetail" runat="server" PlaceHolder=" تفاصيل الشكوى " TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <button class="btn action-button" type="button" id="btbvalid" onclick="SendClick();">ارسال الطلب</button>
                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" type="button" Style="display: none;" runat="server" Text="Button" />
                            <asp:HiddenField runat="server" ID="hdnSaveResultStatus" />
                            <asp:HiddenField runat="server" ID="hdnSaveResultVAlue" />
                            <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                        </fieldset>

                    </div>
                </div>
            </section>

        </div>
    </div>
</div>





<asp:LinkButton ID="lnkSubscribe" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender runat="server" ID="mpeInquiry"
    TargetControlID="lnkSubscribe" BehaviorID="mpeInquiry"
    BackgroundCssClass="modalBackground" PopupControlID="panelInquiry"
    CancelControlID="btnClose">
</cc1:ModalPopupExtender>
<asp:Panel ID="panelInquiry" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome in" Style="display: none; position: fixed; top: 0px; right: 0px; bottom: 0px; left: 0.5px; z-index: 1000001; overflow: hidden; outline: 0px;">
    <div class="modal-dialog modal-md">
        <!-- Modal content-->
        <div class="modal-content">

            <div class="modal-header">


                <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnClose"><span class="fa fa-close"></span></asp:LinkButton>
                <h4 class="modal-title" id="myModalLabel">
                    <asp:Literal runat="server" ID="lblInquiryTitle" Text="تقديم شكوى الكترونية "></asp:Literal></h4>
            </div>
            <div class="modal-body">

                <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                    <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                    <p>
                        <asp:Literal runat="server" ID="lblInquiryMessage" Text="تم استلام الشكوى بنجاح. وسيتم الرد عليكم في أقرب وقت. رضاءكم هو هدفنا. ">                             
                        </asp:Literal>
                        <%-- <asp:HyperLink ID="lnkfollowlink" NavigateUrl="/ar/home/#" style="color:white" runat="server">الرابط التالي</asp:HyperLink>--%>
                    </p>

                </div>
            </div>
            <div class="modal-footer">

                <asp:Button ID="btn_ok" runat="server" Text="موافق" CssClass="d_model_btn button" type="button" OnClick="btn_ok_Click" />
            </div>


        </div>
    </div>

</asp:Panel>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://maps.google.com/maps/api/js?key=AIzaSyDw7R6UWQg5NiY7uR6T-GKmwkscSaBmVtY"></script>

<script>

    var lati = $("#<%=lblLatitude.ClientID%>").val();
    var lang = $("#<%=lblLongiude.ClientID%>").val();

    document.getElementById('latlbl').innerHTML = lati;
    document.getElementById('lonlbl').innerHTML = lang;

    var map;
    function initialize() {
        var myLatlng = new google.maps.LatLng(lati, lang);
        var myOptions = {
            zoom: 7,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        map = new google.maps.Map(document.getElementById("gmap"), myOptions);
        // marker refers to a global variable
        marker = new google.maps.Marker({
            position: myLatlng,
            map: map

        });

        google.maps.event.addListener(map, "click", function (event) {
            // get lat/lon of click
            var clickLat = event.latLng.lat();
            var clickLon = event.latLng.lng();

            // show in input box
            //document.getElementById("lat").value = clickLat.toFixed(5);
            //document.getElementById("lon").value = clickLon.toFixed(5);

            document.getElementById('latlbl').innerHTML = clickLat.toFixed(5);
            document.getElementById('lonlbl').innerHTML = clickLon.toFixed(5);



            $('#<%=lblLatitude.ClientID %>').val(clickLat.toFixed(5));
            $('#<%=lblLongiude.ClientID %>').val(clickLon.toFixed(5));


            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(clickLat, clickLon),
                map: map
            });
        });
    }

    window.onload = function () { initialize() };

</script>


<script type="text/javascript">
    function SendClick() {


       
        var ValComplianTitle = false;
        var ValComplainDetail = false;
    

        if ($('#<%= txtComplianTitle.ClientID %>').val().trim() != '') {

            $('#<%= txtComplianTitle.ClientID %>').css('border', 'none');
            ValComplianTitle = true;
        }
        else {

            $('#<%= txtComplianTitle.ClientID %>').css('border', '1px solid red');
        }


        if ($('#<%= txtComplainDetail.ClientID %>').val().trim() != '') {

            $('#<%= txtComplainDetail.ClientID %>').css('border', 'none');
            ValComplainDetail = true;
        }
        else {

            $('#<%= txtComplainDetail.ClientID %>').css('border', '1px solid red');
        }

        if (ValComplianTitle == true &&
            ValComplainDetail == true
          

        ) {


            //---------------------------------------- Calling API ---------------------------------------


            //$("[id$=txtfirstName]").val();
            //$("[id$=txtSecondNAme]").val();
            //$("[id$=txtThirdName]").val();
            //$("[id$=txtFamilyName]").val();

            var FNAme = $("[id$=txtfirstName]").val();
            var SNAme = $("[id$=txtSecondNAme]").val();
            var TNAme = $("[id$=txtThirdName]").val();
            var LNAme = $("[id$=txtFamilyName]").val();


            var BranchID = $("[id$=ddlGeove]").val();
            var RequesterMobile = $("[id$=txtMobileNo]").val();
            var RequesterName = FNAme + " " + SNAme + " " + TNAme + " " + LNAme;
            var ServiceID = $("[id$=ddlAreas]").val();
            var CategoryID = $("[id$=ddlAreas2]").val();
            var SubCategoryID = $("[id$=ddlsteet]").val();
            var IssueTitle = $("[id$=txtComplianTitle]").val();
            var IssueDescription = $("[id$=txtComplainDetail]").val();

            $.ajax({

                type: "POST",
                url: "/Default.aspx/SaveComplainData",
                data: "{BranchID:'" + BranchID + "',RequesterMobile:'" + RequesterMobile + "',RequesterName:'" + RequesterName + "',ServiceID:'" + ServiceID + "',CategoryID:'" + CategoryID + "',SubCategoryID:'" + SubCategoryID + "',IssueTitle:'" + IssueTitle + "',IssueDescription:'" + IssueDescription + "'}",
                contentType: "application/json; charset-utf-8",
                dataType: "json",
                success: function (result) {

                    debugger;
                    console.log(result);

                    var SaveResult = result.d;

                    var arr = SaveResult.split(':');

                    //alert(arr[0]);
                    //alert(arr[1]);
                    $("[id$=hdnSaveResultStatus]").val(arr[0]);
                    $("[id$=hdnSaveResultVAlue]").val(arr[1]);

                    $("[id*=<%=btnSubmit.ClientID %>]").click();


                },
                error: function (result) {
                    //alert(result.status + " : " + result.StatusText);
                }
            });

            //--------------------------------------- API END ------------------------------------





        }

    }
</script>



<script>
    $(".mobileNo").keypress(function (e) {

        //if the letter is not digit then display error and don't type anything
        if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            //$("#errmsg").html("Digits Only").show().fadeOut("slow");

            return false;
        }
        else {
            var len = $(".mobileNo").val().length;
            //if (len > 10)
            //{
            //    return false;
            //}
        }

    });
</script>

<style>
    .action-button {
        /*min-height: 60px;
        border-radius: 0;
        background: #007fc3;
        color: #fff;
        font-size: 18px;
        text-transform: uppercase;
        width: 180px;
        text-align: center;
        float: right;
        margin-top: 9px;
        margin-right: 45px;*/
    }

    .step_form textarea {
        border: 1px solid #d8d8d8;
        height: 60px;
        padding: 10px 15px;
        color: #007fc3;
        font-size: 18px;
    }
</style>

<script>

    $("#ddlGeove").append("<option value='0'>اختيار الجنسية</option>");
    $("#ddlAreas").append("<option value='0'>اختيار الجنسية</option>");
    $("#ddlAreas2").append("<option value='0'>اختيار الجنسية</option>");
    $("#ddlsteet").append("<option value='0'>اختيار الجنسية</option>");
    debugger;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Default.aspx/BindGovernetData",
        data: "{}",
        success: function (result) {

            debugger;
            console.log(result);
            $("#ddlGeove").empty();
            $("#ddlGeove").append("<option value='0'>اختيار الجنسية</option>");
            $.each(result.d, function (key, value) {

                $("#ddlGeove").append($("<option></option>").val(value.BranchID).html(value.desc1));

            });


            //$("#ddlMashrekGrade_" + firstrow).empty();
            //$("#ddlMashrekGrade_" + firstrow).append("<option value='0'>--Select Grade--</option>");
            //$.each(result.d, function (key, value) {

            //    $("#ddlMashrekGrade_" + firstrow).append($("<option></option>").val(value.GradeID).html(value.GradeName));

            //});

        },
        error: function (result) {
            // alert(result.status + " : " + result.StatusText);
        }
    });


    $("#ddlGeove").change(function () {



        var govidSelected = $('#ddlGeove').val();
        debugger;
        $.ajax({
            //type: "POST",
            //contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindAreaDatas",           
            ////data: { '"govid:"' + govidSelected + '}',
            //data: '{"govid":' + govidSelected + '}',
            //dataType: 'json',

            type: "POST",
            url: "/Default.aspx/BindAreaDatas",
            data: "{govid:'" + govidSelected + "'}",
            contentType: "application/json; charset-utf-8",
            dataType: "json",

            //contentType: 'application/json',
            // data: govidSelected //JSON.stringify(govidSelected),

            success: function (result) {

                debugger;
                console.log(result);


                $("#ddlAreas").empty();
                $("#ddlAreas").append("<option value='0'>اختيار الجنسية</option>");
                $.each(result.d, function (key, value) {

                    $("#ddlAreas").append($("<option></option>").val(value.ServiceID).html(value.Desc1));

                });


            },
            error: function (result) {
                // alert(result.status + " : " + result.StatusText);
            }
        });

    });

    $("#ddlAreas").change(function () {



        var areaidSelected = $('#ddlAreas').val();
        var govidSelected = $('#ddlGeove').val();
        debugger;
        $.ajax({

            type: "POST",
            url: "/Default.aspx/BindArea2Datas",
            data: "{areaid:'" + areaidSelected + "',govid:'" + govidSelected + "'}",
            contentType: "application/json; charset-utf-8",
            dataType: "json",

            //contentType: 'application/json',
            // data: govidSelected //JSON.stringify(govidSelected),

            success: function (result) {

                debugger;
                console.log(result);


                $("#ddlAreas2").empty();
                $("#ddlAreas2").append("<option value='0'>اختيار الجنسية</option>");
                $.each(result.d, function (key, value) {

                    $("#ddlAreas2").append($("<option></option>").val(value.code).html(value.Desc1));

                });


            },
            error: function (result) {
                // alert(result.status + " : " + result.StatusText);
            }
        });

    });

    $("#ddlAreas2").change(function () {



        var area2idSelected = $('#ddlAreas2').val();
        var govidSelected = $('#ddlGeove').val();
        debugger;
        $.ajax({

            type: "POST",
            url: "/Default.aspx/BindStreetDatas",
            data: "{area2id:'" + area2idSelected + "',govid:'" + govidSelected + "'}",
            contentType: "application/json; charset-utf-8",
            dataType: "json",

            //contentType: 'application/json',
            // data: govidSelected //JSON.stringify(govidSelected),

            success: function (result) {

                debugger;
                console.log(result);


                $("#ddlsteet").empty();
                $("#ddlsteet").append("<option value='0'>اختيار الجنسية</option>");
                $.each(result.d, function (key, value) {

                    $("#ddlsteet").append($("<option></option>").val(value.code).html(value.Desc1));

                });


            },
            error: function (result) {
                // alert(result.status + " : " + result.StatusText);
            }
        });

    });

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
        /*margin-right: 45px;*/
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

    .menuuu {
    padding: 0 0 0 15px;
}
</style>

<script type="text/javascript">
    $("document").ready(function () {

        var current_fs, next_fs, previous_fs; //fieldsets
        var opacity;
        var current = 1;
        var steps = $("fieldset").length;

        var step1validResult = false;
        var step2validResult = false;
        var step3validResult = false;
        var step4validResult = false;

        setProgressBar(current);

        $(".next").click(function () {

            current_fs = $(this).parent();


            if (current == 1) {

                step1validResult = false;
                step1Valid();

                if (step1validResult == true) {
                }
                else {
                    return false;
                }
            }

            if (current == 2) {
                step2validResult = false;
                step2Valid();
                if (step2validResult == true) {
                }
                else {
                    return false;
                }
            }


            next_fs = $(this).parent().next();

            //Add Class Active
            //$("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
            debugger;
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
            debugger;
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


        function step1Valid() {
            var ValComplainType = false;

            if ($('#<%= ddlComplainType.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlComplainType.ClientID %>').css('border', '1px solid red');
            }
            else {
                $('#<%= ddlComplainType.ClientID %>').css('border', 'none');
                ValComplainType = true;
            }

            if (ValComplainType == true

            ) {
                debugger;
                step1validResult = true;
            }
            else {

                step1validResult = false;
            }



        }

        function step2Valid() {

            var ValfirstName = false;
            var ValSecondNAme = false;
            var ValThirdName = false;
            var ValFamilyName = false;
            var ValDocumnetNo = false;
            var ValNationality = false;
            var ValTypeDocument = false;
            var ValEmail = false;
            var ValGovernate = false;
            var ValArea = false;

            var ValArea2 = false;
            var Valstreet = false;
            var ValMetro1 = false;
            var ValMetro2 = false;




            if ($('#<%= txtfirstName.ClientID %>').val().trim() != '') {

                $('#<%= txtfirstName.ClientID %>').css('border', 'none');
                ValfirstName = true;
            }
            else {

                $('#<%= txtfirstName.ClientID %>').css('border', '1px solid red');
            }

            if ($('#<%= txtSecondNAme.ClientID %>').val().trim() != '') {

                $('#<%= txtSecondNAme.ClientID %>').css('border', 'none');
                ValSecondNAme = true;
            }
            else {

                $('#<%= txtSecondNAme.ClientID %>').css('border', '1px solid red');
            }

            if ($('#<%= txtThirdName.ClientID %>').val().trim() != '') {

                $('#<%= txtThirdName.ClientID %>').css('border', 'none');
                ValThirdName = true;
            }
            else {

                $('#<%= txtThirdName.ClientID %>').css('border', '1px solid red');
            }



            if ($('#<%= txtFamilyName.ClientID %>').val().trim() != '') {

                $('#<%= txtFamilyName.ClientID %>').css('border', 'none');
                ValFamilyName = true;
            }
            else {

                $('#<%= txtFamilyName.ClientID %>').css('border', '1px solid red');
            }


            if ($('#<%= txtDocumnetNo.ClientID %>').val().trim() != '') {

                $('#<%= txtDocumnetNo.ClientID %>').css('border', 'none');
                ValDocumnetNo = true;
            }
            else {

                $('#<%= txtDocumnetNo.ClientID %>').css('border', '1px solid red');
            }



            if ($('#<%= ddlNationality.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlNationality.ClientID %>').css('border', '1px solid red');
            }
            else {
                $('#<%= ddlNationality.ClientID %>').css('border', 'none');
                ValNationality = true;
            }

            if ($('#<%= ddlTypeDocument.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlTypeDocument.ClientID %>').css('border', '1px solid red');
            }
            else {
                $('#<%= ddlTypeDocument.ClientID %>').css('border', 'none');
                ValTypeDocument = true;
            }



            if ($('#<%= txtEmail.ClientID %>').val().trim() != '') {
                $('#<%= txtEmail.ClientID %>').css('border', 'none');
                if ($('#<%= txtEmail.ClientID %>').val().trim() != "") {
                    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                    if (!regex.test($('#<%= txtEmail.ClientID %>').val())) {
                        $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

                    }
                    else {
                        $('#<%= txtEmail.ClientID %>').css('border', 'none');
                        ValEmail = true;
                    }
                }
                else {
                    $("#txtEmail").css('border', '1px solid red');

                }
            }
            else {
                $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

            }
            debugger;

            if ($("[id$=ddlGeove]").val() == "0") {
                $("[id$=ddlGeove]").css('border', '1px solid red');
            }
            else {
                $("[id$=ddlGeove]").css('border', 'none');
                ValGovernate = true;
            }




            if ($("[id$=ddlAreas]").val() == "0") {
                $("[id$=ddlAreas]").css('border', '1px solid red');
            }
            else {
                $("[id$=ddlAreas]").css('border', 'none');
                ValArea = true;
            }

            if ($("[id$=ddlAreas2]").val() == "0") {
                $("[id$=ddlAreas2]").css('border', '1px solid red');
            }
            else {
                $("[id$=ddlAreas2]").css('border', 'none');
                ValArea2 = true;
            }


            if ($('#<%= ddlComplainType.ClientID %> option:selected').val() == "1") {
                if ($('#<%= txtMeterNo.ClientID %>').val().trim() != '') {

                    $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
                    ValMetro1 = true;
                }
                else {

                    $('#<%= txtMeterNo.ClientID %>').css('border', '1px solid red');
                }
            }
            else {
                ValMetro1 = true;
                $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
            }


            if ($('#<%= ddlComplainType.ClientID %> option:selected').val() == "2") {

                if ($('#<%= txtMeterNo.ClientID %>').val().trim() != '') {

                    $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
                    ValMetro2 = true;
                }
                else {

                    $('#<%= txtMeterNo.ClientID %>').css('border', '1px solid red');
                }
            }
            else {
                ValMetro2 = true;
                $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
            }

            if (
                ValfirstName == true &&
                ValSecondNAme == true &&
                ValThirdName == true &&
                ValFamilyName == true &&
                ValDocumnetNo == true &&
                ValNationality == true &&
                ValTypeDocument == true &&
                ValEmail == true &&
                ValGovernate == true &&
                ValArea == true &&
                ValArea2 == true &&
                ValMetro1 == true &&
                ValMetro2 == true
            ) {
                debugger;
                step2validResult = true;
            }
            else {

                step2validResult = false;
            }


        }
    });
</script>



