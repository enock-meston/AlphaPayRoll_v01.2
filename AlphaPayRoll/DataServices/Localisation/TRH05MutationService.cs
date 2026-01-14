using Microsoft.AspNetCore.Components;
using PayLibrary.Localisation;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace AlphaPayRoll.DataServices.Localisation
{
    public class TRH05LocalisationService : ITRH05Localisation
    {

        private readonly HttpClient oHttpClient;

        public TRH05LocalisationService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<TRH05Localisation>> GetList(string id)
        {
            return (await oHttpClient.GetJsonAsync<TRH05Localisation[]>($"api/TRH05Localisation/{id}")).ToList();

        }

        public async Task<List<TRH05Localisation>> GetListAll()
        {
            return (await oHttpClient.GetJsonAsync<TRH05Localisation[]>($"api/TRH05Localisation/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TRH05Localisation item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05Localisation/", item);
        }

        public async Task<Resultat> ValiderLocalisation(ParamValidLocalisation param)
        {
            //throw new System.NotImplementedException();
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05Localisation/validate/", param);

        }
    }
}
