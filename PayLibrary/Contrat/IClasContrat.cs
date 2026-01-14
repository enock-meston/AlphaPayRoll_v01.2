using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Contrat
{
   public  interface IClasContrat
    {
        Task<List<ClasContrat>> GetContractByMatricule(string id);
        Task<Resultat> GetResutUpdate(ClasContrat item);

        Task<List<TRH04Affectation>> GetAffectionByMatricule(string id);
        Task<Resultat> GetResutUpdateAffect(TRH04Affectation item);

        Task<Resultat> ValiderCotrat(ParamValidContrat param);
        Task<Resultat> ValiderAffectation(ParamValidAffectation param);
       






    }
}
