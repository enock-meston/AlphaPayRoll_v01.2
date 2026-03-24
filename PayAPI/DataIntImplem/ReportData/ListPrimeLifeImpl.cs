using Dapper;
using PayLibrary.General;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListPrimeLifeImpl : IListPrimeLife
    {
        private readonly string _connectionString;

        public ListPrimeLifeImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }
        List<ListPrimeLife> itemList = new List<ListPrimeLife>();

        Resultat oResultat = new Resultat();

        public async Task<List<ListPrimeLife>> GetListPrimeLife()
        {
            itemList = new List<ListPrimeLife>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListPrimeLife>(
                        "Ps_ListPrimeLife",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListPrimeLife: {ex.Message}");
            }

            return itemList;
        }
    }
}
