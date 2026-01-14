using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550User;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TCl550User
{
    public class TCl550UserImpl : ITCl550User
    {
        List<ClassTCl550User> oItemList = new List<ClassTCl550User>();


        public async Task<List<ClassTCl550User>> GetTCl550User()
        {

            oItemList = new List<ClassTCl550User>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550User>("Select * from TSc551User");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }

            return oItemList;
        }
    }
}
