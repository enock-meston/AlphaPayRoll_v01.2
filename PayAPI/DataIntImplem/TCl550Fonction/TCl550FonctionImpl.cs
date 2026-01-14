using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550Fonction;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550Fonction
{
    public class TCl550FonctionImpl : ITCl550Fonction
    {
        List<ClassTCl550Fonction> oItemList = new List<ClassTCl550Fonction>();


        public async Task<List<ClassTCl550Fonction>> GetTCl550Fonction()
        {

            oItemList = new List<ClassTCl550Fonction>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550Fonction>("Select * from TCl550Fonction");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }

    }
}
