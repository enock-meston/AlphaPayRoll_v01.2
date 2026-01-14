using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL04ArchivIPR;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL04ArchivIPR
{
    [Route("api/[controller]")]
    public class TSL04ArchivIPRController : ControllerBase
    {

        private readonly ITSL04ArchivIPR oItem;

        public TSL04ArchivIPRController(ITSL04ArchivIPR xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTSL04ArchivIPR>> GetTSL04ArchivIPR()
        {
            return await oItem.GetTSL04ArchivIPR();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTSL04ArchivIPR item)
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

