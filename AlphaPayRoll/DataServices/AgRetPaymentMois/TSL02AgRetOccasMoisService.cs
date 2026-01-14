using Microsoft.AspNetCore.Components;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.AgRetPaymentMois
{
    public class TSL02AgRetOccasMoisService : ITSL02AgRetOccasMois
    {

        private readonly HttpClient ohttpClient;
        public TSL02AgRetOccasMoisService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMois()
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRetOccasMois/")).ToList();
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMoisByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<AgDonIntialMois[]>($"api/TSL02AgRetOccasMois/{id}")).ToList();
        }

        public Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMoisByType(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Resultat> GetUpdateRetOccasMoisResult(AgDonIntialMois item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgRetOccasMois/", item);
        }
    }
}
