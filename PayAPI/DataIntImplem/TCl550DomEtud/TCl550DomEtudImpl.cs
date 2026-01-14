using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550DomEtud;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550DomEtud
{
    public class TCl550DomEtudImpl : ITCl550DomEtud
    {
        List<ClassTCl550DomEtud> oItemList = new List<ClassTCl550DomEtud>();


        public async Task<List<ClassTCl550DomEtud>> GetTCl550DomEtud()
        {

            oItemList = new List<ClassTCl550DomEtud>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550DomEtud>("Select * from TCl550DomEtud");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
