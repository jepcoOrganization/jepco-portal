﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FileDetails.aspx.cs" Inherits="DetailsPage_FileDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-lg-8 col-md-12 col-sm-12">
		  
		 
        <div class="average_energy">
          <aside>            
            <h1><small>الاستهلاك في الاربعة اشهر الاخيرة</small> 
              معدل استهلاكك للطاقة لآخر <span>12</span> شهر</h1>
            <img src="<%=ResolveUrl("~/") %>App_Themes/ThemeAr/img//energy-2.png" alt="">
          </aside>
			
			
			
         
          <div class="billlist">
			  
			  <div class="top-cart-detail">
			  
			  <div class="row">
			  
			  
				  <div class="col-md-5 col-sm-6"><span>رقم العداد</span><strong style="margin-right: 15px;  font-family: 'Montserrat', sans-serif;">0096279856439822</strong></div>
				  <div class="col-md-3 col-sm-3"><span> المنطقة:</span><strong> الجبيهة</strong></div>
				  <div class="col-md-2 col-sm-3col-xs-6 "><span> القطاع:</span><strong>  سكني</strong></div>
				  
				  <div class="col-md-2 pull-right text-right"><a href="#">عدادات اخرى؟</a></div>
			  
			  </div>
				  
				  
				  </div>
			  
			  
			  
			  
			  

             <div class="canvasdiv">
          <canvas id="ctx" width="1000" height="250"></canvas>
          </div>


            <ul class="list-unstyled">
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
            </ul>

            
          </div>

        </div>
      </div>
</asp:Content>


