using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAffichageListController : ControllerBase
    {
        private readonly IMenuAffichage oMenuAffichageImplement;

        public MenuAffichageListController(IMenuAffichage menuAffichageImplement)
        {
            oMenuAffichageImplement = menuAffichageImplement;
        }

        [HttpGet("{id}")]
        public async Task<List<MenuAffichage>> GetMenuFonctList(string id)
        {
            return await oMenuAffichageImplement.GetMenuFonctList(id);
        }


    }
}
