using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgentRet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TSL02AgentRet
{
    public class TSL02AgentRetImpl : ITSL02AgentRet
    {

        List<ClassTSL02AgentRet> oItemList = new List<ClassTSL02AgentRet>();

        Resultat oResultat = new Resultat();



        public async Task<List<ClassTSL02AgentRet>> GetTSL02AgentRet()
        {
            oItemList = new List<ClassTSL02AgentRet>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL02AgentRet>("Select * from TSL02AgentRet");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }

        public async Task<Resultat> GetResutUpdate(ClassTSL02AgentRet item)
        {

            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSL02AgentRet", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSL02AgentRet item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@AgentId", item.AgentId);
            oParameters.Add("@TpRetId", item.TpRetId);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@ExercDeb", item.ExercDeb);
            oParameters.Add("@MoisDeb", item.MoisDeb);
            oParameters.Add("@Montant", item.Montant);
            oParameters.Add("@MaxRef", item.MaxRef);
            oParameters.Add("@Reste", item.Reste);
            oParameters.Add("@Perman", item.Perman);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }





    }
}


