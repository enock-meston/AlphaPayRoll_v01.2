using Microsoft.AspNetCore.Mvc;
using PayLibrary.CongeRequestF;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListPayByBranchController : ControllerBase
    {
        private readonly IListPayByBranch _listPayByBranch;

        public ListPayByBranchController(IListPayByBranch listPayByBranch )
        {
            _listPayByBranch = listPayByBranch;
        }

        [HttpGet("{id}")]
        public async Task<List<ListPayByBranch>> GetListPayByBranch(string id)
        {
            if (ModelState.IsValid)
            {
                return await _listPayByBranch.GetListPayByBranch(id);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<List<ListPayByBranch>> GetListPayGen()
        {
            if (ModelState.IsValid)
            {
                return await _listPayByBranch.GetListPayGen();
            }
            else
            {
                return null;
            }
        }

        [HttpGet("consolid")]
        public async Task<List<ListPayByBranch>> GetListPayConsolid()
        {
            if (ModelState.IsValid)
            {
                return await _listPayByBranch.GetListPayConsolid();
            }
            else
            {
                return null;
            }
        }
    }
}
