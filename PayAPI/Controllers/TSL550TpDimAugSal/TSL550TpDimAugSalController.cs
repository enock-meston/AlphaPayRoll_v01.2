using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL550TpDimAugSal;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL550TpDimAugSal
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL550TpDimAugSalController : ControllerBase
    {
        private readonly ITSL550TpDimAugSal oImplement;
        public TSL550TpDimAugSalController(ITSL550TpDimAugSal implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<ClassTSL550TpDimAugSal>> GetTSL550TpDimAugSal()
        {
            return await oImplement.GetTSL550TpDimAugSal();
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] ClassTSL550TpDimAugSal item)
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
