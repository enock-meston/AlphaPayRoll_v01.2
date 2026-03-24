using Microsoft.AspNetCore.Components;
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
        public async Task<List<CongConsultStatus>> GetAllCongeConsultStatus(ParamConsultConge param)
        {
            //return (await ohttpClient.PostJsonAsync<CongConsultStatus[]>("api/CongConsultStatus/")).ToList();
            return (await ohttpClient.PostJsonAsync<CongConsultStatus[]>($"api/CongConsultStatus/", param)).ToList();
        }
    }
}
