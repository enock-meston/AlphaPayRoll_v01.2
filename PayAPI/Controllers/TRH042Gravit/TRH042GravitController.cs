using Microsoft.AspNetCore.Mvc;
using PayLibrary.Gravite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH042GravitController : ControllerBase
    {
        private readonly ITRH042Gravite oImplement;
        public TRH042GravitController(ITRH042Gravite implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TRH042Gravite>> GetListAll()
        {

            return await oImplement.GetListAll();
        }
    }
}
