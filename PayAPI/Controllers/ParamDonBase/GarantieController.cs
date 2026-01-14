using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamDonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarantieController : ControllerBase
    {
        private readonly ITGAs55Garantie oImplement;
        public GarantieController(ITGAs55Garantie implement)
        {
            this.oImplement = implement;
        }

        [HttpGet("{id}")]
        public async Task<List<TGAs55Garantie>> GetGarantieProdListxxx(int id)
        {
            return await oImplement.GetGarantieProdList(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TGAs55Garantie oTGAs55Garantie)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(oTGAs55Garantie);
            }
            else
            {
                return null;
            }

        }


    }
}
