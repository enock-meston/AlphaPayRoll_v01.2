using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ParamSec
{
    public class TSc552MenuAllawedImpl : ITSc552MenuAllawed
    {
        List<TSc552MenuAllawed> itemList = new List<TSc552MenuAllawed>();
        Resultat oResultat = new Resultat();

        //string QueryString = "SELECT  dbo.TSc552MenuAllawed.ID, dbo.TSc552MenuAllawed.Module, dbo.TSc552MenuAllawed.SubMenuID, " +
        //             "dbo.TSc552MenuAllawed.MUserID, dbo.TSc552MenuAllawed.SelectAllowed, dbo.TSc552MenuAllawed.InsertAllowed,  " +
        //            "dbo.TSc552MenuAllawed.UpdateAllowed, dbo.TSc552MenuAllawed.DeleteAllowed, dbo.TSc552MenuAllawed.CreatBy,  " +
        //            "dbo.TSc552MenuAllawed.CreatOn, dbo.TSc552MenuAllawed.LModifBy, dbo.TSc552MenuAllawed.LModifOn,  " +
        //            "dbo.TSc551User.UserName AS MUserName, dbo.TSc551SubMenu.Descript AS SMenuName " +
        //            "FROM     dbo.TSc551User INNER JOIN " +
        //            "dbo.TSc552MenuAllawed ON dbo.TSc551User.ID = dbo.TSc552MenuAllawed.MUserID INNER JOIN " +
        //            "dbo.TSc551SubMenu ON dbo.TSc552MenuAllawed.SubMenuID = dbo.TSc551SubMenu.ID ";

        public async Task<List<TSc552MenuAllawed>> GetList(int id)
        {
            itemList = new List<TSc552MenuAllawed>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSc552MenuAllawed>("Ps_UpdateMnuAlllowed", RenseignerPrmCompos(id), commandType: CommandType.StoredProcedure);


                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        private DynamicParameters RenseignerPrmCompos(int id)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@RolID", id);

            return oParameters;

        }

        public async Task<Resultat> GetUpdateResult(TSc552MenuAllawed item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc552MenuAllawed", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        private DynamicParameters RenseignerPrmUpdate(TSc552MenuAllawed item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Module", item.Module);
            oParameters.Add("@SubMenuID", item.SubMenuID);
            oParameters.Add("@MUserID", item.MUserID);
            oParameters.Add("@SelectAllowed", item.SelectAllowed);
            oParameters.Add("@InsertAllowed", item.InsertAllowed);
            oParameters.Add("@UpdateAllowed", item.UpdateAllowed);
            oParameters.Add("@DeleteAllowed", item.DeleteAllowed);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;

        }


    }
}
