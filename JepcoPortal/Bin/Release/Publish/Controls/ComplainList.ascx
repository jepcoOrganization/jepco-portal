<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComplainList.ascx.cs" Inherits="Controls_ComplainList" %>

<div class="modal fade welcome modal-complain" id="myModalBill" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="head-title">تفاصيل الشكوى</h2>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span class="fa fa-close"></span>
                </button>

            </div>
 <div class="modal-body">
    <div class="card-header">

        <div class="con">
            <div class="col-log-bg_6 col-lg-6 col-md-6 col-sm-6 col-12">
                <div class="head">
                    <strong>رقم الشكوى </strong>
                </div>
                <div class="min">
                    <h5 id="transaction"></h5>
                </div>
            </div>

            <div class="col-log-bg_6 col-lg-6 col-md-6 col-sm-6 col-12">
                <div class="head">
                    <strong>تاريخ الشكوى </strong>
                </div>
                <div class="min">
                    <h5 id="fileNumberPopup"></h5>
                </div>
            </div>
        </div>

        <div class="con">
            <div class="col-log-bg_6 col-lg-6 col-md-6 col-sm-6 col-12">
                <div class="head">
                    <strong>نوع الشكوى </strong>
                </div>
                <div class="min">
                    <h5 id="amount"></h5>
                </div>
            </div>
            <div class="col-log-bg_6 col-lg-6 col-md-6 col-sm-6 col-12">
                <div class="head">
                    <strong>رقم العداد </strong>
                </div>
                <div class="min">
                    <h5 id="bill-type"></h5>
                </div>
            </div>
        </div>
        <div class="con1">
            <div class="hea">
                <strong>تفاصيل الشكوى :</strong>
            </div>
            <div class="mi">
                <h5 id="date-bill" style="font-size: 16px;"></h5>
            </div>
        </div>

        <div class="con2">
            <div class="head2">
                <strong>حالة الشكوى</strong>
            </div>
            <div class="min2">
                <h5 id="bill-order-type" > </h5>
            </div>
        </div>

    </div>
</div>
            <div class="modal-footer">
                <%--<button id="SubmitFillCall"  >Save</button>--%>

                <%-- <button>موافق</button>--%>
            </div>
        </div>
    </div>
</div>



<div class="detil_counter_rowone">
    <div class="newcounter newcounter1">
        <p>جميع الشكاوى </p>
        <h1><asp:Label runat="server" ID="ComplainCount" Style="display:none"></asp:Label><label id="ComplainCount1" ></label></h1>
    </div>
    <div class="newcounter newcounter2">
        <p>الشكاوى المغلقة</p>
        <h1><label id="CountIsOpenlbl" Style="display:none"></label><label id="CountIsOpenlbl1" ></label></h1>
        
    </div>
    <div class="newcounter newcounter3">
        <p>الشكاوى المفتوحة</p>
        <h1><label id="CountIsCloselbl" Style="display:none"></label><label id="CountIsCloselbl1" ></label></h1>
        
    </div>
        <div class="newcounter newcounter4">
        <p>الشكاوى قيد التنفيذ</p>
        <h1><label id="CountInProglbl1" ></label></h1>
        
    </div>
</div>
<div class="clearfix"></div>
<div class="delsearch_delfilter">
    <div class="delfilter">

        <a style="background: #e46a6a;" class="ShowOpn fil1" >جميع الشكاوى</a>
                <a style="background: #4db6c9;" class="Showcls fil4" >الشكاوى المغلقة</a>
                <a style="background: #e89973;" class="ShowOpn fil3" >الشكاوى المفتوحة</a>

                <a style="background: #dec84d;" class="Showcls fil2" >الشكاوى قيد التنفيذ</a>

    </div>
   <h3>
       <a href="/ar/Home/ComplainList/ComplainForm" class="Submit_complaint">	تقديم شكوى جديدة</a>
   </h3>
       
   </div>
