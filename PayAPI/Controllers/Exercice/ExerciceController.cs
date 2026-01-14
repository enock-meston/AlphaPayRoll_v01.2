using Microsoft.AspNetCore.Mvc;
using PayLibrary.Exercice;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.Exercice
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciceController : ControllerBase
    {
        private readonly ITSL550Exercice oItem;

        public ExerciceController(ITSL550Exercice inter)
        {
            oItem = inter;
        }


        [HttpGet]
        public async Task<List<TSL550Exercice>> GetExercice()
        {
            return await oItem.GetExerciceAll();
        }

    }

}