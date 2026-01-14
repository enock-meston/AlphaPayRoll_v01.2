using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
  public  interface ITSc552MenuAllawed
    {
        Task<List<TSc552MenuAllawed>> GetList(int id);
        Task<Resultat> GetUpdateResult(TSc552MenuAllawed item);
    }
}
