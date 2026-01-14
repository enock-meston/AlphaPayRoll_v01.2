using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
  public  interface ITSc552PrmAllowed
    {
        Task<List<TSc552PrmAllowed>> GetList();
        Task<Resultat> GetUpdateResult(TSc552PrmAllowed item);
    }
}
