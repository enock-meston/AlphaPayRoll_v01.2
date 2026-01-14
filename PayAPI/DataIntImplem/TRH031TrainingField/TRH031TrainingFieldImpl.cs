

using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TrainingField;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.DataIntImplem.HumanResource
{
    public class TRH031TrainingFieldImpl : ITRH031TrainingField
    {
        List<TRH031TrainingField> itemList = new List<TRH031TrainingField>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH031TrainingField>> GetListAll()
        {
            itemList = new List<TRH031TrainingField>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TClA04AccountBloc>("Select * from TClA04AccountBloc");
                var List = await oCon.QueryAsync<TRH031TrainingField>("Ps_AffichAllTRH031TrainingField", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }
    }
}
