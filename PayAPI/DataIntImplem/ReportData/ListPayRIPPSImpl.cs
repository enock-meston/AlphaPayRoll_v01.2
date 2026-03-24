using Dapper;
using PayLibrary.General;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{

    public class ListPayRIPPSImpl : IListPayRIPPS
    {
        private readonly string _connectionString;

        public ListPayRIPPSImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }
        List<ListPayRIPPS> itemList = new List<ListPayRIPPS>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListPayRIPPS>> GetListPayRIPPS()
        {
            itemList = new List<ListPayRIPPS>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListPayRIPPS>(
                        "Ps_ListPayRIPPS",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListPayRIPPS: {ex.Message}");
            }

            return itemList;
        }

    }
}
