using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550NatIDType;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550NatIDType
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550NatIDTypeController : ControllerBase
    {
        private readonly ITCl550NatIDType oItem;

        public TCl550NatIDTypeController(ITCl550NatIDType xxx)
        {
            oItem = xxx;
        }
        [HttpGet]
        public async Task<List<ClassTCl550NatIDType>> GetIdType()
        {
            return await oItem.GetIdType();
        }
    }
}
