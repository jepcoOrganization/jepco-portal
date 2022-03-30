﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Payment.ascx.cs" Inherits="Controls_Payment" %>

<asp:HiddenField runat="server" ID="hdnFileNAme" />



<%-- Moadl Summery :  --%>

<div class="modal fade welcome" id="myModalBill" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display:contents">شركة الكهرباء الأردينة</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                <div class="input-feild">
                    <p class="title">
                        اسم المشترك : 
                    </p>
                    <strong id='CostName1' class='value-field'></strong>
                </div>
                  <div class="input-feild">
                    <p class="title">
                        رقم المرجع : 
                    </p>
                    <strong id='fileNumber1'></strong>
                </div>                
                <div class="input-feild">
                    <p class="title">
                        الفواتير : 
                    </p>
                    <strong id='bill-sammury'></strong>
                </div>               
                <div class="input-feild">
                    <p class="title">
                        عدد الفواتير : 
                    </p>
                    <strong id='bill-no1'></strong>
                </div>
                 <div class="input-feild">
                    <p class="title">
                        القيمة : 
                    </p>
                    <strong id='totalAmount1'></strong>
                </div>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <a href="" class="btn btn-outline-primary" id="button-payment">تسديد</a>
            </div>
        </div>
    </div>
</div>

<div class="protal_tabs">
   <div class="title-payment">
      <h1>الفواتير الغير مسددة لهذا الملف</h1>
       <img src="/App_Themes/ThemeAr/img/ايقونة%20الدفع%20في%20موقع%20الدعم-01.png" class="img-header" />
 
   </div>
    <div class="Name-Payment">
            <span>اسم صاحب العداد:</span>
        <strong>
            <label id="CostName"></label>
         </strong>
    </div>
   <div class="card-header">
      <div class="card-payment">
         <div class="row">
            <div class="col-lg-12 col-sm-12 col-md-12">
               <p><strong>رقم العقد :    <span>
                  <label id="contractNo"></label>
                  </span></strong>
               </p>
            </div>
            <div class="col-lg-12 col-sm-12 col-md-12">
               <p><strong>نوع الأشتراك :  <span>
                  <label id="subscriptionType" style="font-size: 15px;"></label>
                  </span></strong>
               </p>
            </div>
         </div>
      </div>
      <div class="card-payment card2">
         <div class="row">
            <div class="col-lg-12 col-sm-12 col-md-12">
               <p><strong>رقم المرجع :   <span>
                  <label id="fileNumber"></label>
                  </span></strong>
               </p>
            </div>
         </div>
      </div>
      <div class="card-payment card3">
         <div class="row">
            <div class="col-lg-12 col-sm-12 col-md-12">
               <p><strong>رقم العداد :   <span>
                  <label id="meterNumber"></label>
                  </span></strong>
               </p>
            </div>
         </div>
      </div>
   </div>
   <div id="MyFileData" class="tab-content emptyfilecls list-con-payment">
         <div class='MyAllFiles' >
            <h5 class="head-payment">
              <div class="form-check">
                     <input class="form-check-input" type="checkbox" value="" id="checkAll">
                     <label class="form-check-label" for="checkAll">  تحديد الجميع   </label>
                </div>
                <span class="btn btn-primary" id="paument-btn">تسديد الفواتير</span>

            </h5>
            <ul class="list-unstyled">
            </ul>
         </div>
      </div>
    <div class="payment-details">
        <div class="pd-container">
            <div class="pd">
                <div class="d1">
                    <p>رصيد سابق : <strong>00.00</strong> </p>
                </div>
                <div class="d2">
                    <p>صافي الذمم : <strong>548.287</strong></p>
                </div>
                <div class="d3">
                    <p>المبلغ الأجمالي : <strong id="bill-amount">00.00</strong></p>
                </div>
            </div>
        </div>
    </div>

