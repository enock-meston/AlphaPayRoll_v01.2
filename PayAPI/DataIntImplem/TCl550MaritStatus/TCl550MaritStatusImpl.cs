using Dapper;
using PayAPI.StringCon;
using PayLibrary.TCl550MaritStatus;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataImplementation.TCl550MaritStatus
{
    public class TCl550MaritStatusImpl : ITCl550MaritStatus
    {
        List<ClassTCl550MaritStatus> oItemList = new List<ClassTCl550MaritStatus>();

        //Resultat oResultat = new Resultat();

        public async Task<List<ClassTCl550MaritStatus>> GetTCl550MaritStatus()
        {
            oItemList = new List<ClassTCl550MaritStatus>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTCl550MaritStatus>("Select * from TCl550MaritStatus");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }


        //public async Task<Resultat> GetResutUpdate(ClassTCl550MaritStatus item)
        //{
        //    oResultat = new Resultat();
        //    try
        //    {

        //        using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //        {

        //            if (oCon.State == ConnectionState.Closed) oCon.Open();
        //            var oRecord = await oCon.QueryAsync<Resultat>("Ps_TCl550MaritStatus", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

        //            oResultat = oRecord.FirstOrDefault();


        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        oResultat.Result = ex.Message;
        //    }

        //    return oResultat;
        //}


        private DynamicParameters RenseignerPrmUpdate(ClassTCl550MaritStatus item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RICode", item.RICode);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@CreatOn", item.CreatOn);
            oParameters.Add("@CreatBy", item.CreatBy);
            oParameters.Add("@LModifBy", item.LModifBy);
            oParameters.Add("@LModifOn", item.LModifOn);

            return oParameters;

        }

    }
}



