using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuDynamOneController : ControllerBase
    {
        private readonly ITSc04MenuDynam oTSc04MenuDynamImplement;
        public MenuDynamOneController(ITSc04MenuDynam tSc04MenuDynamImplement)
        {
            oTSc04MenuDynamImplement = tSc04MenuDynamImplement;
        }

        //[HttpGet("{id}")]
        //public async Task<TSc04MenuDynam> GetMenuDynam(string id)
        //{
        //    return await oTSc04MenuDynamImplement.GetMenuDynam(id);
        //}
    }
}
