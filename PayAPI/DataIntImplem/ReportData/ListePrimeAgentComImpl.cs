using Dapper;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListePrimeAgentComImpl : IListePrimeAgentCom
    {
        private readonly string _connectionString;

        public ListePrimeAgentComImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }
        List<ListePrimeAgentCom> itemList = new List<ListePrimeAgentCom>();

        Resultat oResultat = new Resultat();

        public async Task<List<ListePrimeAgentCom>> GetListePrimeAgentCom()
        {
            itemList = new List<ListePrimeAgentCom>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListePrimeAgentCom>(
                        "Ps_ListePrimeAgentCom",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListePrimeAgentCom: {ex.Message}");
            }

            return itemList;
        }
    }
}
