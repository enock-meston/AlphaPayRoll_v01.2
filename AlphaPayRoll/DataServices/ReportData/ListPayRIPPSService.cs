using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListPayRIPPSService : IListPayRIPPS
    {
        private readonly HttpClient ohttpClient;
        public ListPayRIPPSService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListPayRIPPS>> GetListPayRIPPS()
        {
            return (await ohttpClient.GetFromJsonAsync<ListPayRIPPS[]>("api/ListPayRIPPS")).ToList();

        }

    }
}
