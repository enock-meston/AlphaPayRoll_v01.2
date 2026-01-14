using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.RubSalCompte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.RubSalCompte
{
    public class TSl550RubSalCompteImpl : ITSl550RubSalCompte
    {
        List<TSl550RubSalCompte> itemList = new List<TSl550RubSalCompte>();
        Resultat oResultat = new Resultat();


        public async Task<List<TSl550RubSalCompte>> GetList()
        {
            itemList = new List<TSl550RubSalCompte>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSl550RubSalCompte>("Select * from TSl550RubSalCompte");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }


        public async Task<Resultat> GetUpdateResult(TSl550RubSalCompte item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSl550RubSalCompte", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TSl550RubSalCompte item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RICODE", item.RICODE);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Compte", item.Compte);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }
    }
}
