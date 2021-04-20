<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="LoginPage_Registration" Culture="en-US" UICulture="en-US" Async="true" EnableEventValidation="false" %>

<%@ Import Namespace="SiteWare.Entity.Common.Enums" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>JEPCO-Register</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
        <div class="ragister">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <div class="ragi_blue">
                            <div class="forlogo">
                                <a href="javascript:void">
                                    <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/login-logo.png" alt="" />
                                </a>
                            </div>
                            <div class="ragister_service">
                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/service.png" alt="" />
                                <aside>التسجيل في الخدمات</aside>
                                <small>ادخل بياناتك للتسجيل في خدماتنا</small>

                                <p>رغبة من الشركة في زيادة تفاعلها مع مشتركيها وتقديم الخدمات الجديدة لهم مباشرة، فقد أطلقت الشركة خدمة حسابي والتي تتيح للمستفيد الفعلي سواءً كان مالكاً أو مستأجراً من معرفة تفاصيل فواتيرة</p>

                                <a href="/LoginPage/Login.aspx">هل لديك حساب بالفعل؟</a>
                                <button onserverclick="btnSignUp_Click" runat="server">تسجيل الدخول</button>
                                <%--<asp:Button ID="btnSignUp" type="button" OnClick="btnSignUp_Click" runat="server" Text="تسجيل الدخول" />--%>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-12 ">
                        <div class="ragi_white">
                            <aside>خدمة حسابي</aside>
                            <p style="margin-bottom: 5px;">الرجاء تعبئة المعلومات أدناه للتسجيل في البوابة الالكترونية لشركة الكهرباء الأردنية</p>
                            <p>بالمتابعة، أنت توافق على <a target="_blank" href="https://jepco.com.jo/ar/Home/%D8%A7%D9%84%D8%B4%D8%B1%D9%88%D8%B7-%D9%88%D8%A7%D9%84%D8%A3%D8%AD%D9%83%D8%A7%D9%85">شروط الاستخدام</a> وإشعار الخصوصية من JEPCO</p>

                            <div id="msform">
                                <ul class="list-unstyled steplist" id="progressbar2">
                                    <li class="active"><a href="javascript:void">الخطوة الاولى</a></li>
                                    <li><a href="javascript:void">الخطوة الثانية</a></li>
                                    <li><a href="javascript:void">الخطوة الثالثة</a></li>
                                    <li><a href="javascript:void">الخطوة الرابعة</a></li>
                                </ul>


                                <fieldset>
                                    <div class="step_form">

                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>نوع المستخدم</label>
                                                    <asp:DropDownList ID="ddlUSerType" runat="server" class="chzn-select">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>

                                        <div id="User1_S1">
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>الاسم الاول</label>
                                                        <asp:TextBox runat="server" ID="txtFirstName" placeholder="الاسم الاول" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>الاسم الثاني</label>
                                                        <asp:TextBox runat="server" ID="txtSecondName" placeholder="الاسم الثاني" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>الاسم الثالث</label>
                                                        <asp:TextBox runat="server" ID="txtThirdName" placeholder="الاسم الثالث" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span> اسم العائلة</label>
                                                        <asp:TextBox runat="server" ID="txtFamilyName" placeholder="اسم العائلة" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="User2_S1">

                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>اسم الشركة</label>
                                                        <asp:TextBox runat="server" ID="txtCompanyName" placeholder="اسم الشركة" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>الرقم الوطني للمنشأة</label>
                                                                <%--<asp:DropDownList ID="ddlNAtionalityUser2" runat="server" class="chzn-select">
                                                                </asp:DropDownList>--%>
                                                                <asp:TextBox runat="server" ID="txtNAtionalityUser2" placeholder="الرقم الوطني للمنشأة" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                                

                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <div class="form-group">
                                                                    <label>تصنيف الشركة</label>
                                                                    <asp:DropDownList ID="ddlCompanyClassification" runat="server" class="chzn-select">
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>



                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <div class="row">
                                                <div class="row">
                                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                                        <div class="form-group">
                                                            <label><span>*</span>كلمه السر</label>
                                                            <asp:TextBox runat="server" ID="txtPasswordUser2" TextMode="Password" placeholder="كلمه السر" ClientIDMode="Static" CssClass="user"></asp:TextBox>

                                                        </div>
                                                    </div>

                                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                                        <div class="form-group">
                                                            <label><span>*</span>تأكيد كلمة السر</label>
                                                            <asp:TextBox runat="server" ID="txtConformPassUser2" TextMode="Password" placeholder="تأكيد كلمة السر" ClientIDMode="Static" CssClass="user" autocomplete="on"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                                        <span>
                                                            <label id="error_lbl_PassValUser2" class="errlbl" style="display: none; float: right">كلمة المرور يجب أن لاتقل عن 8 وتحتوي على رقم على الأقل وعلى حرف على الأقل  </label>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                    </div>

                                    <input type="button" name="next" class="next action-button" value="التالي" id="nextFirstStp" />
                                </fieldset>
                                <fieldset>
                                    <div class="step_form">

                                        <div id="User1_S2">

                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">

                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>الجنسية</label>
                                                                <asp:DropDownList ID="ddlNAtionality" runat="server" class="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlNAtionality_SelectedIndexChanged">
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>

                                                    </div>



                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>نوع الوثيقة</label>
                                                                <asp:DropDownList ID="ddlIDType" runat="server" class="chzn-select">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <div class="form-group">
                                                                    <label>رقم الوثيقة</label>
                                                                    <asp:TextBox runat="server" ID="txtIDNumber" placeholder="رقم الوثيقة" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <div class="row">

                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>كلمه السر</label>
                                                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="كلمه السر" ClientIDMode="Static" CssClass="user"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>تأكيد كلمة السر</label>
                                                        <asp:TextBox runat="server" ID="txtConformPass" TextMode="Password" placeholder="تأكيد كلمة السر" ClientIDMode="Static" CssClass="user" autocomplete="on"></asp:TextBox>
                                                    </div>
                                                </div>


                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <span>
                                                        <label id="error_lbl_PassVal" class="errlbl" style="display: none; float: right">كلمة المرور يجب أن لاتقل عن 8 وتحتوي على رقم على الأقل وعلى حرف على الأقل  </label>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="User2_S2">
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>رقم الهاتف المحمول</label>
                                                        <div class="row">

                                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                                <asp:TextBox runat="server" ID="txtMobileUser2" placeholder="7XXXXXXXX" ClientIDMode="Static" CssClass="user mobileNo" Style="font-family: TimesNewRoman,Times,serif;"></asp:TextBox>

                                                            </div>
                                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                                <%-- <span>+ 962</span>--%>
                                                                <asp:TextBox runat="server" ID="txtMobileCodeUser2" placeholder="962+" ClientIDMode="Static" CssClass="user mobileNo" ReadOnly="true"></asp:TextBox>

                                                            </div>

                                                        </div>


                                                    </div>
                                                </div>

                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>رقم هاتف</label>
                                                        <asp:TextBox runat="server" ID="txtTelePhoneUser2" placeholder="رقم هاتف" ClientIDMode="Static" CssClass="user mobileNo"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <label id="lblMobileErrorUSer2" class="errlbl" style="display: none; float: right;"><span>يجب ألا يبدأ رقم الهاتف بصفر وليس بأكثر من 9 أرقام</span></label>
                                                    <label id="lblMobileRegistedErrorUSer2" class="errlbl" style="display: none; float: right;"><span>رقم الهاتف مسجل بالفعل</span></label>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>البريد الإلكتروني</label>
                                                        <asp:TextBox runat="server" ID="txtEmailUSer2" placeholder="البريد الإلكتروني" ClientIDMode="Static" CssClass="user" Style="font-family: Montserrat"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <label id="errorEmailuse2" class="errlbl" style="display: none; float: right;"><span>البريد الالكتروني مستخدم مسبقا</span></label>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>رقم الفاكس</label>
                                                        <asp:TextBox runat="server" ID="txtFaxUSer2" placeholder="رقم الفاكس" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>الموقع الالكتروني</label>
                                                        <asp:TextBox runat="server" ID="txtWebsiteUser2" placeholder="الموقع الالكتروني" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                    <input type="button" name="next" class="next action-button" value="التالي" />
                                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                                </fieldset>
                                <fieldset>
                                    <div class="step_form">

                                        <div id="User1_S3">

                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>رقم الهاتف المحمول</label>
                                                        <div class="row">

                                                            <div class="col-lg-8 col-md-8 col-sm-8">
                                                                <asp:TextBox runat="server" ID="txtMobileNo" placeholder="7XXXXXXXX" ClientIDMode="Static" CssClass="user mobileNo" Style="font-family: TimesNewRoman,Times,serif;"></asp:TextBox>

                                                            </div>
                                                            <div class="col-lg-4 col-md-4 col-sm-4">
                                                                <%-- <span>+ 962</span>--%>
                                                                <asp:TextBox runat="server" ID="TextBox1" placeholder="962+" ClientIDMode="Static" CssClass="user mobileNo" ReadOnly="true"></asp:TextBox>

                                                            </div>

                                                        </div>


                                                    </div>
                                                </div>

                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>رقم هاتف</label>
                                                        <asp:TextBox runat="server" ID="txtTelePhoneNo" placeholder="رقم هاتف" ClientIDMode="Static" CssClass="user mobileNo"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <label id="lblMobileError" class="errlbl" style="display: none; float: right;"><span>يجب ألا يبدأ رقم الهاتف بصفر وليس بأكثر من 9 أرقام</span></label>
                                                    <label id="lblMobileRegistedError" class="errlbl" style="display: none; float: right;"><span>رقم الهاتف مسجل بالفعل</span></label>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label><span>*</span>البريد الإلكتروني</label>
                                                        <asp:TextBox runat="server" ID="txtEmail" placeholder="البريد الإلكتروني" ClientIDMode="Static" CssClass="user" Style="font-family: Montserrat"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <label id="errorEmailuse" class="errlbl" style="display: none; float: right;"><span>البريد الالكتروني مستخدم مسبقا</span></label>
                                                </div>


                                            </div>
                                            <div class="row" style="display: none;">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>خط الطول</label>
                                                        <asp:TextBox runat="server" ID="txtLongitude" placeholder="خط الطول" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>خط العرض</label>
                                                        <asp:TextBox runat="server" ID="txtLatitude" placeholder="خط العرض" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div id="User2_S3">

                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>

                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>المحافظة</label>
                                                                <select id="ddlGeove" name="ddlGeove" class="form-control" tabindex="2"></select>

                                                                <%-- <asp:DropDownList ID="ddlGovernateUSer2" runat="server" class="chzn-select">
                                                                </asp:DropDownList>--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <div class="form-group">
                                                                    <label>المنطقة 1</label>
                                                                    <select id="ddlAreas" name="ddlAreas" class="form-control" tabindex="2"></select>
                                                                    <%--<select id="ddlsteet" name="ddlsteet" class="form-control" tabindex="2"></select>--%>
                                                                    <%-- <asp:DropDownList ID="ddlArea1USer2" runat="server" class="chzn-select">
                                                                    </asp:DropDownList>--%>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>المنطقة 2</label>
                                                                <select id="ddlAreas2" name="ddlAreas2" class="form-control" tabindex="2"></select>
                                                                <%--<asp:DropDownList ID="ddlArea2USer2" runat="server" class="chzn-select">
                                                                </asp:DropDownList>--%>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <div class="form-group">
                                                                    <label>الشارع</label>
                                                                    <select id="ddlsteet" name="ddlsteet" class="form-control" tabindex="2"></select>
                                                                    <%-- <asp:DropDownList ID="ddlStreet" runat="server" class="chzn-select">
                                                                    </asp:DropDownList>--%>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>



                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">
                                                        <label>العنوان</label>
                                                        <asp:TextBox runat="server" ID="txtAdressUSer2" placeholder="العنوان" ClientIDMode="Static" CssClass="user"></asp:TextBox>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                    <input type="button" name="next" class="next action-button" value="التالي" />
                                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                                </fieldset>
                                <fieldset>
                                    <div class="step_form">

                                        <div id="User1_S4">
                                            <asp:UpdatePanel ID="up1" runat="server">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>بلد</label>
                                                                <asp:DropDownList ID="ddlCountry" runat="server" class="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>مدينة</label>
                                                                <asp:DropDownList ID="ddlCity" runat="server" class="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>


                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-12">
                                                            <div class="form-group">
                                                                <label>المنطقة 1</label>
                                                                <asp:DropDownList ID="ddlArea1" runat="server" class="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlArea1_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <%-- <div class="col-lg-6 col-md-6 col-sm-12">
                                                        <div class="form-group">
                                                            <label>المنطقة 2</label>
                                                            <asp:DropDownList ID="ddlArea2" runat="server" class="chzn-select">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>  --%>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12">
                                                    <div class="form-group">
                                                        <label>عنوان</label>
                                                        <asp:TextBox runat="server" ID="txtAddress" placeholder="عنوان السكن" ClientIDMode="Static" CssClass="user"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>




                                        <div id="User2_S4">

                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-12">

                                                    <div class="file-upload">

                                                        <label for="fileuploadfield_1" class="custom-file-upload fieldlabels">
                                                            السجل التجاري للشركة
                                   
                                                        </label>
                                                        <input id="fileuploadfield_1" name="fileuploadfield_1" type="file" class="demoInputBox" />


                                                        <span class="file-select">No file selected</span>
                                                        <br />
                                                        <span id="file_error1" style="color: red"></span>


                                                        <%--<br />
                                <span class="fieldlabels">الرجاء تحميل السيرة الذاتية بنوع doc  أو docx  أو pdf  وبحجم أقصى 2 ميجابايت</span>--%>
                                                    </div>

                                                   <%--  <label class="fieldlabels">السجل التجاري للشركة</label>
                                                    <label for="fileuploadfield_3" class="custom-file-upload fieldlabels">
                                                        اختيار الملف
                                                    </label>
                                                    <input id="fileuploadfield_3" name="fileuploadfield_3" type="file" class="demoInputBox" />
                                                    <span class="file-select">No file selected</span>
                                                    <span id="file_error" style="color: red"></span>
                                                    <br />
                                                    <span class="fieldlabels">الرجاء تحميل السيرة الذاتية بنوع doc  أو docx  أو pdf  وبحجم أقصى 2 ميجابايت</span>--%>
                                                </div>

                                                <div class="col-lg-6 col-md-6 col-sm-12">

                                                    <div class="file-upload">
                                                        <label for="fileuploadfield_2" class="custom-file-upload fieldlabels">
                                                          صورة عن ترخيص الشركة
                                   
                                                        </label>
                                                        <input id="fileuploadfield_2" name="fileuploadfield_2" type="file" class="demoInputBox" />
                                                        <span class="file-select">No file selected</span>
                                                        <br />
                                                        <span id="file_error2" style="color: red"></span>
                                                      
                                                    </div>

                                                    <%-- <label class="fieldlabels">صورة عن ترخيص الشركة</label>
                                                    <label for="fileuploadfield_2" class="custom-file-upload fieldlabels">
                                                        اختيار الملف
                                                    </label>
                                                    <input id="fileuploadfield_2" name="fileuploadfield_2" type="file" class="demoInputBox" />
                                                    <span class="file-select">No file selected</span>
                                                    <span id="file_error2" style="color: red"></span>
                                                    <br />
                                                    <span class="fieldlabels">الرجاء تحميل السيرة الذاتية بنوع doc  أو docx  أو pdf  وبحجم أقصى 2 ميجابايت</span>--%>
                                                </div>
                                            </div>

                                            <div class="row">

                                                <div class="col-lg-6 col-md-6 col-sm-12">
                                                    <div class="form-group">

                                                        <label>تاريخ انتهاء الترخيص <span style="color: red">*</span></label>
                                                        <input id="txtQualificationDate" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                                    </div>
                                                </div>

                                            </div>


                                        </div>

                                    </div>
                                    <button class="btn action-button" type="button" id="btbvalid" onclick="SendClick();">إرسال</button>
                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" type="button" Style="display: none;" runat="server" Text="Button" />
                                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                                </fieldset>
                            </div>



                            <%--<div class="step_form">
              

            <div class="form-group">
              <label><span>*</span>الاسم الاول</label>
                 
              <input type="text" placeholder="عبد الكريم الجغبير">
            </div>
            <div class="form-group">
              <label><span>*</span> البريد الالكتروني</label>
              <input type="text" placeholder="البريد الالكتروني">
            </div>
            <div class="form-group">
              <label><span>*</span> موبايل</label>
              <input type="text" placeholder="البريد الالكتروني">
            </div>
            <!-- <div class="Re_captch">
              <div class="ragi_check_box">
                <input type="checkbox" id="html">
                <label for="html">الفحص البشري</label>
              </div>
              <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Re-captch.png" alt="">
            </div> -->
            
            <div class="ragibtn">
              <button>متابعة</button>
              <button class="cancelbtn">الغاء</button>
            </div>
          </div>--%>
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


        <asp:LinkButton ID="lnkSubscribe" runat="server"></asp:LinkButton>
        <cc1:ModalPopupExtender runat="server" ID="mpeInquiry"
            TargetControlID="lnkSubscribe" BehaviorID="mpeInquiry"
            BackgroundCssClass="modalBackground" PopupControlID="panelInquiry"
            CancelControlID="btnClose">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="panelInquiry" runat="server" CssClass="modalPopup d_model_popup l_modelpopup welcome in" Style="display: none; position: fixed; top: 0px; right: 0px; bottom: 0px; left: 0.5px; z-index: 1000001; overflow: hidden; outline: 0px;background:rgb(194 194 194 / 72%);">
            <div class="modal-dialog modal-md">
                <!-- Modal content-->
                <div class="modal-content">

                    <div class="modal-header">


                        <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnClose">&times;</asp:LinkButton>
                        <h4 class="modal-title" id="myModalLabel">
                            <asp:Literal runat="server" ID="lblInquiryTitle" Text="حساب جديد"></asp:Literal></h4>
                    </div>
                    <div class="modal-body">
                        <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                            <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                            <p>
                                <asp:Literal runat="server" ID="lblInquiryMessage" Text="تم انشاء حسابك بنجاح, يرجى تسجيل الدخول عبر البوابة الالكترونية الخاصة بالخدمات الالكترونية">                             
                                </asp:Literal>
                            </p>
                            <p>
                                <asp:Literal runat="server" ID="lblInquiryMessage2" Text="شكرا لكم ">                             
                                </asp:Literal>
                            </p>
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
        <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                jQuery(".Dateeee").datepicker();

            });
        </script>

        <script>
            $(".forpass").click(function () {
                $(".card").addClass("flipped");
            });
            $(".arenewuser").click(function () {
                $(".card").removeClass("flipped");
            });
        </script>

        <script type="text/javascript">
            $("document").ready(function () {




                //$('input[type=file]').change(function (e) {
                //    debugger;


                //    $in = $(this);
                //    var abcd2 = "";
                //    $in.next().html(abcd2);

                //    debugger;
                //    var fileInput =
                //        document.getElementById('fileuploadfield_1');

                //    var filePath = fileInput.value;


                //    var allowedExtensions =
                //        /(\.PDF|\.doc|\.docx)$/i;

                //    if (!allowedExtensions.exec(filePath)) {

                //        $("#file_error").html("Invalid file type");
                //        fileInput.value = '';
                //        return false;
                //    }
                //    else {
                //        $in = $(this);
                //        var abcd = $in[0].files[0].name;
                //        $in.next().html(abcd);
                //        $("#file_error").html("");

                //    }

                //});

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
                    debugger;
                    var fileInput2 = document.getElementById('fileuploadfield_2');
                    var filePath2 = fileInput2.value;   // Allowing file type           
                    var allowedExtensions2 =
                        /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
                    if (!allowedExtensions2.exec(filePath2)) {
                        $("#file_error2").html("Invalid file type");
                        fileInput2.value = '';
                        $('#fileuploadfield_2').next().html("");
                        return false;
                    }
                    else {
                        // $in = $(this);
                        var abc2 = $('#fileuploadfield_2')[0].files[0].name;
                        $('#fileuploadfield_2').next().html(abc2);
                        $("#file_error2").html("");
                    }

                });




                var SelectedUserValidation = 1;

                $("#User1_S1").hide();
                $("#User2_S1").hide();

                $('#nextFirstStp').prop('disabled', true);

                $('#<%=ddlUSerType.ClientID %>').change(function () {

                    $('#nextFirstStp').prop('disabled', false);



                    if ($('#<%=ddlUSerType.ClientID %>').val() == "0") {
                        $("#User1_S1").hide();
                        $("#User2_S1").hide();

                        $("#User1_S2").hide();
                        $("#User2_S2").hide();

                        $("#User1_S3").hide();
                        $("#User2_S3").hide();

                        $("#User1_S4").hide();
                        $("#User2_S4").hide();
                        SelectedUserValidation = 1;

                        $('#nextFirstStp').prop('disabled', true);
                    }

                    else if ($('#<%=ddlUSerType.ClientID %>').val() == "1") {
                        $("#User1_S1").show();
                        $("#User2_S1").hide();

                        $("#User1_S2").show();
                        $("#User2_S2").hide();

                        $("#User1_S3").show();
                        $("#User2_S3").hide();

                        $("#User1_S4").show();
                        $("#User2_S4").hide();
                        SelectedUserValidation = 1;
                    }
                    else {
                        $("#User1_S1").hide();
                        $("#User2_S1").show();

                        $("#User1_S2").hide();
                        $("#User2_S2").show();

                        $("#User1_S3").hide();
                        $("#User2_S3").show();

                        $("#User1_S4").hide();
                        $("#User2_S4").show();
                        SelectedUserValidation = 2;

                    }
                });

                if (testArray) {

                }

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

                    if (SelectedUserValidation == 1) {

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

                        if (current == 3) {

                            step3validResult = false;
                            step3Valid();
                            if (step3validResult == true) {
                            }
                            else {
                                return false;
                            }
                        }
                    }
                    else {

                        if (current == 1) {

                            step1validResult = false;
                            step1ValidUSer1();
                            debugger;
                            if (step1validResult == true) {
                            }
                            else {
                                return false;
                            }
                        }

                        if (current == 2) {
                            step2validResult = false;
                            step2ValidUSer1();
                            debugger;
                            if (step2validResult == true) {
                            }
                            else {
                                return false;
                            }
                        }

                        if (current == 3) {

                            step3validResult = false;
                            step3ValidUSer1();
                            if (step3validResult == true) {
                            }
                            else {
                                return false;
                            }
                        }


                    }






                    //if (current == 4) {
                    //     
                    //    step4validResult = false;
                    //    step4Valid();
                    //    if (step4validResult == true) {
                    //    }
                    //    else {
                    //        return false;
                    //    }
                    //}


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


                function step1Valid() {

                    var ValFirstName = false;
                    var ValSecondName = false;
                    var ValThirdName = false;
                    var ValLastName = false;

                    if ($('#<%= txtFirstName.ClientID %>').val().trim() != '') {

                        $('#<%= txtFirstName.ClientID %>').css('border', 'none');
                        ValFirstName = true;
                    }
                    else {

                        $('#<%= txtFirstName.ClientID %>').css('border', '1px solid red');
                    }

                    if ($('#<%= txtSecondName.ClientID %>').val().trim() != '') {

                        $('#<%= txtSecondName.ClientID %>').css('border', 'none');
                        ValSecondName = true;
                    }
                    else {

                        $('#<%= txtSecondName.ClientID %>').css('border', '1px solid red');
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
                        ValLastName = true;
                    }
                    else {

                        $('#<%= txtFamilyName.ClientID %>').css('border', '1px solid red');
                    }



                    if (ValFirstName == true &&
                        ValSecondName == true &&
                        ValThirdName == true &&
                        ValLastName == true) {

                        step1validResult = true;
                    }
                    else {

                        step1validResult = false;
                    }
                }
                function step2Valid() {

                    var PassWord_S3 = false;

                    var ConformPassWord_S3 = false;
                    var ComparePassWord_S3 = false;

                    var DoctType = false;


                    if ($('#<%= txtPassword.ClientID %>').val().trim() != '') {

                        $('#<%= txtPassword.ClientID %>').css('border', 'none');

                        var mayPass = $('#<%= txtPassword.ClientID %>').val();

                        if (mayPass.length >= 8) {

                            var lowerCaseLetters = /[a-z]/g;
                            if (mayPass.match(lowerCaseLetters)) {

                                var numbers = /[0-9]/g;
                                if (mayPass.match(numbers)) {
                                    PassWord_S3 = true;
                                    $('#error_lbl_PassVal').css("display", "none");

                                }
                                else {
                                    $('#error_lbl_PassVal').css("display", "block");
                                    $('#error_lbl_PassVal').css("color", "red");
                                    $('#<%= txtPassword.ClientID %>').css('border', '1px solid red');
                                }




                            }
                            else {
                                $('#error_lbl_PassVal').css("display", "block");
                                $('#error_lbl_PassVal').css("color", "red");
                                $('#<%= txtPassword.ClientID %>').css('border', '1px solid red');
                            }

                        }
                        else {
                            $('#error_lbl_PassVal').css("display", "block");
                            $('#error_lbl_PassVal').css("color", "red");
                            $('#<%= txtPassword.ClientID %>').css('border', '1px solid red');
                        }


                    }
                    else {

                        $('#<%= txtPassword.ClientID %>').css('border', '1px solid red');
                    }

                    if ($('#<%= txtConformPass.ClientID %>').val().trim() != '') {

                        $('#<%= txtConformPass.ClientID %>').css('border', 'none');
                        ConformPassWord_S3 = true;

                        var password1 = $('#<%=txtPassword.ClientID %>').val().trim();
                        var password2 = $('#<%= txtConformPass.ClientID %>').val().trim();
                        if (password1 == password2) {
                            ComparePassWord_S3 = true;

                        }
                        else {
                            $('#<%= txtConformPass.ClientID %>').css('border', '1px solid red');
                        }

                    }
                    else {

                        $('#<%= txtConformPass.ClientID %>').css('border', '1px solid red');
                    }



                    if ($('#<%= txtIDNumber.ClientID %>').val().trim() != '') {

                        $('#<%= txtIDNumber.ClientID %>').css('border', 'none');
                        DoctType = true;
                    }
                    else {

                        $('#<%= txtIDNumber.ClientID %>').css('border', '1px solid red');
                    }



                    if (PassWord_S3 == true && ConformPassWord_S3 == true && ComparePassWord_S3 == true && DoctType == true) {

                        step2validResult = true;
                    }
                    else {

                        step2validResult = false;
                    }
                }
                function step3Valid() {

                    var FEmail_S3 = false;
                    var MoBileno_S3 = false;

                    if ($('#<%= txtEmail.ClientID %>').val().trim() != '') {
                        $('#<%= txtEmail.ClientID %>').css('border', 'none');
                        if ($('#<%= txtEmail.ClientID %>').val().trim() != "") {
                            var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                            if (!regex.test($('#<%= txtEmail.ClientID %>').val())) {
                                $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

                            }
                            else {
                                $('#<%= txtEmail.ClientID %>').css('border', 'none');

                                var compareEMailwithArry = false;
                                var myEmail = $('#<%= txtEmail.ClientID %>').val();



                                $.each(testArray, function () {
                                    var self = this.toString();

                                    if (myEmail.indexOf(self) === -1) {


                                    }
                                    else {

                                        compareEMailwithArry = true;
                                    }
                                });

                                if (compareEMailwithArry == true) {
                                    $("#errorEmailuse").css("display", "block");
                                    $("#errorEmailuse").css("color", "red");
                                }
                                else {
                                    $("#errorEmailuse").css("display", "none");

                                    FEmail_S3 = true;
                                }




                            }
                        }
                        else {
                            $("#txtEmail").css('border', '1px solid red');

                        }
                    }
                    else {
                        $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

                    }


                    if ($('#<%= txtMobileNo.ClientID %>').val().trim() != '') {

                        $('#<%= txtMobileNo.ClientID %>').css('border', 'none');

                        var mobiles = $('#<%= txtMobileNo.ClientID %>').val();

                        if (mobiles.length != 9) {
                            $("#lblMobileError").css("display", "block");
                            $("#lblMobileError").css("color", "red");
                        }
                        else {
                            var mobile_pattern = /^[1-9]{1}[0-9]+/;
                            if (mobiles.match(mobile_pattern)) {


                                var compareMobielwithArry = false;
                                $.each(testArrayMobiles, function () {
                                    var self = this.toString();
                                    var RemoveFirstCharThreeSub = self.substring(4);
                                    if (mobiles != RemoveFirstCharThreeSub) {

                                    }
                                    else {

                                        compareMobielwithArry = true;
                                    }
                                });

                                if (compareMobielwithArry == true) {
                                    $("#lblMobileRegistedError").css("display", "block");
                                    $("#lblMobileRegistedError").css("color", "red");
                                    $("#lblMobileError").css("display", "none");
                                }
                                else {

                                    MoBileno_S3 = true;
                                    $("#lblMobileError").css("display", "none");
                                    $("#lblMobileRegistedError").css("display", "none");


                                }

                                //MoBileno_S3 = true;
                                //$("#lblMobileError").css("display", "none");
                            }
                            else {
                                $("#lblMobileError").css("display", "block");
                                $("#lblMobileError").css("color", "red");

                            }
                        }

                    }
                    else {

                        $('#<%= txtMobileNo.ClientID %>').css('border', '1px solid red');
                    }

                    if (FEmail_S3 == true && MoBileno_S3 == true) {

                        step3validResult = true;
                    }
                    else {

                        step3validResult = false;
                    }
                }


                function step1ValidUSer1() {
                    //-----------------------------------------------------------------
                    var ValCompanyName = false;
                    var ValNAtionalUSer2 = false;
                    var ValClassificationUSer2 = false;
                    var PassWord_S3 = false;
                    var ComparePassWord_S3 = false;


                    if ($('#<%= txtCompanyName.ClientID %>').val().trim() != '') {

                        $('#<%= txtCompanyName.ClientID %>').css('border', 'none');
                        ValCompanyName = true;
                    }
                    else {

                        $('#<%= txtCompanyName.ClientID %>').css('border', '1px solid red');
                    }


                    <%--if ($('#<%= ddlNAtionalityUser2.ClientID %> option:selected').val() == "0") {

                        $('#<%= ddlNAtionalityUser2.ClientID %>').css('border', '1px solid red');
                    }
                    else {
                        $('#<%= ddlNAtionalityUser2.ClientID %>').css('border', 'none');
                        ValNAtionalUSer2 = true;
                    }--%>

                    if ($('#<%= txtNAtionalityUser2.ClientID %>').val().trim() != '') {

                        $('#<%= txtNAtionalityUser2.ClientID %>').css('border', 'none');
                        ValNAtionalUSer2 = true;
                      }
                      else {

                          $('#<%= txtNAtionalityUser2.ClientID %>').css('border', '1px solid red');
                      }


                    if ($('#<%= ddlCompanyClassification.ClientID %> option:selected').val() == "0") {

                        $('#<%= ddlCompanyClassification.ClientID %>').css('border', '1px solid red');
                    }
                    else {
                        $('#<%= ddlCompanyClassification.ClientID %>').css('border', 'none');
                        ValClassificationUSer2 = true;
                    }


                    if ($('#<%= txtPasswordUser2.ClientID %>').val().trim() != '') {

                        $('#<%= txtPasswordUser2.ClientID %>').css('border', 'none');

                        var mayPass = $('#<%= txtPasswordUser2.ClientID %>').val();

                        if (mayPass.length >= 8) {

                            var lowerCaseLetters = /[a-z]/g;
                            if (mayPass.match(lowerCaseLetters)) {

                                var numbers = /[0-9]/g;
                                if (mayPass.match(numbers)) {
                                    PassWord_S3 = true;
                                    $('#error_lbl_PassValUser2').css("display", "none");

                                }
                                else {
                                    $('#error_lbl_PassValUser2').css("display", "block");
                                    $('#error_lbl_PassValUser2').css("color", "red");
                                    $('#<%= txtPasswordUser2.ClientID %>').css('border', '1px solid red');
                                }




                            }
                            else {
                                $('#error_lbl_PassValUser2').css("display", "block");
                                $('#error_lbl_PassValUser2').css("color", "red");
                                $('#<%= txtPasswordUser2.ClientID %>').css('border', '1px solid red');
                            }

                        }
                        else {
                            $('#error_lbl_PassValUser2').css("display", "block");
                            $('#error_lbl_PassValUser2').css("color", "red");
                            $('#<%= txtPasswordUser2.ClientID %>').css('border', '1px solid red');
                        }


                    }
                    else {

                        $('#<%= txtPasswordUser2.ClientID %>').css('border', '1px solid red');
                    }

                    if ($('#<%= txtConformPassUser2.ClientID %>').val().trim() != '') {

                        $('#<%= txtConformPassUser2.ClientID %>').css('border', 'none');
                        ConformPassWord_S3 = true;

                        var password1 = $('#<%=txtPasswordUser2.ClientID %>').val().trim();
                        var password2 = $('#<%= txtConformPassUser2.ClientID %>').val().trim();
                        if (password1 == password2) {
                            ComparePassWord_S3 = true;

                        }
                        else {
                            $('#<%= txtConformPassUser2.ClientID %>').css('border', '1px solid red');
                        }

                    }
                    else {

                        $('#<%= txtConformPass.ClientID %>').css('border', '1px solid red');
                    }

                    //-----------------------------------------------------------------


                    debugger;

                    if (ValCompanyName == true &&
                        ValNAtionalUSer2 == true &&
                        ValClassificationUSer2 == true &&
                        PassWord_S3 == true &&
                        ComparePassWord_S3 == true) {

                        step1validResult = true;
                    }
                    else {

                        step1validResult = false;
                    }
                }


                function step2ValidUSer1() {

                    var FEmail_S2 = false;
                    var MoBileno_S2 = false;
                    debugger;
                    if ($('#<%= txtEmailUSer2.ClientID %>').val().trim() != '') {
                        $('#<%= txtEmailUSer2.ClientID %>').css('border', 'none');
                        if ($('#<%= txtEmailUSer2.ClientID %>').val().trim() != "") {
                            var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                            if (!regex.test($('#<%= txtEmailUSer2.ClientID %>').val())) {
                                $('#<%= txtEmailUSer2.ClientID %>').css('border', '1px solid red');

                            }
                            else {
                                $('#<%= txtEmailUSer2.ClientID %>').css('border', 'none');

                                var compareEMailwithArry = false;
                                var myEmail = $('#<%= txtEmailUSer2.ClientID %>').val();



                                $.each(testArray, function () {
                                    var self = this.toString();

                                    if (myEmail.indexOf(self) === -1) {


                                    }
                                    else {

                                        compareEMailwithArry = true;
                                    }
                                });

                                if (compareEMailwithArry == true) {
                                    $("#errorEmailuse2").css("display", "block");
                                    $("#errorEmailuse2").css("color", "red");
                                }
                                else {
                                    $("#errorEmailuse2").css("display", "none");

                                    FEmail_S2 = true;
                                }




                            }
                        }
                        else {
                            $("#txtEmailUSer2").css('border', '1px solid red');

                        }
                    }
                    else {
                        $('#<%= txtEmailUSer2.ClientID %>').css('border', '1px solid red');

                    }


                    if ($('#<%= txtMobileUser2.ClientID %>').val().trim() != '') {

                        $('#<%= txtMobileUser2.ClientID %>').css('border', 'none');

                        var mobiles = $('#<%= txtMobileUser2.ClientID %>').val();

                        if (mobiles.length != 9) {
                            debugger;
                            $("#lblMobileErrorUSer2").css("display", "block");
                            $("#lblMobileErrorUSer2").css("color", "red");
                        }
                        
                        else {
                            var mobile_pattern = /^[1-9]{1}[0-9]+/;
                            if (mobiles.match(mobile_pattern)) {


                                var compareMobielwithArry = false;
                                $.each(testArrayMobiles, function () {
                                    var self = this.toString();
                                    var RemoveFirstCharThreeSub = self.substring(4);
                                    if (mobiles != RemoveFirstCharThreeSub) {

                                    }
                                    else {

                                        compareMobielwithArry = true;
                                    }
                                });

                                if (compareMobielwithArry == true) {
                                    $("#lblMobileRegistedErrorUSer2").css("display", "block");
                                    $("#lblMobileRegistedErrorUSer2").css("color", "red");
                                    $("#lblMobileErrorUSer2").css("display", "none");
                                }
                                else {

                                    MoBileno_S2 = true;
                                    $("#lblMobileErrorUSer2").css("display", "none");
                                    $("#lblMobileRegistedErrorUSer2").css("display", "none");


                                }

                                //MoBileno_S3 = true;
                                //$("#lblMobileError").css("display", "none");
                            }
                            else {
                                $("#lblMobileErrorUSer2").css("display", "block");
                                $("#lblMobileErrorUSer2").css("color", "red");

                            }
                        }

                    }
                    else {

                        $('#<%= txtMobileUser2.ClientID %>').css('border', '1px solid red');
                    }

                    debugger;
                    if (FEmail_S2 == true && MoBileno_S2 == true) {

                        step2validResult = true;
                    }
                    else {

                        step2validResult = false;
                    }
                }

                function step3ValidUSer1() {

                    //var FEmail_S3 = false;
                    //var MoBileno_S3 = false;
                    var ValGovernate = false;
                    var ValArea = false;
                    var ValArea2 = false;

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

                    if (ValGovernate == true && ValArea == true && ValArea2 == true) {

                        step3validResult = true;
                    }
                    else {

                        step3validResult = false;
                    }
                }

            });


            function SendClick() {

                var SelectedUserValidation = 1;



                if ($('#<%= ddlUSerType.ClientID %> option:selected').val() == "1") {

                    SelectedUserValidation = 1;
                }
                else {
                    SelectedUserValidation = 2;
                }

                debugger;
                if (SelectedUserValidation == 1) {

                    var APIF_Name = $("#txtFirstName").val(); //$('#<%=txtFirstName.ClientID %>').val();
                    var APIl_Name = $("#txtFamilyName").val(); // $('#<%=txtFirstName.ClientID %>').val();
                    var APImobileNumbers = $("#txtMobileNo").val();      //$('#<%=txtMobileNo.ClientID %>').val();
                    var APIemails = $("#txtEmail").val(); //$('#<%=txtEmail.ClientID %>').val();
                    var APInationalNumbers = "0";

                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        //url: "https://mobile.jepco.com.jo:8443/JepcoMobApiProd/profile/newCreate",
                        url: "http://217.144.0.219:8080/JepcoMobApiProd/profile/newCreate",

                        // data: JSON.stringify({ alias: 'myATest', fileNumber: '0110892277693', mobileNumber: '+962790121435' }),
                        data: JSON.stringify({ firstName: APIF_Name, lastName: APIl_Name, mobileNumber: APImobileNumbers, email: APIemails, nationalNumber: APInationalNumbers }),
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            // alert("Call Success");
                            console.log(data);



                        },
                        error: function (result) {

                            console.log(result);
                            //alert("Error");

                        }
                    });

                    $("[id*=<%=btnSubmit.ClientID %>]").click();
                }
                else {


                    var FileUpload1 = false;
                    var FileUpload2 = false;
                    var ValQualificationDate = false;

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
                        if (file_size1 > 1000001) {
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
                        if (file_size2 > 1000001) {
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

                    if ($('#<%= txtQualificationDate.ClientID %>').val().trim() != '') {

                        if ($('#<%= txtQualificationDate.ClientID %>').val().trim() != "") {

                             var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                             if (!regex.test($('#<%= txtQualificationDate.ClientID %>').val())) {
                        $('#<%= txtQualificationDate.ClientID %>').css('border', '1px solid red');

                    } else {
                        $('#<%= txtQualificationDate.ClientID %>').css('border', 'none');
                        ValQualificationDate = true;
                    }
                }
                else {
                    $('#<%= txtQualificationDate.ClientID %>').css('border', '1px solid red');
                         }
                     }
                     else {
                         $('#<%= txtQualificationDate.ClientID %>').css('border', '1px solid red');
                     }

                    debugger;
                    if (FileUpload1 == true && FileUpload2 == true && ValQualificationDate == true) {
                        var APIF_Name = $("#txtCompanyName").val(); //$('#<%=txtFirstName.ClientID %>').val();
                        var APIl_Name = ""; // $('#<%=txtFirstName.ClientID %>').val();
                        var APImobileNumbers = $("#txtMobileUser2").val();      //$('#<%=txtMobileNo.ClientID %>').val();
                        var APIemails = $("#txtEmailUSer2").val(); //$('#<%=txtEmail.ClientID %>').val();
                        var APInationalNumbers = "0";

                        

                        //$.ajax({
                        //    type: "POST",
                        //    contentType: "application/json; charset=utf-8",
                        //    //url: "https://mobile.jepco.com.jo:8443/JepcoMobApiProd/profile/newCreate",
                        //    url: "http://217.144.0.219:8080/JepcoMobApiProd/profile/newCreate",

                        //    // data: JSON.stringify({ alias: 'myATest', fileNumber: '0110892277693', mobileNumber: '+962790121435' }),
                        //    data: JSON.stringify({ firstName: APIF_Name, lastName: APIl_Name, mobileNumber: APImobileNumbers, email: APIemails, nationalNumber: APInationalNumbers }),
                        //    dataType: "json",
                        //    async: false,
                        //    success: function (data) {
                        //        // alert("Call Success");
                        //        console.log(data);



                        //    },
                        //    error: function (result) {

                        //        console.log(result);
                        //        //alert("Error");

                        //    }
                        //});

                        $("[id*=<%=btnSubmit.ClientID %>]").click();


                    }
                }

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

            /*#msform {
                text-align: center;
                position: relative;
                margin-top: 20px
            }*/

            #msform fieldset {
                background: white;
                border: 0 none;
                border-radius: 0.5rem;
                box-sizing: border-box;
                width: 100%;
                margin: 0;
                padding-bottom: 0px;
                position: relative
            }

            .form-card {
                text-align: left;
                padding: 45px 45px;
                background: #ebeceb;
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
            }

            #msform .action-button-previous {
                width: 100px;
                background: #e7e7e7;
                font-weight: bold;
                color: #c2c2c2;
                border: 0 none;
                border-radius: 0px;
                cursor: pointer;
                padding: 10px 5px;
                margin: 10px 5px 10px 0px;
                float: right;
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
                height: 45px;
                border: 1px solid #e2e2e2;
                padding: 10px;
                margin-bottom: 4px;
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

                /*.form-card input[type="radio"].toggle + label:after {
            background: #1a1a1a;
            content: "";
            height: 100%;
            position: absolute;
            top: 0;
            -webkit-transition: left 200ms cubic-bezier(0.77, 0, 0.175, 1);
            transition: left 200ms cubic-bezier(0.77, 0, 0.175, 1);
            width: 100%;
            z-index: -1;
        }

    .form-card input[type="radio"].toggle.toggle-left + label:after {
        left: 100%;
    }

    .form-card input[type="radio"].toggle.toggle-right + label {
        margin-left: 18px;
    }

        .form-card input[type="radio"].toggle.toggle-right + label:after {
            left: -100%;
        }*/



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
                font-size: 18px;
                /*color: #32592b;*/
                color: #007fc3;
                float: right;
            }

            label.formdetailslbl {
                margin-top: 10px;
            }

            label.fieldlabels {
                margin-top: 10px;
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

            }
        </style>

        <style>
            .errlbl {
                font-size: 12px !important;
                position: absolute;
                bottom: 0;
                right: 15px;
            }

            .custom-file-upload {  
    padding: 16px 5px;    
}
        </style>

        <style>
            @media only screen and (min-width:1300px) and (max-width:1390px) {
                .steplist li::after {
                    border-top: 42px solid #ffde23;
                }

                .steplist li.active::after {
                    border-top: 42px solid #ffde23;
                }

                steplist li::before {
                    border-bottom: 42px solid #ffde23;
                }

                steplist li.active::before {
                    border-bottom: 42px solid #ffde23;
                }

                .steplist li:first-child::before {
                    border-bottom: 42px solid #007fc3;
                }

                .steplist li::before {
                    border-bottom: 42px solid #ffde23;
                }

                .steplist li:last-child::before {
                    border-bottom: 42px solid #f2f2f2;
                }

                .steplist li:first-child.active::before {
                    border-bottom: 42px solid #ffde23;
                }

                .steplist li:last-child.active::before {
                    border-bottom: 42px solid #ffde23;
                }
            }
        </style>

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


        <script>

            //$('#form1').keydown(function (event) {
            $(document).on('keydown', function (event) {


                if (event.keyCode == 10 || event.keyCode == 13) {

                    return false;

                }
            });

           <%--   $('#form1').keydown(function (event) {

                   
                  if (event.keyCode == 10 || event.keyCode == 13) {
                       
                      var vEmail_pop = false;
                       
                      if ($('#Check1').is(':checked')) {
                          $("#check1").css('border', 'none');

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
                    else {
                        $("#check1").css('border', '1px solid red');
                        return false;

                    }

                }

            });--%>

</script>

        <script>
            $("document").ready(function () {
                $("#ddlGeove").append("<option value='0'>المحافظة</option>");
                $("#ddlAreas").append("<option value='0'>المنطقة 1</option>");
                $("#ddlAreas2").append("<option value='0'>المنطقة 2</option>");
                $("#ddlsteet").append("<option value='0'>الشارع</option>");

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Default.aspx/BindGovernetData",
                    data: "{}",
                    success: function (result) {


                        console.log(result);
                        $("#ddlGeove").empty();
                        $("#ddlGeove").append("<option value='0'>المحافظة</option>");
                        $.each(result.d, function (key, value) {

                            $("#ddlGeove").append($("<option></option>").val(value.BranchID).html(value.desc1));

                        });


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
                            $("#ddlAreas").append("<option value='0'>المنطقة 1</option>");
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
                            $("#ddlAreas2").append("<option value='0'>المنطقة 2</option>");
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
                            $("#ddlsteet").append("<option value='0'>الشارع</option>");
                            $.each(result.d, function (key, value) {

                                $("#ddlsteet").append($("<option></option>").val(value.code).html(value.Desc1));

                            });


                        },
                        error: function (result) {
                            // alert(result.status + " : " + result.StatusText);
                        }
                    });

                });
            });


        </script>
    </form>
</body>
</html>
