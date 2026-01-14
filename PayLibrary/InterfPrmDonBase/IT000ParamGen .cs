using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfPrmDonBase
{
   public interface IT000ParamGen
    {
        Task<IList<T000ParamGen>> GetT000ParamGenList();
        Task<T000ParamGen> GetT000ParamGen(int Id);
        Task<Resultat> GetUpdateResult(T000ParamGen oT000ParamGen);
        Task<List<T000ParamGen>> GetList();
    }
}
