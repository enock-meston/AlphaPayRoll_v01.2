using Microsoft.AspNetCore.Components;
using PayLibrary.AgRegAugmBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.AgRetCotisation
{
    public class TSL02AgRetCotisService: ITSL02AgRetCotis
    {

        //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
        private readonly HttpClient ohttpClient;
        public TSL02AgRetCotisService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotis()
        {
            return (await ohttpClient.GetJsonAsync<TSL02AgRetCotis[]>($"api/TSL02AgRetCotis/")).ToList();
        }

        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<TSL02AgRetCotis[]>($"api/TSL02AgRetCotis/{id}")).ToList();
        }

        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByType(int id)
        {
            return (await ohttpClient.GetJsonAsync<TSL02AgRetCotis[]>($"api/TSL02AgRetCotisType/{id}")).ToList();
        }

   

        public async Task<Resultat> GetUpdateResult(TSL02AgRetCotis item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgRetCotis/", item);
        }

      
    }
}
