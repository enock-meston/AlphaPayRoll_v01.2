using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550Universite
{
   public interface ITCl550Universite
    {
        Task<List<ClassTCl550Universite>> GetTCl550Universite();
    }
}
