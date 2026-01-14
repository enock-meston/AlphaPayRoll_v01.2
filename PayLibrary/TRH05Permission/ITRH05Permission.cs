
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Permission

{
    public interface ITRH05Permission
    {
        Task<List<TRH05Permission>> GetList(string id);
        Task<List<TRH05Permission>> GetListAll();
        Task<Resultat> GetUpdateResult(TRH05Permission item);
    }
}
