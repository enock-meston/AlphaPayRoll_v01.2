using Microsoft.AspNetCore.Mvc;
using PayLibrary.TSL550TPHSup;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL550TPHSup
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL550TPHSupController : ControllerBase
    {
        private readonly ITSL550TPHSup oImplement;
        public TSL550TPHSupController(ITSL550TPHSup implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<ClassTSL550TPHSup>> GetTSL550TPHSup()
        {
            return await oImplement.GetTSL550TPHSup();
        }

        //[HttpPost]
        //public async Task<Resultat> GetUpdateResult([FromBody] ClassTSL550TPHSup item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return await oImplement.GetUpdateResult(item);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}
