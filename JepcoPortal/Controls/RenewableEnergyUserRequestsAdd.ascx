<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyUserRequestsAdd.ascx.cs" Inherits="Controls_RenewableEnergyUserRequestsAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="Energy_Request">
    <h2>طلب ابداء رغبة ربط نظام طاقة</h2>

    <div class="row custom_radio">
        <div class="col-lg-3 col-md-3 col-sm-12">
            <label>نوع الطلب</label>
        </div>
        <div class="col-lg-9 col-md-9 col-sm-12">
            <div class="radio">
                <asp:RadioButtonList runat="server" ID="rblRenwableEnergyType" RepeatDirection="Horizontal">
                    <asp:ListItem Text="صغير صافي قياس" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="كبير صافي قياس" Value="2"></asp:ListItem>
                    <asp:ListItem Text="تصريح عبور اولي" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
    </div>


    <div class="row custom_radio" id="divMeterStatu">
        <div class="col-lg-3 col-md-3 col-sm-12">
            <label>حالة العداد</label>
        </div>

        <div class="col-lg-9 col-md-9 col-sm-12">
            <div class="radio">
                <asp:RadioButtonList runat="server" ID="rblMeterStatus" RepeatDirection="Horizontal">
                    <asp:ListItem Text="عداد عامل" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="عداد جديد" Value="2"></asp:ListItem>
                    <asp:ListItem Text="مبنى قيد الانشاء" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
    </div>

    <div class="row custom_radio" id="referncediv">
        <div class="col-lg-3 col-md-3 col-sm-12">
            <label class="referncNolblClass">الرقم المرجعي</label>
        </div>

        <div class="col-lg-6 col-md-6 col-sm-12">
            <div class="radio">
                <asp:RadioButtonList runat="server" ID="rbdRefeenceType" RepeatDirection="Horizontal" Style="display: none">
                    <asp:ListItem Text="رقم العداد" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="رقم الطلب" Value="2"></asp:ListItem>

                </asp:RadioButtonList>
                <asp:TextBox ID="txtRefernceNumber" runat="server" PlaceHolder="رقم العداد" class="enter_number"></asp:TextBox>
                <%-- <asp:TextBox ID="txtRefernceNumber" runat="server" PlaceHolder="رقم الملف" class="enter_number"></asp:TextBox>--%>
            </div>
        </div>

        <div class="col-lg-3 col-md-3 col-sm-4">

            <%--<input type="text" placeholder="ادخل رقم العداد" class="enter_number">--%>
        </div>
    </div>

    <br />

    <div class="row" style="display: none">
        <div class="col-lg-12">
            <button class="FetchingdataBTN">جلب البيانات</button>
        </div>
    </div>
    <div class="clearfix"></div>

    <div class="energyrequest">
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>الاسم الاول</label>
                    <%-- <input type="text" placeholder="عبد الكريم">--%>
                    <asp:TextBox ID="txtFirstNAme" runat="server" PlaceHolder="عبد الكريم" disabled="disabled"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>اسم الأب</label>
                    <asp:TextBox ID="txtsecondNAme" runat="server" PlaceHolder="اس8889 الاب" disabled="disabled"></asp:TextBox>
                    <%--<input type="text" placeholder="مصطفى">--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>اسم الجد</label>
                    <asp:TextBox ID="txtThirdName" runat="server" PlaceHolder="اسم الجد" disabled="disabled"></asp:TextBox>
                    <%--<input type="text" placeholder="عبد الكريم">--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>اسم العائلة</label>
                    <asp:TextBox ID="txtLastName" runat="server" PlaceHolder="اسم العائلة" disabled="disabled"></asp:TextBox>
                    <%--<input type="text" placeholder="الجغبير">--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>المحافظة</label>
                    <asp:TextBox ID="txtGovernal" runat="server" PlaceHolder="المحافظة" disabled="disabled"></asp:TextBox>
                    <%--<input type="text" placeholder="العاصمة عمان">--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>المنطقة ١</label>
                    <asp:TextBox ID="txtArea1" runat="server" PlaceHolder="المنطقة ١" disabled="disabled"></asp:TextBox>
                    <%--<input type="text" placeholder="الجبيهة">--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>المنطقة ٢</label>
                    <asp:TextBox ID="txtArea2" runat="server" PlaceHolder="المنطقة ٢" disabled="disabled"></asp:TextBox>
                    <%-- <input type="text" placeholder="شفابدران">--%>
                </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                    <label>اسم الشارع</label>
                    <asp:TextBox ID="txtStret" runat="server" PlaceHolder="اسم الشارع" disabled="disabled"></asp:TextBox>
                    <%--<input type="text" placeholder="شفابدران">--%>
                </div>
            </div>
        </div>
        <p></p>
        <p style="display: none">هل ترغب بتحديث البايانات الموجودة اعلاه؟ <a href="javascript:void">اضغط هنا</a></p>
    </div>

    <div class="clearfix"></div>

    <div class="row">
        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="form-group">
                <div class="deviceflie">
                    <div class="Device_description">
                        <label>
                            ارفاق هوية
						</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                    </div>
                    <div class="file-upload">
                        <label for="fileuploadfield_1" class="file-upload__label fieldlabels">
                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                        </label>
                        <input id="fileuploadfield_1" name="fileuploadfield_1" type="file" class="file-upload__input" />
                        <span class="file-select"></span>
                        <br />
                        <span id="file_error1" style="color: red"></span>

                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="form-group">
                <div class="deviceflie">
                    <div class="Device_description" style="padding-bottom: 22px;">
                        <label>
                            تفويض الشركة
					   </br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                    </div>
                    <div class="file-upload">
                        <label for="fileuploadfield_2" class="file-upload__label fieldlabels">
                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                        </label>
                        <input id="fileuploadfield_2" name="fileuploadfield_2" type="file" class="file-upload__input" />
                        <span class="file-select"></span>
                        <br />
                        <span id="file_error2" style="color: red"></span>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="form-group">

                <div class="deviceflie" id="fiUploadDiv3">
                    <div class="Device_description">
                        <label>
                            مخطط أراضي
						  </br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                    </div>
                    <div class="file-upload">
                        <label for="fileuploadfield_3" class="file-upload__label fieldlabels">
                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                        </label>
                        <input id="fileuploadfield_3" name="fileuploadfield_3" type="file" class="file-upload__input" />
                        <span class="file-select"></span>
                        <br />
                        <span id="file_error3" style="color: red"></span>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="form-group">

                <div class="deviceflie" id="fiUploadDiv4">
                    <div class="Device_description">
                        <label>
                            <label id="blboffile4">وصل رسوم تركيب عداد جديد</label>

                            </br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                    </div>
                    <div class="file-upload">
                        <label for="fileuploadfield_4" class="file-upload__label fieldlabels">
                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                        </label>
                        <input id="fileuploadfield_4" name="fileuploadfield_4" type="file" class="file-upload__input" />
                        <span class="file-select"></span>
                        <br />
                        <span id="file_error4" style="color: red"></span>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="form-group">

                <div class="deviceflie" id="fiUploadDiv5">
                    <div class="Device_description">
                        <label>
                            صورة العداد
						  </br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                    </div>
                    <div class="file-upload">
                        <label for="fileuploadfield_5" class="file-upload__label fieldlabels">
                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                        </label>
                        <input id="fileuploadfield_5" name="fileuploadfield_5" type="file" class="file-upload__input" />
                        <span class="file-select"></span>
                        <br />
                        <span id="file_error5" style="color: red"></span>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="information_delegated">
        <h3>معلومات الشركة المراد تفويضها</h3>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" class="">

            <ContentTemplate>

                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label>اختر اسم الشركة التي ترغب بتفويضها لتركيب النظام</label>

                            <asp:DropDownList ID="ddlCompnay" runat="server" class="form-control" TabIndex="2" OnSelectedIndexChanged="ddlCompnay_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>

                            <%--<select>
                        <option>اختر اسم الشركة</option>
                        <option>company 1</option>
                        <option>company 2</option>
                    </select>--%>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label>رقم هاتف الشركة </label>
                            <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="رقم هاتف الشركة " disabled="disabled"></asp:TextBox>
                            <%--<input type="text" placeholder="079 9823 095" class="number">--%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label>الرقم الوطني للمنشأة </label>
                            <asp:TextBox ID="txtNationalNo" runat="server" PlaceHolder="الرقم الوطني للمنشأة " disabled="disabled"></asp:TextBox>
                            <%-- <input type="text" placeholder="3456799823095" class="number">--%>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label>البريد الالكتروني </label>
                            <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="البريد الالكتروني " disabled="disabled"></asp:TextBox>
                            <%-- <input type="text" placeholder="lkgsd@hotmail.com">--%>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col-lg-12">
                <div class="checkbox">
                    <label>
                        <span class="detcheckbox">
                            <input type="checkbox" id="two">
                            <label for="two"></label>
                        </span>


                        أقر بأن المعلومات الواردة في هذا الطلب صحيحة وأوافق على الالتزام ببنود وشروط اتفاقية ربط نظم مصادر الطاقة المتجددة  المدرجة في الطلب بواسطة شركة (<label id="lblddlvalurmsg"></label>) المفوضة.
                    </label>
                </div>
            </div>
        </div>



        <div class="row">
            <div class="col-lg-12">

                <button class="submitbtn" type="button" id="btbvalid" onclick="SendClick();">ارسال الطلب</button>
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" type="button" Style="display: none;" runat="server" Text="Button" />
                <%-- <button class="submitbtn">تقديم الطلب</button>--%>
                <button class="cancelbtn" onclick="SendCancle()">الغاء</button>
                <asp:Button ID="btncancle" OnClick="btncancle_Click" type="button" Style="display: none;" runat="server" Text="Button" />
            </div>
        </div>
    </div>

