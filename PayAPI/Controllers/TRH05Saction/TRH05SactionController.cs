
using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Saction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH05SactionController : ControllerBase
    {
        private readonly ITRH05Saction oImplement;
        public TRH05SactionController(ITRH05Saction implement)
        {
            this.oImplement = implement;
        }
        [HttpPost]
        public async Task<Resultat> Post([FromBody] TRH05Saction item)
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
        public async Task<List<TRH05Saction>> GetListAll()
        {

            return await oImplement.GetListAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH05Saction>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }
    }
}
