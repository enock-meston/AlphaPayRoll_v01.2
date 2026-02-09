using Microsoft.AspNetCore.Mvc;
using PayLibrary.Cl550Branch;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;

namespace PayAPI.Controllers.ParamDonBase.TSc551BranchAndSubBranch
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSc551BranchDirController : ControllerBase
    {
        private readonly ITSc551BranchDir oItem;

        public TSc551BranchDirController(ITSc551BranchDir xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<TSc551BranchDir>> GetList()
        {
            return await oItem.GetList();
        }
    }
}
