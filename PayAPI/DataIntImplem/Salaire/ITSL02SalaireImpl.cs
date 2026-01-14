using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Salaire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace PayAPI.DataIntImplem.Salaire
{
    public class ITSL02SalaireImpl : ITSL02Salaire
    {
        List<TSL02Salaire> oItemList = new List<TSL02Salaire>();
        Resultat oResultat = new Resultat();
        public async Task<List<TSL02Salaire>> GetSalaire(string id)
        {
            oItemList = new List<TSL02Salaire>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02Salaire>("Select * from TSL02Salaire where Matricule='" + id + "'");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }

        public async Task<List<TSL02Salaire>> GetSalaireAll()
        {
            oItemList = new List<TSL02Salaire>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02Salaire>("Select * from TSL02Salaire");
                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }
            }
            return oItemList;
        }

        public async Task<Resultat> GetUpdateResult(TSL02Salaire item)
        {
            oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02Salaire", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrmUpdate(TSL02Salaire item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@Matricule", item.Matricule);
            oParameters.Add("@BranchCpteID", item.BranchCpteID);
            oParameters.Add("@SBranchCpteID", item.SBranchCpteID);
            oParameters.Add("@ClientId", item.ClientId);
            oParameters.Add("@PayDay", item.PayDay);

            oParameters.Add("@SalBase", item.SalBase);
            oParameters.Add("@IndemLog", item.IndemLog);
            oParameters.Add("@IndemDeplac", item.IndemDeplac);
            oParameters.Add("@IndemFct", item.IndemFct);
            oParameters.Add("@Gratifications", item.Gratifications);
            oParameters.Add("@TotalIndem", item.TotalIndem);
            oParameters.Add("@Primes", item.Primes);

            oParameters.Add("@REGULARISATION", item.REGULARISATION);
            oParameters.Add("@AutresAvantage", item.AutresAvantage);
            oParameters.Add("@SALAIRE_BRUT", item.SALAIRE_BRUT);
            oParameters.Add("@SALAIRE_IMPOSABLE", item.SALAIRE_IMPOSABLE);
            oParameters.Add("@Cotisation_Patronale", item.Cotisation_Patronale);
            oParameters.Add("@Cotisation_Caisse_Social", item.Cotisation_Caisse_Social);
            oParameters.Add("@RSSB_EMPLOYEUR", item.RSSB_EMPLOYEUR);
            oParameters.Add("@RSSB_EMPLOYEE", item.RSSB_EMPLOYEE);

            oParameters.Add("@TPR", item.TPR);
            oParameters.Add("@RSSBPens", item.RSSBPens);
            oParameters.Add("@MedInsur", item.MedInsur);
            oParameters.Add("@MutSante", item.MutSante);
            oParameters.Add("@RembCredit", item.RembCredit);
            oParameters.Add("@RembBourse", item.RembBourse);
            oParameters.Add("@RetSanLam", item.RetSanLam);
            oParameters.Add("@RetPrimeLife", item.RetPrimeLife);
            oParameters.Add("@RetCaisseSolid", item.RetCaisseSolid);
            oParameters.Add("@RetCaisEp", item.RetCaisEp);
            oParameters.Add("@RetEjoHeza", item.RetEjoHeza);

            oParameters.Add("@AutRetenues", item.AutRetenues);
            oParameters.Add("@TotalRetenue", item.TotalRetenue);
            oParameters.Add("@TotalReteNonStat", item.TotalReteNonStat);
            oParameters.Add("@NetAPayer", item.NetAPayer);

            oParameters.Add("@RIPPSPAYMENT", item.RIPPSPAYMENT);
            oParameters.Add("@BourseRipps", item.BourseRipps);
            oParameters.Add("@EjoHezaRipps", item.EjoHezaRipps);
            oParameters.Add("@AutreRetRipps", item.AutreRetRipps);
            oParameters.Add("@ViremRIPPS", item.ViremRIPPS);
            oParameters.Add("@IndemAutre", item.IndemAutre);
            oParameters.Add("@GuichetID", item.GuichetID);
            oParameters.Add("@BanqPaySalaire", item.BanqPaySalaire);
            oParameters.Add("@CpteAutreBanq", item.CpteAutreBanq);

            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);

            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;
        }


    }
}
