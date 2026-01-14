using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.Cl550Branch
{
    public interface ITCl550Branch
    {
        Task<List<ClassTCl550Branch>> GetT550Branch();
    }
}
