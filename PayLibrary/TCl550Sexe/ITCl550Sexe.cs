using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550Sexe
{
    public interface ITCl550Sexe
    {
        Task<List<ClassTCl550Sexe>> GetTCl550Sexe();
    }
}
