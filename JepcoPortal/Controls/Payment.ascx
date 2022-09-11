
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Payment.ascx.cs" Inherits="Controls_Payment" %>

<asp:HiddenField runat="server" ID="hdnFileNAme" />

<asp:HiddenField runat="server" ID="hiddenArrayBills" OnValueChanged="hiddenArrayBills_ValueChanged" />


<div class="modal fade welcome modal-data"  id="myModalFailedNoPayment" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display: contents">شركة الكهرباء الأردنية</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
           <div class="modal-body">
                <h4 class="modal-text" ></h4>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <a href="/ar/Home/Subscriptions" class="btn btn-primary" id="" style="width: 100%;padding: 20px;font-size: 20px;" >موافق</a>

            </div>
        </div>
    </div>
</div>



<div class="modal fade welcome modal-data" id="myModalFailed" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display: contents">شركة الكهرباء الأردنية</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                                   <h4>
                            <label id="errroreCreate" class="errorRef">
                                لا يمكن الاستمرار بعملية الدفع لوجود دفعة بالحساب اكبر او تساوي قيمة الذمم
                            </label>
                        </h4>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <button class="btn btn-outline-primary" id="">موافق</button>

            </div>
        </div>
    </div>
</div>


<div class="modal fade welcome modal-data" id="myModalerror2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display: contents">شركة الكهرباء الأردنية</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                       <div class="err-box alert alert-danger">
                    <p style="font-weight:bold"> خطأ : </p>
                    <p> في حال أختيار اكثر من فاتورة يجب عليك اختيار فواتير متتالية</p>
                </div>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <button type="button" class="btn btn-outline-primary" id="" data-dismiss="modal" aria-label="Close">موافق</button>

            </div>
        </div>
    </div>
</div>

<%-- Moadl Summery :  --%>

