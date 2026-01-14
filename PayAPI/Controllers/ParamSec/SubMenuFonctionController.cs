using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenuFonctionController : ControllerBase
    {

        private readonly ITSc551SubMenu oSubMenuImplement;

        public SubMenuFonctionController(ITSc551SubMenu menuAffichageImplement)
        {
            oSubMenuImplement = menuAffichageImplement;
        }

        [HttpGet]
        public async Task<List<TSc551SubMenu>> GetSubMenuList()
        {
            return await oSubMenuImplement.GetFonctionMenu();
        }


    }
}
