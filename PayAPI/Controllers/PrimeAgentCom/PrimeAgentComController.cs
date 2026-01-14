using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.PrimeAgentCom
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeAgentComController : ControllerBase
    {
        private readonly string connectionString;

        public PrimeAgentComController(IConfiguration configuratrion)
        {
            connectionString = configuratrion.GetConnectionString("ApiConnection")!;
        }

        [HttpGet("{id}")]
        //public async Task<List<AgentComPrime>> GetList(int id)
        public async Task<IActionResult> GetList(int id)
        {

            Resultat itemList = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(connectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    DynamicParameters oparameters = new();
                    oparameters.Add("@Periode", id);

                    var List = await oCon.QueryFirstAsync<Resultat>("Ps_CalculPrimeAgentCommercial", oparameters, commandType: CommandType.StoredProcedure); ;

                    if (List != null)
                    {
                        itemList = List;
                    }
                }
                if (itemList != null)
                    return Ok(itemList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(itemList);
            }
        }



    }
}
