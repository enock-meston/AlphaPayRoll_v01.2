using Microsoft.AspNetCore.Components;
using PayLibrary.Gravite;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH042GraviteService : ITRH042Gravite
    {
        private readonly HttpClient ohttpClient;

        public TRH042GraviteService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH042Gravite>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH042Gravite[]>($"api/TRH042Gravit/")).ToList();
        }
    }
}
