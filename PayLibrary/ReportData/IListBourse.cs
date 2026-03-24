using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListBourse
    {
        Task<List<ListBourse>> GetListBourse();
    }
}
