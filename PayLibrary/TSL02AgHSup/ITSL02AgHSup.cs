using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL02AgHSup
{
   public interface ITSL02AgHSup
    {
        Task<List<ClassTSL02AgHSup>> GetTSL02AgHSup();
        Task<List<ClassTSL02AgHSup>> GetTSL02AgHSupByAgent(int id);
        Task<Resultat> GetUpdateResult(ClassTSL02AgHSup item);
    }
}
