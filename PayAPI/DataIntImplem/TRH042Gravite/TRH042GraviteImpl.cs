
using Dapper;
using PayAPI.StringCon;
using PayLibrary.Gravite;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.DataIntImplem.HumanResource
{
    public class TRH042GraviteImpl : ITRH042Gravite
    {
        List<TRH042Gravite> itemList = new List<TRH042Gravite>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH042Gravite>> GetListAll()
        {
            itemList = new List<TRH042Gravite>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TClA04AccountBloc>("Select * from TClA04AccountBloc");
                var List = await oCon.QueryAsync<TRH042Gravite>("Ps_AffichAllTRH042Gravite", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }
    }
}
