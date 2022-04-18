<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyCompanyRequestPhase2.ascx.cs" Inherits="Controls_RenewableEnergyCompanyRequestPhase2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<div class="companyorder">
    <section class="step" id="msform">
        <div class="menuuu">
            <ul class="list-unstyled steplist" id="progressbar2">
                <li class="active"><a href="javascript:void(0)" > <span id="Li1">  قبول الطلب </span></a></li>
                <li><a href="javascript:void(0)"><span id="Li2"> معلومات الاشتراك</span></a></li>
                <li><a href="javascript:void(0)"><span id="Li3">  اختيار المفوض</span> </a></li>
                <li><a href="javascript:void(0)"><span id="Li4"> تفاصيل النظام</span>    </a></li>
                <li><a href="javascript:void(0)"><span id="Li5"> الموافقة</span>  </a></li>
            </ul>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <fieldset>
                    <%--<div class="row custom_radio">
                        <div class="col-lg-2 col-md-3 col-sm-12">
                            <label>نوع الطلب</label>
                        </div>
                        <div class="col-lg-10 col-md-9 col-sm-12">
                            <div class="radio">
                                <asp:RadioButtonList runat="server" ID="rblRenwableRequest" RepeatDirection="Horizontal" Enabled="False">
                                    <asp:ListItem Text="صغير صافي قياس" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="كبير صافي قياس" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="عبور" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>--%>

                    <div id="RenwableRequest1Step1" style="display:none">
                    <div class="row custom_radio" id="MeterStatuDiv">
                        <div class="col-lg-2 col-md-3 col-sm-12">
                            <label>نوع الطلب</label>
                        </div>
                        <div class="col-lg-10 col-md-9 col-sm-12">
                            <div class="radio">
                                <asp:RadioButtonList runat="server" ID="rblMeterStatus" RepeatDirection="Horizontal" Enabled="False">
                                    <asp:ListItem Text="عداد عامل" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="عداد جديد" Value="2"></asp:ListItem>
                                     <asp:ListItem Text="مبنى قيد الانشاء" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="row custom_radio">
                        <div class="col-lg-2 col-md-3 col-sm-12" id="divRefernText">
                         
                            <label><asp:Literal runat="server" ID="lblRefenceTitle"></asp:Literal></label>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="radio">
                                <asp:RadioButtonList runat="server" ID="rbdRefeenceType" RepeatDirection="Horizontal" Enabled="False" style="display:none">
                                    <asp:ListItem Text="رقم العداد" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="رقم الطلب" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="مبنى قيد الانشاء" Value="3"></asp:ListItem>
                                    
                                </asp:RadioButtonList>
                            </div>
                            <span class="LTR">
                                <asp:Literal runat="server" ID="FileNumber"></asp:Literal>
                            </span>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12">
                            
                        </div>
                    </div>
                    <div class="row Type_Request" style="display: none">
                        <div class="col-lg-5 col-md-6 col-sm-6">
                            <strong>نوع الطلب</strong>
                            <div class="ordercheckbox">
                                <label>
                                    <span class="detcheckbox">
                                        <input type="checkbox" id="two">
                                        <label for="two"></label>
                                    </span>
                                    <asp:Literal runat="server" ID="TypeRequst"></asp:Literal>
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-6">
                            <strong>حالة العداد</strong>
                            <div class="ordercheckbox">
                                <label>
                                    <span class="detcheckbox">
                                        <input type="checkbox" id="two0">
                                        <label for="two0"></label>
                                    </span>
                                    <asp:Literal runat="server" ID="Counter"></asp:Literal>
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="row Type_Request" style="display: none">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <strong>الرقم المرجعي</strong>
                            <div class="ordercheckbox">
                                <label>
                                    <span class="detcheckbox">
                                        <input type="checkbox" id="ttwo">
                                        <label for="ttwo"></label>
                                    </span>
                                    <asp:Literal runat="server" ID="ReferenceNo"></asp:Literal>
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <strong class="extitle">معلومات صاحب الطلب</strong>
                    <div class="energyrequest">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>الاسم الاول</label>
                                    <asp:HiddenField ID="hndFromUser" runat="server" />
                                    <asp:TextBox ID="txtFirstNAme" runat="server" PlaceHolder="عبد الكريم" disabled="disabled"></asp:TextBox>
                                   
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>اسم الاب</label>
                                   
                                    <asp:TextBox ID="txtSecondName" runat="server" PlaceHolder="اسم الاب" disabled="disabled"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>اسم الجد</label>
                                   
                                    <asp:TextBox ID="txtThirdName" runat="server" PlaceHolder="اسم الجد" disabled="disabled"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>اسم العائلة</label>
                                   
                                    <asp:TextBox ID="txtLastName" runat="server" PlaceHolder="اسم العائلة" disabled="disabled"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>المحافظة</label>
                                    <asp:TextBox ID="txtGovernal" runat="server" PlaceHolder="المحافظة" disabled="disabled"></asp:TextBox>
                                    
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>المنطقة ١</label>
                                    <asp:TextBox ID="txtArea1" runat="server" PlaceHolder="المنطقة ١" disabled="disabled"></asp:TextBox>
                                   
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>المنطقة ٢</label>
                                    <asp:TextBox ID="txtArea2" runat="server" PlaceHolder="المنطقة ٢" disabled="disabled"></asp:TextBox>
                                  
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>اسم الشارع</label>
                                    <asp:TextBox ID="txtStret" runat="server" PlaceHolder="اسم الشارع" disabled="disabled"></asp:TextBox>
                                    
                                </div>
                            </div>
                        </div>
                    </div> 
                     </div>

                    <div class="energyrequest" id="RenwableRequest3Step1" >
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>Requester Name </label>                                   
                                    <asp:TextBox ID="txtRequstName" runat="server" PlaceHolder="" disabled="disabled"></asp:TextBox>
                                    <%-- <input type="text" placeholder="عبد الكريم">--%>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>Telephone</label>                                   
                                    <asp:TextBox ID="txtTelePhoneno" runat="server" PlaceHolder="" disabled="disabled"></asp:TextBox>
                                    <%-- <input type="text" placeholder="عبد الكريم">--%>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>Email Address </label>                                   
                                    <asp:TextBox ID="txtEmailAdd" runat="server" PlaceHolder="" disabled="disabled"></asp:TextBox>
                                    <%-- <input type="text" placeholder="عبد الكريم">--%>
                                </div>
                            </div>                           
                        </div>

                        <%--Total Power--%>

                        <div class="row">
                            <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>الاستطاعة الكلية</label>                                   
                                    <asp:TextBox ID="txtTotalPower" runat="server" PlaceHolder="الاستطاعة الكلية" ></asp:TextBox>                                   
                                </div>
                            </div>
                        </div>
                        </div>

                        <%--Location--%>
                        <div class="row">
                            <asp:ListView runat="server" ID="lstPhase1Location">
                                <ItemTemplate>
                                      <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                    <label>الموقع</label>                                   
                                    <%--<input type="text" id="txtLocationName_1" name="txtLocationName_1" placeholder="الموقع">--%>
                                    <asp:TextBox runat="server" ID="txtLocationName" Text='<%# Bind("LocationName") %>' readonly="true" PlaceHolder="الموقع"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                    <label>المحافظة</label>  
                                    <asp:TextBox runat="server" ID="txtGovernate" Text='<%# Bind("Governate") %>' readonly="true" PlaceHolder="المحافظة"></asp:TextBox>
                                    <%--<input type="text" id="txtGovernate_1" name="txtGovernate_1" placeholder="المحافظة">--%>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <div class="form-group">
                                    <label>المديرية</label>  
                                    <asp:TextBox runat="server" ID="txtArea1" Text='<%# Bind("Area1") %>' readonly="true" PlaceHolder="المديرية"></asp:TextBox>
                                    <%--<input type="text" id="txtArea1_1 " name="txtArea1_1" placeholder="المديرية">--%>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <div class="form-group">
                                    <label>القرية</label>    
                                    <asp:TextBox runat="server" ID="txtArea2" Text='<%# Bind("Area2") %>' readonly="true" PlaceHolder="القرية"></asp:TextBox>
                                    <%--<input type="text" id="txtArea2_1" name="txtArea2_1" placeholder="القرية">--%>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <div class="form-group">
                                    <label>الحوض</label>      
                                    <asp:TextBox runat="server" ID="txtArea3" Text='<%# Bind("Area3") %>' readonly="true" PlaceHolder="الحوض"></asp:TextBox>
                                    <%--<input type="text" id="txtArea3_1" name="txtArea3_1" placeholder="الحوض">--%>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                    <label>رقم القطعة</label>     
                                     <asp:TextBox runat="server" ID="txtAreaNumber" Text='<%# Bind("AreaNumber") %>' readonly="true" PlaceHolder="رقم القطعة"></asp:TextBox>
                                    <%--<input type="text" id="txtAreaNumber_1" name="txtAreaNumber_1" placeholder="رقم القطعة">--%>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                    <label>Longitude</label> 
                                    <asp:TextBox runat="server" ID="txtLongitude" Text='<%# Bind("Longitude") %>' readonly="true" PlaceHolder="Longitude"></asp:TextBox>
                                   <%-- <input type="text" id="txtLongitude_1" name="txtLongitude_1" placeholder="Longitude">--%>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                    <label>Latitude</label>     
                                    <asp:TextBox runat="server" ID="txtLatitude" Text='<%# Bind("Latitude") %>' readonly="true" PlaceHolder="Latitude"></asp:TextBox>
                                   <%-- <input type="text" id="txtLatitude_1 " name="txtLatitude_1" placeholder="Latitude">--%>
                                </div>
                            </div>                            
                            
                        </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                        <%--MeterData--%>
                        <div class="row">
                           <asp:ListView runat="server" ID="lstMeterData">
                               <ItemTemplate>



                                    <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>عدد الاشتراكات</label>                                   
                                    <asp:TextBox ID="txtNumberofConnection" runat="server" PlaceHolder="عدد الاشتراكات" Text='<%# Bind("NumberofConnection") %>' readonly="true" ></asp:TextBox>                                                     
                                    <%--<input type="text" id="txtNumberofConnection_1" name="txtNumberofConnection_1" placeholder="عدد الاشتراكات">--%>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>اسم المشترك  </label>                                   
                                    <asp:TextBox ID="txtNumberofConnectionName" runat="server" PlaceHolder="اسم المشترك " Text='<%# Bind("Name") %>' readonly="true" ></asp:TextBox>
                                    <%--<input type="text" id="txtNumberofConnectionName_1" name="txtNumberofConnectionName_1" placeholder="اسم المشترك">--%>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label> رقم العداد </label>                                   
                                    <asp:TextBox ID="txtMeterNumber" runat="server" PlaceHolder=" رقم العداد" Text='<%# Bind("MeterNumber") %>' readonly="true" ></asp:TextBox>  
                                    <%--<input type="text" id="txtMeterNumber_1" name="txtMeterNumber_1" placeholder="رقم العداد">--%>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>رقم الملف </label>                                   
                                    <asp:TextBox ID="txtFileNumber" runat="server" PlaceHolder="رقم الملف" Text='<%# Bind("FileNumber") %>' readonly="true" ></asp:TextBox>
                                    <%--<input type="text" id="txtFileNumber_1" name="txtFileNumber_1" placeholder="رقم الملف">--%>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>عنوان الاشتراك </label>                                   
                                    <asp:TextBox ID="txtMeterAddress" runat="server" PlaceHolder="عنوان الاشتراك" Text='<%# Bind("MeterAddress") %>' readonly="true" ></asp:TextBox>
                                    <%--<input type="text" id="txtMeterAddress_1" name="txtMeterAddress_1" placeholder="عنوان الاشتراك">--%>
                                </div>
                            </div>
                           
                               </ItemTemplate>
                           </asp:ListView>
                        </div>


                        <%--Attachments--%>

                        <asp:ListView ID="lstattcment" runat="server" OnItemDataBound="lstattcment_ItemDataBound">
                                        <ItemTemplate>

                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <label>
                                           الهوية الشخصية
                               </label>
                                                    <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# Bind("Attachments1") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <label>
                                               تفويض خطي مصدق من البنك
												</label>
                                                    <asp:HyperLink runat="server" ID="HyperLink2" NavigateUrl='<%# Bind("Attachments2") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <label>
                                             تفويض خطي مصدق من صاحب الأرض   
												</label>
                                                    <asp:HyperLink runat="server" ID="HyperLink3" NavigateUrl='<%# Bind("Attachments3") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <label>
                                                صورة عن السجل التجاري لصاحب المشترك 
												</label>
                                                    <asp:HyperLink runat="server" ID="HyperLink4" NavigateUrl='<%# Bind("Attachments4") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                            </div>
                                            
                                            <div class="row" style="display:none;">
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:HyperLink runat="server" ID="HyperLink5" NavigateUrl='<%# Bind("Attachments5") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:HyperLink runat="server" ID="HyperLink6" NavigateUrl='<%# Bind("Attachments6") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                            </div>

                                             <div class="row" style="display:none;">
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:HyperLink runat="server" ID="HyperLink7" NavigateUrl='<%# Bind("Attachments7") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:HyperLink runat="server" ID="HyperLink8" NavigateUrl='<%# Bind("Attachments8") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                            </div>

                                            <div class="row" style="display:none;">
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:HyperLink runat="server" ID="HyperLink9" NavigateUrl='<%# Bind("Attachments9") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6">
                                                    <asp:HyperLink runat="server" ID="HyperLink10" NavigateUrl='<%# Bind("Attachments10") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                </div>
                                            </div>

                                        </ItemTemplate></asp:ListView>

                    </div>

                    <input type="button" name="next" class="next request_accept_BTN" value="قبول الطلب والاستمرار" />
                </fieldset>
                <fieldset>     
                    
                     <div class="Choose_Commissioner">
                        <strong class="extitle">اختيار المفوض</strong>

                    
                    

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" class="">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6">
                                        <div class="form-group">
                                            <label>قم بتحديد المفوض لهذا الطلب</label>
                                            <asp:DropDownList ID="ddlUSerType" runat="server" OnSelectedIndexChanged="ddlUSerType_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <ul class="list-unstyled">
                                    <asp:ListView ID="lstUSerData" runat="server" OnItemDataBound="lstUSerData_ItemDataBound">
                                        <ItemTemplate>
                                            <li>
                                                <div class="profile_PIC">
                                                    <%-- <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Profile_pic_1.png" alt="">--%>
                                                    <asp:Image ID="imgProfileimge" runat="server" ImageUrl='<%# Bind("DocumentUploadPhoto") %>' />

                                                    <span><strong>اسم المفوض</strong>
                                                        <p>
                                                            <asp:Literal runat="server" ID="lblname" Text='<%# Eval("FirstName") + " " + Eval("FatherName") + " " + Eval("FamilyName") %>'></asp:Literal>
                                                        </p>
                                                    </span>
                                                </div>
                                                <div>
                                                    <strong>رقم الهاتف</strong>
                                                    <span class="LTR">
                                                        <asp:Literal runat="server" ID="lblTelePhone" Text='<%# Bind("MobileNo") %>'></asp:Literal></span>
                                                </div>
                                                <div>
                                                    <strong>البريد الالكتروني</strong>
                                                    <span class="LTR">
                                                        <asp:Literal runat="server" ID="lblEmail" Text='<%# Bind("EmailID") %>'></asp:Literal></span>
                                                </div>
                                                <div>
                                                    <strong>هوية احوال مدنية</strong>
                                                    <p>
                                                        <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("DocumentUpload") %>' Target="_blank">
                                   <i class="fa fa fa-download"></i>
                                                        </asp:HyperLink>
                                                    </p>
                                                </div>
                                                <%-- <a href="javascript:void">التفاصيل</a>--%>
                                            </li>
                                        </ItemTemplate>
                                    </asp:ListView>                                    
                                </ul>
                            </ContentTemplate>

                        <Triggers>
                             
               
                             <asp:AsyncPostBackTrigger ControlID="ddlUSerType" EventName="SelectedIndexChanged"/> 
                             <%--  <asp:PostBackTrigger ControlID="LinkButton2" /> --%>

               </Triggers>


                        </asp:UpdatePanel>

                          </div>
                    <%-- <button class="Continue_BTN">متابعة</button>--%>
                    <input type="button" name="next" class="next Continue_BTN" value="التالي" />
                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                </fieldset>
                <fieldset>
                    <div id="RenwableRequest1Step3">

                         <div id="RenwableRequest1Step4" >
                    <div class="Order-details">
                        <strong class="extitle">تفاصيل النظام</strong>
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <label>قدرة النظام <span class="LTR"> AC  (KW)</span> </label>
                                    <%--<input type="text" placeholder="ادخل قدرة النظام">--%>
                                    <asp:TextBox ID="txtACVal" runat="server" PlaceHolder="ادخل قدرة النظام" class="mobileNo  LTR"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <label>قدرة النظام <span class="LTR"> DC  (KW)</span> </label>
                                    <%--<input type="text" placeholder="ادخل قدرة النظام">--%>
                                    <asp:TextBox ID="txtDCVal" runat="server" PlaceHolder="ادخل قدرة النظام" class="mobileNo LTR"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="hdnstep4" runat="server" />

                    <div class="Reverse_device_information">
                        <strong>معلومات جهاز العكس</strong>
                        <asp:HiddenField ID="hdnDeviceRowloopCount" runat="server" />
                        <div class="row" id="DiviceDivID_1">
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                   
                                    <label>نوع جهاز العكس</label>
                                    <select id="ddlDivice_1" class="form-control ddldevicedrop" data-filename="1" name="ddlDivice_1"></select>
                                    <input type="text" id="txtdeviceName_1" name="txtdeviceName_1" style="display: none">
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-2">
                                <div class="form-group">
                                    <label>الموديل</label>
                                     <select id="ddlDiviceModel_1" class="form-control ddldevicedropModel" data-filename="1" name="ddlDiviceModel_1"></select>
                                    <input type="text" id="txtModelNo_1" name="txtModelNo_1" placeholder="الموديل" class="input_number" readonly style="display:none">
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-3">
                                <div class="form-group">
                                    <label>قدرة جهاز العكس </label>
                                    <input type="text" id="txtdevice_1" name="txtdevice_1" placeholder="قدرة الجهاز" class="input_number" readonly>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-3">
                                <div class="form-group">
                                    <label>عدد أجهزة العكس </label>
                                    <input type="text" id="txtdeviceNoUnit_1" name="txtdeviceNoUnit_1" class="mobileNo LTR" placeholder="ادخل عدد أجهزة العكس ">
                                   
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="Add_device">
                                    <input type="text" id="txtdeviceDocument_1" name="txtdeviceDocument_1" style="display: none">
                                    <a href="javascript:void(0);" id="ahref_1">
                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                                    </a>
                                    <a href="javascript:void(0)" onclick="GetADDNewRow();">
                                        <i class="lni lni-plus"></i>اضافة جهاز</a>
                                    <div id="DeleteDeviceDiv1">
                                   
                                        </div>
                                </div>
                            </div>

                        </div>

                        <a href="/ar/Home/RenewableEnergyCompanyDeviceList/RenewableEnergyCompanyDeviceAdd" target="_blank"> اضافة جهاز عكس جديد</a>
                        <br />
                        <a href="javascript:void(0);" class="loadDevise">تحديث القائمة </a>

                       

             
                        
                       

                        <div id="divDeviceInfo"></div>                        
                    </div>

                    <div class="Reverse_device_information Solar_cell_information">
                        <strong>معلومات الخلايا الشمسية</strong>
                        <asp:HiddenField ID="hdnSollerRowloopCount" runat="server" />
                        <div class="row" id="SolerCellDivID_1">
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">
                                    <label>نوع الخلايا الشمسية</label>
                                    <select id="ddlSolarcell_1" class="form-control ddlSolerdrop" data-filename="1" name="ddlSolarcell_1"></select>
                                    <input type="text" id="txtSolarcellName_1" name="txtSolarcellName_1" style="display: none">
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-3">
                                <div class="form-group">
                                    <label>الموديل</label>
                                    <select id="ddlSollerCellModel_1" class="form-control ddlSollerCelldropModel" data-filename="1" name="ddlSollerCellModel_1"></select>
                                    <input type="text" placeholder="الموديل" id="txtModelSollerCell_1" name="txtModelSollerCell_1" class="input_number" readonly style="display:none">
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-3">
                                <div class="form-group">
                                    <label>قدرة الخلايا </label>
                                    <input type="text" placeholder="قدرة الخلايا " id="txtSollerCell_1" name="txtSollerCell_1" class="input_number" readonly>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-3">
                                <div class="form-group">
                                    <label>عدد الخلايا </label>
                                    <input type="text" id="txtSellNoUnit_1" name="txtSellNoUnit_1" class="mobileNo LTR" placeholder="عدد الخلايا ">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="Add_device">
                                    <input type="text" id="txtSolarcellDocument_1" name="txtSolarcellDocument_1" style="display: none">
                                    <a href="javascript:void(0);" id="aSolarhref_1" >
                                        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                                    </a>
                                    <a href="javascript:void(0)" onclick="GetADDNewSollerCell();">
                                        <i class="lni lni-plus"></i>
                                        اضافة خلايا </a>
                                    <div id="DeleteSolerDiv1">
                                    <%-- <a href="javascript:void(0)" class="remove_document" onclick="RemoveSollerCell(1)"><i class="fa fa-Remove"></i>ازالة</a>--%>
                                        </div>
                                </div>
                            </div>
                        </div>

                        


                        <a href="/ar/Home/RenewableEnergyCompanySolarCellList/RenewableEnergyCompanySolarCellAdd" target="_blank">اضافة خلية شمسية جديدة</a>
                        <br />
                        <a href="javascript:void(0);" class="loadSoller">تحديث القائمة</a>
                        <div id="divSollerCellDiv"></div>
                    </div>

                             <div class="Reverse_device_information">
                                 <strong>المعدات الأخرى التي سيتم استخدامها</strong>
                           
                             <asp:HiddenField ID="hdnOtherCount" runat="server" />

                       <div class="row" id="otharAddRow_1">
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                <div class="form-group">                                                                      
                                    <input type="text" id="txtOtherDevice_1" name="txtOtherDevice_1">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3">
                                 <a href="javascript:void(0)" onclick="GetOthersNewRow();">
                                        <i class="lni lni-plus"></i>اضافة جهاز</a>
                            </div>
                           
                        </div>
                           

                            <div id="newOtherDiv"></div>
                        </div>

                    <div class="upload_div">
                        <div class="row">
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                صورة مخطط أحادي
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
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                دراسة تصميمية
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
                        <div class="row" style="display:none">
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                صورة مخطط أراضي
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
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                شهادة سلامة عامة للخلايا والعكس
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
                        </div>
                    </div>

                        


                          </div>

                    
                    
                        </div>
                     <asp:HiddenField ID="HdnMeterStatus" runat="server" />
                    <%--<div id="RenwableRequest3Step3" class="energyrequest" style="display:none">
                       
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>عدد الاشتراكات</label>                                                                      
                                    <input type="text" id="txtNumberofConnection_1" name="txtNumberofConnection_1" placeholder="عدد الاشتراكات">
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>اسم المشترك  </label>                                                                      
                                    <input type="text" id="txtNumberofConnectionName_1" name="txtNumberofConnectionName_1" placeholder="اسم المشترك">
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label> رقم العداد </label>                                   
                                   
                                    <input type="text" id="txtMeterNumber_1" name="txtMeterNumber_1" placeholder="رقم العداد">
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>رقم الملف </label>                                   
                                   
                                    <input type="text" id="txtFileNumber_1" name="txtFileNumber_1" placeholder="رقم الملف">
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <div class="form-group">
                                    <label>عنوان الاشتراك </label>                                   
                                   
                                    <input type="text" id="txtMeterAddress_1" name="txtMeterAddress_1" placeholder="عنوان الاشتراك">
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6">
                                <a href="javascript:void(0)" onclick="AddMeterRow();">
                                        <i class="lni lni-plus"></i>اضافة جهاز</a>
                            </div>
                        </div>
                        <div id="divAddeRowMeteStatus"></div>
                    </div>--%>




                    <input type="button" name="next" class="next Continue_BTN" value="التالي" />
                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                </fieldset>
                <fieldset>

                    <div id="RenwableRequest3Step4" >


                        <div class="row">
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                               أحقية استخدام الأرض 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_1" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_1" name="fileuploadCross_1" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error1" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مخطط موقع تنظيمي 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_2" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_2" name="fileuploadCross_2" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error2" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                               موافقة الجهة التنظيمية    
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_3" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_3" name="fileuploadCross_3" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error3" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                أخرى 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_4" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_4" name="fileuploadCross_4" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error4" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="display:none;">
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مرفق 5 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_5" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_5" name="fileuploadCross_5" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error5" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مرفق 6 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_6" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_6" name="fileuploadCross_6" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error6" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="display:none;">
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مرفق 7 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_7" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_7" name="fileuploadCross_7" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error7" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مرفق 8 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_8" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_8" name="fileuploadCross_8" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error8" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="display:none;">
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مرفق 9 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_9" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_9" name="fileuploadCross_9" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error9" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-md-6 col-sm-6">
                                <div class="form-group">
                                    <div class="deviceflie">
                                        <div class="Device_description">
                                            <label>
                                                مرفق 10 
												</br>
                                <small><span>*</span>بحجم أقصى 2 ميجابايت</small></label>
                                        </div>
                                        <div class="file-upload">
                                            <label for="fileuploadCross_10" class="file-upload__label fieldlabels">
                                                تحميل الصور 
                                                <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/upload.png" alt="">
                                            </label>
                                            <input id="fileuploadCross_10" name="fileuploadCross_10" type="file" class="file-upload__input" />
                                            <span class="file-select"></span>
                                            <br />
                                            <span id="fileCross_error10" style="color: red"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                   
                    <input type="button" name="next" id="s3" class="next Continue_BTN" value="التالي" />
                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                </fieldset>
                <fieldset>
                    <div class="Agree">
                        <strong>الموافقة</strong>
                        <div class="checkbox">
                            <label>
                                <span class="detcheckbox">
                                    <input type="checkbox" id="twooo">
                                    <label for="twooo"></label>
                                </span>

                                <span id="lbldetailsfiedld5"> 
                                     أقر أن المعلومات الواردة في هذا الطلب صحيحة وأوافق على الالتزام ببنود وشروط اتفاقية ربط نظم مصادر الطاقة المتجددة والتي سيتم توقيعها عند اجراء الكشف الأولي
                                </span>
                               
                            </label>
                        </div>
                    </div>
                    <button class="btn Continue_BTN" type="button" id="btbvalid" onclick="SendClick();">موافقة على الطلب</button>
                    <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Style="display: none;" type="button" />
                    <input type="button" name="previous" class="previous action-button-previous" value="السابق" />
                </fieldset>

            </div>

        </div>

        <%--<button class="Continue_BTN">موافقة على الطلب</button>--%>
    </section>
