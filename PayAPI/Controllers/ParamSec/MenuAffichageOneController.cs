using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAffichageOneController : ControllerBase
    {
        private readonly IMenuAffichage oMenuAffichageImplement;

        public MenuAffichageOneController(IMenuAffichage menuAffichageImplement)
        {
            oMenuAffichageImplement = menuAffichageImplement;
        }

        [HttpGet("{id}")]
        public async Task<MenuAffichage> GetMenuFonctOne(int id)
        {
            return await oMenuAffichageImplement.GetMenuFonctOne(id);
        }
    }
}
