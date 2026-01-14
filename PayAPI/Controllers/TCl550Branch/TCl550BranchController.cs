using Microsoft.AspNetCore.Mvc;
using PayLibrary.Cl550Branch;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Branch
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550BranchController : ControllerBase
    {
        private readonly ITCl550Branch oItem;

        public TCl550BranchController(ITCl550Branch xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Branch>> GetT550Branch()
        {
            return await oItem.GetT550Branch();
        }

    }
}