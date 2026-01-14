using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PostModif
{
    public interface ITRH05PostModif
    {
        Task<Resultat> GetResutUpdate(TRH05PostModif item);
        Task<List<TRH05PostModif>> GetPostModifByMatricule(string id);
        Task<Resultat> ValiderPostModif(ParamValidPostModif param);
    }
}
