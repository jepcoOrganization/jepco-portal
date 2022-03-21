<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileDatails.ascx.cs" Inherits="Controls_FileDatails" %>

<%--<div class="col-lg-8 col-md-12 col-sm-12">--%>

<asp:HiddenField runat="server" ID="hdnFileNAme" />
<div class="average_energy">
    <aside>
        <h1><small>الاستهلاك في ال 12 شهرا الأخيرة</small>
            معدل استهلاك الطاقة لاخر <span>12</span> شهرا</h1>
        <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/energy-2.png" alt="">
    </aside>

    <div class="billlist">

        <div class="top-cart-detail">


            <div class="row">
                <div class="col-md-10 col-sm-10">
                    <span>اسم صاحب العداد:</span>
                    <strong>
                        <label id="CostName"></label>
                    </strong>

                </div>
                <div class="col-md-2 pull-right text-right"><a href="#" class="cllChangeFile">عدادات اخرى؟</a></div>
            </div>

            <div class="row">



                <%--<div class="col-md-3 col-sm-6"><span>رقم العداد</span><strong style="margin-right: 15px; font-family: 'Montserrat', sans-serif;"><label id="lblFileNo"></label></strong></div>--%>
                <%--  <div class="col-md-3 col-sm-3"><span> المنطقة:</span><strong> الجبيهة</strong></div>--%>
                <%-- <div class="col-md-2 col-sm-3">
                    <span>المنطقة:</span><strong>
                        <label id="lblFileArea"></label>
                    </strong>
                </div>--%>

                <%--   <div class="col-md-3 col-sm-3">
                    <span>الذمم المستحقة:</span><strong>
                        <label id="lblmTotalReceivabales"></label>
                    </strong>
                </div>--%>

                <%-- <div class="col-md-2 col-sm-3col-xs-6 "><span> القطاع:</span><strong>  سكني</strong></div>--%>
                <%--  <div class="col-md-2 col-sm-3 col-xs-6 ">
                    <span>القطاع:</span><strong>
                        <label id="lblfileSectiontype"></label>
                    </strong>
                </div>--%>
            </div>

            <div class="detil_counter_rowone">
                <div class="newcounter1" style="display: none">



                    <div class="counterinfo1">
                        <div class="col-xs-12 col-sm-12 col-md-12">
                            <p class="counter_new1">رقم الملف </p>
                        </div>
                    </div>
                    <div class="counterinfo2">
                        <div class="col-xs-12 col-sm-12 col-md-12">
                            <div class="counterinfo2_Data1">

                                <p class="counter_new2">المنطقة: </p>

                            </div>

                            <div class="counterinfo2_Data2">
                                <p class="counter_new3">القطاع:</p>

                            </div>


                        </div>
                    </div>
                </div>

                <div class="newcounter4">

                    <p><strong>رقم الملف  <span>
                        <label class="LTR" id="lblFileNo"></label>
                    </span></strong></p>
                    <div class="row">
                        <div class="col-lg-6 col-sm-12 col-md-12">
                            <p><strong>المنطقة:   <span>
                                <label id="lblFileArea"></label>
                            </span></strong></p>
                        </div>
                        <div class="col-lg-6 col-sm-12 col-md-12">
                            <p><strong>القطاع:  <span>
                                <label id="lblfileSectiontype"></label>
                            </span></strong></p>
                        </div>
                        <p style="display: none">الذمم المستحقة:</p>
                        <label id="lblmTotalReceivabales" style="display: none"></label>

                    </div>
                </div>

                <div class="newcounterBox ReportMess1">
                    <p>الفواتير الغير مسددة </p>

                    <label id="lblUnpaidBills"></label>


                </div>

                <div class="newcounterBox newcounter2">
                    <p>اجمالي المبلغ المطلوب</p>

                    <label id="lblUnpaidAmount"></label>


                </div>




            </div>









            <div class="canvasdiv canvasdivDetails" id="myCanvasDivDetails">
                <canvas id="ctx" width="925" height="250"></canvas>
            </div>


            <div id="MyAllFiles"></div>

            <%--<ul class="list-unstyled">
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="row">
                        <div class="col-xs-6 col-sm-6 col-md-5">
                            <h4>رقم الفاتورة</h4>
                            <span class="LTR">2798564398222</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>تاريخ القراءة</h4>
                            <span class="LTR">23-05-2020</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-3">
                            <h4>كمية الاستهلاك KW</h4>
                            <span class="LTR">KW768435</span>
                        </div>
                        <div class="col-xs-6 col-sm-6 col-md-2">
                            <h4>القيمة المطلوبة</h4>
                            <span><strong>٢٤،٦٩٣</strong> دينار</span>
                        </div>
                    </div>
                </li>
            </ul>--%>
        </div>

    </div>
