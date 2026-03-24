using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListRetCaisSolid
    {
        Task<List<ListRetCaisSolid>> GetListRetCaisSolid();
    }
}
