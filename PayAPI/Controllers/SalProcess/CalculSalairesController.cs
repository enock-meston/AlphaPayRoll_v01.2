using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using System.Threading.Tasks;

namespace PayAPI.Controllers.SalProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculSalairesController : ControllerBase
    {
        private readonly ITSL00Process oItem;
        public CalculSalairesController(ITSL00Process inter)
        {
            oItem = inter;
        }

        [HttpPost]
        public async Task<Resultat> GetCalculerSalResult([FromBody] ParamPeriod item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetCalculerSalResult(item);
            }
            else
            {
                return null;
            }

        }

    }
}
