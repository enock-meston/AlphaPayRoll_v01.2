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
    public class SubMenuController : ControllerBase
    {
        private readonly ITSc551SubMenu oSubMenuImplement;

        public SubMenuController(ITSc551SubMenu menuAffichageImplement)
        {
            oSubMenuImplement = menuAffichageImplement;
        }

        [HttpGet]
        public async Task<List<TSc551SubMenu>> GetSubMenuList()
        {
            return await oSubMenuImplement.GetSubMenuList();
        }

        //[HttpGet]
        //public async Task<List<TSc551SubMenu>> GetListAll()
        //{
        //    return await oSubMenuImplement.GetListAll();
        //}

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc551SubMenu item)
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
