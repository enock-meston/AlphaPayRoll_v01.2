using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListePrimeAgentComService : IListePrimeAgentCom
    {
        private readonly HttpClient ohttpClient;
        public ListePrimeAgentComService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListePrimeAgentCom>> GetListePrimeAgentCom()
        {
            return (await ohttpClient.GetFromJsonAsync<ListePrimeAgentCom[]>("api/ListePrimeAgentCom")).ToList();

        }
    }
}
