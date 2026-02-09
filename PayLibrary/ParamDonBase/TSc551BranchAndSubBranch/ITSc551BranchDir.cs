
using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ParamDonBase.TSc551BranchAndSubBranch
{
    public interface ITSc551BranchDir
    {
        Task<List<TSc551BranchDir>> GetList();
    }
}
