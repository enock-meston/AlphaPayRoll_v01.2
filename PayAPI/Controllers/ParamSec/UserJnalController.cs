using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJnalController : ControllerBase
    {
        private readonly ITSc552UserJnal oImplement;
        public UserJnalController(ITSc552UserJnal implement)
        {
            this.oImplement = implement;
        }

        [HttpGet("{id}")]
        public async Task<List<TSc552UserJnal>> GetList(int id)
        {
            return await oImplement.GetList(id);
        }

        //[HttpPost]
        //public async Task<Resultat> Post([FromBody] TSc552UserJnal oTSc552UserJnal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return await oImplement.GetUpdateResult(oTSc552UserJnal);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}
