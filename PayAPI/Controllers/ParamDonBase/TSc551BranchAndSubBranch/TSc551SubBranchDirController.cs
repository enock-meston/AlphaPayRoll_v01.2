using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;

namespace PayAPI.Controllers.ParamDonBase.TSc551BranchAndSubBranch
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSc551SubBranchDirController : ControllerBase
    {
        private readonly ITSc551SubBranchDir oItem;

        public TSc551SubBranchDirController(ITSc551SubBranchDir xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<TSc551SubBranchDir>> GetList()
        {
            return await oItem.GetList();
        }
    }
}
