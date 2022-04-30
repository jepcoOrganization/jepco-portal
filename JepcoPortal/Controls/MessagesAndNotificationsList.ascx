<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessagesAndNotificationsList.ascx.cs" Inherits="Controls_MessagesAndNotificationsList" %>


<button class="filterbtn">تصفي</button>
<div class="filterboxdiv">
    <div class="mmddiv">
        <span class="detcheckbox">
            <input type="checkbox" id="one">
            <label for="one"></label>
        </span>

        <asp:LinkButton runat="server" OnClick="Unnamed_Click">حذف</asp:LinkButton>

         <asp:LinkButton runat="server" OnClick="UnRead_Click">تحديد كغير مقروء</asp:LinkButton>
        
         <asp:LinkButton runat="server" OnClick="Read_Click">تحديد كمقروء</asp:LinkButton>

       <%-- <a href="javascript:void"></a>
        <a href="javascript:void"></a>--%>
    </div>
    <div class="filrevdiv">
       
       
         <span>استعراض</span>
        <select>
            <option>جميع الرسائل</option>
            <%--<option>جميع الرسائل</option>
            <option>جميع الرسائل</option>--%>
        </select>

        <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <span>ترتيب حسب</span>
          <asp:DropDownList ID="ddlMapping" runat="server" OnSelectedIndexChanged="ddlMapping_SelectedIndexChanged" AutoPostBack="true">
          </asp:DropDownList>

                                <%--</ContentTemplate>

          </asp:UpdatePanel>--%>
          
       <%-- <span>تصفية حسب</span>
        <select>
            <option>الاحدث الى الاقدم</option>
            <option>الاحدث الى الاقدم</option>
            <option>الاحدث الى الاقدم</option>
        </select>--%>
    </div>
</div>
<div class="protal_tabs inboxlistdiv">
    <!-- Tab panes -->
    <div class="tab-content">
        <div role="tabpanel" class="tab-pane fade in active" id="home">
            <div class="residential_sector">
                <ul class="list-unstyled inboxul">

                    <asp:HiddenField runat="server" ID="hdnCountRecord" />

                    <asp:ListView runat="server" ID="lstNotificationDevice" OnItemDataBound="lstNotificationDevice_ItemDataBound" OnPagePropertiesChanging="lstNewsRow_PagePropertiesChanging" ItemPlaceholderID="itemPlaceHolder1" GroupPlaceholderID="groupPlaceHolder1">

                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstNotificationDevice" class="pagination">

                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false"
                                        ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<i class='fa fa-angle-left' aria-hidden='true'></i>" ButtonCssClass="prev" />
                                    <asp:NumericPagerField ButtonType="Link" CurrentPageLabelCssClass="active num" Visible="true" NumericButtonCssClass="num" NextPreviousButtonCssClass="num" />
                                    <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="false"
                                        ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="<i class='fa fa-angle-right' aria-hidden='true'></i>" ButtonCssClass="next" />
                                </Fields>
                            </asp:DataPager>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <li id="ListLI" runat="server">
                                <div class="div1">
                                    <span class="detcheckbox">

                                        <div id="lblforCheckbox" runat="server">

                                            <asp:CheckBox ID="CBID" runat="server" />
                                        </div>
                                      
                                    </span>
                                    <span>
                                        <asp:HiddenField runat="server" ID="hdnMsgFromUserID" Value='<%# Bind("MsgFromUserID") %>' />
                                        <asp:HiddenField runat="server" ID="hdnNotificationID" Value='<%# Bind("NotificationID") %>' />
                                        <asp:HiddenField runat="server" ID="hdnISRead" Value='<%# Bind("IsRead") %>' />
                                          
                                        <asp:HiddenField runat="server" ID="hndAttechment" Value='<%# Bind("Attachment1") %>' />
                                         <asp:Label runat="server" ID="lblUserName"></asp:Label>
                                        <strong>
                                           </strong>
                                        <p>
                                            <asp:Label runat="server" ID="lblMsg" Text='<%# Bind("Subject") %>'></asp:Label>
                                            
                                        </p>
                                    </span>
                                </div>
                                <div class="div2">

                                     <asp:Image ID="imgattech" runat="server" ImageUrl="~/App_Themes/ThemeAr/img/attech.png" />
                                   
                                    <span>
                                         <p>
                                        <asp:Label runat="server" ID="lblDetials" Text='<%# Bind("Description") %>' class="LTR"></asp:Label>
                                    </p>
                                    </span>
                                   


                                   <%-- <span>القيمة المطلوبة
                                        <p>
                                            <asp:Label runat="server" ID="lblDetials" Text='<%# Bind("Description") %>' class="LTR"></asp:Label>
                                        </p>
                                    </span>--%>
                                </div>


                                 <div class="div3"> 
                                         <asp:HiddenField runat="server" ID="hdnPublishDate" Value='<%# Bind("PublishDate") %>' />
                                          <asp:Label runat="server" ID="lblPublishDate" Text='<%# Bind("PublishDate") %>' class="LTR"></asp:Label>
                                     <span>
                                        <p>
                                            <asp:Label runat="server" ID="lblPublishTime"  class="LTR"></asp:Label>
                                        </p>
                                     </span>
                                    
                                </div>




                                <asp:HyperLink runat="server" ID="lnkNews">
                                   التفاصيل
                                </asp:HyperLink>


                            </li>
                            
                        </ItemTemplate>


                        <GroupTemplate>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
                        </GroupTemplate>
                    </asp:ListView>


                    <%-- <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="oone">
              <label for="oone"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="two">
              <label for="two"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="three">
              <label for="three"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="four">
              <label for="four"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="five">
              <label for="five"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="six">
              <label for="six"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="seven">
              <label for="seven"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="eight">
              <label for="eight"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="nine">
              <label for="nine"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>
        <li>
          <div class="div1">
            <span class="detcheckbox">
              <input type="checkbox" id="ten">
              <label for="ftenive"></label>
            </span>
            <span>
              <strong>قسم خدمة العملاء</strong>
            <p>قبل ٨ ساعات</p>
            </span>
          </div>
          <div class="div2">
            <img src="images/attech.png" alt="">
            <span><strong>القيمة المطلوبة</strong>
              <p>اجمالي المبلغ المطلوب 
  ٢٤،٦٩٣ دينار<span class="LTR">00962798564398222</span></p></span>
          </div>
          <a href="javascript:void">
            التفاصيل
          </a>
        </li>--%>
                </ul>
                <p class="term">يرجى العلم بان البريد الداخلي يقوم بحفظ الرسائل لاخر ٣٠ يوم فقط من تاريخ الاستلام حيث يقوم النظام بحذف البريد السابق بشكل تلقائي ودون اي اشعار مسبق.</p>
            </div>
        </div>
    </div>


    <%--<ul class="pagination">
        <li>
            <a href="#" aria-label="Previous">
                <span aria-hidden="true" class="fa fa-arrow-left"></span>
            </a>
        </li>
        <li><a href="#">1</a></li>
        <li><a href="#">2</a></li>
        <li><a href="#">3</a></li>
        <li><a href="#">...</a></li>
        <li><a href="#">5</a></li>
        <li>
            <a href="#" aria-label="Next">
                <span aria-hidden="true" class="fa fa-arrow-right"></span>
            </a>
        </li>
    </ul>--%>
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

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

