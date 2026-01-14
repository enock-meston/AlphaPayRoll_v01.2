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
    public class TSc552PrmAllowedImpl : ITSc552PrmAllowed
    {
        List<TSc552PrmAllowed> itemList = new List<TSc552PrmAllowed>();
        Resultat oResultat = new Resultat();
        //TableName
        string QueryString = "SELECT  dbo.TSc552PrmAllowed.ID, dbo.TSc552PrmAllowed.Module, dbo.TSc552PrmAllowed.PrmTableID, " +
                     "dbo.TSc552PrmAllowed.MUserID, dbo.TSc552PrmAllowed.SelectAllowed, dbo.TSc552PrmAllowed.InsertAllowed,  " +
                    "dbo.TSc552PrmAllowed.UpdateAllowed, dbo.TSc552PrmAllowed.DeleteAllowed, dbo.TSc552PrmAllowed.CreatBy,  " +
                    "dbo.TSc552PrmAllowed.CreatOn, dbo.TSc552PrmAllowed.LModifBy, dbo.TSc552PrmAllowed.LModifOn,  " +
                    "dbo.TSc551User.UserName AS MUserName, dbo.TSc06PrmTable.TableName AS SDonBaseName " +
                    "FROM     dbo.TSc551User INNER JOIN " +
                    "dbo.TSc552PrmAllowed ON dbo.TSc551User.ID = dbo.TSc552PrmAllowed.MUserID INNER JOIN " +
                    "dbo.TSc06PrmTable ON dbo.TSc552PrmAllowed.PrmTableID = dbo.TSc06PrmTable.ID ";

        public async Task<List<TSc552PrmAllowed>> GetList()
        {
            itemList = new List<TSc552PrmAllowed>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSc552PrmAllowed>(QueryString);
                //var List = await oCon.QueryAsync<TSc552PrmAllowed>("Select * from TSc552PrmAllowed");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TSc552PrmAllowed item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc552PrmAllowed", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        private DynamicParameters RenseignerPrmUpdate(TSc552PrmAllowed item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@ID", item.ID);
            oParameters.Add("@Module", item.Module);
            oParameters.Add("@PrmTableID", item.PrmTableID);
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
