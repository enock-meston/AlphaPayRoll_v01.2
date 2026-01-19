using Dapper;
using PayAPI.StringCon;
using PayLibrary.CongeRequestF;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace PayAPI.DataIntImplem.CongeRequestsF
{
    public class THRCongCircRequestImpl : ITHRCongCircRequest
    {


        List<THRCongCircRequest> oListCongeRequest = new List<THRCongCircRequest>();
        ClassTRH02Agent oAgent = new ClassTRH02Agent();
        Resultat oResultat = new Resultat();
        public async Task<List<THRCongCircRequest>> GetAllCongeRequests()
        {

            oListCongeRequest = new List<THRCongCircRequest>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();


                var List = await oCon.QueryAsync<THRCongCircRequest>("Select * from THRCongRequest", commandType: CommandType.Text);

                if (List != null && List.Count() > 0)
                {
                    oListCongeRequest = List.ToList();
                }
            }


            return oListCongeRequest;
        }



        public async Task<List<THRCongCircRequest>> GetAllCongeRequestsByMatricule(string id)
        {

            oListCongeRequest = new List<THRCongCircRequest>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();

                var List = await oCon.QueryAsync<THRCongCircRequest>(
                    "SELECT * FROM THRCongRequest WHERE Matricule = @Matricule",
                    new { Matricule = id }
                );

                if (List != null && List.Any())
                {
                    oListCongeRequest = List.ToList();
                }
            }
            return oListCongeRequest;
        }


        public async Task<Resultat> GetUpdateResult(THRCongCircRequest item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_THRCongRequest", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        public async Task<Resultat> ValideCongeRequest(ParamMatricule param, int id)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ValideConge", this.RenseignerPrmValideCongeReq(param,id), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(THRCongCircRequest item)
        {



            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule ?? string.Empty);
            oParameters.Add("@SBranchID", item.SBranchID ?? string.Empty);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@NumTranche", item.NumTranche);
            oParameters.Add("@DateRequest", item.DateRequest);
            oParameters.Add("@DateDebutReq", item.DateDebutReq);
            oParameters.Add("@DateFinReq", item.DateFinReq);
            oParameters.Add("@DateDebutApprov", item.DateDebutApprov);
            oParameters.Add("@DateFinApprov", item.DateFinApprov);
            oParameters.Add("@NbrJour", item.NbrJour);
            oParameters.Add("@NbrJourApprov", item.NbrJourApprov);
            oParameters.Add("@StatusChefID", item.StatusChefID);
            oParameters.Add("@StatusHRID", item.StatusHRID);
            oParameters.Add("@StatusDGID", item.StatusDGID);
            oParameters.Add("@RemChefD", item.RemChefD);
            oParameters.Add("@RemHR", item.RemHR);
            oParameters.Add("@RemDG", item.RemDG);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;

        }


        private DynamicParameters RenseignerPrmValideCongeReq(ParamMatricule param,int id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", param.Matricule ?? string.Empty);
            oParameters.Add("@ID", id);

            return oParameters;
        }
    }
}