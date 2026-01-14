using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TCl550MaritStatus
{
    public class TCl550MaritStatusService : ITCl550MaritStatus
    {

        private readonly HttpClient oHttpClient;

        public TCl550MaritStatusService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550MaritStatus>> GetTCl550MaritStatus()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550MaritStatus[]>($"api/TCl550MaritStatus/")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTCl550MaritStatus item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TCl550MaritStatus/", item);
        }

       
    }
}

