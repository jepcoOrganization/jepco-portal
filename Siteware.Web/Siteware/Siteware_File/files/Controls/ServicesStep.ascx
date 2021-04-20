<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ServicesStep.ascx.cs" Inherits="Controls_ServicesStep" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<section class="comn_padding greybg sevice_step">
  <div class="container">
    <div class="row">
      <div class="col-lg-3 col-md-12 col-sm-12">
        <div class="sidebar_Accordion">
          <aside>
            <small>اختيار نوع المعاملة</small>
            نوع المعاملة المطلوبة</aside>

            <div id="ca-1" class="collapsable collapsable-accordion">
              <h4 class="ca-control">
                <a href="#ca-1" class="ca-ico">خدمات الاشتراكات</a>
              </h4>
              <div class="ca-box">
                <a href="javascript:void">طلب عداد جديد ( 1 فاز/ 3 فاز) </a>
                <a href="javascript:void">طلب تبديل عداد1فاز الى 3 فاز او 3 فاز الى1 فاز </a>
                <a href="javascript:void">التحويل من مؤقت الى دائم</a>
                <a href="javascript:void">طلب معاملات الصيانة (نقل خطوط، رفع قدرة قاطع)</a>
                <a href="javascript:void">نقل عداد، تثبيت فناجين</a>
              </div>
            </div>
            <div id="ca-2" class="collapsable collapsable-accordion">
              <h4 class="ca-control">
                <a href="#ca-2">خدمات دائرة الجباية</a>
              </h4>
              <div class="ca-box">
                <a href="javascript:void">طلب تغيير اشتراك مشغول</a>
                <a href="javascript:void">طلب انهاء عقد </a>
                <a href="javascript:void">طلب فصل تيار </a>
                <a href="javascript:void">طلب وصل تيار </a>
                <a href="javascript:void">طلب فحص عداد </a>
                <a href="javascript:void">طلب رفع عداد بسبب الهدم </a>
                <a href="javascript:void">طلب تغيير تعرفة </a>
              </div>
            </div>
        </div>
      </div>
      <div class="col-lg-9 col-md-12 col-sm-12">
        <div class="stepdiv">
          <!--------------------------- STEP 1 --------------------------->
          <div class="stepbox step1">
            <img src="images/error.png" alt="">
            <p>ابدأ بإختيار نوع المعاملة المطلوبة</p>
          </div>
          <!--------------------------- STEP 2 --------------------------->
          <div class="stepbox step2">
            <ul class="list-unstyled steplist">
          <li class="activebg"><a href="javascript:void">معاملات الاشتراكات </a></li>
          <li class="active"><a href="javascript:void">طلب عداد جديد ( ١ فاز / ٣ فاز  )</a></li>
          <li><a href="javascript:void">الاوراق المطلوبة</a></li>
        </ul>
            <h3>تقديم الخدمات الفضلى المستدامة</h3>
                <P>تسعى شركة الكهرباء الأردنية المساهمة العامة المحدودة لتبقى الأولى في موثوقية تقديم خدمات توزيع الكهرباء في الأردن، والشركة الريادية في استخدام أحدث لتبقى الأولى في موثوقية تقديم خدمات توزيع والشركة الريادية في استخدام أحدث لتبقى.</P>

            <div class="row">
              <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="stepiconbox">
                    <div class="stepiconboximg">
                      <img src="images/Step-Icon-1.png" alt="">
                      <img src="images/Step-Icon-11.png" alt="" class="backimg">
                    </div>
                    <h4>طلب عداد سكني</h4>                    
                  </div>
              </div>
              <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="stepiconbox">
                    <div class="stepiconboximg">
                      <img src="images/Step-Icon-2.png" alt="">
                      <img src="images/Step-Icon-22.png" alt="" class="backimg">
                    </div>
                    <h4>طلب عداد تجاري</h4>                    
                  </div>
              </div>
              <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="stepiconbox">
                    <div class="stepiconboximg">
                      <img src="images/Step-Icon-3.png" alt="">
                      <img src="images/Step-Icon-33.png" alt="" class="backimg">
                    </div>
                    <h4>عداد شحن سيارة كهربائية</h4>                    
                  </div>
              </div>
              <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="stepiconbox">
                    <div class="stepiconboximg">
                      <img src="images/Step-Icon-4.png" alt="">
                      <img src="images/Step-Icon-44.png" alt="" class="backimg">
                    </div>
                    <h4>طلب عداد مؤقت</h4>                    
                  </div>
              </div>
              <div class="col-lg-3 col-md-4 col-sm-6">
                <div class="stepiconbox">
                    <div class="stepiconboximg">
                      <img src="images/Step-Icon-5.png" alt="">
                      <img src="images/Step-Icon-55.png" alt="" class="backimg">
                    </div>
                    <h4>طلب عداد خدمات</h4>                    
                  </div>
              </div>
            </div>
            <button>
              متابعة
              <i class="fa fa-long-arrow-left"></i>
            </button>
            <div class="clearfix"></div>
          </div>
          <!--------------------------- STEP 3 --------------------------->
          <div class="stepbox step3">
            <ul class="list-unstyled steplist">
          <li class="activebg"><a href="javascript:void">معاملات الاشتراكات </a></li>
          <li class="activebg"><a href="javascript:void">طلب عداد جديد ( ١ فاز / ٣ فاز  )</a></li>
          <li class="active"><a href="javascript:void">الاوراق المطلوبة</a></li>
        </ul>
        <h3>خدمة عداد شحن السيارات الكهربائية</h3>
        <p>تسعى شركة الكهرباء الأردنية المساهمة العامة المحدودة لتبقى الأولى في موثوقية تقديم خدمات توزيع الكهرباء في الأردن، والشركة الريادية في استخدام أحدث لتبقى الأولى في موثوقية تقديم خدمات توزيع والشركة الريادية في استخدام أحدث لتبقى.</p>

        <div class="row">
          <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="meterbg3 meter_service">
              <img src="images/clock.png" alt="">
              <p>المدة الزمنية لتفعيل الخدمة</p>
              <aside><span>4-6</span> ايام عمل</aside>
            </div>
          </div>
          <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="meterbg2 meter_service">
              <img src="images/money.png" alt="">
              <p>الرسوم المطلوبة للاشتراك</p>
              <aside><span>182</span> دينار</aside>
            </div>
          </div>
          <div class="col-lg-4 col-md-4 col-sm-4">
            <div class="meterbg1 meter_service">
              <img src="images/save.png" alt="">
              <p>قم بتحميل النموذج لتعبئتة</p>
              <aside>تحميل النموذج</aside>
            </div>
          </div>
        </div>

        <strong>الاوراق المطلوبة للمعاملة</strong>
        <ul class="list-unstyled transaction">
          <li>1-    صورة عن مخطط موقع تنظيمي ( حديث) </li>
          <li>2-    صورة عن مخطط اراضي ( حديث)</li>
          <li>3-    صورة عن سند تسجيل الملكية للمالك او عقد ايجار مصدق</li>
          <li>4-    تفويض خطي من المالك مصادق على التوقيع بنكياً في حال تقديم الطلب من قبل شخص اخر او صورة عن الوكالة العدلية</li>
          <li>5-    فاتورة عداد الكهرباء لصاحب رخصة السيارة الراكب في نفس العقار المطلوب تزويده بعداد الشحن</li>
          <li>6-    صورة رخصة المركبة المطابق لسند التسجيل او عقد ايجار مصدق </li>
          <li>7-    كتاب هيئة تنظيم قطاع الطاقة والمعادن</li>
          <li>8-    صورة عن هوية طالب الاشتراك وصورة هوية المفوض ان وجد</li>
        </ul>
          </div>

        </div>
      </div>
      <div>
      
      </div>
    </div>
  </div>
</section>