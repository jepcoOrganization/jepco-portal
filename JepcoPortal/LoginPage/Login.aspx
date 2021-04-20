<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginPage_Login" Culture="en-US" UICulture="en-US" Async="true" EnableEventValidation="false" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">--%>


    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>JEPCO-Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

        <div class="forgot_login customClick">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="login_right">
                            <div class="forlogo">
                                <a href="javascript:void">
                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/login-logo.png" alt="">
                                </a>
                            </div>
                            <div class="account_service">
                                <small>خدمة حسابي</small>
                                <aside>اهلا بكم في خدمة حسابي</aside>
                                <p>رغبة من الشركة في زيادة تفاعلها مع مشتركيها وتقديم الخدمات الجديدة لهم مباشرة، فقد أطلقت الشركة خدمة حسابي والتي تتيح للمستفيد الفعلي سواءً كان مالكاً أو مستأجراً من معرفة تفاصيل فواتيرة</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 col-md-12 col-sm-12 col-lg-offset-1">
                        <div class="card">
                            <!--onclick="flip()"-->
                            <div class="front">
                                <h1>تسجيل الدخول</h1>
                                <p>الرجاء ادخال معلومات تسجيل الدخول الخاصة بك</p>



                                <asp:TextBox runat="server" ID="txtEmail" placeholder="البريد الالكتروني" ClientIDMode="Static" CssClass="user" class="customClick" Style="font-family: Montserrat"></asp:TextBox>



                                <asp:TextBox runat="server" ID="txtPassword" placeholder="كلمة المرور" ClientIDMode="Static" CssClass="pass" TextMode="Password" class="customClick" autocomplete="on"></asp:TextBox>


                                <%--  <input type="text" placeholder="اسم المستخدم" class="user">
                                <input type="text" placeholder="كلمة المرور" class="pass">--%>
                                 <a href="javascript:void" class="forpass">نسيت كلمة المرور؟</a> 
                                <%-- <a href="javascript:void" class="chgpass">تغيير كلمة المرور؟</a>--%>
                                <div class="check_box">

                                    <%--<div id="check1">

                                    <label class="container-checkbox" >
                                       بالمتابعة، أنت توافق على<mark> <a target="_blank" href="https://jepco.com.jo/ar/Home/%D8%A7%D9%84%D8%B4%D8%B1%D9%88%D8%B7-%D9%88%D8%A7%D9%84%D8%A3%D8%AD%D9%83%D8%A7%D9%85" >شروط الاستخدام</a> </mark>وإشعار الخصوصية من JEPCO

                                          <input type="checkbox" id="Check1">                                          
                                       <span class="checkmark"></span>                                         
                                    </label>
                                                                     
                                    </div>--%>

                                    <div id="check1">

                                        <label class="container-checkbox" style="padding-right:0">
                                            بالمتابعة، أنت توافق على<mark> <a target="_blank" href="https://jepco.com.jo/ar/Home/%D8%A7%D9%84%D8%B4%D8%B1%D9%88%D8%B7-%D9%88%D8%A7%D9%84%D8%A3%D8%AD%D9%83%D8%A7%D9%85">شروط الاستخدام</a> </mark>وإشعار الخصوصية من JEPCO

                                       <%--   <input type="checkbox" id="Check1">                                          
                                       <span class="checkmark"></span>     --%>
                                        </label>

                                    </div>





                                    <label class="container-checkbox">
                                        احتفظ بمعلومات تسجيل دخولي
                                          <input type="checkbox" id="Check2">
                                        <span class="checkmark"></span>

                                    </label>
                                    <%-- <asp:CheckBox ID="checkmark2" runat="server" class="checkmark"/>--%>
                                </div>
                                <div class="forlogbtndiv">

                                    <button onclick="validForm();" type="button">تسجيل الدخول</button>

                                    <%-- <button onclick="ClearForm();" type="button">ارسال الرسالة</button>--%>

                                    <asp:Button runat="server" ID="lnkSubmitFrm" OnClick="lnkSubmitFrm_Click" Text="تسجيل الدخول" Style="display: none;" disbled="disabled"></asp:Button>
                                    <%-- <asp:Button runat="server" ID="lnkClear" OnClick="lnkClear_Click" Text="مسح الحقول"></asp:Button>--%>
                                </div>

                                <%--<style>
                                    .forlogbtndiv input[type="submit"]:first-child {
                                        background: #f1b707;
                                    }

                                    .forlogbtndiv input[type="submit"] {
                                        border: none;
                                        color: #fff;
                                        background: #cecece;
                                        font-size: 20px;
                                        font-weight: bold;
                                        min-width: 190px;
                                        height: 60px;
                                        line-height: 60px;
                                        margin: 10px 0 10px 10px;
                                    }
                                </style>--%>

                                <hr>
                                <a href="javascript:void" class="new_user">هل انت مستخدم جديد؟</a>
                                <%--<button class="Create_account" onclick="CreateNew();">انشئ حسابك الان</button>--%>
                                <asp:Button ID="btn_ok" runat="server" Text="انشئ حسابك الان" CssClass="Create_account" type="button" OnClick="btn_ok_Click" />


                                <div class="forlogotherlink">

                                    <asp:ListView runat="server" ID="lstFooterNav">
                                        <ItemTemplate>

                                            <asp:HyperLink runat="server" ID="lnkFooterNav" Text='<%# Bind("Title") %>' NavigateUrl='<%# Bind("URL") %>' Target='<%# Bind("Target") %>'>
                                            </asp:HyperLink>


                                        </ItemTemplate>
                                    </asp:ListView>

                                    <%--<a href="javascript:void">خدمة العملاء</a>
                                    <a href="javascript:void">الشكاوي والاقتراحات  </a>
                                    <a href="javascript:void">خريطة الموقع</a>
                                    <a href="javascript:void">اسئلة واجوبة</a>--%>
                                </div>

                            </div>
                            <div class="back">
                                <h1>نسيت كلمة المرور؟</h1>
                                <p>
                                 الرجاء ادخال البريد الالكتروني الخاص بك وسنقوم بارسال تفاصيل الدخول الى البوابة الالكترونية الخاص بكم في حال توفر البيانات.
                                </p>

                                <asp:TextBox runat="server" ID="txtForgetPassEmail" placeholder="ادحل البريد الالكتروني" ClientIDMode="Static" CssClass="user" class="customClick"></asp:TextBox>

