using Microsoft.AspNetCore.Components;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.AgRetPaymentMois
{
    public class TSL02AgRetPaymentMoisService : ITSL02AgRetPaymentMois
    {

        private readonly HttpClient ohttpClient;
        public TSL02AgRetPaymentMoisService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois()
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRetPayment/")).ToList();
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRetPayment/{id}")).ToList();
        }

        public Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByType(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Resultat> GetUpdatePaymentMoisResult(AgDonIntialMois item)
        {
           return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgRetPayment/", item);
        }
    }
}
