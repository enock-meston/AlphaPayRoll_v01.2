using Microsoft.AspNetCore.Components;
using PayLibrary.Contrat;
using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace AlphaPayRoll.DataServices.ContratModif
{
    public class THR05ContratModifService : ITHR05ContratModif
    {

        private readonly HttpClient oHttpClient;

        public THR05ContratModifService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<THR05ContratModif>> GetContratModifByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<THR05ContratModif[]>($"api/ContratModif/{id}")).ToList();

        }

        public async Task<Resultat> GetResutUpdate(THR05ContratModif item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/ContratModif/", item);

        }

        public async Task<Resultat> ValiderContratModif(ParamValidContratModif param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/ContratModif/validate/", param);

        }

        
    }
}
