using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListSanLamController : ControllerBase
    {
        private readonly IListSanLam _listSanLam;

        public ListSanLamController(IListSanLam listSanLam)
        {
            _listSanLam = listSanLam;
        }

        [HttpGet]
        public async Task<List<ListSanLam>> GetListSanLam()
        {
            if (ModelState.IsValid)
            {
                return await _listSanLam.GetListSanLam();
            }
            else
            {
                return null;
            }
        }
    }
}
