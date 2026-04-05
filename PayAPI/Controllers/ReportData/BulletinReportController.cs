using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulletinReportController : ControllerBase
    {
        private readonly IBulletinReport _bulletinReport;

        public BulletinReportController(IBulletinReport bulletinReport)
        {
            _bulletinReport = bulletinReport;
        }

        [HttpGet("GetBulletinReport")]
        public async Task<ActionResult<BulletinReport>> GetBulletinReport(
    [FromQuery] string Exercice,
    [FromQuery] string Mois,
    [FromQuery] string Matricule)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _bulletinReport.GetBulletinReport(Exercice, Mois, Matricule);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
