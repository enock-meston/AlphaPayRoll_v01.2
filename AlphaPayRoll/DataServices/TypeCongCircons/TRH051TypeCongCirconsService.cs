using Microsoft.AspNetCore.Components;
using PayLibrary.Depart;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TypeCongCircons;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TypeCongCircons
{
    public class TRH051TypeCongCirconsService : ITRH051TypeCongCircons
    {
        private readonly HttpClient oHttpClient;

        public TRH051TypeCongCirconsService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<TRH051TypeCongCircons>> GetTRH051TypeCongCircons()
        {
            return (await oHttpClient.GetJsonAsync<TRH051TypeCongCircons[]>($"api/TRH051TypeCongCircons")).ToList();

        }

        public async Task<Resultat> UpdateTRH051TypeCongCircons(TRH051TypeCongCircons item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH051TypeCongCircons/", item);
        }
    }
}
