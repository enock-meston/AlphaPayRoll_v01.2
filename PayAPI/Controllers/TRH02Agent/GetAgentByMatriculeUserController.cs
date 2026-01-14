using Microsoft.AspNetCore.Mvc;
using PayLibrary.TRH02Agent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TRH02Agent
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAgentByMatriculeUserController : ControllerBase
    {


        private readonly ITRH02Agent oItem;
        public GetAgentByMatriculeUserController(ITRH02Agent xxx)
        {
            oItem = xxx;
        }



        [HttpPost]
        public async Task<List<ClassTRH02Agent>> GetAgentByMatriculeXX([FromBody] ParamAgentMatricule param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetAgentByMatriculeXX(param);
            }
            else
            {
                return null;
            }
        }

    }
}