<div class="clearfix"></div>
<div class="protal_tabs">

    <div id="CopmlainEmptyDiv" class="emptyfilecls"  runat="server">
                               <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/سجل%20الدفعات-11.png" alt="" style="margin-bottom: 20px; width: 210px;"><br />
                                            <strong style="font-size: 22px;">
                                            <a href="/ar/Home/ComplainList/ComplainForm" >لا يوجد شكاوى</a>
                                        </strong>
    </div>

    <div class="billlist">
        <ul class="list-unstyled">

               <div class="row inner-js" style="overflow-x:auto">
<%--      <div class="col-lg-12 col-sm-12 col-md-12">


         <div class="billnum" >
               <h2 class='billno'>2021-06</h2>
         </div>

   </div>--%>
   <table class="table table-history  table-hover table-responsive table-success" >
      <thead>
         <tr>
             <th></th>
            <th>  الرقم المرجعي للشكوى</th>
            <th> تاريخ الشكوى </th>
            <th>نوع الشكوى</th>
            <th>الحالة</th>
             <th></th>
         </tr>
      </thead>
      <tbody class="body-table-list">
         
   </table>

</div>

            <asp:ListView runat="server" ID="lstComplain" OnItemDataBound="lstComplain_ItemDataBound" Style="display:none">
                <ItemTemplate>
                  <%--  <li>
                        <div class="row">
                            <div class="col-xs-6 col-sm-6 col-md-3">
                                <h4>الرقم المرجعي للشكوى</h4>
                                <span class="LTR"><asp:Literal runat="server" ID="lblComplainStatusNo" Text='<%# Bind("IssueResultNo") %>'></asp:Literal></span>
                                <asp:HiddenField runat="server" ID="hdnCoplianStatusResult" Value='<%# Bind("IssueResultNo") %>'/>
                                <asp:HiddenField runat="server" ID="hdnBranchID" Value='<%# Bind("Governate") %>'/>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-3">
                                <h4>تاريخ الشكوى</h4>
                                <span ><asp:Literal runat="server" ID="lblCompainDate" Text='<%# Bind("PublishedDate") %>'></asp:Literal></span>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>	عنوان الشكوى </h4>
                                <span ><asp:Literal runat="server" ID="lblAddress" Text='<%# Bind("MeterNumber") %>'></asp:Literal></span>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2">
                                <h4>	نوع الشكوى</h4>
                                <span><asp:Literal runat="server" ID="lblComplainType" Text='<%# Bind("ComplainType") %>'></asp:Literal></span>
                            </div>
                            <div class="col-xs-6 col-sm-6 col-md-2" >
                                <div id="Statusbtnid" runat="server" class="Cmpdetailsbtndiv" style='background:#f9db32; color:#007fc3;border:none;text-align: center;'>
                                    <%-- <button style="background: #f9db32; color: #007fc3;">قيد التنفيذ</button>
                                </div>
                               
                            </div>




                        </div>
                    </li>--%>


                </ItemTemplate>
            </asp:ListView>


          



        </ul>
    </div>


</div>


