using Microsoft.AspNetCore.Mvc;
using PayLibrary.CongCircRequest;
using PayLibrary.CongConsult;
using PayLibrary.CongeRequestF;

namespace PayAPI.Controllers.CongConsult
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongConsultStatusController
    {
        private readonly ICongConsultStatus _congeStatus;

        public CongConsultStatusController(ICongConsultStatus congeStatus)
        {
            _congeStatus = congeStatus;
        }

        [HttpGet("{id}")]
        public async Task<List<CongConsultStatus>> GetAllCongeConsultStatus(string id)
        {
            return await _congeStatus.GetAllCongeConsultStatus(id);
        }
    }
}
