using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.RubSalCompte
{
    public interface ITSl550RubSalCompte
    {
        Task<Resultat> GetUpdateResult(TSl550RubSalCompte item);
        Task<List<TSl550RubSalCompte>> GetList();
    }
}
