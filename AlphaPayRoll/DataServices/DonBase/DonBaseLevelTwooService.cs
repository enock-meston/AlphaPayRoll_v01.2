using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaAssurance.DataServices.DonBase
{
    public class DonBaseLevelTwooService : IDonBaseLevelTwoo
    {

        private readonly HttpClient oHttpClient;

        public DonBaseLevelTwooService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<DonBaseLevelTwoo>> GetItemList(string id)
        {
            return (await oHttpClient.GetJsonAsync<DonBaseLevelTwoo[]>($"api/DonBaseLev2/{id}")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(DonBaseLevelTwoo item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/DonBaseLev2/", item);
        }
    }
}
