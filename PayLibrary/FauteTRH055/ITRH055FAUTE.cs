using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.FauteTRH055
{
    public interface ITRH055FAUTE
    {
        Task<List<TRH055FAUTE>> GetListAll();
        //Task<List<TRH055FAUTE>> GetListByMatricule();
    }
}
