using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.RubSalCompte;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.RubSalCompte
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSlRubSalCompteController : ControllerBase
    {
        private readonly ITSl550RubSalCompte oImplement;
        public TSlRubSalCompteController(ITSl550RubSalCompte implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<TSl550RubSalCompte>> GetList()
        {
            return await oImplement.GetList();
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] TSl550RubSalCompte oTSl550RubSalCompte)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(oTSl550RubSalCompte);
            }
            else
            {
                return null;
            }

        }
    }
}
