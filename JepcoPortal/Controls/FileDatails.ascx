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

<div class="modal fade welcome divBillModal" id="myModalBillImage" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <button class="btn btn-primary" id="getpdb_btn" onclick="myApp.printTable()"> طباعة الفاتورة </button>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                <div id="editor"></div>
                 <div style="width:100%" align="center" class="BillBody" id="BillBodyId" >
            <table class="bor " align="center" width="100%" cellpadding="0" cellspacing="0" dir="rtl" style="border:solid 0.05vw #0099FF" id="Table-Bill">
                <tr>
                    <td align="center" colspan="3" style="border:solid 0.05vw #0099FF; border-right:none; border-left:none; padding:0px;">
                        <table class="bor" align="center" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" width="12%">
                                    <img style="width:100%;" src=" data:image/png;base64,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" />
                                </td>
                                <td align="right" colspan="3" width="88%" style="font-size:2.5vw">
                                    شركة الكهرباء الأردنية المساهمة العامة المحدودة - عمان
                                    <br />
                                    <font style="font-size:2vw">قسيمة المشترك</font>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; background:#C0DCFE; border-top:solid 0.05vw #0099FF; font-weight: bold" ;=; width="12%">اسم المشترك</td>
                                <td align="right" colspan="3" style="border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="88%">
                                    <table align="center" width="100%" cellpadding="0" cellspacing="0" style="padding:0px">
                                        <tr>
                                            <td align="right" width="60%" style="padding:0px" id="BillName"></td>
                                            <td align="right" width="40%" style="padding:0px" id="BillInstallation"></td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; background:#C0DCFE; border-top:solid 0.05vw #0099FF; font-weight: bold" width="12%">رقم ونوع الاشتراك</td>
                                <td align="right" colspan="3" style=" border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="88%">
                                    <table align="center" width="100%" cellpadding="0" cellspacing="0" style="padding:0px">
                                        <tr>
                                            <td align="right" width="60%" style="padding:0px" id="subscriptionNo"></td>
                                            <td align="right" width="40%" style="padding:0px" id="subscriptionDescription"></td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; background:#C0DCFE; border-top:solid 0.05vw #0099FF; font-weight: bold" width="12%">
                                    فترة الإشتراك
                                </td>
                                <td align="right" colspan="3" style=" border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="88%">
                                    <table align="center" width="100%" cellpadding="0" cellspacing="0" style="padding:0px">
                                        <tr>
                                            <td align="right" width="60%" style="padding:0px"><font style="color:#4144f2;font-weight: bold" id="startBillingPeriod">من: </font></td>
                                            <td align="right" width="40%" style="padding:0px"><font style="color:#4144f2;font-weight: bold" id="endBillingPeriod">إلى: </font></td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="13%">رقم الفاتورة</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="37%" id="billPeriod"></td>
                                <td align="center" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="14%">رقم الاضبارة</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="36%">********</td>
                            </tr>
                            <tr>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="13%">رقم الملف</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="37%" id="fileNumberI"></td>
                                <td align="center" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="14%">معامل الضرب</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="36%" id="factor"></td>
                            </tr>
                            <tr>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="13%">رقم العداد</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="37%" id="meterNumber"></td>
                                <td align="center" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="14%">الخصم ( % )</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="36%">0.00</td>
                            </tr>
                            <tr>
                                <td align="center" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="13%">قراءة العداد</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="37%" id="normalMeterRead"></td>
                                <td align="center" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold" width="14%">التاريخ</td>
                                <td align="right" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="36%" id="endBillingPeriod1"></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="right" style="border-left:solid 0.05vw #0099FF; padding:0px; padding-right:1%; background:#C0DCFE; font-weight: bold" width="26%" height="100%">قراءة عداد الطاقة</td>
                                            <td align="right" style=" padding:0px;" width="74%" height="100%">
                                                <table align="center" width="100%" cellpadding="0" cellspacing="0" height="100%">
                                                    <tr>
                                                        <td align="center" width="50%" height="100%" style="border-left:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold">حالية</td>
                                                        <!-- <td align="center" width="50%" height="100%" style=" background:#C0DCFE;">محتسبة</td> -->
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" colspan="2" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="right" style=" padding:0px;" width="100%" height="100%">
                                                <table align="center" width="100%" cellpadding="0" cellspacing="0" height="100%">
                                                    <tr>
                                                        <td align="center" width="50%" height="100%" style="border-left:solid 0.05vw #0099FF; background:#C0DCFE; font-weight: bold">سابقة</td>
                                                        <td align="center" width="50%" height="100%" style=" background:#C0DCFE; font-weight: bold">الكمية (ك.و.س)</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="right" style="border-left:solid 0.05vw #0099FF; padding:0px; padding-right:1%; background:#C0DCFE; font-weight: bold" width="26%" height="100%">المستجرة من الشبكة</td>
                                            <td align="right" style=" padding:0px;" width="74%">
                                                <table align="center" width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center" width="50%" style="border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%" id="normalMeterRead1"></td>
                                                        <!-- <td align="center" width="50%" style=" color:#000000">x16t</td>  -->
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" colspan="2" height="100%" style="width:50%; padding:0px; border-top:solid 0.05vw #0099FF;">
                                    <table align="center" width="100%" height="100%" style=" padding:0;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" width="50%" height="100%" style="border-left:solid 0.05vw #0099FF; width:50%; padding:0px; color:#000000; font-size:130%" id="prevNormalMeterRead"></td>
                                            <td align="center" width="50%" height="100%" style=" padding:0px; color:#000000; font-size:130%" id="ibillingQuantity"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="right" style="border-left:solid 0.05vw #0099FF; padding:0px; padding-right:1%; background:#C0DCFE; font-weight: bold" width="26%" height="100%">المصدرة الى الشبكة</td>
                                            <td align="right" style=" padding:0px;" height="100%" width="74%">
                                                <table align="center" width="100%" height="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center" width="50%" height="100%" style="border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%" id="netMeteringMeterRead"></td>
                                                        <!-- <td align="center" width="50%" height="100%" style=" color:#000000">********</td> -->
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" colspan="2" style="width:50%; padding:0px; border-top:solid 0.05vw #0099FF;" height="100%">
                                    <table align="center" width="100%" height="100%" style=" padding:0;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" width="50%" height="100%" style="border-left:solid 0.05vw #0099FF; width:50%; padding:0px; color:#000000; font-size:130%" id="prevNetMeteringMeterRead"></td>
                                            <td align="center" width="50%" height="100%" style=" padding:0px; color:#000000; font-size:130%" id="ebillingQuantity"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="right" height="100%" style="border-left:solid 0.05vw #0099FF; padding:0px; padding-right:1%; background:#C0DCFE; font-weight: bold" width="26%">مدور سابق</td>
                                            <td align="right" height="100%" style=" padding:0px;" width="74%">
                                                <table align="center" width="100%" height="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center" height="100%" width="100%" style=" color:#000000; font-size:130%" id="prevCarryForwardCumQty"></td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" colspan="2" height="100%" style="width:50%; padding:0px; border-top:solid 0.05vw #0099FF;">
                                    <table align="center" width="100%" height="100%" style=" padding:0;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" width="50%" height="100%" style="border-left:solid 0.05vw #0099FF; width:50%; padding:0px; background:#C0DCFE; font-weight: bold">الكمية المفوترة</td>
                                            <td align="center" width="50%" height="100%" style=" padding:0px; color:#000000; font-size:130%" id="settlementQuantity"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; background:#C0DCFE; padding:1vh; font-weight: bold" width="12%">مدور</td>
                                <td align="right" height="100%" width="88%" colspan="3" style=" border-top:solid 0.05vw #0099FF; padding:1vh; color:#000000; font-size:130%" id="nextCarryForwardCumQty"></td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" colspan="2" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; vertical-align:top; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px; color:#FFFFFF;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" style="padding:0;" width="100%" colspan="2" height="100%">
                                                <table align="center" width="100%" height="100%" style="padding:0px; color:#0044FF" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; background:#C0DCFE" width="43%" height="100%">
                                                            البيان
                                                        </td>
                                                        <td align="right" style="padding:0;" width="57%" height="100%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #0099FF;" width="35%" height="100%">
                                                                        فلس
                                                                    </td>
                                                                    <td align="center" style="padding:1%;" width="65%" height="100%">
                                                                        دينـار
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <!--;l;ll;l-->
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF;" width="43%">
                                                            قيمة الاستهلاك
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-top:solid 0.05vw #0099FF;" width="35%" id="consumptionAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="65%" id="consumptionAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF;" width="43%">
                                                            فرق اسعار الوقود
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-top:solid 0.05vw #0099FF;" width="35%" id="fuelAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="65%" id="fuelAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF;" width="43%">
                                                            اجرة العداد
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-top:solid 0.05vw #0099FF;" width="35%" id="meterRentAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="65%" id="meterRentAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF;" width="43%">
                                                            <table align="center" width="100%" cellpadding="0" cellspacing="0" height="100%">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:0px; background:#75AADF; width:2.8%; border-left:solid 0.05vw #0099FF;">
                                                                    </td>
                                                                    <td height="100%" align="right" style="padding:0;" width="57%">
                                                                        <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td height="100%" align="center" style="padding:1%; border-bottom:solid 0.05vw #0099FF; background:#C0DCFE;" width="37%">
                                                                                    فلس الريف
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="100%" align="center" style="padding:1%; border-bottom:solid 0.05vw #0099FF; background:#C0DCFE;" width="37%">
                                                                                    رسم التلفزيون
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="100%" align="center" style="padding:1%; background:#C0DCFE;" width="37%">
                                                                                    رسم النفايات
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" cellpadding="0" cellspacing="0" height="100%">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:0%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-left:solid 0.05vw #0099FF;" width="35%" id="fillsAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="65%" id="fillsAmount_dinar"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-left:solid 0.05vw #0099FF;" width="22%" id="televisionAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%;" width="41%" id="televisionAmount_dinar"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-left:solid 0.05vw #0099FF;" width="22%" id="totalRubbishAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="41%" id="totalRubbishAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" colspan="4" style="padding:0px; vertical-align:top" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF;" width="43%">
                                                            قيمة الفاتورة
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-top:solid 0.05vw #0099FF;" width="35%" id="totalBillAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="65%" id="totalBillAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF;" width="43%">
                                                            حساب التسوية
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:1%; border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-top:solid 0.05vw #0099FF;" width="35%" id="clearingAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:1%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%" width="65%" id="clearingAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="100%" align="center" style="padding:0px; border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; font-weight: bold" width="43%">
                                                            القيمة المطلوبة
                                                        </td>
                                                        <td height="100%" align="right" style="padding:0;" width="57%">
                                                            <table align="center" width="100%" height="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="100%" align="center" style="padding:3%; border-left:solid 0.05vw #0099FF; color:#000000; font-size:130%; border-top:solid 0.05vw #0099FF; font-weight: bold" width="35%" id="unClearingAmount_fils"></td>
                                                                    <td height="100%" align="center" style="padding:3%; border-top:solid 0.05vw #0099FF; color:#000000; font-size:130%; font-weight: bold" width="65%" id="unClearingAmount_dinar"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" valign="top" colspan="2" height="100%" style="border-left:solid 0.05vw #0099FF; border-top:solid 0.05vw #0099FF; vertical-align:top; width:50%; padding:0px;">
                                    <table align="center" width="100%" height="100%" style="padding:0px; color:#FFFFFF;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="top" align="center" colspan="2" style="border-top:solid 0.05vw #0099FF; width:50%; padding:0px;">
                                                <table align="center" width="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td bgcolor="#D00D0D" width="5%" style="padding:0px;">
                                                            <div class="rotate" style="width:100%; color:#FFFFFF"></div>
                                                        </td>
                                                        <td width="95%" style="padding:0px;">
                                                            <table align="center" width="100%" style="padding:0px;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td bgcolor="#D00D0D" align="center" colspan="3" style="padding:1%; color:#ffffff; border-right:none; border-top:none;" valign="top">
                                                                        تفاصيل الذمم السابقة
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="border-bottom:solid 0.05vw #D00D0D; border-left:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        رقم الفاتورة
                                                                    </td>
                                                                    <td align="center" style="border-bottom:solid 0.05vw #D00D0D; border-left:solid 0.05vw #D00D0D;color:#000000;" width="20%" valign="top">
                                                                        فلس
                                                                    </td>
                                                                    <td align="center" style="border-bottom:solid 0.05vw #D00D0D; border-left:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        دينار
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="border-bottom:solid 0.05vw #D00D0D; border-left:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-bottom:solid 0.05vw #D00D0D; border-left:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-bottom:solid 0.05vw #D00D0D; color:#000000; border-left:solid 0.05vw #D00D0D;" width="30%" valign="top">
                                                                        ********
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style=" border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********
                                                                    </td>
                                                                    <td align="center" style="border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        ********

                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********

                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="50%" valign="top">
                                                                        ********

                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********

                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D;color:#000000;" width="50%" valign="top">
                                                                        رصيد سابق
                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********

                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D;color:#000000;" width="50%" valign="top">
                                                                        مجموع قيمة الذمم
                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="20%" valign="top">
                                                                        ********

                                                                    </td>
                                                                    <td align="center" style="padding:1%; border-left:solid 0.05vw #D00D0D; border-bottom:solid 0.05vw #D00D0D; color:#000000;" width="30%" valign="top">
                                                                        ********

                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>


                                    </table>

                                </td>
                            </tr>

                            <!--;l;ll-->

                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right" style="padding:1%; height:200%; border:solid 0.05vw #D00D0D;">
                        <font style="color:#FF0000; font-size:2vw;">&bull; يفصل التيار ما لم تسدد الفاتورة خلال شهر من تاريخ الاصدار <font style="color:#000000"></font> بدون اشعار اخر</font><br />
                        <font style="font-size:1.7vw;">&bull; لا تعتبر هذه القسيمة وصلا بقيمة المطالبة إلا بعد ختمها بآلة أو ختم صندوق الشركة</font><br /><!--<font style="font-size:1.7vw; text-decoration:underline"> ملاحظات: </font> <font style="color:#000000; font-size:2vw"></font><br />-->

                    </td>
                </tr>

                

            </table>
          <table width="100%" id="barcode-table">
            <tr>
                <td colspan="4" align="center" style="padding:1%; height:200%; border:solid 0.05vw #D00D0D;" id="bar-id">
                    <font style="color:#FF0000; font-size:2vw;">     <font style="color:#000000"></font></font>
                    <font style="font-size:1.7vw;"><div style='text-align: center;'>
                      <!-- insert your custom barcode setting your data in the GET parameter "data" -->
                      <img alt='Barcode Generator TEC-IT' id="barcode-img"
                           src=''/>
                    </div></font>
                                    </td>
            </tr>
            </table>
                             </div>

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
<script src="https://cdnjs.cloudflare.com/ajax/libs/bwip-js/3.0.4/bwip-js-min.js"></script>
<script src="https://code.jquery.com/jquery-latest.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.6/jspdf.plugin.autotable.min.js"></script>
<%--<a href="../Properties/">../Properties/</a>--%>



