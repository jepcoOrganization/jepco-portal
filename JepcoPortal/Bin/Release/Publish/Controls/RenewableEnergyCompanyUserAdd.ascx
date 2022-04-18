<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyCompanyUserAdd.ascx.cs" Inherits="Controls_RenewableEnergyCompanyUserAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="billlist subscribe_div">
    <div class="step_form">
        <div class="">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="row">
                        <div class="col-md-9 col-sm-9">
                            <h3><strong>اضافة مفوض جديد
                            </strong></h3>


                        </div>
                        <div class="col-md-3 pull-right text-right"><a href="javascript:void(0)">عدد المفوضين</a></div>
                    </div>




                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-sm-3">
                            <div class="form-group">
                                <label><span>*</span>الاسم الأول</label>
                                <asp:HiddenField ID="hdnCompanyId" runat="server" />
                                <asp:TextBox ID="txtFirstNAme" runat="server" PlaceHolder="الاسم الأول"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-3">
                            <div class="form-group">
                                <label><span>*</span>اسم الأب</label>
                                <asp:TextBox ID="txtFatherNAme" runat="server" PlaceHolder="اسم الأب"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-3">
                            <div class="form-group">
                                <label><span>*</span>اسم الجد</label>

                                <asp:TextBox ID="txtGFatherNAme" runat="server" PlaceHolder="اسم الجد"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-3">
                            <div class="form-group">
                                <label><span>*</span>اسم العائلة</label>
                                <asp:TextBox ID="txtFamilyNAme" runat="server" PlaceHolder="اسم العائلة"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>نوع الوثيقة</label>

                                <asp:TextBox ID="txtDocumentType" runat="server" PlaceHolder="اختر نوع الوثيقة"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>رقم الوثيقة </label>
                                <asp:TextBox ID="txtDocumentNo" runat="server" PlaceHolder="ادخل رقم الوثيقة"></asp:TextBox>
                            </div>
                        </div>
                    </div>




                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>رقم الموبايل</label>

                                <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="ادخل رقم الموبايل"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>البريد الالكتروني </label>
                                <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="ادخل البريد الالكتروني"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                    <div class="row">

                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label>تاريخ بداية التفويض<span style="color: red">*</span></label>
                                <input id="txtStartDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label>تاريخ نهاية التفويض<span style="color: red">*</span></label>
                                <input id="txtEndDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                            </div>
                        </div>

                    </div>







                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <div class="deviceflie">
                                    <div class="Device_description">
                                        <label>صورة عن الوثيقة</label>
                                        <label><span>*</span>بحجم اقصى ١ ميجابايت</label>
                                    </div>
                                    <div class="file-upload">


                                        <label for="fileuploadfield_1" class="file-upload__label fieldlabels">
                                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                        </label>
                                         <input id="fileuploadfield_1" name="fileuploadfield_1" type="file" class="file-upload__input" />

                                        <span class="file-select">No file selected</span>
                                        <br />
                                        <span id="file_error1" style="color: red"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <div class="deviceflie">
                                    <div class="Device_description">

                                        <label>صورة شخصية للمفوض</label>
                                        <label><span>*</span>بحجم اقصى ١ ميجابايت</label>
                                    </div>
                                    <div class="file-upload">
                                         <label for="fileuploadfield_2" class="file-upload__label fieldlabels">
                                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                        </label>
                                     
                                         <input id="fileuploadfield_2" name="fileuploadfield_1" type="file" class="file-upload__input" />
                                          <span class="file-select">No file selected</span>
                                        <br />
                                        <span id="file_error2" style="color: red"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <button class="btn action-button" type="button" id="btbvalid" onclick="SendClick();">اضافة مفوض</button>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" type="button" Style="display: none;" runat="server" Text="Button" />
                    <button class="btn action-button-clear" type="button" id="btbvalidclear" onclick="ClearClick();">مسح الحقول</button>
                </div>

            </div>
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
                    <asp:Literal runat="server" ID="lblInquiryTitle" Text="اضافة مفوض بنجاح"></asp:Literal></h4>
            </div>
            <div class="modal-body">

                <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                    <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                    <p>
                        <asp:Literal runat="server" ID="lblInquiryMessage" Text="تم اضافة المفوض بنجاح. يمكنكم مشاهدة كافة المفوضين الخاصين بالشركة لديكم من قائمة المفوضين.">                             
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

