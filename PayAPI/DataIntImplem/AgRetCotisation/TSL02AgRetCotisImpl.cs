using Dapper;
using PayAPI.StringCon;
using PayLibrary.AgRegAugmBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.AgRetCotisation
{
    public class TSL02AgRetCotisImpl : ITSL02AgRetCotis
    {


        List<TSL02AgRetCotis> itemList = new List<TSL02AgRetCotis>();
        Resultat oResultat = new Resultat();
        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotis()
        {

            string strQuery = "SELECT dbo.TSL02AgRetCotis.ID, dbo.TSL02AgRetCotis.AgentId, dbo.TSL02AgRetCotis.TpRetId, dbo.TSL02AgRetCotis.ExercDeb, dbo.TSL02AgRetCotis.MoisDeb, " +
            "dbo.TSL02AgRetCotis.PayMensuel, dbo.TSL02AgRetCotis.MontAPayMois, " +
            "dbo.TSL02AgRetCotis.EnVig, dbo.TSL02AgRetCotis.CreatBy, dbo.TSL02AgRetCotis.CreatOn, dbo.TSL02AgRetCotis.LModifBy, dbo.TSL02AgRetCotis.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL550TpDimAugSal.Denom " +
            "FROM  dbo.TSL02AgRetCotis INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL02AgRetCotis.AgentId = dbo.TRH02Agent.AgentID INNER JOIN " +
            "dbo.TSL550TpDimAugSal ON dbo.TSL02AgRetCotis.TpRetId = dbo.TSL550TpDimAugSal.ID ";



            itemList = new List<TSL02AgRetCotis>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02AgRetCotis>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList; ;
        }

        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByAgent(int id)
        {
            string strQuery = "SELECT dbo.TSL02AgRetCotis.ID, dbo.TSL02AgRetCotis.AgentId, dbo.TSL02AgRetCotis.TpRetId, dbo.TSL02AgRetCotis.ExercDeb, dbo.TSL02AgRetCotis.MoisDeb, " +
            "dbo.TSL02AgRetCotis.PayMensuel, dbo.TSL02AgRetCotis.MontAPayMois, " +
            "dbo.TSL02AgRetCotis.EnVig, dbo.TSL02AgRetCotis.CreatBy, dbo.TSL02AgRetCotis.CreatOn, dbo.TSL02AgRetCotis.LModifBy, dbo.TSL02AgRetCotis.LModifOn, " +
            "RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL550TpDimAugSal.Denom " +
            "FROM  dbo.TSL02AgRetCotis INNER JOIN " +
            "dbo.TRH02Agent ON dbo.TSL02AgRetCotis.AgentId = dbo.TRH02Agent.AgentID INNER JOIN " +
            "dbo.TSL550TpDimAugSal ON dbo.TSL02AgRetCotis.TpRetId = dbo.TSL550TpDimAugSal.ID  where dbo.TSL02AgRetCotis.AgentId=" + id;

            itemList = new List<TSL02AgRetCotis>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02AgRetCotis>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByType(int id)
        {
            string strQuery = "SELECT dbo.TSL02AgRetCotis.ID, dbo.TSL02AgRetCotis.AgentId, dbo.TSL02AgRetCotis.TpRetId, dbo.TSL02AgRetCotis.ExercDeb, dbo.TSL02AgRetCotis.MoisDeb, " +
            "dbo.TSL02AgRetCotis.PayMensuel, dbo.TSL02AgRetCotis.MontAPayMois,  " +
            "dbo.TSL02AgRetCotis.EnVig, dbo.TSL02AgRetCotis.CreatBy, dbo.TSL02AgRetCotis.CreatOn, dbo.TSL02AgRetCotis.LModifBy, dbo.TSL02AgRetCotis.LModifOn,  " +
            "RTRIM(dbo.TRH02Agent.Nom) + ' ' + RTRIM(dbo.TRH02Agent.Prenom) AS NomAgent, dbo.TSL550TpRetCotis.Descript " +
            "FROM  dbo.TSL02AgRetCotis INNER JOIN  " +
            "dbo.TRH02Agent ON dbo.TSL02AgRetCotis.AgentId = dbo.TRH02Agent.AgentID INNER JOIN  " +
            "dbo.TSL550TpRetCotis ON dbo.TSL02AgRetCotis.TpRetId = dbo.TSL550TpRetCotis.ID   " +
            "where dbo.TSL550TpRetCotis.ID=" + id;


            itemList = new List<TSL02AgRetCotis>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<TSL02AgRetCotis>(strQuery);

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TSL02AgRetCotis item)
        {
            oResultat = new Resultat();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRetCotis", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

                oResultat = vCustomList.FirstOrDefault();
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrm(TSL02AgRetCotis item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@AgentId ", item.AgentId);
            oParameters.Add("@TpRetId ", item.TpRetId);
            oParameters.Add("@ExercDeb", item.ExercDeb);
            oParameters.Add("@MoisDeb", item.MoisDeb);
            oParameters.Add("@PayMensuel ", item.PayMensuel);
            oParameters.Add("@MontAPayMois", item.MontAPayMois);
            oParameters.Add("@EnVig", item.EnVig);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}
