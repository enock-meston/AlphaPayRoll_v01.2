using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.RubSalCompte;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.RubSalCompte
{
    public class TSl550RubSalCompteService: ITSl550RubSalCompte
    {
        public readonly HttpClient ohttpClient;

        public TSl550RubSalCompteService(HttpClient ohttp)
        {
            ohttpClient = ohttp;
        }
        public async Task<List<TSl550RubSalCompte>> GetList()
        {
            return (await ohttpClient.GetJsonAsync<TSl550RubSalCompte[]>($"api/TSlRubSalCompte/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TSl550RubSalCompte item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSlRubSalCompte/", item);
        }
    }
}
