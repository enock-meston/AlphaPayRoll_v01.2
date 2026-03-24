using Dapper;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListRetCaisSolidImpl : IListRetCaisSolid
    {
        private readonly string _connectionString;

        public ListRetCaisSolidImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }
        List<ListRetCaisSolid> itemList = new List<ListRetCaisSolid>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListRetCaisSolid>> GetListRetCaisSolid()
        {
            itemList = new List<ListRetCaisSolid>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListRetCaisSolid>(
                        "Ps_ListRetCaisSolid",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListRetCaisSolid: {ex.Message}");
            }

            return itemList;
        }
    }
}
