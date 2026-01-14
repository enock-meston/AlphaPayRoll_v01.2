using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550Fonction;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Fonction
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550FonctionController : ControllerBase
    {
        private readonly ITCl550Fonction oItem;

        public TCl550FonctionController(ITCl550Fonction xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Fonction>> GetTCl550Fonction()
        {
            return await oItem.GetTCl550Fonction();
        }
    }
}
