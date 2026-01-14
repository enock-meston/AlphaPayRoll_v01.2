using PayLibrary.Localisation;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Salaire
{
    public interface ITSL02Salaire
    {
        Task<List<TSL02Salaire>> GetSalaire(string id);
        Task<List<TSL02Salaire>> GetSalaireAll();
        Task<Resultat> GetUpdateResult(TSL02Salaire item);
    }
}
