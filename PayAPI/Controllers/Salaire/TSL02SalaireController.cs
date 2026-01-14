using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Salaire;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.Salaire
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL02SalaireController : ControllerBase
    {

        private readonly ITSL02Salaire oImplement;
        public TSL02SalaireController(ITSL02Salaire implement)
        {
            this.oImplement = implement;
        }


        [HttpGet]
        public async Task<List<TSL02Salaire>> GetSalaireAll()
        {
            return await oImplement.GetSalaireAll();
        }

        [HttpGet("{id}")]
        public async Task<List<TSL02Salaire>> GetSalaire(string id)
        {
            return await oImplement.GetSalaire(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TSL02Salaire item)
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



    }
}