</div>

<br>
<br>




<asp:LinkButton ID="lnkSubscribe" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender runat="server" ID="mpeInquiry"
    TargetControlID="lnkSubscribe" BehaviorID="mpeInquiry"
    BackgroundCssClass="modalBackground" PopupControlID="panelInquiry"
    CancelControlID="btnClose">
</cc1:ModalPopupExtender>
<asp:Panel ID="panelInquiry" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome in" Style="display: none; position: fixed; top: 0px; right: 0px; bottom: 0px; left: 0.5px; z-index: 1000001; overflow: hidden; outline: 0px; background: rgb(194 194 194 / 72%);">
    <div class="modal-dialog modal-md">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnClose"><span class="fa fa-close"></span></asp:LinkButton>
                <h4 class="modal-title" id="myModalLabel">
                    <asp:Literal runat="server" ID="lblInquiryTitle" Text="تقديم طلب طاقة متجددة"></asp:Literal></h4>
            </div>
            <div class="modal-body">
                <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                    <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/check.png" />
                    <strong>تم ارسال الطلب بنجاح</strong>
                    <p>
                        <asp:Literal runat="server" ID="lblInquiryMessage" Text="لقد تم ارسال طلبكم الى">                             
                        </asp:Literal>

                        <asp:Literal runat="server" ID="lvlCompanyNAme" Text="">                             
                        </asp:Literal>

                        <asp:Literal runat="server" ID="Literal2" Text="لغايات استكمال الطلب الخاص بكم.">                             
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


