using Dapper;
using PayAPI.StringCon;
using PayLibrary.General;
using PayLibrary.GetHRCounts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.GetHRCounts
{
    public class ClassGetHRCountsImpl : IClassGetHRCounts
    {
        List<ClassGetHRCounts> itemList = new List<ClassGetHRCounts>();
        Resultat oResultat = new Resultat();
        public async Task<List<ClassGetHRCounts>> GetHRCountsAsync()
        {
            itemList = new List<ClassGetHRCounts>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();

                var results = await oCon.QueryAsync<ClassGetHRCounts>(
                    "Ps_GetHRCounts",
                    commandType: CommandType.StoredProcedure
                );

                if (results != null && results.Any())
                {
                    itemList = results.ToList();
                }
            }

            return itemList;
        }

    }

}
