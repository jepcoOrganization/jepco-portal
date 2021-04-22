<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnergyRequestDetails.ascx.cs" Inherits="Controls_EnergyRequestDetails" %>

<div>

    <!-- Nav tabs -->
    <ul class="nav nav-tabs energyrequest_tab" role="tablist">
        <li role="presentation" class="active"><a href="#Order_details" aria-controls="Order_details" role="tab" data-toggle="tab">تفاصيل الطلب</a></li>
        <li role="presentation"><a href="#Working_procedures" aria-controls="Working_procedures" role="tab" data-toggle="tab">اجراءات العمل</a></li>

    </ul>

    <!-- Tab panes -->
    <div class="tab-content energyrequest_tabcontent">
        <div role="tabpanel" class="tab-pane fade in active" id="Order_details">
            <ul class="list-unstyled">
                <li>
                    <strong>تاريخ الطلب</strong>
                    <%--<span>٢٥ نيسان ٢٠٢٠</span>--%>
                    <asp:Literal ID="lbldate" runat="server"></asp:Literal>
                </li>
                 <li>
                    <strong>نوع الطلب</strong>
                   <%-- <span>الجبيهة - شفابدران</span>--%>
                     <asp:Literal ID="lblENGType" runat="server"></asp:Literal>
                </li>
                 <li>
                    <strong>رقم الطلب / رقم العداد</strong>
                   <%-- <span class="LTR"><b>2798564398222</b></span>--%>
                    <asp:Literal ID="lblRefenceNo" runat="server"></asp:Literal>
                </li>

                  <li>
                    <strong>حالة العداد</strong>
                   <%-- <span class="LTR"><b>2798564398222</b></span>--%>
                    <asp:Literal ID="lblMeterStus" runat="server"></asp:Literal>
                </li>
                <li>
                    <strong>رقم الطلب / رقم العداد</strong>
                   <%-- <span class="LTR"><b>2798564398222</b></span>--%>
                    <asp:Literal ID="lblName" runat="server"></asp:Literal>
                </li>

            </ul>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <label>اسم صاحب الطلب</label>
                        <asp:TextBox ID="txtFirstNAme" runat="server" PlaceHolder="شركة الافاق المتجددة للتكنولوجيا" disabled="disabled"></asp:TextBox>
                        <%--   <input type="text" placeholder="شركة الافاق المتجددة للتكنولوجيا">--%>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>الرقم الوطني لصاحب الطلب </label>
                        <input type="text" placeholder="2798564398222" class="input_number">
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>رقم هاتف صاحب الطلب </label>
                        <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="رقم هاتف الشركة " disabled="disabled"></asp:TextBox>
                        <%-- <input type="text" placeholder="0798568222" class="input_number">--%>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>البريد الالكتروني لصاحب الطلب </label>
                        <asp:TextBox ID="txtemail" runat="server" PlaceHolder="البريد الالكتروني لصاحب الطلب" disabled="disabled"></asp:TextBox>
                        <%--  <input type="text" placeholder="lkgsd@hotmail.com" class="input_number">--%>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>قدرة النظام <span class="LTR">AC</span> </label>
                        <asp:TextBox ID="txtACPower" runat="server" PlaceHolder="البريد الالكتروني" disabled="disabled"></asp:TextBox>
                        <%-- <input type="text" placeholder="623 KW" class="input_number">--%>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>قدرة النظام <span class="LTR">DC</span> </label>
                        <%-- <input type="text" placeholder="223 KW" class="input_number">--%>
                        <asp:TextBox ID="txtDCPower" runat="server" PlaceHolder="البريد الالكتروني" disabled="disabled"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:ListView runat="server" ID="lstCompanyDevice" OnItemDataBound="lstCompanyDevice_ItemDataBound">

                <ItemTemplate>

                    <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع جهاز العكس </label>
                        <%--<a href="javascript:void" class="download">--%>
                           <%-- <strong>جهاز العكس ١</strong>--%>
                             <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("DeviceDocument") %>' Target="_blank" class="download">
                             <strong><asp:Label runat="server" ID="lblname" Text='<%# Bind("DeviceName") %>'></asp:Label></strong>

                            
                                   <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                                                        </asp:HyperLink>
                           
                       <%-- </a>--%>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>قدرة جهاز العكس </label>
                                
                                  <asp:textbox ID="Label2" runat="server" Text='<%# Bind("DevicePower") %>'></asp:textbox>
                               <%-- <input type="text" placeholder="623 KW" class="input_number">--%>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>عدد أجهزة العكس </label>
                                  <asp:textbox ID="Textbox1" runat="server" Text='<%# Bind("NumberofUnits") %>'></asp:textbox>
                                 
                                <%--<input type="text" placeholder="١٨ جهاز">--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                  
                </ItemTemplate>

            </asp:ListView>
            <asp:ListView runat="server" ID="lstCompanySoller" OnItemDataBound="lstCompanySoller_ItemDataBound">

                <ItemTemplate>

                    <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                       <%-- <a href="javascript:void" class="download">--%>
                         <asp:HyperLink runat="server" ID="lnkSecondNav" NavigateUrl='<%# Bind("SollarCellDocument") %>' Target="_blank" class="download">
                           <%-- <strong>الخلايا الشمسية</strong>--%>
                             <strong><asp:Label runat="server" ID="Label1" Text='<%# Bind("SollarCellName") %>'></asp:Label></strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                             </asp:HyperLink>
                       <%-- </a>--%>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>قدرة الخلايا </label>
                                 <asp:textbox ID="Label2" runat="server" Text='<%# Bind("SollarCellPower") %>'></asp:textbox>
                                <%--<input type="text" placeholder="223 KW" class="input_number">--%>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>عدد الخلايا </label>
                                 <asp:textbox ID="Textbox2" runat="server" Text='<%# Bind("NumberofUnits") %>'></asp:textbox>
                               <%-- <input type="text" placeholder="١٢٥ خلية">--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                  
                </ItemTemplate>

            </asp:ListView>
          <%--  <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع جهاز العكس</label>
                        <a href="javascript:void" class="download">
                            <strong>جهاز العكس ٢</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>قدرة جهاز العكس </label>
                                <input type="text" placeholder="623 KW" class="input_number">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>عدد أجهزة العكس </label>
                                <input type="text" placeholder="١٨ جهاز">
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                        <a href="javascript:void" class="download">
                            <strong>الخلايا الشمسية</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>قدرة الخلايا </label>
                                <input type="text" placeholder="223 KW" class="input_number">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>عدد الخلايا </label>
                                <input type="text" placeholder="١٢٥ خلية">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                        <a href="javascript:void" class="download">
                            <strong>الخلايا الشمسية</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>قدرة الخلايا </label>
                                <input type="text" placeholder="223 KW" class="input_number">
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="form-group">
                                <label>عدد الخلايا </label>
                                <input type="text" placeholder="١٢٥ خلية">
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>


           <%-- <h4 class="extitle">نوع الخلايا</h4>

            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                        <a href="javascript:void" class="download">
                            <strong>الخلايا الشمسية</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                        <a href="javascript:void" class="download">
                            <strong>الخلايا الشمسية</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                        <a href="javascript:void" class="download">
                            <strong>الخلايا الشمسية</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <div class="form-group">
                        <label>نوع الخلايا</label>
                        <a href="javascript:void" class="download">
                            <strong>الخلايا الشمسية</strong>
                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/pdf.png" alt="">
                        </a>
                    </div>
                </div>
            </div>

            <button class="backBTN">عودة</button>--%>

            <div class="clearfix"></div>
        </div>
        <div role="tabpanel" class="tab-pane fade " id="Working_procedures">

            <ul class="list-unstyled">
                <li>
                    <strong>تاريخ الطلب</strong>
                   <%-- <span>٢٥ نيسان ٢٠٢٠</span>--%>
                     <asp:Literal ID="lblDate2" runat="server"></asp:Literal>
                </li>
                <li>
                    <strong>اسم الشركة</strong>
                   <%-- <span>شركة الافاق المتجددة للتكنولوجيا</span>--%>
                    <asp:Literal ID="lblUSerName" runat="server"></asp:Literal>
                </li>
                <li style="display:none;">
                    <strong>رقم الطلب / رقم العداد</strong>
                     <asp:Literal ID="lblName2" runat="server"></asp:Literal>
                   <%-- <span class="LTR"><b>2798564398222</b></span>--%>
                </li>
                <li style="display:none;">
                    <strong>المنطقة</strong>
                    <%--<span>الجبيهة - شفابدران</span>--%>
                     <asp:Literal ID="lblENGType2" runat="server"></asp:Literal>
                </li>
            </ul>

            <div class="EnergyRequest_Accordion" >

                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">                    

                   <asp:ListView ID="lstStepsValue" runat="server" OnItemDataBound="lstStepsValue_ItemDataBound">
                        <ItemTemplate>
                            <div class="panel panel-default">
                                <div class="panel-heading" role="tab" id='heading<%# Eval("ID") %>'>
                                    <h4 class="panel-title">
                                        <a role="button" class="collapsed" data-toggle="collapse" data-parent="#accordion" href='#collapse<%# Eval("ID") %>' aria-expanded="false" aria-controls='collapse<%# Eval("ID") %>'>
                                            <div class="headingtext">
                                                <i class="more-less lni lni-plus"></i>
                                                <asp:Label ID="lblStepName" runat="server" Text=' <%# Eval("StepName") %>'></asp:Label>
                                            </div>
                                            <div class="check_date_time">
                                                <asp:HiddenField ID="hndStepStatus" runat="server" Value='<%#Eval("StepStatus") %>' />
                                                <img runat="server" id="imgDone" src="http://jepcoportal.aura-techs.com/App_Themes/ThemeAr/img/small-check.png" alt="" visible='<%# Convert.ToString(Eval("StepStatus")) == "Done"? true:false %>'>
                                                <img runat="server" id="imgpending" src="http://jepcoportal.aura-techs.com/App_Themes/ThemeAr/img/small-check-01.png" alt="" visible='<%# Convert.ToString(Eval("StepStatus")) != "Done"? true:false %>'>
                                                <asp:Label ID="lblTime" CssClass="time" runat="server" Text=' <%# Eval("Adddate","{0:hh:mm tt}") %>'></asp:Label>
                                                <asp:Label ID="lblDate" runat="server" CssClass="date" Text=' <%# Eval("Adddate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </div>
                                        </a>
                                    </h4>
                                </div>
                                <div id='collapse<%# Eval("ID") %>' class="panel-collapse collapse" role="tabpanel" aria-labelledby='heading<%# Eval("ID") %>'>
                                    <div class="panel-body">
                                        <asp:Label ID="lblStepNotes" runat="server" Text=' <%# Eval("StepNotes") %>'></asp:Label><br />
                                         <asp:HyperLink runat="server" ID="Attachment" Target="_blank" NavigateUrl='<%# Eval("Attachment") %>'></asp:HyperLink><br />
                                         <asp:HyperLink runat="server" ID="Attachment2" Target="_blank" NavigateUrl='<%# Eval("Attachment2") %>'></asp:HyperLink><br />
                                         <asp:HyperLink runat="server" ID="Attachment3" Target="_blank" NavigateUrl='<%# Eval("Attachment3") %>'></asp:HyperLink><br />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <h3>No Records!</h3>
                        </EmptyDataTemplate>
                    </asp:ListView>

                     <asp:ListView ID="StpeValueUnDone" runat="server" style="display:none" >
                                        <ItemTemplate>

