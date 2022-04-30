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
<div class="modal fade welcome modal-done" id="myModalerror2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display: contents">شركة الكهرباء الأردنية</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                       <div class="err-box err-app alert alert-success">
                    
                </div>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <a href="/ar/Home/ComplainList" class="btn btn-primary" id="" style="width: 100%;padding: 20px;font-size: 20px;" >موافق</a>

            </div>
        </div>
    </div>
</div>

<div class="modal fade welcome modal-err" id="" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display: contents">شركة الكهرباء الأردنية</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                       <div class="err-box err-app alert alert-danger">
                    
                </div>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <a href="/ar/Home/ComplainList" class="btn btn-primary" id="" style="width: 100%;padding: 20px;font-size: 20px;" >موافق</a>

            </div>
        </div>
    </div>
</div>

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

                        <ul class="list-unstyled steplist Compiansteps" id="progressbar2" style="margin-bottom: 30px;">
                                <li class="active"><a href="javascript:void">الشكوى المقدم لها</a></li>
                                <li><a href="javascript:void">المعلومات الشخصية</a></li>
                                <li><a href="javascript:void">عنوان الشكوى</a></li>
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
                                          <select TabIndex="2" class="complain-type-select">
                                                <option value="0">الرجاء اختيار نوع الشكوى</option>
                                          </select>
                                        <asp:DropDownList ID="ddlComplainType" runat="server" TabIndex="2" Width="100%" Style="display:none">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group damage-type">

                                        <label><span>*</span>نوع العطل</label>
                                          <select TabIndex="2" class="damage-type-select">
                                                <option value="0">الرجاء اختيار نوع العطل</option>
                                          </select>

                                    </div>
                                     <div class="form-group meter-number-req">
                                        <label><span>*</span>رقم العداد</label>
                                          <select TabIndex="2" class="meter-number-select req">
                                                <option value="0">الرجاء اختيار رقم العداد</option>
                                          </select>
                                    </div>
                                    <div class="form-group meter-number-notreq">
                                        <label>رقم العداد ( اختياري )</label>
                                          <select TabIndex="2" class="meter-number-select">
                                                <option value="0">الرجاء اختيار رقم العداد</option>
                                          </select>
                                    </div>
                                     <div class="form-group trans-number">
                                        <label><span>*</span> رقم المعاملة</label>
                                          <asp:TextBox ID="transNumber" runat="server" PlaceHolder=" رقم المعاملة "></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <input type="button" name="next" class="btn next next1 action-button" value="التالي" onclick=""/>
                        </fieldset>
                        <fieldset>
                            <h3>المعلومات الشخصية</h3>

                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>الاسم الأول</label>
                                        <asp:HiddenField runat="server" ID="hdnServiceID" />
                                        <asp:TextBox ID="txtfirstName" runat="server" PlaceHolder="الاسم الأول" ReadOnly="true"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>اسم الأب </label>
                                        <asp:TextBox ID="txtSecondNAme" runat="server" PlaceHolder="اسم الأب" ReadOnly="true"></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>اسم الجد </label>
                                        <asp:TextBox ID="txtThirdName" runat="server" PlaceHolder="اسم الجد " ReadOnly="true"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>اسم العائلة </label>
                                        <asp:TextBox ID="txtFamilyName" runat="server" PlaceHolder="اسم العائلة " ReadOnly="true" ></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label><span>*</span>  الجنسية</label>
                                                <select class="national-select">
                                                    <option value="0">اختيار الجنسية</option>
                                                    <option value="1">الأردنية</option>
                                                    <option value="2">أخرى</option>
                                                </select>
                                                <asp:DropDownList ID="ddlNationality" OnSelectedIndexChanged="ddlNationality_SelectedIndexChanged" AutoPostBack="true" runat="server" TabIndex="2" Width="100%" Style="display:none" >
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label ><span>*</span>  نوع الوثيقة</label>
                                                <select class="nationalTypeDocument-select">
                                                    <option value="0">يرجى اختيار الجنسية</option>
                                                </select>
                                                <asp:DropDownList ID="ddlTypeDocument" runat="server" TabIndex="2" Width="100%" Style="display:none">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6">
                                            <div class="form-group">
                                                <label><span>*</span> رقم ( الوطني / الوثيقة ) </label>
                                                <asp:TextBox ID="txtDocumnetNo" runat="server" PlaceHolder="رقم الوثيقة" ></asp:TextBox>
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
                                        <asp:TextBox ID="txtEmail" runat="server" PlaceHolder=" البريد الالكتروني " ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>رقم الهاتف </label>
                                        <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="رقم الهاتف " ReadOnly="true" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                          

                            <input type="button" name="next" class="btn next next2 action-button" value="التالي" />
                            <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                        </fieldset>

                          <fieldset>

                              <div class="alert alert-danger err-label" >لن تستطيع تعديل عنوان الشكوى, سيتم إعتماد عنوان العداد</div>

                                <div class="row">

                                <div class="col-lg-6 col-md-6 col-sm-6" style="display:none" >
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
                                        <select class="city-select">
                                            <option value="0">أختيار المحافظة</option>
                                        </select>
                                        <select class="city-select-disabled" disabled >
                                            
                                        </select>
                                        <select id="ddlGeove" name="ddlGeove" class="form-control" tabindex="2" style="display:none"></select>
                                    </div>

                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>المنطقة </label>
                                        <select class="areas-select">
                                             <option value="0">لعرض المناطق يرجى اختيار المحافظة</option>
                                        </select>
                                        <select class="areas-select-disabled" disabled>
                                        </select>
                                        <select id="ddlAreas" name="ddlAreas" class="form-control" tabindex="2" style="display:none" ></select>

                                    </div>

                                </div>
                            </div>

                            <div class="row">

                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label><span>*</span>الحي</label>
                                        <select class="neighborhoods-select">
                                            <option value="0">لعرض الاحياء يرجى اختيار المنطقة</option>
                                        </select>
                                        <select class="neighborhoods-select-disabled" disabled>

                                        </select>
                                        <select id="ddlAreas2" name="ddlAreas2" class="form-control" tabindex="2" style="display:none"></select>
                                    </div>

                                </div>

                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <div class="form-group">
                                        <label style="margin-top:7px">الشارع</label>
                                        <select class="street-select">
                                           <option value="0">لعرض الشوارع يرجى اختيار الحي</option>

                                        </select>
                                        <select class="street-select-disabled" disabled>

                                        </select>
                                        <select id="ddlsteet" name="ddlsteet" class="form-control" tabindex="2" style="display:none"></select>
                                    </div>

                                </div>
                                 <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label><span>*</span>تفاصيل العنوان ( رقم البناية رقم الشقة أقرب معلم ) </label>
                                        <asp:TextBox ID="txtComplianTitle" runat="server" PlaceHolder="عنوان الشكوى " CssClass="complain-address"></asp:TextBox>
                                         <input type="text" class="complain-address-disabled" disabled>

                                    </div>
                                </div>
                            </div>


                           

                               <input type="button" name="next" class="next action-button next3" value="التالي" />
                            <input type="button" name="previous" class="previous action-button-previous" value="السابق" />

                          </fieldset>

                        <fieldset>

                            <h3>تفاصيل الشكوى </h3>

                            <div class="row">


                            </div>
                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <label><span>*</span> تفاصيل الشكوى </label>
                                        <asp:TextBox ID="txtComplainDetail" runat="server" PlaceHolder=" تفاصيل الشكوى " TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                                                      <div class="row" style="">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label>اختر المنطقة بالتحديد</label>
                            <div id="gmap" style="width: 100%; height: 450px;"></div>
                                <input
      id="pac-input"
      class="controls "
      type="text"
      placeholder="البحث"
    />

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

                       <button class="btn action-button sendComplain next4" type="button" id="btbvalid" ">ارسال الطلب</button>
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

          <div id="loading">
              <div id="loader"></div><br />
              <h3 style="color:#007fc3;font-weight:bold">شركة الكهرباء الأردنية  </h3>
                            <h4 style="color:#007fc3;font-weight:bold">الرجاء الأنتظار  </h4>

  <%--<img id="loading-image" src="/App_Themes/ThemeAr/img/Dual Ring-1s-200px (3).gif" alt="Loading..." style="width:200px;height:200px" />--%>
