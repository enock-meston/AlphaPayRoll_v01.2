using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550NivEtudId;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550NivEtudId
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550NivEtudIdController : ControllerBase
    {
        private readonly ITCl550NivEtudId oItem;

        public TCl550NivEtudIdController(ITCl550NivEtudId xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550NivEtudId>> GetTCl550NivEtudId()
        {
            return await oItem.GetTCl550NivEtudId();
        }

    }
}
