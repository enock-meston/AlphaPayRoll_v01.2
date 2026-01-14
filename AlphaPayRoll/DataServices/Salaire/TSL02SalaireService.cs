using Microsoft.AspNetCore.Components;
using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Salaire;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace AlphaPayRoll.DataServices.Salaire
{


    public class TSL02SalaireService : ITSL02Salaire
    {
        private readonly HttpClient oHttpClient;
        public TSL02SalaireService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<TSL02Salaire>> GetSalaire(string id)
        {
            return (await oHttpClient.GetJsonAsync<TSL02Salaire[]>($"api/TSL02Salaire/{id}")).ToList();

        }

        public async Task<List<TSL02Salaire>> GetSalaireAll()
        {
            return (await oHttpClient.GetJsonAsync<TSL02Salaire[]>($"api/TSL02Salaire")).ToList();

        }

        public async Task<Resultat> GetUpdateResult(TSL02Salaire item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL02Salaire/", item);

        }
    }
}
