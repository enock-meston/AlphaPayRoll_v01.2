using Dapper;
using PayAPI.StringCon;
using PayLibrary.CongConsult;
using PayLibrary.CongeRequestF;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System.Data;
using System.Data.SqlClient;

namespace PayAPI.DataIntImplem.CongConsult
{
    public class CongConsultStatusImpl : ICongConsultStatus
    {
        List<CongConsultStatus> oListCongeRequest = new List<CongConsultStatus>();
        ClassTRH02Agent oAgent = new ClassTRH02Agent();
        Resultat oResultat = new Resultat();
        public async Task<List<CongConsultStatus>> GetAllCongeConsultStatus(ParamConsultConge param)
        {
            string sProcedureStock = "";

            if (param.TypeConge=="CongeAnnuel")
            {
                sProcedureStock = "Ps_CongConsultStatus";
            }
            else
            {
                sProcedureStock = "Ps_CongCirconsConsultStatus";
            }
            oListCongeRequest = new List<CongConsultStatus>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
       
                var List = await oCon.QueryAsync<CongConsultStatus>(
                    sProcedureStock, this.RenseignerPrm(param), commandType: CommandType.StoredProcedure);
                   

                if (List != null && List.Any())
                {
                    oListCongeRequest = List.ToList();
                }
            }
            return oListCongeRequest;
        }


        private DynamicParameters RenseignerPrm(ParamConsultConge param)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule",param.Matricule);

            return oParameters;
        }
    }
}
