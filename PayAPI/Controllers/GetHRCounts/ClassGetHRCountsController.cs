using Microsoft.AspNetCore.Mvc;
using PayLibrary.GetHRCounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.GetHRCounts
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassGetHRCountsController : ControllerBase
    {
        private readonly IClassGetHRCounts oImplement;
        public ClassGetHRCountsController(IClassGetHRCounts implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<ClassGetHRCounts>> GetHRCountsAsync()
        {
            return await oImplement.GetHRCountsAsync();
        }
    }
}
