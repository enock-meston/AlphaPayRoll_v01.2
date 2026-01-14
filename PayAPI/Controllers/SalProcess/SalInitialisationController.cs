using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.SalProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalInitialisationController : ControllerBase
    {
        // GET: api/<SalInitialisationController>
        private readonly ITSL00Process oItem;
        public SalInitialisationController(ITSL00Process inter)
        {
            oItem = inter;
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] ParamPeriod item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetIntialisSalResult(item);
            }
            else
            {
                return null;
            }

        }

    }
}
