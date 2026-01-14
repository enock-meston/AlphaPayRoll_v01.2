using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Gravite
{
   public interface ITRH042Gravite
    {
        Task<List<TRH042Gravite>> GetListAll();
    }
}
