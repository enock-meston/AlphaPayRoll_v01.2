using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550Departement;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550Departement
{
    public class TCl550DepartementImpl : ITCl550Departement
    {
        List<ClassTCl550Departement> oItemList = new List<ClassTCl550Departement>();


        public async Task<List<ClassTCl550Departement>> GetTCl550Departement()
        {

            oItemList = new List<ClassTCl550Departement>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550Departement>("Select * from TCl550Departement");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }
    }
}
