using Microsoft.AspNetCore.Components;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.AgRetPaymentMois
{
    public class TSL02AgRegAugmMoisService : ITSL02AgRegAugmMois
    {

        private readonly HttpClient ohttpClient;
        public TSL02AgRegAugmMoisService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMois()
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRegAugmMois/")).ToList();
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRegAugmMois/{id}")).ToList();
        }

        public Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByType(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Resultat> GetUpdateRegAugmMoisResult(AgDonIntialMois item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgRegAugmMois/", item);
        }
    }
}
