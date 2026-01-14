using PayLibrary.ParamDonBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.InterfPrmDonBase
{
    public interface ITSc551MenuDonBase
    {
        Task<IList<TSc551MenuDonBase>> GetMenuDonBaseList();
        Task<TSc551MenuDonBase> GetMenuDonBase(int Id);
    }
}
