using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550Departement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550Departement
{
    public class TCl550DepartementServise : ITCl550Departement
    {
        private readonly HttpClient oHttpClient;

        public TCl550DepartementServise(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Departement>> GetTCl550Departement()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Departement[]>($"api/TCl550Departement/")).ToList();
        }
    }
}
