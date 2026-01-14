using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550User;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550User
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550UserController : ControllerBase
    {
        private readonly ITCl550User oItem;

        public TCl550UserController(ITCl550User xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550User>> GetTCl550User()
        {
            return await oItem.GetTCl550User();
        }
    }
}
