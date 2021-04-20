using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteWare.Domain.Common
{
    public static class DomainCommonConstants
    {
        public const string ErrorMessageFormatter = "{0} - {1}{2}";
        public static List<List<T>> SplitList<T>(this List<T> listDate, int size = 7)
        {
            var list = new List<List<T>>();
            for (int i = 0; i < listDate.Count; i += size)
                list.Add(listDate.GetRange(i, Math.Min(size, listDate.Count - i)));
            return list;
        }
    }
}
