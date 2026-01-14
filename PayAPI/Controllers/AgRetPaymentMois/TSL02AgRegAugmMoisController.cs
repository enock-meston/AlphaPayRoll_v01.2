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
    public class TSL02AgRegAugmMoisController : ControllerBase
    {
        private readonly ITSL02AgRegAugmMois oImplement;
        public TSL02AgRegAugmMoisController(ITSL02AgRegAugmMois implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois()
        {
            return await oImplement.GetTSL02AgRegAugmMois();
        }
        [HttpGet("{id}")]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id)
        {
            return await oImplement.GetTSL02AgRegAugmMoisByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateRegAugmMoisResult([FromBody] AgDonIntialMois item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateRegAugmMoisResult(item);
            }
            else
            {
                return null;
            }

        }


    }
}
