using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;

namespace PayLibrary.InterfParamSec
{
   public interface ITSc552UserJnal
    {
        //Task<List<TSc552UserJnal>> GetJrnalUserType(string id);
        Task<List<TSc552UserJnal>> GetList(int id);
        //Task<Resultat> GetUpdateResult(TSc552UserJnal item);
    }
}
