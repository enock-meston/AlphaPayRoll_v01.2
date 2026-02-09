using Dapper;
using PayAPI.StringCon;
using PayLibrary.Cl550Branch;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ParamDonBase.TSc551BranchAndSubBranch
{
    public class TSc551BranchDirImpl : ITSc551BranchDir
    {
        List<TSc551BranchDir> oItemList = new List<TSc551BranchDir>();
        public async Task<List<TSc551BranchDir>> GetList()
        {
            oItemList = new List<TSc551BranchDir>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSc551BranchDir>("Select * from TSc551BranchDir");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
