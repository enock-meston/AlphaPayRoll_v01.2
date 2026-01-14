using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL550TpDimAugSal
{
    public interface ITSL550TpDimAugSal
    {
        Task<List<ClassTSL550TpDimAugSal>> GetTSL550TpDimAugSal();
        Task<Resultat> GetUpdateResult(ClassTSL550TpDimAugSal item);
    }
}
