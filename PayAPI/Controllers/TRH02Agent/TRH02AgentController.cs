using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TRH02Agent
{
    [Route("api/[controller]")]
    public class TRH02AgentController : ControllerBase
    {
        private readonly ITRH02Agent oItem;
        public TRH02AgentController(ITRH02Agent xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTRH02Agent>> GetAgent()
        {
            return await oItem.GetAgent();
        }


        [HttpGet("{id}")]
        public async Task<List<ClassTRH02Agent>> GetAgentRech(string id)
        {
            return await oItem.GetAgentRech(id);
        }

        [HttpGet("subBranch/{id}")]
        public async Task<List<ClassTRH02Agent>> GetAgentBySubBranch(string id)
        {
            return await oItem.GetAgentBySubBranch(id);
        }

        [HttpPost("AgentByChef")]
        public async Task<List<ClassTRH02Agent>> GetAgentByChef([FromBody] ParamAgentByChef param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetAgentByChef(param);
            }
            else
            {
                return null;
            }
        }


        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTRH02Agent item)
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

