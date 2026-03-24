using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListRetCaisSolidService : IListRetCaisSolid
    {
        private readonly HttpClient ohttpClient;
        public ListRetCaisSolidService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListRetCaisSolid>> GetListRetCaisSolid()
        {
            return (await ohttpClient.GetFromJsonAsync<ListRetCaisSolid[]>("api/ListRetCaisSolid")).ToList();
        }
    }
}
