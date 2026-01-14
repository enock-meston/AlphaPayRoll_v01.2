using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ContratModif
{
    public interface ITHR05ContratModif
    {
        Task<Resultat> GetResutUpdate(THR05ContratModif item);
        Task<List<THR05ContratModif>> GetContratModifByMatricule(string id);
        Task<Resultat> ValiderContratModif(ParamValidContratModif param);
    }
}
