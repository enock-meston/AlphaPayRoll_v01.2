using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Training;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaBkBlzr.API.DataIntImplem.HumanResource
{
    public class TRH03TrainingImpl : ITRH03Training
    {
        List<TRH03Training> itemList = new List<TRH03Training>();
        Resultat oResultat = new Resultat();
        public async Task<List<TRH03Training>> GetList(string id)
        {
            itemList = new List<TRH03Training>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                // var items = await oCon.QueryAsync<TransJour>("Select * from TCt041TransJour");
                //var items = await oCon.QueryAsync<TRH03Training>("Ps_Affich_TRH03Training", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);
                var items = await oCon.QueryAsync<TRH03Training>("Ps_Affich_TRH03Training", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);

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

        public async Task<List<TRH03Training>> GetListAll()
        {
            itemList = new List<TRH03Training>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TClA04AccountBloc>("Select * from TClA04AccountBloc");
                var List = await oCon.QueryAsync<TRH03Training>("Ps_AffichAllTRH03Training", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }



        public async Task<Resultat> GetUpdateResult(TRH03Training item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH03Training", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TRH03Training item)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);

            oParameters.Add("Matricule", item.Matricule);
            oParameters.Add("FieldID", item.FieldID);
            oParameters.Add("Descript", item.Descript);
            oParameters.Add("Pays", item.Pays);
            oParameters.Add("Ville", item.Ville);
            oParameters.Add("OrganisePar", item.OrganisePar);
            oParameters.Add("Observation", item.Observation);
            oParameters.Add("StartDate", item.StartDate);
            oParameters.Add("EndDate", item.EndDate);
            oParameters.Add("CreatBy", item.CreatBy);
            oParameters.Add("CreatOn", item.CreatOn);
            oParameters.Add("LModifBy", item.LModifBy);
            oParameters.Add("LModifOn", item.LModifOn);

            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
