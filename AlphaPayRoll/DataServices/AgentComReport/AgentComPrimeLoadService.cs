using PayAPI.ReportFiles;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.AgentComReport
{
    public class AgentComPrimeLoadService
    {
        private readonly HttpClient ohttpClient;

        public AgentComPrimeLoadService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<Resultat> ListPrimeAsync(int id)
        {
            return await ohttpClient.GetFromJsonAsync<Resultat>($"api/PrimeAgentCom/{id}");
        }

    }
}
