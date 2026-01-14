using Microsoft.AspNetCore.Mvc;
using PayLibrary.TypeSaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH051TypeSactionController : ControllerBase
    {
        private readonly ITRH051TypeSaction oImplement;
        public TRH051TypeSactionController(ITRH051TypeSaction implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TRH051TypeSaction>> GetListAll()
        {

            return await oImplement.GetListAll();
        }
    }
}
