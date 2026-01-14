using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuDynamController : ControllerBase
    {

        private readonly ITSc04MenuDynam oTSc04MenuDynamImplement;
        public MenuDynamController(ITSc04MenuDynam tSc04MenuDynamImplement)
        {
            oTSc04MenuDynamImplement = tSc04MenuDynamImplement;
        }

        [HttpGet]
        public async Task<IEnumerable<TSc04MenuDynam>> GetMenuDynamList()
        {
            return await oTSc04MenuDynamImplement.GetMenuDynamList();
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc04MenuDynam item)
        {
            if (ModelState.IsValid)
            {
                return await oTSc04MenuDynamImplement.GetUpdateResult(item);
            }
            else
            {
                return null;
            }
        }

    }
}
