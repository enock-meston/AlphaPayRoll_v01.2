using Dapper;
using PayAPI.StringCon;
using PayLibrary.Cl550Branch;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.ParamDonBase.TSc551BranchAndSubBranch
{
    public class TSc551SubBranchDirImpl : ITSc551SubBranchDir
    {
        List<TSc551SubBranchDir> oItemList = new List<TSc551SubBranchDir>();
        public async Task<List<TSc551SubBranchDir>> GetList()
        {
            oItemList = new List<TSc551SubBranchDir>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSc551SubBranchDir>("Select * from TSc551SubBranchDir");

                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
