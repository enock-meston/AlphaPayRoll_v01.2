using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListSanLamService : IListSanLam
    {

        private readonly HttpClient ohttpClient;
        public ListSanLamService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }

        public async Task<List<ListSanLam>> GetListSanLam()
        {
            return (await ohttpClient.GetFromJsonAsync<ListSanLam[]>("api/ListSanLam")).ToList();
        }
    }
}
