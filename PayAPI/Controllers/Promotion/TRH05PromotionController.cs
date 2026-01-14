using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Promotion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.Promotion
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH05PromotionController : ControllerBase
    {
        private readonly ITRH05Promotion oItem;
        public TRH05PromotionController(ITRH05Promotion item)
        {
            oItem = item;
        }


        [HttpGet("{id}")]
        public async Task<List<TRH05Promotion>> GetPromotionByMatricule(string id)
        {
            return await oItem.GetPromotionByMatricule(id);
        }


        [HttpPost]
        public async Task<Resultat> GetResutUpdate([FromBody] TRH05Promotion item)
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
        public async Task<Resultat> ValiderPromotion([FromBody] ParamValidPromotion param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderPromotion(param);
            }
            else
            {
                return null;
            }

        }
    }
}
