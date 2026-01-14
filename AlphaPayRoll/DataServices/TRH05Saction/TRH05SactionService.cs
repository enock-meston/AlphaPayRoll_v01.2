using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Saction;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH05SactionService : ITRH05Saction
    {
        private readonly HttpClient ohttpClient;

        public TRH05SactionService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH05Saction>> GetList(string id)
        {
            return (await ohttpClient.GetJsonAsync<TRH05Saction[]>($"api/TRH05Saction/{id}")).ToList();
        }

        public async Task<List<TRH05Saction>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH05Saction[]>($"api/TRH05Saction/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TRH05Saction item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TRH05Saction/", item);
        }
    }
}
