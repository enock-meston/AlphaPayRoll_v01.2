using PayLibrary.ParamDonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
    public interface ITSc551SubBranch
    {
        Task<List<TSc551SubBranch>> GetList();
    }
}
