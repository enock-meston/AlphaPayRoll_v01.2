using PayLibrary.CongConsult;
using PayLibrary.CongeRequestF;

namespace AlphaPayRoll.DataServices.CongConsult
{
    public class CongConsultStatusService : ICongConsultStatus
    {
        private readonly HttpClient ohttpClient;
        public CongConsultStatusService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<CongConsultStatus>> GetAllCongeConsultStatus(string id)
        {
            return (await ohttpClient.GetFromJsonAsync<CongConsultStatus[]>("api/CongConsultStatus/" + id)).ToList();

        }
    }
}
