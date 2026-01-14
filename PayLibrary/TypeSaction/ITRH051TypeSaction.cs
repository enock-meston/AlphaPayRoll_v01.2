using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TypeSaction
{
   public interface ITRH051TypeSaction
    {
        Task<List<TRH051TypeSaction>> GetListAll();
    }
}