</div>
<%--</div>--%>

 <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Style="display: none;" type="button" />
<asp:HiddenField ID="BillNo" runat="server" />
<asp:HiddenField ID="BillAmount" runat="server" />

<div class="modal fade welcome" id="myModalForFileGraph" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                <div id="filegraph" class="protal_tabs"></div>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>

                <%-- <button>موافق</button>--%>
            </div>
        </div>
    </div>
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.min.js"></script>







<script>
    $("document").ready(function () {

        var AllFileBill = [];
        var ALLGraphdata = [];
        var MobileNoURL = $("#hdnmobileno").val();
        var apiConfiguUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["MobileAPIurl"].ToString() %>';
        var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';

        var GetFileNo = $("#ContentPlaceHolder1_ctl00_hdnFileNAme").val();


        var months = ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيو",
            "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"];

        //var abcd = "2020-07";
        //var myString = abcd.split("-").pop();
        //var converm = parseFloat(myString);
        //var abcd2 = months[converm];



        callFirstload();

        function callFirstload() {


            
            $("#lblFileNo").text(GetFileNo);
            $.ajax({

                type: "POST",
                url: APIUrl + "MobileBills/GetBills",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                },
                data: JSON.stringify({
                    FileNumber: GetFileNo,
                    LanguageId: "AR"
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.statusCode == "Success") {
                        var CostsName = data.body.billsHeader.firstName; 


                        var amount = 0
                        //$("#lblUnpaidAmount").text(parseFloat(data.body.fileNumberInfo.mConBalance));
                        for (var i = 0; i < data.body.allBillsDetails.length;i++)
                            amount += parseFloat(data.body.allBillsDetails[i].unClearingAmount);
                        $("#lblUnpaidAmount").text(parseFloat(data.body.allBillsDetails.totalBillAmount));
                        $("#lblUnpaidAmount").text(amount);
                        $("#lblUnpaidBills").text(parseFloat(data.body.unClearedBillsDetails.length));

                        $("#CostName").text(CostsName);
                        //var FileSectionType = data.body.allBills[0].billHTMLData.values[3];
                        var FileSectionType = data.body.billsHeader.subscriptionDescription; 
                        //var FileArea = data.body.allBills[0].billHTMLData.values[1];
                        var FileArea = data.body.billsHeader.officeDescription; 
                        $("#lblFileArea").text(FileArea); //Area
                        $("#lblfileSectiontype").text(FileSectionType); //Section

                        //var AllBills = data.body.allBills;
                        var AllBills = data.body.allBillsDetails; 

                        var AllPaidBill = data.body.clearedBillsDetails;
                        var AllUnPaidBill = data.body.unClearedBillsDetails;




                        $.each(AllBills, function (key, value) {

                            if (value.ibillingQuantity > 0) {

                                var FileData = {};
                                var PaidStatu;
                                var BillValue;
                                var BillNo = value.billPeriod;
                                BillNo = BillNo.replace(/[^a-zA-Z0-9]/g, '');
                                var ConsQty = value.ibillingQuantity;

                                if (value.clearingAmount != "0.000") {
                                    BillValue = value.clearingAmount;
                                } else {
                                    BillValue = 0
                                }
                                 
                                var BillDates = value.billPeriod;
                                var FileNo = value.fileNumber;
                                var PaymentDate = value.clearingDate;
                                if (PaymentDate !== "0000/00/00")
                                    PaidStatu = 1;
                                else
                                    PaidStatu = 0;

                                FileData.billNo = BillNo;
                                FileData.consumptionQty = ConsQty;
                                FileData.status = PaidStatu;
                                FileData.billValue = BillValue;
                                FileData.readDate = BillDates;
                                FileData.fileNumber = FileNo;
                                FileData.paidDate = PaymentDate;
                                AllFileBill.push(FileData);

                            }



                        });

                        $.each(AllPaidBill, function (key, value) {


                            if (value.ibillingQuantity > 0) {
                                var FileData = {};
                                var PaidStatu;

                                var BillNo = value.billPeriod;
                                BillNo = BillNo.replace(/[^a-zA-Z0-9]/g, '');
                                var ConsQty = value.ibillingQuantity;
     
                                var BillValue;
                                if (value.clearingAmount != "0.000") {
                                    BillValue = value.clearingAmount;
                                } else {
                                    BillValue = 0
                                }
                                var BillDates = value.billPeriod;
                                var FileNo = value.fileNumber;
                                var PaymentDate = value.clearingDate;
                                if (PaymentDate !== "0000/00/00")
                                    PaidStatu = 1;
                                else
                                    PaidStatu = 0;

                                FileData.billNo = BillNo;
                                FileData.consumptionQty = ConsQty;
                                FileData.status = PaidStatu;
                                FileData.billValue = BillValue;
                                FileData.readDate = BillDates;
                                FileData.fileNumber = FileNo;
                                FileData.paidDate = PaymentDate;
                                AllFileBill.push(FileData);

                            }


                        });

                        $.each(AllUnPaidBill, function (key, value) {

                            if (value.ibillingQuantity > 0) {

                                var FileData = {};
                                var PaidStatu;

                                //var BillNo = value.billNo;
                                //var ConsQty = value.consumptionQty;
                                //var PaidStatu = value.status;
                                //var BillValue = value.billValue;
                                //var BillDates = value.readDate;
                                //var FileNo = value.fileNumber;
                                //var PaymentDate = value.paidDate;
                                var BillNo = value.billPeriod;
                                BillNo = string.BillNo(/[^a-zA-Z0-9]/g, '');
                                var ConsQty = value.ibillingQuantity;

                                var BillValue ;
                                if (value.clearingAmount != "0.000") {
                                    BillValue = value.clearingAmount;
                                } else {
                                    BillValue = value.unClearingAmount
                                }
                                var BillDates = value.billPeriod;
                                var FileNo = value.fileNumber;
                                var PaymentDate = value.clearingDate;
                                if (PaymentDate !== "0000/00/00")
                                    PaidStatu = 1;
                                else
                                    PaidStatu = 0;

                                FileData.billNo = BillNo;
                                FileData.consumptionQty = ConsQty;
                                FileData.status = PaidStatu;
                                FileData.billValue = BillValue;
                                FileData.readDate = BillDates;
                                FileData.fileNumber = FileNo;
                                FileData.paidDate = PaymentDate;
                                AllFileBill.push(FileData);
                            }

                        });

                    }
                    else {
                        Fillstatus = "error";
                    }



                },
                error: function (result) {
                    // alert("Errorinhistory");
                }
            });

            debugger
            $.ajax({
                //type: "GET",
                ////contentType: "application/json; charset=utf-8",
                //url: callStatusURl,
                //dataType: "json",
                //async: false,
                //success: function (data) {
                //    console.log("now : ",data)
                //    if (data.status == "success") {
                type: "POST",
                url: APIUrl + "MobileBills/GetBills",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                },
                data: JSON.stringify({
                    FileNumber: GetFileNo,
                    LanguageId: "AR"
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.statusCode == "Success") {
                        var amount = 0
                        for (var i = 0; i < data.body.allBillsDetails.length; i++)
                            amount += parseFloat(data.body.allBillsDetails[i].unClearingAmount);
                        var mReceivables = amount;
                        $("#lblmTotalReceivabales").text(mReceivables);
                    }
                    else {
                        Fillstatus = "error";
                    }



                },
                error: function (result) {
                    // alert("Errorinhistory");
                }
            });

            //console.log(AllFileBill);


            var uniqueBill = [];

            //-------------------------------------------------------------
            // Display the list of array objects 


            // Declare a new array 
            let newArray = [];

            // Declare an empty object 
            let uniqueObject = {};
            // Loop for the array elements 
            for (let i in AllFileBill) {

                // Extract the title 
                objTitle = AllFileBill[i]['billNo'];
                // Use the title as the index 
                uniqueObject[objTitle] = AllFileBill[i];
            }

            // Loop to push unique object into array 
            for (i in uniqueObject) {
                newArray.push(uniqueObject[i]);
            }

            // Display the unique objects 
            // console.log(newArray);

            //---------------------------------------------------------
            //newArray.sort(function (a, b) {
            //     
            //    return parseInt(a.billNo) + parseInt(b.billNo);
            //});

            var HTMLUL = "<ul class='list-unstyled'>";
            var HtmlLIContaint = "";
