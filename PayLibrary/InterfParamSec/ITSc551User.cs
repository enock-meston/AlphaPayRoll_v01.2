using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
    public interface ITSc551User
    {

        Task<List<TSc551User>> GetList();
        Task<Resultat> GetUpdateResult(TSc551User item);

    }
}
