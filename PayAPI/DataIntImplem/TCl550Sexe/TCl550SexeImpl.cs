using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550Sexe;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550Sexe
{
    public class TCl550SexeImpl : ITCl550Sexe
    {
        List<ClassTCl550Sexe> oItemList = new List<ClassTCl550Sexe>();

        public async Task<List<ClassTCl550Sexe>> GetTCl550Sexe()
        {
            oItemList = new List<ClassTCl550Sexe>();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550Sexe>("Select * from TCl550Sexe");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
