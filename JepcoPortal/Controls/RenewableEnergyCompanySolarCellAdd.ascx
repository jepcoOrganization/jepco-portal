<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyCompanySolarCellAdd.ascx.cs" Inherits="Controls_RenewableEnergyCompanySolarCellAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<div class="billlist subscribe_div">

    <div class="step_form">
        <div class="">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">




                    <%--<h5>لديك عدد ٣ عدادات في القطاع السكني <a href="javascript:void">اضافة/ تعديل رقم عداد</a></h5>--%>


                    <div class="row">
                        <div class="col-md-9 col-sm-9">
                            <h3><strong>اضافة خلايا شمسية جديدة
                            </strong></h3>


                        </div>
                        <div class="col-md-3 pull-right text-right"><a href="javascript:void(0)">عدد الخلايا الشمسية الكلي</a></div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>اسم الشركة المصنعة</label>
                                <asp:HiddenField ID="hdnCompanyId" runat="server" />
                                <asp:HiddenField ID="hdnemailId" runat="server" />

                                <asp:TextBox ID="txtCompanyName" runat="server" PlaceHolder="اختر اسم الشركة"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>رقم الموديل </label>
                                <asp:TextBox ID="txtModelNo" runat="server" PlaceHolder="ادخل رقم الموديل"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>قدرة الخلايا</label>

                                <asp:TextBox ID="txtDevicePower" runat="server" PlaceHolder="ادخل قدرة الجهاز"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label><span>*</span>بلد المنشأ </label>
                                <asp:TextBox ID="txtCountryOrigin" runat="server" PlaceHolder="اختر بلد المنشأ"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <div class="deviceflie">
                                    <div class="Device_description">
                                        <label>ملف وصف الخلايا الشمسية</label>
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
                                        <label>شهادة سلامة الخلايا</label>
                                        <label><span>*</span>بحجم اقصى ١ ميجابايت</label>
                                    </div>
                                    <div class="file-upload">
                                        <label for="fileuploadfield_2" class="file-upload__label fieldlabels">
                                            تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                        </label>
                                        <input id="fileuploadfield_2" name="fileuploadfield_2" type="file" class="file-upload__input" />
                                         <span class="file-select">No file selected</span>
                                        <br />
                                        <span id="file_error2" style="color: red"></span>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <button class="btn action-button" type="button" id="btbvalid" onclick="SendClick();">اضافة الخلايا</button>
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
                    <asp:Literal runat="server" ID="lblInquiryTitle" Text="اضافة جهاز بنجاح"></asp:Literal></h4>
            </div>
            <div class="modal-body">

                <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                    <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                    <p>
                        <asp:Literal runat="server" ID="lblInquiryMessage" Text="تم اضافة خلية شمسية جديدة بنجاح. يمكنكم مشاهدة كافة الخلايا الشمسية المسجلة من خلال قائمة الخلايا الشمسية">                             
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
    function SendClick() {

        var ValCompanyName = false;
        var ValModelNo = false;
        var ValDevicePower = false;
        var ValCountryOrigin = false;
        var FileUpload1 = false;
        var FileUpload2 = false;


        if ($('#<%= txtCompanyName.ClientID %>').val().trim() != '') {
            $('#<%= txtCompanyName.ClientID %>').css('border', 'none');
            ValCompanyName = true;
        }
        else {

            $('#<%= txtCompanyName.ClientID %>').css('border', '1px solid red');
        }

        //----------------------------------------------- 
        if ($('#<%= txtModelNo.ClientID %>').val().trim() != '') {
            $('#<%= txtModelNo.ClientID %>').css('border', 'none');
            ValModelNo = true;
        }
        else {

            $('#<%= txtModelNo.ClientID %>').css('border', '1px solid red');
        }

        //---------------------------------------------------
        if ($('#<%= txtDevicePower.ClientID %>').val().trim() != '') {
            $('#<%= txtDevicePower.ClientID %>').css('border', 'none');
            ValDevicePower = true;
        }
        else {

            $('#<%= txtDevicePower.ClientID %>').css('border', '1px solid red');
        }
        //-------------------------------------------------
        if ($('#<%= txtCountryOrigin.ClientID %>').val().trim() != '') {
            $('#<%= txtCountryOrigin.ClientID %>').css('border', 'none');
            ValCountryOrigin = true;
        }
        else {

            $('#<%= txtCountryOrigin.ClientID %>').css('border', '1px solid red');
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


        //------------------------------------------------------------------
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

                var abcd2 = $('#fileuploadfield_2')[0].files[0].name;
                $('#fileuploadfield_2').next().html(abcd2);
            }
        }
        //------------------------------------------------------


        if (ValCompanyName == true &&
            ValModelNo == true &&
            ValDevicePower == true &&
            ValCountryOrigin == true &&
            FileUpload1 == true &&
           FileUpload2 == true

        ) {
            $("[id*=<%=btnSubmit.ClientID %>]").click();
        }



    }

    function ClearClick() {

        $('#<%= txtCompanyName.ClientID %>').val("");
        $('#<%= txtModelNo.ClientID %>').val("");
        $('#<%= txtDevicePower.ClientID %>').val("");
        $('#<%= txtCountryOrigin.ClientID %>').val("");
        $("#fileuploadfield_1").val('');
        $('#fileuploadfield_1').next().html("");


    }
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

    .deviceflie {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .Device_description,
    .file-upload {
        display: inline-block;
        vertical-align: middle;
    }
        /*.upload {
    width: 250px;
    background:#007fc3;
    position:relative;
    z-index:1;
}
.upload input{
    opacity:0;
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
}*/
        .Device_description small {
            display: table;
            color: #007fc3;
        }




    /*----------------------------*/

    .step_form label.file-upload__label {
        padding: 8px 15px;
        color: #fff;
        background: #007fc3;
        width: 200px;
        display: flex;
        align-items: center;
        justify-content: space-between;
    }

    .fieldlabels {
        color: #848484;
        text-align: right;
        display: inline-block;
        width: 100%;
        font-size: 18px;
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

    /*----------------------------*/
</style>


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

            var fileInput2 = document.getElementById('fileuploadfield_2');
            var filePath2 = fileInput2.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath2)) {
                $("#file_error2").html("Invalid file type");
                fileInput2.value = '';
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
