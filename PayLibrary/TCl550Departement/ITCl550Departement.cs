using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550Departement
{
   public interface ITCl550Departement
    {
        Task<List<ClassTCl550Departement>> GetTCl550Departement();
    }
}
