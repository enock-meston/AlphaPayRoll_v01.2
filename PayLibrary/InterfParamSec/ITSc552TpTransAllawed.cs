using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;


namespace PayLibrary.InterfParamSec
{
  public  interface ITSc552TpTransAllawed
    {
        Task<List<TSc552TpTransAllawed>> GetList(int id);
        Task<Resultat> GetUpdateResult(TSc552TpTransAllawed item);
    }
}
