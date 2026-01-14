using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL09ImputPay;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TSL09ImputPay
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasserTransConstController : ControllerBase
    {

        private readonly ITSL09ImputPay oImplement;
        public PasserTransConstController(ITSL09ImputPay implement)
        {
            this.oImplement = implement;
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] ParamTransSalaire item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetResutPasserConstSalaire(item);
            }
            else
            {
                return null;
            }

        }
    }
}
