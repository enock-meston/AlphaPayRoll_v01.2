using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL02AgDimAugmSal
{
    public interface ITSL02AgDimAugmSal
    {
        Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSal();
        Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSalByAgent(int id);
        Task<Resultat> GetUpdateResult(ClassTSL02AgDimAugmSal item);
    }
}
