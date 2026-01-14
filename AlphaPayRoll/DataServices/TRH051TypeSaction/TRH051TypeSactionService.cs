using Microsoft.AspNetCore.Components;
using PayLibrary.TypeSaction;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH051TypeSactionService : ITRH051TypeSaction
    {
        private readonly HttpClient ohttpClient;

        public TRH051TypeSactionService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH051TypeSaction>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH051TypeSaction[]>($"api/TRH051TypeSaction/")).ToList();
        }
    }
}