<div class="modal fade welcome modal-data" id="myModalBill" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 style="display: contents">شركة الكهرباء الأردنية</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                <div class="head-body">
                    <h3>ملخص الدفع</h3>
                </div>
                <div class="s-col" style="display: flex; justify-content: space-between;">
                    <div class="input-feild">
                        <p class="title">
                            رقم المرجع :
                        </p>
                        <strong id='fileNumber1'></strong>

                    </div>


                    <div class="input-feild">
                        <p class="title" style="text-align: center;">
                            عدد الفواتير  
                        </p>
                        <strong id='bill-no1' style="text-align: center;"></strong>
                    </div>

                </div>
                <div class="f-col">
                    <div class="input-feild">
                        <p class="title">
                            اسم المشترك : 
                        </p>
                        <strong id='CostName1' class='value-field'></strong>
                    </div>

                </div>

                <div class="input-feild">
                    <p class="title">
                        الفواتير : 
                    </p>
                    <strong id='bill-sammury'></strong>
                </div>
                <div class="input-feild">
                    <p class="title">
                        القيمة : 
                    </p>
                    <strong id='totalAmount1'></strong>
                </div>

                  <button class="helper-btn" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                    ملاحظة : عملية الدفع مربوطة بمزود خدمة الدفع
                      <span class="helper">?</span>
                  </button>
                <div class="collapse" id="collapseExample">
                  <div class="ef-helper">
                        <div class="ef-img">
                            <img src="/App_Themes/ThemeAr/img/unnamed.png" />
                        </div>
                      <div class="ef-content">
                              <h4>كيفية اتمام الدفع : </h4>
                               <p style="color:red">لا يوجد أي رسوم إضافية على استخدام  الدفع المباشر</p>
                          <ul class="ef-list" style="list-style:arabic-indic">
                              <li>بعد الضغط على الزر 'متابعة' سيتم تحويلك لصفحة الدفع المباشر المُقدمة من خلال نظام efawateercom</li>
                              <li>قم باختيار اسم البنك الذي ترغب بالدفع من خلاله.</li>
                              <li>قم باختيار نوع التعريف الخاص بالبنك.</li>
                              <li>قم بادخال رمز التعريف المعُتمد لدى بنكك بناء على المعلومات المُدخلة، سيقوم البنك الخاص بك بتحديد تفاصيل حسابك.</li>
                              <li>اضغط على زر 'متابعة'.</li>
                              <li>سيقوم البنك بارسال رسالة نصية تحتوي رمز التحقق على هاتفك المحمول.</li>
                              <li>أدخل رمز التحقق في حقل OTP، ثم اضغط زر 'ادفع'، سيقوم النظام باظهار نتيجة الدفع.</li>
                          </ul>
                      </div>
                  </div>
                </div>


            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>
                <button class="btn btn-outline-primary" id="button-payment">تسديد</button>

               <asp:TextBox runat="server" ID="txtEmail" placeholder="البريد الالكتروني" ClientIDMode="Static" CssClass="user" class="customClick" Style="font-family: Montserrat;display:none" ></asp:TextBox>

                 <asp:Button runat="server" ID="lnkSubmitFrm" OnClick="paymentreq" Text="pay" style="display:none" ></asp:Button>

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
                    <p>
                        <strong>رقم العقد :    <span>
                            <label id="contractNo"></label>
                        </span></strong>
                    </p>
                </div>
                <div class="col-lg-12 col-sm-12 col-md-12">
                    <p>
                        <strong>نوع الأشتراك :  <span>
                            <label id="subscriptionType" style="font-size: 15px;"></label>
                        </span></strong>
                    </p>
                </div>
            </div>
        </div>
        <div class="card-payment card2">
            <div class="row">
                <div class="col-lg-12 col-sm-12 col-md-12">
                    <p>
                        <strong>رقم المرجع :   <span>
                            <label id="fileNumber"></label>
                        </span></strong>
                    </p>
                </div>
            </div>
        </div>
        <div class="card-payment card3">
            <div class="row">
                <div class="col-lg-12 col-sm-12 col-md-12">
                    <p>
                        <strong>رقم العداد :   <span>
                            <label id="meterNumber"></label>
                        </span></strong>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div id="MyFileData" class="tab-content emptyfilecls list-con-payment">
        <div class='MyAllFiles'>
            <h5 class="head-payment">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="checkAll">
                    <label class="form-check-label" for="checkAll">تحديد الجميع   </label>
                </div>
                   <div class="d3">
                    <p class="p-amount">المبلغ الأجمالي : <strong id="bill-amount">00.00</strong></p>
                </div>
                <button type="button" class="btn btn-primary" id="paument-btn" disabled>تسديد الفواتير</button>

            </h5>
            <ul class="list-unstyled">
            </ul>
        </div>
    </div>
    <div class="payment-details">
        <div class="pd-container">
            <div class="pd">
                <div class="d1">
                    <p>رصيد سابق : <strong id="advPayment">00.00</strong> </p>
                </div>
                <div class="d2">
                    <p>صافي الذمم : <strong id="t-reciviable">00.00</strong></p>
                </div>

            </div>
        </div>
    </div>

</div>

          <div id="loading">
              <div id="loader"></div><br />
              <h3 style="color:#007fc3;font-weight:bold">شركة الكهرباء الأردنية  </h3>
                            <h4 style="color:#007fc3;font-weight:bold">الرجاء الأنتظار  </h4>

  <%--<img id="loading-image" src="/App_Themes/ThemeAr/img/Dual Ring-1s-200px (3).gif" alt="Loading..." style="width:200px;height:200px" />--%>
