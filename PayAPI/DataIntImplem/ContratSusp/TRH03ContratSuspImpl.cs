using Dapper;
using PayAPI.StringCon;
using PayLibrary.Contrat;
using PayLibrary.ContratSusp;
using PayLibrary.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ContratSusp
{
    public class TRH03ContratSuspImpl : ITRH03ContratSusp
    {
        List<TRH03ContratSusp> oItemList = new List<TRH03ContratSusp>();

        Resultat oResultat = new Resultat();
        public async Task<List<TRH03ContratSusp>> GetAllSusContract()
        {
            oItemList = new List<TRH03ContratSusp>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TRH03ContratSusp>("Select * from TRH03ContratSusp");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }


        public async Task<List<TRH03ContratSusp>> GetSusContractByMatricule(string id)
        {

            oItemList = new List<TRH03ContratSusp>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();

                var List = await oCon.QueryAsync<TRH03ContratSusp>(
                    "SELECT * FROM TRH03ContratSusp WHERE Matricule = @Matricule",
                    new { Matricule = id }
                );

                if (List != null && List.Any())
                {
                    oItemList = List.ToList();
                }
            }
            return oItemList;
        }

        public async Task<Resultat> GetResutUpdate(TRH03ContratSusp item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH03ContratSuspUpdate", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }



        private DynamicParameters RenseignerPrmUpdate(TRH03ContratSusp item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@NumContrat", item.NumContrat);
            oParameters.Add("@MATRICULE", item.MATRICULE);
            oParameters.Add("@Categorie", item.Categorie);
            oParameters.Add("@DateDebut", item.DateDebut);
            oParameters.Add("@DateFin", item.DateFin);
            oParameters.Add("@DateFinProbable", item.DateFinProbable);
            oParameters.Add("@StatusID", item.StatusID);
            oParameters.Add("@DateChangStatus", item.DateChangStatus);
            oParameters.Add("@Notes", item.Notes);
            oParameters.Add("@Motif", item.Motif);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;
        }




        // contract validation
        public async Task<Resultat> ValiderSusCotrat(ParamValidContrat param)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TRH03ContratSusValidation", this.RenseignerPrmValid(param), commandType: CommandType.StoredProcedure);

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
    }
}
