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
    public class TSc551SubMenuImplement : ITSc551SubMenu
    {
        private List<TSc551SubMenu> oTSc551SubMenuList = new List<TSc551SubMenu>();
        private TSc551SubMenu oTSc551SubMenu = new TSc551SubMenu();

        public async Task<List<TSc551SubMenu>> GetSubMenuList()
        {


            oTSc551SubMenuList = new List<TSc551SubMenu>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTSc551SubMenuList = await oCon.QueryAsync<TSc551SubMenu>("Ps_MenuAffSubMenu", commandType: CommandType.StoredProcedure);

                if (vTSc551SubMenuList != null && vTSc551SubMenuList.Count() > 0)
                {
                    oTSc551SubMenuList = vTSc551SubMenuList.ToList();
                }
            }

            return oTSc551SubMenuList;


        }
        public async Task<List<TSc551SubMenu>> GetListAll()
        {
            List<TSc551SubMenu> list = new List<TSc551SubMenu>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var items = await oCon.QueryAsync<TSc551SubMenu>("Select * from TSc551SubMenu");

                if (items != null && items.Count() > 0)
                {
                    list = items.ToList();
                }
            }
            return list;
        }

        public async Task<TSc551SubMenu> GetSubMenu(int id)
        {
            oTSc551SubMenu = new TSc551SubMenu();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTSc551SubMenu = await oCon.QueryAsync<TSc551SubMenu>("Select ID,Descript,PageRoute from TSc551SubMenu where ID=" + id);

                if (vTSc551SubMenu != null && vTSc551SubMenu.Count() > 0)
                {
                    oTSc551SubMenu = vTSc551SubMenu.FirstOrDefault();
                }
            }

            return oTSc551SubMenu;
        }

        private DynamicParameters RenseignerPrm(string Param)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Param", Param);

            return oParameters;

        }

        public async Task<Resultat> GetUpdateResult(TSc551SubMenu item)
        {
            Resultat oResultat = new Resultat();
            try
            {
                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {
                    if (oCon.State == ConnectionState.Closed) oCon.Open();
                    var oRecord = await oCon.QueryAsync<Resultat>("Ps_TSc551SubMenu", this.RenseignerPrmUpdate(item), commandType: CommandType.StoredProcedure);
                    oResultat = oRecord.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                oResultat.Result = ex.Message;
            }
            return oResultat;
        }

        private DynamicParameters RenseignerPrmUpdate(TSc551SubMenu item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@@ID", item.ID);
            oParameters.Add("@Groupe", item.Groupe);
            oParameters.Add("@Descript", item.Descript);
            oParameters.Add("@CodeModule", item.CodeModule);
            oParameters.Add("@PageRoute", item.PageRoute);
            oParameters.Add("@Enab", item.Enab);
            oParameters.Add("@OrdNum", item.OrdNum);
            oParameters.Add("@MainMenID", item.MainMenID);
            oParameters.Add("@UserID", item.UserID);
            oParameters.Add("@TpMaj", item.TpMaj);
            return oParameters;
        }

        public async Task<List<TSc551SubMenu>> GetFonctionMenu()
        {
            oTSc551SubMenuList = new List<TSc551SubMenu>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vMenuAffichageList = await oCon.QueryAsync<TSc551SubMenu>("Ps_MenuAffSubMenuTout", commandType: CommandType.StoredProcedure);

                if (vMenuAffichageList != null && vMenuAffichageList.Count() > 0)
                {
                    oTSc551SubMenuList = vMenuAffichageList.ToList();
                }
            }

            return oTSc551SubMenuList;
        }



    }
}
