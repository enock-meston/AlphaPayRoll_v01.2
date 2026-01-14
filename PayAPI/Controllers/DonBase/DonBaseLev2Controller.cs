using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.DonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonBaseLev2Controller : ControllerBase
    {
        private readonly IDonBaseLevelTwoo oImplement;
        public DonBaseLev2Controller(IDonBaseLevelTwoo implement)
        {
            this.oImplement = implement;
        }

        [HttpGet("{id}")]
        public async Task<List<DonBaseLevelTwoo>> GetList(string id)
        {
            return await oImplement.GetItemList(id);
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] DonBaseLevelTwoo item)
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
