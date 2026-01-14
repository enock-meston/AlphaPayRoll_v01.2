using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamDonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamGenController : ControllerBase
    {
        private readonly IT000ParamGen oImplement;
        public ParamGenController(IT000ParamGen implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<T000ParamGen>> GetList()
        {
            return await oImplement.GetList();
        }

        [HttpPost]
        public async Task<Resultat> Post([FromBody] T000ParamGen oT000ParamGen)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(oT000ParamGen);
            }
            else
            {
                return null;
            }

        }


    }
}