</div>
        <style>
            #loader {
    display: block;
    position: relative;

    width: 150px;
    height: 150px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #3498db;
    -webkit-animation: spin 2s linear infinite;
    animation: spin 2s linear infinite;
}
            #loader:before {
    content: "";
    position: absolute;
    top: 5px;
    left: 5px;
    right: 5px;
    bottom: 5px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #e74c3c;
    -webkit-animation: spin 3s linear infinite;
    animation: spin 3s linear infinite;
}
#loader:after {
    content: "";
    position: absolute;
    top: 15px;
    left: 15px;
    right: 15px;
    bottom: 15px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #f9c922;
    -webkit-animation: spin 1.5s linear infinite;
    animation: spin 1.5s linear infinite;
}
            #loading {
  position: fixed;
  display: flex;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  text-align: center;
  background-color: rgba(255, 255, 255,1);
  z-index: 99;
  justify-content:center;
  align-items:center;
      flex-direction: column;

}

#loading-image {

  z-index: 99999;
}
@-webkit-keyframes spin {
	0%   {-webkit-transform: rotate(0deg);}

	100% {-webkit-transform: rotate(360deg);}
}
@keyframes spin {
	0%   {transform: rotate(0deg);}

	100% {transform: rotate(360deg);}
}
        </style>
 
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://maps.google.com/maps/api/js?key=AIzaSyA7f_t2Ccx3tdV_Mz2pT0zdVioGU6SiKS4&callback=initAutocomplete&libraries=places&v=weekly"></script>

