using Dapper;
using PayAPI.StringCon;
using PayLibrary.TRH550TypeSalaire;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TypeSalaire
{
    public class TRH550TypeSalaireImpl : ITRH550TypeSalaire
    {
        List<TRH550TypeSalaire> oItemList = new List<TRH550TypeSalaire>();
        public async Task<List<TRH550TypeSalaire>> GetAllTypeSalaire()
        {
            oItemList = new List<TRH550TypeSalaire>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TRH550TypeSalaire>("Select * from TRH550TypeSalaire");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
