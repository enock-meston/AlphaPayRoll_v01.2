using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
    public interface ITSc04MenuDynam
    {
        Task<List<TSc04MenuDynam>> GetMenuDynamList();
        Task<Resultat> GetUpdateResult(TSc04MenuDynam item);

        //Task<TSc04MenuDynam> GetMenuDynam(string Param);
    }
}
