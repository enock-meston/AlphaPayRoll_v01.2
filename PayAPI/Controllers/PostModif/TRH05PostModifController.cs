using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PostModif;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.PostModif
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH05PostModifController : ControllerBase
    {
        private readonly ITRH05PostModif oItem;
        public TRH05PostModifController(ITRH05PostModif item)
        {
            oItem = item;
        }


        [HttpGet("{id}")]
        public async Task<List<TRH05PostModif>> GetPostModifByMatricule(string id)
        {
            return await oItem.GetPostModifByMatricule(id);
        }


        [HttpPost]
        public async Task<Resultat> GetResutUpdate([FromBody] TRH05PostModif item)
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
        public async Task<Resultat> ValiderPostModif([FromBody] ParamValidPostModif param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderPostModif(param);
            }
            else
            {
                return null;
            }

        }
    }
}
