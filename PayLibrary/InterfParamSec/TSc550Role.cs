using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;

namespace PayLibrary.InterfParamSec
{
   public interface ITSc550Role
    {
        Task<List<TSc550Role>> GetList(int id);
        Task<Resultat> GetUpdateResult(TSc550Role item);
    }
}
