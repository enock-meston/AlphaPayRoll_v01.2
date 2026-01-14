using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrmTableController : ControllerBase
    {
        private readonly ITSc06PrmTable oTSc06PrmTableImplement;

        public PrmTableController(ITSc06PrmTable oTSc06PrmTableImplement)
        {
            this.oTSc06PrmTableImplement = oTSc06PrmTableImplement;
        }
        [HttpGet]
        public async Task<List<TSc06PrmTable>> GetListAll()
        {
            return await oTSc06PrmTableImplement.GetPrmTableList();
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc06PrmTable item)
        {
            if (ModelState.IsValid)
            {
                return await oTSc06PrmTableImplement.GetUpdateResult(item);
            }
            else
            {
                return null;
            }
        }
    }
}
