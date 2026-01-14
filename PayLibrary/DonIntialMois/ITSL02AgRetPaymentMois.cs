using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.DonIntialMois
{
    public interface ITSL02AgRetPaymentMois
    {

        Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois();
        Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id);
        Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByType(int id);
        Task<Resultat> GetUpdatePaymentMoisResult(AgDonIntialMois item);


    }
}