/*            newArray.reverse();*/
            var GraphMonthLoop = 1;
            $.each(newArray, function (key, value) {

                var HtmlLi = "<li>";
                var HtmlRow = "<div class='row'>";
                var FirstDiv = "<div class='col-xs-6 col-sm-6 col-md-2'><h4>رقم الفاتورة</h4><span class='LTR'>" + value.billNo + "</span></div>";
                var FileThisStatu = "";
                var FileThisDate = "";
                var fontcolor = "red";

                if (value.status == "1") {
                    FileThisStatu = "مسددة";
                    FileThisDate = value.paidDate;
                    fontcolor = "green"

                }
                else {
                    FileThisStatu = "غير مسددة";
                    FileThisDate = "-";
                    fontcolor = "red";
                }
                var StatusDiv = "<div class='col-xs-6 col-sm-6 col-md-2'><h4>الحالة</h4><span style='color:" + fontcolor + ";'>" + FileThisStatu + "</span></div>";
                var SecondDiv = "<div class='col-xs-6 col-sm-6 col-md-2'><h4>تاريخ القراءة</h4><span class='LTR'>" + value.readDate + "</span></div>";
                var ThirdDiv = "<div class='col-xs-6 col-sm-6 col-md-2'><h4>الاستهلاك KW</h4><span class='LTR'>KW " + value.consumptionQty + "</span></div>";
                var FourthDiv = "<div class='col-xs-6 col-sm-6 col-md-2'><h4>القيمة المطلوبة</h4><span><strong>" + value.billValue + "</strong> دينار</span></div>";
                var FiveDiv = "<div class='col-xs-6 col-sm-6 col-md-1'><h4>تاريخ الدفع</h4><span><strong style='font-family:TimesNewRoman,Times,serif;'>" + FileThisDate + "</strong></span>  </div>";
                //var SixNewDiv = "<div class='col-xs-6 col-sm-6 col-md-1'><h4>تاريخ الدفع</h4> <a href='#' data-billnos=" + value.billNo + " data-amount=" + value.billValue + "  class='Paymentcls'  > pay </a > </div>";
                var EndHtmlRow = "</div>";
                var EndHtmlLi = "</li>";
                var thisLi = HtmlLi + HtmlRow + FirstDiv + SecondDiv + ThirdDiv + FourthDiv + StatusDiv + FiveDiv  + EndHtmlRow + EndHtmlLi;
                HtmlLIContaint = HtmlLIContaint + thisLi;





                if (GraphMonthLoop <= 12) {
                    var Graphdata = {};

                    var BillMonth = "";
                    var BillConQTY = "0";
                    var BillMonthstng = "0000-01";
                    BillMonth = value.readDate;
                    BillConQTY = value.consumptionQty;

                    var abcd = BillMonth;
                    var myString = abcd.split("-").pop();
                    var converm = parseFloat(myString);

                    var streetaddress = BillMonth.split('-')[0];
                    var abcd2 = streetaddress + "-" + months[converm];


                    Graphdata.BillMonth = BillMonth;
                    Graphdata.BillConQTY = BillConQTY;
                    Graphdata.BillMonthString = abcd2;

                    //ALLGraphdata.push(Graphdata);
                    ALLGraphdata.push(Graphdata);

                    GraphMonthLoop++;

                }

            });

            var EndHTMLUL = "</ul>";
            var my_UL = HTMLUL + HtmlLIContaint + EndHTMLUL;

            $("#MyAllFiles").append(my_UL);
            if (ALLGraphdata.length < 12) {

                var AryLength = ALLGraphdata.length;
                for (var i = AryLength; i < 12; i++) {

                    var Graphdata = {};
                    var BillMonth = "0000-01";
                    var BillConQTY = "0";
                    var abcd = BillMonth;
                    var myString = abcd.split("-").pop();
                    var converm = parseFloat(myString);

                    var streetaddress = BillMonth.split('-')[0];
                    var abcd2 = streetaddress + "-" + months[converm];

                    //var abcd2 = months[converm];


                    Graphdata.BillMonth = BillMonth;
                    Graphdata.BillConQTY = BillConQTY;
                    Graphdata.BillMonthString = abcd2;

                    ALLGraphdata.push(Graphdata);


                }
            }


            ALLGraphdata.reverse();


            //-------------------------------------------------------
            $('#ctx').remove(); // this is my <canvas> element
            $('#myCanvasDivDetails').append(' <canvas id="ctx" width="925" height="250"></canvas>');

            var chart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: [[ALLGraphdata[0].BillMonth, ALLGraphdata[0].BillConQTY], [ALLGraphdata[1].BillMonth, ALLGraphdata[1].BillConQTY], [ALLGraphdata[2].BillMonth, ALLGraphdata[2].BillConQTY], [ALLGraphdata[3].BillMonth, ALLGraphdata[3].BillConQTY], [ALLGraphdata[4].BillMonth, ALLGraphdata[4].BillConQTY], [ALLGraphdata[5].BillMonth, ALLGraphdata[5].BillConQTY], [ALLGraphdata[6].BillMonth, ALLGraphdata[6].BillConQTY], [ALLGraphdata[7].BillMonth, ALLGraphdata[7].BillConQTY], [ALLGraphdata[8].BillMonth, ALLGraphdata[8].BillConQTY], [ALLGraphdata[9].BillMonth, ALLGraphdata[9].BillConQTY], [ALLGraphdata[10].BillMonth, ALLGraphdata[10].BillConQTY], [ALLGraphdata[11].BillMonth, ALLGraphdata[11].BillConQTY]],// responsible for how many bars are gonna show on the chart
                    //labels: [["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"], ["كانون الثاني", "KW 768435"]],// responsible for how many bars are gonna show on the chart
                    // create 12 datasets, since we have 12 items
                    // data[0] = labels[0] (data for first bar - 'Standing costs') | data[1] = labels[1] (data for second bar - 'Running costs')
                    // put 0, if there is no data for the particular bar
                    datasets: [{
                        label: 'Washing and cleaning',
                        //data: [5, 8, 2, 4, 6, 4, 5, 6, 7, 8, 2, 4],
                        data: [ALLGraphdata[0].BillConQTY, ALLGraphdata[1].BillConQTY, ALLGraphdata[2].BillConQTY, ALLGraphdata[3].BillConQTY, ALLGraphdata[4].BillConQTY, ALLGraphdata[5].BillConQTY, ALLGraphdata[6].BillConQTY, ALLGraphdata[7].BillConQTY, ALLGraphdata[8].BillConQTY, ALLGraphdata[9].BillConQTY, ALLGraphdata[10].BillConQTY, ALLGraphdata[11].BillConQTY],
                        backgroundColor: '#a4dfff'
                    }, {
                        //label: 'Traffic tickets',
                        //data: [5, 2, 8, 6, 4, 6, 5, 4, 3, 2, 8, 6],
                        //backgroundColor: '#f2efef'
                    }]
                },
                options: {
                    responsive: false,
                    legend: false,
                    showLine: false,
                    responsive: false,
                    maintainAspectRatio: false,
                    tooltips: {
                        enabled: false
                    },
                    scales: {
                        xAxes: [{
                            barThickness: 70,
                            stacked: true, // this should be set to make the bars stacked
                            gridLines: {
                                drawOnChartArea: false,
                                drawBorder: false,
                                display: false
                            },
                            ticks: {
                                fontFamily: "",
                                fontColor: "#007fc3",
                                fontSize: 14,
                                padding: 50
                            }
                        }],
                        yAxes: [{
                            stacked: true, // this also..
                            gridLines: {
                                drawOnChartArea: false,
                                drawBorder: false,
                                display: false
                            },
                            ticks: {
                                display: false, //this will remove only the label

                            }
                        }]
                    }
                }
            });


        };



        $(".cllChangeFile").click(function () {


            var AllFileForGraph = "";
            var ApiURLprofile = apiConfiguUrl + "profile/" + MobileNoURL;
            var DesingAllFileForGraph = "";
            $.ajax({
                type: "POST",
                url: APIUrl + "CustomerInfo/GetCustomerInfoDataForWebsite",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                },
                data: JSON.stringify({
                    MobileNumber: MobileNoURL,
                    LanguageId: "AR"
                }),
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                        DesingAllFileForGraph = "";
                        var GetAllFile = data.body.customerInfoResult.customerInformationDetails;


                        var tab_Pop = "<div class='tab-content'>";
                        var StringUI123_pop = "<ul class='list-unstyled'>";
                        var HtmlScroolingdivHRD_pop = "<div class='content demo-y'>";
                        var ENDHtmlScroolingdivHRD123_pop = "</div>";
                        var EndStringUI123_pop = "</ul>";
                        var ENDtab_Pop = "</div>";

                        $.each(GetAllFile, function (key, value) {

                            var fileNumber = value.fileNumber;
                            var alias = value.aliasName;

                            var HTMLLI_pop = "<li>";
                            var HTMLDiv1_pop = "<div><strong>التعريف</strong><span >" + alias + "</span></div>";
                            var HTMLDiv2_pop = "<div><strong> الرقم المرجعي</strong><p> " + fileNumber + " </p></div>"

                            //var HTMLa_pop = "<a href='#' data-filename=" + fileNumber + " class='fileGraphChangecls' >عرض التفاصيل </a >";
                            var HTMLa_pop = "<a href='#' data-filename=" + fileNumber + " class='changeFileData' >عرض التفاصيل </a >";
                            var EndHTMLLI_pop = "</li>";

                            var HTMLmyFileName = HTMLLI_pop + HTMLDiv1_pop + HTMLDiv2_pop + HTMLa_pop + EndHTMLLI_pop;

                            AllFileForGraph = AllFileForGraph + HTMLmyFileName;
                            // AllFileForGraph = AllFileForGraph + HTMLmyFileName;



                        });



                        DesingAllFileForGraph = tab_Pop + StringUI123_pop + HtmlScroolingdivHRD_pop + AllFileForGraph + ENDHtmlScroolingdivHRD123_pop + EndStringUI123_pop + ENDtab_Pop;
                        //console.log("Last Array Data " + AllcustomerSubAccountList);
                        $('#filegraph').empty();
                        $("#filegraph").append(DesingAllFileForGraph);

                        //----------------------------------------------------------

                        //alert("call Scroll 2");

                        $.mCustomScrollbar.defaults.theme = "light-2"; //set "light-2" as the default theme

                        $(".demo-y").mCustomScrollbar();

                        $(".demo-x").mCustomScrollbar({
                            axis: "x",
                            advanced: { autoExpandHorizontalScroll: true }
                        });

                        $(".demo-yx").mCustomScrollbar({
                            axis: "yx"
                        });

                        $(".scrollTo a").click(function (e) {
                            e.preventDefault();
                            var $this = $(this),
                                rel = $this.attr("rel"),
                                el = rel === "content-y" ? ".demo-y" : rel === "content-x" ? ".demo-x" : ".demo-yx",
                                data = $this.data("scroll-to"),
                                href = $this.attr("href").split(/#(.+)/)[1],
                                to = data ? $(el).find(".mCSB_container").find(data) : el === ".demo-yx" ? eval("(" + href + ")") : href,
                                output = $("#info > p code"),
                                outputTXTdata = el === ".demo-yx" ? data : "'" + data + "'",
                                outputTXThref = el === ".demo-yx" ? href : "'" + href + "'",
                                outputTXT = data ? "$('" + el + "').find('.mCSB_container').find(" + outputTXTdata + ")" : outputTXThref;
                            $(el).mCustomScrollbar("scrollTo", to);
                            output.text("$('" + el + "').mCustomScrollbar('scrollTo'," + outputTXT + ");");
                        });
                    //--------------------------------------------------------
                },
                error: function (result) {
                    //alert("Error");
                }
            });

            $(".changeFileData").click(function () {
                AllFileBill = [];
                ALLGraphdata = [];
                $('#MyAllFiles').empty();
                //var filename = $(this).data("filename");
                var filename = $('.changeFileData').attr('data-filename');
                console.log("hehe : ", filename)
                GetFileNo = filename;

                callFirstload();
                $('#myModalForFileGraph').modal('hide');
            });

            //$("#filegraph").append(AllFileForGraph); 
            $('#myModalForFileGraph').modal('show');



        });

    });
