
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Training;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH03TrainingService : ITRH03Training
    {
        private readonly HttpClient ohttpClient;

        public TRH03TrainingService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH03Training>> GetList(string id)
        {
            return (await ohttpClient.GetJsonAsync<TRH03Training[]>($"api/TRH03Training/{id}")).ToList();
        }

        public async Task<List<TRH03Training>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH03Training[]>($"api/TRH03Training/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TRH03Training item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TRH03Training/", item);
        }
    }
}