<%--<div class="popup_modal">
    <button data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Open modal</button>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span class="fa fa-close"></span></button>
                    <h4 class="modal-title" id="exampleModalLabel">طلب طاقة متجددة</h4>
                </div>
                <div class="modal-body">
                    <img src="images/check.png" alt="">
                    <strong>تم ارسال الطلب بنجاح</strong>
                    <p>لقد تم ارسال طلبكم الى شركة النظم الحديثة للطاقة المتجددة لغايات استكمال تقديم الطلب الخاص بكم</p>
                </div>
                <div class="modal-footer">
                    <button>متابعة الى الموقع</button>
                </div>
            </div>
        </div>
    </div>
</div>--%>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<script type="text/javascript">
    $("document").ready(function () {


        //===================== Radio 1 ==========================
        $('#<%=rblRenwableEnergyType.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblRenwableEnergyType.ClientID  %>_1').addClass("toggle toggle-right");
        $('#<%=rblRenwableEnergyType.ClientID  %>_2').addClass("toggle toggle-right");


        $('#<%=rblRenwableEnergyType.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rblRenwableEnergyType.ClientID  %>_1').next('label').addClass("radio-label");
        $('#<%=rblRenwableEnergyType.ClientID  %>_2').next('label').addClass("radio-label");

        //===================== Radio 2 ==========================
        $('#<%=rblMeterStatus.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblMeterStatus.ClientID  %>_1').addClass("toggle toggle-right");
        $('#<%=rblMeterStatus.ClientID  %>_2').addClass("toggle toggle-right");



        $('#<%=rblMeterStatus.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rblMeterStatus.ClientID  %>_1').next('label').addClass("radio-label");
        $('#<%=rblMeterStatus.ClientID  %>_2').next('label').addClass("radio-label");



        //===================== Radio 3 ==========================
        $('#<%=rbdRefeenceType.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rbdRefeenceType.ClientID  %>_1').addClass("toggle toggle-right");



        $('#<%=rbdRefeenceType.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rbdRefeenceType.ClientID  %>_1').next('label').addClass("radio-label");


        $('#fiUploadDiv4').hide();
        $('#fiUploadDiv5').hide();

        $("[id*=<%=rblMeterStatus.ClientID %>]").change(function () {

            if ($(this).val() == '1') {
                $('#<%= txtRefernceNumber.ClientID %>').attr("placeholder", " رقم العداد");
                $('#fiUploadDiv4').hide();
                $('#fiUploadDiv5').hide();
            }
            if ($(this).val() == '2') {
                $('#<%= txtRefernceNumber.ClientID %>').attr("placeholder", " رقم طلب اشتراك جديد");
                $('#fiUploadDiv4').show();
                $('#fiUploadDiv5').hide();
                $("#blboffile4").text("صورة سند قبض رسوم عداد جديد");
            }
            if ($(this).val() == '3') {
                $('#referncediv').hide();
                $('#fiUploadDiv4').show();

                $('#fiUploadDiv5').hide();
                $("#blboffile4").text("صورة عن دراسة ايصال تيار");



            }
            else {
                $('#referncediv').show();
            }
            return false;
        });




    });

    $("[id*=<%=rblRenwableEnergyType.ClientID %>]").change(function () {

        debugger;

        var asdasd = $('#<%=rblRenwableEnergyType.ClientID %> input:checked').val();


        if (asdasd == '3') {

            $('#divMeterStatu').hide();
            $('#referncediv').hide();

            $('#fiUploadDiv3').hide();
            $('#fiUploadDiv4').hide();
            $('#fiUploadDiv5').hide();

        }
        else {

            $('#divMeterStatu').show();
            $('#referncediv').show();
            $('#fiUploadDiv3').show();
            GetOthers();
        }

    });


    function GetOthers() {
        debugger;
        var asdasd = $('#<%=rblMeterStatus.ClientID %> input:checked').val();
        if (asdasd == '1') {
            $('#<%= txtRefernceNumber.ClientID %>').attr("placeholder", " رقم العداد");
            $('#fiUploadDiv4').hide();
            $('#fiUploadDiv5').hide();
        }
        else if (asdasd == '2') {
            $('#<%= txtRefernceNumber.ClientID %>').attr("placeholder", " رقم طلب اشتراك جديد");
            $('#fiUploadDiv4').show();
            $('#fiUploadDiv5').hide();
            $("#blboffile4").text("صورة سند قبض رسوم عداد جديد");
        }
        else if (asdasd == '3') {
            $('#referncediv').hide();
            $('#fiUploadDiv4').show();

            $('#fiUploadDiv5').hide();
            $("#blboffile4").text("صورة عن دراسة ايصال تيار");
        }
        else {
            $('#referncediv').show();
        }
        return false;
    }

