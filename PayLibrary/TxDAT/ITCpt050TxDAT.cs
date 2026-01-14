
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.TxDAT
{
    public interface ITCpt050TxDAT
    {
        Task<List<TCpt050TxDAT>> GetAllData();
        Task<List<TCpt050TxDAT>> GetDataById(int id);
        Task<Resultat> GetUpdateResult(TCpt050TxDAT item);
    }
}
