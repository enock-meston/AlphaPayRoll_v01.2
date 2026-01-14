using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Personnel_RIM2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.Personnel_RIM2
{
    public class Personnel_RIM2Service : IPersonnel_RIM2
    {
        private readonly HttpClient oHttpClient;

        public Personnel_RIM2Service(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<ClassPersonnel_RIM2>> GetPersonnelAll()
        {
            return (await oHttpClient.GetJsonAsync<ClassPersonnel_RIM2[]>($"api/Personnel_RIM2/")).ToList();
        }

        public async Task<List<ClassPersonnel_RIM2>> GetPersonnelRech(string id)
        {
            return (await oHttpClient.GetJsonAsync<ClassPersonnel_RIM2[]>($"api/Personnel_RIM2/{id}")).ToList();
        }
        public async Task<Resultat> GetResutUpdate(ClassPersonnel_RIM2 item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Personnel_RIM2/", item);
        }
    }
}
