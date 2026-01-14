using PayLibrary.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.TCt550TpTransTout
{
    public interface ITCt550TpTransTout
    {
        Task<List<TCt550TpTransTout>> GetAllTrans();
        Task<List<TCt550TpTransTout>> GetTransById(int id);
        Task<Resultat> GetUpdateResult(TCt550TpTransTout item);
    }
}
