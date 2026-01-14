
using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Training;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH03TrainingController : ControllerBase
    {
        private readonly ITRH03Training oImplement;
        public TRH03TrainingController(ITRH03Training implement)
        {
            this.oImplement = implement;
        }
        [HttpPost]
        public async Task<Resultat> Post([FromBody] TRH03Training item)
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
        public async Task<List<TRH03Training>> GetListAll()
        {

            return await oImplement.GetListAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH03Training>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }
    }
}
