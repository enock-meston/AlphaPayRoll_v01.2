using Dapper;
using PayAPI.StringCon;
using PayLibrary.Cl550Branch;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550Branch
{
    public class TCl550BranchImpl : ITCl550Branch
    {

        List<ClassTCl550Branch> oItemList = new List<ClassTCl550Branch>();


        public async Task<List<ClassTCl550Branch>> GetT550Branch()
        {

            oItemList = new List<ClassTCl550Branch>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550Branch>("Select * from TCl550Branch");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
