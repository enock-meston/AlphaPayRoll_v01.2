using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamDonBase;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSc551SubBranchController : ControllerBase
    {
        private readonly ITSc551SubBranch oImplement;

        public TSc551SubBranchController(ITSc551SubBranch Implement)
        {
            oImplement = Implement;
        }

        [HttpGet]
        public async Task<List<TSc551SubBranch>> GetSubBranchList()
        {
            return await oImplement.GetList();
        }


    }
}
