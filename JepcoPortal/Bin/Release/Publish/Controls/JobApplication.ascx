<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JobApplication.ascx.cs" Inherits="Controls_JobApplication" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style>
    .addmore {
        padding-top: 35px;
    }

    .divremove {
        padding-top: 35px;
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
</style>
<style>
    .datepicker-dropdown.dropdown-menu {
        background: #fff !important;
    }
</style>
<%--<div class="about_page">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-xl-12 col-lg-12 col-md-12">
                <div id="msform">
                    <ul id="progressbar">
                        <li class="active" id="account">
                            <strong>معلومات شخصية</strong>
                            <p>معلومات شخصية</p>
                        </li>
                        <li id="personal">
                            <strong>المؤهل</strong>
                            <p>المؤهل</p>
                        </li>
                        <li id="payment">
                            <strong>خبرة سابقة</strong>
                            <p>خبرة سابقة</p>
                        </li>
                        <li id="contactd">
                            <strong>بيانات المتصل</strong>
                            <p>بيانات المتصل</p>
                        </li>
                       
                    </ul>
                    <br />
                   



                   

                    <br />
                </div>
            </div>
        </div>
    </div>
</div>--%>

<section class="step" id="msform">
    <div class="menuuu">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <label class="forminfolabelHead"><b>نموذج طلب توظيف</b></label>
            <label class="fieldlabels" style="font-weight: normal;">الرجاء تعبئة البيانات أدناه مع مراعاة دقة المعلومات</label>
        </div>
        <%-- <div class="container">--%>
        <div>
            <div class="col-md-12">

                <ul class="list-unstyled steplist" id="progressbar2" style="margin-bottom: 30px;">
                    <li class="active"><a href="javascript:void">الخطوة الاولى</a></li>
                    <li><a href="javascript:void">الخطوة الثانية</a></li>
                    <li><a href="javascript:void">الخطوة الثالثة</a></li>
                    <li><a href="javascript:void">الخطوة الرابعة</a></li>

                </ul>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">
            <fieldset>


                <div class="form-card">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="forminfolabel"><b>الوظيفة المقدم لها</b></label>
                        </div>
                    </div>
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" class="">
                            <ContentTemplate>

                                <div class="col-lg-6 col-md-6 col-sm-12">
                                    <div class="form-group">

                                        <label class="fieldlabels">نوع الوظيفة <span style="color: red">*</span></label>
                                        <asp:DropDownList ID="ddlJobType" runat="server" class="form-control" TabIndex="2" Width="100%" OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12">
                                    <div class="form-group">

                                        <label class="fieldlabels">اسم الوظيفة<span style="color: red">*</span></label>
                                        <asp:DropDownList ID="ddlJobName" runat="server" class="form-control" TabIndex="2" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="forminfolabel"><b>المعلومات الشخصية</b></label>
                        </div>
                    </div>
                    <div class="row">
                        <asp:HiddenField runat="server" ID="CaptchCodeSession" />
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">الاسم الأول<span style="color: red">*</span></label>
                                <asp:TextBox ID="txtfirstName" runat="server" PlaceHolder="الاسم الأول" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">الاسم الثاني</label>
                                <asp:TextBox ID="txtSecondName" runat="server" PlaceHolder="الاسم الثاني" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">الاسم الثالث</label>
                                <asp:TextBox ID="txtThirdName" runat="server" PlaceHolder="الاسم الثالث" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">الاسم الرابع<span style="color: red">*</span></label>
                                <asp:TextBox ID="txtLastName" runat="server" PlaceHolder="الكنية" class="form-control"></asp:TextBox>
                            </div>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">الرقم الوطني<span style="color: red">*</span></label>
                                <asp:TextBox ID="txtNationalID" runat="server" PlaceHolder="الهوية الوطنية" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">تاريخ الميلاد<span style="color: red">*</span></label>
                                <input id="txtDateOfBirth" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">الحالة الاجتماعية<span style="color: red">*</span></label>
                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" class="form-control" TabIndex="2" Width="100%">
                                    <asp:ListItem Value="0">الرجاء اختيار الحالة الاجتماعية</asp:ListItem>
                                    <asp:ListItem Value="1">متزوج</asp:ListItem>
                                    <asp:ListItem Value="2">اعزب</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">عدد الأولاد</label>
                                <asp:TextBox ID="txtNumberofChild" runat="server" PlaceHolder="عدد الأولاد" class="form-control mobileNo"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">هل تمتلك رخصة قيادة ؟</label>
                                <asp:RadioButtonList runat="server" ID="rblLisence" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="نعم" Value="True"></asp:ListItem>
                                    <asp:ListItem Text="لا" Value="False" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                    </div>

                    <div id="LicenceDetials">
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <div class="form-group">

                                    <label class="fieldlabels">فئة الرخصه<span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlLisenceType" runat="server" class="form-control" TabIndex="2" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label class="fieldlabels">سنة الحصول على رخصة القياده</label>
                                    <%-- <asp:DropDownList ID="ddlYearofLisence" runat="server" class="form-control" TabIndex="2" Width="100%">
                                        </asp:DropDownList>--%>
                                    <input id="txtLicenceYear" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                </div>
                            </div>


                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">المؤهل<span style="color: red">*</span></label>
                                <asp:DropDownList ID="ddlQualification" runat="server" class="form-control" TabIndex="2" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>

                    <br />
                    <div class="clearfix"></div>
                </div>
                <input type="button" name="next" class="next action-button" value="التالي" />


            </fieldset>

            <fieldset>
                <div class="form-card">

                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="forminfolabel"><b>المؤهل</b></label>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" class="">

                        <ContentTemplate>


                            <div id="firstop" style="display: none">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">اسم الجامعة<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtUniName" runat="server" PlaceHolder="اسم الجامعة" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">سنة الحصول على المؤهل العلمي<span style="color: red">*</span></label>
                                            <input id="ddlPassingYear" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                            <%-- <asp:DropDownList ID="ddlPassingYear" runat="server" class="form-control" TabIndex="2" Width="100%">
                                                        <asp:ListItem Value="0">Select Item</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">لتخصص<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtMajor" runat="server" PlaceHolder="لتخصص" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">المعدل</label>
                                            <asp:TextBox ID="txtAverage" runat="server" PlaceHolder="المعدل" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">التقدير الجامعي<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtOverallEval" runat="server" PlaceHolder="التقدير الجامعي" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="secondop" style="display: none">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">اسم الكلية<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtUniName2" runat="server" PlaceHolder="اسم الكلية" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">سنة الحصول على المؤهل العلمي<span style="color: red">*</span></label>
                                            <input id="ddlYear2" runat="server" type="text" placeholder="mm/dd/yyyy" name="date" class="Dateeee form-control" />
                                            <%-- <asp:DropDownList ID="ddlYear2" runat="server" class="form-control" TabIndex="2" Width="100%">
                                                        <asp:ListItem Value="0">Select Item</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">التخصص<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtMajor2" runat="server" PlaceHolder="التخصص" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">معدل الشامل<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtAverage2" runat="server" PlaceHolder="معدل الشامل" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="thirdop" style="display: none">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">سنة الحصول على المؤهل العلمي<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtYear3" runat="server" PlaceHolder="سنة الحصول على المؤهل العلمي" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">التخصص<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtMajor3" runat="server" PlaceHolder="التخصص" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">معدل الثانوبة<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtAverage3" runat="server" PlaceHolder="معدل الثانوبة" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="fourthop" style="display: none">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">سنة الحصول على المؤهل الفني<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtYear4" runat="server" PlaceHolder="سنة الحصول على المؤهل الفني" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">المؤهل الفني<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtMajor4" runat="server" PlaceHolder="المؤهل الفني" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">التخصص<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtMajor24" runat="server" PlaceHolder="التخصص" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <div class="form-group">
                                            <label class="fieldlabels">الجهه المانحه للمؤهل الفني<span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtMajorFrom" runat="server" PlaceHolder="الجهه المانحه للمؤهل الفني" class="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <input type="button" name="next" class="next action-button" value="التالي" />
                <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
            </fieldset>

            <fieldset>

                <div class="form-card">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="forminfolabel"><b>الخبرات السابقة</b></label>
                        </div>
                    </div>
                    <div class="row">
                        <asp:HiddenField runat="server" ID="hdWorkExpCount" ClientIDMode="Static" />
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">الجهه</label>
                                <input type="text" id="txtEntityName_1" name="txtEntityName_1" class="form-control" placeholder="الجهه">
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">نوع الخبره</label>
                                <input type="text" id="txtExperienceType_1" name="txtExperienceType_1" class="form-control" placeholder="نوع الخبره">
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">عدد سنوات الخبره</label>
                                <input type="text" id="txtNumberofYears_1" name="txtNumberofYears_1" class="form-control mobileNo" placeholder="عدد سنوات الخبره">
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 addmore">
                            <div class="form-group ">
                                <a href="javascript:void" class="Add_More btn action-button" onclick="GetNewRowWorkExp();"><i class="fa fa-plus "></i>&nbsp; إضافة مزيد</a>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="dynamicRow_Experience">
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="forminfolabel"><b>الدورات التدريبيه</b></label>
                        </div>
                    </div>
                    <div class="row">
                        <asp:HiddenField runat="server" ID="hdntrainigCourse" ClientIDMode="Static" />
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">نوع الدوره التدريبيه</label>
                                <input type="text" id="txtCourseType_1" name="txtCourseType_1" class="form-control" placeholder="نوع الدوره التدريبيه">
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">اسم الدوره التدريبيه</label>
                                <input type="text" id="txtCourseName_1" name="txtCourseName_1" class="form-control" placeholder="اسم الدوره التدريبيه">
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">مدة الدوره التدريبيه</label>
                                <input type="text" id="txtCourseDuration_1" name="txtCourseDuration_1" class="form-control" placeholder="مدة الدوره التدريبيه">
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12 addmore">
                            <div class="form-group">
                                <a href="javascript:void" class="Add_More btn action-button" onclick="GetNewRowTraining();"><i class="fa fa-plus "></i>&nbsp; إضافة مزيد</a>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div id="dynamicRow_Training">
                    </div>
                    <br />
                </div>
                <input type="button" name="next" class="next action-button" value="التالي" />
                <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
            </fieldset>

            <fieldset>

                <div class="form-card">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="forminfolabel"><b>المحافظه</b></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">المحافظة</label>
                                <asp:DropDownList ID="ddlProvenance" runat="server" class="form-control" TabIndex="2" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">المنطقه</label>
                                <asp:DropDownList ID="ddlArea" runat="server" class="form-control" TabIndex="2" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">الحي</label>
                                <asp:DropDownList ID="ddlArea2" runat="server" class="form-control" TabIndex="2" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">الشارع</label>
                                <asp:TextBox ID="txtStreet" runat="server" PlaceHolder="الشارع" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">رقم العمارة</label>
                                <asp:TextBox ID="txtBuildingNo" runat="server" PlaceHolder="رقم العمارة" class="form-control mobileNo"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">تلفون 1</label>
                                <asp:TextBox ID="txtTel1" runat="server" PlaceHolder="تلفون 1" class="form-control mobileNo"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">
                                <label class="fieldlabels">تلفون 2</label>
                                <asp:TextBox ID="txtTel2" runat="server" PlaceHolder="تلفون 2" class="form-control mobileNo"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="form-group">

                                <label class="fieldlabels">البريد الالكتروني</label>
                                <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="البريد الالكتروني" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">

                            <label class="fieldlabels">السيرة الذاتية</label>
                            <label for="fileuploadfield_1" class="custom-file-upload fieldlabels">
                                اختيار الملف
                            </label>
                            <input id="fileuploadfield_1" name="fileuploadfield_1" type="file" class="demoInputBox" />
                            <span class="file-select">No file selected</span>
                            <span id="file_error" style="color: red"></span>
                            <br />
                            <span class="fieldlabels">الرجاء تحميل السيرة الذاتية بنوع doc  أو docx  أو pdf  وبحجم أقصى 2 ميجابايت</span>
                        </div>
                    </div>

                    <div class="form-card">
                        <div class="row">
                            <table>
                                <tr>
                                    <td style="height: 50px; width: 100px;">
                                        <asp:Image ID="imgCaptcha" runat="server" />
                                    </td>

                                </tr>
                            </table>

                            <asp:TextBox ID="txtCaptcha" runat="server" Width="200px" PlaceHolder="Enter Captcha" CssClass="form-control" style="font-family:Poppins, sans-serif;"></asp:TextBox>
                            <asp:Label ID="CaptchaErrorLabel" runat="server" ForeColor="Red" />
                        </div>
                    </div>


                    <br />
                    <div class="clearfix"></div>
                </div>
                <button class="btn action-button" type="button" id="btbvalid" onclick="SendClick();">ارسال الطلب</button>
                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" type="button" Style="display: none;" runat="server" Text="Button" />
                <%--<input type="button" name="next" class="next action-button" value="Next" />--%>
                <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
            </fieldset>
        </div>

    </div>
    <%-- </div>--%>
</section>



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


                <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" ID="btnClose">&times;</asp:LinkButton>
                <h4 class="modal-title" id="myModalLabel">
                    <asp:Literal runat="server" ID="lblInquiryTitle" Text="م الاستلام بنجاح "></asp:Literal></h4>
            </div>
            <div class="modal-body">

                <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                    <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/logo.png" />

                    <p>
                        <asp:Literal runat="server" ID="lblInquiryMessage" Text="لقد تم استلام رسالتك بنجاح. شكرا لكم">                             
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

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function SendClick() {
        var qualificationVal = $("#<%=ddlQualification.ClientID%>").val();
        debugger;
        if (qualificationVal == "7") {
            var ValCaptcha = false;
            var FEmail_S2 = false;
            var FileUpload = false;
            var Provenance = false;
            var Area1 = false;
            var TelephoneNumber1 = false;
            var TelephoneNumber2 = false;

            if ($('#<%= txtEmail.ClientID %>').val().trim() != '') {
                $('#<%= txtEmail.ClientID %>').css('border', 'none');
                 if ($('#<%= txtEmail.ClientID %>').val().trim() != "") {
                     var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                     if (!regex.test($('#<%= txtEmail.ClientID %>').val())) {
                    $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

                }
                else {
                    $('#<%= txtEmail.ClientID %>').css('border', 'none');
                         FEmail_S2 = true;
                     }
                 }
                 else {
                     $("#txtEmail").css('border', '1px solid red');

                 }
             }
             else {
                 $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

            }


            if ($('#<%= txtCaptcha.ClientID %>').val().trim() != "") {


                if ($('#<%= txtCaptcha.ClientID %>').val().trim() == $('#<%= CaptchCodeSession.ClientID %>').val()) {
                    $('#<%= txtCaptcha.ClientID %>').css('border', 'none');
                    ValCaptcha = true;
                }
                else {

                    $('#<%= CaptchaErrorLabel.ClientID %>').val("Invalid Captcha Code");
                    $('#<%= CaptchaErrorLabel.ClientID %>').visible = true;
                    $('#<%= txtCaptcha.ClientID %>').css('border', '1px solid red');
                    //altertString = altertString + '<p>' + "Invalid Captcha" + '</p>';
                }

            }
            else {
                $('#<%= txtCaptcha.ClientID %>').css('border', '1px solid red');
                //altertString = altertString + '<p>' + "Invalid Captcha" + '</p>';
            }


            var inp = document.getElementById('fileuploadfield_1');
            if (inp.files.length === 0) {
                $("#file_error").html("Please Select File");
                inp.focus();
                FileUpload = false;
                //return false;
                //FileUpload = true;
            }
            else {
                $("#file_error").html("");
                $(".demoInputBox").css("border-color", "#F0F0F0");
                var file_size = $('#fileuploadfield_1')[0].files[0].size;
                if (file_size > 2097152) {
                    $("#file_error").html("File size is greater than 2MB");
                    $(".demoInputBox").css("border-color", "#f00");

                }
                else {
                    FileUpload = true;
                }
            }


           

            if ($('#<%= ddlProvenance.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlProvenance.ClientID %>').css('border', '1px solid red');
              }
              else {
                  $('#<%= ddlProvenance.ClientID %>').css('border', 'none');
                Provenance = true;
            }

            if ($('#<%= ddlArea.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlArea.ClientID %>').css('border', '1px solid red');
            }
            else {
                $('#<%= ddlArea.ClientID %>').css('border', 'none');
                Area1 = true;
            }

            if ($('#<%= txtTel1.ClientID %>').val().trim() != '') {

                $('#<%= txtTel1.ClientID %>').css('border', 'none');
                TelephoneNumber1 = true;
             }
             else {

                 $('#<%= txtTel1.ClientID %>').css('border', '1px solid red');
            }

            if ($('#<%= txtTel2.ClientID %>').val().trim() != '') {

                $('#<%= txtTel2.ClientID %>').css('border', 'none');
                TelephoneNumber2 = true;
             }
             else {

                 $('#<%= txtTel2.ClientID %>').css('border', '1px solid red');
             }

            if (ValCaptcha == true && FEmail_S2 == true && FileUpload == true && Provenance == true && Area1 == true && TelephoneNumber1 == true && TelephoneNumber2 == true) {
                $("[id*=<%=btnSubmit.ClientID %>]").click();
              }

        }
        else {
            var ValCaptcha = false;
            var FEmail_S2 = false;
            var FileUpload = false;

            if ($('#<%= txtEmail.ClientID %>').val().trim() != '') {
                $('#<%= txtEmail.ClientID %>').css('border', 'none');
            if ($('#<%= txtEmail.ClientID %>').val().trim() != "") {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                if (!regex.test($('#<%= txtEmail.ClientID %>').val())) {
                    $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

                }
                else {
                    $('#<%= txtEmail.ClientID %>').css('border', 'none');
                    FEmail_S2 = true;
                }
            }
            else {
                $("#txtEmail").css('border', '1px solid red');

            }
        }
            else {
            $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

            }


            if ($('#<%= txtCaptcha.ClientID %>').val().trim() != "") {


                if ($('#<%= txtCaptcha.ClientID %>').val().trim() == $('#<%= CaptchCodeSession.ClientID %>').val()) {
                $('#<%= txtCaptcha.ClientID %>').css('border', 'none');
                ValCaptcha = true;
            }
            else {

                $('#<%= CaptchaErrorLabel.ClientID %>').val("Invalid Captcha Code");
                $('#<%= CaptchaErrorLabel.ClientID %>').visible = true;
                $('#<%= txtCaptcha.ClientID %>').css('border', '1px solid red');
                //altertString = altertString + '<p>' + "Invalid Captcha" + '</p>';
            }

        }
            else {
            $('#<%= txtCaptcha.ClientID %>').css('border', '1px solid red');
                //altertString = altertString + '<p>' + "Invalid Captcha" + '</p>';
            }


            var inp = document.getElementById('fileuploadfield_1');
            if (inp.files.length === 0) {
                //$("#file_error").html("Please Select File");
                //inp.focus();

                //return false;
                FileUpload = true;
            }
            else {
                $("#file_error").html("");
                $(".demoInputBox").css("border-color", "#F0F0F0");
                var file_size = $('#fileuploadfield_1')[0].files[0].size;
                if (file_size > 2097152) {
                    $("#file_error").html("File size is greater than 2MB");
                    $(".demoInputBox").css("border-color", "#f00");

                }
                else {
                    FileUpload = true;
                }
            }

            if (ValCaptcha == true && FEmail_S2 == true && FileUpload == true) {
                $("[id*=<%=btnSubmit.ClientID %>]").click();
        }
        }

        

       
    }
</script>

<script type='text/javascript'>
    var arrayVal = [1];
    var firstrow = 2;
    function GetNewRowWorkExp() {

        var addDiv2 = '<div class="row" id="divWorkExp_' + firstrow + '">' +
            '<div class="col-lg-3 col-md-3 col-sm-12">' +
            '<div class="form-group">' +
            '<label class="fieldlabels">الجهه</label>' +
            '<input type="text" id="txtEntityName_' + firstrow + '" name="txtEntityName_' + firstrow + '" class="form-control" placeholder="الجهه">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-12">' +
            '<div class="form-group">' +
            '<label class="fieldlabels">نوع الخبره</label>' +
            '<input type="text" id="txtExperienceType_' + firstrow + '" name="txtExperienceType_' + firstrow + '" class="form-control" placeholder="نوع الخبره">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-12">' +
            '<div class="form-group">' +
            '<label class="fieldlabels">عدد سنوات الخبره</label>' +
            '<input type="text" id="txtNumberofYears_' + firstrow + '" name="txtNumberofYears_' + firstrow + '" class="form-control mobileNo" placeholder="عدد سنوات الخبره">' +
            '</div>' +
            '</div>' +

            ' <div class="col-lg-3 col-md-3 col-sm-12 divremove">' +
            '<div class="form-group">' +
            '<a href="javascript:void" class="remove_document btn action-button" onclick="RemoveWorkExp(' + firstrow + ')"><i class="fa fa-Remove"></i> إزالة</a>' +
            '</div>' +
            '</div>' +

            '</div>';

        $("#dynamicRow_Experience").append(addDiv2);
        debugger;
        arrayVal.push(firstrow);

        firstrow = firstrow + 1;


        $("#<%=hdWorkExpCount.ClientID%>").val(firstrow.toString());

    }

    function RemoveWorkExp(a) {

        var itemId = "divWorkExp_" + a;
        $("#" + itemId).remove();
        debugger;
        removeItem(arrayVal, a);
    }

    //function removeItem(array, item) {
    //    debugger;
    //    for (var i in array) {
    //        if (array[i] == item) {
    //            array.splice(i, 1);
    //            break;
    //        }
    //    }
    //}

    var firstrowTraining = 2;
    var arrayVal2 = [1];

    function GetNewRowTraining() {

        var addDivTraining = '<div class="row" id="divTraining_' + firstrowTraining + '">' +
            '<div class="col-lg-3 col-md-3 col-sm-12">' +
            '<div class="form-group">' +
            '<label class="fieldlabels">نوع الدوره التدريبيه</label>' +
            '<input type="text" id="txtCourseType_' + firstrowTraining + '" name="txtCourseType_' + firstrowTraining + '" class="form-control" placeholder="نوع الدوره التدريبيه">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-12">' +
            '<div class="form-group">' +
            '<label class="fieldlabels">اسم الدوره التدريبيه</label>' +
            '<input type="text" id="txtCourseName_' + firstrowTraining + '" name="txtCourseName_' + firstrowTraining + '" class="form-control" placeholder="اسم الدوره التدريبيه">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-12">' +
            '<div class="form-group">' +
            '<label class="fieldlabels">العنوان</label>' +
            '<input type="text" id="txtCourseDuration_' + firstrowTraining + '" name="txtCourseDuration_' + firstrowTraining + '" class="form-control" placeholder="العنوان">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-12 divremove">' +
            '<div class="form-group">' +
            '<a href="javascript:void" class="remove_document btn action-button" onclick="RemoveTraining(' + firstrowTraining + ')"><i class="fa fa-Remove"></i> إزالة</a>' +
            '</div>' +
            '</div>' +

            '</div>';

        $("#dynamicRow_Training").append(addDivTraining);
        debugger;
        arrayVal2.push(firstrowTraining);

        firstrowTraining = firstrowTraining + 1;


        $("#<%=hdntrainigCourse.ClientID%>").val(firstrowTraining.toString());

    }

    function RemoveTraining(a) {

        var itemId = "divTraining_" + a;
        $("#" + itemId).remove();
        debugger;
        removeItem(arrayVal2, a);
    }

    function removeItem(array, item) {
        debugger;
        for (var i in array) {
            if (array[i] == item) {
                array.splice(i, 1);
                break;
            }
        }
    }

</script>

<style>
    td, th {
        padding: 0 20px;
        min-width: 30px;
    }

    .modal-dialog .d_model_btn {
        background: #007fc3;
        color: #fff;
        font-size: 24px;
        font-weight: bold;
        border: none;
        width: 100%;
        max-width: 200px;
        line-height: 60px;
    }

    .table-condensed thead {
        background: #007fc3;
        color: #fff;
    }

    .datepicker-switch {
        text-align: center;
    }

    .next {
        text-align: left;
    }
</style>

<script type="text/javascript">
    $(document).ready(function () {
        jQuery(".Dateeee").datepicker();

    });
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

<script type="text/javascript">
    $("document").ready(function () {

        $('input[type=file]').change(function (e) {
            debugger;


            $in = $(this);
            var abcd2 = "";
            $in.next().html(abcd2);
            //Chack FileType 
            debugger;
            var fileInput =
                document.getElementById('fileuploadfield_1');

            var filePath = fileInput.value;

            // Allowing file type 
            var allowedExtensions =
                /(\.PDF|\.doc|\.docx)$/i;
            //PDF, doc, and docx.

            if (!allowedExtensions.exec(filePath)) {

                $("#file_error").html("Invalid file type");
                fileInput.value = '';
                return false;
            }
            else {
                $in = $(this);
                var abcd = $in[0].files[0].name;
                $in.next().html(abcd);
                // Image preview 

            }

        });

        $("#firstop").css("display", "");
        $("#<%=ddlQualification.ClientID%>").change(function () {
            debugger;
            var a = $("#<%=ddlQualification.ClientID%>").val();
            if (a == "7") {
                $("#firstop").css("display", "none");
                $("#secondop").css("display", "none");
                $("#thirdop").css("display", "none");
                $("#fourthop").css("display", "");

            }
            else if (a == "4") {
                debugger;
                $("#firstop").css("display", "none");
                $("#secondop").css("display", "");
                $("#thirdop").css("display", "none");
                $("#fourthop").css("display", "none");


            }
            else if (a == "5") {
                $("#firstop").css("display", "none");
                $("#secondop").css("display", "none");
                $("#thirdop").css("display", "");
                $("#fourthop").css("display", "none");
            }
            else {
                $("#firstop").css("display", "");
                $("#secondop").css("display", "none");
                $("#thirdop").css("display", "none");
                $("#fourthop").css("display", "none");
            }
        });

        $(function () {
            //Reference the DropDownList.
            var ddlYears = $("#ContentPlaceHolder1_ctl00_ddlPassingYear");
            var ddlYears2 = $("#ContentPlaceHolder1_ctl00_ddlYear2");


            //Determine the Current Year.
            var currentYear = (new Date()).getFullYear();

            //Loop and add the Year values to DropDownList.
            for (var i = 1991; i <= currentYear; i++) {
                var option = $("<option />");
                option.html(i);
                option.val(i);
                ddlYears.append(option);

            }

            for (var i = 1991; i <= currentYear; i++) {
                var option = $("<option />");
                option.html(i);
                option.val(i);

                ddlYears2.append(option);
            }
        });

        $('#LicenceDetials').hide();
        $("[id*=<%=rblLisence.ClientID %>]").change(function () {

            if ($(this).val() == 'False') {
                $('#LicenceDetials').hide();
            }
            else {
                $('#LicenceDetials').show();
            }
            return false;
        });



        $('#<%=rblLisence.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblLisence.ClientID  %>_1').addClass("toggle toggle-right");


        $('#<%=rblLisence.ClientID  %>_0').next('label').addClass("btn");
        $('#<%=rblLisence.ClientID  %>_1').next('label').addClass("btn");

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

            //if (current == 3) {
            //    debugger;
            //    step3validResult = false;
            //    step3Valid();
            //    if (step3validResult == true) {
            //    }
            //    else {
            //        return false;
            //    }
            //}

            //if (current == 4) {
            //    debugger;
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

        $(".submit").click(function () {
            return false;
        })


        function step1Valid() {
            var ValJobType = false;
            var ValJobName = false;
            var ValFirstName = false;
            var ValSecondName = false;
            var ValThirdName = false;
            var ValLastName = false;
            var ValNationalID = false;
            var ValBirthDate = false;
            var ValMaritalStatus = false;
            var ValChildNumber = false;
            var ValLicenceYearDate = false;
            var ValQualification = false;


            if ($('#<%= ddlJobType.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlJobType.ClientID %>').css('border', '1px solid red');
            }
            else {
                $('#<%= ddlJobType.ClientID %>').css('border', 'none');
                ValJobType = true;
            }

            if ($('#<%= ddlJobName.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlJobName.ClientID %>').css('border', '1px solid red');
            }
            else {

                $('#<%= ddlJobName.ClientID %>').css('border', 'none');
                ValJobName = true;
            }

            if ($('#<%= txtfirstName.ClientID %>').val().trim() != '') {

                $('#<%= txtfirstName.ClientID %>').css('border', 'none');
                ValFirstName = true;
            }
            else {

                $('#<%= txtfirstName.ClientID %>').css('border', '1px solid red');
            }

           <%-- if ($('#<%= txtSecondName.ClientID %>').val().trim() != '') {

                $('#<%= txtSecondName.ClientID %>').css('border', 'none');
                ValSecondName = true;
            }
            else {

                $('#<%= txtSecondName.ClientID %>').css('border', '1px solid red');
            }--%>

          <%--  if ($('#<%= txtThirdName.ClientID %>').val().trim() != '') {

                $('#<%= txtThirdName.ClientID %>').css('border', 'none');
                ValThirdName = true;
            }
            else {

                $('#<%= txtThirdName.ClientID %>').css('border', '1px solid red');
            }--%>

            if ($('#<%= txtLastName.ClientID %>').val().trim() != '') {

                $('#<%= txtLastName.ClientID %>').css('border', 'none');
                ValLastName = true;
            }
            else {

                $('#<%= txtLastName.ClientID %>').css('border', '1px solid red');
            }

            if ($('#<%= txtNationalID.ClientID %>').val().trim() != '') {

                $('#<%= txtNationalID.ClientID %>').css('border', 'none');
                ValNationalID = true;
            }
            else {

                $('#<%= txtNationalID.ClientID %>').css('border', '1px solid red');
            }

            if ($('#<%= txtDateOfBirth.ClientID %>').val().trim() != '') {

                if ($('#<%= txtDateOfBirth.ClientID %>').val().trim() != "") {

                    var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                    if (!regex.test($('#<%= txtDateOfBirth.ClientID %>').val())) {
                        $('#<%= txtDateOfBirth.ClientID %>').css('border', '1px solid red');

                    } else {
                        $('#<%= txtDateOfBirth.ClientID %>').css('border', 'none');
                        ValBirthDate = true;
                    }
                }
                else {
                    $('#<%= txtDateOfBirth.ClientID %>').css('border', '1px solid red');
                }
            }
            else {
                $('#<%= txtDateOfBirth.ClientID %>').css('border', '1px solid red');
            }

            if ($('#<%= ddlMaritalStatus.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlMaritalStatus.ClientID %>').css('border', '1px solid red');
            }
            else {

                $('#<%= ddlMaritalStatus.ClientID %>').css('border', 'none');
                ValMaritalStatus = true;
            }

            var checked_radiorblAnyOtherSchool = $("[id*=rblLisence] input:checked");
            var valuerblAnyOtherSchool = checked_radiorblAnyOtherSchool.val();
            if (valuerblAnyOtherSchool == 'True') {
                if ($('#<%= txtLicenceYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= txtLicenceYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= txtLicenceYear.ClientID %>').val())) {
                            $('#<%= txtLicenceYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= txtLicenceYear.ClientID %>').css('border', 'none');
                            ValLicenceYearDate = true;
                        }
                    }
                    else {
                        $('#<%= txtLicenceYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= txtLicenceYear.ClientID %>').css('border', '1px solid red');
                }
            }
            else {
                ValLicenceYearDate = true;
            }


            if ($('#<%= ddlQualification.ClientID %> option:selected').val() == "0") {

                $('#<%= ddlQualification.ClientID %>').css('border', '1px solid red');
            }
            else {
                $('#<%= ddlQualification.ClientID %>').css('border', 'none');
                ValQualification = true;
            }


            debugger;
            //ValSecondName == true &&
            //ValThirdName == true &&
            if (ValJobType == true &&
                ValJobName == true &&
                ValFirstName == true &&
                ValMaritalStatus == true &&

                ValLastName == true &&
                ValNationalID == true &&
                ValBirthDate == true &&
                ValLicenceYearDate == true &&
                ValQualification == true
            ) {
                debugger;
                step1validResult = true;
            }
            else {

                step1validResult = false;
            }
        }

        function step2Valid() {


            var qualificationVal = $("#<%=ddlQualification.ClientID%>").val();
            debugger;
            if (qualificationVal == "1") {
                var ValddlPassingYear = false;
                var ValUniName = false;
                var ValMajorName = false;
                var ValOverallEval = false;



                if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlPassingYear.ClientID %>').val())) {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName.ClientID %>').css('border', 'none');
                    ValUniName = true;
                }
                else {

                    $('#<%= txtUniName.ClientID %>').css('border', '1px solid red');
                }


                if ($('#<%= txtMajor.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor.ClientID %>').css('border', 'none');
                    ValMajorName = true;
                }
                else {

                    $('#<%= txtMajor.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtOverallEval.ClientID %>').val().trim() != '') {

                    $('#<%= txtOverallEval.ClientID %>').css('border', 'none');
                    ValOverallEval = true;
                }
                else {

                    $('#<%= txtOverallEval.ClientID %>').css('border', '1px solid red');
                }


                if (ValddlPassingYear == true &&
                    ValUniName == true &&
                    ValMajorName == true &&
                    ValOverallEval == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }

            }

            else if (qualificationVal == "2") {
                var ValddlPassingYear = false;
                var ValUniName = false;
                var ValMajorName = false;
                var ValOverallEval = false;

                if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlPassingYear.ClientID %>').val())) {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName.ClientID %>').css('border', 'none');
                    ValUniName = true;
                }
                else {

                    $('#<%= txtUniName.ClientID %>').css('border', '1px solid red');
                }


                if ($('#<%= txtMajor.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor.ClientID %>').css('border', 'none');
                    ValMajorName = true;
                }
                else {

                    $('#<%= txtMajor.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtOverallEval.ClientID %>').val().trim() != '') {

                    $('#<%= txtOverallEval.ClientID %>').css('border', 'none');
                    ValOverallEval = true;
                }
                else {

                    $('#<%= txtOverallEval.ClientID %>').css('border', '1px solid red');
                }



                if (ValddlPassingYear == true &&
                    ValUniName == true &&
                ValMajorName == true &&
                ValOverallEval == true 
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }
            else if (qualificationVal == "3") {
                var ValddlPassingYear = false;
                var ValUniName = false;
                var ValMajorName = false;
                var ValOverallEval = false;

                if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlPassingYear.ClientID %>').val())) {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName.ClientID %>').css('border', 'none');
                     ValUniName = true;
                 }
                 else {

                     $('#<%= txtUniName.ClientID %>').css('border', '1px solid red');
                }


                if ($('#<%= txtMajor.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor.ClientID %>').css('border', 'none');
                    ValMajorName = true;
                }
                else {

                    $('#<%= txtMajor.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtOverallEval.ClientID %>').val().trim() != '') {

                    $('#<%= txtOverallEval.ClientID %>').css('border', 'none');
                    ValOverallEval = true;
                }
                else {

                    $('#<%= txtOverallEval.ClientID %>').css('border', '1px solid red');
                }

                if (ValddlPassingYear == true &&
                    ValUniName == true &&
                    ValMajorName == true &&
                    ValOverallEval == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }
            else if (qualificationVal == "4") {
                var ValddlPassingYear = false;
                var VarUniName2 = false;
                var VarMajor2 = false;
                var VarAverage2 = false;
                if ($('#<%= ddlYear2.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlYear2.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlYear2.ClientID %>').val())) {
                            $('#<%= ddlYear2.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlYear2.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlYear2.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlYear2.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName2.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName2.ClientID %>').css('border', 'none');
                    VarUniName2 = true;
                 }
                 else {

                     $('#<%= txtUniName2.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajor2.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor2.ClientID %>').css('border', 'none');
                    VarMajor2 = true;
                }
                else {

                    $('#<%= txtMajor2.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtAverage2.ClientID %>').val().trim() != '') {

                    $('#<%= txtAverage2.ClientID %>').css('border', 'none');
                    VarAverage2 = true;
                }
                else {

                    $('#<%= txtAverage2.ClientID %>').css('border', '1px solid red');
                }

                

                if (ValddlPassingYear == true &&
                    VarUniName2 == true &&
                VarMajor2 == true &&
                VarAverage2 == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }
            else if (qualificationVal == "5") {
                var VarYear3 = false;
                var VarMajor3 = false;
                var VarAverage3 = false;

                if ($('#<%= txtYear3.ClientID %>').val().trim() != '') {

                    $('#<%= txtYear3.ClientID %>').css('border', 'none');
                    VarYear3 = true;
                 }
                 else {

                     $('#<%= txtYear3.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajor3.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor3.ClientID %>').css('border', 'none');
                    VarMajor3 = true;
                 }
                 else {

                     $('#<%= txtMajor3.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtAverage3.ClientID %>').val().trim() != '') {

                    $('#<%= txtAverage3.ClientID %>').css('border', 'none');
                    VarAverage3 = true;
                 }
                 else {

                     $('#<%= txtAverage3.ClientID %>').css('border', '1px solid red');
                 }

                if (VarYear3 == true &&
                    VarMajor3 == true &&
                    VarAverage3 == true 
                    
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }


            else {
                
                var VarMajor4 = false;
                var VarMajor24 = false;
                var VarMajorFrom = false;
                var varYear4 = false;
                

                if ($('#<%= txtYear4.ClientID %>').val().trim() != '') {

                    $('#<%= txtYear4.ClientID %>').css('border', 'none');
                    varYear4 = true;
                 }
                 else {

                     $('#<%= txtYear4.ClientID %>').css('border', '1px solid red');
                 }



                if ($('#<%= txtMajor4.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor4.ClientID %>').css('border', 'none');
                    VarMajor4 = true;
                 }
                 else {

                     $('#<%= txtMajor4.ClientID %>').css('border', '1px solid red');
                 }

                if ($('#<%= txtMajor24.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor24.ClientID %>').css('border', 'none');
                    VarMajor24 = true;
                }
                else {

                    $('#<%= txtMajor24.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajorFrom.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajorFrom.ClientID %>').css('border', 'none');
                    VarMajorFrom = true;
                  }
                  else {

                      $('#<%= txtMajorFrom.ClientID %>').css('border', '1px solid red');
                  }
                
                if (VarMajor4 == true &&
                    VarMajor24 == true &&
                    VarMajorFrom == true &&
                    varYear4 == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }


                //step2validResult = true;
            }


        }


    });
