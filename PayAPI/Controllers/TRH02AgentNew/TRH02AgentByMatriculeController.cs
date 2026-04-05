using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02AgentNew;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TRH02AgentNew
{
    [Route("api/TRH02AgentNew/[controller]")]
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

    }
}

