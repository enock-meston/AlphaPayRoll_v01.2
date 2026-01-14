using Dapper;
using PayAPI.StringCon;
using PayLibrary.Exercice;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Exercice
{
    public class ExerciceImpl : ITSL550Exercice
    {
        List<TSL550Exercice> itemList = new List<TSL550Exercice>();
        Resultat oResultat = new Resultat();

        public async Task<List<TSL550Exercice>> GetExerciceAll()
        {
            itemList = new List<TSL550Exercice>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSL550Exercice>("Select * from TSL550Exercice");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }



    }
}