<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
 <script>
     var MobileNoURL = $("#hdnmobileno").val();
     var APIUrl = '<%= System.Configuration.ConfigurationManager.AppSettings["APIurl"].ToString() %>';
     var allCount = 0;
     var closedCount = 0;
     var inProcessCount = 0;
     var openCount = 0;
     var allComplaint = [];
     var closedcomplaints = [];
     var inProcesscomplaints = [];
     var opencomplaints = [];
     var seclectArray = [];
     var selectopencomplaints = [];
     var selectclosedcomplaints = [];
     var selectinProcesscomplaints = []
            $("document").ready(function () {

                /* ----------------- Refresh Api --------------------- */
                $.ajax({
                    type: "POST",
                    url: APIUrl + "Complaints/UpdateComplaintStatus",
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
                    },
                    error: function (err) {
                        console.log(err);
                    }
                })
  
                /* ----------------- Get Compaints Api --------------------- */
                $.ajax({
                    type: "POST",
                    url: APIUrl + "Complaints/ComplaintByID",
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

                        allCount = data.body.allCount;
                        openCount = data.body.openCount;
                        inProcessCount = data.body.inProcessCount;
                        closedCount = data.body.closedCount;
                        allComplaint.push.apply(allComplaint,data.body.closedcomplaints)
                        allComplaint.push.apply(allComplaint,data.body.inProcesscomplaints)
                        allComplaint.push.apply(allComplaint,data.body.opencomplaints)
                        selectinProcesscomplaints = data.body.inProcesscomplaints;
                        selectclosedcomplaints = data.body.closedcomplaints;
                        selectopencomplaints = data.body.opencomplaints;

                        $.each(allComplaint, function (key, value) {
                            var splitDate = value.complainDate.split("T");
                            var splitcomplainRefrenceNumber = value.complainRefrenceNumber.split(":");
                            var html1 = "<tr class='complainRow fil1-row' index='" + key + "' ><td>" + ++key + "</td><td><label style='font-size: 15px;'> " + splitcomplainRefrenceNumber[1]+"</label></td>";
                            var html2 = "<td><label style='font-size:15px;'>" + splitDate[0] + "</label></td><td><label style='font-size:15px;'>" + value.complainTypeName +"</label></td>";
                            var html3 = "<td><label style='font-size:15px;'> " + value.complainStatus +" </label></td><td><button type='button' class='btn btn-primary'>عرض التفاصيل</button></td></tr>";
                            $(".body-table-list").append(html1 + html2 + html3);
                        })
                        $.each(data.body.closedcomplaints, function (key, value) {
                            var splitDate = value.complainDate.split("T");
                            var splitcomplainRefrenceNumber = value.complainRefrenceNumber.split(":");
                            var html1 = "<tr class='complainRow fil4-row' index='" + key + "' ><td>" + ++key + "</td><td><label style='font-size: 15px;'> " + splitcomplainRefrenceNumber[1] + "</label></td>";
                            var html2 = "<td><label style='font-size:15px;'>" + splitDate[0] + "</label></td><td><label style='font-size:15px;'>" + value.complainTypeName + "</label></td>";
                            var html3 = "<td><label style='font-size:15px;'> " + value.complainStatus + " </label></td><td><button type='button' class='btn btn-primary'>عرض التفاصيل</button></td></tr>";
                            $(".body-table-list").append(html1 + html2 + html3);
                        })
                        $.each(data.body.inProcesscomplaints, function (key, value) {
                            var splitDate = value.complainDate.split("T");
                            var splitcomplainRefrenceNumber = value.complainRefrenceNumber.split(":");
                            var html1 = "<tr class='complainRow fil2-row' index='" + key + "' ><td>" + ++key + "</td><td><label style='font-size: 15px;'> " + splitcomplainRefrenceNumber[1] + "</label></td>";
                            var html2 = "<td><label style='font-size:15px;'>" + splitDate[0] + "</label></td><td><label style='font-size:15px;'>" + value.complainTypeName + "</label></td>";
                            var html3 = "<td><label style='font-size:15px;'> " + value.complainStatus + " </label></td><td><button type='button' class='btn btn-primary'>عرض التفاصيل</button></td></tr>";
                            $(".body-table-list").append(html1 + html2 + html3);
                        })
                        $.each(data.body.opencomplaints, function (key, value) {
                            var splitDate = value.complainDate.split("T");
                            var splitcomplainRefrenceNumber = value.complainRefrenceNumber.split(":");
                            var html1 = "<tr class='complainRow fil3-row' index='" + key + "' ><td>" + ++key + "</td><td><label style='font-size: 15px;'> " + splitcomplainRefrenceNumber[1] + "</label></td>";
                            var html2 = "<td><label style='font-size:15px;'>" + splitDate[0] + "</label></td><td><label style='font-size:15px;'>" + value.complainTypeName + "</label></td>";
                            var html3 = "<td><label style='font-size:15px;'> " + value.complainStatus + " </label></td><td><button type='button' class='btn btn-primary'>عرض التفاصيل</button></td></tr>";
                            $(".body-table-list").append(html1 + html2 + html3);
                        })
                        /* -------- Send Value To HTML ------------ */
                        $("#ComplainCount1").text(allCount)
                        $("#CountIsOpenlbl1").text(closedCount)
                        $("#CountInProglbl1").text(inProcessCount)
                        $("#CountIsCloselbl1").text(openCount)
                    },
                    error: function (err) {
                        console.log(err);
                    }
                })


                var fsjdf = $("[id$=ComplainCount]").text();

                var isopenCount = 0;
                var isCloseCount = 0;
                
                for (var i = 0; i < fsjdf; i++) {
                     
                    
                    var statusResul = $("#ContentPlaceHolder1_ctl00_lstComplain_hdnCoplianStatusResult_" + i).val(); 
                    var StutuBtranchid = $("#ContentPlaceHolder1_ctl00_lstComplain_hdnBranchID_" + i).val(); 

                    var StatusID = "0";

                    $.ajax({

                        type: "POST",
                        url: "/Default.aspx/GetComplainStatus",
                        data: "{RefCode:'" + statusResul + "',BranchID:'" + StutuBtranchid + "'}",
                        contentType: "application/json; charset-utf-8",
                        dataType: "json",
                        async: false,

                        //contentType: 'application/json',
                        // data: govidSelected //JSON.stringify(govidSelected),

                        success: function (result) {
                           
                            StatusID = result.d;
                           
                           
                            $.ajax({
                                type: "POST",
                                url: "/Default.aspx/BindCopalianStstubyID",
                                data: "{CompalinStatusID:'" + StatusID + "',StutuBtranchid:'" + StutuBtranchid + "'}",
                                contentType: "application/json; charset-utf-8",
                                dataType: "json",
                                async: false,
                                success: function (result) {

                                  
                                    debugger;
                                    console.log(result);
                                    console.log(result.d.length);
                                    if (result.d.length <= 0) {
                                        
                                        isopenCount = 0;
                                        isCloseCount = 0;
                                        $("#ContentPlaceHolder1_ctl00_lstComplain_Statusbtnid_" + i).append("<a></a>");
                                    }
                                    else {
                                       

                                        var ThisStatu = "";

                                        ThisStatu = result.d[0].StatusName;
                                        if (ThisStatu == "حلت") {
                                            debugger;
                                            $("#ContentPlaceHolder1_ctl00_lstComplain_Statusbtnid_" + i).closest('li').addClass('opncls');
                                            //$(this).closest('li').addClass('opncls');
                                            isopenCount++;
                                        }
                                        else {
                                            debugger;
                                            $("#ContentPlaceHolder1_ctl00_lstComplain_Statusbtnid_" + i).closest('li').addClass('clscls');
                                            //$(this).closest('li').addClass('clscls');
                                            isCloseCount++;
                                        }

                                        debugger;
                                        $("#ContentPlaceHolder1_ctl00_lstComplain_Statusbtnid_" + i).append("<a>" + ThisStatu + "</a>");

                                    }

                               },
                                error: function (result) {
                                  
                                  
                                    // alert(result.status + " : " + result.StatusText);
                                }
                            });
                        },
                        error: function (result) {
                            // alert(result.status + " : " + result.StatusText);
                            //isopenCount = 0;
                            //isCloseCount = 0;
                            
                        }
                    });
                }
                

               

                $("#CountIsOpenlbl").text(isopenCount);
                $("#CountIsCloselbl").text(isCloseCount);



                $(".ShowOpn").click(function () {
                   
                    $(".clscls").hide();
                    $(".opncls").show();
                   
                });

                $(".Showcls").click(function () {
                   
                    $(".clscls").show();
                    $(".opncls").hide();

                });
            });


 </script>

