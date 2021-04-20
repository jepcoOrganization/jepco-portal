<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RenewableEnergyUserRequestsAdd.ascx.cs" Inherits="Controls_RenewableEnergyUserRequestsAdd" %>

 <div class="Energy_Request">
          <h2>طلب ربط نظم مصادر  الطاقة المتجددة</h2>       
          <div class="row custom_radio">
            <div class="col-lg-3 col-md-3 col-sm-12">
              <label>نوع الطلب</label>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-1" name="Typeof-Request" type="radio" checked>
                <label for="radio-1" class="radio-label">صغير صافي قياس</label>
              </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-2" name="Typeof-Request" type="radio">
                <label  for="radio-2" class="radio-label">كبير صافي قياس</label>
              </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-3" name="Typeof-Request" type="radio">
                <label  for="radio-3" class="radio-label">عبور</label>
              </div>
            </div>
          </div> 
          <div class="row custom_radio">
            <div class="col-lg-3 col-md-3 col-sm-12">
              <label>حالة العداد</label>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-4" name="Counter-condition" type="radio">
                <label  for="radio-4" class="radio-label">عداد عامل</label>
              </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-5" name="Counter-condition" type="radio" checked>
                <label  for="radio-5" class="radio-label">عداد جديد </label>
              </div>
            </div>
          </div> 
          <div class="row custom_radio">
            <div class="col-lg-3 col-md-3 col-sm-12">
              <label>الرقم المرجعي</label>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-6" name="reference-number" type="radio" checked>
                <label  for="radio-6" class="radio-label">رقم العداد</label>
              </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <div class="radio">
                <input id="radio-7" name="reference-number" type="radio">
                <label  for="radio-7" class="radio-label">رقم الطلب</label>
              </div>
            </div>
            <div class="col-lg-3 col-md-3 col-sm-4">
              <input type="text" placeholder="ادخل رقم العداد" class="enter_number">
            </div>
          </div>  
          <div class="row">
            <div class="col-lg-12">
              <button class="FetchingdataBTN">جلب البيانات</button>
            </div>
          </div>
          <div class="clearfix"></div>
          
          <form class="energyrequest">
            <div class="row">
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>الاسم الاول</label>
                  <input type="text" placeholder="عبد الكريم">
                </div>
              </div>
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>اسم الاب</label>
                  <input type="text" placeholder="مصطفى">
                </div>
              </div>
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>اسم الجد</label>
                  <input type="text" placeholder="عبد الكريم">
                </div>
              </div>
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>اسم العائلة</label>
                  <input type="text" placeholder="الجغبير">
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>المحافظة</label>
                  <input type="text" placeholder="العاصمة عمان">
                </div>
              </div>
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>المنطقة ١</label>
                  <input type="text" placeholder="الجبيهة">
                </div>
              </div>
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>المنطقة ٢</label>
                  <input type="text" placeholder="شفابدران">
                </div>
              </div>
              <div class="col-lg-3 col-md-3 col-sm-6">
                <div class="form-group">
                  <label>اسم الشارع</label>
                  <input type="text" placeholder="شفابدران">
                </div>
              </div>
            </div>
            <p>هل ترغب بتحديث البايانات الموجودة اعلاه؟ <a href="javascript:void">اضغط هنا</a></p>
          </form>

          <div class="clearfix"></div>

          <div class="information_delegated">
            <h3>معلومات الشركة المراد تفويضها</h3>
            
            <div class="row">
              <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                <label>اختر اسم الشركة التي ترغب بتفويضها لتركيب النظام</label>
                <select>
                  <option>اختر اسم الشركة</option>
                  <option>company 1</option>
                  <option>company 2</option>
                </select>
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                <label>رقم هاتف الشركة </label>
                <input type="text" placeholder="079 9823 095" class="number">
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                <label>الرقم الوطني للمنشأة </label>
                <input type="text" placeholder="3456799823095" class="number">
                </div>
              </div>
              <div class="col-lg-6 col-md-6 col-sm-6">
                <div class="form-group">
                <label>البريد الالكتروني </label>
                <input type="text" placeholder="lkgsd@hotmail.com">
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-12">
                <div class="checkbox">
                  <label>
                    <span class="detcheckbox">
                      <input type="checkbox" id="two">
                      <label for="two"></label>
                    </span>
                  أقر بأن المعلومات الواردة في هذا الطلب صحيحة وأوافق على الالتزام ببنود وشروط اتفاقية ربط نظم مصادر الطاقة المتجددة 
الصغيرة المدرجة في الطلب بواسطة شركة (اسم الشركة) لعداد رقم (823095)
</label>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-12">
                <button class="submitbtn">تقديم الطلب</button>
                <button class="cancelbtn">الغاء</button>
              </div>
            </div>
          </div>

        </div>

        <br>
        <br>
        <div class="popup_modal">
        <button  data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">Open modal</button>

        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span class="fa fa-close"></span></button>
                <h4 class="modal-title" id="exampleModalLabel">طلب طاقة متجددة</h4>
              </div>
              <div class="modal-body">
               <img src="images/check.png" alt="">
               <strong>تم ارسال الطلب بنجاح</strong>
              <p>لقد تم ارسال طلبكم الى شركة النظم الحديثة للطاقة المتجددة لغايات استكمال تقديم الطلب الخاص بكم</p>
              </div>
              <div class="modal-footer">
                  <button>متابعة الى الموقع</button>
              </div>
            </div>
          </div>
        </div>
        </div>
