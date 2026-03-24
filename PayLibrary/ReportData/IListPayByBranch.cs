using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public interface IListPayByBranch
    {
        Task<List<ListPayByBranch>> GetListPayByBranch(string id);
        Task<List<ListPayByBranch>> GetListPayGen();
        Task<List<ListPayByBranch>> GetListPayConsolid();
    }
}
