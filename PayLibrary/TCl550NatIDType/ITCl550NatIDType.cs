using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550NatIDType
{
   public interface ITCl550NatIDType
    {
        Task<List<ClassTCl550NatIDType>> GetIdType();
    }
}
