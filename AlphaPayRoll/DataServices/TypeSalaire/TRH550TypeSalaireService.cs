using Microsoft.AspNetCore.Components;
using PayLibrary.Cl550Branch;
using PayLibrary.TRH550TypeSalaire;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TypeSalaire
{
    public class TRH550TypeSalaireService : ITRH550TypeSalaire
    {

        private readonly HttpClient oHttpClient;

        public TRH550TypeSalaireService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<TRH550TypeSalaire>> GetAllTypeSalaire()
        {
            return (await oHttpClient.GetJsonAsync<TRH550TypeSalaire[]>($"api/TRH550TypeSalaire/")).ToList();
        }

    }
}
