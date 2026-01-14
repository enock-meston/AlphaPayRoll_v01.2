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
    public class TSc551UserImpl : ITSc551User
    {
        List<TSc551User> itemList = new List<TSc551User>();
        Resultat oResultat = new Resultat();


        public async Task<List<TSc551User>> GetList()
        {
            itemList = new List<TSc551User>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSc551User>("Select * from TSc551User");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TSc551User item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc551User", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);
                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TSc551User item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@UserName", item.UserName);
            oParameters.Add("@Names", item.Names);
            oParameters.Add("@Deleted", item.Deleted);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@Connected", item.Connected);
            oParameters.Add("@PssWord", item.PssWord);
            oParameters.Add("@DatPswModif", item.DatPswModif);
            oParameters.Add("@DatPswExpD", item.DatPswExpD);
            oParameters.Add("@MaxWdraw", item.MaxWdraw);
            oParameters.Add("@MaxApprov", item.MaxApprov);
            oParameters.Add("@Phone", item.Phone);
            oParameters.Add("@UserExpD", item.UserExpD);
            oParameters.Add("@ProfStartD", item.ProfStartD);
            oParameters.Add("@ProfExpD", item.ProfExpD);
            oParameters.Add("@CanConFrom", item.CanConFrom);
            oParameters.Add("@CanConTo", item.CanConTo);
            oParameters.Add("@ClientID", item.ClientID);
            oParameters.Add("@RoleID", item.RoleID);
            oParameters.Add("@BranchID", item.BranchID);
            oParameters.Add("@DepatmentID", item.DepatmentID);
            oParameters.Add("@CashAcctID", item.CashAcctID);
            oParameters.Add("@ChefID", item.ChefID);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}
