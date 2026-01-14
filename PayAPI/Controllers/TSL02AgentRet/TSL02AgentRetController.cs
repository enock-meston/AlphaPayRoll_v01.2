using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgentRet;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL02AgentRet
{
    [Route("api/[controller]")]
    public class TSL02AgentRetController : ControllerBase
    {
        private readonly ITSL02AgentRet oItem;

        public TSL02AgentRetController(ITSL02AgentRet xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTSL02AgentRet>> GetTSL02AgentRet()
        {
            return await oItem.GetTSL02AgentRet();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTSL02AgentRet item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutUpdate(item);
            }
            else
            {
                return null;
            }

        }

    }
}

