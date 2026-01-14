using PayLibrary.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ListePaie
{
    public interface ILstPaieConsolid
    {
        Task<List<LstPaieConsolid>> GetTout();
    }
}
