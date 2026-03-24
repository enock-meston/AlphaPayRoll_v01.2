using Dapper;
using PayLibrary.General;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListBourseImpl : IListBourse
    {
        private readonly string _connectionString;

        public ListBourseImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }
        List<ListBourse> itemList = new List<ListBourse>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListBourse>> GetListBourse()
        {
            itemList = new List<ListBourse>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListBourse>(
                        "Ps_ListBourse",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListBourse: {ex.Message}");
            }

            return itemList;
        }
    
    }
}
