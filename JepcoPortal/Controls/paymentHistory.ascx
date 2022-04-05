<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentHistory.ascx.cs" Inherits="Controls_PaymentHistory" %>

<div class="table-history">
   <div class="title-payment">
   <h1>سجل الدفعات </h1>
       <img src="/App_Themes/ThemeAr/img/pay1Log3.png" class="title-img"/>
       
    </div>
<div class="container">
   <div class="row inner-js">
<%--      <div class="col-lg-12 col-sm-12 col-md-12">


         <div class="billnum" >
               <h2 class='billno'>2021-06</h2>
         </div>

   </div>--%>
<%--   <table class="table  table-hover table-responsive table-success" >
      <thead>
         <tr>
             <th></th>
            <th>  الإسم المختصر</th>
            <th> تاريخ الدفع </th>
            <th> رقم الحركة </th>
            <th>القيمة</th>
         </tr>
      </thead>
      <tbody>
         <tr>
             <th id="count">1</th>
            <td>
               <label id="aliasName" style="font-size: 15px;">حمزة السرابي</label>
            </td>
            <td>
               <label id="responseDate" style="font-size: 15px;">25/11/2021</label>
            </td>
            <td>
               <label id="fawateercomTransactionNumber" style="font-size: 15px;">1112514</label>
            </td>
            <td>
               <label id="amount" style="font-size: 15px;"> 22222 د.أ </label>
            </td>
         </tr>

      </tbody>
   </table>--%>
              </div>

</div>
    </div>





<div class="modal fade welcome " id="myModalBill" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="head-title">تفاصيل الدفعة</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
            <div class="modal-body">
                <div class="card-header">
                    <table>
                        <tr><td><strong>رقم الحركة :</strong></td><td id="transaction"></td></tr>
                        <tr><td><strong>رقم المرجع :</strong></td><td id="fileNumberPopup"></td></tr>
                        <tr><td><strong>القيمة :</strong></td><td id="amount"></td></tr>
                        <tr><td><strong>تاريخ الدفع :</strong></td><td id="date-bill"></td></tr>
                        <tr><td><strong>نوع الدفعة :</strong></td><td id="bill-type"></td></tr>
                        <tr><td><strong>مزود خدمة الدفع :</strong></td><td id="bill-order-type"> </td></tr>
                    </table>
                </div>
            </div>
            <div class="space"><h3>الفواتير</h3></div>
                        <div class="modal-body">
                <div class="card-header">
                    <div class="bill-parnet"></div>
                </div>
            </div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>

                <%-- <button>موافق</button>--%>
            </div>
        </div>
    </div>
