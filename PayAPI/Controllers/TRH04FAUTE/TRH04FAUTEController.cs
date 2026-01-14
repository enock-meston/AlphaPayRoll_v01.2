using Microsoft.AspNetCore.Mvc;
using PayLibrary.Faute;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.Controllers.HumanResource
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH04FAUTEController : ControllerBase
    {
        private readonly ITRH04FAUTE oImplement;
        public TRH04FAUTEController(ITRH04FAUTE implement)
        {
            this.oImplement = implement;
        }
        [HttpPost]
        public async Task<Resultat> Post([FromBody] TRH04FAUTE item)
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
        public async Task<List<TRH04FAUTE>> GetListAll()
        {

            return await oImplement.GetListAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TRH04FAUTE>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }
    }
}
