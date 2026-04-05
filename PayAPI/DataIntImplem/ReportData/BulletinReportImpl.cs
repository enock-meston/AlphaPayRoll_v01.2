using Dapper;
using PayLibrary.General;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class BulletinReportImpl : IBulletinReport
    {
        private readonly string _connectionString;

        public BulletinReportImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }

        Resultat oResultat = new Resultat();

        public async Task<BulletinReport> GetBulletinReport(string Exercice, string Mois, string Matricule)
        {
            BulletinReport item = new BulletinReport();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed)
                        oCon.Open();

                    var result = await oCon.QueryFirstOrDefaultAsync<BulletinReport>(
                        "Ps_BuletinPaie",
                        new { Exercice, Mois, Matricule },
                        commandType: CommandType.StoredProcedure);

                    if (result != null)
                        item = result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_BuletinPaie: {ex.Message}");
            }

            return item;
        }
    }
}