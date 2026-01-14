using Dapper;
using PayAPI.StringCon;
using PayLibrary.General;
using PayLibrary.GetUserCounts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.GetUserCounts
{
    public class ClassGetUserCountsImpl : IClassGetAgentCounts
    {
        List<ClassGetAgentCounts> itemList = new List<ClassGetAgentCounts>();
        Resultat oResultat = new Resultat();
        public async Task<List<ClassGetAgentCounts>> GetAgentCountsAsync(string matricule)
        {
            itemList = new List<ClassGetAgentCounts>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();

                var results = await oCon.QueryAsync<ClassGetAgentCounts>(
                    "Ps_GetAgentCounts",
                    new { Matricule = matricule },
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
