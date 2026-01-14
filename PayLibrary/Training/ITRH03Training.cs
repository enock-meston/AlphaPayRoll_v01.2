using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.Training
{
  public  interface ITRH03Training
    {
        Task<List<TRH03Training>> GetList(string id);
        Task<List<TRH03Training>> GetListAll();
        Task<Resultat> GetUpdateResult(TRH03Training item);
    }
}
