using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.Localisation
{
    public interface ITRH05Mutation
    {
        Task<List<TRH05Mutation>> GetList(string id);
        Task<List<TRH05Mutation>> GetListAll();
        Task<Resultat> GetUpdateResult(TRH05Mutation item);
        Task<Resultat> ValiderMutation(ParamValidMutation param);

    }
}
