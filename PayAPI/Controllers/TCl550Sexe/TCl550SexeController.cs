using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550Sexe;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Sexe
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550SexeController : ControllerBase
    {
        private readonly ITCl550Sexe oItem;

        public TCl550SexeController(ITCl550Sexe xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Sexe>> GetTCl550Sexe()
        {
            return await oItem.GetTCl550Sexe();
        }

    }
}
