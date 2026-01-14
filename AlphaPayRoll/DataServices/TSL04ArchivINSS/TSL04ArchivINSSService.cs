using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL04ArchivINSS;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSL04ArchivINSS
{
    public class TSL04ArchivINSSService : ITSL04ArchivINSS
    {
        private readonly HttpClient oHttpClient;

        public TSL04ArchivINSSService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTSL04ArchivINSS>> GetTSL04ArchivINSS()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL04ArchivINSS[]>($"api/TSL04ArchivINSS/")).ToList();
        }

        public async Task<Resultat> GetResutUpdate(ClassTSL04ArchivINSS item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL04ArchivINSS/", item);
        }

        
    }
}

