using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550Departement;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550Departement
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCl550DepartementController : ControllerBase
    {
        private readonly ITCl550Departement oItem;

        public TCl550DepartementController(ITCl550Departement xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550Departement>> GetT550Branch()
        {
            return await oItem.GetTCl550Departement();
        }
    }
}