</div>
<script>
    // Global Variable : ---------------
    var GetFileNo = $("#ContentPlaceHolder1_ctl00_hdnFileNAme").val();
    var Language = "AR";
    var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';
    var userNameMiddlewareToken = '<%= System.Configuration.ConfigurationManager.AppSettings["usernameMiddleware"].ToString() %>';
    var passwordMiddlewareToken = '<%= System.Configuration.ConfigurationManager.AppSettings["passwordMiddleware"].ToString() %>';
    var totalAmount = 0;
    var nameCustomer = "";
    var subscriptionType = "";
    var meterNumber = "";
    var fileNumber = "";
    var contractNo = "";
    var billNo = 0;
    var tmp = [];
    var phoneNumber = $("#hdnmobileno").val();
    var allDocumentSelected = false;
    var docArray = []

    $(document).ready(function () {


        $("#checkAll").click(function () {
            if (this.checked) {
                $('.list-unstyled input:checkbox').each(function () {
                    $(".list-unstyled input:checkbox ").prop('checked', true);
                })
            } else {
                $('.list-unstyled input:checkbox').each(function () {
                    $(".list-unstyled input:checkbox").prop('checked', false);
                })
            }
        });

     

        // Token Middlware : ------------------

       
        var MiddlewareToken = "";
        $.ajax({
            url: APIUrl + 'LoginController/Login',
            type: 'POST',
            data: JSON.stringify(
                {
                    username: userNameMiddlewareToken,
                    password: passwordMiddlewareToken
                }),
            dataType: "json",
            contentType: "application/json",
            async: false,
            success: function (res) {
                MiddlewareToken = res.body.token;
                localStorage.setItem("MiddlewareToken", MiddlewareToken);
            },
            error: function (err) {
                console.log(err);
            }
        });

        // Get Bills Data : -----------------
        $.ajax({
            type: "POST",
            url: APIUrl + "MobileBills/AccountStatement",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
            },
            data: JSON.stringify({
                FileNumber: GetFileNo,
                LanguageId: Language
            }),
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                console.log(data);
                if (data.statusCode = "Success") {

                    // Customer Details :
                    if (data.body.header.customerFirstName != "") 
                        nameCustomer = data.body.header.customerFirstName;
                     else
                        nameCustomer = data.body.header.customerLastName;

                    console.log(nameCustomer)
                    subscriptionType = data.body.header.subscriptionType;
                    meterNumber = data.body.header.meterNumber;
                    fileNumber = data.body.header.fileNumber;
                    contractNo = data.body.header.contractNo;

                    // send global var to html : --------------
                    $("#CostName").text(nameCustomer);
                    $("#subscriptionType").text(subscriptionType);
                    $("#meterNumber").text(meterNumber);
                    $("#fileNumber").text(fileNumber);
                    $("#contractNo").text(contractNo);

                    if ((data.body.details).length > 0) {
                        $.each(data.body.details, function (key, value) {
                            var htmlbox = "<li><div><strong>رقم الفاتورة</strong><span class='LTR'>" + value.billNumber + "</span></div>";
                            var htmlbox2 = "<div><strong>قيمة الفاتورة</strong><p>" + value.billAmount + "</p></div>";
                            var htmlbox3 = "<div class='form-check'><input class='form-check-input' index='"+key+"' type='checkbox' value='" + value.billNumber + "' bill-amount='" + value.billAmount +"'><label class='form-check-label' for='flexCheckDefault'>اختيار الفاتورة</label></div></li>";

                            var collect = htmlbox + htmlbox2 + htmlbox3;
                            $(".MyAllFiles .list-unstyled").append(collect);
                        })
                    } else {

                    }
                    $(".list-unstyled input[type='checkbox']").on("click", function () {
                        var checked = $(this).val();
                        var billatrr = $(this).attr('bill-amount')
                        var index = $(this).attr('index')
                        if ($(this).is(':checked')) {
                            billNo++;

                            totalAmount = totalAmount + parseFloat(billatrr);
                            console.log(totalAmount)
                            $("#bill-amount").text(totalAmount)
                            tmp.push({
                                "BillNumber" : checked,
                                "BillAmount" : billatrr,
                                index
                            });
                        } else {
                            totalAmount = totalAmount - parseFloat(billatrr);
                            billNo--;
                            $("#bill-amount").text(totalAmount)
                            tmp.splice($.inArray(index, tmp), 1);
                        }
                    });

                } 
            },
            error: function (err) {
                console.log(err);
            }
        });
        $("#paument-btn").click(function () {
            $("#CostName1").text(nameCustomer);
            $("#fileNumber1").text(fileNumber);
            $("#bill-no1").text(billNo)
            $("#totalAmount1").text(totalAmount)
            docArray.splice(0, docArray.length)
            $("#bill-sammury").empty();
            $.each(tmp, function (key, value) {
                var htmlbill = "<div class=''> " + value.BillNumber + " || " + value.BillAmount + " </div>";
                $("#bill-sammury").append(htmlbill)
                docArray.push(
                    {
                        "BillNumber": value.BillNumber,
                        "BillAmount": value.BillAmount
                    }
                )
            })
            console.log("Arrya : ", docArray);
            $('#myModalBill').modal('show');

            $("#button-payment").click(function () {
                debugger;
                $.ajax({
                    url: APIUrl + 'PaymentOrderHeaders/ReturnPaymentSummary',
                    type: 'POST',
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
                    },
                    data: JSON.stringify(
                        {
                            ReferenceNumber: fileNumber,
                            ListOfDocument: docArray,
                            PaymentSource: "0",
                            Language: "AR",
                            PaymentType: "bills",
                            AllDocument: allDocumentSelected,
                            PaymentGatewayId: "1",
                            MobileNumber: phoneNumber
                        }),
                    dataType: "json",
                    contentType: "application/json",
                    async: false,
                    success: function (res) {
                        alert( res.body.paymentWebPageURL)
                        //window.location.href = res.body.paymentWebPageURL;

                    },
                    error: function (err) {
                        console.log(err);
                    }

            })
            });
        })

        $('#button').on('click', function () {
            console.log(tmp)
            
        });

    })
    
