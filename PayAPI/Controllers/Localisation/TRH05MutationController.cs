using Microsoft.AspNetCore.Mvc;
using PayLibrary.Localisation;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.Localisation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH05LocalisationController : ControllerBase
    {
        private readonly ITRH05Localisation oImplement;
        public TRH05LocalisationController(ITRH05Localisation implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TRH05Localisation>> GetListAll()
        {
            return await oImplement.GetListAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH05Localisation>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TRH05Localisation item)
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
        public async Task<Resultat> ValiderLocalisation([FromBody] ParamValidLocalisation param)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.ValiderLocalisation(param);
            }
            else
            {
                return null;
            }

        }




    }
}
