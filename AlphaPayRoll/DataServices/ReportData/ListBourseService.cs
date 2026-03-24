using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListBourseService : IListBourse
    {
        private readonly HttpClient ohttpClient;
        public ListBourseService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListBourse>> GetListBourse()
        {
            return (await ohttpClient.GetFromJsonAsync<ListBourse[]>("api/ListBourse")).ToList();
           
        }
    }
}