<div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="headingTwo">
                            <h4 class="panel-title">
                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                    <div class="headingtext">
                                        <i class="more-less lni lni-plus"></i>
                                        <h5>تم استلام الطلب من قبل قسم الطاقة المتجددة</h5>
                                    </div>
                                    <div class="check_date_time">
                                        <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/small-check.png" alt="">
                                        <span class="time">07:35 AM</span>
                                        <span class="date">٢٥ نيسان ٢٠٢٠</span>
                                    </div>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                            <div class="panel-body">
                                <strong>ملاحظات</strong>
                                <p>تم استلام الطلب من قبل قسم الطاقة المتجددة والتأكد من مطابقتة </p>
                            </div>
                        </div>
                    </div>

                                        </ItemTemplate>
                     </asp:ListView>


                </div>
            </div>

            <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">


                  <asp:ListView ID="StpeValueDone" runat="server" style="display:none">
                                        <ItemTemplate>
                                            <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingseven">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseseven" aria-expanded="true" aria-controls="collapseseven">
                                <div class="headingtext">
                                    <i class="more-less lni lni-plus"></i>
                                    <h5>تم استلام الطلب من قبل قسم الطاقة المتجددة</h5>
                                </div>
                                <div class="check_date_time">
                                    <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/duration.png" alt="">
                                    <span class="time">07:35 AM</span>
                                    <span class="date">٢٥ نيسان ٢٠٢٠</span>
                                </div>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseseven" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingseven">
                        <div class="panel-body">
                            <strong>ملاحظات</strong>
                            <p>تم استلام الطلب من قبل قسم الطاقة المتجددة والتأكد من مطابقتة </p>
                        </div>
                    </div>
                </div>

                                        </ItemTemplate></asp:ListView>               
            </div>





            <%--<button class="backBTN">عودة</button>--%>
             <asp:Button class="backBTN" OnClick="btnsave_Click" ID="btnsave" runat="server" Text="عودة"/>   
            <div class="clearfix"></div>


        </div>
    </div>

</div>




<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->


<script>
    $(".show_profilebtn").click(function () {
        $(".hidendiv").slideToggle();
    });

    $(".mobile_menu button").click(function () {
        $(".mobile_menu .container").slideToggle();
    });

    $(".filterbtn").click(function () {
        $(".filterboxdiv").slideToggle();
    });

</script>
<script>
    function toggleIcon(e) {
        $(e.target)
            .prev('.panel-heading')
            .find(".more-less")
            .toggleClass('lni-plus lni-minus');
    }
    $('.panel-group').on('hidden.bs.collapse', toggleIcon);
    $('.panel-group').on('shown.bs.collapse', toggleIcon);
</script>
