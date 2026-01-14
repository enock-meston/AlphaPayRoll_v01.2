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
    public class TSL02AgRetPaymentController : ControllerBase
    {
        private readonly ITSL02AgRetPaymentMois oImplement;
        public TSL02AgRetPaymentController(ITSL02AgRetPaymentMois implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois()
        {
            return await oImplement.GetTSL02AgRetPaymentMois();
        }
        [HttpGet("{id}")]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id)
        {
            return await oImplement.GetTSL02AgRetPaymentMoisByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] AgDonIntialMois item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdatePaymentMoisResult(item);
            }
            else
            {
                return null;
            }

        }


    }
}
