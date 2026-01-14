using Microsoft.AspNetCore.Mvc;
using PayLibrary.CalculSalaire;
using PayLibrary.ParamSec.ViewModel;
using System.Threading.Tasks;

namespace PayAPI.Controllers.CalculSalaire
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalSalRimController : ControllerBase
    {

        private readonly ICalculerSalaire oItem;
        public CalSalRimController(ICalculerSalaire xxx)
        {
            oItem = xxx;
        }

        [HttpPost]
        public async Task<Resultat> PostCalculerSalaire([FromBody] ParamCallSalaire item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.PostCalculerSalaire(item);
            }
            else
            {
                return null;
            }
        }
    }
}

