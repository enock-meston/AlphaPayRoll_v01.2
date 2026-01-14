using Microsoft.AspNetCore.Mvc;
using PayLibrary.AgRegAugmBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.AgRegAugmBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL02AgRetAugmBaseController : ControllerBase
    {
        private readonly ITSL02AgRetPayment oImplement;
        public TSL02AgRetAugmBaseController(ITSL02AgRetPayment implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBase()
        {
            return await oImplement.GetTSL02AgRetAugmBase();
        }
        [HttpGet("{id}")]
        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByAgent(int id)
        {
            return await oImplement.GetTSL02AgRetAugmBaseByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TSL02AgRetPayment item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(item);
            }
            else
            {
                return null;
            }

        }
    }
}
