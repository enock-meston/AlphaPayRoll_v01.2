using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550Sexe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550Sexe
{
    public class TCl550SexeService : ITCl550Sexe
    {
        private readonly HttpClient oHttpClient;

        public TCl550SexeService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Sexe>> GetTCl550Sexe()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Sexe[]>($"api/TCl550Sexe/")).ToList();
        }
    }
}

