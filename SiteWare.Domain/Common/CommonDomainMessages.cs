using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Common
{
    public static class CommonDomainMessages
    {
        public const string NotNumberMessage = "خطأ في القيمة المرفقة";
        public const string NotNumberDetails = "القيمة المرفقة يجب ان تكون ارقاما فقط";

        public const string PageIndexNotNumberDetails = "القيمة المرفقة المرجعية لبداية البحث يجب ان تكون ارقاما فقط";
        public const string PageSizeNotNumberDetails = "القيمة المرفقة المرجعية لنهاية البحث يجب ان تكون ارقاما فقط";
        public const string PageIndexAndPageSizeNotNumberDetails = "القيمة المرفقة المرجعية لبداية و لنهاية البحث يجب ان تكون ارقاما فقط";

        public const string ValidationError = "خطأ في فاعلية البيانات المدخلة";

        public const string DuplicateFound = "القيمة المرفقة موجودة مسبقا";

        public const string NotFound = "القيمة المرفقة غير موجودة";

        public const string InsertionError = "خطأ في ادخال البيانات";
        public const string UpdateError = "خطأ في تعديل البيانات";
        public const string DeleteError = "خطأ عند مسح البيانات";

        public const string DeleteUsedDataError = "لا يمكن مسح البيانات لوجود عمليات عليها";
        public const string FinancialYearError = "السنه الماليه موجوده من قبل او التاريخ المدخل غير صحيح";

        public const string DateExist = "التاريخ المدخل موجود من قبل";

        public const string WrongDate = "تاريخ بداية الصرف يجب ان يكون اصغر من تاريخ نهاية الصرف وان تكون الفترة سنة واحدة فقط";


        public const string BeneficiaryPayrollError = "لا يوجد مرتب فعال لهذا المستفيد";

        public const string AddAllPermissionsSucess = "تمت اضافة جميع الصلاحيات لجميع شاشات المستخدم";

    }
}
