using Microsoft.AspNetCore.Components;
using PayLibrary.FauteTRH055;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TRH055FAUTE
{
    public class TRH055FAUTEService : ITRH055FAUTE
    {

        private readonly HttpClient ohttpClient;

        public TRH055FAUTEService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<PayLibrary.FauteTRH055.TRH055FAUTE>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<PayLibrary.FauteTRH055.TRH055FAUTE[]>($"api/TRH055FAUTE")).ToList();
        }
    }
}
