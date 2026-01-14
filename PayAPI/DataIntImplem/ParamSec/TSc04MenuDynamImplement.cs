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
    public class TSc04MenuDynamImplement : ITSc04MenuDynam
    {

        private IEnumerable<TSc04MenuDynam> oTSc04MenuDynamList = new List<TSc04MenuDynam>();
        //private TSc04MenuDynam oTSc04MenuDynamRecord = new TSc04MenuDynam();


        //public async Task<TSc04MenuDynam> GetMenuDynam(string Param)
        //{
        //    oTSc04MenuDynamRecord = new TSc04MenuDynam();

        //    using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //    {
        //        if (oCon.State == ConnectionState.Closed) oCon.Open();
        //        var vTSc04MenuDynamRecord = await oCon.QueryAsync<TSc04MenuDynam>("Ps_SecMenuAfficherOne", RenseignerPrmCompos(Param), commandType: CommandType.StoredProcedure);

        //        if (vTSc04MenuDynamRecord != null && vTSc04MenuDynamRecord.Count() > 0)
        //        {
        //            oTSc04MenuDynamRecord = vTSc04MenuDynamRecord.FirstOrDefault();
        //        }
        //    }

        //    return oTSc04MenuDynamRecord;
        //} 

        public async Task<List<TSc04MenuDynam>> GetMenuDynamList()
        {
            List<TSc04MenuDynam> oTSc04MenuDynamList = new List<TSc04MenuDynam>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTSc04MenuDynamList = await oCon.QueryAsync<TSc04MenuDynam>("Ps_MenuAffDynamMenu", commandType: CommandType.StoredProcedure);

                if (vTSc04MenuDynamList != null && vTSc04MenuDynamList.Count() > 0)
                {
                    oTSc04MenuDynamList = vTSc04MenuDynamList.ToList();
                }
            }

            return oTSc04MenuDynamList;
        }


        public async Task<Resultat> GetUpdateResult(TSc04MenuDynam item)
        {
            Resultat oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc04MenuDynam", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);
                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TSc04MenuDynam item)

        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", item.ID);
            oParameters.Add("@PageRoute", item.PageRoute);
            oParameters.Add("@MenuName", item.MenuName);
            oParameters.Add("@ParentMenuId", item.ParentMenuId);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }


        //private DynamicParameters RenseignerIDRole(int RoleId)
        //{
        //    DynamicParameters oParameters = new DynamicParameters();

        //    oParameters.Add("@RoleId", RoleId);

        //    return oParameters;

        //}


        //private DynamicParameters RenseignerPrmCompos(string Param)
        //{
        //    DynamicParameters oParameters = new DynamicParameters();

        //    oParameters.Add("@Param", Param);

        //    return oParameters;

        //}


    }
}
