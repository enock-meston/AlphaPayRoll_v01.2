using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSto551EventIn;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TSto551EventIn
{
    [Route("api/[controller]")]
    public class TSto551EventInController : ControllerBase
    {

        private readonly ITSto551EventIn oItem;

        public TSto551EventInController(ITSto551EventIn xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTSto551EventIn>> GetTSto551EventIn()
        {
            return await oItem.GetTSto551EventIn();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTSto551EventIn item)
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