</div>
        <style>
            #loader {
    display: block;
    position: relative;

    width: 150px;
    height: 150px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #3498db;
    -webkit-animation: spin 2s linear infinite;
    animation: spin 2s linear infinite;
}
            #loader:before {
    content: "";
    position: absolute;
    top: 5px;
    left: 5px;
    right: 5px;
    bottom: 5px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #e74c3c;
    -webkit-animation: spin 3s linear infinite;
    animation: spin 3s linear infinite;
}
#loader:after {
    content: "";
    position: absolute;
    top: 15px;
    left: 15px;
    right: 15px;
    bottom: 15px;
    border-radius: 50%;
    border: 3px solid transparent;
    border-top-color: #f9c922;
    -webkit-animation: spin 1.5s linear infinite;
    animation: spin 1.5s linear infinite;
}
            #loading {
  position: fixed;
  display: flex;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  text-align: center;
  background-color: rgba(255, 255, 255,1);
  z-index: 99;
  justify-content:center;
  align-items:center;
      flex-direction: column;

}

#loading-image {

  z-index: 99999;
}
@-webkit-keyframes spin {
	0%   {-webkit-transform: rotate(0deg);}

	100% {-webkit-transform: rotate(360deg);}
}
@keyframes spin {
	0%   {transform: rotate(0deg);}

	100% {transform: rotate(360deg);}
}
        </style>

 
 
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<script>
    $(window).on('load', function () {
        $('#loading').hide();
    });
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
    var totalReciviable = "";
    var advPayment = "";
    var billNo = 0;
    var tmp = [];
    var phoneNumber = $("#hdnmobileno").val();
    var allDocumentSelected = false;
    var docArray = []
    var totalSelectedAmount = 0;
    var arrayBill = []
    var receivablePaymentAmount;


    $(document).ready(function () {


        var checkAll = $("#checkAll");

        $("#checkAll").click(function () {
            $("#bill-sammury").empty();

            tmp = [];
            if (this.checked) {
                billNo = arrayBill.length;
                $("#bill-no1").text(billNo)
                totalAmount = 0;
                docArray = [];

                for (let i = 0; i < arrayBill.length; i++) {
                    totalAmount += Number(arrayBill[i].billAmount);

                }
                $("#bill-amount").text(totalAmount.toFixed(3))

                $('.list-unstyled input:checkbox').each(function () {
                    $(".list-unstyled input:checkbox ").prop('checked', true);
                    $(".list-unstyled input:checkbox").attr("disabled", true);


                })

                $.each(arrayBill, function (key, value) {

                    var htmlbill = "<div class=''> " + value.billNumber + " --> " + value.billAmount + " د.أ </div>";
                    $("#bill-sammury").append(htmlbill)
                    
                    docArray.push(
                        {
                            "BillNumber": (value.billNumber.slice(0, -2)),
                            "BillAmount": (value.billAmount).toString(),
                            "index":key
                        }
                    )
                })

            } else {
                billNo = 0;
                $("#bill-sammury").empty();
                $("#bill-no1").text(billNo);
                docArray = [];
                totalAmount = 0
                $("#bill-amount").text(totalAmount.toFixed(3))
                $('.list-unstyled input:checkbox').each(function () {

                    $(".list-unstyled input:checkbox").prop('checked', false);
                    $(".list-unstyled input:checkbox").removeAttr("disabled");

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
                
                if (data.statusCode = "Success") {

                    receivablePaymentAmount = data.body.header.receivablePaymentAmount;
                    // Customer Details :
                    if (data.body.header.customerFirstName != "")
                        nameCustomer = data.body.header.customerFirstName;
                    else
                        nameCustomer = data.body.header.customerLastName;

                    subscriptionType = data.body.header.subscriptionType;
                    meterNumber = data.body.header.meterNumber;
                    fileNumber = data.body.header.fileNumber;
                    contractNo = data.body.header.contractNo;
                    advPayment = data.body.header.advancePaymentAmount;
                    totalReciviable = data.body.header.totalReceivablePaymentAmount;
                    arrayBill = data.body.details;
                    if (data.body.header.receivablePaymentAmount <= 0) {
                        $("#paument-btn").attr("disabled", true);
                    }
                    // send global var to html : --------------
                    $("#CostName").text(nameCustomer);
                    $("#subscriptionType").text(subscriptionType);
                    $("#meterNumber").text(meterNumber);
                    $("#fileNumber").text(fileNumber);
                    $("#contractNo").text(contractNo);
                    $("#advPayment").text(advPayment);
                    $("#t-reciviable").text(receivablePaymentAmount);

                    if ((arrayBill).length > 0) {
                        $.each(arrayBill, function (key, value) {
                            var htmlbox3 = "<li><div class='form-check'><input class='form-check-input' index='" + key + "' type='checkbox' value='" + value.billNumber + "' bill-amount='" + value.billAmount + "'><label class='form-check-label' for='flexCheckDefault'>اختيار الفاتورة</label></div>";
                            var htmlbox = "<div><strong>رقم الفاتورة</strong><span class='LTR'>" + value.billNumber + "</span></div>";
                            var htmlbox2 = "<div><strong>قيمة الفاتورة</strong><p>" + value.billAmount + "</p></div></li>";

                            var collect =  htmlbox3 + htmlbox + htmlbox2 ;
                            $(".MyAllFiles .list-unstyled").append(collect);

                            totalSelectedAmount = totalSelectedAmount + Number(value.billAmount);
                            totalSelectedAmount.toFixed(3);
                        })
                    } else {
                        $(".MyAllFiles").css("display", "none");
                        var htmlNoBill = "<div class='nobill'><img src='/App_Themes/ThemeAr/img/ايقونة%20دفع%20الفواتير-01.png' alt=''><strong>جميع الفواتير مدفوعة</strong></div >"
                        $(".list-con-payment").append(htmlNoBill);
                    }


                    $(".list-unstyled input[type='checkbox']").on("click", function () {

                        var checked = $(this).val();
                        var billatrr = Number($(this).attr('bill-amount'))
                        var index = parseInt($(this).attr('index'))
  
                     

                        parseFloat(totalAmount)
                        $("#bill-sammury").empty();

                        if ($(this).is(':checked')) {
                            billNo++;

                            totalAmount = totalAmount + billatrr;
                            $("#bill-amount").text(totalAmount.toFixed(3))
                            tmp.push({
                                "BillNumber": checked,
                                "BillAmount": billatrr,
                                index
                            });
                        }

                        else {
                            totalAmount = totalAmount - billatrr;

                            billNo--;
                            $("#bill-amount").text(totalAmount.toFixed(3))
                            //    tmp.splice($.inArray(index, tmp), 1);
                            for (let i = 0; i < tmp.length; i++) {
                                if (tmp[i].index == index) {
                                    tmp.splice(i, 1);
                                }
                            }
                        }
                    });


                }
            },
            error: function (err) {
                console.log(err);
            }
        });

        //$("#checkAll").on("change", function () {
        //    if (checkAll.is(':checked')) {
        //        $("#bill-amount").text(totalSelectedAmount.toFixed(3))
        //        $("#totalAmount1").text(totalSelectedAmount.toFixed(3))

        //    } else {
        //        $("#bill-amount").text("00.00")
        //        $("#totalAmount1").text("00.00")
        //    }
        //})


        $("#paument-btn").click(function () {

            if (Number(receivablePaymentAmount) <= 0) {
                $("#myModalFailed").modal("show")
            } else {

                if (checkAll.is(':checked')) {

                } else {
                    docArray.splice(0, docArray.length)
                    $("#bill-sammury").empty();

                }

                //if (docArray.length != 1 || docArray.length != arrayBill.length) {
                //    var currentIndex = 0;
                //    var currentIndexPlus = 1;
                //    var curretIndexMin = -1;

                //    for (let k in docArray) {
                //        if (docArray[k].index == currentIndex || )
                //    } 
                //}

                //if (checkAll.is(':checked')) {
                //    $("#CostName1").text(nameCustomer);
                //    $("#fileNumber1").text(fileNumber);
                //    $("#bill-no1").text(paymentArray.length)
                //    $("#totalAmount1").text(totalSelectedAmount.toFixed(3))

                //}
                //else {
                //    $("#CostName1").text(nameCustomer);
                //    $("#fileNumber1").text(fileNumber);
                //    $("#bill-no1").text(billNo)
                //    $("#totalAmount1").text(totalAmount.toFixed(3))

                //}

                $("#CostName1").text(nameCustomer);
                $("#fileNumber1").text(fileNumber);
                $("#bill-no1").text(billNo)
                $("#totalAmount1").text(totalAmount.toFixed(3))



                $.each(tmp, function (key, value) {

                    var htmlbill = "<div class=''> " + value.BillNumber + " --> " + value.BillAmount + " د.أ </div>";
                    $("#bill-sammury").append(htmlbill)
                    docArray.push(
                        {
                            "BillNumber": (value.BillNumber.slice(0, -2)).toString(),
                            "BillAmount": (value.BillAmount).toString(),
                            "index": value.index
                        }
                    )
                })


                //////////////////////////////////////////////

                $('#<%=hiddenArrayBills.ClientID %>').val(docArray);

                
                // The logic of consecutive bill payments : 
                var allow = true;

                docArray.sort(function (a, b) {
                    return a.index - b.index;
                })

                var current;
                var cnt = 0;

                for (let k in docArray) {

                    if (cnt == 0) {
                        current = docArray[k].index;
                        cnt++;

                        continue;
                    }


                    if ((current + 1) == docArray[k].index) {
                        current = docArray[k].index;
                        cnt++;

                    } else {
                        //   alert('error');
                        allow = false
                        break;
                    }


                }
                if (!allow) {
                    $('#myModalerror2').modal('show');


                } else {
                    var invoceList = '';
                    for (let k in docArray) {
                        if (docArray.length - 1 == k) {
                            invoceList += docArray[k].BillNumber;
                        } else {
                            invoceList += docArray[k].BillNumber + ',';
                        }

                    }
                    $('#txtEmail').val(invoceList)
                    $('#myModalBill').modal('show');

                }


            }


        })

        $("#button-payment").click(function (e) {
            e.preventDefault();


           // Send to payment  : ____________
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
                        PaymentSource: "1",
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

                    window.open(
                        res.body.paymentWebPageURL, "_blank").focus();
                    //window.location.href = res.body.paymentWebPageURL;

                },
                error: function (err) {
                    console.log(err);

                    $(".modal-text").text(err.responseJSON.errors);

                    $('#myModalFailedNoPayment').parent().append($('#myModalFailedNoPayment'));
                    $("#myModalFailedNoPayment").modal("show")


                }

            })
        });
        //}

        $("input[type='checkbox']").on("change", function () {
            if ($("input[type='checkbox']").is(":checked")) {
                $("#paument-btn").removeAttr("disabled")
            } else {
                $("#paument-btn").attr("disabled", true)

            }
        })
        $(".form-check-input").on("change", function () {
            if ($(".form-check-input").is(":checked")) {
                $("#paument-btn").removeAttr("disabled")
            } else {
                $("#paument-btn").attr("disabled", true)

            }
        })

    })

