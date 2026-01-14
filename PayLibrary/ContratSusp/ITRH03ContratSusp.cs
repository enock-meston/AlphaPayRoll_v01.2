
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.ContratSusp

{
    public interface ITRH03ContratSusp
    {
        Task<List<TRH03ContratSusp>> GetSusContractByMatricule(string id);
        Task<List<TRH03ContratSusp>> GetAllSusContract();
        Task<Resultat> GetResutUpdate(TRH03ContratSusp item);
        Task<Resultat> ValiderSusCotrat(ParamValidContrat param);


    }
}
