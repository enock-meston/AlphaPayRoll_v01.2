using Microsoft.AspNetCore.Mvc;
using PayLibrary.TRH550TypeSalaire;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.TypeSalaire
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRH550TypeSalaireController : ControllerBase
    {
        private readonly ITRH550TypeSalaire oItem;

        public TRH550TypeSalaireController(ITRH550TypeSalaire xxx)
        {
            oItem = xxx;
        }
        [HttpGet]
        public async Task<List<TRH550TypeSalaire>> GetAllTypeSalaire()
        {
            return await oItem.GetAllTypeSalaire();
        }

    }
}
