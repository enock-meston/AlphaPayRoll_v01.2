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
    public class RoleController : ControllerBase
    {
        private readonly ITSc550Role oImplement;
        public RoleController(ITSc550Role implement)
        {
            this.oImplement = implement;
        }

        [HttpGet("{id}")]
        public async Task<List<TSc550Role>> GetList(int id)
        {
            return await oImplement.GetList(id);
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSc550Role item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(item);
            }
            else
            {
                return null;
            }

        }

    }
}
