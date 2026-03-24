using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListPayRIPPS
    {
        Task<List<ListPayRIPPS>> GetListPayRIPPS();

    }
}
