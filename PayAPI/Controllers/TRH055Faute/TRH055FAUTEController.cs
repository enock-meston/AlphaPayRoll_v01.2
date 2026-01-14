using Microsoft.AspNetCore.Mvc;
using PayLibrary.FauteTRH055;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TRH055Faute
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH055FAUTEController : ControllerBase
    {
        private readonly ITRH055FAUTE oImplement;
        public TRH055FAUTEController(ITRH055FAUTE implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TRH055FAUTE>> GetListAll()
        {
            return await oImplement.GetListAll();
        }

    }
}
