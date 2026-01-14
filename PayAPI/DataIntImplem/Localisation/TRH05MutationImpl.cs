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

namespace PayAPI.DataIntImplem.Localisation
{
    public class TRH05LocalisationImpl : ITRH05Localisation
    {
        List<TRH05Localisation> itemList = new List<TRH05Localisation>();
        Resultat oResultat = new Resultat();

        public async Task<List<TRH05Localisation>> GetList(string id)
        {
            itemList = new List<TRH05Localisation>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var items = await oCon.QueryAsync<TRH05Localisation>("Ps_AffichTRH05Localisation", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);

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

        public async Task<List<TRH05Localisation>> GetListAll()
        {
            itemList = new List<TRH05Localisation>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var List = await oCon.QueryAsync<TRH05Localisation>("Select * from TRH04FAUTE");
                var List = await oCon.QueryAsync<TRH05Localisation>("Ps_AffichAllTRH05Localisation", commandType: CommandType.StoredProcedure);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TRH05Localisation item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05Localisation", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(TRH05Localisation item)
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
        public async Task<Resultat> ValiderLocalisation(ParamValidLocalisation param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH05LocalisationValidation", this.RenseignerPrmValidLocalisation(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmValidLocalisation(ParamValidLocalisation param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }
    }
}
