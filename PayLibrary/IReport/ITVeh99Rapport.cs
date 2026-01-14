
using PayLibrary.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.IReport
{
    public interface ITVeh99Rapport
    {
        Task<List<TVeh99Rapport>> GetTout();
        Task<List<TVeh99Rapport>> GetList(string id);
    }
}
