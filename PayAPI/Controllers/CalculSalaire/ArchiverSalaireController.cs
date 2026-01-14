using Microsoft.AspNetCore.Mvc;
using PayLibrary.CalculSalaire;
using PayLibrary.ParamSec.ViewModel;
using System.Threading.Tasks;

namespace PayAPI.Controllers.CalculSalaire
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiverSalaireController : ControllerBase
    {

        private readonly ICalculerSalaire oItem;
        public ArchiverSalaireController(ICalculerSalaire xxx)
        {
            oItem = xxx;
        }

        [HttpPost]
        public async Task<Resultat> PostArchiverSalaire([FromBody] ParamCallSalaire item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.PostArchiverSalaire(item);
            }
            else
            {
                return null;
            }
        }
    }
}
