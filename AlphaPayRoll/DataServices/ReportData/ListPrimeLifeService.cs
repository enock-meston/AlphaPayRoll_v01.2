using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListPrimeLifeService : IListPrimeLife
    {
        private readonly HttpClient ohttpClient;
        public ListPrimeLifeService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListPrimeLife>> GetListPrimeLife()
        {
            return (await ohttpClient.GetFromJsonAsync<ListPrimeLife[]>("api/ListPrimeLife")).ToList();
        }
    }
}
