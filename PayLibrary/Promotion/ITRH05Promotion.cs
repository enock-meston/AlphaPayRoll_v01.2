using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Promotion
{
    public interface ITRH05Promotion
    {
        Task<Resultat> GetResutUpdate(TRH05Promotion item);
        Task<List<TRH05Promotion>> GetPromotionByMatricule(string id);
        Task<Resultat> ValiderPromotion(ParamValidPromotion param);
    }
}
