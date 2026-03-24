using PayLibrary.CongeRequestF;
using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class ListPayByBranchService : IListPayByBranch
    {
        private readonly HttpClient ohttpClient;
        public ListPayByBranchService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<ListPayByBranch>> GetListPayByBranch(string id)
        {

            return (await ohttpClient.GetFromJsonAsync<ListPayByBranch[]>($"api/ListPayByBranch/{id}")).ToList();

        }

        public async Task<List<ListPayByBranch>> GetListPayConsolid()
        {
            return (await ohttpClient.GetFromJsonAsync<ListPayByBranch[]>("api/ListPayByBranch/consolid")).ToList();
        }

        public async Task<List<ListPayByBranch>> GetListPayGen()
        {
            return (await ohttpClient.GetFromJsonAsync<ListPayByBranch[]>($"api/ListPayByBranch")).ToList();

        }
    }
}
