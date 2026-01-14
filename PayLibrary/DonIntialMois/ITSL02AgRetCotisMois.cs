using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.DonIntialMois
{
    public interface ITSL02AgRetCotisMois
    {

        Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMois();
        Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMoisByAgent(int id);
        Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMoisByType(int id);
        Task<Resultat> GetUpdateRetCotisMoisResult(AgDonIntialMois item);

    }
}
