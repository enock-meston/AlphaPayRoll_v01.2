using Dapper;
using PayAPI.StringCon;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.AgDonIntialMoisRep
{
    public class TSL02AgRetPaymentMoisImpl : ITSL02AgRetPaymentMois
    {
        List<AgDonIntialMois> itemList = new List<AgDonIntialMois>();
        Resultat oResultat = new Resultat();





        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMois()
        {

            string sSqlString = "SELECT dbo.TSL02AgRetPaymentMois.ID, dbo.TSL02AgRetPaymentMois.AgentId, " +
            "dbo.TSL02AgRetPaymentMois.TpRetId, dbo.TSL02AgRetPaymentMois.Exercice, " +
            "dbo.TSL02AgRetPaymentMois.Mois, dbo.TSL02AgRetPaymentMois.MontAPayMois, " +
            "dbo.TSL02AgRetPaymentMois.CreatBy, dbo.TSL02AgRetPaymentMois.CreatOn, " +
            "dbo.TSL02AgRetPaymentMois.LModifBy, dbo.TSL02AgRetPaymentMois.LModifOn, " +
            "dbo.TSL550TpRetRemb.Descript " +
            "FROM dbo.TSL02AgRetPaymentMois INNER JOIN " +
            "dbo.TSL550TpRetRemb ON dbo.TSL02AgRetPaymentMois.TpRetId = dbo.TSL550TpRetRemb.ID ";


            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>(sSqlString);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;

        }


        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByAgent(int id)
        {

            string sSqlString = "SELECT dbo.TSL02AgRetPaymentMois.ID, dbo.TSL02AgRetPaymentMois.AgentId, " +
            "dbo.TSL02AgRetPaymentMois.TpRetId, dbo.TSL02AgRetPaymentMois.Exercice, " +
            "dbo.TSL02AgRetPaymentMois.Mois, dbo.TSL02AgRetPaymentMois.MontAPayMois, " +
            "dbo.TSL02AgRetPaymentMois.CreatBy, dbo.TSL02AgRetPaymentMois.CreatOn, " +
            "dbo.TSL02AgRetPaymentMois.LModifBy, dbo.TSL02AgRetPaymentMois.LModifOn, " +
            "dbo.TSL550TpRetRemb.Descript " +
            "FROM dbo.TSL02AgRetPaymentMois INNER JOIN " +
            "dbo.TSL550TpRetRemb ON dbo.TSL02AgRetPaymentMois.TpRetId = dbo.TSL550TpRetRemb.ID  Where dbo.TSL02AgRetPaymentMois.AgentId=" + id;


            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>(sSqlString);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }


        public async Task<List<AgDonIntialMois>> GetTSL02AgRetPaymentMoisByType(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRetPaymentMois where TpRetId=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }


        public async Task<Resultat> GetUpdatePaymentMoisResult(AgDonIntialMois item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRetPaymentMois", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(AgDonIntialMois item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@AgentId", item.AgentId);
            oParameters.Add("@TpRetId", item.TpRetId);
            oParameters.Add("@Exercice", item.Exercice);
            oParameters.Add("@Mois", item.Mois);
            oParameters.Add("@MontAPayMois", item.MontAPayMois);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}
