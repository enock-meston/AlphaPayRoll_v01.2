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
    public class TSL02AgRegAugmMoisImpl : ITSL02AgRegAugmMois
    {

        List<AgDonIntialMois> itemList = new List<AgDonIntialMois>();
        Resultat oResultat = new Resultat();
        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMois()
        {

            string sSqlString = "SELECT dbo.TSL02AgRegAugmMois.ID, dbo.TSL02AgRegAugmMois.AgentId, dbo.TSL02AgRegAugmMois.TpRetId, " +
            "dbo.TSL02AgRegAugmMois.Exercice, dbo.TSL02AgRegAugmMois.Mois, dbo.TSL02AgRegAugmMois.MontAPayMois, " +
            "dbo.TSL02AgRegAugmMois.CreatBy, dbo.TSL02AgRegAugmMois.CreatOn, dbo.TSL02AgRegAugmMois.LModifBy, " +
            "dbo.TSL02AgRegAugmMois.LModifOn, dbo.TSL550TpAugmRegul.Descript " +
            "FROM dbo.TSL02AgRegAugmMois INNER JOIN " +
            "dbo.TSL550TpAugmRegul ON dbo.TSL02AgRegAugmMois.TpRetId = dbo.TSL550TpAugmRegul.ID ";



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

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByAgent(int id)
        {

            string sSqlString = "SELECT dbo.TSL02AgRegAugmMois.ID, dbo.TSL02AgRegAugmMois.AgentId, dbo.TSL02AgRegAugmMois.TpRetId, " +
            "dbo.TSL02AgRegAugmMois.Exercice, dbo.TSL02AgRegAugmMois.Mois, dbo.TSL02AgRegAugmMois.MontAPayMois, " +
            "dbo.TSL02AgRegAugmMois.CreatBy, dbo.TSL02AgRegAugmMois.CreatOn, dbo.TSL02AgRegAugmMois.LModifBy, " +
            "dbo.TSL02AgRegAugmMois.LModifOn, dbo.TSL550TpAugmRegul.Descript " +
            "FROM dbo.TSL02AgRegAugmMois INNER JOIN " +
            "dbo.TSL550TpAugmRegul ON dbo.TSL02AgRegAugmMois.TpRetId = dbo.TSL550TpAugmRegul.ID where dbo.TSL02AgRegAugmMois.AgentId= " + id;



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

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByType(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRegAugmMois  where TpRetId=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }




        public async Task<Resultat> GetUpdateRegAugmMoisResult(AgDonIntialMois item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRegAugmMois", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

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
