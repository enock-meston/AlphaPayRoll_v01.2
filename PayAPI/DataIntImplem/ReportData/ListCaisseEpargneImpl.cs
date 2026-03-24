using Dapper;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListCaisseEpargneImpl : IListCaisseEpargne
    {
        private readonly string _connectionString;

        public ListCaisseEpargneImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }
        List<ListCaisseEpargne> itemList = new List<ListCaisseEpargne>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListCaisseEpargne>> GetListCaisseEpargne()
        {
            itemList = new List<ListCaisseEpargne>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListCaisseEpargne>(
                        "Ps_ListCaisseEpargne",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListCaisseEpargne: {ex.Message}");
            }

            return itemList;
        }
    }
}
