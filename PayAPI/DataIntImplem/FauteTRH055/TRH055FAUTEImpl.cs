
using Dapper;
using PayAPI.StringCon;
using PayLibrary.FauteTRH055;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace PayAPI.DataIntImplem.FauteTRH055
{
    public class TRH055FAUTEImpl : ITRH055FAUTE
    {
        List<TRH055FAUTE> itemList = new List<TRH055FAUTE>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH055FAUTE>> GetListAll()
        {
            itemList = new List<TRH055FAUTE>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TRH055FAUTE>("Select * from TRH055FAUTE");
                var List = await oCon.QueryAsync<TRH055FAUTE>("Ps_AffichAllTRH055FAUTE", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        //public async Task<List<TRH055FAUTE>> GetListByRICode()
        //{
        //    itemList = new List<TRH055FAUTE>();

        //    using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //    {
        //        if (oCon.State == ConnectionState.Closed) oCon.Open();
        //        //var List = await oCon.QueryAsync<TRH055FAUTE>("Select * from TRH055FAUTE");
        //        var List = await oCon.QueryAsync<TRH055FAUTE>("Ps_AffichTRH055FAUTE", commandType: CommandType.StoredProcedure);

        //        if (List != null && List.Count() > 0)
        //        {
        //            itemList = List.ToList();
        //        }
        //    }
        //    return itemList;
        //}
    }
}
