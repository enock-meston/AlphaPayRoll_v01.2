using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
    public interface ITSc06PrmTable
    {

        Task<List<TSc06PrmTable>> GetPrmTableList();
        Task<TSc06PrmTable> GetPrmTable(int Id);
        Task<Resultat> GetUpdateResult(TSc06PrmTable item);

    }
}
