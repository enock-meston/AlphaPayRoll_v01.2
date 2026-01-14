using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgHSup;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL02AgHSup
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL02AgHSupController : ControllerBase
    {
        private readonly ITSL02AgHSup oImplement;
        public TSL02AgHSupController(ITSL02AgHSup implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<ClassTSL02AgHSup>> GetTSL02AgHSup()
        {
            return await oImplement.GetTSL02AgHSup();
        }

        [HttpGet("{id}")]
        public async Task<List<ClassTSL02AgHSup>> GetTSL02AgHSupByAgent(int id)
        {
            return await oImplement.GetTSL02AgHSupByAgent(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] ClassTSL02AgHSup item)
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