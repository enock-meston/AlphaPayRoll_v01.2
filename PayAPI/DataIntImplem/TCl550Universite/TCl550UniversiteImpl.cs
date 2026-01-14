using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550Universite;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550Universite
{
    public class TCl550UniversiteImpl : ITCl550Universite
    {
        List<ClassTCl550Universite> oItemList = new List<ClassTCl550Universite>();


        public async Task<List<ClassTCl550Universite>> GetTCl550Universite()
        {

            oItemList = new List<ClassTCl550Universite>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550Universite>("Select * from TCl550Universite");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
