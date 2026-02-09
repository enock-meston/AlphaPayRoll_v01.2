using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ParamDonBase.TSc551BranchAndSubBranch
{
    public interface ITSc551SubBranchDir
    {
        Task<List<TSc551SubBranchDir>> GetList();
    }
}
