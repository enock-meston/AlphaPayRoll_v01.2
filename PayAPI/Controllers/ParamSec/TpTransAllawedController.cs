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
    public class TpTransAllawedController : ControllerBase
    {
        private readonly ITSc552TpTransAllawed oImplement;
        public TpTransAllawedController(ITSc552TpTransAllawed implement)
        {
            this.oImplement = implement;
        }

        [HttpGet("{id}")]
        public async Task<List<TSc552TpTransAllawed>> GetList(int id)
        {
            return await oImplement.GetList(id);
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc552TpTransAllawed oTSc552TpTransAllawed)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(oTSc552TpTransAllawed);
            }
            else
            {
                return null;
            }

        }

    }
}
