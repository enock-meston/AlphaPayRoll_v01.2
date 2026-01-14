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
    public class PrmAllowedController : ControllerBase
    {
        private readonly ITSc552PrmAllowed oImplement;
        public PrmAllowedController(ITSc552PrmAllowed implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TSc552PrmAllowed>> GetList()
        {
            return await oImplement.GetList();
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc552PrmAllowed oTSc552CptabMAllawed)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(oTSc552CptabMAllawed);
            }
            else
            {
                return null;
            }

        }

    }
}
