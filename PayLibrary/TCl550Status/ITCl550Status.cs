using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550Status
{
    public interface ITCl550Status
    {
        Task<List<ClassTCl550Status>> GetTCl550Status();
    }
}
