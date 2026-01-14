using Microsoft.AspNetCore.Mvc;
using PayLibrary.Contrat;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.Contrat
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffectationController : ControllerBase
    {

        private readonly IClasContrat oItem;
        public AffectationController(IClasContrat xxx)
        {
            oItem = xxx;
        }


        [HttpGet("{id}")]
        public async Task<List<TRH04Affectation>> GetAffectionByMatricule(string id)
        {
            return await oItem.GetAffectionByMatricule(id);
        }


        [HttpPost]
        public async Task<Resultat> GetResutUpdateAffec([FromBody] TRH04Affectation item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutUpdateAffect(item);
            }
            else
            {
                return null;
            }

        }


        [HttpPost("validateAffectation")]
        public async Task<Resultat> ValiderAffectation([FromBody] ParamValidAffectation param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderAffectation(param);
            }
            else
            {
                return null;
            }

        }

    }
}

