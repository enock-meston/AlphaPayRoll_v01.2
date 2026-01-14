using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSto551EventIn;
using PayAPI.StringCon;
using PayLibrary.ParamSec.ViewModel;

namespace PayAPI.DataImplementation.TSto551EventIn
{
    public class TSto551EventInImpl : ITSto551EventIn
    {

        List<ClassTSto551EventIn> oItemList = new List<ClassTSto551EventIn>();

        Resultat oResultat = new Resultat();


        public async Task<List<ClassTSto551EventIn>> GetTSto551EventIn()
        {
            oItemList = new List<ClassTSto551EventIn>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vCustomList = await oCon.QueryAsync<ClassTSto551EventIn>("Select * from TSto551EventIn");


                if (vCustomList != null && vCustomList.ToList().Count > 0)
                {
                    oItemList = vCustomList.ToList();
                }


            }

            return oItemList;
        }

        public async Task<Resultat> GetResutUpdate(ClassTSto551EventIn item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSto551EventIn", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerPrmUpdate(ClassTSto551EventIn item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@RICode", item.RICode);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@EntitIDFrom", item.EntitIDFrom);
            oParameters.Add("@EntitIDTo", item.EntitIDTo);
            oParameters.Add("@Salary", item.Salary);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);

            return oParameters;

        }

    }
}