<%-- New Api For Complain  :  --%>
<script>    
    $(window).on('load', function () {
        $('#loading').hide();
    });
    var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';

    /* ------------------- Add Complain API Variable ----------------------- */
    var MobileNoURL = $("#hdnmobileno").val();
    var ComplainantName = "";
    var ComplainantType = "";
    var ComplainTypeName = "";
    var ComplainFailureType = "";
    var MeterNumber = "";
    var requsterName = ""
    var Nationality = "";
    var NationalityDoc = "";
    var NationalityNum = "";
    var ComplainEmail = "";
    var ComplainPhoneNumber = "";
    var ProvinceId = "";
    var ProvinceName = "";
    var AreaIdLast = "";
    var AreaNameLast = "";
    var NeighborhoodIdLast = "";
    var NeighborhoodNameLast = "";
    var StreetIdLast = "";
    var StreetNameLast = "";
    var AddrssDetails = "";
    var ComplainDetails = "";
    var arrayAddress = undefined;
    /* --------------------- Disabled Global Variable For Address Section -----------------------   */
    var DisabledCity = "";
    var DisabledArea = "";
    var DisabledNeighbrhood = "";
    var DisabledStreat = "";

    var BranchId;
    var AreaId;
    var NeighborhoodId;

    var complainType = [];
    var damageType = [];
    var meterNumberList = [];
    var arrayMeter = [];


    var lonFAPI = null;
    var latFAPI = null;
    /* ----------------------- Validation Variable ----------------------- */
    // section 1 : 
    var validComplainType = false;
    var valDamageType = false;
    var valMeterReq = false;
    // section 2 : 
    var validationFname = true;
    var validationM1name = true;
    var validationM2name = true;
    var validationLname = true;
    var validationNatio = false;
    var validationTypeNatio = false;
    var validationDocNatio = true;
    var validationEmail = true;
    var validationPhone = true;
    var validationCity = false;
    var validationArea = false;
    var validationNeigh = false;
    var validationTrans = false;

    var addressPass = false;
    //if ($('#aioConceptName').find(":selected").text() == "0") {

    //} else {

    //}
    $(document).ready(function () {

        $.ajax({
            type: "POST",
            url: APIUrl + "Complaints/RequestComplaint",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
            },
            data: JSON.stringify({
                MobileNumber: MobileNoURL,
                LanguageId: "AR"
            }),
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                complainType = data.body.complanetTypeList;
                damageType = data.body.failureTypesList;
                meterNumberList = data.body.meterNumberList;
                arrayMeter = data.body.meterNumberList;



                // for loop for complain type : 
                $.each(complainType, function (key, value) {
                    // value == codeId from API
                    var htmlComplainDropDown = "<option value='" + value.codeId + "'>" + value.codeName + "</option>";
                    $(".complain-type-select").append(htmlComplainDropDown);
                })

                // foor loop for damage type : 
                $.each(damageType, function (key, value) {
                    // value == codeId from API
                    var htmlComplainDropDown = "<option value='" + value.codeId + "'>" + value.codeName + "</option>";
                    $(".damage-type-select").append(htmlComplainDropDown);
                })

                // foor loop for meter Number List :
                $.each(meterNumberList, function (key, value) {
                    // value == codeId from API
                    var htmlComplainDropDown = "<option value='" + ++key + "' meter-num='" + value.meterNumber + "'>" + value.name + " : " + value.meterNumber + "</option>";
                    $(".meter-number-select").append(htmlComplainDropDown);
                })

                $(".complain-type-select").on('change', function () {

                    ComplainFailureType = "";
                    ComplainTypeName = "";
                    MeterNumber = "";

                    ComplainantName = $(this).find('option:selected').text();
                    ComplainantType = this.value;

                    /* *********** -- Validation For Input -- *********** */
                    if (this.value == 0) {
                        validComplainType = false;
                    } else {
                        validComplainType = true;
                    }


                    if (this.value == 1) {

                        $(".damage-type").show()
                        $(".meter-number-notreq").show()
                    } else {

                        $(".damage-type").hide()
                        $(".meter-number-notreq").hide()

                    }

                    if (this.value == 7) {
                        $(".meter-number-req").show()
                    } else {
                        $(".meter-number-req").hide()
                    }
                    if (this.value == 8) {
                        $(".trans-number").show()
                    } else {
                        $(".trans-number").hide()
                    }
                })
                $(".damage-type-select").on("change", function () {
                    ComplainFailureType = this.value;
                    ComplainTypeName = $(this).find('option:selected').text();

                    if (this.value == 0) {
                        valDamageType = false;
                    } else {
                        valDamageType = true;
                    }
                })
                $("select.meter-number-select.req").on("change", function () {
                    MeterNumber = $(this).find('option:selected').attr("meter-num")
                    if (this.value == 0) {
                        valMeterReq = false;
                    } else {
                        valMeterReq = true;
                    }
                })
                $("select.meter-number-select").on("change", function () {
                    MeterNumber = $(this).find('option:selected').attr("meter-num")
                })
                $(".national-select").on("change", function () {
                    if (this.value == 0) {
                        $(".nationalTypeDocument-select").empty()
                        $(".nationalTypeDocument-select").append("<option value='0'>يرجى اختيار الجنسية</option>");
                    }
                    else if (this.value == 1) {

                        $(".nationalTypeDocument-select").empty()

                        $(".nationalTypeDocument-select").append("<option value='1'>هوية أحوال مدنية</option>");
                    } else {
                        $(".nationalTypeDocument-select").empty()
                        $(".nationalTypeDocument-select").append("<option value='2'> جواز سفر</option><option value='3'>اقامة</option>");

                    }
                    if ($(".nationalTypeDocument-select").val() == 0) {
                        validationTypeNatio = false;
                    } else {
                        validationTypeNatio = true;
                    }

                })
                $('#<%= transNumber.ClientID %>').on("keyup", function () {
                    MeterNumber = this.value;
                    if (this.value == 0) {
                        validationTrans = false;
                    } else {
                        validationTrans = true;
                    }
                })
                /* -------------------- Validation section 2 -------------------- */
                $('#<%= txtfirstName.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationFname = false;
                    } else {
                        validationFname = true;
                    }
                })
                $('#<%= txtSecondNAme.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationM1name = false;
                    } else {
                        validationM1name = true;
                    }
                })
                $('#<%= txtThirdName.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationM2name = false;
                    } else {
                        validationM2name = true;
                    }
                })
                $('#<%= txtFamilyName.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationLname = false;
                    } else {
                        validationLname = true;
                    }
                })
                $("select.national-select").on("change", function () {
                    /*Nationality = $(this).find('option:selected').text();*/
                    if (this.value == 0) {
                        validationNatio = false;
                    } else {
                        validationNatio = true;
                    }
                })
                $(".nationalTypeDocument-select").on("change", function () {
                    // NationalityDoc = $(this).find('option:selected').text();
                    if (this.value == 0) {
                        validationTypeNatio = false;
                    } else {
                        validationTypeNatio = true;
                    }

                })
                $('#<%= txtDocumnetNo.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationDocNatio = false;
                    } else {
                        validationDocNatio = true;
                    }
                })
                $('#<%= txtEmail.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationEmail = false;
                    } else {
                        validationEmail = true;
                    }
                })
                $('#<%= txtMobileNo.ClientID %>').on("keyup", function () {
                    if (this.value == 0) {
                        validationPhone = false;
                    } else {
                        validationPhone = true;
                    }
                })
            },
            error: function (result) {
                console.log(result)
            }
        });



        $.ajax({
            type: "POST",
            url: APIUrl + "Complaints/GetCallCenterProviance",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
            },
            //data: JSON.stringify({
            //    MobileNumber: MobileNoURL,
            //    LanguageId: "AR"
            //}),
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                $.each(data.body, function (key, value) {
                    var htmlBox = "<option value='" + value.codeId + "'>" + value.codeName + "</option>"
                    $(".city-select").append(htmlBox);
                })
            },
            error: function (err) {
                console.log(err);
            }
        })

        $(".city-select").on("change", function () {
            BranchId = Number(this.value);
            ProvinceName = $(this).find('option:selected').text();
            ProvinceId = this.value;

            if (this.value == 0) {
                validationCity = false;
            } else {
                validationCity = true
            }

            if (BranchId != 0) {
                $.ajax({
                    type: "POST",
                    url: APIUrl + "Complaints/GetCallCenterAreas",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                    },
                    data: JSON.stringify({
                        BranchId: BranchId,
                        LanguageId: "AR"
                    }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        $(".areas-select").empty()
                        $(".areas-select").append("<option value='0'>أختيار المنطقة</option>");

                        $.each(data.body, function (key, value) {
                            var htmlBox = "<option value='" + value.codeId + "' >" + value.codeName + "</option >"
                            $(".areas-select").append(htmlBox);
                        })

                    },
                    error: function (err) {
                        console.log(err);
                    }
                })
            }
            if ($(".areas-select").val() == 0) {
                validationArea = false
            } else {
                validationArea = true
            }
        })


        $(".areas-select").on("change", function () {
            AreaId = Number(this.value);
            AreaIdLast = this.value;
            AreaNameLast = $(this).find('option:selected').text();


            if (this.value == 0) {
                validationArea = false
            } else {
                validationArea = true
            }


            if (AreaId != 0) {
                $.ajax({
                    type: "POST",
                    url: APIUrl + "Complaints/GetCallCenterNeighborhood",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                    },
                    data: JSON.stringify({
                        BranchId: BranchId,
                        AreaId: AreaId,
                        LanguageId: "AR"
                    }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        $(".neighborhoods-select").empty()
                        $(".neighborhoods-select").append("<option value='0'>أختيار الحي</option>");
                        $.each(data.body, function (key, value) {
                            var htmlBox = "<option value='" + value.codeId + "'>" + value.codeName + "</option>"
                            $(".neighborhoods-select").append(htmlBox);
                        })

                    },
                    error: function (err) {
                        console.log(err);
                    }
                })
            }

            if ($(".neighborhoods-select").val() == 0) {


                validationNeigh = false
            } else {
                validationNeigh = true
            }
        })


        $(".neighborhoods-select").on("change", function () {
            NeighborhoodId = Number(this.value);
            NeighborhoodNameLast = $(this).find('option:selected').text();
            NeighborhoodIdLast = this.value;
            if (this.value == 0) {
                validationNeigh = false
            } else {
                validationNeigh = true
            }

            if (NeighborhoodId != 0) {
                $.ajax({
                    type: "POST",
                    url: APIUrl + "Complaints/GetCallCenterStreets",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                    },
                    data: JSON.stringify({
                        BranchId: BranchId,
                        AreaId: AreaId,
                        NeighborhoodId: NeighborhoodId,
                        LanguageId: "AR"
                    }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    success: function (data) {
                        $(".street-select").empty()
                        $(".street-select").append("<option value='0'>أختيار الشارع</option>");
                        $.each(data.body, function (key, value) {
                            var htmlBox = "<option value='" + value.codeId + "'>" + value.codeName + "</option>"
                            $(".street-select").append(htmlBox);
                        })

                    },
                    error: function (err) {
                        console.log(err);
                    }
                })
            }

        })
        $(".street-select").on("change", function () {
            StreetIdLast = this.value;
            StreetNameLast = $(this).find('option:selected').text();
        })



    })



