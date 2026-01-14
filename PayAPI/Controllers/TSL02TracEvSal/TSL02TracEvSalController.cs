using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02TracEvSal;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL02TracEvSal
{

    [Route("api/[controller]")]
    [ApiController]
    public class TSL02TracEvSalController : ControllerBase
    {
        private readonly ITSL02TracEvSal oImplement;
        public TSL02TracEvSalController(ITSL02TracEvSal implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<ClassTSL02TracEvSal>> GetTSL02TracEvSal()
        {
            return await oImplement.GetTSL02TracEvSal();
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] ClassTSL02TracEvSal item)
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