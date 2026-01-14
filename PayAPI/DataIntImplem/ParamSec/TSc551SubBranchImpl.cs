using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamDonBase;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ParamSec
{
    public class TSc551SubBranchImpl : ITSc551SubBranch
    {
        public List<TSc551SubBranch> oSubBranch = new List<TSc551SubBranch>();
        public async Task<List<TSc551SubBranch>> GetList()
        {
            oSubBranch = new List<TSc551SubBranch>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTSc551SubMenuList = await oCon.QueryAsync<TSc551SubBranch>("Select * from TSc551SubBranch", commandType: CommandType.Text);

                if (vTSc551SubMenuList != null && vTSc551SubMenuList.Count() > 0)
                {
                    oSubBranch = vTSc551SubMenuList.ToList();
                }
            }

            return oSubBranch;
        }
    }
}