</script>



<script type="text/javascript">
<%--    function SendClick() {


       
        
        var ValComplainDetail = false;
    
  


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
            var TeleMeterNo = $("[id$=txtMeterNo]").val();

            $.ajax({

                type: "POST",
                url: "/Default.aspx/SaveComplainData",
                data: "{BranchID:'" + BranchID + "',RequesterMobile:'" + RequesterMobile + "',RequesterName:'" + RequesterName + "',ServiceID:'" + ServiceID + "',CategoryID:'" + CategoryID + "',SubCategoryID:'" + SubCategoryID + "',IssueTitle:'" + IssueTitle + "',IssueDescription:'" + IssueDescription + "',TeleMeterNo:'" + TeleMeterNo + "'}",
                contentType: "application/json; charset-utf-8",
                dataType: "json",
                success: function (result) {

                     
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

    }--%>
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
       @media(max-width:767px) {
        #pac-input {
                        z-index: 0 !important;
    position: absolute !important;
    left: 0 !important;
    top:60px !important;
    width: 300px !important;
    height: 45px !important;
        }
    }
    @media(max-width:375px){
                #pac-input {
                        z-index: 0 !important;
    position: absolute !important;
    left: 0 !important;
    top:60px !important;
    width: 300px !important;
    height: 45px !important;
        }
    }
    @media(min-width:768px){
            #pac-input{
            z-index: 0 !important;
    position: absolute !important;
    left: 200px !important;
    width: 350px !important;
    height: 45px !important;
    top: 5px !important;
    }
    }
