using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550DomEtud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550DomEtud
{
    public class TCl550DomEtudService : ITCl550DomEtud
    {
        private readonly HttpClient oHttpClient;

        public TCl550DomEtudService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550DomEtud>> GetTCl550DomEtud()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550DomEtud[]>($"api/TCl550DomEtud/")).ToList();
        }
    }
}