<script type="text/javascript">
    $(document).ready(function () {
        jQuery(".Dateeee").datepicker();

    });
</script>

<script type="text/javascript">
    function SendClick() {


        var ValFirstNAme = false;
        var ValFatherNAme = false;
        var ValGFatherNAme = false;
        var ValFamilyNAme = false;
        var ValDocumentType = false;
        var ValDocumentNo = false;
        var ValMobileNo = false;
        var ValEmail = false;
        var ValStartDate = false;
        var ValEndDate = false;
        var FileUpload1 = false;
        var FileUpload2 = false;


        if ($('#<%= txtFirstNAme.ClientID %>').val().trim() != '') {
            $('#<%= txtFirstNAme.ClientID %>').css('border', 'none');
            ValFirstNAme = true;
        }
        else {

            $('#<%= txtFirstNAme.ClientID %>').css('border', '1px solid red');
        }


        if ($('#<%= txtFatherNAme.ClientID %>').val().trim() != '') {
            $('#<%= txtFatherNAme.ClientID %>').css('border', 'none');
            ValFatherNAme = true;
        }
        else {

            $('#<%= txtFatherNAme.ClientID %>').css('border', '1px solid red');
        }


        if ($('#<%= txtGFatherNAme.ClientID %>').val().trim() != '') {
            $('#<%= txtGFatherNAme.ClientID %>').css('border', 'none');
            ValGFatherNAme = true;
        }
        else {

            $('#<%= txtGFatherNAme.ClientID %>').css('border', '1px solid red');
        }

        if ($('#<%= txtFamilyNAme.ClientID %>').val().trim() != '') {
            $('#<%= txtFamilyNAme.ClientID %>').css('border', 'none');
            ValFamilyNAme = true;
        }
        else {

            $('#<%= txtFamilyNAme.ClientID %>').css('border', '1px solid red');
        }





        if ($('#<%= txtDocumentType.ClientID %>').val().trim() != '') {
            $('#<%= txtDocumentType.ClientID %>').css('border', 'none');
            ValDocumentType = true;
        }
        else {

            $('#<%= txtDocumentType.ClientID %>').css('border', '1px solid red');
        }

        if ($('#<%= txtDocumentNo.ClientID %>').val().trim() != '') {
            $('#<%= txtDocumentNo.ClientID %>').css('border', 'none');
            ValDocumentNo = true;
        }
        else {

            $('#<%= txtDocumentNo.ClientID %>').css('border', '1px solid red');
        }


        if ($('#<%= txtMobileNo.ClientID %>').val().trim() != '') {
            $('#<%= txtMobileNo.ClientID %>').css('border', 'none');
            ValMobileNo = true;
        }
        else {

            $('#<%= txtMobileNo.ClientID %>').css('border', '1px solid red');
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




        //----------------------------------------------- 

        if ($('#<%= txtStartDate.ClientID %>').val().trim() != '') {

            if ($('#<%= txtStartDate.ClientID %>').val().trim() != "") {

                var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                if (!regex.test($('#<%= txtStartDate.ClientID %>').val())) {
                    $('#<%= txtStartDate.ClientID %>').css('border', '1px solid red');

                } else {
                    $('#<%= txtStartDate.ClientID %>').css('border', 'none');
                    ValStartDate = true;
                }
            }
            else {
                $('#<%= txtStartDate.ClientID %>').css('border', '1px solid red');
            }
        }
        else {
            $('#<%= txtStartDate.ClientID %>').css('border', '1px solid red');
        }



        if ($('#<%= txtEndDate.ClientID %>').val().trim() != '') {

            if ($('#<%= txtEndDate.ClientID %>').val().trim() != "") {

                var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                if (!regex.test($('#<%= txtEndDate.ClientID %>').val())) {
                    $('#<%= txtEndDate.ClientID %>').css('border', '1px solid red');

                } else {
                    $('#<%= txtEndDate.ClientID %>').css('border', 'none');
                    ValEndDate = true;
                }
            }
            else {
                $('#<%= txtEndDate.ClientID %>').css('border', '1px solid red');
            }
        }
        else {
            $('#<%= txtEndDate.ClientID %>').css('border', '1px solid red');
        }





        //------------------------------------------------------------------
        var inp1 = document.getElementById('fileuploadfield_1');
        if (inp1.files.length === 0) {
            debugger;
            $("#file_error1").html("Please Select File");
            inp1.focus();
            FileUpload1 = false;

        }
        else {
            debugger;
            $("#file_error1").html("");
            var file_size1 = $('#fileuploadfield_1')[0].files[0].size;
            if (file_size1 > 2000001) {
                $("#file_error1").html("File size is greater than 1 Megabyte");

                $('#fileuploadfield_1').next().html("");

            }
            else {
                debugger;
                FileUpload1 = true;

                var abcd = $('#fileuploadfield_1')[0].files[0].name;
                $('#fileuploadfield_1').next().html(abcd);
            }
        }
        //------------------------------------------------------

        var inp2 = document.getElementById('fileuploadfield_2');
        if (inp2.files.length === 0) {
            debugger;
            $("#file_error2").html("Please Select File");
            inp2.focus();
            FileUpload2 = false;
        }
        else {
            debugger;
            $("#file_error2").html("");
            var file_size2 = $('#fileuploadfield_2')[0].files[0].size;
            if (file_size2 > 2000001) {
                $("#file_error2").html("File size is greater than 1 Megabyte");
                $('#fileuploadfield_2').next().html("");
            }
            else {
                debugger;
                FileUpload2 = true;
                var abcd = $('#fileuploadfield_2')[0].files[0].name;
                $('#fileuploadfield_2').next().html(abcd);
            }
        }


        if (
            ValFirstNAme == true &&
            ValFatherNAme == true &&
            ValGFatherNAme == true &&
            ValFamilyNAme == true &&
            ValDocumentType == true &&
            ValDocumentNo == true &&
            ValMobileNo == true &&
            ValEmail == true &&
            ValStartDate == true &&
            ValEndDate == true &&
            FileUpload1 == true &&
            FileUpload2 == true) {

            $("[id*=<%=btnSubmit.ClientID %>]").click();
        }



    }

    function ClearClick() {

      <%--  $('#<%= txtCompanyName.ClientID %>').val("");
        $('#<%= txtModelNo.ClientID %>').val("");
        $('#<%= txtDevicePower.ClientID %>').val("");
        $('#<%= txtCountryOrigin.ClientID %>').val("");--%>
        $("#fileuploadfield_1").val('');
        $('#fileuploadfield_1').next().html("");


    }
</script>


<script type="text/javascript">
    $("document").ready(function () {



        $('#fileuploadfield_1').change(function (e) {
            //$in = $(this);
            //var abcd = $in[0].files[0].name;
            //$in.next().html(abcd);
            debugger;

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
            //$in = $(this);
            //var abcd = $in[0].files[0].name;
            //$in.next().html(abcd);
            debugger;

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


    });



</script>

<style>
    .action-button {
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
        /* margin-right: 45px; */
    }

    .action-button-clear {
        width: 100px;
        background: #616161;
        font-weight: bold;
        color: white;
        border: 0 none;
        border-radius: 0px;
        cursor: pointer;
        padding: 10px 5px;
        margin: 10px 5px 10px 0px;
        float: right;
        min-height: 60px;
    }


    span.file-select {
        color: white;
    }


    /*.deviceflie {
        display: flex;
        justify-content: space-between;
        align-items: center;
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

    .Device_description small {
        display: table;
        color: #007fc3;
    }*/

     /*.step_form label.file-upload__label {
        padding: 8px 15px;
        color: #fff;
        background: #007fc3;
        width: 200px;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }*/

    /*.deviceflie {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

     input[type="file"] {
        display: none;
    }*/


     .step_form label.file-upload__label {
        padding: 8px 15px;
        color: #fff;
        background: #007fc3;
        width: 200px;
        display: flex;
        align-items: center;
        justify-content: space-between;
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
        display: table;
        color: #007fc3;
    }
</style>


