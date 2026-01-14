using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550Deplom;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Deplom
{
    [Route("api/[controller]")]
    public class TCl550DeplomController : ControllerBase
    {
        private readonly ITCl550Deplom oItem;

        public TCl550DeplomController(ITCl550Deplom xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Deplom>> GetTCl550Deplom()
        {
            return await oItem.GetTCl550Deplom();
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTCl550Deplom item)
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

