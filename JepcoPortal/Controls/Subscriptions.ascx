<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Subscriptions.ascx.cs" Inherits="Controls_Subscriptions" %>


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
                        <label class="LTR" id="lblFileNo">0540410779496</label>
                    </span></strong></p>
                    <div class="row">
                        <div class="col-lg-6 col-sm-12 col-md-12">
                            <p><strong>المنطقة:   <span>
                                <label id="lblFileArea">ام السماق</label>
                            </span></strong></p>
                        </div>
                        <div class="col-lg-6 col-sm-12 col-md-12">
                            <p><strong>القطاع:  <span>
                                <label id="lblfileSectiontype">القطاع المنزلي</label>
                            </span></strong></p>
                        </div>
                        <p style="display: none">الذمم المستحقة:</p>
                        <label id="lblmTotalReceivabales" style="display: none">0</label>

                    </div>
                </div>

                <div class="newcounterBox ReportMess1">
                    <p>الفواتير الغير مسددة </p>

                    <label id="lblUnpaidBills">0</label>


                </div>

                <div class="newcounterBox newcounter2">
                    <p>اجمالي المبلغ المطلوب</p>

                    <label id="lblUnpaidAmount">0</label>


                </div>




            </div>



<style>
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