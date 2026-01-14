using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550NivEtudId
{
   public interface ITCl550NivEtudId
    {
        Task<List<ClassTCl550NivEtudId>> GetTCl550NivEtudId();
    }
}