</script>

<style>
    body {
        font-family: Tahoma, "Helvetica Neue", Arial, Helvetica, sans-serif
    }

    .title-payment {
        background: #3f8ab2;
        color: #fff;
        padding: 20px;
        font-weight: bold;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

        .title-payment h1 {
            font-size: 30px
        }

    .Name-Payment {
        padding: 25px 25px 0;
        font-size: 18px;
    }

        .Name-Payment span {
            color: #8a8a8a;
        }

        .Name-Payment strong {
            color: #007fc3;
        }

    .list-con-payment {
        padding-top: 10px !important
    }

        .list-con-payment .head-payment {
            margin-bottom: 45px;
        }

        .list-con-payment .form-check {
            padding-top: 15px;
        }

    .card-header {
        display: flex;
        justify-content: space-between;
        padding: 20px;
        padding-top: 0;
    }

        .card-header .card-payment {
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

        .card-header .card2 {
            background: #4db6c9;
        }

        .card-header .card3 {
            background: #dec84d;
        }

        .card-header .card-payment strong {
            color: #fff;
        }

        .card-header .card-payment p {
            margin-bottom: 0
        }

    .list-con-payment .mCSB_dragger_bar {
        background: #dec84d !important;
    }

    @media(max-width:600px) {
        .card-header {
            flex-direction: column;
        }

            .card-header .card-payment {
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
            font-weight: bold;
            margin-bottom: 15px;
        }

        .pd strong {
            color: #007fc3;
        }

    .button-submit {
        text-align: center;
    }

        .button-submit a {
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

    .protal_tabs .tab-content h5 a {
        color: #fff;
        text-decoration: none
    }

    .img-header {
        width: 55px;
        margin-left: 10px;
    }

    @media(max-width:500px) {
        .pd {
            flex-direction: column;
        }
    }

    .welcome .modal-body {
        text-align: right;
        padding: 10px 20px;
        background: #FFF !important
    }

        .welcome .modal-body p {
            margin: 0 0 10px;
            color: #007fc3;
        }

        .welcome .modal-body strong {
            width: 100%;
            background: #1111;
            border-radius: 2em;
            display: block;
            padding: 10px 20px;
            margin-bottom: 10px;
            color: #007fc3;
        }

    .nobill strong {
        margin-bottom: 20px
    }

    .nobill img {
        width: 175px;
        margin-bottom: 5px;
        margin-top: 20px;
    }

    .nobill {
        color: #fff;
        width: auto;
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
    }

    .welcome .modal-dialog {
        max-width: 600px
    }

    .head-body {
        text-align: center
    }

        .head-body h3 {
            color: #007fc3;
            font-weight: bold
        }

    p.title {
        color: darkgray !important;
    }

    .welcome .modal-footer button {
        background: #007fc3;
        color: #fff;
        font-size: 24px;
        font-weight: bold;
        border: none;
        width: 100%;
        max-width: 100%;
        line-height: 60px;
    }
    p.p-amount {
    margin: 0;
    display: flex;
}
    .d3 {
    padding-top: 15px;
}
    strong#bill-amount {
    margin-top: 3px;
    margin-right: 8px;
}
    button#paument-btn {
    margin-top: 15px;
}
    .ef-img {
    display: flex;
    justify-content: center;
}
    .ef-img img{
        width : 150px
    }
    .ef-list li{
            padding: 6px 0;
    font-size: 15px;
    }
    .ef-content h4{
            font-weight: bold;
    padding-right: 10px;
    }
    .ef-content p{
        font-size : 15px !important;
        padding-right : 10px !important
    }
    .help {

  font: 15px Arial, sans-serif;
  color: white;
  background: #bababa;
  box-shadow: 6px 3px 18px -8px rgba(0,0,0,0.75);
  border-radius: 50%;
  padding: 8px;
  width: 16px;
  height: 16px;
  text-align: center;
  transition: 0.5s;
}
.help:hover {
  transform: translate(-3px,-3px);
  padding: 10px;
  width: 18px;
  height: 18px;
}
.helper-btn {
    background: none ;
    border: none;
    color: red;
    font-size: 15px;
    font-weight: bold;
}
.modal-data{
        overflow-y: overlay !important;
}
span.helper {
    background: #007fc3;
    color: #fff;
    border-radius: 50%;
    width: 25px;
    height: 25px;
    display: inline-flex;
    align-items: center;
    justify-content: center;
}
.err-box.alert.alert-danger {
    margin-top: 15px;
        margin-bottom: 0;
}
</style>
