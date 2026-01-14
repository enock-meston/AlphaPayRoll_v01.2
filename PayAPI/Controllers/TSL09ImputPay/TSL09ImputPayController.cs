using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL09ImputPay;
using System.Collections.Generic;
using System.Threading.Tasks;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL09ImputPay
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL09ImputPayController : ControllerBase
    {
        private readonly ITSL09ImputPay oImplement;
        public TSL09ImputPayController(ITSL09ImputPay implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<ClassTSL09ImputPay>> GetTSL09ImputPay()
        {
            return await oImplement.GetTSL09ImputPay();
        }
        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] ClassTSL09ImputPay item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetResutUpdate(item);
            }
            else
            {
                return null;
            }

        }
    }
}

