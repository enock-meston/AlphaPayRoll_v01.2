using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListCaisseEpargne
    {
        Task<List<ListCaisseEpargne>> GetListCaisseEpargne();

    }
}
