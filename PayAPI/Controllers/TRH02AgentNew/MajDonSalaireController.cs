using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02AgentNew;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TRH02AgentNew
{
    [Route("api/TRH02AgentNew/[controller]")]
    [ApiController]
    public class MajDonSalaireController : ControllerBase
    {
        private readonly ITRH02Agent oItem;
        public MajDonSalaireController(ITRH02Agent xxx)
        {
            oItem = xxx;
        }


        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassTRH02Agent item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutMajSalaire(item);
            }
            else
            {
                return null;
            }

        }

    }
}