<%--                                <input type="text" placeholder="ادحل البريد الالكتروني">--%>
                              <%--  <button class="Send_password" onclick="validForgetPassFormForm();">ارسال كلمة مرور جديدة</button>--%>

                                <asp:LinkButton runat="server" ID="lnkforgetpass" OnClick="btnForgetPass_Click" Text="ارسال كلمة المرور"></asp:LinkButton>

                                <%-- <asp:Button runat="server" ID="btnForgetPass" OnClick="btnForgetPass_Click" Text="تسجيل الدخول" Style="display: none;" disbled="disabled"></asp:Button>--%>
                                <a href="javascript:void" class="arenewuser">هل انت مستخدم جديد؟  
              <mark>قم بالتسجيل الآن            </mark>
                                </a>
                                <div class="forlogotherlink">
                                    <a href="javascript:void">خدمة العملاء</a>
                                    <a href="javascript:void">الشكاوي والاقتراحات  </a>
                                    <a href="javascript:void">خريطة الموقع</a>
                                    <a href="javascript:void">اسئلة واجوبة</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="copyright forlogcopyright">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">

                            <aside>
                                جميع الحقوق الملكية محفوظة <span style="font-family: 'Poppins', sans-serif;">2020</span>.<strong>جيبكو</strong>  ©     
                            </aside>
                            <small>|</small>
                            <aside>
                                <span>تصميم وتطوير بواسطة</span>
                                <a href="javascript:void">Auratechs Solutions&nbsp;</a>
                            </aside>
                        </div>
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
                        <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnClose" Style="display: none;"><span class="fa fa-close"></span></asp:LinkButton>
                        <h4 class="modal-title" id="myModalLabel11">الرقم التعريفي الخاص بكم 
                        </h4>
                    </div>
                    <div class="modal-body">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" Style="padding-top: 20px;" />

                        <div class="step_form">

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <p>
                                            <asp:Literal runat="server" ID="lblOTPString" Text="أهلا وسهلا بكم في البوابة الالكترونية الخاصة بشركة الكهرباء الأردنية. الرجاء ادخال رقم التعريف الخاص بكم والذي تم ارساله الى الرقم "></asp:Literal>

                                            <asp:Label runat="server" ID="lblOTPMobile" class="LTR"></asp:Label>
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

                        <asp:Button ID="Button1" runat="server" Text="موافق" CssClass="d_model_btn" type="button" OnClick="Button1_Click" />
                    </div>


                </div>
            </div>

        </asp:Panel>





          <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
        <cc1:ModalPopupExtender runat="server" ID="ModalPopupExtender1"
            TargetControlID="LinkButton2" BehaviorID="ModalPopupExtender1"
            BackgroundCssClass="modalBackground" PopupControlID="panel1"
            CancelControlID="btnClose">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="panel1" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome in" Style="display: none; position: fixed; top: 0px; right: 0px; bottom: 0px; left: 0.5px; z-index: 1000001; overflow: hidden; outline: 0px;">
            <div class="modal-dialog modal-md">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="LinkButton3"><span class="fa fa-close"></span></asp:LinkButton>
                        <h4 class="modal-title" id="myModalLabel1155">استعادة كلمة المرور
                        </h4>
                    </div>
                    <div class="modal-body">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" Style="padding-top: 20px;" />

                        <div class="step_form">

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <p>
                                            <asp:Literal runat="server" ID="Literal1" Text="في حال وجود بيانات تخص البريد الالكتروني المدخل سنقوم بارسال تفاصيل الدخول الى البوابة اليكم."></asp:Literal>

                                            <asp:Label runat="server" ID="Label1" class="LTR"></asp:Label>
                                        </p>

                                    </div>
                                </div>

                            </div>

                            

                        </div>

                    </div>
                  <%--  <div class="modal-footer">

                        <asp:Button ID="Button2" runat="server" Text="موافق" CssClass="d_model_btn" type="button" OnClick="Button1_Click" />
                    </div>--%>


                </div>
            </div>

        </asp:Panel>






        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script type="text/javascript" src="/Scripts/bootstrap.min.js"></script>

        <script>
            $(".forpass").click(function () {
                $(".card").addClass("flipped");
            });
            $(".arenewuser").click(function () {
                $(".card").removeClass("flipped");
            });



            function validForm() {
                 

                var vEmail = false;



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

                if (vEmail == true) {
                    $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
                }




                // 
                //if ($('#Check1').is(':checked')) {
                //    $("#check1").css('border', 'none');
                //}
                //else {
                //    $("#check1").css('border', '1px solid red');

                //}



            }


            function ClearForm() {
                 
                $("#txtEmail").val('');
                $("#txtPassword").val('');

            }


            function validForgetPassFormForm() {
                var vEmail = false;

                debugger;

                if ($("#txtForgetPassEmail").val() != "") {
                    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                    if (!regex.test($("#txtForgetPassEmail").val())) {
                        $("#txtForgetPassEmail").css('border', '1px solid red');
                    } else {
                        $("#txtForgetPassEmail").css('border', 'none');
                        vEmail = true;
                    }
                }
                else {
                    $("#txtForgetPassEmail").css('border', '1px solid red');
                }

                if (vEmail == true) {
                    $("[id*=<%=lnkforgetpass.ClientID %>]").click();
                }
                else {
                    return false;
                }
            }


        </script>

        <script>

            //$('#form1').keydown(function (event) {
            $(document).on('keydown', function (event) {

                 
                if (event.keyCode == 10 || event.keyCode == 13) {
                     
                    var vEmail_pop = false;
                     


                    if ($("#txtEmail").val() != "") {
                        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                        if (!regex.test($("#txtEmail").val())) {
                            $("#txtEmail").css('border', '1px solid red');
                        } else {
                            $("#txtEmail").css('border', 'none');
                            vEmail_pop = true;
                        }
                    }
                    else {
                        $("#txtEmail").css('border', '1px solid red');
                    }

                    if (vEmail_pop == true) {
                        $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
                    }

                    //if ($('#Check1').is(':checked')) {
                    //    $("#check1").css('border', 'none');
                    //}
                    //else {
                    //    $("#check1").css('border', '1px solid red');
                    //    return false;
                    //}

                }
            });

            $('#form1').keydown(function (event) {


                if (event.keyCode == 10 || event.keyCode == 13) {
                     
                    var vEmail_pop = false;

                    if ($("#txtEmail").val() != "") {
                        var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                        if (!regex.test($("#txtEmail").val())) {
                            $("#txtEmail").css('border', '1px solid red');
                        } else {
                            $("#txtEmail").css('border', 'none');
                            vEmail_pop = true;
                        }
                    }
                    else {
                        $("#txtEmail").css('border', '1px solid red');
                    }
                    if (vEmail_pop == true) {
                        $("[id*=<%=lnkSubmitFrm.ClientID %>]").click();
                    }


                }

            });

        </script>

        <style>
            input#Button1 {
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

            a#lnkforgetpass {
    background: #007fc3;
    color: #fff;
    font-size: 26px;
    font-weight: bold;
    display: block;
    border: none;
    width: 100%;
    padding: 10px;
    text-align: center;
}
        </style>
    </form>
</body>
</html>
