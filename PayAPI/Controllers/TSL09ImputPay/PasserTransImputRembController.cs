using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL09ImputPay;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TSL09ImputPay
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasserTransImputRembController : ControllerBase
    {

        private readonly ITSL09ImputPay oImplement;
        public PasserTransImputRembController(ITSL09ImputPay implement)
        {
            this.oImplement = implement;
        }

        [HttpPost]
        public async Task<Resultat> GetResutPasserRembCredit([FromBody] ParamTransSalaire item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetResutPasserRembCredit(item);
            }
            else
            {
                return null;
            }

        }
    }
}
