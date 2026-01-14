using Dapper;
using PayAPI.StringCon;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.Contrat
{
    public class ContratImpl : IClasContrat
    {
        List<ClasContrat> oItemList = new List<ClasContrat>();
        List<TRH04Affectation> oItemAffectList = new List<TRH04Affectation>();

        Resultat oResultat = new Resultat();

        public async Task<List<ClasContrat>> GetContractByMatricule(string id)
        {
            oItemList = new List<ClasContrat>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClasContrat>("Select * from TRH03Contrat where Matricule='" + id + "'");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }

        private DynamicParameters RenseignerPrmRech(string id)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", id);

            return oParameters;
        }

        public async Task<Resultat> GetResutUpdate(ClasContrat item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH03Contrat", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrmUpdate(ClasContrat item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@NumContrat", item.NumContrat);
            oParameters.Add("@MATRICULE", item.MATRICULE);
            oParameters.Add("@Categorie", item.Categorie);
            oParameters.Add("@ContraPeriod", item.ContraPeriod);
            oParameters.Add("@DateDebut", item.DateDebut);
            oParameters.Add("@DateFin", item.DateFin);
            oParameters.Add("@DateFinProbable", item.DateFinProbable);
            oParameters.Add("@StatusID", item.StatusID);
            oParameters.Add("@DateChangStatus", item.DateChangStatus);
            oParameters.Add("@Notes", item.Notes);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;
        }

        public async Task<List<TRH04Affectation>> GetAffectionByMatricule(string id)
        {
            oItemAffectList = new List<TRH04Affectation>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TRH04Affectation>("Ps_TRH03ContratAff", this.RenseignerPrmRech(id), commandType: CommandType.StoredProcedure);
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemAffectList = vCustomList.ToList();
                }
            }
            return oItemAffectList;
        }

        public async Task<Resultat> GetResutUpdateAffect(TRH04Affectation item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH04Affectation", this.RenseignerPrmAffect(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;

        }

        private DynamicParameters RenseignerPrmAffect(TRH04Affectation item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@NumContrat", item.NumContrat);
            oParameters.Add("@SBranchID", item.SBranchID);
            oParameters.Add("@DateAffect", item.DateAffect);
            oParameters.Add("@DateFin", item.DateFin);
            oParameters.Add("@FunctionID", item.FunctionID);
            oParameters.Add("@Observations", item.Observations);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }



        public async Task<Resultat> ValiderCotrat(ParamValidContrat param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH03ContratValidation", this.RenseignerPrmValid(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmValid(ParamValidContrat param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }


        public async Task<Resultat> ValiderAffectation(ParamValidAffectation param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH04AffectationValidation", this.RenseignerPrmValidAffectation(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmValidAffectation(ParamValidAffectation param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@UserID", param.UserID);
            return oParameters;

        }

        public async Task<Resultat> ContractSuspesion(ParamSuspendContract param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH03ContratSusp", this.RenseignerPrmContractSusp(param), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }


        private DynamicParameters RenseignerPrmContractSusp(ParamSuspendContract param)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", param.ID);
            oParameters.Add("@NumContrat", param.NumContrat);
            oParameters.Add("@MATRICULE", param.Matricule);
            oParameters.Add("@UserID", param.UserID);
            oParameters.Add("@TpMaj", param.TpMaj);
            return oParameters;

        }
    }
}
