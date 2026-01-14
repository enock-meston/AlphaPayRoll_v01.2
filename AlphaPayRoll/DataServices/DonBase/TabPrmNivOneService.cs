using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.DonBase
{
    public class TabPrmNivOneService: ITabPrmNivOne
    {
        private readonly HttpClient oHttpClient;

        public TabPrmNivOneService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<IList<TabPrmNivOne>> GetDBList(int id)
        {
            return await oHttpClient.GetJsonAsync<TabPrmNivOne[]>($"api/DonBaseNivOne/{id}");
        }

 
        public async Task<IList<TabPrmNivOne>> GetDBListName(string id)
        {
            return await oHttpClient.GetJsonAsync<TabPrmNivOne[]>($"api/DonBaseNivOneNom/{id}");
        }

        public async Task<TabPrmNivOne> GetDBRec(string id)
        {
            return await oHttpClient.GetJsonAsync<TabPrmNivOne>($"api/DonBaseNivOneBis/{id}");
        }

        public async Task<Resultat> MajDonBaseNivOne(TabPrmNivOne oTabPrmNivOne)
        {

            return await oHttpClient.PostJsonAsync<Resultat>($"api/DonBaseNivOne/",oTabPrmNivOne);
            
        }
    }
}
