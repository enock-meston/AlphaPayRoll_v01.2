using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.AgRegAugmBase
{
    public interface ITSL02AgRetCotis
    {
        Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotis();
        Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByAgent(int id);
        Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByType(int id);
        Task<Resultat> GetUpdateResult(TSL02AgRetCotis item);
    }
}
