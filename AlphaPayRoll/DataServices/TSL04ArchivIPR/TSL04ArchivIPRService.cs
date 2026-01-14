using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL04ArchivIPR;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSL04ArchivIPR
{
    public class TSL04ArchivIPRService : ITSL04ArchivIPR
    {
        private readonly HttpClient oHttpClient;

        public TSL04ArchivIPRService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<ClassTSL04ArchivIPR>> GetTSL04ArchivIPR()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL04ArchivIPR[]>($"api/TSL04ArchivIPR/")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL04ArchivIPR item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL04ArchivIPR/", item);
        }

       
    }
}

