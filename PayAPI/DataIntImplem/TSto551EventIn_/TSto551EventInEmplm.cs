using Dapper;
using PayAPI.StringCon;
using PayLibrary.TSto551EventIn;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem
{
    public class TSto551EventInEmplm
    {

        List<ClassTSto551EventIn> oItemList = new List<ClassTSto551EventIn>();

        public async Task<List<ClassTSto551EventIn>> GetTSto551EventIn()
        {
            oItemList = new List<ClassTSto551EventIn>();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSto551EventIn>("Select * from TSto551EventIn");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }

    }
}
