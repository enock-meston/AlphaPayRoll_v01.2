using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550Status;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550Status
{
    public class TCl550StatusImpl : ITCl550Status
    {

        List<ClassTCl550Status> oItemList = new List<ClassTCl550Status>();


        public async Task<List<ClassTCl550Status>> GetTCl550Status()
        {

            oItemList = new List<ClassTCl550Status>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550Status>("Select * from TCl550Status");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
