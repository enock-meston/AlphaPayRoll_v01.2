using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550Fonction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550Fonction
{
    public class TCl550FonctionServise : ITCl550Fonction
    {
        private readonly HttpClient oHttpClient;

        public TCl550FonctionServise(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Fonction>> GetTCl550Fonction()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Fonction[]>($"api/TCl550Fonction/")).ToList();
        }
    }
}