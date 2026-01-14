

using PayLibrary.General;
using PayLibrary.TCt550TpTransTout;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.DonBase
{

    public class TCt550TpTransToutService : ITCt550TpTransTout
    {
        private readonly HttpClient ohttpClient;
        public TCt550TpTransToutService(HttpClient httpClient)
        {
            this.ohttpClient = httpClient;
        }


        public async Task<List<TCt550TpTransTout>> GetAllTrans()
        {
            try
            {
                var result = await ohttpClient.GetFromJsonAsync<List<TCt550TpTransTout>>("api/TCt550TpTransTout");
                return result ?? new List<TCt550TpTransTout>();
            }
            catch (HttpRequestException ex)
            {
                return new List<TCt550TpTransTout>();
            }
        }

        public Task<List<TCt550TpTransTout>> GetTransById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Resultat> GetUpdateResult(TCt550TpTransTout item)
        {
            Resultat oResult = new Resultat();

            var response = await ohttpClient.PostAsJsonAsync<TCt550TpTransTout>($"api/TCt550TpTransTout/", item);

            if (response.IsSuccessStatusCode)
            {
                oResult = await response.Content.ReadFromJsonAsync<Resultat>();
            }
            return oResult;
        }
    }
}
