using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.TypeCongCircons
{
    public interface ITRH051TypeCongCircons
    {
        Task<List<TRH051TypeCongCircons>> GetTRH051TypeCongCircons();
        Task<Resultat> UpdateTRH051TypeCongCircons(TRH051TypeCongCircons item);
    }
}
