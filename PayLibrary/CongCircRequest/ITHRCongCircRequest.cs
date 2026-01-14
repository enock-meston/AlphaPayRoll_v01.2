using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.CongCircRequest
{
    public interface ITHRCongCircRequestNew
    {
        Task<List<THRCongCircRequestNew>> GetAllCongeCircRequests();
        Task<Resultat> GetUpdateResult(THRCongCircRequestNew item);
     
    }
}
