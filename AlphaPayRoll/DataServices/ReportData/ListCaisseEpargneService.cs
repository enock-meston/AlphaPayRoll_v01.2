using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListCaisseEpargneService : IListCaisseEpargne
    {
        private readonly HttpClient ohttpClient;
        public ListCaisseEpargneService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }

        public async Task<List<ListCaisseEpargne>> GetListCaisseEpargne()
        {
            return (await ohttpClient.GetFromJsonAsync<ListCaisseEpargne[]>("api/ListCaisseEpargne")).ToList();
        }
    }
}
