using Dapper;
using PayAPI.StringCon;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PayAPI.DataIntImplem.ParamSec
{
    public class UserLoginImplement : IUserLogin
    {

        private UserLoginDon oUserLoginList = new UserLoginDon();
        private Resultat oResult = new Resultat();
        public async Task<UserLoginDon> GetAuthentication(UserLoginParam oUserLoginParam)
        {



            oUserLoginList = new UserLoginDon();

            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {

                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vUserLoginList = await oCon.QueryAsync<UserLoginDon>("Ps_UserLogin", RenseignerPrmLogin(oUserLoginParam), commandType: CommandType.StoredProcedure);

                if (vUserLoginList != null && vUserLoginList.Count() > 0)
                {
                    oUserLoginList = vUserLoginList.SingleOrDefault();
                }

            }

            return oUserLoginList;

        }

        public async Task<Resultat> GetResultChangePsw(ParamChangPsw item)
        {
            oResult = new Resultat();
            using (IDbConnection oCon = new SqlConnection(ClassConString.sConnectionString))
            {
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var vItem = await oCon.QueryAsync<Resultat>("Ps_SecChangePassWord", RenseignerPrmChangePsw(item), commandType: CommandType.StoredProcedure);

                if (vItem != null && vItem.Count() > 0)
                {
                    oResult = vItem.SingleOrDefault();
                }
            }

            return oResult;
        }


        private DynamicParameters RenseignerPrmChangePsw(ParamChangPsw item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@OldPsw", item.OldPsw);
            oParameters.Add("@NewPsw", item.NewPsw);
            oParameters.Add("@UserID", item.UserID);


            return oParameters;
        }

        private DynamicParameters RenseignerPrmLogin(UserLoginParam item)
        {
            DynamicParameters oParameters = new DynamicParameters();
            oParameters.Add("@UserName", item.UserName);
            oParameters.Add("@PassWord", item.PassWord);


            return oParameters;
        }



    }
}