</script>
<script>
    $("document").ready(function () {
        debugger;
        //ContentPlaceHolder1_ctl00_txtRefernceNumber

        var MeterStatusChecked = $("[id*=rblMeterStatus] input:checked");
        var MeterStatusValue = MeterStatusChecked.val();

        if (MeterStatusValue == "1") {
            $("#<%=txtRefernceNumber.ClientID%>").attr("placeholder", "رقم الملف");
        } else {
            $("#<%=txtRefernceNumber.ClientID%>").attr("placeholder", "رقم العداد");
        }

    });

</script>
<script type="text/javascript">
    $("document").ready(function () {



        $('#fileuploadfield_1').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadfield_1');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_error1").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfield_1').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfield_1')[0].files[0].name;
                $('#fileuploadfield_1').next().html(abcd);
                $("#file_error1").html("");
            }

        });


        $('#fileuploadfield_2').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadfield_2');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_error2").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfield_2').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfield_2')[0].files[0].name;
                $('#fileuploadfield_2').next().html(abcd);
                $("#file_error2").html("");
            }

        });

        $('#fileuploadfield_3').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadfield_3');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_error3").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfield_3').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfield_3')[0].files[0].name;
                $('#fileuploadfield_3').next().html(abcd);
                $("#file_error3").html("");
            }

        });

        $('#fileuploadfield_4').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadfield_4');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_error4").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfield_4').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfield_4')[0].files[0].name;
                $('#fileuploadfield_4').next().html(abcd);
                $("#file_error4").html("");
            }

        });

        $('#fileuploadfield_5').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadfield_5');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_error5").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfield_5').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfield_5')[0].files[0].name;
                $('#fileuploadfield_5').next().html(abcd);
                $("#file_error5").html("");
            }

        });

    });


    jQuery('#ContentPlaceHolder1_ctl00_txtRefernceNumber').on('input', function () {
        // do your stuff
        var abcd = $("#ContentPlaceHolder1_ctl00_txtRefernceNumber").val();

        $("#lbltextvalurmsg").text(abcd);

    });





