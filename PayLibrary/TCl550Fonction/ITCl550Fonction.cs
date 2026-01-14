using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550Fonction
{
   public interface ITCl550Fonction
    {
        Task<List<ClassTCl550Fonction>> GetTCl550Fonction();
    }
}
