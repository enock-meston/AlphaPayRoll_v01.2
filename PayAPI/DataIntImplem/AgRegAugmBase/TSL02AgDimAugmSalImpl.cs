using Dapper;
using PayAPI.StringCon;
using PayLibrary.AgRegAugmBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.AgRegAugmBase
{
    public class TSL02AgRetAugmBaseImpl : ITSL02AgRetPayment
    {
        List<TSL02AgRetPayment> itemList = new List<TSL02AgRetPayment>();
        Resultat oResultat = new Resultat();
        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBase()
        {

            string strQuery = "SELECT dbo.TSL02AgRetPayment.ID, dbo.TSL02AgRetPayment.AgentId, dbo.TSL02AgRetPayment.TpRetId, dbo.TSL02AgRetPayment.ExercDeb, dbo.TSL02AgRetPayment.MoisDeb, dbo.TSL02AgRetPayment.MontAPay, " +
            "dbo.TSL02AgRetPayment.PayMensuel, dbo.TSL02AgRetPayment.MontAPayMois, dbo.TSL02AgRetPayment.CumulPay, dbo.TSL02AgRetPayment.ResteAPay, " +
            "dbo.TSL02AgRetPayment.EnVig, dbo.TSL02AgRetPayment.CreatBy, dbo.TSL02AgRetPayment.CreatOn, dbo.TSL02AgRetPayment.LModifBy, dbo.TSL02AgRetPayment.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL550TpDimAugSal.Denom " +
            "FROM  dbo.TSL02AgRetPayment INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL02AgRetPayment.AgentId = dbo.TRH02Agent.AgentID INNER JOIN " +
            "dbo.TSL550TpDimAugSal ON dbo.TSL02AgRetPayment.TpRetId = dbo.TSL550TpDimAugSal.ID ";



            itemList = new List<TSL02AgRetPayment>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02AgRetPayment>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByAgent(int id)
        {
            string strQuery = "SELECT dbo.TSL02AgRetPayment.ID, dbo.TSL02AgRetPayment.AgentId, dbo.TSL02AgRetPayment.TpRetId, dbo.TSL02AgRetPayment.ExercDeb, dbo.TSL02AgRetPayment.MoisDeb, dbo.TSL02AgRetPayment.MontAPay, " +
            "dbo.TSL02AgRetPayment.PayMensuel, dbo.TSL02AgRetPayment.MontAPayMois, dbo.TSL02AgRetPayment.CumulPay, dbo.TSL02AgRetPayment.ResteAPay, " +
            "dbo.TSL02AgRetPayment.EnVig, dbo.TSL02AgRetPayment.CreatBy, dbo.TSL02AgRetPayment.CreatOn, dbo.TSL02AgRetPayment.LModifBy, dbo.TSL02AgRetPayment.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL550TpDimAugSal.Denom " +
            "FROM  dbo.TSL02AgRetPayment INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL02AgRetPayment.AgentId = dbo.TRH02Agent.AgentID INNER JOIN " +
            "dbo.TSL550TpDimAugSal ON dbo.TSL02AgRetPayment.TpRetId = dbo.TSL550TpDimAugSal.ID  where dbo.TSL02AgRetPayment.AgentId=" + id;





            itemList = new List<TSL02AgRetPayment>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02AgRetPayment>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;

        }


        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByType(int id)
        {
            string strQuery = "SELECT dbo.TSL02AgRetPayment.ID, dbo.TSL02AgRetPayment.AgentId, dbo.TSL02AgRetPayment.TpRetId, dbo.TSL02AgRetPayment.ExercDeb, dbo.TSL02AgRetPayment.MoisDeb, dbo.TSL02AgRetPayment.MontAPay, " +
            "dbo.TSL02AgRetPayment.PayMensuel, dbo.TSL02AgRetPayment.MontAPayMois, dbo.TSL02AgRetPayment.CumulPay, dbo.TSL02AgRetPayment.ResteAPay, " +
            "dbo.TSL02AgRetPayment.EnVig, dbo.TSL02AgRetPayment.CreatBy, dbo.TSL02AgRetPayment.CreatOn, dbo.TSL02AgRetPayment.LModifBy, dbo.TSL02AgRetPayment.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL550TpDimAugSal.Denom " +
            "FROM  dbo.TSL02AgRetPayment INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL02AgRetPayment.AgentId = dbo.TRH02Agent.AgentID INNER JOIN " +
            "dbo.TSL550TpDimAugSal ON dbo.TSL02AgRetPayment.TpRetId = dbo.TSL550TpDimAugSal.ID  where dbo.TSL550TpDimAugSal.ID=" + id;


            itemList = new List<TSL02AgRetPayment>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02AgRetPayment>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;

        }



        public async Task<Resultat> GetUpdateResult(TSL02AgRetPayment item)
        {
            oResultat = new Resultat();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRetPayment", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

                oResultat = vCustomList.FirstOrDefault();
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrm(TSL02AgRetPayment item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@AgentId ", item.AgentId);
            oParameters.Add("@TpRetId ", item.TpRetId);
            oParameters.Add("@ExercDeb", item.ExercDeb);
            oParameters.Add("@MoisDeb", item.MoisDeb);
            oParameters.Add("@MontAPay ", item.MontAPay);
            oParameters.Add("@PayMensuel ", item.PayMensuel);
            oParameters.Add("@MontAPayMois", item.MontAPayMois);
            oParameters.Add("@CumulPay", item.CumulPay);
            oParameters.Add("@ResteAPay", item.MontAPayMois);
            oParameters.Add("@EnVig", item.EnVig);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }

    }
}
