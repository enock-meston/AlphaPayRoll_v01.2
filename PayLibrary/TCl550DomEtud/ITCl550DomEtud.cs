using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TCl550DomEtud
{
    public interface ITCl550DomEtud
    {
        Task<List<ClassTCl550DomEtud>> GetTCl550DomEtud();
    }
}
