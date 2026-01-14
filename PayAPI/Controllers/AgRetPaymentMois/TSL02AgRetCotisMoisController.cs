using Microsoft.AspNetCore.Mvc;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.AgRetPaymentMois
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL02AgRetCotisMoisController : ControllerBase
    {
        private readonly ITSL02AgRetCotisMois oImplement;
        public TSL02AgRetCotisMoisController(ITSL02AgRetCotisMois implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois()
        {
            return await oImplement.GetTSL02AgRetCotisMois();
        }

        [HttpGet("{id}")]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id)
        {
            return await oImplement.GetTSL02AgRetCotisMoisByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateRetCotisMoisResult([FromBody] AgDonIntialMois item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateRetCotisMoisResult(item);
            }
            else
            {
                return null;
            }

        }


    }
}