</div>
<script>
    var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';
    var userNameMiddlewareToken = '<%= System.Configuration.ConfigurationManager.AppSettings["usernameMiddleware"].ToString() %>';
    var passwordMiddlewareToken = '<%= System.Configuration.ConfigurationManager.AppSettings["passwordMiddleware"].ToString() %>';
    var MiddlewareToken = "";
    var phoneNumber = $("#hdnmobileno").val();
    var arrayDate = [];
    var arrayResponese = [];
    var allArray = [];
    var i = 0;
    var selctedArray = [];
    $(document).ready(function () {

        // Get Token Middleware : 
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


        // Get All Payment Log : 

        $.ajax({

            type: "POST",
            url: APIUrl + "PaymentOrderHeaders/LogPayment",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
            },
            data: JSON.stringify({
                Language: "AR",
                MobileNumber: phoneNumber
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (data) {
                arrayResponese = data.body;

                $.each(arrayResponese, function (key, value) {
                    console.log("SSS : ",value)
                    var dateSplit = ((value.responseDate.split('T'))[0]).slice(0, -3)
                    arrayDate.push(dateSplit)
                    var i = 0;
                    allArray.push(
                        {
                            "name": value.aliasName,
                            "date": value.responseDate,
                            "difDate": ((value.responseDate.split('T'))[0]).slice(0, -3),
                            "amount": value.amount,
                            "transaction": value.fawateercomTransactionNumber,
                            "billArray": value.paymentOrderHeaderDetails,
                            "paymentGatewayId": value.paymentGatewayId,
                            "paymentOrderTypeId": value.paymentOrderTypeId,
                            "fileNumber": value.fileNumber,
                            key
                        }
                    )
                    //var arrayBillAmount = data.body.paymentOrderHeaderDetails;
                    //// html : 
                    //var htmlContent = "<table class='table table-hover table-responsive table-success'><thead><tr><th></th><th> الإسم المختصر</th><th> تاريخ الدفع </th><th> رقم الحركة </th><th>القيمة</th></tr></thead>";
                    //var htmlContent2 = "<tbody><tr><th>" + i++ + "</th><td><label  style='font-size: 15px;'>" + value.aliasName + "</label></td>";
                    //var htmlContent3 = "<td><label style='font-size: 15px'>" + value.responseDate + "</label></td><td><label style='font-size: 15px;'>" + value.fawateercomTransactionNumber + "</label></td>";
                    //var htmlContent4 = "<td><label  style='font-size: 15px;'> " + value.amount+" د.أ </label></td></tr></tbody></table>";

                    //var concat = htmlHeader + htmlContent + htmlContent2 + htmlContent3 + htmlContent4;
                    
                })
                $.each(unique(arrayDate), function (index, value) {
                    var count = 1;
                    var htmlHeader = "<div class='col-lg-12 col-sm-12 col-md-12'><div class='billnum'><h2 class='billno'>" + value + "</h2></div></div>";
                    var htmlContent = "<table class='table table-hover table-responsive table-success'><thead><tr><th></th><th> الإسم المختصر</th><th> تاريخ الدفع </th><th> رقم الحركة </th><th>القيمة</th></tr></thead><tbody class='inner-body"+i+"'>";
                    var htmlContent1 = "</tbody></table>"
                    $(".inner-js").append(htmlHeader + htmlContent + htmlContent1);
                    $.each(allArray, function (key, temp) {
                        if (value == temp.difDate) {
                            var x = temp.date.split("T");
                            var htmlContent2 = "<tr class='btn-modal' data-billNo='"+ key +"'><td>" + count++ + "</td><td><label  style='font-size: 15px;'>" + temp.name + "</label></td>";
                            var htmlContent3 = "<td><label style='font-size: 15px'>" + x[0] + "/" + x[1].split(".")[0] + "</label></td><td><label style='font-size: 15px;'>" + temp.transaction + "</label></td>";
                           var htmlContent4 = "<td><label  style='font-size: 15px;'> " + temp.amount + " د.أ </label></td></tr>";

                            var concatChild1 = htmlContent2 + htmlContent3 + htmlContent4;
                            $(".inner-body" + i +"").append(concatChild1);

                        }
                    })
                    
                    i++;

                })
            },
            error: function (result) {
                console.log(result);
            }
        });

        // Get all date With
        function unique(list) {
            var result = [];
            $.each(list, function (i, e) {
                if ($.inArray(e, result) == -1) result.push(e);
            });
            return result;
        }
        console.log(allArray)

        $(".btn-modal").click(function (event) {
            var index = $(this).attr("data-billNo");
            //var index = event.target.attributes.getNamedItem('data-billNo').value;
            console.log("index : ",index)
            selctedArray = allArray[index]
            console.log("select : ", selctedArray)

            var x = selctedArray.date.split("T");
            var final_date = x[0] + " / " + x[1].split(".")[0];
            var billType;
            var paymentGatewayId;
            var htmlappeend;
            if (selctedArray.paymentOrderTypeId == "bills") {
                billType = "فواتير";
            }
            if (selctedArray.paymentGatewayId == "1") {
                paymentGatewayId = "إي فواتيركم";
            }

            $(".bill-parnet").empty()
        
            $("#transaction").text(selctedArray.transaction)
            $("#fileNumberPopup").text(selctedArray.fileNumber)
            $("#amount").text(selctedArray.amount + " د.أ ")
            $("#date-bill").text(final_date)
            $("#bill-type").text(billType)
            $("#bill-order-type").text(paymentGatewayId)

            $.each(selctedArray.billArray, function (key, value) {
                console.log(value)
                var htmlBox = "<div class='box-bill'><strong> " + value.billNumber + " </strong><h3>|</h3><strong>" + value.billAmount + " د.أ </strong></div>"
                /*               htmlappeend += htmlBox;*/
                $(".bill-parnet").append(htmlBox)

            })
            $("#myModalBill").modal("show")
        })

    })


</script>


<%-- Css Style Page :  --%>

<style>
    .title-img{
        width: 100px
    }
    .table-history thead{
        background : #007fc3;
    }
    .table-history thead th{
        color : #fff;
        padding: 15px 0 !important;
        border : none !important;
        text-align : center
    }
    .table-history tr:hover td{
        background : #f5f5f5;
        cursor : pointer
    }

    .table-history thead th:first-child{
        border-top-right-radius : 5px;
    }
    .table-history thead th:last-child{
        border-top-left-radius : 5px;
    }
    .table-history tbody th ,.table-history tbody td{
        padding : 15px 0 !important;
        text-align: center;
        background-color : #fff
    } 
    .table-history tbody th:first-child ,.table-history tbody td:first-child{
        padding-right : 7px !important;
    } 
    .table-history tbody th ,.table-history tbody td{
        padding-left : 7px !important;
    } 
    .table-history tbody label{
        display : contents;
        margin : 0 !important
    }
    .title-payment {
        background: #007fc3;
        color: #fff;
        padding: 15px 25px;
        margin-bottom : 15px;
        display: flex;
    justify-content: space-between;
    }
    .billnum{
        max-width: 190px;
        text-align: center;
        padding: 5px;
        background: #fff;
        border-radius: 10px;
        box-shadow: 3px 3px 5px rgb(0 33 66 / 20%);
        border: 1px solid #ced3d9;
        margin-bottom: 15px;
        display: flex;
        justify-content: center;
        align-items: center;
        font-family : Tahoma, Arial, sans-serif
    }
    .billnum .billno{
        margin : 5px ;
    }
    .table-history{
        font-family: Tahoma, "Helvetica Neue", Arial, Helvetica, sans-serif !important;
    }
    .welcome .modal-dialog {
        max-width: 600px !important;
    }
    .welcome .modal-body {
    text-align: center;
    padding: 20px 40px;
    background-color: #f5f5f5!important;
    font-family: Tahoma, "Helvetica Neue", Arial, Helvetica, sans-serif;
        border-bottom-left-radius: 25px;
    border-bottom-right-radius: 25px;
}
    .head-title{
            display: inline-block;
    margin-top: 5px !important;
    margin-right: 5px;
    }
    .modal-body table {
    width: 100%;
    text-align: initial;
}
    .modal-body table td {
    padding-bottom: 10px;
        font-size: 15px;

}
    .modal-body table strong{
        color : #007fc3;
    }
    .welcome .modal-header {
        padding: 15px 15px 5px;
    }
    .space h3{
        margin: 15px 0 2px;
    padding: 0 18px;
    color: #007fc3;
    font-size: 20px;
    }
.box-bill {
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    background: #fff;
    padding: 15px;
    margin-bottom: 5px;
    border-radius: 10px;
        box-shadow: 3px 3px 5px rgb(0 33 66 / 20%);
    border: 1px solid #ced3d9;
}
    .box-bill strong{
        color:  #007fc3
    }
    .box-bill h3{
        display:contents
    }
</style>