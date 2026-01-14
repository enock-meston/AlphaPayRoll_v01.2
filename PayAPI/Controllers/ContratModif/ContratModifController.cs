using Microsoft.AspNetCore.Mvc;
using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.ContratModif
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratModifController : ControllerBase
    {
        private readonly ITHR05ContratModif oItem;
        public ContratModifController(ITHR05ContratModif item)
        {
            oItem = item;
        }


        [HttpGet("{id}")]
        public async Task<List<THR05ContratModif>> GetContratModifByMatricule(string id)
        {
            return await oItem.GetContratModifByMatricule(id);
        }


        [HttpPost]
        public async Task<Resultat> GetResutUpdate([FromBody] THR05ContratModif item)
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
        public async Task<Resultat> ValiderContratModif([FromBody] ParamValidContratModif param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderContratModif(param);
            }
            else
            {
                return null;
            }

        }
    }
}