</script>

<script>
    $("#ContentPlaceHolder1_ctl00_ddlCompnay").change(function () {
        var abcd2 = $("#ContentPlaceHolder1_ctl00_ddlCompnay option:selected").text();
        $("#lblddlvalurmsg").text(abcd2);
    });



</script>


<script type="text/javascript">
    function SendClick() {

        var CompanyVal = false;
        var RefernceNumberVal = false;
        var FileUpload1 = false;
        var FileUpload1 = false;
        var FileUpload3 = false;
        var FileUpload4 = false;
        var FileUpload5 = false;




        if ($('#<%= ddlCompnay.ClientID %> option:selected').val() == "0") {
            $('#<%= ddlCompnay.ClientID %>').css('border', '1px solid red');
        }
        else {
            $('#<%= ddlCompnay.ClientID %>').css('border', 'none');
            CompanyVal = true;
        }

        //------------------------------------------------------------------
        var inp1 = document.getElementById('fileuploadfield_1');
        if (inp1.files.length === 0) {

            $("#file_error1").html("Please Select File");
            inp1.focus();
            FileUpload1 = false;

        }
        else {

            $("#file_error1").html("");
            var file_size1 = $('#fileuploadfield_1')[0].files[0].size;
            if (file_size1 > 2000001) {
                $("#file_error1").html("File size is greater than 1 Megabyte");

                $('#fileuploadfield_1').next().html("");

            }
            else {

                FileUpload1 = true;

                var abcd = $('#fileuploadfield_1')[0].files[0].name;
                $('#fileuploadfield_1').next().html(abcd);
            }
        }
        //------------------------------------------------------


        //------------------------------------------------------------------
        var inp2 = document.getElementById('fileuploadfield_2');
        if (inp2.files.length === 0) {

            $("#file_error2").html("Please Select File");
            inp2.focus();
            FileUpload2 = false;

        }
        else {

            $("#file_error2").html("");
            var file_size2 = $('#fileuploadfield_2')[0].files[0].size;
            if (file_size2 > 2000001) {
                $("#file_error2").html("File size is greater than 1 Megabyte");
                $('#fileuploadfield_2').next().html("");
            }
            else {

                FileUpload2 = true;
                var abcd = $('#fileuploadfield_2')[0].files[0].name;
                $('#fileuploadfield_2').next().html(abcd);
            }
        }
        //------------------------------------------------------


        //------------------------------------------------------------------
        var inp3 = document.getElementById('fileuploadfield_3');
        if (inp3.files.length === 0) {

            $("#file_error3").html("Please Select File");
            inp3.focus();
            FileUpload3 = false;

        }
        else {

            $("#file_error3").html("");
            var file_size3 = $('#fileuploadfield_3')[0].files[0].size;
            if (file_size3 > 2000001) {
                $("#file_error3").html("File size is greater than 1 Megabyte");
                $('#fileuploadfield_3').next().html("");
            }
            else {

                FileUpload3 = true;
                var abcd = $('#fileuploadfield_3')[0].files[0].name;
                $('#fileuploadfield_3').next().html(abcd);
            }
        }
        //------------------------------------------------------


        //============================

        var checked_radiorblallergies = $("[id*=rblMeterStatus] input:checked");
        var valuerblallergies = checked_radiorblallergies.val();
        if (valuerblallergies == '1' || valuerblallergies == '2') {

            var allergiesDetalis = $('#ContentPlaceHolder1_ctl00_txtRefernceNumber').val().trim();
            if (allergiesDetalis == '' || allergiesDetalis == "") {
                $('#ContentPlaceHolder1_ctl00_txtRefernceNumber').css('border', '1px solid red');

            }
            else {
                $('#ContentPlaceHolder1_ctl00_txtRefernceNumber').css('border', 'none');
                RefernceNumberVal = true;
            }
        }
        else {
            RefernceNumberVal = true;
        }

        //============================ 

        //======================  Validation For rblMeterStatus == 2 then need FileUploaded 4

        if (valuerblallergies == '2' || valuerblallergies == '3') {
            var inp4 = document.getElementById('fileuploadfield_4');
            if (inp4.files.length === 0) {

                //$("#file_error4").html("Please Select File");
                //inp4.focus();
                //FileUpload4 = false;
                FileUpload4 = true;

            }
            else {

                $("#file_error4").html("");
                var file_size4 = $('#fileuploadfield_4')[0].files[0].size;
                if (file_size4 > 2000001) {
                    $("#file_error4").html("File size is greater than 1 Megabyte");
                    $('#fileuploadfield_4').next().html("");
                }
                else {

                    FileUpload4 = true;
                    var abcd = $('#fileuploadfield_4')[0].files[0].name;
                    $('#fileuploadfield_4').next().html(abcd);
                }
            }
        }
        else {
            FileUpload4 = true;
        }

        // =====================

        var asdasd = $('#<%=rblRenwableEnergyType.ClientID %> input:checked').val();

        if (asdasd == "3") {
            FileUpload3 = true;
            FileUpload4 = true;
            RefernceNumberVal = true;
        }


        if (CompanyVal == true &&
            FileUpload1 == true &&
            FileUpload2 == true &&
            FileUpload3 == true &&
            FileUpload4 == true &&
            RefernceNumberVal == true
        ) {
            $("[id*=<%=btnSubmit.ClientID %>]").click();
        }



    }

    function SendCancle() {
        $("[id*=<%=btncancle.ClientID %>]").click();
    }