</script>

<style>

    body{
        font-family : Tahoma, "Helvetica Neue", Arial, Helvetica, sans-serif
    }
    .title-payment{
        background: #3f8ab2;
        color: #fff;
        padding: 20px;
        font-weight: bold;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    .title-payment h1{
        font-size : 30px
    }
    .Name-Payment{
        padding: 25px 25px 0;
        font-size: 18px;
    }    
    .Name-Payment span{
         color: #8a8a8a;
    } 
     .Name-Payment strong{
            color: #007fc3;

    }
    .list-con-payment{
        padding-top :10px !important
    }
    .list-con-payment .head-payment{
        margin-bottom: 45px;
    }
    .list-con-payment .form-check {
        padding-top: 15px;
    }

    .card-header{
        display : flex;
        justify-content: space-between;
        padding: 20px;
            padding-top: 0;

    }
    .card-header .card-payment{
        background: #007fc3;
        text-align: right;
        float: right;
        width: 31%;
        align-items: center;
        padding: 20px;
        display: flex;
        align-content: center;
        align-items: center;
    }
    .card-header .card2{
        background: #4db6c9;
    }
    .card-header .card3{
        background: #dec84d;
    }
    .card-header .card-payment strong{
        color : #fff;
    }
    .card-header .card-payment p{
        margin-bottom : 0
    }
    .list-con-payment .mCSB_dragger_bar {
    background: #dec84d !important;
    }
    @media(max-width:600px){
        .card-header {
            flex-direction: column;
        }
        .card-header .card-payment{
            width: 100%;
            margin-bottom: 10px
        }
    }
    .list-con-payment input[type=checkbox] {
        width: 25px;
        height: 15px;
    }
    .pd {
        display: flex;
        justify-content: space-around;
            padding: 0 20px;

    }
    .pd p {
        font-weight:bold;
        margin-bottom : 15px;
    }
    .pd strong{
            color: #007fc3;
    }
    .button-submit {
        text-align: center;
    }
    .button-submit a{
            width: 250px;
    font-weight: bold;
    padding: 10px;
    margin-bottom: 15px;
    }
    span#no-bill {
    display: contents;
    color: #007fc3;
}
     .list-con-payment li:first-child {
    padding: 20px 0;
    border-bottom: 1px solid #d4d4d4;
    border-top: 1px solid #d4d4d4;
} 
     .list-con-payment li:last-child {
    padding: 20px 0 !important;
    border-bottom: 1px solid #d4d4d4 !important;
}
     .list-con-payment li {
    padding: 20px 0;
    border-bottom: 1px solid #d4d4d4;
}
     .protal_tabs .tab-content h5 a{
         color:#fff;
         text-decoration: none
     }
     .img-header{
         width: 55px;
        margin-left: 10px;
     }
     @media(max-width:500px){
         .pd {
             flex-direction: column;
         }
     }
     .welcome .modal-body{
         text-align : right;
         padding : 10px 20px
     }
     .welcome .modal-body p{
         margin: 0 0 10px;
         color: #007fc3;
     }
    .welcome .modal-body strong {
    width: 100%;
    background: #fff;
    display: block;
    padding: 10px 20px;
    margin-bottom: 10px;
    color: #007fc3;

    }
</style>