<script>
    $(window).on('load', function () {
        $('#loading').hide();
    });

    $("document").ready(function () {

        var getcont = $("#ContentPlaceHolder1_ctl00_hdnCountRecord").val();
        debugger;
        for (var i = 0; i < getcont; i++) {

            $("#ContentPlaceHolder1_ctl00_lstNotificationDevice_ctrl" + i + "_lblforCheckbox_" + i).append("<label for='ContentPlaceHolder1_ctl00_lstNotificationDevice_ctrl" + i + "_CBID_" + i + "'></label>");
            //ContentPlaceHolder1_ctl00_lstNotificationDevice_ctrl1_lblforCheckbox_1                              ContentPlaceHolder1_ctl00_lstNotificationDevice_ctrl1_CBID_1
        }
    });
</script>

<style>
    .tab-content li:hover {
        background: #ebf8ff;
    }

    a.next,
a.prev{
        background: #007fc3;
    color: #fff;
        margin: 0 15px;
        position: relative;
        display:inline-block;
    padding: 9px 17px;
        border: 1px solid #ddd;
    font-size: 20px;
        text-decoration: none;
}
span.num{
    position: relative;
    padding: 9px 17px;
    margin-right: -1px;
    line-height: 1.42857143;
    color: #8c8c8c;
    text-decoration: none;
    background-color: #fff;
    border: 1px solid #ddd;
    font-size: 20px;
    margin: 0 5px;
}
span.active.num{
    color: #fff;
    background-color: #007fc3;
    border: 1px solid #ddd;
}


li.UnreadLI {
    position:relative;
    background: #fff9db;
}
li.UnreadLI:before{
    content:"";
    background:#fff9db;
    width:40px;
    height:100%;
    position:absolute;
    top:0;
    left:-40px;
}
li.UnreadLI:after{
    content:"";
    background:#fff9db;
    width:40px;
    border-right:15px solid #fee662;
    height:100%;
    position:absolute;
    top:0;
    right:-40px;
}

ul.inboxul {
    margin-bottom: 0px;
}
</style>

