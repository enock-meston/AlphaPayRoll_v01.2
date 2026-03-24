using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListEjoheza
    {
        Task<List<ListEjoheza>> GetListEjohezas();
    }
}
