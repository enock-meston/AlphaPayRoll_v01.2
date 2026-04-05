using PayLibrary.ReportData;

namespace AlphaPayRoll.DataServices.ReportData
{
    public class BulletinReportService : IBulletinReport
    {
        private readonly HttpClient ohttpClient;
        public BulletinReportService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<BulletinReport> GetBulletinReport(string Exercice, string Mois, string Matricule)
        {
            var url = $"api/BulletinReport/GetBulletinReport?Exercice={Exercice}&Mois={Mois}&Matricule={Matricule}";

            return await ohttpClient.GetFromJsonAsync<BulletinReport>(url);
        }
    }
}