</script>
<style>
    #myModalForFileGraph .modal-body {
        padding: 0;
    }

    #filegraph {
        margin: 0;
    }

    .newcounter1 {
        background: #007fc3;
    }

        .newcounter1 p {
            font-size: 10px;
            color: #4db6c9;
        }

        .newcounter1 label {
            font-size: 10px;
            color: white;
        }

    .ReportMess label {
        color: white;
    }

    .newcounter label {
        color: white;
    }

    .ReportMess1 p, .newcounter2 p {
        font-size: 22px;
    }

    .ReportMess1 {
        background: #4db6c9;
    }

    .newcounter2 {
        background: #e46a6a;
    }

    p.counter_new1 {
        display: inline-block;
    }

    .newcounter4 {
        background: #007fc3;
        text-align: right;
        float: right;
        width: 31%;
        align-items: center;
        padding: 20px;
    }
    .newcounter4 p {
       margin-bottom: 0;
    }

        .newcounter4 p strong {
            color: white;
            font-size: 18px;
        }

        .newcounter4 p span {
            color: #4db6c9;
            font-size: 18px;
        }


    .newcounterBox {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 20px 40px;
        width: 31%;
    }

        .newcounterBox p {
            color: #fff;
            font-size: 18px;
            font-weight: bold;
            margin: 0;
            white-space: pre-line;
        }

        .newcounterBox label {
            font-size: 30px;
            color: white;
        }

    @media only screen and (max-width: 1367px) and (min-width: 1300px) {
         .newcounter4 p strong {          
            font-size: 12px;
        }

        .newcounter4 p span {           
            font-size: 12px;
        }
    }


    @media only screen and (max-width: 767px) {
        .detil_counter_rowone {
            display: block;
        }
        .newcounterBox ,
        .newcounter4{
            width: 100%;
            float: none;
        }
    }

