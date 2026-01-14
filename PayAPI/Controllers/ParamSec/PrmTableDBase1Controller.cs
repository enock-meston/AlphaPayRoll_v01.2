using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrmTableDBase1Controller : ControllerBase
    {
        private readonly ITSc06PrmTable oTSc06PrmTableImplement;
        public PrmTableDBase1Controller(ITSc06PrmTable tSc06PrmTableImplement)
        {
            oTSc06PrmTableImplement = tSc06PrmTableImplement;
        }

        [HttpGet("{id}")]
        public async Task<TSc06PrmTable> GetPrmTable(int id)
        {
            return await oTSc06PrmTableImplement.GetPrmTable(id);
        }


        [HttpGet]
        public async Task<IEnumerable<TSc06PrmTable>> GetPrmTableList()
        {
            return await oTSc06PrmTableImplement.GetPrmTableList();
        }


    }
}
