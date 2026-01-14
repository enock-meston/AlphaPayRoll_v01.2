using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfParamSec
{
    public interface IUserLogin
    {
        Task<UserLoginDon> GetAuthentication(UserLoginParam oUserLoginParam);
        Task<Resultat> GetResultChangePsw(ParamChangPsw item);
    }
}