<style>
    @media(min-width:992px){
            .delfilter{
        width : 70%
    }
    }

    .delfilter a{
        margin: 0 5px;
        cursor : pointer
    }
    .newcounter{
        padding : 20px 30px;
            margin: 0 10px;

    }
    .modal-complain{
                font-family: Tahoma, "Helvetica Neue", Arial, Helvetica, sans-serif !important; 

    }

    .table-history thead {
    background: #007fc3;
} 

    .table-history thead th{
        color : #fff;
        padding: 15px 0 !important;
        border : none !important;
        text-align : center
    }
    .table-history tr:hover td{
        background : #f5f5f5;
        cursor : pointer;
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
            vertical-align: middle !important;

    } 
    .table-history tbody label{
        display : contents;
        margin : 0 !important
    }
    .Cmpdetailsbtndiv button {
    width: 100px;
    height: 50px;
}

    .newcounter span {
        color : white;
    }

    
    .ReportMess label {
        color : white;
    }

    .newcounter label {
        color : white;
    }
     a.aheffuncation,
                .emptyfilecls a.ahrefcallGraph {
                    display: table;
                    margin: 20px auto 0;
                }

                .emptyfilecls {
                padding: 40px;
                 text-align: center;

            }

                .newcounter1 {
                     background: #e46a6a;
                }
                .newcounter2 {
                     background: #4db6c9;
                }
                .newcounter3 {
                     background: #e89973;
                }
                .newcounter4 {
                       background: #dec84d;

                }
                 .Cmpdetailsbtndiv a {
   
    color: #007fc3;
    font-size: 18px;
    border: none;
    width: 133px;
    line-height: 60px;
    margin-left: 10px;
    text-align: center;
}
   .card-header tr {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    background: #fff;
    padding: 15px;
    margin-bottom: 5px;
        margin-top: 10px;

    box-shadow: 3px 3px 5px rgb(0 33 66 / 20%);
    border: 1px solid #ced3d9;
}       
   .card-header tr td:nth-child(2){
           padding-right: 20px;

   } 
   .welcome .modal-body{
       padding : 0;
   text-align: inherit;
       }
    
    .welcome .modal-dialog {
        max-width : 600px
    }
    h2.head-title {
    display: contents;
}
    .card-header {
    padding: 0 15px;
}
    .welcome .modal-body {
 
    background: white !important;
}
.welcome .modal-footer {
    background: white !important;
}
h5#bill-order-type {
    font-size: 155%;
    color: darkred;
}
.min2 {
    display: flex;
    justify-content: center;
    background: #efefef;
    border-radius: 2em;
    margin: 10px;
}
.mi {
    color: #999999;
}
.head2 {
    display: flex;
    justify-content: center;
    font-size: 115%;
    color: #007fc3;
}
.con {
    display: flex;
    align-items: center;
}
.head {
    display: flex;
    justify-content: center;
    font-size: 115%;
    margin-top: 11px;
    background: white;
    color: #007fc3;
}
.min {
    display: flex;
    justify-content: space-around;
    background: #1111;
    border-radius: 4em;
    margin: 10px;
}
.hea {
    margin-top: 10px;
   font-size: 115%;
    color: #007fc3;
}
</style>





