using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550Deplom;
using PayLibrary.TCl550MaritStatus;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TCl550Deplom
{
    public class TCl550DeplomService : ITCl550Deplom
    {

        private readonly HttpClient oHttpClient;

        public TCl550DeplomService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Deplom>> GetTCl550Deplom()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Deplom[]>($"api/TCl550Deplom/")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTCl550Deplom item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TCl550Deplom/", item);
        }

       
    }
}

