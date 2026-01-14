using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgDimAugmSal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TSL02AgDimAugmSal
{
    public class TSL02AgDimAugmSalImpl : ITSL02AgDimAugmSal
    {
        List<ClassTSL02AgDimAugmSal> itemList = new List<ClassTSL02AgDimAugmSal>();
        Resultat oResultat = new Resultat();
        public async Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSal()
        {
            itemList = new List<ClassTSL02AgDimAugmSal>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL02AgDimAugmSal>("Select * from TSL02AgDimAugmSal");

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSalByAgent(int id)
        {
            string strQuery = "SELECT dbo.TSL02AgDimAugmSal.ID, dbo.TSL02AgDimAugmSal.AgentId, dbo.TSL02AgDimAugmSal.TpRetId, dbo.TSL02AgDimAugmSal.ExercDeb, dbo.TSL02AgDimAugmSal.MoisDeb, dbo.TSL02AgDimAugmSal.MontAPay," +
                  " dbo.TSL02AgDimAugmSal.PayMensuel, dbo.TSL02AgDimAugmSal.MontAPayMois, dbo.TSL02AgDimAugmSal.CumulPay, dbo.TSL02AgDimAugmSal.ResteAPay, dbo.TSL02AgDimAugmSal.Perman, dbo.TSL02AgDimAugmSal.Sens," +
                  " dbo.TSL02AgDimAugmSal.EnVig, dbo.TSL02AgDimAugmSal.Denom, dbo.TSL02AgDimAugmSal.CreatBy, dbo.TSL02AgDimAugmSal.CreatOn, dbo.TSL02AgDimAugmSal.LModifBy, dbo.TSL02AgDimAugmSal.LModifOn," +
                  " RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent " +
                  " FROM dbo.TSL02AgDimAugmSal INNER JOIN " +
                  " dbo.TRH02Agent ON dbo.TSL02AgDimAugmSal.AgentId = dbo.TRH02Agent.AgentID " +
                  " where dbo.TRH02Agent.AgentID=" + id;


            List<ClassTSL02AgDimAugmSal> itemList = new List<ClassTSL02AgDimAugmSal>();
            Resultat oResultat = new Resultat();

            itemList = new List<ClassTSL02AgDimAugmSal>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL02AgDimAugmSal>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;

        }

        public async Task<Resultat> GetUpdateResult(ClassTSL02AgDimAugmSal item)
        {
            oResultat = new Resultat();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL02AgDimAugmSal", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

                oResultat = vCustomList.FirstOrDefault();
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrm(ClassTSL02AgDimAugmSal item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@AgentId ", item.AgentId);
            oParameters.Add("@TpRetId ", item.TpRetId);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@MontAPay ", item.MontAPay);
            oParameters.Add("@PayMensuel ", item.PayMensuel);
            oParameters.Add("@MontAPayMois", item.MontAPayMois);
            oParameters.Add("@CumulPay", item.CumulPay);
            oParameters.Add("@ResteAPay", item.MontAPayMois);
            oParameters.Add("@Perman", item.Perman);
            oParameters.Add("@Sens", item.Sens);
            oParameters.Add("@EnVig", item.EnVig);
            oParameters.Add("@Denom", item.Denom);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }

    }
}
