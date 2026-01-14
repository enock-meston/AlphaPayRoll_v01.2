using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Promotion;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.Promotion
{
    public class TRH05PromotionService : ITRH05Promotion
    {
        private readonly HttpClient oHttpClient;

        public TRH05PromotionService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<TRH05Promotion>> GetPromotionByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<TRH05Promotion[]>($"api/TRH05Promotion/{id}")).ToList();
        }

        public async Task<Resultat> GetResutUpdate(TRH05Promotion item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05Promotion/", item);

        }

        public async Task<Resultat> ValiderPromotion(ParamValidPromotion param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05Promotion/validate/", param);

        }
    }
}
