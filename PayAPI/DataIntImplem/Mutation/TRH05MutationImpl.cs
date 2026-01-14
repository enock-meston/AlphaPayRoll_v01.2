using Dapper;
using PayAPI.StringCon;
using PayLibrary.Localisation;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Mutation
{
    public class TRH05MutationImpl : ITRH05Mutation
    {
        List<TRH05Mutation> itemList = new List<TRH05Mutation>();
        Resultat oResultat = new Resultat();

        public async Task<List<TRH05Mutation>> GetList(string id)
        {
            itemList = new List<TRH05Mutation>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var items = await oCon.QueryAsync<TRH05Mutation>("Ps_AffichTRH05Mutation", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);

                if (items != null && items.Count() > 0)
                {
                    itemList = items.ToList();
                }
            }
            return itemList;
        }
        private DynamicParameters RenseignerPrmRech(string matricule)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Matricule", matricule);

            return oParameters;
        }

        public async Task<List<TRH05Mutation>> GetListAll()
        {
            itemList = new List<TRH05Mutation>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TRH05Mutation>("Select * from TRH04FAUTE");
                var List = await oCon.QueryAsync<TRH05Mutation>("Ps_AffichAllTRH05Mutation", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TRH05Mutation item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05Mutation", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TRH05Mutation item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@SBranchFromID", item.SBranchFromID);
            oParameters.Add("@SBranchToID", item.SBranchToID);
            oParameters.Add("@DateMut", item.DateMut);
            oParameters.Add("@RaisonMut", item.RaisonMut);
            oParameters.Add("@FunctionID", item.FunctionID);
            //oParameters.Add("@CreatBy", item.CreatBy);
            //oParameters.Add("@CreatOn", item.CreatOn);
            //oParameters.Add("@LModifBy", item.LModifBy);
            //oParameters.Add("@LModifOn", item.LModifOn);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;
        }





        //------------------------
        public async Task<Resultat> ValiderMutation(ParamValidMutation param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05MutationValidation", this.RenseignerPrmValidMutation(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmValidMutation(ParamValidMutation param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }
    }
}
