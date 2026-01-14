using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550User
{
    public interface ITCl550User
    {
        Task<List<ClassTCl550User>> GetTCl550User();
    }
}
