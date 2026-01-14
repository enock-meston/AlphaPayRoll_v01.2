using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL550TpDimAugSal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.TSL550TpDimAugSal
{
    public class TSL550TpDimAugSalImpl : ITSL550TpDimAugSal
    {
        List<ClassTSL550TpDimAugSal> itemList = new List<ClassTSL550TpDimAugSal>();
        Resultat oResultat = new Resultat();
        public async Task<List<ClassTSL550TpDimAugSal>> GetTSL550TpDimAugSal()
        {
            itemList = new List<ClassTSL550TpDimAugSal>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL550TpDimAugSal>("Select * from TSL550TpDimAugSal");

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }
        public async Task<Resultat> GetUpdateResult(ClassTSL550TpDimAugSal item)
        {
            oResultat = new Resultat();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL550TpDimAugSal", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

                oResultat = vCustomList.FirstOrDefault();
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrm(ClassTSL550TpDimAugSal item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Denom ", item.Denom);
            oParameters.Add("@Perman ", item.Perman);
            oParameters.Add("@Sens", item.Sens);
            oParameters.Add("@Occasionnel", item.Occasionnel);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }

    }
}
