using Microsoft.AspNetCore.Mvc;
using PayLibrary.Localisation;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.Mutation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH05MutationController : ControllerBase
    {
        private readonly ITRH05Mutation oImplement;
        public TRH05MutationController(ITRH05Mutation implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TRH05Mutation>> GetListAll()
        {
            return await oImplement.GetListAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH05Mutation>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TRH05Mutation item)
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


        [HttpPost("validate")]
        public async Task<Resultat> ValiderMutation([FromBody] ParamValidMutation param)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.ValiderMutation(param);
            }
            else
            {
                return null;
            }

        }




    }
}
