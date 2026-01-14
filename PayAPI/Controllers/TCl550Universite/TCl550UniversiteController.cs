using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550Universite;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Universite
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550UniversiteController : ControllerBase
    {
        // GET: api/<TCl550UniversiteController>
        private readonly ITCl550Universite oItem;

        public TCl550UniversiteController(ITCl550Universite xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Universite>> GetTCl550Universiteh()
        {
            return await oItem.GetTCl550Universite();
        }
    }
}
