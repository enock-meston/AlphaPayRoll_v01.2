using Microsoft.AspNetCore.Mvc;
using PayLibrary.TRH02Agent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TRH02Agent
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH02AgentByMatriculeController : ControllerBase
    {

        private readonly ITRH02Agent oItem;
        public TRH02AgentByMatriculeController(ITRH02Agent xxx)
        {
            oItem = xxx;
        }

        [HttpGet("{id}")]
        public async Task<List<ClassTRH02Agent>> GetAgentByMatricule(string id)
        {
            return await oItem.GetAgentByMatricule(id);
        }

        [HttpPost]
        public async Task<List<ClassTRH02Agent>> GetAgentByMatriculeCongeReq([FromBody] ParamAgentMatricule param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetAgentByMatriculeCongeReq(param);
            }
            else
            {
                return null; // or return new List<ClassTRH02Agent>();
            }
        }



    }
}

