using Microsoft.AspNetCore.Mvc;
using PayLibrary.Contrat;
using PayLibrary.ContratSusp;
using PayLibrary.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.ContratSusp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH03ContratSuspController : ControllerBase
    {
        private readonly ITRH03ContratSusp oItem;

        public TRH03ContratSuspController(ITRH03ContratSusp xxx)
        {
            oItem = xxx;
        }

        [HttpGet]
        public async Task<List<TRH03ContratSusp>> GetAllSusContract()
        {
            return await oItem.GetAllSusContract();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH03ContratSusp>> GetSusContractByMatricule(string id)
        {
            return await oItem.GetSusContractByMatricule(id);
        }



        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TRH03ContratSusp item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutUpdate(item);
            }
            else
            {
                return null;
            }
        }

        [HttpPost("validate")]
        public async Task<Resultat> ValiderSusCotrat([FromBody] ParamValidContrat param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderSusCotrat(param);
            }
            else
            {
                return null;
            }

        }

    }
}
