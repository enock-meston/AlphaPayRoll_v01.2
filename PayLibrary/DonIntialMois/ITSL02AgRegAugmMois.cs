using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.DonIntialMois
{
    public interface ITSL02AgRegAugmMois
    {
        Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMois();
        Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByAgent(int id);
        Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByType(int id);
        Task<Resultat> GetUpdateRegAugmMoisResult(AgDonIntialMois item);
    }
}
