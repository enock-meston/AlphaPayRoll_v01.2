using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgDimAugmSal;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL02AgDimAugmSal
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL02AgDimAugmSalController : ControllerBase
    {
        private readonly ITSL02AgDimAugmSal oImplement;
        public TSL02AgDimAugmSalController(ITSL02AgDimAugmSal implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSal()
        {
            return await oImplement.GetTSL02AgDimAugmSal();
        }
        [HttpGet("{id}")]
        public async Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSalByAgent(int id)
        {
            return await oImplement.GetTSL02AgDimAugmSalByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] ClassTSL02AgDimAugmSal item)
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
