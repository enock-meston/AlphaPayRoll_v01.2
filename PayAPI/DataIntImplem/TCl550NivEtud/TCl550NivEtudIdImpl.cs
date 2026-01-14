using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550NivEtudId;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550NivEtud
{
    public class TCl550NivEtudIdImpl : ITCl550NivEtudId
    {

        List<ClassTCl550NivEtudId> oItemList = new List<ClassTCl550NivEtudId>();


        public async Task<List<ClassTCl550NivEtudId>> GetTCl550NivEtudId()
        {

            oItemList = new List<ClassTCl550NivEtudId>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550NivEtudId>("Select * from TCl550NivEtudId");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }

    }
}
