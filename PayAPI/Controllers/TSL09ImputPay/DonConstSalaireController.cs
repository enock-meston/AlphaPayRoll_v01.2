using Microsoft.AspNetCore.Mvc;
using PayLibrary.TSL09ImputPay;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TSL09ImputPay
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonConstSalaireController : ControllerBase
    {

        private readonly ITSL09ImputPay oImplement;
        public DonConstSalaireController(ITSL09ImputPay implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TMontConstSalaire>> GetConstatSalaire()
        {
            return await oImplement.GetConstatSalaire();
        }
    }
}
