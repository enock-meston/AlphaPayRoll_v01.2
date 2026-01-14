using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL03Traitem;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL03Traitem
{
    [Route("api/[controller]")]
    public class TSL03TraitemController : ControllerBase
    {
        private readonly ITSL03Traitem oItem;

        public TSL03TraitemController(ITSL03Traitem xxx)
        {
            oItem = xxx;
        }


        [HttpGet("{id}")]
        public async Task<List<ClassTSL03Traitem>> GetTSL03TraitemByAgent(int id)
        {
            return await oItem.GetTSL03TraitemByAgent(id);
        }

        [HttpGet]
        public async Task<List<ClassTSL03Traitem>> GetTSL03Traitem()
        {
            return await oItem.GetTSL03Traitem();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTSL03Traitem item)
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

