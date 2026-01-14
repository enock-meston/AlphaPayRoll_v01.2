using Microsoft.AspNetCore.Components;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.AgRetPaymentMois
{
    public class TSL02AgRetCotisMoisService : ITSL02AgRetCotisMois
    {

        private readonly HttpClient ohttpClient;
        public TSL02AgRetCotisMoisService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMois()
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRetCotisMois/")).ToList();
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMoisByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRetCotisMois/{id}")).ToList();
        }

        public Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMoisByType(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Resultat> GetUpdateRetCotisMoisResult(AgDonIntialMois item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgRetCotisMois/", item);
        }
    }
}
