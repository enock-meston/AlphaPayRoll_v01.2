using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfPrmDonBase
{
    public interface IDonBaseLevelTwoo
    {
        Task<List<DonBaseLevelTwoo>> GetItemList(string id);
        public Task<Resultat> GetUpdateResult(DonBaseLevelTwoo item);
    }
}
