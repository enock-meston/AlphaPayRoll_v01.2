using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListRetCaisSolidController : ControllerBase
    {
        private readonly IListRetCaisSolid _listBourse;

        public ListRetCaisSolidController(IListRetCaisSolid listBourse)
        {
            _listBourse = listBourse;
        }

        [HttpGet]
        public async Task<List<ListRetCaisSolid>> GetListRetCaisSolid()
        {
            if (ModelState.IsValid)
            {
                return await _listBourse.GetListRetCaisSolid();
            }
            else
            {
                return null;
            }
        }
    }
}
