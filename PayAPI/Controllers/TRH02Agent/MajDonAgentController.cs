using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TRH02Agent
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajDonAgentController : ControllerBase
    {
        private readonly ITRH02Agent oItem;
        public MajDonAgentController(ITRH02Agent xxx)
        {
            oItem = xxx;
        }



        [HttpPost]
        public async Task<Resultat> GetUpdateDon([FromBody] ClasParamMajDon item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetUpdateDon(item);
            }
            else
            {
                return null;
            }

        }

    }
}
