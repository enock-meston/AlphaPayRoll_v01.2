using Microsoft.AspNetCore.Components;
using PayLibrary.ContratModif;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PostModif;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.PostModif
{
    public class TRH05PostModifService : ITRH05PostModif
    {
        private readonly HttpClient oHttpClient;

        public TRH05PostModifService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<TRH05PostModif>> GetPostModifByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<TRH05PostModif[]>($"api/TRH05PostModif/{id}")).ToList();
        }

        public async Task<Resultat> GetResutUpdate(TRH05PostModif item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05PostModif/", item);

        }

        public async Task<Resultat> ValiderPostModif(ParamValidPostModif param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05PostModif/validate/", param);

        }
    }
}
