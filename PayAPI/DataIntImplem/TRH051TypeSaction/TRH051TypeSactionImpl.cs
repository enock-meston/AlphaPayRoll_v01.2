
using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TypeSaction;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.DataIntImplem.HumanResource
{
    public class TRH051TypeSactionImpl : ITRH051TypeSaction
    {
        List<TRH051TypeSaction> itemList = new List<TRH051TypeSaction>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH051TypeSaction>> GetListAll()
        {
            itemList = new List<TRH051TypeSaction>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TClA04AccountBloc>("Select * from TClA04AccountBloc");
                var List = await oCon.QueryAsync<TRH051TypeSaction>("Ps_AffichAllTRH051TypeSaction", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }
    }
}
