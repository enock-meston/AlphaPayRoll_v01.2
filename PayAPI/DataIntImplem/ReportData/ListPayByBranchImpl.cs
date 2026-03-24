using Dapper;
using PayLibrary.CongeRequestF;
using PayLibrary.General;
using PayLibrary.PlanningConge;
using PayLibrary.ReportData;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ReportData
{
    public class ListPayByBranchImpl : IListPayByBranch
    {

        private readonly string _connectionString;

        public ListPayByBranchImpl(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApiConnection");
        }


        List<ListPayByBranch> itemList = new List<ListPayByBranch>();

        Resultat oResultat = new Resultat();
        public async Task<List<ListPayByBranch>> GetListPayByBranch(string id)
        {
            itemList = new List<ListPayByBranch>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListPayByBranch>(
                        "Ps_ListPayByBranch",
                        RenseignerPrmByBranch(id),
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                // 👉 Replace with your logger when you have one
                Console.WriteLine($"Erreur GetListPayByBranch: {ex.Message}");
            }

            return itemList;
        }

        private DynamicParameters RenseignerPrmByBranch(string id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@BranchID", id);
            return oParameters;
        }

        public async Task<List<ListPayByBranch>> GetListPayGen()
        {
            itemList = new List<ListPayByBranch>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListPayByBranch>(
                        "Ps_ListPayGen",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                // 👉 Replace with your logger when you have one
                Console.WriteLine($"Erreur Ps_ListPayGen: {ex.Message}");
            }

            return itemList;
        }

        public async Task<List<ListPayByBranch>> GetListPayConsolid()
        {
            itemList = new List<ListPayByBranch>();

            try
            {
                using (IDbConnection oCon = new SqlConnection(_connectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var list = await oCon.QueryAsync<ListPayByBranch>(
                        "Ps_ListPayConsolid",
                        commandType: CommandType.StoredProcedure);

                    if (list != null && list.Any())
                        itemList = list.ToList();
                }
            }
            catch (Exception ex)
            {
                // 👉 Replace with your logger when you have one
                Console.WriteLine($"Erreur Ps_ListPayConsolid: {ex.Message}");
            }

            return itemList;
        }
    }
}
