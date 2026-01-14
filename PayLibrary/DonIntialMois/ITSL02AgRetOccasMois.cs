using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.DonIntialMois
{
    public interface ITSL02AgRetOccasMois
    {
        Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMois();
        Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMoisByAgent(int id);
        Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMoisByType(int id);
        Task<Resultat> GetUpdateRetOccasMoisResult(AgDonIntialMois item);
    }
}
