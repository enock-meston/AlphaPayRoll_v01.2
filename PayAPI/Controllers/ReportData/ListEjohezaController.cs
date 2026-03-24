using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListEjohezaController : ControllerBase
    {
        private readonly IListEjoheza _listEjoheza;

        public ListEjohezaController(IListEjoheza listEjoheza)
        {
            _listEjoheza = listEjoheza;
        }

        [HttpGet]
        public async Task<List<ListEjoheza>> GetListEjohezas()
        {
            if (ModelState.IsValid)
            {
                return await _listEjoheza.GetListEjohezas();
            }
            else
            {
                return null;
            }
        }

    }
}
