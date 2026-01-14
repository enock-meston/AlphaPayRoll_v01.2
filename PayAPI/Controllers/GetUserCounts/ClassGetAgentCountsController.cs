using Microsoft.AspNetCore.Mvc;
using PayLibrary.GetUserCounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.GetUserCounts
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassGetAgentCountsController : ControllerBase
    {
        private readonly IClassGetAgentCounts oImplement;
        public ClassGetAgentCountsController(IClassGetAgentCounts implement)
        {
            this.oImplement = implement;
        }

        [HttpGet("{id}")]
        public async Task<List<ClassGetAgentCounts>> GetAgentCountsAsync(string id)
        {
            return await oImplement.GetAgentCountsAsync(id);
        }
    }
}
