using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL03Traitem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TSL03Traitem
{
    public class TSL03TraitemImpl : ITSL03Traitem
    {

        List<ClassTSL03Traitem> oItemList = new List<ClassTSL03Traitem>();

        Resultat oResultat = new Resultat();


        public async Task<List<ClassTSL03Traitem>> GetTSL03Traitem()
        {

            string stringSQL = "SELECT dbo.TSL03Traitem.ID, dbo.TSL03Traitem.AgentId, RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL03Traitem.An, dbo.TSL03Traitem.Mois, dbo.TSL03Traitem.NbreJTrav, " +
            "dbo.TSL03Traitem.SalBase, dbo.TSL03Traitem.Logem, dbo.TSL03Traitem.Deplacem, dbo.TSL03Traitem.Alloc, dbo.TSL03Traitem.Indemnit, dbo.TSL03Traitem.IndemRep, dbo.TSL03Traitem.AutresIndmt, dbo.TSL03Traitem.HeureSup, " +
            "dbo.TSL03Traitem.RegulAugm, dbo.TSL03Traitem.Brut, dbo.TSL03Traitem.BaseIPR, dbo.TSL03Traitem.RegulDimin, dbo.TSL03Traitem.PensionComp, dbo.TSL03Traitem.Remboursement, dbo.TSL03Traitem.Cotisation, " +
            "dbo.TSL03Traitem.AutreRetenue, dbo.TSL03Traitem.INSS, dbo.TSL03Traitem.IPR, dbo.TSL03Traitem.NETS, dbo.TSL03Traitem.PPINSS6, dbo.TSL03Traitem.PPINSS3, dbo.TSL03Traitem.PPPens, dbo.TSL03Traitem.CreatBy, " +
            "dbo.TSL03Traitem.CreatOn, dbo.TSL03Traitem.LModifBy, dbo.TSL03Traitem.LModifOn " +
            "FROM  dbo.TSL03Traitem INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL03Traitem.AgentId = dbo.TRH02Agent.AgentID ";


            oItemList = new List<ClassTSL03Traitem>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL03Traitem>(stringSQL);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        public async Task<List<ClassTSL03Traitem>> GetTSL03TraitemByAgent(int id)

        {

            string strQuery = "SELECT dbo.TSL03Traitem.ID, dbo.TSL03Traitem.AgentId, RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL03Traitem.An, dbo.TSL03Traitem.Mois, dbo.TSL03Traitem.NbreJTrav, " +
            "dbo.TSL03Traitem.SalBase, dbo.TSL03Traitem.Logem, dbo.TSL03Traitem.Deplacem, dbo.TSL03Traitem.Alloc, dbo.TSL03Traitem.Indemnit, dbo.TSL03Traitem.IndemFct, dbo.TSL03Traitem.AutresIndmt, dbo.TSL03Traitem.HeureSup, " +
            "dbo.TSL03Traitem.RegulAugm, dbo.TSL03Traitem.Brut, dbo.TSL03Traitem.BaseIPR, dbo.TSL03Traitem.RegulDimin, dbo.TSL03Traitem.PensComp10Prc,dbo.TSL03Traitem.PensionComp, dbo.TSL03Traitem.Remboursement, dbo.TSL03Traitem.Cotisation, " +
            "dbo.TSL03Traitem.AutreRetenue, dbo.TSL03Traitem.INSS, dbo.TSL03Traitem.IPR, dbo.TSL03Traitem.NETS, dbo.TSL03Traitem.PPINSS6, dbo.TSL03Traitem.PPINSS3, dbo.TSL03Traitem.PPPens, dbo.TSL03Traitem.CreatBy, " +
            "dbo.TSL03Traitem.CreatOn, dbo.TSL03Traitem.LModifBy, dbo.TSL03Traitem.LModifOn " +
            "FROM  dbo.TSL03Traitem INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL03Traitem.AgentId = dbo.TRH02Agent.AgentID where dbo.TRH02Agent.AgentID=" + id;


            oItemList = new List<ClassTSL03Traitem>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL03Traitem>(strQuery);


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;

        }


        public async Task<Resultat> GetResutUpdate(ClassTSL03Traitem item)
        {

            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL03Traitem", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSL03Traitem item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@AgentId", item.AgentId);
            oParameters.Add("@An", item.An);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@NbreJTrav", item.NbreJTrav);
            oParameters.Add("@SalBase", item.SalBase);
            oParameters.Add("@Logem", item.Logem);
            oParameters.Add("@Deplacem", item.Deplacem);
            oParameters.Add("@Alloc", item.Alloc);
            oParameters.Add("@Indemnit", item.Indemnit);
            oParameters.Add("@IndemFct", item.IndemFct);
            oParameters.Add("@AutresIndmt", item.AutresIndmt);
            oParameters.Add("@HeureSup", item.HeureSup);
            oParameters.Add("@RegulAugm", item.RegulAugm);
            oParameters.Add("@Brut", item.Brut);
            oParameters.Add("@BaseIPR", item.BaseIPR);
            oParameters.Add("@RegulDimin", item.RegulDimin);
            oParameters.Add("@PensionComp", item.PensionComp);
            oParameters.Add("@Remboursement", item.Remboursement);
            oParameters.Add("@Cotisation", item.Cotisation);
            oParameters.Add("@AutreRetenue", item.AutreRetenue);
            oParameters.Add("@INSS", item.INSS);
            oParameters.Add("@IPR", item.IPR);
            oParameters.Add("@NETS", item.NETS);
            oParameters.Add("@PPINSS6", item.PPINSS6);
            oParameters.Add("@PPINSS3", item.PPINSS3);
            oParameters.Add("@PPPens", item.PPPens);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}


