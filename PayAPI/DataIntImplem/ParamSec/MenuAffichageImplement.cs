using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ParamSec
{
    public class MenuAffichageImplement : IMenuAffichage
    {


        private List<MenuAffichage> oMenuAffichageList = new List<MenuAffichage>();
        private MenuAffichage oMenuAffichage = new MenuAffichage();

        //public async Task<List<MenuAffichage>> GetFonctionMenu()
        //{
        //    oMenuAffichageList = new List<MenuAffichage>();

        //    using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //    {
        //        if (oCon.State == ConnectionState.Closed) oCon.Open();
        //        var vMenuAffichageList = await oCon.QueryAsync<MenuAffichage>("Ps_MenuAffSubMenuTout",  commandType: CommandType.StoredProcedure);

        //        if (vMenuAffichageList != null && vMenuAffichageList.Count() > 0)
        //        {
        //            oMenuAffichageList = vMenuAffichageList.ToList();
        //        }
        //    }

        //    return oMenuAffichageList;
        //}

        public async Task<List<MenuAffichage>> GetMenuFonctList(string Param)
        {


            oMenuAffichageList = new List<MenuAffichage>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vMenuAffichageList = await oCon.QueryAsync<MenuAffichage>("Ps_MenuAffFonctMenu", RenseignerPrmCompos(Param), commandType: CommandType.StoredProcedure);

                if (vMenuAffichageList != null && vMenuAffichageList.Count() > 0)
                {
                    oMenuAffichageList = vMenuAffichageList.ToList();
                }
            }

            return oMenuAffichageList;


        }


        public async Task<MenuAffichage> GetMenuFonctOne(int id)
        {


            oMenuAffichage = new MenuAffichage();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vMenuAffichage = await oCon.QueryAsync<MenuAffichage>("Select ROW_NUMBER() over (order By ID) as ID,Descript,PageRoute from TSc06PrmTable where ID=" + id);

                if (vMenuAffichage != null && vMenuAffichage.Count() > 0)
                {
                    oMenuAffichage = vMenuAffichage.FirstOrDefault();
                }
            }

            return oMenuAffichage;


        }

        //public async Task<MenuAffichage> GetMenuFonctTwo(int id)
        //{
        //    oMenuAffichage = new MenuAffichage();

        //    using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
        //    {
        //        if (oCon.State == ConnectionState.Closed) oCon.Open();
        //        var vMenuAffichage = await oCon.QueryAsync<MenuAffichage>("Select ID,Descript,PageRoute from TSc06PrmTableN2 where ID=" + id);

        //        if (vMenuAffichage != null && vMenuAffichage.Count() > 0)
        //        {
        //            oMenuAffichage = vMenuAffichage.FirstOrDefault();
        //        }
        //    }

        //    return oMenuAffichage;
        //}

        private DynamicParameters RenseignerPrmCompos(string Param)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Param", Param);

            return oParameters;

        }





    }
}