</script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>

<script>

    $(document).on('focus', ".datepicker_recurring_start", function () {
        $(".Dateeee").datepicker();
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
        text-align: center;
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

<script>
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {


        $(document).ready(function () {
            jQuery(".Dateeee").datepicker();

        });

       <%-- function SendClick() {
            debugger;
            var ValCaptcha = false;
            var FEmail_S2 = false;
            var FileUpload = false;

            if ($('#<%= txtEmail.ClientID %>').val().trim() != '') {
                $('#<%= txtEmail.ClientID %>').css('border', 'none');
                if ($('#<%= txtEmail.ClientID %>').val().trim() != "") {
                    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                    if (!regex.test($('#<%= txtEmail.ClientID %>').val())) {
                        $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

                    }
                    else {
                        $('#<%= txtEmail.ClientID %>').css('border', 'none');
                        FEmail_S2 = true;
                    }
                }
                else {
                    $("#txtEmail").css('border', '1px solid red');

                }
            }
            else {
                $('#<%= txtEmail.ClientID %>').css('border', '1px solid red');

            }



            if ($('#<%= txtCaptcha.ClientID %>').val().trim() != "") {


                if ($('#<%= txtCaptcha.ClientID %>').val().trim() == $('#<%= CaptchCodeSession.ClientID %>').val()) {
                    $('#<%= txtCaptcha.ClientID %>').css('border', 'none');
                    ValCaptcha = true;
                }
                else {

                    $('#<%= CaptchaErrorLabel.ClientID %>').val("Invalid Captcha Code");
                    $('#<%= CaptchaErrorLabel.ClientID %>').visible = true;
                    $('#<%= txtCaptcha.ClientID %>').css('border', '1px solid red');
                    //altertString = altertString + '<p>' + "Invalid Captcha" + '</p>';
                }

            }
            else {
                $('#<%= txtCaptcha.ClientID %>').css('border', '1px solid red');
                //altertString = altertString + '<p>' + "Invalid Captcha" + '</p>';
            }

            debugger;
          

            $("#file_error").html("");
            $(".demoInputBox").css("border-color", "#F0F0F0");
            var file_size = $('#fileuploadfield_1')[0].files[0].size;
            if (file_size > 2097152) {
                $("#file_error").html("File size is greater than 2MB");
                $(".demoInputBox").css("border-color", "#f00");
                return false;
            }
            else {
                FileUpload = true;
            }

            if (ValCaptcha == true && FEmail_S2 == true && FileUpload == true) {
                $("[id*=<%=btnSubmit.ClientID %>]").click();
            }
        }--%>

        var arrayVal = [1];
        var firstrow = 2;
        function GetNewRowWorkExp() {

            var addDiv2 = '<div class="row" id="divWorkExp_' + firstrow + '">' +
                '<div class="col-lg-3 col-md-3 col-sm-12">' +
                '<div class="form-group">' +
                '<label class="fieldlabels">الجهه</label>' +
                '<input type="text" id="txtEntityName_' + firstrow + '" name="txtEntityName_' + firstrow + '" class="form-control" placeholder="الجهه">' +
                '</div>' +
                '</div>' +
                '<div class="col-lg-3 col-md-3 col-sm-12">' +
                '<div class="form-group">' +
                '<label class="fieldlabels">نوع الخبره</label>' +
                '<input type="text" id="txtExperienceType_' + firstrow + '" name="txtExperienceType_' + firstrow + '" class="form-control" placeholder="نوع الخبره">' +
                '</div>' +
                '</div>' +
                '<div class="col-lg-3 col-md-3 col-sm-12">' +
                '<div class="form-group">' +
                '<label class="fieldlabels">عدد سنوات الخبره</label>' +
                '<input type="text" id="txtNumberofYears_' + firstrow + '" name="txtNumberofYears_' + firstrow + '" class="form-control mobileNo" placeholder="عدد سنوات الخبره">' +
                '</div>' +
                '</div>' +

                ' <div class="col-lg-3 col-md-3 col-sm-12 divremove">' +
                '<div class="form-group">' +
                '<a href="javascript:void" class="remove_document btn action-button" onclick="RemoveWorkExp(' + firstrow + ')"><i class="fa fa-Remove"></i>Remove</a>' +
                '</div>' +
                '</div>' +

                '</div>';

            $("#dynamicRow_Experience").append(addDiv2);
            debugger;
            arrayVal.push(firstrow);

            firstrow = firstrow + 1;


            $("#<%=hdWorkExpCount.ClientID%>").val(firstrow.toString());

        }

        function RemoveWorkExp(a) {

            var itemId = "divWorkExp_" + a;
            $("#" + itemId).remove();
            debugger;
            removeItem(arrayVal, a);
        }



        var firstrowTraining = 2;
        var arrayVal2 = [1];

        function GetNewRowTraining() {

            var addDivTraining = '<div class="row" id="divTraining_' + firstrowTraining + '">' +
                '<div class="col-lg-3 col-md-3 col-sm-12">' +
                '<div class="form-group">' +
                '<label class="fieldlabels">نوع الدوره التدريبيه</label>' +
                '<input type="text" id="txtCourseType_' + firstrowTraining + '" name="txtCourseType_' + firstrowTraining + '" class="form-control" placeholder="نوع الدوره التدريبيه">' +
                '</div>' +
                '</div>' +
                '<div class="col-lg-3 col-md-3 col-sm-12">' +
                '<div class="form-group">' +
                '<label class="fieldlabels">اسم الدوره التدريبيه</label>' +
                '<input type="text" id="txtCourseName_' + firstrowTraining + '" name="txtCourseName_' + firstrowTraining + '" class="form-control" placeholder="اسم الدوره التدريبيه">' +
                '</div>' +
                '</div>' +
                '<div class="col-lg-3 col-md-3 col-sm-12">' +
                '<div class="form-group">' +
                '<label class="fieldlabels">العنوان</label>' +
                '<input type="text" id="txtCourseDuration_' + firstrowTraining + '" name="txtCourseDuration_' + firstrowTraining + '" class="form-control" placeholder="العنوان">' +
                '</div>' +
                '</div>' +
                '<div class="col-lg-3 col-md-3 col-sm-12 divremove">' +
                '<div class="form-group">' +
                '<a href="javascript:void" class="remove_document btn action-button" onclick="RemoveTraining(' + firstrowTraining + ')"><i class="fa fa-Remove"></i>Remove</a>' +
                '</div>' +
                '</div>' +

                '</div>';

            $("#dynamicRow_Training").append(addDivTraining);
            debugger;
            arrayVal2.push(firstrowTraining);

            firstrowTraining = firstrowTraining + 1;


            $("#<%=hdntrainigCourse.ClientID%>").val(firstrowTraining.toString());

        }

        function RemoveTraining(a) {

            var itemId = "divTraining_" + a;
            $("#" + itemId).remove();
            debugger;
            removeItem(arrayVal2, a);
        }

        function removeItem(array, item) {
            debugger;
            for (var i in array) {
                if (array[i] == item) {
                    array.splice(i, 1);
                    break;
                }
            }
        }

        $(document).ready(function () {
            jQuery(".Dateeee").datepicker();

        });

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


        $("document").ready(function () {

            $('input[type=file]').change(function (e) {
                //debugger;
                //$in = $(this);
                //var abcd = $in[0].files[0].name;
                //$in.next().html(abcd);
                $in = $(this);
                var abcd2 = "";
                $in.next().html(abcd2);


                $("#file_error").html("");
                var fileInput =
                    document.getElementById('fileuploadfield_1');

                var filePath = fileInput.value;

                // Allowing file type 
                var allowedExtensions =
                    /(\.PDF|\.doc|\.docx)$/i;
                //PDF, doc, and docx.

                if (!allowedExtensions.exec(filePath)) {

                    $("#file_error").html("Invalid file type");
                    fileInput.value = '';
                    return false;
                }
                else {
                    $in = $(this);
                    var abcd = $in[0].files[0].name;
                    $in.next().html(abcd);
                    // Image preview 

                }

            });

            $("#firstop").css("display", "");
            $("#<%=ddlQualification.ClientID%>").change(function () {
                debugger;
                var a = $("#<%=ddlQualification.ClientID%>").val();
                if (a == "7") {
                    $("#firstop").css("display", "none");
                    $("#secondop").css("display", "none");
                    $("#thirdop").css("display", "none");
                    $("#fourthop").css("display", "");

                }
                else if (a == "4") {
                    debugger;
                    $("#firstop").css("display", "none");
                    $("#secondop").css("display", "");
                    $("#thirdop").css("display", "none");
                    $("#fourthop").css("display", "none");


                }
                else if (a == "5") {
                    $("#firstop").css("display", "none");
                    $("#secondop").css("display", "none");
                    $("#thirdop").css("display", "");
                    $("#fourthop").css("display", "none");
                }
                else {
                    debugger;
                    $("#firstop").css("display", "");
                    $("#secondop").css("display", "none");
                    $("#thirdop").css("display", "none");
                    $("#fourthop").css("display", "none");
                }
            });

            $(function () {
                //Reference the DropDownList.
                var ddlYears = $("#ContentPlaceHolder1_ctl00_ddlPassingYear");
                var ddlYears2 = $("#ContentPlaceHolder1_ctl00_ddlYear2");


                //Determine the Current Year.
                var currentYear = (new Date()).getFullYear();

                //Loop and add the Year values to DropDownList.
                for (var i = 1991; i <= currentYear; i++) {
                    var option = $("<option />");
                    option.html(i);
                    option.val(i);
                    ddlYears.append(option);

                }

                for (var i = 1991; i <= currentYear; i++) {
                    var option = $("<option />");
                    option.html(i);
                    option.val(i);

                    ddlYears2.append(option);
                }
            });

            $('#LicenceDetials').hide();
            $("[id*=<%=rblLisence.ClientID %>]").change(function () {

                if ($(this).val() == 'False') {
                    $('#LicenceDetials').hide();
                }
                else {
                    $('#LicenceDetials').show();
                }
                return false;
            });



            $('#<%=rblLisence.ClientID  %>_0').addClass("toggle toggle-left");
            $('#<%=rblLisence.ClientID  %>_1').addClass("toggle toggle-right");


            $('#<%=rblLisence.ClientID  %>_0').next('label').addClass("btn");
            $('#<%=rblLisence.ClientID  %>_1').next('label').addClass("btn");

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

                //if (current == 3) {
                //    debugger;
                //    step3validResult = false;
                //    step3Valid();
                //    if (step3validResult == true) {
                //    }
                //    else {
                //        return false;
                //    }
                //}

                //if (current == 4) {
                //    debugger;
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
                $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

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

                //Remove class active
                $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

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

            $(".submit").click(function () {
                return false;
            })



            function step1Valid() {
                var ValJobType = false;
                var ValJobName = false;
                var ValFirstName = false;
                var ValSecondName = false;
                var ValThirdName = false;
                var ValLastName = false;
                var ValNationalID = false;
                var ValBirthDate = false;
                var ValMaritalStatus = false;
                var ValChildNumber = false;
                var ValLicenceYearDate = false;
                var ValQualification = false;

                if ($('#<%= ddlJobType.ClientID %> option:selected').val() == "0") {

                    $('#<%= ddlJobType.ClientID %>').css('border', '1px solid red');
                }
                else {
                    $('#<%= ddlJobType.ClientID %>').css('border', 'none');
                    ValJobType = true;
                }

                if ($('#<%= ddlJobName.ClientID %> option:selected').val() == "0") {

                    $('#<%= ddlJobName.ClientID %>').css('border', '1px solid red');
                }
                else {

                    $('#<%= ddlJobName.ClientID %>').css('border', 'none');
                    ValJobName = true;
                }

                if ($('#<%= txtfirstName.ClientID %>').val().trim() != '') {

                    $('#<%= txtfirstName.ClientID %>').css('border', 'none');
                    ValFirstName = true;
                }
                else {

                    $('#<%= txtfirstName.ClientID %>').css('border', '1px solid red');
                }

              <%--  if ($('#<%= txtSecondName.ClientID %>').val().trim() != '') {

                    $('#<%= txtSecondName.ClientID %>').css('border', 'none');
                    ValSecondName = true;
                }
                else {

                    $('#<%= txtSecondName.ClientID %>').css('border', '1px solid red');
                }--%>

                <%--if ($('#<%= txtThirdName.ClientID %>').val().trim() != '') {

                    $('#<%= txtThirdName.ClientID %>').css('border', 'none');
                    ValThirdName = true;
                }
                else {

                    $('#<%= txtThirdName.ClientID %>').css('border', '1px solid red');
                }--%>

                if ($('#<%= txtLastName.ClientID %>').val().trim() != '') {

                    $('#<%= txtLastName.ClientID %>').css('border', 'none');
                    ValLastName = true;
                }
                else {

                    $('#<%= txtLastName.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtNationalID.ClientID %>').val().trim() != '') {

                    $('#<%= txtNationalID.ClientID %>').css('border', 'none');
                    ValNationalID = true;
                }
                else {

                    $('#<%= txtNationalID.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtDateOfBirth.ClientID %>').val().trim() != '') {

                    if ($('#<%= txtDateOfBirth.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= txtDateOfBirth.ClientID %>').val())) {
                            $('#<%= txtDateOfBirth.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= txtDateOfBirth.ClientID %>').css('border', 'none');
                            ValBirthDate = true;
                        }
                    }
                    else {
                        $('#<%= txtDateOfBirth.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= txtDateOfBirth.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= ddlMaritalStatus.ClientID %> option:selected').val() == "0") {

                    $('#<%= ddlMaritalStatus.ClientID %>').css('border', '1px solid red');
                }
                else {

                    $('#<%= ddlMaritalStatus.ClientID %>').css('border', 'none');
                    ValMaritalStatus = true;
                }

                var checked_radiorblAnyOtherSchool = $("[id*=rblLisence] input:checked");
                var valuerblAnyOtherSchool = checked_radiorblAnyOtherSchool.val();
                if (valuerblAnyOtherSchool == 'True') {
                    if ($('#<%= txtLicenceYear.ClientID %>').val().trim() != '') {

                        if ($('#<%= txtLicenceYear.ClientID %>').val().trim() != "") {

                            var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                            if (!regex.test($('#<%= txtLicenceYear.ClientID %>').val())) {
                                $('#<%= txtLicenceYear.ClientID %>').css('border', '1px solid red');

                            } else {
                                $('#<%= txtLicenceYear.ClientID %>').css('border', 'none');
                                ValLicenceYearDate = true;
                            }
                        }
                        else {
                            $('#<%= txtLicenceYear.ClientID %>').css('border', '1px solid red');
                        }
                    }
                    else {
                        $('#<%= txtLicenceYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    ValLicenceYearDate = true;
                }









                if ($('#<%= ddlQualification.ClientID %> option:selected').val() == "0") {

                    $('#<%= ddlQualification.ClientID %>').css('border', '1px solid red');
                }
                else {
                    $('#<%= ddlQualification.ClientID %>').css('border', 'none');
                    ValQualification = true;
                }

                debugger;
                //ValSecondName == true &&
                //ValThirdName == true &&
                if (ValJobType == true &&
                    ValJobName == true &&
                    ValFirstName == true &&
                    ValMaritalStatus == true &&

                    ValLastName == true &&
                    ValNationalID == true &&
                    ValBirthDate == true &&
                    ValLicenceYearDate == true &&
                    ValQualification == true
                ) {
                    debugger;
                    step1validResult = true;
                }
                else {

                    step1validResult = false;
                }
            }

            function step2Valid() {
                debugger;

                var qualificationVal = $("#<%=ddlQualification.ClientID%>").val();
               debugger;
               if (qualificationVal == "1") {
                   var ValddlPassingYear = false;
                   var ValUniName = false;
                   var ValMajorName = false;
                   var ValOverallEval = false;



                   if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlPassingYear.ClientID %>').val())) {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName.ClientID %>').css('border', 'none');
                    ValUniName = true;
                }
                else {

                    $('#<%= txtUniName.ClientID %>').css('border', '1px solid red');
                }


                if ($('#<%= txtMajor.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor.ClientID %>').css('border', 'none');
                    ValMajorName = true;
                }
                else {

                    $('#<%= txtMajor.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtOverallEval.ClientID %>').val().trim() != '') {

                    $('#<%= txtOverallEval.ClientID %>').css('border', 'none');
                    ValOverallEval = true;
                }
                else {

                    $('#<%= txtOverallEval.ClientID %>').css('border', '1px solid red');
                }


                if (ValddlPassingYear == true &&
                    ValUniName == true &&
                    ValMajorName == true &&
                    ValOverallEval == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }

            }

            else if (qualificationVal == "2") {
                var ValddlPassingYear = false;
                var ValUniName = false;
                var ValMajorName = false;
                var ValOverallEval = false;

                if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlPassingYear.ClientID %>').val())) {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName.ClientID %>').css('border', 'none');
                    ValUniName = true;
                }
                else {

                    $('#<%= txtUniName.ClientID %>').css('border', '1px solid red');
                }


                if ($('#<%= txtMajor.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor.ClientID %>').css('border', 'none');
                    ValMajorName = true;
                }
                else {

                    $('#<%= txtMajor.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtOverallEval.ClientID %>').val().trim() != '') {

                    $('#<%= txtOverallEval.ClientID %>').css('border', 'none');
                    ValOverallEval = true;
                }
                else {

                    $('#<%= txtOverallEval.ClientID %>').css('border', '1px solid red');
                }



                if (ValddlPassingYear == true &&
                    ValUniName == true &&
                    ValMajorName == true &&
                    ValOverallEval == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }
            else if (qualificationVal == "3") {
                var ValddlPassingYear = false;
                var ValUniName = false;
                var ValMajorName = false;
                var ValOverallEval = false;

                if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlPassingYear.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlPassingYear.ClientID %>').val())) {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlPassingYear.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlPassingYear.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName.ClientID %>').css('border', 'none');
                    ValUniName = true;
                }
                else {

                    $('#<%= txtUniName.ClientID %>').css('border', '1px solid red');
                }


                if ($('#<%= txtMajor.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor.ClientID %>').css('border', 'none');
                    ValMajorName = true;
                }
                else {

                    $('#<%= txtMajor.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtOverallEval.ClientID %>').val().trim() != '') {

                    $('#<%= txtOverallEval.ClientID %>').css('border', 'none');
                    ValOverallEval = true;
                }
                else {

                    $('#<%= txtOverallEval.ClientID %>').css('border', '1px solid red');
                }

                if (ValddlPassingYear == true &&
                    ValUniName == true &&
                    ValMajorName == true &&
                    ValOverallEval == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }
               else if (qualificationVal == "4") {
                   debugger;
                var ValddlPassingYear = false;
                var VarUniName2 = false;
                var VarMajor2 = false;
                var VarAverage2 = false;
                if ($('#<%= ddlYear2.ClientID %>').val().trim() != '') {

                    if ($('#<%= ddlYear2.ClientID %>').val().trim() != "") {

                        var regex = /^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$/;
                        if (!regex.test($('#<%= ddlYear2.ClientID %>').val())) {
                            $('#<%= ddlYear2.ClientID %>').css('border', '1px solid red');

                        } else {
                            $('#<%= ddlYear2.ClientID %>').css('border', 'none');
                            ValddlPassingYear = true;
                        }
                    }
                    else {
                        $('#<%= ddlYear2.ClientID %>').css('border', '1px solid red');
                    }
                }
                else {
                    $('#<%= ddlYear2.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtUniName2.ClientID %>').val().trim() != '') {

                    $('#<%= txtUniName2.ClientID %>').css('border', 'none');
                    VarUniName2 = true;
                }
                else {

                    $('#<%= txtUniName2.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajor2.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor2.ClientID %>').css('border', 'none');
                    VarMajor2 = true;
                }
                else {

                    $('#<%= txtMajor2.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtAverage2.ClientID %>').val().trim() != '') {

                    $('#<%= txtAverage2.ClientID %>').css('border', 'none');
                    VarAverage2 = true;
                }
                else {

                    $('#<%= txtAverage2.ClientID %>').css('border', '1px solid red');
                }


                   debugger;
                if (ValddlPassingYear == true &&
                    VarUniName2 == true &&
                    VarMajor2 == true &&
                    VarAverage2 == true
                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }
            else if (qualificationVal == "5") {
                var VarYear3 = false;
                var VarMajor3 = false;
                var VarAverage3 = false;

                if ($('#<%= txtYear3.ClientID %>').val().trim() != '') {

                    $('#<%= txtYear3.ClientID %>').css('border', 'none');
                    VarYear3 = true;
                }
                else {

                    $('#<%= txtYear3.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajor3.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor3.ClientID %>').css('border', 'none');
                    VarMajor3 = true;
                }
                else {

                    $('#<%= txtMajor3.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtAverage3.ClientID %>').val().trim() != '') {

                    $('#<%= txtAverage3.ClientID %>').css('border', 'none');
                    VarAverage3 = true;
                }
                else {

                    $('#<%= txtAverage3.ClientID %>').css('border', '1px solid red');
                }

                if (VarYear3 == true &&
                    VarMajor3 == true &&
                    VarAverage3 == true

                ) {
                    step2validResult = true;
                }
                else {
                    step2validResult = false;
                }
            }


            else {

                var VarMajor4 = false;
                var VarMajor24 = false;
                var VarMajorFrom = false;
                   var varYear4 = false;

                   if ($('#<%= txtYear4.ClientID %>').val().trim() != '') {

                       $('#<%= txtYear4.ClientID %>').css('border', 'none');
                        varYear4 = true;
                    }
                    else {

                        $('#<%= txtYear4.ClientID %>').css('border', '1px solid red');
                    }

                if ($('#<%= txtMajor4.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor4.ClientID %>').css('border', 'none');
                    VarMajor4 = true;
                }
                else {

                    $('#<%= txtMajor4.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajor24.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajor24.ClientID %>').css('border', 'none');
                    VarMajor24 = true;
                }
                else {

                    $('#<%= txtMajor24.ClientID %>').css('border', '1px solid red');
                }

                if ($('#<%= txtMajorFrom.ClientID %>').val().trim() != '') {

                    $('#<%= txtMajorFrom.ClientID %>').css('border', 'none');
                    VarMajorFrom = true;
                }
                else {

                    $('#<%= txtMajorFrom.ClientID %>').css('border', '1px solid red');
                   }

                   if (VarMajor4 == true &&
                       VarMajor24 == true &&
                       VarMajorFrom == true &&
                       varYear4 == true
                   ) {
                       step2validResult = true;
                   }
                   else {
                       step2validResult = false;
                   }


                   //step2validResult = true;
               }


           }

        });



    });
</script>
