using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.Saction
{
  public  interface ITRH05Saction
    {
        Task<List<TRH05Saction>> GetList(string id);
        Task<List<TRH05Saction>> GetListAll();

        Task<Resultat> GetUpdateResult(TRH05Saction item);
    }
}