</div>

  

 

  <asp:HyperLink runat="server" ID="lnkSecondNav" />


<asp:LinkButton ID="lnkSubscribe" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender runat="server" ID="mpeInquiry123"
    TargetControlID="lnkSubscribe" BehaviorID="mpeInquiry123"
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
                    <asp:Literal runat="server" ID="lblInquiryTitle" Text="تقديم طلب طاقة متجددة"></asp:Literal></h4>
            </div>
            <div class="modal-body">
                <div style="text-align: center; font-size: 25px; padding: 40px 0;">
                    <asp:Image ID="imgPopup" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/check.png" />
                    <strong>تم ارسال الطلب بنجاح</strong>
                    <p>
                        <asp:Literal runat="server" ID="lblInquiryMessage" Text="">                             
                        </asp:Literal>
                        <br />
                        <asp:Literal runat="server" ID="lblInquiryMessage2" Text="">                             
                        </asp:Literal>
                        <br />
                        <asp:Literal runat="server" ID="lblInquiryMessage3" Text="">                             
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




<%--<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
--%>


<script>
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_endRequest(function () {

        $("#btbvalid").attr("disabled", true);

        $("#twooo").click(function () {


            var checked_status = this.checked;
            if (checked_status == true) {
                $("#btbvalid").attr("disabled", true);

                //$("#btbvalid").removeAttr("disabled");

            } else {
                $("#btbvalid").attr("disabled", false);
                //$("#btbvalid").attr("disabled", "disabled");
            }
        });

        //SendClickDevice();

        //if (sender._postBackSettings.panelsToUpdate != null) {
        //    SendClickDevice();
        //}




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
        background: #FFF;
        padding: 30px 0px;
    }

        #msform fieldset {
            background: #FFF;
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

    /*#msform input,
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
    }*/

    #msform input:focus,
    #msform textarea:focus {
        -moz-box-shadow: none !important;
        -webkit-box-shadow: none !important;
        box-shadow: none !important;
        border: 1px solid #325925;
        outline-width: 0;
    }

    /*#msform .action-button {
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
        
    }*/

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
        float: right;
        height: 60px;
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

    /*#msform fieldset input,
    #msform fieldset select {
        background: #fff;
        height: 60px;
        border: 1px solid #e2e2e2;
        padding: 10px;
        margin-bottom: 15px;
    }*/

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
        background: url(../<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/down-arrow.png) no-repeat #fff !important;
        background-position: right !important;
    }

    select#new_select_name {
        background: url(../<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/down-arrow.png) no-repeat #fff !important;
        background-position: right !important;
    }

    input[type="file"] {
        display: block;
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


    .profile_PIC img {
        width: 70px;
    }

    .modal-body input {
        font-size: 18px;
        color: #858585;
        background: none;
        border: 1px solid #d8d8d8;
        height: 60px;
        padding: 10px 15px;
    }

    /*.steplist li a {  
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
}*/


    @media only screen and (max-width: 1367px) and (min-width: 1300px) {

        /*.steplist li::before {
    border-bottom: 60px solid #ffde23;
}
 .steplist li:first-child::before {
            border-bottom: 60px solid #007fc3;
        }
 .steplist li:last-child::before {
    border-bottom: 60px solid #f2f2f2;
}*/

    }
</style>

<style>
    .Continue_BTN {
        background: #007fc3;
        color: #fff;
        height: 60px;
        width: 200px;
        font-size: 20px;
        padding: 10px;
        border: none;
        margin: 80px 0;
        font-weight: bold;
        text-align: center;
        float: right;
        margin-top: 9px;
    }

    .radio td {
        width: 25%;
    }
</style>

<script type="text/javascript">

    var arrayVal = [1];
    var arrayValSolerCell = [1];
    var arrayLocationCount = [1];
    var arrayMeterCount = [1];
    var arrayOthersCount = [1];
    $("document").ready(function () {


        //$(".ahrefcallGraph").click(function () {

        //    $('#myModalForFileGraph').modal('show');
        //});

        GetDeviceData(1);
        GetSellData(1);

        //===================== Radio 1 ==========================
       <%-- $('#<%=rblRenwableEnergyType.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblRenwableEnergyType.ClientID  %>_1').addClass("toggle toggle-right");
        $('#<%=rblRenwableEnergyType.ClientID  %>_2').addClass("toggle toggle-right");


        $('#<%=rblRenwableEnergyType.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rblRenwableEnergyType.ClientID  %>_1').next('label').addClass("radio-label");
        $('#<%=rblRenwableEnergyType.ClientID  %>_2').next('label').addClass("radio-label");



        $('#<%=rblRenwablePowerType.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblRenwablePowerType.ClientID  %>_1').addClass("toggle toggle-right");



        $('#<%=rblRenwablePowerType.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rblRenwablePowerType.ClientID  %>_1').next('label').addClass("radio-label");--%>

       <%-- $('#<%=rblRenwableRequest.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblRenwableRequest.ClientID  %>_1').addClass("toggle toggle-right");
        $('#<%=rblRenwableRequest.ClientID  %>_2').addClass("toggle toggle-right");

        $('#<%=rblRenwableRequest.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rblRenwableRequest.ClientID  %>_1').next('label').addClass("radio-label");
        $('#<%=rblRenwableRequest.ClientID  %>_2').next('label').addClass("radio-label");--%>


        $('#<%=rblMeterStatus.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rblMeterStatus.ClientID  %>_1').addClass("toggle toggle-right");
        $('#<%=rblMeterStatus.ClientID  %>_2').addClass("toggle toggle-right");



        $('#<%=rblMeterStatus.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rblMeterStatus.ClientID  %>_1').next('label').addClass("radio-label");
        $('#<%=rblMeterStatus.ClientID  %>_2').next('label').addClass("radio-label");



        //===================== Radio 3 ==========================
        $('#<%=rbdRefeenceType.ClientID  %>_0').addClass("toggle toggle-left");
        $('#<%=rbdRefeenceType.ClientID  %>_1').addClass("toggle toggle-right");
        $('#<%=rbdRefeenceType.ClientID  %>_2').addClass("toggle toggle-right");



        $('#<%=rbdRefeenceType.ClientID  %>_0').next('label').addClass("radio-label");
        $('#<%=rbdRefeenceType.ClientID  %>_2').next('label').addClass("radio-label");


    });
    $("document").ready(function () {

        $("#twooo").click(function () {


            var checked_status = this.checked;
            if (checked_status == true) {
                $("#btbvalid").attr("disabled", true);

                //$("#btbvalid").removeAttr("disabled");

            } else {
                $("#btbvalid").attr("disabled", false);
                //$("#btbvalid").attr("disabled", "disabled");
            }
        });
        $('#EnergyDeteils').hide();

       <%-- $("[id*=<%=rblRenwableEnergyType.ClientID %>]").change(function () {

            if ($(this).val() == '3') {
                $('#EnergyDeteils').show();

            }
            else {
                $('#EnergyDeteils').hide();
            }
            return false;
        });--%>

        var current_fs, next_fs, previous_fs; //fieldsets
        var opacity;
        var current = 1;
        var steps = $("fieldset").length;
        var step1validResult = false;
        var step2validResult = false;
        var step3validResult = false;
        var step4validResult = false;

        if ($('#<%= hdnstep4.ClientID %>').val() != "1") {
            current = 1;
        }
        else {
            current = 4;
        }

        setProgressBar(current);

        //var current_fs, next_fs, previous_fs; //fieldsets
        //var opacity;
        //var current = 1;
        //var steps = $("fieldset").length;
        //var step1validResult = false;
        //var step2validResult = false;
        //var step3validResult = false;
        //var step4validResult = false;

        //setProgressBar(current);
        $(".next").click(function () {
            current_fs = $(this).parent();


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

            //===================== *** Add Class Active ***  =====================             
            $("#progressbar2 li").eq($("fieldset").index(next_fs)).addClass("active");
            $("#progressbar2 li").eq($("fieldset").index(current_fs)).removeClass("active");
            $("#progressbar2 li").eq($("fieldset").index(current_fs)).addClass("activebg");

            // ===================== *** show the next fieldset ***  =====================
            next_fs.show();
            // ===================== *** hide the current fieldset with style ***  =====================
            current_fs.animate({ opacity: 0 }, {
                step: function (now) {
                    // ===================== *** for making fielset appear animation ***  =====================
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

            // ===================== *** Remove class active ***  =====================

            $("#progressbar2 li").eq($("fieldset").index(current_fs)).removeClass("active");
            $("#progressbar2 li").eq($("fieldset").index(previous_fs)).addClass("active");
            $("#progressbar2 li").eq($("fieldset").index(current_fs)).removeClass("activebg");
            // ===================== *** show the previous fieldset
            previous_fs.show();

            // ===================== *** hide the current fieldset with style  ***  =====================
            current_fs.animate({ opacity: 0 }, {
                step: function (now) {
                    // ===================== *** for making fielset appear animation ***  =====================
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
            debugger;
            var percent = parseFloat(100 / steps) * curStep;
            percent = percent.toFixed();
            $(".progress-bar")
                .css("width", percent + "%")
            // ===================== *** to scroll top of page ***  =====================
            window.scrollTo(0, 500);
        }
        function step1Valid() {

        }

       function step2Valid() {

           var UserTypeVal = false;
           if ($('#<%= ddlUSerType.ClientID %> option:selected').val() == "0") {
               $('#<%= ddlUSerType.ClientID %>').css('border', '1px solid red');
            }
           else {
                    $('#<%= ddlUSerType.ClientID %>').css('border', 'none');
                    UserTypeVal = true;
           }

           if (UserTypeVal == true) {
               step2validResult = true;
           }
           else {
               step2validResult = false;
           }

            
        }
        //-------------------------------------------------------------------------
        function step3Valid() {


            var ACVal = false;
            var DCVal = false;

            var FileUpload1 = false;
            var FileUpload1 = false;
            var FileUpload3 = false;
            var FileUpload4 = false;


            if ($('#<%= txtACVal.ClientID %>').val().trim() != '') {

                $('#<%= txtACVal.ClientID %>').css('border', 'none');
                    ACVal = true;
                }
                else {

                    $('#<%= txtACVal.ClientID %>').css('border', '1px solid red');
            }


            if ($('#<%= txtDCVal.ClientID %>').val().trim() != '') {

                $('#<%= txtDCVal.ClientID %>').css('border', 'none');
                DCVal = true;
            }
                else {

                $('#<%= txtDCVal.ClientID %>').css('border', '1px solid red');
            }

                //------------------------------------------------------------------
                var inp1 = document.getElementById('fileuploadfield_1');
                if (inp1.files.length === 0) {

                $("#file_error1").html("الرجاء اختيار الملف");
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

                $("#file_error2").html("الرجاء اختيار الملف");
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
                var falsecountforDegree = 0;
                var falsecountforNoUnit = 0;
                var Divice1 = false;
                var DiviceUnit1 = false;
                var rowcount = $("#<%=hdnDeviceRowloopCount.ClientID%>").val();
                if (rowcount == "") {
                if ($("#ddlDivice_1").val() == 0) {
                    falsecountforDegree += 1;
                    $("#ddlDivice_1").css('border', '1px solid red');
                }
                else {
                    $("#ddlDivice_1").css('border', 'none');
                    Divice1 = true;
                }
            }
                for (var i = 1; i < rowcount; i++) {
                var isInArray = arrayVal.includes(i);
                if (isInArray == true) {


                    var dynamicdegree = $("#ddlDivice_" + i).val();
                    if (dynamicdegree != 0) {
                        Divice1 = true;
                        $("#ddlDivice_" + i).css('border', 'none');
                    }
                    else {
                        falsecountforDegree += 1;
                        $("#ddlDivice_" + i).css('border', '1px solid red');
                    }

                }
            }
                //==============================================================

                //Mandetory of No Unit for Device
                if (rowcount == "") {
                if ($("#txtdeviceNoUnit_1").val() == "") {
                    falsecountforNoUnit += 1;
                    $("#txtdeviceNoUnit_1").css('border', '1px solid red');
                }
                else {
                    $("#txtdeviceNoUnit_1").css('border', 'none');
                    DiviceUnit1 = true;
                }
            }
                for (var i = 1; i < rowcount; i++) {
                var isInArray = arrayVal.includes(i);
                if (isInArray == true) {


                    var dynamicdegree = $("#txtdeviceNoUnit_" + i).val();
                    if (dynamicdegree != "") {
                        DiviceUnit1 = true;
                        $("#txtdeviceNoUnit_" + i).css('border', 'none');
                    }
                    else {
                        falsecountforNoUnit += 1;
                        $("#txtdeviceNoUnit_" + i).css('border', '1px solid red');
                    }

                }
            }
                //=================================================================

                var falsecountforSoler = 0;
                var falsecountforSolerUnit = 0;
                var Solar1 = false;
                var Solar1unit = false;
            var rowSolarcount = $("#<%=hdnSollerRowloopCount.ClientID%>").val();
            if (rowSolarcount == "") {
                if ($("#ddlSolarcell_1").val() == 0) {
                    falsecountforSoler += 1;
                    $("#ddlSolarcell_1").css('border', '1px solid red');
                }
                else {
                    $("#ddlSolarcell_1").css('border', 'none');
                    Solar1 = true;
                }
            }
            for (var i = 1; i < rowSolarcount; i++) {

                var isInArray = arrayValSolerCell.includes(i);
                if (isInArray == true) {
                    var dynamicdegree = $("#ddlSolarcell_" + i).val();
                    if (dynamicdegree != 0) {
                        Solar1 = true;
                        $("#ddlSolarcell_" + i).css('border', 'none');
                    }
                    else {
                        falsecountforSoler += 1;
                        $("#ddlSolarcell_" + i).css('border', '1px solid red');
                    }
                }


            }

            //===========================

            if (rowSolarcount == "") {
                if ($("#txtSellNoUnit_1").val() == "") {
                    falsecountforSolerUnit += 1;
                    $("#txtSellNoUnit_1").css('border', '1px solid red');
                }
                else {
                    $("#txtSellNoUnit_1").css('border', 'none');
                    Solar1unit = true;
                }
            }
            for (var i = 1; i < rowSolarcount; i++) {

                var isInArray = arrayValSolerCell.includes(i);
                if (isInArray == true) {
                    var dynamicdegree = $("#txtSellNoUnit_" + i).val();
                    if (dynamicdegree != "") {
                        Solar1unit = true;
                        $("#txtSellNoUnit_" + i).css('border', 'none');
                    }
                    else {
                        falsecountforSolerUnit += 1;
                        $("#txtSellNoUnit_" + i).css('border', '1px solid red');
                    }
                }


            }

            //==================================

            debugger;
            if (ACVal == true && DCVal == true && FileUpload1 == true && FileUpload2 == true && falsecountforDegree == 0 && falsecountforNoUnit == 0 && Divice1 == true && DiviceUnit1 == true
                && falsecountforSoler == 0 && Solar1 == true && falsecountforSolerUnit == 0 && Solar1unit == true
            ) {
                step3validResult = true;
            }
            else {
                step3validResult = false;
            }
            
            


            

        }
        function step4Valid() {

           

        }

       <%-- if ($('#<%=rblRenwableRequest.ClientID %> input:checked').val() == "3") {

            $("#RenwableRequest1Step1").hide();
            $("#RenwableRequest3Step1").show();

            $("#RenwableRequest1Step2").hide();
            $("#RenwableRequest3Step2").show();

            $("#RenwableRequest1Step3").hide();
            $("#RenwableRequest3Step3").show();

            $("#RenwableRequest1Step4").hide();
            $("#RenwableRequest3Step4").show();

            $("#Li1").html(' صاحب الطلب');
            $("#Li2").html('معلومات المواقع');
            $("#Li3").html('معلومات الاشتراك ');
            $("#Li4").html('المرفقات ');
            $("#Li5").html('اقرار مقدم الطلب');
            $("#lbldetailsfiedld5").html('أقر بأن المعلومات الواردة في هذا الطلب صحيحةوأوافق على الالتزام ببنود وشروط اتفاقية ربط نظم مصادر الطاقة المتجددة.');
            
        }--%>

    });

    var DeViceCount = 2;
    function GetADDNewRow() {

        var divdata3 = '<div class="row" id="DiviceDivID_' + DeViceCount + '">' +
            '<div class="col-lg-3 col-md-3 col-sm-3">' +
            '<div class="form-group">' +
            '<label>نوع جهاز العكس</label>' +
            '<select id="ddlDivice_' + DeViceCount + '" class="form-control ddldevicedrop" data-filename="' + DeViceCount + '" name="ddlDivice_' + DeViceCount + '"></select>' +
            '<input type="text" id="txtdeviceName_' + DeViceCount + '" name="txtdeviceName_' + DeViceCount + '" style="display:none">' +
            '</div>' +
            '</div>' +

            '<div class="col-lg-2 col-md-2 col-sm-2">' +
            '<div class="form-group">' +
            '<label>الموديل</label>' +
            '<select id="ddlDiviceModel_' + DeViceCount + '" class="form-control ddldevicedropModel" data-filename="' + DeViceCount + '" name="ddlDiviceModel_' + DeViceCount + '"></select>' +
            '<input type="text" id="txtModelNo_' + DeViceCount + '" name="txtModelNo_' + DeViceCount + '" placeholder="الموديل" class="input_number" readonly style="display:none">' +
            '</div>' +
            '</div>' +

            '<div class="col-lg-2 col-md-2 col-sm-3">' +
            '<div class="form-group">' +
            '<label>قدرة جهاز العكس </label>' +
            '<input type="text" id="txtdevice_' + DeViceCount + '" name="txtdevice_' + DeViceCount + '" placeholder="قدرة جهاز العكس" class="input_number" readonly>' +
            '</div>' +
            '</div>' +




            '<div class="col-lg-2 col-md-2 col-sm-3">' +
            '<div class="form-group">' +
            '<label>عدد أجهزة العكس </label>' +
            '<input type="text" id="txtdeviceNoUnit_' + DeViceCount + '" name="txtdeviceNoUnit_' + DeViceCount + '" class="mobileNo LTR" placeholder="ادخل عدد أجهزة العكس">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-3">' +
            ' <div class="Add_device">' +
            '<input type="text" id="txtdeviceDocument_' + DeViceCount + '" name="txtdeviceDocument_' + DeViceCount + '" style="display:none">' +
            '<a href="javascript:void(0);" id="ahref_' + DeViceCount + '" >' +
            '<img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">' +
            '</a>' +
            '<a href="javascript:void(0)" onclick="GetADDNewRow();">' +
            '<i class="lni lni-plus"></i>اضافة جهاز</a>' +
            '<div id="DeleteDeviceDiv' + DeViceCount + '">' +
            '<a href="javascript:void(0)" class="remove_document" onclick="RemoveDivice(' + DeViceCount + ')"><i class="fa fa-Remove"></i>ازالة</a>' +
            '</div>' +
            '</div>' +
            '</div></div>';


        $("#divDeviceInfo").append(divdata3);
        arrayVal.push(DeViceCount);
        GetDeviceData(DeViceCount);

        DeViceCount = DeViceCount + 1;

        $("#<%=hdnDeviceRowloopCount.ClientID%>").val(DeViceCount.toString());

        for (var i = 0; i < DeViceCount; i++) {
            var nwKey = i - 1;
            if (nwKey != DeViceCount) {

                $("#DeleteDeviceDiv" + nwKey).hide();
            }
        }

        //alert(newDeViceCount);

        ////$("#DeleteDeviceDiv" + newDeViceCount).hide();
        //$("#DeleteDeviceDiv" + newDeViceCount).removeClass("ShowThisDivDivice");
        //$("#DeleteDeviceDiv" + newDeViceCount).addClass("HiddenThisDivDivice");
        //$(".HiddenThisDivDivice").hide();



    }

   <%-- function CloseDevicePopup() {
        debugger;
        $('#<%=ModalPopupExtender1.ClientID  %>').hide();
    }--%>

    function GetDeviceData(DeViceCount) {

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindDeivcetoDropdown",
            url: "/Default.aspx/BindDeivcetoDropdownByDistingCompanName",

            data: "{}",
            success: function (result) {
                $("#ddlDivice_" + DeViceCount).append("<option value='0'>الرجاء اختيار جهاز العكس</option>");
                $.each(result.d, function (key, value) {

                    //$("#ddlDivice_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.CompanyName + " " + value.ModelNo));
                    $("#ddlDivice_" + DeViceCount).append($("<option></option>").val(value.CompanyName).html(value.CompanyName));

                });
            },
            error: function (result) {
                alert(result.status + " : " + result.StatusText);
            }
        });
    }

    var SellRowCount = 2;
    function GetADDNewSollerCell() {

        var divdata4 = '<div class="row" id="SolerCellDivID_' + SellRowCount + '">' +
            '<div class="col-lg-3 col-md-3 col-sm-3">' +
            '<div class="form-group">' +
            '<label>نوع الخلايا الشمسية</label>' +
            '<select id="ddlSolarcell_' + SellRowCount + '" class="form-control ddlSolerdrop" data-filename="' + SellRowCount + '" name="ddlSolarcell_' + SellRowCount + '"></select>' +
            '<input type="text" id="txtSolarcellName_' + SellRowCount + '" name="txtSolarcellName_' + SellRowCount + '" style="display:none">' +
            '</div>' +
            '</div>' +


            '<div class="col-lg-2 col-md-2 col-sm-3">' +
            '<div class="form-group">' +
            '<label>الموديل</label>' +
            '<select id="ddlSollerCellModel_' + SellRowCount + '" class="form-control ddlSollerCelldropModel" data-filename="' + SellRowCount + '" name="ddlSollerCellModel_' + SellRowCount + '"></select>' +
            '<input type="text" placeholder="الموديل" id="txtModelSollerCell_' + SellRowCount + '" name="txtModelSollerCell_' + SellRowCount + '" class="input_number" readonly style="display:none">' +
            '</div>' +
            '</div>' +
            ' <div class="col-lg-2 col-md-2 col-sm-3">' +
            '<div class="form-group">' +
            '<label>قدرة الخلايا  </label>' +
            '<input type="text" placeholder="قدرة الخلايا " id="txtSollerCell_' + SellRowCount + '" name="txtSollerCell_' + SellRowCount + '" class="input_number" readonly>' +
            ' </div>' +
            '</div>' +
            '<div class="col-lg-2 col-md-2 col-sm-3">' +
            '<div class="form-group">' +
            '<label>عدد الخلايا  </label>' +

            '<input type="text" id="txtSellNoUnit_' + SellRowCount + '" name="txtSellNoUnit_' + SellRowCount + '" class="mobileNo LTR"  placeholder="عدد الخلايا   ">' +
            '</div>' +
            '</div>' +
            '<div class="col-lg-3 col-md-3 col-sm-3">' +
            '<div class="Add_device">' +
            '<input type="text" id="txtSolarcellDocument_' + SellRowCount + '" name="txtSolarcellDocument_' + SellRowCount + '" style="display: none">' +
            '<a href="javascript:void(0);" id="aSolarhref_' + SellRowCount + '">' +

            '<img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">' +
            '</a>' +
            '<a href="javascript:void(0)" onclick="GetADDNewSollerCell();">' +
            '<i class="lni lni-plus"></i>اضافة خلايا </a>' +
            '<div id="DeleteSolerDiv' + SellRowCount + '">' +
            '<a href="javascript:void(0)" class="remove_document" onclick="RemoveSollerCell(' + SellRowCount + ')"><i class="fa fa-Remove"></i>ازالة</a>' +
            '</div>'
        '</div>' +
            '</div>' +
            ' </div>';

        $("#divSollerCellDiv").append(divdata4);
        arrayValSolerCell.push(SellRowCount);
        GetSellData(SellRowCount);
        SellRowCount = SellRowCount + 1;
        $("#<%=hdnSollerRowloopCount.ClientID%>").val(SellRowCount.toString());


        for (var i = 0; i < SellRowCount; i++) {
            var nwKey = i - 1;
            if (nwKey != SellRowCount) {

                $("#DeleteSolerDiv" + nwKey).hide();
            }
        }
    }
    function RemoveDivice(b) {
        var itemId1 = "DiviceDivID_" + b;
        //alert(itemId1);

        if (b != 2) {
            var PreId = $("#" + itemId1).prev().closest('.row').attr("id");
            if (PreId != null) {
                var newmystring = PreId.split('_')[1];
                $("#DeleteDeviceDiv" + newmystring).show();
            }
        }

        $("#" + itemId1).remove();
        removeItem(arrayVal, b);

    }
    function removeItem(array, item) {

        for (var i in array) {
            if (array[i] == item) {
                array.splice(i, 1);
                break;
            }
        }
    }
    function RemoveSollerCell(b) {


        var itemId1 = "SolerCellDivID_" + b;

        if (b != 2) {
            var PreId = $("#" + itemId1).prev().closest('.row').attr("id");
            if (PreId != null) {
                var newmystring = PreId.split('_')[1];
                $("#DeleteSolerDiv" + newmystring).show();
            }
        }

        $("#" + itemId1).remove();

        removeItem(arrayValSolerCell, b);
    }
    function GetSellData(SellRowCount) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindSelltoDropdown",
            url: "/Default.aspx/BindSollerCelltoDropdownByDistingCompanName",
            data: "{}",
            success: function (result) {

                $("#ddlSolarcell_" + SellRowCount).append("<option value='0'>الرجاء اختيار الخلايا الشمسية</option>");
                $.each(result.d, function (key, value) {
                    $("#ddlSolarcell_" + SellRowCount).append($("<option></option>").val(value.CompanyName).html(value.CompanyName));
                });
            },
            error: function (result) {
                console.log(result);

                alert(result.status + " : " + result.StatusText);
            }
        });
    }



    //28102020 start

    var LocationRowCount = 2;
    function AddLocation() {

        var divdata3 = 
            '<div id="LocationDiv_' + LocationRowCount + '">'+
                '<div class="row">'+
                    '<div class="col-lg-3 col-md-3 col-sm-3">'+
                        '<div class="form-group">'+
                            '<label>الموقع</label>'+
        '<input type="text" id="txtLocationName_' + LocationRowCount + '" name="txtLocationName_' + LocationRowCount +'" placeholder="الموقع">'+
                                '</div>'+
                        '</div>'+
                        '<div class="col-lg-3 col-md-3 col-sm-3">'+
                            '<div class="form-group">'+
                                '<label>المحافظة</label>'+
        '<input type="text" id="txtGovernate_' + LocationRowCount + '" name="txtGovernate_' + LocationRowCount + '" placeholder="المحافظة">'+
                                '</div>'+
                            '</div>'+
                            '<div class="col-lg-2 col-md-2 col-sm-2">'+
                                '<div class="form-group">'+
                                    '<label>المديرية</label>'+
            '<input type="text" id="txtArea1_' + LocationRowCount + '" name="txtArea1_' + LocationRowCount + '" placeholder="المديرية">'+
                                '</div>'+
                                '</div>'+
                                '<div class="col-lg-2 col-md-2 col-sm-2">'+
                                    '<div class="form-group">'+
                                       ' <label>القرية</label>'+
        '<input type="text" id="txtArea2_' + LocationRowCount + '" name="txtArea2_' + LocationRowCount + '" placeholder="القرية">'+
                                '</div>'+
                                    '</div>'+
                                    '<div class="col-lg-2 col-md-2 col-sm-2">'+
                                        '<div class="form-group">'+
                                            '<label>الحوض</label>'+
        '<input type="text" id="txtArea3_' + LocationRowCount + '" name="txtArea3_' + LocationRowCount + '" placeholder="الحوض">'+
                                '</div>'+
                                        '</div>'+
                                   ' </div>'+
                                    '<div class="row">'+
                                        '<div class="col-lg-3 col-md-3 col-sm-3">'+
                                            '<div class="form-group">'+
                                                '<label>رقم القطعة</label>'+
        '<input type="text" id="txtAreaNumber_' + LocationRowCount + '" name="txtAreaNumber_' + LocationRowCount + '" placeholder="رقم القطعة">'+
                                '</div>'+
                                            '</div>'+
                                            '<div class="col-lg-3 col-md-3 col-sm-3">'+
                                                '<div class="form-group">'+
                                                    '<label>Longitude</label>'+
        '<input type="text" id="txtLongitude_' + LocationRowCount + '" name="txtLongitude_' + LocationRowCount + '" placeholder="Longitude">'+
                                '</div>'+
                                                '</div>'+
                                                '<div class="col-lg-3 col-md-3 col-sm-3">'+
                                                   ' <div class="form-group">'+
                                                        '<label>Latitude</label>'+
        '<input type="text" id="txtLatitude_' + LocationRowCount + '" name="txtLatitude_' + LocationRowCount + '" placeholder="Latitude">'+
                                '</div>'+
                                                    '</div>'+
                                                   ' <div class="col-lg-3 col-md-3 col-sm-3">'+
                                                        '<a href="javascript:void(0)" onclick="AddLocation();">'+
            '<i class="lni lni-plus"></i>اضافة جهاز</a>' +
            '<a href="javascript:void(0)" class="remove_document" onclick="RemoveLocation(' + LocationRowCount + ')">'+
                '<i class="fa fa-Remove"></i>ازالة</a>'+
                                                    '</div>'+
                                               ' </div>'+
                                           ' </div>';


        $("#divAddeRowLocation").append(divdata3);
        arrayLocationCount.push(LocationRowCount);
        //GetDeviceData(DeViceCount);

        LocationRowCount = LocationRowCount + 1;

       <%-- $("#<%=hdnLocationCount.ClientID%>").val(LocationRowCount.toString());--%>

        for (var i = 0; i < LocationRowCount; i++) {
            var nwKey = i - 1;
            if (nwKey != LocationRowCount) {

                //$("#DeleteDeviceDiv" + nwKey).hide();
            }
        }
    }

    function RemoveLocation(b) {
        var itemId1 = "LocationDiv_" + b;
        //alert(itemId1);

        //if (b != 2) {
        //    var PreId = $("#" + itemId1).prev().closest('.row').attr("id");
        //    if (PreId != null) {
        //        var newmystring = PreId.split('_')[1];
        //        $("#DeleteDeviceDiv" + newmystring).show();
        //    }
        //}

        $("#" + itemId1).remove();
        removeItem(arrayLocationCount, b);

    }

    var MeterRowCount = 2;    
    function AddMeterRow() {
        debugger;
        var divdata3 =
            '<div id="MeterDiv' + MeterRowCount + '">' +
            '<div class="row">'+
                '<div class="col-lg-4 col-md-4 col-sm-6">'+
                    '<div class="form-group">'+
                        '<label>عدد الاشتراكات</label>'     +                                                                                
        '<input type="text" id="txtNumberofConnection_' + MeterRowCount + '" name="txtNumberofConnection_' + MeterRowCount + '" placeholder="عدد الاشتراكات">'+
                                '</div>'+
                    '</div>'+
                    '<div class="col-lg-4 col-md-4 col-sm-6">'+
                        '<div class="form-group">'+
                           ' <label>اسم المشترك  </label>'+                                  
        ' <input type="text" id="txtNumberofConnectionName_' + MeterRowCount + '" name="txtNumberofConnectionName_' + MeterRowCount + '" placeholder="اسم المشترك">'+
                                '</div>'+
                        '</div>'+
                        '<div class="col-lg-4 col-md-4 col-sm-6">'+
                            '<div class="form-group">'+
                                '<label> رقم العداد </label>'           +                       
        '<input type="text" id="txtMeterNumber_' + MeterRowCount + '" name="txtMeterNumber_' + MeterRowCount + '" placeholder="رقم العداد">'+
                                '</div>'+
                            '</div>'+
                            '<div class="col-lg-4 col-md-4 col-sm-6">'+
                                '<div class="form-group">'+
                                    '<label>رقم الملف </label>'          +                         
        '<input type="text" id="txtFileNumber_' + MeterRowCount + '" name="txtFileNumber_' + MeterRowCount + '" placeholder="رقم الملف">'+
                                '</div>'+
                                '</div>'+
                                '<div class="col-lg-4 col-md-4 col-sm-6">'+
                                    '<div class="form-group">'+
                                       ' <label>عنوان الاشتراك </label>'          +                         
        '<input type="text" id="txtMeterAddress_' + MeterRowCount + '" name="txtMeterAddress_' + MeterRowCount + '" placeholder="عنوان الاشتراك">'+
                                '</div>'+
                                    '</div>'+
                                    '<div class="col-lg-4 col-md-4 col-sm-6">'+
                                        '<a href="javascript:void(0)" onclick="AddMeterRow();">'+
            '<i class="lni lni-plus"></i>اضافة جهاز</a>' +
            '<a href="javascript:void(0)" class="remove_document" onclick="RemoveMeter(' + MeterRowCount + ')">' +
            '<i class="fa fa-Remove"></i>ازالة</a>' +
                                    '</div>'+
            ' </div> </div>';


        $("#divAddeRowMeteStatus").append(divdata3);
        arrayMeterCount.push(MeterRowCount);
        //GetDeviceData(DeViceCount);

        MeterRowCount = MeterRowCount + 1;

        $("#<%=HdnMeterStatus.ClientID%>").val(MeterRowCount.toString());

        for (var i = 0; i < MeterRowCount; i++) {
            var nwKey = i - 1;
            if (nwKey != MeterRowCount) {

                //$("#DeleteDeviceDiv" + nwKey).hide();
            }
        }
    }

    function RemoveMeter(b) {
        var itemId1 = "MeterDiv" + b;
        
        $("#" + itemId1).remove();
        removeItem(arrayMeterCount, b);

    }

    var OthersRowCount = 2;  
    function GetOthersNewRow() {
        debugger;
        var divdata3 =
            '<div class="row" id="otharAddRow_' + OthersRowCount+'">'+
                '<div class="col-lg-3 col-md-3 col-sm-3">'+
                    '<div class="form-group">'+                        
        '<input type="text" id="txtOtherDevice_' + OthersRowCount + '" name="txtOtherDevice_' + OthersRowCount +'">'+
                                '</div>'+
                    '</div>'+
                    '<div class="col-lg-3 col-md-3 col-sm-3">'+
                        '<a href="javascript:void(0)" onclick="GetOthersNewRow();">'+
        '<i class="lni lni-plus"></i>اضافة جهاز</a>'+
        '<a href="javascript:void(0)" class="remove_document" onclick="RemoveOther(' + OthersRowCount + ')">' +
            '<i class="fa fa-Remove"></i>ازالة</a>'+
                    '</div>'+
                '</div>';


        $("#newOtherDiv").append(divdata3);
        arrayOthersCount.push(OthersRowCount);
        //GetDeviceData(DeViceCount);

        OthersRowCount = OthersRowCount + 1;

        $("#<%=hdnOtherCount.ClientID%>").val(OthersRowCount.toString());

        for (var i = 0; i < OthersRowCount; i++) {
            var nwKey = i - 1;
            if (nwKey != OthersRowCount) {

                //$("#DeleteDeviceDiv" + nwKey).hide();
            }
        }
    }

    function RemoveOther(b) {
        var itemId1 = "otharAddRow_" + b;

        $("#" + itemId1).remove();
        removeItem(arrayOthersCount, b);

    }
    
    //28102020 End


</script>

<script type="text/javascript">

    //=================

   <%-- if ($('#<%= hdnstep4.ClientID %>').val() == "1") {
        
        //setProgressBar2(4);
         chageStep3By2(4);
        //return confirm(".json_encode(false).");
    }

    function setProgressBar2(curStep) {
        var steps2 = $("fieldset").length;

        debugger;
        var percent = parseFloat(100 / steps2) * curStep;
        percent = percent.toFixed();
        $(".progress-bar")
            .css("width", percent + "%")
        // ===================== *** to scroll top of page ***  =====================
        window.scrollTo(0, 500);


    }


    function chageStep3By2(id) {

        steps = $("fieldset").length;
        setProgressBar2(4);

        var obj = {};
        obj.id = id;

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
            steps: function (now) {
                debugger;
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
            steps: function (now) {
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
        //$("#s3").show();

    }--%>
    //=========================

</script>

<script>

    //$(".ddldevicedrop").change(function () {
    //     
    //    var filename = $(this).data("filename");
    //    alert(filename);

    //});


    $(document).on("change", ".ddldevicedrop", function () {
        var filename = $(this).data("filename");
        var idThis = $('#ddlDivice_' + filename).val();
        var idThis2 = $('#ddlDivice_' + filename);
        var idThis4 = $(idThis2).find('option:selected').text();
        debugger;
        $("#ddlDiviceModel_" + filename).empty();
        $("#txtdeviceName_" + filename).val(idThis4);
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Default.aspx/BindModelDATAS",
            data: "{Deivceid:'" + idThis + "'}",
            success: function (result) {

                debugger;

                $("#ddlDiviceModel_" + filename).append("<option value='0'>الرجاء اختيار جهاز العكس</option>");
                $.each(result.d, function (key, value) {

                    //$("#ddlDivice_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.CompanyName + " " + value.ModelNo));
                    //$("#ddlDiviceModel_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.ModelNo));
                    //$("#ddlDiviceModel_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.ModelNo));
                    $("#ddlDiviceModel_" + filename).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.ModelNo + "-" + value.DevicePower));

                });

                //console.log(result.d);
                //$("#txtdevice_" + filename).val(result.d.DevicePower);
                //$("#ahref_" + filename).attr("href", result.d.DeviceDocument);
                //$("#ahref_" + filename).attr('target', '_blank');
                //$("#txtdeviceDocument_" + filename).val(result.d.DeviceDocument);
                //$("#txtModelNo_" + filename).val(result.d.ModelNo);
            },
            error: function (result) {
                //alert(result.status + " : " + result.StatusText);
            }
        });
    });

    $(document).on("change", ".ddldevicedropModel", function () {
        debugger;
        var filename = $(this).data("filename");
        var idThis = $('#ddlDiviceModel_' + filename).val();
        var idThis2 = $('#ddlDiviceModel_' + filename);
        var idThis4 = $(idThis2).find('option:selected').text();
        $("#txtdeviceName_" + filename).val(idThis4);
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Default.aspx/BindDeivceDATAS",
            data: "{Deivceid:'" + idThis + "'}",
            success: function (result) {
                debugger;
                console.log(result.d);
                $("#txtdevice_" + filename).val(result.d.DevicePower);
                $("#ahref_" + filename).attr("href", result.d.DeviceDocument);
                $("#ahref_" + filename).attr('target', '_blank');
                $("#txtdeviceDocument_" + filename).val(result.d.DeviceDocument);
                $("#txtModelNo_" + filename).val(result.d.ModelNo);
            },
            error: function (result) {
                //alert(result.status + " : " + result.StatusText);
            }
        });
    });

    //$(document).on("change", ".ddldevicedrop", function () {        
    //    var filename = $(this).data("filename");
    //    var idThis = $('#ddlDivice_' + filename).val();
    //    var idThis2 = $('#ddlDivice_' + filename);
    //    var idThis4 = $(idThis2).find('option:selected').text();        
    //    $("#txtdeviceName_" + filename).val(idThis4);
    //    $.ajax({
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        url: "/Default.aspx/BindDeivceDATAS",
    //        data: "{Deivceid:'" + idThis + "'}",            
    //        success: function (result) {
    //            console.log(result.d);
    //            $("#txtdevice_" + filename).val(result.d.DevicePower);
    //            $("#ahref_" + filename).attr("href", result.d.DeviceDocument);
    //            $("#ahref_" + filename).attr('target', '_blank');
    //            $("#txtdeviceDocument_" + filename).val(result.d.DeviceDocument);
    //            $("#txtModelNo_" + filename).val(result.d.ModelNo);
    //        },
    //        error: function (result) {
    //            //alert(result.status + " : " + result.StatusText);
    //        }
    //    });
    //});


    $(document).on("change", ".ddlSolerdrop", function () {
        debugger;
        var filename = $(this).data("filename");
        var idThis = $('#ddlSolarcell_' + filename).val();
        var idThis2 = $('#ddlSolarcell_' + filename);
        var idThis4 = $(idThis2).find('option:selected').text();
        // $("#txtSolarcellName_" + filename).text(idThis4);
        $("#ddlSollerCellModel_" + filename).empty();
        $("#txtSolarcellName_" + filename).val(idThis4);
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindSolerCellDATAS",
            url: "/Default.aspx/BindModelSollerDATAS",
            data: "{Sollerid:'" + idThis + "'}",
            success: function (result) {
                $("#ddlSollerCellModel_" + filename).append("<option value='0'>الرجاء اختيار جهاز العكس</option>");
                $.each(result.d, function (key, value) {

                    //$("#ddlDivice_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.CompanyName + " " + value.ModelNo));
                    //$("#ddlDiviceModel_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.ModelNo));
                    //$("#ddlDiviceModel_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.ModelNo));
                    $("#ddlSollerCellModel_" + filename).append($("<option></option>").val(value.RenewbleCompnySolarCell).html(value.ModelNo + "-" + value.DevicePower));

                });


                //console.log(result.d);
                //$("#txtSollerCell_" + filename).val(result.d.DevicePower);
                //$("#aSolarhref_" + filename).attr("href", result.d.SolarCellDocument);
                //$("#aSolarhref_" + filename).attr('target', '_blank');
                //$("#txtSolarcellDocument_" + filename).val(result.d.SolarCellDocument);
                //$("#txtModelSollerCell_" + filename).val(result.d.ModelNo);
            },
            error: function (result) {
                // alert(result.status + " : " + result.StatusText);
            }
        });




    });



    $(document).on("change", ".ddlSollerCelldropModel", function () {
        debugger;
        var filename = $(this).data("filename");
        var idThis = $('#ddlSollerCellModel_' + filename).val();
        var idThis2 = $('#ddlSollerCellModel_' + filename);
        var idThis4 = $(idThis2).find('option:selected').text();
        // $("#txtSolarcellName_" + filename).text(idThis4);
        // $("#ddlSollerCellModel_" + filename).empty();
        $("#txtSolarcellName_" + filename).val(idThis4);

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindSolerCellDATAS",
            url: "/Default.aspx/BindSolerCellDATAS",
            data: "{Sollerid:'" + idThis + "'}",
            success: function (result) {
                $("#txtSollerCell_" + filename).val(result.d.DevicePower);
                $("#aSolarhref_" + filename).attr("href", result.d.SolarCellDocument);
                $("#aSolarhref_" + filename).attr('target', '_blank');
                $("#txtSolarcellDocument_" + filename).val(result.d.SolarCellDocument);
                $("#txtModelSollerCell_" + filename).val(result.d.ModelNo);
            },
            error: function (result) {
                // alert(result.status + " : " + result.StatusText);
            }
        });


    });



    
    $(document).on("click", ".loadDevise", function () {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindDeivcetoDropdown",
            url: "/Default.aspx/BindDeivcetoDropdownByDistingCompanName",

            data: "{}",
            success: function (result) {

                $("#ddlDivice_1").empty();

                $("#ddlDivice_1").append("<option value='0'>الرجاء اختيار جهاز العكس</option>");
                $.each(result.d, function (key, value) {

                    //$("#ddlDivice_" + DeViceCount).append($("<option></option>").val(value.RenewbleCompnyDevice).html(value.CompanyName + " " + value.ModelNo));
                    $("#ddlDivice_1").append($("<option></option>").val(value.CompanyName).html(value.CompanyName));

                });
            },
            error: function (result) {
                alert(result.status + " : " + result.StatusText);
            }
        });
    });

    
    $(document).on("click", ".loadSoller", function () {

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            //url: "/Default.aspx/BindSelltoDropdown",
            url: "/Default.aspx/BindSollerCelltoDropdownByDistingCompanName",
            data: "{}",
            success: function (result) {

                $("#ddlSolarcell_1").append("<option value='0'>الرجاء اختيار الخلايا الشمسية</option>");
                $.each(result.d, function (key, value) {
                    $("#ddlSolarcell_1").append($("<option></option>").val(value.CompanyName).html(value.CompanyName));
                });
            },
            error: function (result) {
                console.log(result);

                alert(result.status + " : " + result.StatusText);
            }
        });
    });


    //$(document).on("change", ".ddlSolerdrop", function () {


    //    //do something
    //    var filename = $(this).data("filename");
    //    var idThis = $('#ddlSolarcell_' + filename).val();



    //    var idThis2 = $('#ddlSolarcell_' + filename);
    //    var idThis4 = $(idThis2).find('option:selected').text();
    //    // $("#txtSolarcellName_" + filename).text(idThis4);
    //    $("#txtSolarcellName_" + filename).val(idThis4);

    //    //$.ajax({
    //    //    type: "POST",
    //    //    contentType: "application/json; charset=utf-8",
    //    //    url: "/Default.aspx/BindSolerCellTextBox",
    //    //    data: "{Sollerid:'" + idThis + "'}",
    //    //    //data: "{}",
    //    //    success: function (result) {
    //    //        console.log(result.d);
    //    //        $("#txtSollerCell_" + filename).val(result.d);
    //    //    },
    //    //    error: function (result) {
    //    //        // alert(result.status + " : " + result.StatusText);
    //    //    }
    //    //});

    //    $.ajax({
    //        type: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        url: "/Default.aspx/BindSolerCellDATAS",
    //        data: "{Sollerid:'" + idThis + "'}",
    //        //data: "{}",
    //        success: function (result) {
    //            console.log(result.d);
    //            $("#txtSollerCell_" + filename).val(result.d.DevicePower);
    //            $("#aSolarhref_" + filename).attr("href", result.d.SolarCellDocument);
    //            $("#aSolarhref_" + filename).attr('target', '_blank');
    //            $("#txtSolarcellDocument_" + filename).val(result.d.SolarCellDocument);
    //            $("#txtModelSollerCell_" + filename).val(result.d.ModelNo);

    //        },
    //        error: function (result) {
    //            // alert(result.status + " : " + result.StatusText);
    //        }
    //    });




    //});

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

        //=================================

        $('#fileuploadCross_1').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_1');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error1").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_1').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_1')[0].files[0].name;
                $('#fileuploadCross_1').next().html(abcd);
                $("#fileCross_error1").html("");
            }

        });

        $('#fileuploadCross_2').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_2');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error2").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_2').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_2')[0].files[0].name;
                $('#fileuploadCross_2').next().html(abcd);
                $("#fileCross_error2").html("");
            }

        });

        $('#fileuploadCross_3').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_3');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error3").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_3').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_3')[0].files[0].name;
                $('#fileuploadCross_3').next().html(abcd);
                $("#fileCross_error3").html("");
            }

        });

        $('#fileuploadCross_4').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_4');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error4").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_4').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_4')[0].files[0].name;
                $('#fileuploadCross_4').next().html(abcd);
                $("#fileCross_error4").html("");
            }

        });

        $('#fileuploadCross_5').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_5');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error5").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_5').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_5')[0].files[0].name;
                $('#fileuploadCross_5').next().html(abcd);
                $("#fileCross_error5").html("");
            }

        });

        $('#fileuploadCross_6').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_6');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error6").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_6').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_6')[0].files[0].name;
                $('#fileuploadCross_6').next().html(abcd);
                $("#fileCross_error6").html("");
            }

        });

        $('#fileuploadCross_7').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_7');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error7").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_7').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_7')[0].files[0].name;
                $('#fileuploadCross_7').next().html(abcd);
                $("#fileCross_error7").html("");
            }

        });

        $('#fileuploadCross_8').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_8');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error8").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_8').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_8')[0].files[0].name;
                $('#fileuploadCross_8').next().html(abcd);
                $("#fileCross_error8").html("");
            }

        });

        $('#fileuploadCross_9').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_9');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error9").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_9').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_9')[0].files[0].name;
                $('#fileuploadCross_9').next().html(abcd);
                $("#fileCross_error9").html("");
            }

        });

        $('#fileuploadCross_10').change(function (e) {

            var fileInput1 = document.getElementById('fileuploadCross_10');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#fileCross_error10").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadCross_10').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadCross_10')[0].files[0].name;
                $('#fileuploadCross_10').next().html(abcd);
                $("#fileCross_error10").html("");
            }

        });


        //===================================

        $('#fileuploadfieldDevice_1').change(function (e) {
            debugger;
            var fileInput1 = document.getElementById('fileuploadfieldDevice_1');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_errorDevice1").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfieldDevice_1').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfieldDevice_1')[0].files[0].name;
                $('#fileuploadfieldDevice_1').next().html(abcd);

                $("#fileuploadfieldDevice_1 > span").text(abcd);
                $("#file_errorDevice1").html("");
            }
        });

        $('#fileuploadfieldDevice_2').change(function (e) {
            //$in = $(this);
            //var abcd = $in[0].files[0].name;
            //$in.next().html(abcd);


            var fileInput1 = document.getElementById('fileuploadfieldDevice_2');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_errorDevice2").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfieldDevice_2').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfieldDevice_2')[0].files[0].name;
                $('#fileuploadfieldDevice_2').next().html(abcd);
                $("#file_errorDevice2").html("");
            }

        });

        $('#fileuploadfieldDevice_3').change(function (e) {
            //$in = $(this);
            //var abcd = $in[0].files[0].name;
            //$in.next().html(abcd);


            var fileInput1 = document.getElementById('fileuploadfieldDevice_3');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_errorDevice3").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfieldDevice_3').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfieldDevice_3')[0].files[0].name;
                $('#fileuploadfieldDevice_3').next().html(abcd);
                $("#file_errorDevice3").html("");
            }

        });

        $('#fileuploadfieldDevice_4').change(function (e) {
            //$in = $(this);
            //var abcd = $in[0].files[0].name;
            //$in.next().html(abcd);


            var fileInput1 = document.getElementById('fileuploadfieldDevice_4');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_errorDevice4").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfieldDevice_4').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfieldDevice_4')[0].files[0].name;
                $('#fileuploadfieldDevice_4').next().html(abcd);
                $("#file_errorDevice4").html("");
            }

        });
        //=====================================

        $('#fileuploadfieldSoller_1').change(function (e) {


            var fileInput1 = document.getElementById('fileuploadfieldSoller_1');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_errorSoller1").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfieldSoller_1').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfieldSoller_1')[0].files[0].name;
                $('#fileuploadfieldSoller_1').next().html(abcd);
                $("#file_errorSoller1").html("");
            }

        });

        $('#fileuploadfieldSoller_2').change(function (e) {


            var fileInput1 = document.getElementById('fileuploadfieldSoller_2');
            var filePath1 = fileInput1.value;   // Allowing file type           
            var allowedExtensions1 =
                /(\.pdf|\.doc|\.docx|\.jpg|\.jpeg)$/i; //PDF, doc, and docx.            
            if (!allowedExtensions1.exec(filePath1)) {
                $("#file_errorSoller2").html("Invalid file type");
                fileInput1.value = '';
                $('#fileuploadfieldSoller_2').next().html("");
                return false;
            }
            else {
                // $in = $(this);
                var abcd = $('#fileuploadfieldSoller_2')[0].files[0].name;
                $('#fileuploadfieldSoller_2').next().html(abcd);
                $("#file_errorSoller2").html("");
            }

        });

        //===================================

    });

