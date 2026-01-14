using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL03TraitemAv;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL03TraitemAv
{
    [Route("api/[controller]")]
    public class TSL03TraitemAvController : ControllerBase
    {
        private readonly ITSL03TraitemAv oItem;

        public TSL03TraitemAvController(ITSL03TraitemAv xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTSL03TraitemAv>> GetTSL03TraitemAv()
        {
            return await oItem.GetTSL03TraitemAv();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTSL03TraitemAv item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutUpdate(item);
            }
            else
            {
                return null;
            }

        }
    }
}

