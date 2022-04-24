<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Subscriptions.ascx.cs" Inherits="Controls_Subscriptions" %>
<%@ Register Src="~/Controls/AddFileNumber.ascx" TagPrefix="uc1" TagName="AddFileNumber" %>


<aside>
        <h1><%--<small>الاستهلاك في ال 12 شهرا الأخيرة</small>--%>
           إدارة الإشتراكات</h1>
       <img src="/App_Themes/ThemeAr/img/ايقونة%20الاشتراكات-02.png" style="width: 75px;"/>
</aside>
<div class="billlist" >
    <div class="detil_counter_rowone">
                <div class="newcounterBox ReportMess5">
                    <p>الأسم :</p>

                    <label id="name_cust"></label>


                </div>

                <div class="newcounterBox ReportMess1">
                    <p>عدد الإشتراكات : 
                    </p>
                    <label id="lblUnpaidAmount"></label>


                </div>
        <a href="/ar/Home/addFile" style="display: contents;">
                <div class="newcounterBox newcounter2">
                    <p>إضافة إشتراك
                    </p>

                    <label id="" style="font-size: 35px;cursor:pointer">+</label>


                </div>
            </a>



            </div>


    <div class="Cont-scroll" id="style-4">
        <div id="MyAllFiles">
        <ul class="list-unstyled list-bill">
            
            
            </ul>
    </div>
        </div>
    
</div>




        <asp:HiddenField runat="server" ID="htdFilenameDetais" />
        <asp:Button ID="LnkPaymentDetails" runat="server" Text="تصويت" OnClick="LnkPaymentDetails_Click" Style="display: none;" />

          <div id="loading">
              <div id="loader"></div><br />
              <h3 style="color:#007fc3;font-weight:bold">شركة الكهرباء الأردنية  </h3>
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
 <script>
     $(window).load(function () {
         $('#loading').hide();
     });
 </script> 
<script>
    var MobileNoURL = $("#hdnmobileno").val();
    $("#lblUnpaidBills").text(MobileNoURL)
    var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';
    var ArrayFile = [];
    var customerName = "";
    $(document).ready(function () {


        $.ajax({
            type: "POST",
            url: APIUrl + "CustomerInfo/GetCustomerInfoData",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("MiddlewareToken"));
            },
            data: JSON.stringify({
                MobileNumber: MobileNoURL,
                LanguageId: "AR"
            }),
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                console.log(data)
                var i = 0;
                ArrayFile = data.body.customerInfoResult.customerInformationDetails;
                customerName = data.body.customerInfoResult.firstName + " " + data.body.customerInfoResult.lastName
                $.each(ArrayFile, function (key, value) {
                    console.log(key, " : ", value);
                    i++;
                    var html1 = "<li><div class='row'><div class='col-xs-6 col-sm-6 col-md-4'><h4>التسمية : </h4><span class='LTR'>"+value.aliasName+"</span></div>";
                    var html2 = "<div class='col-xs-6 col-sm-6 col-md-4'><h4> رقم الملف : </h4><span class='LTR'>"+value.fileNumber+"</span></div>";
                    var html3 = "<div class='col-xs-6 col-sm-6 col-md-2'><a href='#' data-filename='"+ value.fileNumber +"' class='btn btn-primary update-link btn-update'>تعديل </a></div>";
                    var html4 = "<div class='col-xs-6 col-sm-6 col-md-2'><button type='button' class='btn btn-danger btn-update'>حذف </button></div></div></li>";

                    $(".list-bill").append(html1 + html2 + html3 + html4);
                })
                $("#lblUnpaidAmount").text(i);
                $("#name_cust").text(customerName);
            },
            error: function (err) {
                console.log(err);
            }
        })

        $(".update-link").click(function (e) {
            var filename = $(this).data("filename");

            console.log("file: ", filename)
            $('#<%=htdFilenameDetais.ClientID %>').val(filename);
            $("[id*=<%=LnkPaymentDetails.ClientID %>]").click();


        })
    })


 
</script>


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
        justify-content: space-around;
        padding: 25px 20px;
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
            font-size: 20px;
            color: white;
            margin-bottom : 0;
        }
        .ReportMess5{
            background:#007fc3;
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
        .sub-section{
            background : #fff;
               padding: 40px;

        }
        .btn-update{
                font-size: 16px;
    padding: 7px 40px;
    margin-top: 8px;
        }


        #style-4::-webkit-scrollbar-track
{
	background-color: #eee;
}

#style-4::-webkit-scrollbar
{
	width: 5px;
	background-color: #F5F5F5;
}

#style-4::-webkit-scrollbar-thumb
{
	background-color: #dec84d;
	border: 2px solid #dec84d;
}
.Cont-scroll {
    padding: 15px;
    max-height: 1425px;
    overflow-y: auto;
}
.billlist span{
    font-size:19px
}
.prrtal_mainpart aside{
        padding: 15px 30px;

}
</style>