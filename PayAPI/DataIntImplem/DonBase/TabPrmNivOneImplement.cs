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
    public class TabPrmNivOneImplement : ITabPrmNivOne
    {
        private IList<TabPrmNivOne> oTabPrmNivOneList = new List<TabPrmNivOne>();
        private TabPrmNivOne oTabPrmNivOneRecord = new TabPrmNivOne();
        private Resultat oResultat = new Resultat();

        public async Task<IList<TabPrmNivOne>> GetDBList(int CodeObj)
        {
            oTabPrmNivOneList = new List<TabPrmNivOne>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTabPrmNivOneList = await oCon.QueryAsync<TabPrmNivOne>("Ps_DBNivOneAffTable", RenseignerIDTable(CodeObj), commandType: CommandType.StoredProcedure);

                if (vTabPrmNivOneList != null && vTabPrmNivOneList.Count() > 0)
                {
                    oTabPrmNivOneList = vTabPrmNivOneList.ToList();
                }
            }

            return oTabPrmNivOneList;

        }


        public async Task<IList<TabPrmNivOne>> GetDBListName(string Param)
        {
            oTabPrmNivOneList = new List<TabPrmNivOne>();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTabPrmNivOneList = await oCon.QueryAsync<TabPrmNivOne>("Ps_DBNivOneTableNom", RenseignerPrmCompos(Param), commandType: CommandType.StoredProcedure);

                if (vTabPrmNivOneList != null && vTabPrmNivOneList.Count() > 0)
                {
                    oTabPrmNivOneList = vTabPrmNivOneList.ToList();
                }
            }

            return oTabPrmNivOneList;

        }



        public async Task<TabPrmNivOne> GetDBRec(string Param)
        {
            oTabPrmNivOneRecord = new TabPrmNivOne();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vTabPrmNivOneList = await oCon.QueryAsync<TabPrmNivOne>("Ps_DBNivOneAffRecord", RenseignerPrmCompos(Param), commandType: CommandType.StoredProcedure);

                if (vTabPrmNivOneList != null && vTabPrmNivOneList.Count() > 0)
                {
                    oTabPrmNivOneRecord = vTabPrmNivOneList.FirstOrDefault();
                }
            }

            return oTabPrmNivOneRecord;
        }



        public async Task<Resultat> MajDonBaseNivOne(TabPrmNivOne pTabPrmNivOne)
        {

            oResultat = new Resultat();



            try
            {

                using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
                {



                    if (oCon.State == ConnectionState.Closed) oCon.Open();

                    var sResultat = await oCon.QueryAsync<Resultat>("Ps_MajPrmTabNivOne", this.RenseignerParamMaj(pTabPrmNivOne), commandType: CommandType.StoredProcedure);

                    oResultat = sResultat.FirstOrDefault();



                }

            }
            catch (Exception ex)
            {

                oResultat.Result = ex.Message;
            }

            return oResultat;
        }


        private DynamicParameters RenseignerIDTable(int IDTable)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@CodeObj", IDTable);

            return oParameters;

        }


        private DynamicParameters RenseignerPrmCompos(string Param)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@Param", Param);

            return oParameters;

        }



        private DynamicParameters RenseignerParamMaj(TabPrmNivOne TabPrmNivOne)
        {
            DynamicParameters oParameters = new DynamicParameters();

            oParameters.Add("@ID", TabPrmNivOne.ID);
            oParameters.Add("@RICode", TabPrmNivOne.RICode);
            oParameters.Add("@Descript", TabPrmNivOne.Descript);
            oParameters.Add("@Enab", TabPrmNivOne.Enab);
            oParameters.Add("@OrdNum", TabPrmNivOne.OrdNum);
            oParameters.Add("@UserID", TabPrmNivOne.UserID);
            oParameters.Add("@CodeObj", TabPrmNivOne.CodeObj);
            oParameters.Add("@TpMaj", TabPrmNivOne.TpMaj);

            return oParameters;

        }


    }
}