<script>
    $(document).ready(function () {


        $(".fil1-row").click(function () {


            var index = $(this).attr("index");
            seclectArray = allComplaint[index];
            var arr =  seclectArray.complainDescribtion.split("\n")
            var result = arr.filter(word => word.trim().length > 0)
            $("#transaction").text(seclectArray.complainRefrenceNumber.split(":")[1])
            $("#fileNumberPopup").text(seclectArray.complainDate.split("T")[0])
            $("#date-bill").empty();
            $("#amount").text(seclectArray.complainTypeName)
            for (let i = 0; i < result.length;i++) {
                var x = result[i] + "  " + result[++i] + "<br/><br/>"
                $("#date-bill").append(x)
                
            }
            /*$("#date-bill").text(seclectArray.complainDescribtion)*/
            $("#bill-type").text(seclectArray.meterNumber)
            $("#bill-order-type").text(seclectArray.complainStatus)

            $(".modal-complain").modal("show")
        })

        $(".fil2-row").click(function () {


            var index = $(this).attr("index");
            seclectArray = selectinProcesscomplaints[index];
            var arr = seclectArray.complainDescribtion.split("\n")
            var result = arr.filter(word => word.trim().length > 0)

            $("#transaction").text(seclectArray.complainRefrenceNumber.split(":")[1])
            $("#fileNumberPopup").text(seclectArray.complainDate.split("T")[0])
            $("#date-bill").empty();
            $("#amount").text(seclectArray.complainTypeName)
            for (let i = 0; i < result.length; i++) {
                var x = result[i] + "  " + result[++i] + "<br/>"
                $("#date-bill").append(x)

            }
            /*$("#date-bill").text(seclectArray.complainDescribtion)*/
            $("#bill-type").text(seclectArray.meterNumber)
            $("#bill-order-type").text(seclectArray.complainStatus)

            $(".modal-complain").modal("show")
        })
        $(".fil3-row").click(function () {


            var index = $(this).attr("index");
            seclectArray = selectopencomplaints[index];
            var arr = seclectArray.complainDescribtion.split("\n")
            var result = arr.filter(word => word.trim().length > 0)
            $("#transaction").text(seclectArray.complainRefrenceNumber.split(":")[1])
            $("#fileNumberPopup").text(seclectArray.complainDate.split("T")[0])
            $("#date-bill").empty();
            $("#amount").text(seclectArray.complainTypeName)
            for (let i = 0; i < result.length; i++) {
                var x = result[i] + "  " + result[++i] + "<br/>"
                $("#date-bill").append(x)

            }
            /*$("#date-bill").text(seclectArray.complainDescribtion)*/
            $("#bill-type").text(seclectArray.meterNumber)
            $("#bill-order-type").text(seclectArray.complainStatus)

            $(".modal-complain").modal("show")
        })
        $(".fil4-row").click(function () {


            var index = $(this).attr("index");
            seclectArray = selectclosedcomplaints[index];
            var arr = seclectArray.complainDescribtion.split("\n")
            var result = arr.filter(word => word.trim().length > 0)
            $("#transaction").text(seclectArray.complainRefrenceNumber.split(":")[1])
            $("#fileNumberPopup").text(seclectArray.complainDate.split("T")[0])
            $("#date-bill").empty();
            $("#amount").text(seclectArray.complainTypeName)
            for (let i = 0; i < result.length; i++) {
                var x = result[i] + "  " + result[++i] + "<br/>"
                $("#date-bill").append(x)

            }
            /*$("#date-bill").text(seclectArray.complainDescribtion)*/
            $("#bill-type").text(seclectArray.meterNumber)
            $("#bill-order-type").text(seclectArray.complainStatus)

            $(".modal-complain").modal("show")
        })
        $(".fil2-row").hide();
        $(".fil3-row").hide();
        $(".fil4-row").hide();

        if (allComplaint.length > 0) {

            $(".billlist").show();
            $(".emptyfilecls").hide();
        } else {
            $(".emptyfilecls").show();
            $(".billlist").hide();

        }
        $(".fil1").click(function () {
            $(".fil1-row").show();
            $(".fil2-row").hide();
            $(".fil3-row").hide();
            $(".fil4-row").hide();

            $(".billlist").show();
            $(".emptyfilecls").hide();
            if (allComplaint.length > 0) {

                $(".billlist").show();
                $(".emptyfilecls").hide();
            } else {
                $(".emptyfilecls").show();
                $(".billlist").hide();

            }
        })
        $(".fil2").click(function () {
            $(".fil1-row").hide();
            $(".fil2-row").show();
            $(".fil3-row").hide();
            $(".fil4-row").hide();

            if (selectinProcesscomplaints.length > 0) {

                $(".billlist").show();
                $(".emptyfilecls").hide();
            } else {
                $(".emptyfilecls").show();
                $(".billlist").hide();

            }
        })
        $(".fil3").click(function () {
            $(".fil1-row").hide();
            $(".fil2-row").hide();
            $(".fil3-row").show();
            $(".fil4-row").hide();
            if (selectopencomplaints.length > 0) {

                $(".billlist").show();
                $(".emptyfilecls").hide();
            } else {
                $(".emptyfilecls").show();
                $(".billlist").hide();

            }
        })
        $(".fil4").click(function () {
            $(".fil1-row").hide();
            $(".fil2-row").hide();
            $(".fil3-row").hide();
            $(".fil4-row").show();


            if (selectclosedcomplaints.length > 0) {

                $(".billlist").show();
                $(".emptyfilecls").hide();
            } else {
                $(".emptyfilecls").show();
                $(".billlist").hide();

            }
        })

   
      
    })
</script>