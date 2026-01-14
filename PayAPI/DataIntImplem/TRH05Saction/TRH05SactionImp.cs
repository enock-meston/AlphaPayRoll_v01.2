
using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Saction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.DataIntImplem.HumanResource
{
    public class TRH05SactionImp : ITRH05Saction
    {
        List<TRH05Saction> itemList = new List<TRH05Saction>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH05Saction>> GetList(string id)
        {
            itemList = new List<TRH05Saction>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                // var items = await oCon.QueryAsync<TransJour>("Select * from TCt041TransJour");
                var items = await oCon.QueryAsync<TRH05Saction>("Ps_Affich_TRH05Saction", this.RenseignerPrm(id), commandType: CommandType.StoredProcedure);

                if (items != null && items.Count() > 0)
                {
                    itemList = items.ToList();
                }
            }
            return itemList;
        }
        private DynamicParameters RenseignerPrm(string id)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Matricule", id);

            return oParameters;
        }
        public async Task<List<TRH05Saction>> GetListAll()
        {
            itemList = new List<TRH05Saction>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TClA04AccountBloc>("Select * from TClA04AccountBloc");
                var List = await oCon.QueryAsync<TRH05Saction>("Ps_AffichAllTRH05Saction", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TRH05Saction item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05Saction", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TRH05Saction item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);

            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@HisHerFautes", item.HisHerFautes);
            oParameters.Add("@FauteID", item.FauteID);
            oParameters.Add("@TpSanctPrevID", item.TpSanctPrevID);
            oParameters.Add("@TpSanctRecID", item.TpSanctRecID);
            oParameters.Add("@Raisons", item.Raisons);
            oParameters.Add("@DecidPar", item.DecidPar);
            oParameters.Add("@DateDebut", item.DateDebut);
            oParameters.Add("@DateFin", item.DateFin);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);


            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
