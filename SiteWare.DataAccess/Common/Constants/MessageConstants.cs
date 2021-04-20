using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.DataAccess.Common.Constants
{
    public static class MessageConstants
    {
        public const string NotFoundMessage = "لا توجد معلومات";
        public const string NotFoundDetails = "لا توجد معلومات بالبحث المرفق تنتمي للرقم المرجعي المرفق";

        public const string CannotInsertMessage = "الاضافة غير ممكنة";
        public const string CannotInsertDetails = "الاضافة غير ممكنة الرجاء مراجعة مسؤول النظام";

        public const string CannotUpdateMessage = "التعديل غير ممكن";
        public const string CannotUpdateDetails = "التعديل غير ممكن الرجاء مراجعة مسؤول النظام";

        public const string CannotDeleteMessage = "الحذف غير ممكن";
        public const string CannotDeleteDetails = "الحذف غير ممكن الرجاء مراجعة مسؤول النظام";

        public const string CannotFindByIDMessage = "لا توجد بيانات";
        public const string CannotFindByIDDetails = "الرقم المرجعي السابق غير موجود";

        public const string CannotFindAllMessage = "لا توجد بيانات";
        public const string CannotFindAllDetails = "لا توجد بيانات";

        public const string InsertSuccessMessage = "تم الحفظ بنجـاح";
        public const string DeleteSuccessMessage = "تم الحذف بنجـاح";
        public const string UpdateSuccessMessage = "تم التعديل بنجـاح";
    }
}
