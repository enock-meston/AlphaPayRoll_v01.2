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
    public class UserController : ControllerBase
    {
        private readonly ITSc551User oSubMenuImplement;

        public UserController(ITSc551User menuAffichageImplement)
        {
            oSubMenuImplement = menuAffichageImplement;
        }

        [HttpGet]
        public async Task<List<TSc551User>> GetList()
        {
            return await oSubMenuImplement.GetList();
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc551User item)
        {
            if (ModelState.IsValid)
            {
                return await oSubMenuImplement.GetUpdateResult(item);
            }
            else
            {
                return null;
            }
        }
    }
}
