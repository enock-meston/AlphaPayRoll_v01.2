using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.SalProcess
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalProcessController : ControllerBase
    {
        private readonly ITSL00Process oItem;
        public SalProcessController(ITSL00Process inter)
        {
            oItem = inter;
        }


        [HttpGet]
        public async Task<List<TSL00Process>> GetSalProcessAll()
        {
            return await oItem.GetSalProcessAll();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSL00Process item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetUpdateResult(item);
            }
            else
            {
                return null;
            }

        }

    }
}
