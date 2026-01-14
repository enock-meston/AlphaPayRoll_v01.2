
using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Permission;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH05PermissionController : ControllerBase
    {
        private readonly ITRH05Permission oImplement;
        public TRH05PermissionController(ITRH05Permission implement)
        {
            this.oImplement = implement;
        }
        [HttpPost]
        public async Task<Resultat> Post([FromBody] TRH05Permission item)
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

        [HttpGet]
        public async Task<List<TRH05Permission>> GetListAll()
        {

            return await oImplement.GetListAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH05Permission>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }
    }
}
