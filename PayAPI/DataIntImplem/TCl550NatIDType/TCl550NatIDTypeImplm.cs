using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550NatIDType;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550NatIDType
{
    public class TCl550NatIDTypeImplm : ITCl550NatIDType
    {
        List<ClassTCl550NatIDType> oItemList = new List<ClassTCl550NatIDType>();


        public async Task<List<ClassTCl550NatIDType>> GetIdType()
        {

            oItemList = new List<ClassTCl550NatIDType>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550NatIDType>("Select * from TCl550NatIDType");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
