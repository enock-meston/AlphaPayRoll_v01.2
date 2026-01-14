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
    public class TSL02AgRetOccasMoisImpl : ITSL02AgRetOccasMois
    {

        List<AgDonIntialMois> itemList = new List<AgDonIntialMois>();
        Resultat oResultat = new Resultat();
        public async Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMois()
        {
            string sSqlString = "SELECT dbo.TSL02AgRetOccasMois.ID, dbo.TSL02AgRetOccasMois.AgentId, dbo.TSL02AgRetOccasMois.TpRetId, " +
            "dbo.TSL02AgRetOccasMois.Exercice, dbo.TSL02AgRetOccasMois.Mois, dbo.TSL02AgRetOccasMois.MontAPayMois, " +
            "dbo.TSL02AgRetOccasMois.CreatBy, dbo.TSL02AgRetOccasMois.CreatOn, dbo.TSL02AgRetOccasMois.LModifBy, " +
            "dbo.TSL02AgRetOccasMois.LModifOn, dbo.TSL550TpRetAutre.Descript " +
            "FROM   dbo.TSL02AgRetOccasMois INNER JOIN " +
            "dbo.TSL550TpRetAutre ON dbo.TSL02AgRetOccasMois.TpRetId = dbo.TSL550TpRetAutre.ID ";


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

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMoisByAgent(int id)
        {

            string sSqlString = "SELECT dbo.TSL02AgRetOccasMois.ID, dbo.TSL02AgRetOccasMois.AgentId, dbo.TSL02AgRetOccasMois.TpRetId, " +
            "dbo.TSL02AgRetOccasMois.Exercice, dbo.TSL02AgRetOccasMois.Mois, dbo.TSL02AgRetOccasMois.MontAPayMois, " +
            "dbo.TSL02AgRetOccasMois.CreatBy, dbo.TSL02AgRetOccasMois.CreatOn, dbo.TSL02AgRetOccasMois.LModifBy, " +
            "dbo.TSL02AgRetOccasMois.LModifOn, dbo.TSL550TpRetAutre.Descript " +
            "FROM   dbo.TSL02AgRetOccasMois INNER JOIN " +
            "dbo.TSL550TpRetAutre ON dbo.TSL02AgRetOccasMois.TpRetId = dbo.TSL550TpRetAutre.ID where dbo.TSL02AgRetOccasMois.AgentId=" + id;



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

        public async Task<List<AgDonIntialMois>> GetTSL02AgRetOccasMoisByType(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRetOccasMois  where TpRetId=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }




        public async Task<Resultat> GetUpdateRetOccasMoisResult(AgDonIntialMois item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRetOccasMois", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

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
