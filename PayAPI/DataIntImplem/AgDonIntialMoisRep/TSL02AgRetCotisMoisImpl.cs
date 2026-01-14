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
    public class TSL02AgRetCotisMoisImpl : ITSL02AgRetCotisMois
    {
        List<AgDonIntialMois> itemList = new List<AgDonIntialMois>();
        Resultat oResultat = new Resultat();
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMois()
        {

            string sSqlString = "SELECT dbo.TSL02AgRetCotisMois.ID, dbo.TSL02AgRetCotisMois.AgentId, dbo.TSL02AgRetCotisMois.TpRetId, " +
            "dbo.TSL02AgRetCotisMois.Exercice, dbo.TSL02AgRetCotisMois.Mois, dbo.TSL02AgRetCotisMois.MontAPayMois, " +
            "dbo.TSL02AgRetCotisMois.CreatBy, dbo.TSL02AgRetCotisMois.CreatOn, dbo.TSL02AgRetCotisMois.LModifBy, " +
            "dbo.TSL02AgRetCotisMois.LModifOn, dbo.TSL550TpRetCotis.Descript " +
            "FROM  dbo.TSL02AgRetCotisMois INNER JOIN " +
            "dbo.TSL550TpRetCotis ON dbo.TSL02AgRetCotisMois.TpRetId = dbo.TSL550TpRetCotis.ID ";


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

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMoisByAgent(int id)
        {

            string sSqlString = "SELECT dbo.TSL02AgRetCotisMois.ID, dbo.TSL02AgRetCotisMois.AgentId, dbo.TSL02AgRetCotisMois.TpRetId, " +
            "dbo.TSL02AgRetCotisMois.Exercice, dbo.TSL02AgRetCotisMois.Mois, dbo.TSL02AgRetCotisMois.MontAPayMois, " +
            "dbo.TSL02AgRetCotisMois.CreatBy, dbo.TSL02AgRetCotisMois.CreatOn, dbo.TSL02AgRetCotisMois.LModifBy, " +
            "dbo.TSL02AgRetCotisMois.LModifOn, dbo.TSL550TpRetCotis.Descript " +
            "FROM     dbo.TSL02AgRetCotisMois INNER JOIN " +
            "dbo.TSL550TpRetCotis ON dbo.TSL02AgRetCotisMois.TpRetId = dbo.TSL550TpRetCotis.ID Where dbo.TSL02AgRetCotisMois.AgentId= " + id;


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

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetCotisMoisByType(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRetCotisMois  where TpRetId=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }




        public async Task<Resultat> GetUpdateRetCotisMoisResult(AgDonIntialMois item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRetCotisMois", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

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
