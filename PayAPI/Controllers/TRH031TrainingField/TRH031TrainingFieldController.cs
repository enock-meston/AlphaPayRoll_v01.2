using Microsoft.AspNetCore.Mvc;
using PayLibrary.TrainingField;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH031TrainingFieldController : ControllerBase
    {


        private readonly ITRH031TrainingField oImplement;
        public TRH031TrainingFieldController(ITRH031TrainingField implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TRH031TrainingField>> GetListAll()
        {

            return await oImplement.GetListAll();
        }
    }
}
