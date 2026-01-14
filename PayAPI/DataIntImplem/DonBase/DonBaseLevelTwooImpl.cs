using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.DonBase
{
    public class DonBaseLevelTwooImpl : IDonBaseLevelTwoo
    {

        List<DonBaseLevelTwoo> itemList = new List<DonBaseLevelTwoo>();
        Resultat oResultat = new Resultat();


        public async Task<List<DonBaseLevelTwoo>> GetItemList(string id)
        {
            itemList = new List<DonBaseLevelTwoo>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<DonBaseLevelTwoo>("Select * from " + id);

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }


        public async Task<Resultat> GetUpdateResult(DonBaseLevelTwoo item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_DonBaseLevelTwoo", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        private DynamicParameters RenseignerPrmUpdate(DonBaseLevelTwoo item)

        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@TableName", item.TableName);
            oParameters.Add("@RICode", item.RICode);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@Parent", item.ParentID);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}
