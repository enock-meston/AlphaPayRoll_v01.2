using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenuOneController : ControllerBase
    {
        private readonly ITSc551SubMenu oSubMenuImplement;

        public SubMenuOneController(ITSc551SubMenu menuAffichageImplement)
        {
            oSubMenuImplement = menuAffichageImplement;
        }

        [HttpGet("{id}")]
        public async Task<TSc551SubMenu> GetSubMenuOne(int id)
        {
            return await oSubMenuImplement.GetSubMenu(id);
        }
    }
}
