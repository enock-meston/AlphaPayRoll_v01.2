using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListPrimeLife
    {
        Task<List<ListPrimeLife>> GetListPrimeLife();

    }
}
