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
    public class TSc550RoleImpl : ITSc550Role
    {
        List<TSc550Role> itemList = new List<TSc550Role>();
        Resultat oResultat = new Resultat();


        public async Task<List<TSc550Role>> GetList(int id)
        {
            itemList = new List<TSc550Role>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var List = await oCon.QueryAsync<TSc550Role>("Select * from TSc550Role");

                if (List != null && List.Count() > 0)
                {
                    itemList = List.ToList();
                }
            }
            return itemList;
        }

        public async Task<Resultat> GetUpdateResult(TSc550Role item)
        {
            oResultat = new Resultat();
            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {

                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc550Role", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);

                    oResultat = oRecord.FirstOrDefault();


                }
            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }



        private DynamicParameters RenseignerPrmUpdate(TSc550Role item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            //oParameters.Add("@ID", item.ID);
            //oParameters.Add("@Module", item.Module);
            //oParameters.Add("@SubMenuID", item.SubMenuID);
            //oParameters.Add("@RoleID", item.RoleID);
            //oParameters.Add("@SelectAllowed", item.SelectAllowed);
            //oParameters.Add("@InsertAllowed", item.InsertAllowed);
            //oParameters.Add("@UpdateAllowed", item.UpdateAllowed);
            //oParameters.Add("@DeleteAllowed", item.DeleteAllowed);
            //oParameters.Add("@UserID", item.UserID);
            //oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }


    }
}
