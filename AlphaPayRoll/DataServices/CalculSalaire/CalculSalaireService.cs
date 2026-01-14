using Microsoft.AspNetCore.Components;
using PayLibrary.CalculSalaire;
using PayLibrary.ParamSec.ViewModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.CalculSalaire
{
    public class CalculSalaireService : ICalculerSalaire
    {

        private readonly HttpClient oHttpClient;

        public CalculSalaireService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<Resultat> PostArchiverSalaire(ParamCallSalaire item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/ArchiverSalaire/", item);
        }

        public async Task<Resultat> PostCalculerSalaire(ParamCallSalaire item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/CalSalRim/", item);
        }
    }
}