<script>
    $("document").ready(function () {

     



        var BillHeaders = {}
        var AllFileBill = [];
        var ALLGraphdata = [];
        var MobileNoURL = $("#hdnmobileno").val();
        var apiConfiguUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["MobileAPIurl"].ToString() %>';
        var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';

        // Bill Global Data :  ---------------
 
        var InvoceList;
        var selectedInvoce;

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



                         // Declering Varible For Billing ------------------------
                         BillHeaders.CustomerName = data.body.billsHeader.firstName;
                     

                         $.each(AllBills, function (key, value) {
                            if (value.ibillingQuantity > 0) {
                                if (value.clearingDate !== "0000/00/00") {
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
                                    FileData.billName = CostsName;
                                    FileData.actualMeterReadDateTime = value.actualMeterReadDateTime;
                                    FileData.billNo = BillNo;
                                    FileData.consumptionQty = ConsQty;
                                    FileData.status = PaidStatu;
                                    FileData.billValue = BillValue;
                                    FileData.readDate = BillDates;
                                    FileData.fileNumber = FileNo;
                                    FileData.paidDate = PaymentDate;
                                    FileData.installation = value.installation;
                                    FileData.billingDocumentNo = value.billingDocumentNo;
                                    FileData.subscriptionNo = value.subscriptionNo;
                                    FileData.subscriptionDescription = value.subscriptionDescription;
                                    FileData.startBillingPeriod = value.startBillingPeriod;
                                    FileData.endBillingPeriod = value.endBillingPeriod;
                                    FileData.billPeriod = value.billPeriod;
                                    FileData.fileNumber = value.fileNumber;
                                    FileData.meterNumber = value.meterNumber;
                                    FileData.factor = value.factor;
                                    FileData.normalMeterRead = value.normalMeterRead;
                                    FileData.ibillingQuantity = value.ibillingQuantity;
                                    FileData.prevNormalMeterRead = value.prevNormalMeterRead;
                                    FileData.ebillingQuantity = value.ebillingQuantity;
                                    FileData.prevNetMeteringMeterRead = value.prevNetMeteringMeterRead;
                                    FileData.netMeteringMeterRead = value.netMeteringMeterRead;
                                    FileData.settlementQuantity = value.settlementQuantity;
                                    FileData.prevCarryForwardCumQty = value.prevCarryForwardCumQty;
                                    FileData.nextCarryForwardCumQty = value.nextCarryForwardCumQty;
                                    FileData.consumptionAmount = value.consumptionAmount;
                                    FileData.fuelAmount = value.fuelAmount;
                                    FileData.meterRentAmount = value.meterRentAmount;
                                    FileData.fillsAmount = value.fillsAmount;
                                    FileData.televisionAmount = value.televisionAmount;
                                    FileData.totalRubbishAmount = value.totalRubbishAmount;
                                    FileData.totalBillAmount = value.totalBillAmount;
                                    FileData.clearingAmount = value.clearingAmount;
                                    FileData.unClearingAmount = value.unClearingAmount;
                                    FileData.billBarCode = value.billBarCode;
                                    AllFileBill.push(FileData);
                                }
                                {

                                }
  

                            }



                        });

                        $.each(AllPaidBill, function (key, value) {


                            if (value.ibillingQuantity > 0) {
                                if (value.clearingDate !== "0000/00/00") {
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
                                    FileData.actualMeterReadDateTime = value.actualMeterReadDateTime;

                                    FileData.billName = CostsName;
                                    FileData.billNo = BillNo;
                                    FileData.consumptionQty = ConsQty;
                                    FileData.status = PaidStatu;
                                    FileData.billValue = BillValue;
                                    FileData.readDate = BillDates;
                                    FileData.fileNumber = FileNo;
                                    FileData.paidDate = PaymentDate;
                                    FileData.installation = value.installation;
                                    FileData.billingDocumentNo = value.billingDocumentNo;
                                    FileData.subscriptionNo = value.subscriptionNo;
                                    FileData.subscriptionDescription = value.subscriptionDescription;
                                    FileData.startBillingPeriod = value.startBillingPeriod;
                                    FileData.endBillingPeriod = value.endBillingPeriod;
                                    FileData.billPeriod = value.billPeriod;
                                    FileData.fileNumber = value.fileNumber;
                                    FileData.meterNumber = value.meterNumber;
                                    FileData.factor = value.factor;
                                    FileData.normalMeterRead = value.normalMeterRead;
                                    FileData.ibillingQuantity = value.ibillingQuantity;
                                    FileData.prevNormalMeterRead = value.prevNormalMeterRead;
                                    FileData.ebillingQuantity = value.ebillingQuantity;
                                    FileData.prevNetMeteringMeterRead = value.prevNetMeteringMeterRead;
                                    FileData.netMeteringMeterRead = value.netMeteringMeterRead;
                                    FileData.settlementQuantity = value.settlementQuantity;
                                    FileData.prevCarryForwardCumQty = value.prevCarryForwardCumQty;
                                    FileData.nextCarryForwardCumQty = value.nextCarryForwardCumQty;
                                    FileData.consumptionAmount = value.consumptionAmount;
                                    FileData.fuelAmount = value.fuelAmount;
                                    FileData.meterRentAmount = value.meterRentAmount;
                                    FileData.fillsAmount = value.fillsAmount;
                                    FileData.televisionAmount = value.televisionAmount;
                                    FileData.totalRubbishAmount = value.totalRubbishAmount;
                                    FileData.totalBillAmount = value.totalBillAmount;
                                    FileData.clearingAmount = value.clearingAmount;
                                    FileData.unClearingAmount = value.unClearingAmount;
                                    FileData.billBarCode = value.billBarCode;

                                    AllFileBill.push(FileData);
                                } else {

      
                                }
 

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
                                BillNo = BillNo.replace(/[^a-zA-Z0-9]/g, '');
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

                                FileData.actualMeterReadDateTime = value.actualMeterReadDateTime;

                                FileData.billName = CostsName;
                                FileData.billNo = BillNo;
                                FileData.consumptionQty = ConsQty;
                                FileData.status = PaidStatu;
                                FileData.billValue = BillValue;
                                FileData.readDate = BillDates;
                                FileData.fileNumber = FileNo;
                                FileData.paidDate = PaymentDate; 
                                FileData.installation = value.installation;
                                FileData.billingDocumentNo = value.billingDocumentNo;
                                FileData.subscriptionNo = value.subscriptionNo;
                                FileData.subscriptionDescription = value.subscriptionDescription;
                                FileData.startBillingPeriod = value.startBillingPeriod;
                                FileData.endBillingPeriod = value.endBillingPeriod;
                                FileData.billPeriod = value.billPeriod;
                                FileData.fileNumber = value.fileNumber;
                                FileData.meterNumber = value.meterNumber;
                                FileData.factor = value.factor;
                                FileData.normalMeterRead = value.normalMeterRead;
                                FileData.ibillingQuantity = value.ibillingQuantity;
                                FileData.prevNormalMeterRead = value.prevNormalMeterRead;
                                FileData.ebillingQuantity = value.ebillingQuantity;
                                FileData.prevNetMeteringMeterRead = value.prevNetMeteringMeterRead;
                                FileData.netMeteringMeterRead = value.netMeteringMeterRead;
                                FileData.settlementQuantity = value.settlementQuantity;
                                FileData.prevCarryForwardCumQty = value.prevCarryForwardCumQty;
                                FileData.nextCarryForwardCumQty = value.nextCarryForwardCumQty;
                                FileData.consumptionAmount = value.consumptionAmount;
                                FileData.fuelAmount = value.fuelAmount;
                                FileData.meterRentAmount = value.meterRentAmount;
                                FileData.fillsAmount = value.fillsAmount;
                                FileData.televisionAmount = value.televisionAmount;
                                FileData.totalRubbishAmount = value.totalRubbishAmount;
                                FileData.totalBillAmount = value.totalBillAmount;
                                FileData.clearingAmount = value.clearingAmount;
                                FileData.unClearingAmount = value.unClearingAmount;
                                FileData.billBarCode = value.billBarCode;

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
            newArray.reverse();
            InvoceList =   newArray;
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
                var SixDiv = "<div class='col-xs-6 col-sm-6 col-md-2' ><a href='#' data-billNo=" + key +" class='btn btn-primary showBillModal' id='showBillModal' > مشاهدة الفاتورة</a></div>";
                //var SixNewDiv = "<div class='col-xs-6 col-sm-6 col-md-1'><h4>تاريخ الدفع</h4> <a href='#' data-billnos=" + value.billNo + " data-amount=" + value.billValue + "  class='Paymentcls'  > pay </a > </div>";
                var EndHtmlRow = "</div>";
                var EndHtmlLi = "</li>";
                var thisLi = HtmlLi + HtmlRow + FirstDiv + SecondDiv + ThirdDiv + FourthDiv + StatusDiv + FiveDiv + SixDiv + EndHtmlRow + EndHtmlLi;
                HtmlLIContaint = HtmlLIContaint + thisLi;

                // امبلمنت متغيرات الترحيل 
                
                


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
                            var HTMLa_pop = "<a href='#' data-filename=" + fileNumber + " class='changeFileData' id='changeFileData'>عرض التفاصيل </a >";
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

        $(".showBillModal").click(function (event) {

            var index = event.target.attributes.getNamedItem('data-billNo').value;
            console.log(index)
            selectedInvoce = InvoceList[index];
            // split Fils & Dinar
            var consumptionAmount_split = (selectedInvoce.consumptionAmount).split('.');
            var fuelAmount_split = (selectedInvoce.fuelAmount).split('.');
            var meterRentAmount_split = (selectedInvoce.meterRentAmount).split('.');
            var fillsAmount_split = (selectedInvoce.fillsAmount).split('.');
            var televisionAmount_split = (selectedInvoce.televisionAmount).split('.');
            var totalRubbishAmount_split = (selectedInvoce.totalRubbishAmount).split('.');
            var totalBillAmount_split = (selectedInvoce.totalBillAmount).split('.');
            var clearingAmount_split = (selectedInvoce.clearingAmount).split('.');
            var unClearingAmount_split = (selectedInvoce.unClearingAmount).split('.');

            var actualMeterRead = (selectedInvoce.actualMeterReadDateTime).slice(0,-4);
            $('#BillName').text(selectedInvoce.billName);
            $('#BillInstallation').text(selectedInvoce.installation);
            $('#subscriptionNo').text(selectedInvoce.subscriptionNo);
            $('#subscriptionDescription').text(selectedInvoce.subscriptionDescription);
            $('#startBillingPeriod').text(selectedInvoce.startBillingPeriod);
            $('#endBillingPeriod').text(selectedInvoce.endBillingPeriod);
            $('#billPeriod').text(selectedInvoce.billPeriod);
            $('#fileNumberI').text(selectedInvoce.fileNumber);
            $('#factor').text(selectedInvoce.factor);
            $('#meterNumber').text(selectedInvoce.meterNumber);
            $('#endBillingPeriod1').text(actualMeterRead);
            $('#normalMeterRead').text(selectedInvoce.normalMeterRead);
            $('#normalMeterRead1').text(selectedInvoce.normalMeterRead);
            $('#ibillingQuantity').text(selectedInvoce.ibillingQuantity);
            $('#prevNormalMeterRead').text(selectedInvoce.prevNormalMeterRead);
            $('#netMeteringMeterRead').text(selectedInvoce.netMeteringMeterRead);
            $('#prevNetMeteringMeterRead').text(selectedInvoce.prevNetMeteringMeterRead);
            $('#ebillingQuantity').text(selectedInvoce.ebillingQuantity);
            $('#prevCarryForwardCumQty').text(selectedInvoce.prevCarryForwardCumQty);
            $('#settlementQuantity').text(selectedInvoce.settlementQuantity);
            $('#nextCarryForwardCumQty').text(selectedInvoce.nextCarryForwardCumQty);
            $('#consumptionAmount_fils').text(consumptionAmount_split[1]);
            $('#consumptionAmount_dinar').text(consumptionAmount_split[0]);
            $('#fuelAmount_fils').text(fuelAmount_split[1]);
            $('#fuelAmount_dinar').text(fuelAmount_split[0]);
            $('#meterRentAmount_fils').text(meterRentAmount_split[1]);
            $('#meterRentAmount_dinar').text(meterRentAmount_split[0]);
            $('#fillsAmount_fils').text(fillsAmount_split[1]);
            $('#fillsAmount_dinar').text(fillsAmount_split[0]);
            $('#televisionAmount_fils').text(televisionAmount_split[1]);
            $('#televisionAmount_dinar').text(televisionAmount_split[0]);
            $('#totalRubbishAmount_fils').text(totalRubbishAmount_split[1]);
            $('#totalRubbishAmount_dinar').text(totalRubbishAmount_split[0]);
            $('#totalBillAmount_fils').text(totalBillAmount_split[1]);
            $('#totalBillAmount_dinar').text(totalBillAmount_split[0]);
            $('#clearingAmount_fils').text(clearingAmount_split[1]);
            $('#clearingAmount_dinar').text(clearingAmount_split[0]);
            $('#unClearingAmount_fils').text(unClearingAmount_split[1]);
            $('#unClearingAmount_dinar').text(unClearingAmount_split[0]);
            var barcode = selectedInvoce.billBarCode;
            $("#barcode-img").attr("src", "https://barcode.tec-it.com/barcode.ashx?data=" + barcode + "&code=Code128&translate-esc=true");
            console.log(selectedInvoce.unClearingAmount);
            if (selectedInvoce.unClearingAmount == "0.000") {
                $("table#barcode-table").css("display", "none");
            } else {
                $("table#barcode-table").css("display", "table");
            }
            $("#myModalBillImage").modal('show');
        })

        //    var doc = new jsPDF();
        //    var specialElementHandlers = {
        //        '#editor': function (element, renderer) {
        //            return true;
        //        }
        //    };

        //$('#getpdb_btn').click(function () {
        //    doc.fromHTML($('#Table-Bill').html(), 15, 15, {
        //            'width': 170,
        //            'elementHandlers': specialElementHandlers
        //        });
        //        doc.save('Bill.pdf');
        //});


    });
    var myApp = new function () {
        this.printTable = function () {
            var tab = document.getElementById('BillBodyId');

            var style = "<style>";
            style = style + "table {width: 100%;font: 17px Calibri;}";
            style = style + " th, td {border: none; border-collapse: unset;";
            style = style + "padding: 2px 3px;}";
            style = style + "</style>";

            var win = window.open();
            win.document.write(style);          //  add the style.
            win.document.write(tab.outerHTML);
            win.document.close();
            win.print();
        }
    }
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
    @media(min-width:768px){
            div#MyAllFiles .col-md-2 {
        width: 15%;
    }   
    }
    @media(min-width:992px){
        a#showBillModal {
            margin-top: 20px;
            margin-right: 10px;
        }
    }
    #getpdb_btn{
        background: #dec84d;
        border-color: #dec84d;
        padding: 8px 25px;
    }


    /* Bill Style */
    .divBillModal .modal-dialog{
        max-width : 1300px;
    }
     #tab20 {
            font-family: gesslight !important;
        }

        #tab21 {
            font-family: gesslight !important;
        }

        .bor td {
            padding: 1%;
        }

        .BillBody {
            font-size: 1.3vw;
            color: #4144f2;
            font-family: gesslight !important;
        }

        .BillBody tbody {
            height: 100%;
        }

        .rotate {
            /* Safari */
            -webkit-transform: rotate(-90deg);
            /* Firefox */
            -moz-transform: rotate(-90deg);
            /* IE */
            -ms-transform: rotate(-90deg);
            /* Opera */
            -o-transform: rotate(-90deg);
            /* Internet Explorer */
            filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3);
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
    
     




