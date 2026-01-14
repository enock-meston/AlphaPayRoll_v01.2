using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550Universite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550Universite
{
    public class TCl550UniversiteService : ITCl550Universite
    {
        private readonly HttpClient oHttpClient;

        public TCl550UniversiteService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Universite>> GetTCl550Universite()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Universite[]>($"api/TCl550Universite/")).ToList();
        }
    }
}
