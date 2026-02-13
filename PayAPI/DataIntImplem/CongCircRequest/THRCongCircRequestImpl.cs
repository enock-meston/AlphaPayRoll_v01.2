using Dapper;
using PayAPI.StringCon;
using PayLibrary.CongCircRequest;
using PayLibrary.CongeRequestF;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace PayAPI.DataIntImplem.CongCircRequest
{
    public class THRCongCircRequestNewImpl : ITHRCongCircRequestNew
    {


        List<THRCongCircRequestNew> oListCongeRequest = new List<THRCongCircRequestNew>();
        Resultat oResultat = new Resultat();
        public async Task<List<THRCongCircRequestNew>> GetAllCongeCircRequests()
        {

            oListCongeRequest = new List<THRCongCircRequestNew>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();


                var List = await oCon.QueryAsync<THRCongCircRequestNew>("Select * from THRCongCircRequest", commandType: CommandType.Text);

                if (List != null && List.Count() > 0)
                {
                    oListCongeRequest = List.ToList();
                }
            }


            return oListCongeRequest;
        }

        public async Task<Resultat> GetUpdateResult(THRCongCircRequestNew item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_THRCongCircRequest", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

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
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_ValideCongCircRequest", this.RenseignerPrmValideCongeReq(param, id), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(THRCongCircRequestNew item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@SBranchID", item.SBranchID);
            oParameters.Add("@TpCongeID", item.TpCongeID);
            oParameters.Add("@DateRequest", item.DateRequest);
            oParameters.Add("@NbrJour", item.NbrJour);
            oParameters.Add("@Observation", item.Observation);
            oParameters.Add("@StatusChefID", item.StatusChefID);
            oParameters.Add("@StatusHRID", item.StatusHRID);
            oParameters.Add("@StatusDGID", item.StatusDGID);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;

        }

        private DynamicParameters RenseignerPrmValideCongeReq(ParamMatricule param, int id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", param.Matricule ?? string.Empty);
            oParameters.Add("@ID", id);

            return oParameters;
        }

    }
}