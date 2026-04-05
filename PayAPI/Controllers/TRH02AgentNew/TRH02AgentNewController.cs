using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TRH02AgentNew;
using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;


namespace PayAPI.Controllers.TRH02AgentNew
{
    [Route("api/[controller]")]
    public class TRH02AgentNewController : ControllerBase
    {
        private readonly ITRH02Agent oItem;
        public TRH02AgentNewController(ITRH02Agent xxx)
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

