using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL04ArchivINSS;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSL04ArchivINSS
{
    [Route("api/[controller]")]
    public class TSL04ArchivINSSController : ControllerBase
    {
        private readonly ITSL04ArchivINSS oItem;

        public TSL04ArchivINSSController(ITSL04ArchivINSS xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTSL04ArchivINSS>> GetTSL04ArchivINSS()
        {
            return await oItem.GetTSL04ArchivINSS();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTSL04ArchivINSS item)
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

