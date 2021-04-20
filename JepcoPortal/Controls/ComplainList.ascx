<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ComplainList.ascx.cs" Inherits="Controls_ComplainList" %>

<div class="detil_counter_rowone">
    <div class="newcounter newcounter1">
        <p>الشكاوى المقدمة </p>
        <h1><asp:Label runat="server" ID="ComplainCount"></asp:Label></h1>
    </div>
    <div class="ReportMess newcounter2">
        <p>الشكاوى المغلقة</p>
        <h1><label id="CountIsOpenlbl"></label></h1>
        
    </div>
    <div class="newcounter newcounter3">
        <p>الشكاوى المفتوحة</p>
        <h1><label id="CountIsCloselbl"></label></h1>
        
    </div>
</div>
<div class="clearfix"></div>
<div class="delsearch_delfilter">
    <div class="delfilter">
        <a style="background: #3f8ab2;" class="ShowOpn" href="#">اظهار الشكاوى غير المغلقة</a>
        <a style="background: #dec84d;" class="Showcls" href="#">اظهار كافة الشكاوى</a>
    </div>
   <h3>
       <a href="/ar/Home/ComplainList/ComplainForm" class="Submit_complaint">	تقديم شكوى جديدة</a>
   </h3>
       
   </div>
<div class="clearfix"></div>
<div class="protal_tabs">

    <div id="CopmlainEmptyDiv" class="emptyfilecls" style="display: none" runat="server">
                                            <img src=" <%=ResolveUrl("~/") %>App_Themes/ThemeAr/img/Step-Icon-2.png" alt="">
                                           <%--  <strong>
                                            <a href="#" >اضافة/ تعديل رقم عداد</a>
                                        </strong>--%>
    </div>

    <div class="billlist">
        <ul class="list-unstyled">



            <asp:ListView runat="server" ID="lstComplain" OnItemDataBound="lstComplain_ItemDataBound">
                <ItemTemplate>
                    <li>
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
                                    <%-- <button style="background: #f9db32; color: #007fc3;">قيد التنفيذ</button>--%>
                                </div>
                               
                            </div>



                        </div>
                    </li>
                </ItemTemplate>
            </asp:ListView>


          



        </ul>
    </div>


</div>


<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

 <script>
            $("document").ready(function () {

                
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
                 .Cmpdetailsbtndiv a {
   
    color: #007fc3;
    font-size: 18px;
    border: none;
    width: 133px;
    line-height: 60px;
    margin-left: 10px;
    text-align: center;
}
             
</style>





