using Microsoft.AspNetCore.Components;
using PayLibrary.Localisation;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace AlphaPayRoll.DataServices.Mutation
{
    public class TRH05MutationService : ITRH05Mutation
    {

        private readonly HttpClient oHttpClient;

        public TRH05MutationService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<TRH05Mutation>> GetList(string id)
        {
            return (await oHttpClient.GetJsonAsync<TRH05Mutation[]>($"api/TRH05Mutation/{id}")).ToList();

        }

        public async Task<List<TRH05Mutation>> GetListAll()
        {
            return (await oHttpClient.GetJsonAsync<TRH05Mutation[]>($"api/TRH05Mutation/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TRH05Mutation item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05Mutation/", item);
        }

        public async Task<Resultat> ValiderMutation(ParamValidMutation param)
        {
            //throw new System.NotImplementedException();
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH05Mutation/validate/", param);

        }
    }
}
