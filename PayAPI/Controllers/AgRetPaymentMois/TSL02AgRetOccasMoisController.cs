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
    public class TSL02AgRetOccasMoisController : ControllerBase
    {
        private readonly ITSL02AgRetOccasMois oImplement;
        public TSL02AgRetOccasMoisController(ITSL02AgRetOccasMois implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois()
        {
            return await oImplement.GetTSL02AgRetOccasMois();
        }
        [HttpGet("{id}")]
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id)
        {
            return await oImplement.GetTSL02AgRetOccasMoisByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateRetOccasMoisResult([FromBody] AgDonIntialMois item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateRetOccasMoisResult(item);
            }
            else
            {
                return null;
            }

        }




    }
}
