using Dapper;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL550TPHSup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RimProjectAPi.DataIntImplem.DocVal
{
    public class TSL550TPHSupImpl : ITSL550TPHSup
    {
        List<ClassTSL550TPHSup> itemList = new List<ClassTSL550TPHSup>();
        Resultat oResultat = new Resultat();
        public async Task<List<ClassTSL550TPHSup>> GetTSL550TPHSup()
        {
            itemList = new List<ClassTSL550TPHSup>();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSL550TPHSup>("Select * from TSL550TPHSup");

                if (vCustomList != null && vCustomList.Count() > 0)
                {
                    itemList = vCustomList.ToList();
                }
            }
            return itemList;
        }
        public async Task<Resultat> GetUpdateResult(ClassTSL550TPHSup item)
        {
            oResultat = new Resultat();


            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<Resultat>("Ps_TSL550TPHSup", this.RenseignerPrm(item), commandType: CommandType.StoredProcedure);

                oResultat = vCustomList.FirstOrDefault();
            }
            return oResultat;
        }
        private DynamicParameters RenseignerPrm(ClassTSL550TPHSup item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RICode", item.RICode);
            oParameters.Add("@Descript ", item.Descript);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@Ordnum", item.Ordnum);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }
    }
}