using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Qualification;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.Qualification
{
    [Route("api/[controller]")]
    public class QualificationController : ControllerBase
    {
        private readonly IQualification oItem;
        public QualificationController(IQualification xxx)
        {
            oItem = xxx;
        }
        [HttpGet]
        public async Task<List<ClassQualification>> GetQualification()
        {
            return await oItem.GetQualification();
        }

        [HttpGet("{id}")]
        public async Task<List<ClassQualification>> GetQualificationRech(string id)
        {
            return await oItem.GetQualificationRech(id);
        }


        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassQualification item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutUpdate(item);
            }
            else
            {
                return null;
            }
        }
    }
}
