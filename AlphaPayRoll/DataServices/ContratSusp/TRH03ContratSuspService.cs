using Microsoft.AspNetCore.Components;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ContratSusp;
using PayLibrary.General;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.ContratSusp
{
    public class TRH03ContratSuspService : ITRH03ContratSusp
    {
        private readonly HttpClient oHttpClient;

        public TRH03ContratSuspService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<TRH03ContratSusp>> GetAllSusContract()
        {
            return (await oHttpClient.GetJsonAsync<TRH03ContratSusp[]>($"api/TRH03ContratSusp")).ToList();
        }

        public async Task<Resultat> GetResutUpdate(TRH03ContratSusp item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH03ContratSusp/", item);

        }

        public async Task<List<TRH03ContratSusp>> GetSusContractByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<TRH03ContratSusp[]>($"api/TRH03ContratSusp/{id}")).ToList();

        }

       
        public async Task<Resultat> ValiderSusCotrat(ParamValidContrat param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH03ContratSusp/validate/", param);

        }
    }
}
