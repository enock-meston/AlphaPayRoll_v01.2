using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ParamSec
{
    public class TSc552TpTransAllawedImpl : ITSc552TpTransAllawed
    {
        List<TSc552TpTransAllawed> itemList = new List<TSc552TpTransAllawed>();
        Resultat oResultat = new Resultat();


        public async Task<List<TSc552TpTransAllawed>> GetList(int id)
        {
            itemList = new List<TSc552TpTransAllawed>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSc552TpTransAllawed>("Select * from TSc552TpTransAllawed");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TSc552TpTransAllawed item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc552TpTransAllawed", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TSc552TpTransAllawed item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RoleID", item.RoleID);
            oParameters.Add("@TpTransID", item.TpTransID);
            oParameters.Add("@AccesAllowed", item.AccesAllowed);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}
