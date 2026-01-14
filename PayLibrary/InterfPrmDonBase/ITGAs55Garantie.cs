using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfPrmDonBase
{
  public  interface ITGAs55Garantie
    {

        Task<List<TGAs55Garantie>> GetGarantieProdList(int id);

        Task<Resultat> GetUpdateResult(TGAs55Garantie oTGAs55Garantie);
    }
}
