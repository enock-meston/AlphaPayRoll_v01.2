
using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Permission;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.DataIntImplem.HumanResource
{
    public class TRH05PermissionImpl : ITRH05Permission
    {
        List<TRH05Permission> itemList = new List<TRH05Permission>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH05Permission>> GetList(string id)
        {
            itemList = new List<TRH05Permission>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                // var items = await oCon.QueryAsync<TransJour>("Select * from TCt041TransJour");
                //var items = await oCon.QueryAsync<TRH05Permission>("Ps_AffichTRH05Permission", this.RenseignerPrm(id), commandType: CommandType.StoredProcedure);
                var items = await oCon.QueryAsync<TRH05Permission>("Ps_AffichTRH05Permission", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);

                if (items != null && items.Count() > 0)
                {
                    itemList = items.ToList();
                }
            }
            return itemList;
        }


        //private DynamicParameters RenseignerPrm(int id)
        //{
        //    DynamicParameters oParameters = new DynamicParameters();

        //    oParameters.Add("@ID", id);

        //    return oParameters;
        //}

        private DynamicParameters RenseignerPrmRech(string matricule)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Matricule", matricule);
            return parameters;
        }


        public async Task<List<TRH05Permission>> GetListAll()
        {
            itemList = new List<TRH05Permission>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TClA04AccountBloc>("Select * from TClA04AccountBloc");
                var List = await oCon.QueryAsync<TRH05Permission>("Ps_AffichAll_TRH05Permission", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TRH05Permission item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05Permission", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }
        private DynamicParameters RenseignerPrmUpdate(TRH05Permission item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);

            oParameters.Add("@Matricule", item.Matricule);
            //oParameters.Add("@TpCongeID", item.TpCongeID);
            oParameters.Add("@SBranchID", item.SBranchID);
            oParameters.Add("@Date", item.Date);
            oParameters.Add("@NbrHDemand", item.NbrHDemand);
            oParameters.Add("@NbrHAccord", item.NbrHAccord);
            oParameters.Add("@TAutorisationDeSortie", item.TAutorisationDeSortie);
            oParameters.Add("@MotifDemand", item.MotifDemand);
            oParameters.Add("@Decision", item.Decision);
            oParameters.Add("@DecisionPrisePar", item.DecisionPrisePar);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
