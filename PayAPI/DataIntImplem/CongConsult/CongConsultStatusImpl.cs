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
        public async Task<List<CongConsultStatus>> GetAllCongeConsultStatus(string id)
        {
            oListCongeRequest = new List<CongConsultStatus>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
       
                var List = await oCon.QueryAsync<CongConsultStatus>(
                    "Ps_CongConsultStatus", this.RenseignerPrm( id), commandType: CommandType.StoredProcedure);
                   

                if (List != null && List.Any())
                {
                    oListCongeRequest = List.ToList();
                }
            }
            return oListCongeRequest;
        }


        private DynamicParameters RenseignerPrm(string id)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule",id);

            return oParameters;
        }
    }
}
