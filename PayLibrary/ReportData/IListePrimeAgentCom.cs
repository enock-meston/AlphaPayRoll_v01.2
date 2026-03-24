using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListePrimeAgentCom
    {
        Task<List<ListePrimeAgentCom>> GetListePrimeAgentCom();
    }
}
