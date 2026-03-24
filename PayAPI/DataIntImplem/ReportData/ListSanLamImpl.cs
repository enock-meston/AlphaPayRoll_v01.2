using Dapper;
using PayLibrary.General;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListSanLamImpl : IListSanLam
    {
        //
        private readonly string _connectionString;

        public ListSanLamImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }


        List<ListSanLam> itemList = new List<ListSanLam>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListSanLam>> GetListSanLam()
        {
            itemList = new List<ListSanLam>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListSanLam>(
                        "Ps_ListSanLam",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur Ps_ListSanLam: {ex.Message}");
            }

            return itemList;
        }
    }
}
