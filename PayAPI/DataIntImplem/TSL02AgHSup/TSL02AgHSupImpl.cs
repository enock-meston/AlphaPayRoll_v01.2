using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgHSup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TSL02AgHSup
{
    public class TSL02AgHSupImpl : ITSL02AgHSup
    {
        List<ClassTSL02AgHSup> itemList = new List<ClassTSL02AgHSup>();
        Resultat oResultat = new Resultat();
        public async Task<List<ClassTSL02AgHSup>> GetTSL02AgHSup()
        {

            string strQuery = "SELECT dbo.TSL02AgHSupMois.ID, dbo.TSL02AgHSupMois.Exercice, dbo.TSL02AgHSupMois.Mois, " +
            "dbo.TSL02AgHSupMois.AgentID, dbo.TSL02AgHSupMois.TpHSupID, dbo.TSL02AgHSupMois.SemaineDu, dbo.TSL02AgHSupMois.Au, " +
            "dbo.TSL02AgHSupMois.Nombre, dbo.TSL02AgHSupMois.TxAppl, dbo.TSL02AgHSupMois.SalBase, dbo.TSL02AgHSupMois.Montant, " +
            "dbo.TSL02AgHSupMois.CreatBy, dbo.TSL02AgHSupMois.CreatOn, dbo.TSL02AgHSupMois.LModifBy, dbo.TSL02AgHSupMois.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom)  +' '+ RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent  " +
            "FROM dbo.TSL02AgHSupMois INNER JOIN dbo.TRH02Agent ON dbo.TSL02AgHSupMois.AgentID = dbo.TRH02Agent.AgentID ";

            itemList = new List<ClassTSL02AgHSup>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL02AgHSup>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<ClassTSL02AgHSup>> GetTSL02AgHSupByAgent(int id)
        {

            string strQuery = "SELECT dbo.TSL02AgHSupMois.ID, dbo.TSL02AgHSupMois.Exercice, dbo.TSL02AgHSupMois.Mois, " +
            "dbo.TSL02AgHSupMois.AgentID, dbo.TSL02AgHSupMois.TpHSupID, dbo.TSL02AgHSupMois.SemaineDu, dbo.TSL02AgHSupMois.Au, " +
            "dbo.TSL02AgHSupMois.Nombre, dbo.TSL02AgHSupMois.TxAppl, dbo.TSL02AgHSupMois.SalBase, dbo.TSL02AgHSupMois.Montant, " +
            "dbo.TSL02AgHSupMois.CreatBy, dbo.TSL02AgHSupMois.CreatOn, dbo.TSL02AgHSupMois.LModifBy, dbo.TSL02AgHSupMois.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom)  +' '+ RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent  " +
            "FROM dbo.TSL02AgHSupMois INNER JOIN dbo.TRH02Agent ON dbo.TSL02AgHSupMois.AgentID = dbo.TRH02Agent.AgentID  Where dbo.TSL02AgHSupMois.AgentID=" + id;

            itemList = new List<ClassTSL02AgHSup>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL02AgHSup>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(ClassTSL02AgHSup item)
        {



            oResultat = new Resultat();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL02AgHSup", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

                oResultat = vCustomList.FirstOrDefault();
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrm(ClassTSL02AgHSup item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Exercice ", item.Exercice);
            oParameters.Add("@Mois ", item.Mois);
            oParameters.Add("@AgentID", item.AgentID);
            oParameters.Add("@TpHSupID", item.TpHSupID);
            oParameters.Add("@SemaineDu", item.SemaineDu);
            oParameters.Add("@Au", item.Au);
            oParameters.Add("@Nombre ", item.Nombre);
            oParameters.Add("@TxAppl", item.TxAppl);
            oParameters.Add("@SalBase", item.SalBase);
            //oParameters.Add("@Montant", item.Montant);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }
    }
}
