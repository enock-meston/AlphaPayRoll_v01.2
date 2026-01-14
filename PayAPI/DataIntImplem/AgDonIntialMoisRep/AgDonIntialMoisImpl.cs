using Dapper;
using PayAPI.StringCon;
using PayLibrary.DonIntialMois;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace PayAPI.DataIntImplem.AgDonIntialMoisRep
{
    public class AgDonIntialMoisImpl : IAgDonIntialMois
    {
 

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


        //=======================================================================

 


        //=======================================================================

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMois()
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRegAugmMois");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegAugmMoisByAgent(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRegAugmMois  where AgentId=" + id);

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





        //=======================================================================

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegDimMoisMois()
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRegDimMois");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegDimMoisByAgent(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRegDimMois  where AgentId=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<List<AgDonIntialMois>> GetTSL02AgRegDimMoisByType(int id)
        {
            itemList = new List<AgDonIntialMois>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<AgDonIntialMois>("Select * from TSL02AgRegDimMois  where TpRetId=" + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }




        public async Task<Resultat> GetUpdateRegDimMoisResult(AgDonIntialMois item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02AgRegDimMois", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        //=======================================================================

 


    }
}