</script>

<style>
    label.referncNolblClass {
        margin-top: 22px;
    }

    .radio td {
        width: 21%;
    }

    span.file-select {
        color: white;
    }

    .modal-body strong {
        display: block;
        color: #007fc3;
    }

    .Energy_Request label.file-upload__label {
        padding: 8px 15px;
        color: #fff;
        background: #007fc3;
        width: 200px;
        display: flex;
        align-items: center;
        justify-content: space-between;
        cursor: pointer;
    }

    .deviceflie {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    input[type="file"] {
        display: none;
    }

    .Device_description,
    .file-upload {
        display: inline-block;
        vertical-align: middle;
    }

    .upload {
        width: 250px;
        background: #007fc3;
        position: relative;
        z-index: 1;
    }

        .upload input {
            opacity: 0;
        }

        .upload:before {
            content: "\f0ee";
            font-family: fontawesome;
            position: absolute;
            left: 15px;
            top: 7px;
            font-size: 34px;
            color: #fff;
        }

        .upload:after {
            content: "اختر الملف";
            position: absolute;
            top: 20px;
            right: 15px;
            color: #fff;
            font-size: 18px;
            z-index: -1;
        }

    span.file-select {
        font-size: 18px;
        color: #a0a0a0;
        margin-left: 14px;
    }

    .Device_description small {
        color: red;
    }

    .Device_description {
        padding-bottom: 22px;
    }
</style>
