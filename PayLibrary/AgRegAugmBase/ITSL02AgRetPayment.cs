using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.AgRegAugmBase
{
    public interface ITSL02AgRetPayment
    {
        Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBase();
        Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByAgent(int id);
        Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByType(int id);
        Task<Resultat> GetUpdateResult(TSL02AgRetPayment item);
    }
}
