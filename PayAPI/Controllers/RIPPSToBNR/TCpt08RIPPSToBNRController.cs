using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.RIPPSToBNR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.RIPPSToBNR
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCpt08RIPPSToBNRController : ControllerBase
    {

        private readonly ITCpt08RIPPSToBNR oItem;
        public TCpt08RIPPSToBNRController(ITCpt08RIPPSToBNR xxx)
        {
            oItem = xxx;
        }
        [HttpGet]
        public async Task<List<TCpt08RIPPSToBNR>> GetRIPPSToBNR()
        {
            return await oItem.GetRIPPSToBNR();
        }


        [HttpPost]
        public async Task<Resultat> Post([FromBody] TCpt08RIPPSToBNR item)
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