</style>

<script>

    $("#ddlGeove").append("<option value='0'>اختيار الجنسية</option>");
    $("#ddlAreas").append("<option value='0'>اختيار الجنسية</option>");
    $("#ddlAreas2").append("<option value='0'>اختيار الجنسية</option>");
    $("#ddlsteet").append("<option value='0'>اختيار الجنسية</option>");

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Default.aspx/BindGovernetData",
        data: "{}",
        success: function (result) {


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

        $.ajax({

            type: "POST",
            url: "/Default.aspx/BindArea2Datas",
            data: "{areaid:'" + areaidSelected + "',govid:'" + govidSelected + "'}",
            contentType: "application/json; charset-utf-8",
            dataType: "json",

            //contentType: 'application/json',
            // data: govidSelected //JSON.stringify(govidSelected),

            success: function (result) {


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

        $.ajax({

            type: "POST",
            url: "/Default.aspx/BindStreetDatas",
            data: "{area2id:'" + area2idSelected + "',govid:'" + govidSelected + "'}",
            contentType: "application/json; charset-utf-8",
            dataType: "json",

            //contentType: 'application/json',
            // data: govidSelected //JSON.stringify(govidSelected),

            success: function (result) {


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
    input.complain-address-disabled {
    background: #eee !important;
}
    /* new API Design  : */
    .damage-type{
        display:none 
    }    
    .meter-number-notreq{
        display:none 
    }
    .meter-number-req{
        display:none
    }
    .trans-number{
        display:none
    }
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
        border-bottom: 60px solid #ffde23;
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

    .steplist li a {  
    font-size: 15px;  
}

    .steplist li:last-child.active::before {
        border-bottom: 60px solid #ffde23;
    }

    .steplist li::before {
    border-bottom: 60px solid #ffde23;
}
    .steplist li::after {
    border-top: 60px solid #ffde23;
}
    .steplist li:first-child::before {
    border-bottom: 60px solid #007fc3;
}


@media only screen and (max-width: 1367px) and (min-width: 1300px) {

.steplist li::before {
    border-bottom: 60px solid #ffde23;
}
 .steplist li:first-child::before {
            border-bottom: 60px solid #007fc3;
        }
 .steplist li:last-child::before {
    border-bottom: 60px solid #f2f2f2;
}

}

.modal-body {
    padding: 42px !important;
}
.modal-body h4 {
    font-size: 25px !important;
}
.err-label{
    display:none
}
.err-box.err-app.alert.alert-danger {
    font-size: 24px;
}
.err-box.err-app.alert.alert-success {
    font-family: Tahoma, "Helvetica Neue", Arial, Helvetica, sans-serif;
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

                if (validComplainType == false) {
                    $(".complain-type-select").css("border", "1px solid red");
                    return false;
                } else {
                    $(".complain-type-select").css("border", "1px solid #e2e2e2");
                }
                if ($(".complain-type-select").val() == 1) {
                    if (valDamageType == false) {
                        $(".damage-type-select").css("border", "1px solid red");
                        return false;
                    } else {
                        $(".damage-type-select").css("border", "1px solid #e2e2e2");
                    }
                }
                if ($(".complain-type-select").val() == 7) {
                    if (valMeterReq == false) {
                        $("select.meter-number-select.req").css("border", "1px solid red");
                        return false;
                    } else {
                        $("select.meter-number-select.req").css("border", "1px solid #e2e2e2");
                    }
                }
                if ($(".complain-type-select").val() == 8) {
                    if (validationTrans == false) {
                        $('#<%= transNumber.ClientID %>').css("border", "1px solid red");
                        return false;
                    } else {
                        $('#<%= transNumber.ClientID %>').css("border", "1px solid #e2e2e2");
                    }
                }


                //step1validResult = false;
                //step1Valid();

                //if (step1validResult == true) {
                //}
                //else {
                //    return false;
                //}

                $.each(arrayMeter, function (key, value) {
                    if (value.fileNumberAddressesData != undefined) {
                        if (value.meterNumber == MeterNumber) {
                            
                            arrayAddress = value.fileNumberAddressesData;
                            ProvinceName = arrayAddress.provinceName;
                            ProvinceId = arrayAddress.provinceId;
                            AreaNameLast = arrayAddress.areaName;
                            AreaIdLast = arrayAddress.areaId;
                            NeighborhoodNameLast = arrayAddress.neighborhoodName;
                            NeighborhoodIdLast = arrayAddress.neighborhoodId;
                            AddrssDetails = arrayAddress.addressDetails;


                            lonFAPI = arrayAddress.long;
                            latFAPI = arrayAddress.latt;

                            console.log("s", lonFAPI)
                            console.log("s1", latFAPI)
                            if (arrayAddress.streetName == undefined) {
                                StreetNameLast = "";
                            } else {
                                StreetNameLast = arrayAddress.streetName;
                            }
                            if (arrayAddress.streetId == undefined) {
                                StreetIdLast = "";
                            } else {
                                StreetIdLast = arrayAddress.streetId;
                            }

                            $(".err-label").show();
                            $(".city-select-disabled").show()
                            $(".areas-select-disabled").show();
                            $(".neighborhoods-select-disabled").show();
                            $(".street-select-disabled").show();
                            $(".complain-address-disabled").show();

                            $(".city-select-disabled").empty();
                            $(".areas-select-disabled").empty()
                            $(".neighborhoods-select-disabled").empty()
                            $(".street-select-disabled").empty();
                            $(".complain-address-disabled").empty();

                            $(".city-select-disabled").append("<option value='" + value.provinceId + "'>" + ProvinceName + "</option>")
                            $(".areas-select-disabled").append("<option value='" + value.areaId + "'>" + AreaNameLast + "</option>");
                            $(".neighborhoods-select-disabled").append("<option value='" + value.neighborhoodId + "'>" + NeighborhoodNameLast + "</option>");
                            $(".street-select-disabled").append("<option>" + StreetNameLast + "</option>");
                            $(".complain-address-disabled").val(AddrssDetails)



                            $(".city-select").hide()
                            $(".areas-select").hide();
                            $(".neighborhoods-select").hide();
                            $(".street-select").hide();
                            $(".complain-address").hide();

                          
                            addressPass = true;
                            return false;
                        } else {
                            $(".err-label").hide();
                            $(".city-select-disabled").hide()
                            $(".areas-select-disabled").hide();
                            $(".neighborhoods-select-disabled").hide();
                            $(".street-select-disabled").hide();
                            $(".complain-address-disabled").hide();

                            $(".city-select").show()
                            $(".areas-select").show();
                            $(".neighborhoods-select").show();
                            $(".street-select").show();
                            $(".complain-address").show();

                            $('.city-select').prop('selectedIndex', 0)
                            $('.areas-select').prop('selectedIndex', 0)
                            $('.neighborhoods-select').prop('selectedIndex', 0)
                            $('.street-select').prop('selectedIndex', 0)
                            arrayAddress = undefined
                            addressPass = false;

                        }
                    } else {
                    }
                })






                if ($(".complain-type-select").val() == "7" || $(".complain-type-select").val() == "8") {
   

                    $.ajax({
                        type: "POST",
                        url: APIUrl + "Complaints/ValidateComplaint",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                        },
                        data: JSON.stringify({
                            MobileNumber: MobileNoURL,
                            ComplainType: $(".complain-type-select").val(),
                            ProvinceId: ProvinceId.toString(),
                            AreaId: AreaIdLast.toString(),
                            NeighborhoodId: NeighborhoodIdLast.toString(),
                            MeterNumber: MeterNumber,
                            LanguageId: "ar"
                        }),
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            console.log(data)
                        },
                        error: function (err) {
                            console.log("err2 : ", err.responseJSON.errors);
                            $(".modal-err .err-app").text(err.responseJSON.errors)
                            $(".modal-err").modal("show")
                            $(".next2").attr("disabled", true);
                        }
                    })
                }
                if ($('#<%= ddlNationality.ClientID %>').val() != null) {
                    validationTypeNatio = true;
                    validationNatio = true;
                    $(".national-select").val($('#<%= ddlNationality.ClientID %>').val())
                    $(".nationalTypeDocument-select").empty()
                    $(".nationalTypeDocument-select").append("<option value='0'>يرجى اختيار الجنسية</option>");
                    $(".nationalTypeDocument-select").append("<option value='1'>هوية أحوال مدنية</option>");
                    $(".nationalTypeDocument-select").append("<option value='2'> جواز سفر</option><option value='3'>اقامة</option>");
                    if ($('#<%= ddlNationality.ClientID %>').val() == 1) {

                                        $(".nationalTypeDocument-select").val($('#<%= ddlNationality.ClientID %>').val());
                                    } else {

                                        $(".nationalTypeDocument-select").val(2);
                                    }
                                }
            }

            if (current == 2) {

                if (validationFname == false) {
                    $('#<%= txtfirstName.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtfirstName.ClientID %>').css("border", "1px solid #e2e2e2");
                }
                if (validationM1name == false) {
                    $('#<%= txtSecondNAme.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtSecondNAme.ClientID %>').css("border", "1px solid #e2e2e2");
                }
                if (validationM2name == false) {
                    $('#<%= txtThirdName.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtThirdName.ClientID %>').css("border", "1px solid #e2e2e2");
                }
                if (validationLname == false) {
                    $('#<%= txtFamilyName.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtFamilyName.ClientID %>').css("border", "1px solid #e2e2e2");
                }
                if (validationNatio == false) {
                    $("select.national-select").css("border", "1px solid red");
                    return false;
                } else {
                    $("select.national-select").css("border", "1px solid #e2e2e2");
                }
                if (validationTypeNatio == false) {
                    $("select.nationalTypeDocument-select").css("border", "1px solid red");
                    return false;
                } else {
                    $("select.nationalTypeDocument-select").css("border", "1px solid #e2e2e2");
                }
                if (validationDocNatio == false) {
                    $('#<%= txtDocumnetNo.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtDocumnetNo.ClientID %>').css("border", "1px solid #e2e2e2");
                }
                if (validationEmail == false) {
                    $('#<%= txtEmail.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtEmail.ClientID %>').css("border", "1px solid #e2e2e2");
                }
                if (validationPhone == false) {
                    $('#<%= txtMobileNo.ClientID %>').css("border", "1px solid red");
                    return false;
                } else {
                    $('#<%= txtMobileNo.ClientID %>').css("border", "1px solid #e2e2e2");
                }



                requsterName = $('#<%= txtfirstName.ClientID %>').val() + " " + $('#<%= txtSecondNAme.ClientID %>').val() + " " +
                    $('#<%= txtThirdName.ClientID %>').val() + " " + $('#<%= txtFamilyName.ClientID %>').val();
                NationalityNum = $('#<%= txtDocumnetNo.ClientID %>').val();
                NationalityDoc = $(".nationalTypeDocument-select").val();
                Nationality = $("select.national-select").val();
                ComplainPhoneNumber = $('#<%= txtMobileNo.ClientID %>').val();
                ComplainEmail = $('#<%= txtEmail.ClientID %>').val();



            }



            var ValComplianTitle = false;

            if (current == 3) {
                if (arrayAddress == undefined) {

                
                if (validationCity == false) {
                    $('.city-select').css("border", "1px solid red");
                    return false;
                } else {
                    $('.city-select').css("border", "1px solid #e2e2e2");
                }
                if (validationArea == false) {
                    $('.areas-select').css("border", "1px solid red");
                    return false;
                } else {
                    $('.areas-select').css("border", "1px solid #e2e2e2");
                }
                if (validationNeigh == false) {
                    $('.neighborhoods-select').css("border", "1px solid red");
                    return false;
                } else {
                    $('.neighborhoods-select').css("border", "1px solid #e2e2e2");
                }
                }
                if (addressPass != true) {
                    if ($('#<%= txtComplianTitle.ClientID %>').val().trim() != '') {

                        $('#<%= txtComplianTitle.ClientID %>').css('border', 'none');
                }
                else {
                    $('#<%= txtComplianTitle.ClientID %>').css('border', '1px solid red');
                    return false;
                }
                    AddrssDetails = $('#<%= txtComplianTitle.ClientID %>').val();
                }



                if ($(".complain-type-select").val() == "1" || $(".complain-type-select").val() == "5") {

       
                  
                    $.ajax({
                        type: "POST",
                        url: APIUrl + "Complaints/ValidateComplaint",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                        },
                        data: JSON.stringify({
                            MobileNumber: MobileNoURL,
                            ComplainType: $(".complain-type-select").val(),
                            ProvinceId: ProvinceId.toString(),
                            AreaId: AreaIdLast.toString(),
                            NeighborhoodId: NeighborhoodIdLast.toString(),
                            MeterNumber: MeterNumber,
                            LanguageId: "ar"
                        }),
                        contentType: "application/json; charset=utf-8",
                        async: false,
                        success: function (data) {
                            console.log(data)
                        },
                        error: function (err) {
                            console.log("err1 : ", err.responseJSON.errors);
                            $(".modal-err .err-app").text(err.responseJSON.errors)
                            $(".modal-err").modal("show")
                            $(".next4").attr("disabled", true);

                        }
                    })
                }





      
            }


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


<%--        function step1Valid() {
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
                 
                step1validResult = true;
            }
            else {

                step1validResult = false;
            }



        }--%>

        function step2Valid() {

            var ValfirstName = false;
            var ValSecondNAme = false;
            var ValThirdName = false;
            var ValFamilyName = false;
            var ValDocumnetNo = false;
            var ValNationality = false;
            var ValTypeDocument = false;
            var ValEmail = false;
           
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
            
            if (
                ValfirstName == true &&
                ValSecondNAme == true &&
                ValThirdName == true &&
                ValFamilyName == true &&
                ValDocumnetNo == true &&
                ValNationality == true &&
                ValTypeDocument == true &&
                ValEmail == true               
            ) {
                 
                step2validResult = true;
            }
            else {

                step2validResult = false;
            }


        }
        //-------------------------------------------------------------------------

            function step3Valid() {

               
                var ValGovernate = false; 
                var ValArea = false; 

                var ValArea2 = false;
               
                var ValMetro1 = false; 
                var ValMetro2 = false; 

                 //------------------------------------- Str 

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


       <%--         if ($('#<%= ddlComplainType.ClientID %> option:selected').val() == "1")
                {
                     
                     if ($('#<%= txtMeterNo.ClientID %>').val().trim() != '')
                     {
                                $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
                         ValMetro1 = true;
                         ValMetro2 = true;
                     }
                     else
                     {
                            $('#<%= txtMeterNo.ClientID %>').css('border', '1px solid red');
                     }
                }
                else
                {
                     
                        ValMetro1 = true;
                        //$('#<%= txtMeterNo.ClientID %>').css('border', 'none');

                    //--------------------------------------------------
                    if ($('#<%= ddlComplainType.ClientID %> option:selected').val() == "2")
                    {

                        if ($('#<%= txtMeterNo.ClientID %>').val().trim() != '')
                        {

                         $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
                         ValMetro2 = true;
                        }
                        else
                        {
                        $('#<%= txtMeterNo.ClientID %>').css('border', '1px solid red');
                        }
                    }
                    else
                    {
                              ValMetro2 = true;
                              $('#<%= txtMeterNo.ClientID %>').css('border', 'none');
                    }
                        //----------------------------------------------------

                }--%>


               

                 if (
                     ValGovernate == true &&
                     ValArea == true &&
                     ValArea2 == true &&
                     ValMetro1 == true &&
                     ValMetro2 == true
                 ) {
                      
                     step3validResult = true;
                 }
                 else {

                     step3validResult = false;
                 }


             }

    });
    $(".meter-number-select").on("change", function () {
        $(document).ready(function () {
            var lati = $("#<%=lblLatitude.ClientID%>").val();
                var lang = $("#<%=lblLongiude.ClientID%>").val();

                document.getElementById('latlbl').innerHTML = lati;
                document.getElementById('lonlbl').innerHTML = lang;

                if (lonFAPI != null && latFAPI != null) {
                    lati = latFAPI;
                    lang = lonFAPI;
                    console.log("s", lati)
                    console.log("s", lang)
                    document.getElementById('latlbl').innerHTML = latFAPI;
                    document.getElementById('lonlbl').innerHTML = lonFAPI;
                }

                var map;
                var myOptions;
                function initialize() {
                    let markers = [];

                    var myLatlng = null;
                    if (lonFAPI != null && latFAPI != null) {
                        console.log("true :")
                        myLatlng = new google.maps.LatLng(latFAPI, lonFAPI);
                        myOptions = {
                            zoom: 15,
                            center: myLatlng,
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                        }
                    } else {
                        console.log("false")
                        myLatlng = new google.maps.LatLng(lati, lang)
                        myOptions = {
                            zoom: 7,
                            center: myLatlng,
                            mapTypeId: google.maps.MapTypeId.ROADMAP
                        }
                    }

                    map = new google.maps.Map(document.getElementById("gmap"), myOptions);
                    // Clear out the old markers.

                    // marker refers to a global variable
                    markers.push(
                        new google.maps.Marker({
                            position: myLatlng,
                            map: map

                        })
                    )
                    // Clear out the old markers.

                    const input = document.getElementById("pac-input");
                    const searchBox = new google.maps.places.SearchBox(input);
                    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

                    map.addListener("bounds_changed", () => {
                        searchBox.setBounds(map.getBounds());

                    });

                    searchBox.addListener("places_changed", () => {
                        const places = searchBox.getPlaces();

                        if (places.length == 0) {
                            return;
                        }

                        // Clear out the old markers.
                        markers.forEach((marker) => {
                            marker.setMap(null);
                        });


                        // For each place, get the icon, name and location.
                        const bounds = new google.maps.LatLngBounds();

                        places.forEach((place) => {

                            document.getElementById('latlbl').innerHTML = place.geometry.location.lat();
                            document.getElementById('lonlbl').innerHTML = place.geometry.location.lng();


                            $('#<%=lblLatitude.ClientID %>').val(place.geometry.location.lat());
                $('#<%=lblLongiude.ClientID %>').val(place.geometry.location.lng());

                if (!place.geometry || !place.geometry.location) {
                    console.log("Returned place contains no geometry");
                    return;
                }

                const icon = {
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(25, 25),
                };

                // Create a marker for each place.
                markers.push(
                    new google.maps.Marker({
                        map,
                        title: place.name,
                        position: place.geometry.location,
                    })
                );
                if (place.geometry.viewport) {
                    // Only geocodes have viewport.
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });
            map.fitBounds(bounds);
        });



        google.maps.event.addListener(map, "click", function (event) {

            var clickLat = event.latLng.lat();
            var clickLon = event.latLng.lng();

            markers.forEach((marker) => {
                marker.setMap(null);
            });

            // show in input box
            //document.getElementById("lat").value = clickLat.toFixed(5);
            //document.getElementById("lon").value = clickLon.toFixed(5);

            document.getElementById('latlbl').innerHTML = clickLat.toFixed(5);
            document.getElementById('lonlbl').innerHTML = clickLon.toFixed(5);



            $('#<%=lblLatitude.ClientID %>').val(clickLat.toFixed(5));
            $('#<%=lblLongiude.ClientID %>').val(clickLon.toFixed(5));
            markers.push(
                new google.maps.Marker({
                    map,
                    position: new google.maps.LatLng(clickLat, clickLon),
                })
            );

            /* var marker = new google.maps.Marker({
            position: new google.maps.LatLng(clickLat, clickLon),
        map: map
             });*/
        });
                }

                window.onload = function () { initialize() };

            })

    })


    $(".sendComplain").click(function () {
        ComplainDetails = $('#<%= txtComplainDetail.ClientID %>').val()
        if ($('#<%= txtComplainDetail.ClientID %>').val().trim() != '') {

            $('#<%= txtComplainDetail.ClientID %>').css('border', 'none')
        }
        else {
            $('#<%= txtComplainDetail.ClientID %>').css('border', '1px solid red');
            return false;
        }



        if (StreetIdLast == "") {
            StreetIdLast = "-1";
        }
        if (ComplainFailureType == "") {
            ComplainFailureType = "-1";
        }

        $.ajax({
            type: "POST",
            url: APIUrl + "Complaints/AddComplaint",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
            },
            data: JSON.stringify({
                MobileNumber: MobileNoURL,
                RequesterName: requsterName,
                ComplainantName: ComplainantName,
                ComplainType: ComplainantType,
                ComplainTypeName: ComplainantName,
                ComplainFailureType: ComplainFailureType,
                MeterNumber: MeterNumber,
                ComplainEmail: ComplainEmail,
                ComplainPhoneNumber: ComplainPhoneNumber,
                Nationality: Nationality,
                DocumentType: NationalityDoc,
                DocumentNumber: NationalityNum,
                ProvinceId: ProvinceId,
                ProvinceName: ProvinceName,
                AreaId: AreaIdLast,
                AreaName: AreaNameLast,
                NeighborhoodId: NeighborhoodIdLast,
                NeighborhoodName: NeighborhoodNameLast,
                ComplainDescribtion: ComplainDetails,
                StreetId: StreetIdLast,
                StreetName: StreetNameLast,
                Address: AddrssDetails,
                LanguageId: "AR",
                Integrationtype: 1,
                Long: $("#lonlbl").text(),
                Latt: $("#latlbl").text(),

            }),
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                console.log(data);

                var htmlData = "<h3> تم تسجيل شكوى برقم " + data.body.complainRefrenceNumber.split(":")[1] + " سيتم التواصل بالقريب العاجل</h3>";
                $(".err-app").append(htmlData);
                $(".modal-done").modal("show")
                $(".sendComplain").attr("disabled", true)
            },
            error: function (err) {
                console.log(err);
            }
        })
    })


</script>



