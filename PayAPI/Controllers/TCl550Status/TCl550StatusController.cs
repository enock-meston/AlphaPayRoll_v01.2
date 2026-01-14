using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550Status;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Status
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550StatusController : ControllerBase
    {
        private readonly ITCl550Status oItem;

        public TCl550StatusController(ITCl550Status xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Status>> GetTCl550Status()
        {
            return await oItem.GetTCl550Status();
        }
    }
}
