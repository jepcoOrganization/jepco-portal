using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonFunction
/// </summary>
public static class CommonFunction
{
    #region--> Split List | Add | Jigar Patel
    public static List<List<T>> SplitList<T>(this List<T> listInvoice, int size = 4)
    {
        var list = new List<List<T>>();
        for (int i = 0; i < listInvoice.Count; i += size)
            list.Add(listInvoice.GetRange(i, Math.Min(size, listInvoice.Count - i)));
        return list;
    }
    #endregion
}