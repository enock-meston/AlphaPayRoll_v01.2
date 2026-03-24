using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListSanLam
    {
        Task<List<ListSanLam>> GetListSanLam();
    }
}
