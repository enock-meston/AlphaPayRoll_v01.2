using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.Localisation
{
    public interface ITRH05Localisation
    {
        Task<List<TRH05Localisation>> GetList(string id);
        Task<List<TRH05Localisation>> GetListAll();
        Task<Resultat> GetUpdateResult(TRH05Localisation item);
        Task<Resultat> ValiderLocalisation(ParamValidLocalisation param);

    }
}
