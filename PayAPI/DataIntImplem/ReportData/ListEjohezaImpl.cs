using Dapper;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListEjohezaImpl : IListEjoheza
    {
        private readonly string _connectionString;

        public ListEjohezaImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }


        List<ListEjoheza> itemList = new List<ListEjoheza>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListEjoheza>> GetListEjohezas()
        {
            itemList = new List<ListEjoheza>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListEjoheza>(
                        "Ps_ListEjoheza",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListEjoheza: {ex.Message}");
            }

            return itemList;
        }
    }
}
