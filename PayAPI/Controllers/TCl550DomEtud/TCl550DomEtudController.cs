using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550DomEtud;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550DomEtud
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550DomEtudController : ControllerBase
    {
        // GET: api/<TCl550DomEtudController>
        private readonly ITCl550DomEtud oItem;

        public TCl550DomEtudController(ITCl550DomEtud xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550DomEtud>> GetTCl550DomEtud()
        {
            return await oItem.GetTCl550DomEtud();
        }
    }
}
