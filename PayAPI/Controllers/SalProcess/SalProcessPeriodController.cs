using Microsoft.AspNetCore.Mvc;
using PayLibrary.SalProcess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.SalProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalProcessPeriodController : ControllerBase
    {
        private readonly ITSL00Process oItem;
        public SalProcessPeriodController(ITSL00Process inter)
        {
            oItem = inter;
        }

        [HttpPost]
        public async Task<List<TSL00Process>> Post([FromBody] ParamPeriod item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetSalProcessByPeriod(item);
            }
            else
            {
                return null;
            }

        }

    }
}
