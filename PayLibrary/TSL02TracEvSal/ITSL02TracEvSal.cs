using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL02TracEvSal
{
   public  interface ITSL02TracEvSal
    {
        Task<List<ClassTSL02TracEvSal>> GetTSL02TracEvSal();
        Task<Resultat> GetUpdateResult(ClassTSL02TracEvSal item);
    }
}
