using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.SalProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiverSalairesController : ControllerBase
    {
        private readonly ITSL00Process oItem;
        public ArchiverSalairesController(ITSL00Process inter)
        {
            oItem = inter;
        }

        [HttpPost]
        public async Task<Resultat> GetArchiverSalResult([FromBody] ParamPeriod item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetArchiverSalResult(item);
            }
            else
            {
                return null;
            }

        }

    }
}
