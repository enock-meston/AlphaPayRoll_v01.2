using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListEjohezaService : IListEjoheza
    {
        private readonly HttpClient ohttpClient;
        public ListEjohezaService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListEjoheza>> GetListEjohezas()
        {
            return (await ohttpClient.GetFromJsonAsync<ListEjoheza[]>("api/ListEjoheza")).ToList();
        }
    }
}
