using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.RIPPSToBNR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.RIPPSToBNR
{
    public class TCpt08RIPPSToBNRImpl : ITCpt08RIPPSToBNR
    {

        List<TCpt08RIPPSToBNR> itemList = new List<TCpt08RIPPSToBNR>();
        Resultat oResultat = new Resultat();
        public async Task<Resultat> GetResutUpdate(TCpt08RIPPSToBNR item)
        {

            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TCpt08RIPPSToBNR", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);
                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        public async Task<List<TCpt08RIPPSToBNR>> GetRIPPSToBNR()
        {

            itemList = new List<TCpt08RIPPSToBNR>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TCpt08RIPPSToBNR>("Select * from TCpt08RIPPSToBNR");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }


        private DynamicParameters RenseignerPrmUpdate(TCpt08RIPPSToBNR item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@SBranchID", item.SBranchID);
            oParameters.Add("@ClientID", item.ClientID);
            oParameters.Add("@NumCheq", item.NumCheq);
            oParameters.Add("@BankID", item.BankID);
            oParameters.Add("@BenefAcct", item.BenefAcct);
            oParameters.Add("@BenefName", item.BenefName);
            oParameters.Add("@Montant", item.Montant);
            oParameters.Add("@DateOp", item.DateOp);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }

    }
}