</style>

 <script type="text/javascript">
     $("document").ready(function () {

         $(".Paymentcls").click(function () {

             $("#<%=BillNo.ClientID%>").val("");
             $("#<%=BillAmount.ClientID%>").val("");

             var apiPaymentConfiguUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["PaymentefawateerAPIurl"].ToString() %>';

             var BillNOVar = $(this).data("billnos");
             var filenameVar = $(this).data("amount");
            
             var BilrTrxNo = BillNOVar;   //"20201000";               //==> Y
             var BillerCode = 1051;               //==> Y
             var ServiceCode = 61283;             //==> Y
             var PaymentType = 1;               //==> Y
             var Currency = "JOD";              //==> Y
             var BillingNo = "20201000";                //==> Y
             var PrepaidCatCode = 10;         //==> N
             var Amount = filenameVar; // 29.778;                   //==> Y
             var StatmntNartive = "";          //==> N
             var CustEmail = "";               //==> N
             var Language = "AR";                 //==> Y
             var OtherDetails = "";             //==> N
             var SecureHash = "d3abe71adf8c4c769a5cab5fea581663";              //==> Y

             debugger;



             $("#<%=BillNo.ClientID%>").val(BilrTrxNo);
             $("#<%=BillAmount.ClientID%>").val(Amount);

             $("[id*=<%=btnSubmit.ClientID %>]").click();

             //$.ajax({
             //    type: "POST",
             //    contentType: "application/json; charset=utf-8",
             //    //url: "/Default.aspx/BindSolerCellDATAS",
             //    url: "/Default.aspx/PaymentGetWayCall",
             //    data: "{BillNO:'" + BilrTrxNo + "',BillAmount:'" + Amount +"'}",
             //    success: function (result) {
                     
             //    },
             //    error: function (result) {
             //        // alert(result.status + " : " + result.StatusText);
             //    }
             //});


            

             //window.location.replace("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6", true)

             //var CallPaymentURL = apiPaymentConfiguUrl + "RequestParams=" + BilrTrxNo + "|" + BillerCode + "|" + ServiceCode + "|" + PaymentType + "|" + Currency + "|" + BillingNo + "|" + PrepaidCatCode + "|" + Amount + "|" + StatmntNartive + "|" + CustEmail + "|" + Language + "|" + OtherDetails + "|" + SecureHash;

             ////Response.Redirect(https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6,false)
             //  //Response.Redirect("https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6", false);
             
             ////window.location.href = "https://staging.efawateercom.jo/DirectPayService/DirectPay.aspx?RequestParams=20201000|1051|61283|1|JOD|20201000||29.778|||AR||$2a$10$FrCnOwloBI2BUG6MZ3ARgeuNTmde1QNkP3BbxyvbFDBwmc9JmpHI6";

             //$.ajax({
             //    type: "POST",
             //    //contentType: "application/json; charset=utf-8",
             //    url: CallPaymentURL,
             //    //dataType: "json",
             //    async: true,
             //    //dataType: "xml",
             //    //contentType: "text/xml; charset=utf-8",
             //    success: function (data) {

             //        console.log(data);

             //        console.log("BilrTrxNo" + data.BilrTrxNo);
             //        console.log("TrxStatus" + data.TrxStatus);
             //        console.log("DirectPayTrxNo" + data.DirectPayTrxNo);
             //        console.log("PaymentStatus" + data.PaymentStatus);
             //        console.log(" OtherDetails" + data.OtherDetails);
             //        console.log("SecureHash" + data.SecureHash);
                    
             //    },
             //    error: function (result) {
             //        console.log(result);
             //        debugger;
             //        // alert("Errorinhistory");
             //    }
             //});


         });


     });
 </script>
    
     




