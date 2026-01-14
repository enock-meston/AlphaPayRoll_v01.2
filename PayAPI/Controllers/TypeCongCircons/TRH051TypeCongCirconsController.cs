using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TypeCongCircons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TypeCongCircons
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH051TypeCongCirconsController : ControllerBase
    {
        private readonly ITRH051TypeCongCircons oItem;
        public TRH051TypeCongCirconsController(ITRH051TypeCongCircons item)
        {
            oItem = item;
        }

        [HttpGet]
        public async Task<List<TRH051TypeCongCircons>> GetTRH051TypeCongCircons()
        {
            return await oItem.GetTRH051TypeCongCircons();
        }


        [HttpPost]
        public async Task<Resultat> UpdateTRH051TypeCongCircons([FromBody] TRH051TypeCongCircons item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.UpdateTRH051TypeCongCircons(item);
            }
            else
            {
                return null;
            }

        }
    }
}
