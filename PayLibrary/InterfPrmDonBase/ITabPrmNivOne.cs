
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfPrmDonBase
{
    public interface ITabPrmNivOne
    {
        Task<IList<TabPrmNivOne>> GetDBList(int CodeObj);
        Task<TabPrmNivOne> GetDBRec(string Param);
        Task<IList<TabPrmNivOne>> GetDBListName(string ObjName);
        Task<Resultat> MajDonBaseNivOne(TabPrmNivOne oTabPrmNivOne);
    }
}