</script>


<style>
    .companyorder label.file-upload__label {
        padding: 8px 15px;
        color: #fff;
        background: #007fc3;
        width: 200px;
        display: flex;
        align-items: center;
        justify-content: space-between;
        cursor: pointer;
    }

    .modalPopup label.file-upload__label {
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

   /* input[type="file"] {
        display: none;
    }*/

    .Device_description,
    .file-upload {
        display: inline-block;
        vertical-align: middle;
    }

    .Device_description {
        padding-bottom: 25px;
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

    .custom_radio span {
        color: #007fc3;
        font-weight: bold;
        margin-right: 20px;
    }


    .steplist li a {
        font-size: 14px;
    }


    .steplist li:first-child::before {
        border-bottom: 60px solid #007fc3;
    }

    .steplist li::after {
        border-top: 60px solid #ffde23;
    }

    .steplist li:last-child::before {
        border-bottom: 60px solid #f2f2f2;
    }

    .steplist li::before {
        border-bottom: 60px solid #ffde23;
    }

    .steplist li:last-child.active::before {
        border-bottom: 60px solid #ffde23;
    }
</style>


<script>
    function SendClick() {

        var UserTypeVal = false;

       <%-- if ($('#<%=rblRenwableRequest.ClientID %> input:checked').val() == "3") {
            UserTypeVal = true;
        }
        else {
            if ($('#<%= ddlUSerType.ClientID %> option:selected').val() == "0") {
                $('#<%= ddlUSerType.ClientID %>').css('border', '1px solid red');
        }
        else {
                $('#<%= ddlUSerType.ClientID %>').css('border', 'none');
                UserTypeVal = true;
            }
        }

        if (UserTypeVal == true) {
            
        }--%>
        $("[id*=<%=btnSubmit.ClientID %>]").click();

    }

    



</script>

<script>
    $(".mobileNo").keypress(function (e) {

        //if the letter is not digit then display error and don't type anything
        //if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {            
        //    return false;
        //}
        //else {
        //    var len = $(".mobileNo").val().length;            
        //}
        debugger;
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }

    });


    $(document).on("keypress", ".mobileNo", function (e) {

        //if the letter is not digit then display error and don't type anything
        //if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
        //    return false;
        //}
        //else {
        //    var len = $(".mobileNo").val().length;            
        //}
        debugger;
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }


    });

    $(document).on("click", "#btbDeviceValid2", function () {
        SendClickDevice();
    });

    //$(document).on("keypress", "#ContentPlaceHolder1_ctl00_txtCompanyName", function () {
    //    //var ajsdhj = $("#ContentPlaceHolder1_ctl00_txtCompanyName").val();
    //    //alert(ajsdhj);

    //    var textFieldVal = $('input[name="ctl00$ContentPlaceHolder1$ctl00$txtCompanyName"]').val();

    //    alert(textFieldVal);
    //});


    $(document).on("click", "#btbSolerValid2", function () {
        SendClickSoller();
    });

    



</script>

<script type="text/javascript">
    function uploadStarted() {
        $get("imgDisplay").style.display = "none";
    }
    function uploadComplete(sender, args) {
        var imgDisplay = $get("imgDisplay");
        imgDisplay.src = "images/loader.gif";
        imgDisplay.style.cssText = "";
        var img = new Image();
        img.onload = function () {
            imgDisplay.style.cssText = "height:100px;width:100px";
            imgDisplay.src = img.src;
        };
        <%--img.src = "<%=ResolveUrl(UploadFolderPath) %>" + args.get_fileName();--%>
    }
</script>